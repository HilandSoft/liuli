namespace YingNet.WeiXing.Business
{
    using System;

    public class BaseConfManager : WebConfigManager
    {
        public static WebConfigManager webConf = new WebConfigManager();

        public static string GetAppName()
        {
            return webConf.GetValue("AppName");
        }

        public static string GetConnectionStr()
        {
            return ("server=" + GetDBServer() + ";database=" + GetDBName() + ";user id=" + GetDBUser() + ";pwd=" + GetDBPwd());
        }

        public static string GetDBName()
        {
            return webConf.GetValue("DBName");
        }

        public static string GetDBPwd()
        {
            return webConf.GetValue("DBPwd");
        }

        public static string GetDBServer()
        {
            return webConf.GetValue("DBServer");
        }

        public static string GetDBType()
        {
            return webConf.GetValue("DBType");
        }

        public static string GetDBUser()
        {
            return webConf.GetValue("DBUser");
        }

        public static string GetDiskName()
        {
            return webConf.GetValue("DiskName");
        }

        public static string GetFilePath()
        {
            return webConf.GetValue("filePath");
        }

        public static string GetImagePath()
        {
            return webConf.GetValue("imagePath");
        }

        public static string GetImagePath1()
        {
            return webConf.GetValue("imagePath1");
        }

        public static string GetKeyValue(string key)
        {
            return webConf.GetValue(key);
        }

        public static string GetMailPassWord()
        {
            return webConf.GetValue("MailPassWord");
        }

        public static string GetMailReceiver()
        {
            return webConf.GetValue("MailReceiver");
        }

        public static string GetMailSender()
        {
            return webConf.GetValue("MailSender");
        }

        public static string GetMailServer()
        {
            return webConf.GetValue("MailServer");
        }

        public static string GetMailUserName()
        {
            return webConf.GetValue("MailUserName");
        }

        public static string GetPicPath()
        {
            return webConf.GetValue("PicPath");
        }
    }
}

