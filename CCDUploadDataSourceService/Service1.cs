using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Timers;
using System.Data.SqlClient;
using System.Configuration;
using System.Collections.Specialized;
using System.Globalization;
using MiniExcelLibs;
using Z.Dapper.Plus;

namespace CCDUploadDataSourceService
{
    public partial class Service1 : ServiceBase
    {
        Timer timer = new Timer();
        string rootPathIn, rootPathBackUp, rootPathBackUpIncorrect, fileExtension;
        string connetionString;

        public Service1()
        {
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {
            connetionString = ConfigurationManager.ConnectionStrings["CCDDataSource"].ConnectionString;
            rootPathIn = ConfigurationManager.AppSettings["INPUT_DIRECTORY"];
            fileExtension = ConfigurationManager.AppSettings["FILE_EXTENSION"];
            rootPathBackUp = ConfigurationManager.AppSettings["BACKUP_DIRECTORY"];
            rootPathBackUpIncorrect = ConfigurationManager.AppSettings["BACKUP_INCORECTFORMAT_DIRECTORY"];

            timer.Elapsed += new ElapsedEventHandler(OnElapsedTime);
            timer.Interval = 180000;
            timer.Enabled = true;
        }

        public void OnDebug()
        {
            OnStart(null);
        }

        protected override void OnStop()
        {
            timer.Stop();
        }

        protected async void OnElapsedTime(object source, ElapsedEventArgs e)
        {

            if (!isDirectoryEmpty())
            {
                WriteToFile("LOG:---------- Start Process ----------");

                string[] files = Directory.GetFiles(rootPathIn, fileExtension, SearchOption.TopDirectoryOnly);
                foreach (string file in files)
                {
                    try
                    {
                        WriteToFile("LOG: Has file in directory");
                        string fileName = Path.GetFileName(file);
                        WriteToFile("LOG: Processing " + fileName);
                        bool success = await processDatatoDatabase(file);
                        if (success == true)
                        {
                            MoveToBackup(file, fileName);
                            WriteToFile("Move to Backup: " + file);
                        }
                        else
                        {
                            File.Move(file, Path.Combine(rootPathBackUpIncorrect, fileName));
                            WriteToFile("Failed task can't process file: " + fileName);
                        }
                    }
                    catch (Exception ex)
                    {
                        WriteToFile("ERR:" + ex.Message);
                    }
                }
                WriteToFile("LOG:---------- End Process ----------");
            }

        }

        public async Task<bool> processDatatoDatabase(string filePath)
        {
            try
            {
                WriteToFile("LOG: initial process file: " + filePath);
                var coa_datasource = new List<COABOS>();
                using (var steam = File.OpenRead(filePath))
                {
                    coa_datasource = steam.Query<COABOS>().ToList();
                }

                coa_datasource.RemoveAll(x => String.IsNullOrEmpty(x.Waybill));
                WriteToFile("LOG: load data into list: " + filePath + " Count:" + coa_datasource.Count());
                DapperPlusManager.Entity<COABOS>().Table("COABOS").Key(x => x.Waybill).InsertIfNotExists();

                using (var connection = new SqlConnection(connetionString))
                {
                    connection.BulkMerge(coa_datasource);
                }

                WriteToFile("LOG: completed import data into database: " + filePath);

                return true;
            }
            catch (Exception ex)
            {
                WriteToFile("ERR:" + ex.Message);
                return false;
            }
        }

        public bool isDirectoryEmpty()
        {
            return Directory.GetFiles(rootPathIn, fileExtension, SearchOption.TopDirectoryOnly).Length == 0;
        }

        public void WriteToFile(string Message)
        {
            DateTime localDate = DateTime.Now;
            var culture = new CultureInfo("th-TH");
            string path = AppDomain.CurrentDomain.BaseDirectory + "\\Logs";
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
            string filepath = AppDomain.CurrentDomain.BaseDirectory + "\\Logs\\ServiceLog_" + DateTime.Now.Date.ToShortDateString().Replace('/', '_') + ".txt";
            if (!File.Exists(filepath))
            {
                using (StreamWriter sw = File.CreateText(filepath))
                {
                    sw.WriteLine(localDate.ToString(culture) +" "+ Message);
                }
            }
            else
            {
                using (StreamWriter sw = File.AppendText(filepath))
                {
                    sw.WriteLine(localDate.ToString(culture) + " " + Message);
                }
            }
        }

        public void MoveToBackup(string file,string fileName)
        {
            try
            {
                string currentMonth = DateTime.Now.Month.ToString();
                string currentYear = DateTime.Now.Year.ToString();
                string path = Path.Combine(rootPathBackUp, currentYear, currentMonth);  
                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }
                File.Move(file, Path.Combine(path, fileName));
            }
            catch (Exception ex)
            {
                WriteToFile("ERR:" + ex.Message);
            }
        }
    }
}
