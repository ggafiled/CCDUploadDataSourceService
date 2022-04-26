using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using Z.Dapper.Plus;
using System.Data.SqlClient;
using MiniExcelLibs;
using RabbitMQ.Client.Events;
using RabbitMQ.Client;
using System.Threading.Tasks;
using static CCDUploadDataSourceService.Global;
using MiniExcelLibs.OpenXml;
using CCDUploadDataSourceService.Model;
using Newtonsoft.Json;

namespace CCDUploadDataSourceService
{
    class TaskQueue
    {
        private static ConnectionFactory mqFactory;
        private static IConnection mqConnection;
        private static IModel mqChannel;
        private static IBasicProperties mqProperties;
        private static EventingBasicConsumer consumer;
        private static OpenXmlConfiguration config;

        public TaskQueue()
        {
            
        }

        public static void OnStart()
        {
            Util.WriteToFile("Start service [TaskQueue]");
            config = new OpenXmlConfiguration { SharedStringCacheSize = 500 * 1024 * 1024 };
            mqFactory = new ConnectionFactory() { HostName = mqHost, UserName = mqUsername, Password = mqPassword };
            mqConnection = mqFactory.CreateConnection();
            mqChannel = mqConnection.CreateModel();
            mqProperties = mqChannel.CreateBasicProperties();

            mqChannel.QueueDeclare(queue: mqChannelName, durable: true, exclusive: false, autoDelete: false, arguments: null);
            consumer = new EventingBasicConsumer(mqChannel);

            consumer.Shutdown += OnConsumerShutdown;
            consumer.Registered += OnConsumerRegistered;
            consumer.Unregistered += OnConsumerUnregistered;
            consumer.ConsumerCancelled += OnConsumerConsumerCancelled;
            consumer.Received += (ch, ea) =>
            {
                try
                {
                    Util.WriteToFile("LOG:---------- Start Process ----------", LogType.QUEUE_PROCESS);
                    // received message  

                    var body = Encoding.UTF8.GetString(ea.Body.ToArray());
                    var content = JsonConvert.DeserializeObject<CCDMessage>(body);

                    //string fileName = Encoding.UTF8.GetString(ea.Body.ToArray());
                    string file = Path.Combine(coabosRootPathBackUp, content.fileName);
                    // handle the received message

                    var mappings = new Dictionary<DataSourceType, Action> {
                        {
                            DataSourceType.COABOS, () => processDatatoDatabase<COABOS>(file, coabosRootPathBackUp, coabosRootPathBackUpIncorrect, ea.DeliveryTag,(s) => s.Query<COABOS>(configuration: config).Where(x =>
                            !String.IsNullOrEmpty(x.Waybill)).GroupBy(x => x.Waybill).Select(x => x.LastOrDefault()).ToList(),
                            () => DapperPlusManager.Entity<COABOS>().Table(nameof(COABOS)).Key(x => x.Waybill).InsertIfNotExists())
                        },
                        {
                            DataSourceType.Density, () => processDatatoDatabase<Density>(file, densityRootPathBackUp, densityRootPathBackUpIncorrect, ea.DeliveryTag,(s) => s.Query<Density>(configuration: config).Where(x =>
                            !String.IsNullOrEmpty(x.Date.ToString()) && 
                            !String.IsNullOrEmpty(x.Mvnm) && 
                            !String.IsNullOrEmpty(x.Destination)
                            ).GroupBy(x => new { x.Date, x.Mvnm, x.Destination }).Select(x => x.LastOrDefault()).ToList(),
                            () => DapperPlusManager.Entity<Density>().Table(nameof(Density)).Key(x => x.Date).Key(x => x.Mvnm).Key(x => x.Destination).InsertIfNotExists())
                        },
                        {
                            DataSourceType.OPMS_KPI, () => processDatatoDatabase<OPMS>(file, opmsRootPathBackUp, opmsRootPathBackUpIncorrect, ea.DeliveryTag,(s) => s.Query<OPMS>(configuration: config).Where(x =>
                            !String.IsNullOrEmpty(x.Date.ToString()) &&
                            !String.IsNullOrEmpty(x.KPI)).GroupBy(x => new { x.Date, x.KPI }).Select(x => x.LastOrDefault()).ToList(),
                            () => DapperPlusManager.Entity<OPMS>().Table(nameof(OPMS)).Key(x => x.KPI).Key(x => x.Date).InsertIfNotExists())
                        },
                        {
                            DataSourceType.Volume, () => processDatatoDatabase<Volume>(file, volumeRootPathBackUp, volumeRootPathBackUpIncorrect, ea.DeliveryTag,(s) => s.Query<Volume>(configuration: config).Where(x =>
                            !String.IsNullOrEmpty(x.HandledDate.ToString()) &&
                            !String.IsNullOrEmpty(x.HandledYear)).GroupBy(x => x.HandledDate).Select(x => x.LastOrDefault()).ToList(),
                            () => DapperPlusManager.Entity<Volume>().Table(nameof(Volume)).Key(x => x.HandledDate).InsertIfNotExists())
                        }
                    };

                    if (mappings.ContainsKey(content.sourceType))
                    {
                      mappings[content.sourceType].Invoke();
                    }
                }
                catch (Exception ex)
                {
                    Util.WriteToFile("ERR:" + ex.Message, LogType.QUEUE_PROCESS);
                }
            };
            mqChannel.BasicConsume(mqChannelName, false, consumer);

        }

