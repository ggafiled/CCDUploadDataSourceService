using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CCDUploadDataSourceService
{
    public static class Global
    {
        //COABOS
        public static string coabosRootPathIn = ConfigurationManager.AppSettings["COABOS_INPUT_DIRECTORY"];
        public static string coabosRootPathBackUp = ConfigurationManager.AppSettings["COABOS_BACKUP_DIRECTORY"];
        public static string coabosRootPathBackUpIncorrect = ConfigurationManager.AppSettings["COABOS_BACKUP_INCORECTFORMAT_DIRECTORY"];
        public static string coabosFileExtension = ConfigurationManager.AppSettings["COABOS_FILE_EXTENSION"];

        //OPMS_KPI
        public static string opmsRootPathIn = ConfigurationManager.AppSettings["OPMS_INPUT_DIRECTORY"];
        public static string opmsRootPathBackUp = ConfigurationManager.AppSettings["OPMS_BACKUP_DIRECTORY"];
        public static string opmsRootPathBackUpIncorrect = ConfigurationManager.AppSettings["OPMS_BACKUP_INCORECTFORMAT_DIRECTORY"];
        public static string opmsFileExtension = ConfigurationManager.AppSettings["OPMS_FILE_EXTENSION"];

        //Volume_KPI
        public static string volumeRootPathIn = ConfigurationManager.AppSettings["VOLUME_INPUT_DIRECTORY"];
        public static string volumeRootPathBackUp = ConfigurationManager.AppSettings["VOLUME_BACKUP_DIRECTORY"];
        public static string volumeRootPathBackUpIncorrect = ConfigurationManager.AppSettings["VOLUME_BACKUP_INCORECTFORMAT_DIRECTORY"];
        public static string volumeFileExtension = ConfigurationManager.AppSettings["VOLUME_FILE_EXTENSION"];

        //Density
        public static string densityRootPathIn = ConfigurationManager.AppSettings["DENSITY_INPUT_DIRECTORY"];
        public static string densityRootPathBackUp = ConfigurationManager.AppSettings["DENSITY_BACKUP_DIRECTORY"];
        public static string densityRootPathBackUpIncorrect = ConfigurationManager.AppSettings["DENSITY_BACKUP_INCORECTFORMAT_DIRECTORY"];
        public static string densityFileExtension = ConfigurationManager.AppSettings["DENSITY_FILE_EXTENSION"];

        //Draft
        public static string draftRootPathIn = ConfigurationManager.AppSettings["DRAFT_INPUT_DIRECTORY"];
        public static string draftRootPathBackUp = ConfigurationManager.AppSettings["DRAFT_BACKUP_DIRECTORY"];
        public static string draftRootPathBackUpIncorrect = ConfigurationManager.AppSettings["DRAFT_BACKUP_INCORECTFORMAT_DIRECTORY"];
        public static string draftFileExtension = ConfigurationManager.AppSettings["DRAFT_FILE_EXTENSION"];

        //RabbitMQ
        public static string connetionString = ConfigurationManager.ConnectionStrings["CCDDataSource"].ConnectionString;
        public static string mqHost = ConfigurationManager.AppSettings["MQ_HOST"];
        public static string mqUsername = ConfigurationManager.AppSettings["MQ_USERNAME"];
        public static string mqPassword = ConfigurationManager.AppSettings["MQ_PASSWORD"];
        public static string mqChannelName = ConfigurationManager.AppSettings["MQ_CHANNEL_NAME"];
    }
}
