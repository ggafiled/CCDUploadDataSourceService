using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.IO;
using System.Globalization;

namespace CCDUploadDataSourceService
{
    enum LogType
    {
        ADD_TO_QUEUE,
        QUEUE_PROCESS
    }

    enum DataSourceType
    {
        COABOS,
        Density,
        OPMS_KPI,
        LDM,
        Volume
    }

    class Util
    {
        public Util()
        {
            
        }

        public static bool isDirectoryEmpty(string rootPathIn, string fileExtension)
        {
            return Directory.GetFiles(rootPathIn, fileExtension, SearchOption.TopDirectoryOnly).Length == 0;
        }

        public static void MoveToBackup(string file, string fileName, string rootPathBackUp, LogType logType = LogType.ADD_TO_QUEUE)
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
                WriteToFile("ERR:" + ex.Message, logType);
            }
        }

        public static void WriteToFile(string Message, LogType logType = LogType.ADD_TO_QUEUE)
        {
            DateTime localDate = DateTime.Now;
            var culture = new CultureInfo("th-TH");
            string LogPath = AppDomain.CurrentDomain.BaseDirectory + "\\Logs\\" + (logType == LogType.ADD_TO_QUEUE ? "FileService" : "TaskQueue");
            if (!Directory.Exists(LogPath))
            {
                Directory.CreateDirectory(LogPath);
            }
            string filepath = LogPath + "\\ServiceLog_" + DateTime.Now.Date.ToString("dd_MM_yyyy") + ".txt";
            if (!File.Exists(filepath))
            {
                using (StreamWriter sw = File.CreateText(filepath))
                {
                    sw.WriteLine(localDate.ToString(culture) + " " + Message);
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
    }
}
