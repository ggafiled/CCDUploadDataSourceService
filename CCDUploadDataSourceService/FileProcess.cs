using System;
using System.IO;
using System.ServiceProcess;
using System.Text;
using System.Configuration;
using RabbitMQ.Client;
using System.Timers;
using static CCDUploadDataSourceService.Global;
using CCDUploadDataSourceService.Model;
using Newtonsoft.Json;

namespace CCDUploadDataSourceService
{
    public partial class FileProcess : ServiceBase
    {
        Timer timer = new Timer();
        private static ConnectionFactory mqFactory;
        private static IConnection mqConnection;
        private static IModel mqChannel;
        private static IBasicProperties mqProperties;

        public FileProcess()
        {
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {
            try
            {
                Util.WriteToFile("Start service [FileProcess]");
                Util.WriteToFile($"LOG: Fous on {coabosRootPathIn}, {densityRootPathIn}, {opmsRootPathIn}, {volumeRootPathIn}");

                mqFactory = new ConnectionFactory() { HostName = mqHost, UserName = mqUsername, Password = mqPassword };
                mqConnection = mqFactory.CreateConnection();
                mqChannel = mqConnection.CreateModel();
                mqProperties = mqChannel.CreateBasicProperties();
                mqProperties.Persistent = true;

                timer.Elapsed += new ElapsedEventHandler(OnElapsedTime);
                timer.Interval = 180000;
                timer.Enabled = true;

                System.Threading.Thread task_queue_threading = new System.Threading.Thread(new System.Threading.ThreadStart(TaskQueue.OnStart));
                task_queue_threading.Start();
            }
            catch (Exception ex)
            {
                Util.WriteToFile("ERR:" + ex.Message);
            }
        }

        public void OnDebug()
        {
            OnStart(null);
        }

        protected override void OnStop()
        {
            timer.Stop();
            Util.WriteToFile("Stop service");
        }

        protected void OnElapsedTime(object source, ElapsedEventArgs e)
        {
            //COABOS Folder
            if (!Util.isDirectoryEmpty(coabosRootPathIn, coabosFileExtension))
            {
                Util.WriteToFile("LOG:---------- Start Process ----------");

                string[] files = Directory.GetFiles(coabosRootPathIn, coabosFileExtension, SearchOption.TopDirectoryOnly);
                foreach (string file in files)
                {
                    try
                    {
                        Util.WriteToFile("LOG: Has file in directory");
                        string fileName = Path.GetFileName(file);
                        Util.WriteToFile("LOG: Processing: " + fileName);

                        File.Move(file, Path.Combine(coabosRootPathBackUp, fileName));
                        Util.WriteToFile("LOG: Moved to queue folder: " + fileName);

                        var content = new CCDMessage { fileName = Path.Combine(coabosRootPathBackUp, fileName), sourceType = DataSourceType.COABOS };
                        var body = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(content));

                        mqChannel.BasicPublish(exchange: "", routingKey: mqChannelName, basicProperties: mqProperties, body: body);
                        Util.WriteToFile("LOG: Added to queue["+mqChannelName+"]: " + fileName);
                    }
                    catch (Exception ex)
                    {
                        Util.WriteToFile("ERR:" + ex.Message);
                    }
                }
                Util.WriteToFile("LOG:---------- End Process ----------");
            }

            //OPMS_KPI Folder
            if (!Util.isDirectoryEmpty(opmsRootPathIn, opmsFileExtension))
            {
                Util.WriteToFile("LOG:---------- Start Process ----------");

                string[] files = Directory.GetFiles(opmsRootPathIn, opmsFileExtension, SearchOption.TopDirectoryOnly);
                foreach (string file in files)
                {
                    try
                    {
                        Util.WriteToFile("LOG: Has file in directory");
                        string fileName = Path.GetFileName(file);
                        Util.WriteToFile("LOG: Processing: " + fileName);

                        File.Move(file, Path.Combine(opmsRootPathBackUp, fileName));
                        Util.WriteToFile("LOG: Moved to queue folder: " + fileName);

                        var content = new CCDMessage { fileName = Path.Combine(opmsRootPathBackUp, fileName), sourceType = DataSourceType.OPMS_KPI };
                        var body = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(content));

                        mqChannel.BasicPublish(exchange: "", routingKey: mqChannelName, basicProperties: mqProperties, body: body);
                        Util.WriteToFile("LOG: Added to queue[" + mqChannelName + "]: " + fileName);
                    }
                    catch (Exception ex)
                    {
                        Util.WriteToFile("ERR:" + ex.Message);
                    }
                }
                Util.WriteToFile("LOG:---------- End Process ----------");
            }


            //Volume_KPI Folder
            if (!Util.isDirectoryEmpty(volumeRootPathIn, volumeFileExtension))
            {
                Util.WriteToFile("LOG:---------- Start Process ----------");

                string[] files = Directory.GetFiles(volumeRootPathIn, volumeFileExtension, SearchOption.TopDirectoryOnly);
                foreach (string file in files)
                {
                    try
                    {
                        Util.WriteToFile("LOG: Has file in directory");
                        string fileName = Path.GetFileName(file);
                        Util.WriteToFile("LOG: Processing: " + fileName);

                        File.Move(file, Path.Combine(volumeRootPathBackUp, fileName));
                        Util.WriteToFile("LOG: Moved to queue folder: " + fileName);

                        var content = new CCDMessage { fileName = Path.Combine(volumeRootPathBackUp, fileName), sourceType = DataSourceType.Volume };
                        var body = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(content));

                        mqChannel.BasicPublish(exchange: "", routingKey: mqChannelName, basicProperties: mqProperties, body: body);
                        Util.WriteToFile("LOG: Added to queue[" + mqChannelName + "]: " + fileName);
                    }
                    catch (Exception ex)
                    {
                        Util.WriteToFile("ERR:" + ex.Message);
                    }
                }
                Util.WriteToFile("LOG:---------- End Process ----------");
            }

            //Density Folder
            if (!Util.isDirectoryEmpty(densityRootPathIn, densityFileExtension))
            {
                Util.WriteToFile("LOG:---------- Start Process ----------");

                string[] files = Directory.GetFiles(densityRootPathIn, densityFileExtension, SearchOption.TopDirectoryOnly);
                foreach (string file in files)
                {
                    try
                    {
                        Util.WriteToFile("LOG: Has file in directory");
                        string fileName = Path.GetFileName(file);
                        Util.WriteToFile("LOG: Processing: " + fileName);

                        File.Move(file, Path.Combine(densityRootPathBackUp, fileName));
                        Util.WriteToFile("LOG: Moved to queue folder: " + fileName);

                        var content = new CCDMessage { fileName = Path.Combine(densityRootPathBackUp, fileName), sourceType = DataSourceType.Density };
                        var body = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(content));

                        mqChannel.BasicPublish(exchange: "", routingKey: mqChannelName, basicProperties: mqProperties, body: body);
                        Util.WriteToFile("LOG: Added to queue[" + mqChannelName + "]: " + fileName);
                    }
                    catch (Exception ex)
                    {
                        Util.WriteToFile("ERR:" + ex.Message);
                    }
                }
                Util.WriteToFile("LOG:---------- End Process ----------");
            }
        }

    }
}