        public static void processDatatoDatabase<T>(string file, string rootPathBackUp, string rootPathBackUpIncorrect, ulong deliveryTag, Func<Stream,IList<T>> dataSourceFunc, Action dapperAct)
        {
            try
            {
                Util.WriteToFile($"LOG: initial process file[{typeof(T)}]: {file}", LogType.QUEUE_PROCESS);

                if (!File.Exists(file))
                {
                    mqChannel.BasicAck(deliveryTag, false);
                    return;
                }

                using (var stream = File.OpenRead(file))
                {
                    Util.WriteToFile($"LOG: starting grep all data to model: {file}", LogType.QUEUE_PROCESS);
                    var ds = dataSourceFunc.Invoke(stream);
                    Util.WriteToFile($"LOG: end grep all data to model: {file}", LogType.QUEUE_PROCESS);
                    Util.WriteToFile($"LOG: remove empty data: {file}", LogType.QUEUE_PROCESS);

                    dapperAct.Invoke();
                    Util.WriteToFile($"LOG: load data into list: {file} Count: {ds.Count()}", LogType.QUEUE_PROCESS);

                    using (var connection = new SqlConnection(connetionString))
                    {
                        connection.BulkMerge(ds);
                        Util.WriteToFile($"LOG: completed import data into database: {file}", LogType.QUEUE_PROCESS);
                    }
                }

                Util.MoveToBackup(file, Path.GetFileName(file), rootPathBackUp);
                Util.WriteToFile($"Move to Backup: {file}", LogType.QUEUE_PROCESS);
                mqChannel.BasicAck(deliveryTag, false);
            }
            catch (Exception ex)
            {
                //File.Move(file, Path.Combine(rootPathBackUpIncorrect, Path.GetFileName(file)));
                Util.WriteToFile($"Failed task can't process file: {file}", LogType.QUEUE_PROCESS);

                Util.WriteToFile($"ERR: {ex.Message}", LogType.QUEUE_PROCESS);
                mqChannel.BasicReject(deliveryTag, true);
            }
        }

        private static void OnConsumerConsumerCancelled(object sender, ConsumerEventArgs e) { }
        private static void OnConsumerUnregistered(object sender, ConsumerEventArgs e) { }
        private static void OnConsumerRegistered(object sender, ConsumerEventArgs e) { }
        private static void OnConsumerShutdown(object sender, ShutdownEventArgs e) { }
        private static void RabbitMQ_ConnectionShutdown(object sender, ShutdownEventArgs e) { }

        public static void OnDebug()
        {
            OnStart();
        }
    }
}
