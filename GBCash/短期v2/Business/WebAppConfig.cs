namespace YingNet.WeiXing.Business
{
    using System;
    using System.Configuration;

    public class WebAppConfig
    {
        protected static string m_CNProductPath = null;
        protected static string m_ENProductPath = null;
        protected static string m_NewsPath = null;
        protected static string m_VideoFilePath = null;
        protected static string m_WebAppTitle = null;

        public static string GetFileExName(string filename)
        {
            int startIndex = filename.LastIndexOf(".");
            if (startIndex > 0)
            {
                return filename.Substring(startIndex);
            }
            return "";
        }

        public static string ToHtml(string str)
        {
            if ((str != null) && !str.Equals(""))
            {
                str = str.Replace("\r\n", "<br>");
                str = str.Replace("\r", "<br>");
                str = str.Replace(" ", "&nbsp;");
            }
            return str;
        }

        public static string CNProductPath
        {
            get
            {
                if (m_CNProductPath == null)
                {
                    m_CNProductPath = ConfigurationSettings.AppSettings["CNProductPath"];
                    if (m_CNProductPath == null)
                    {
                        m_CNProductPath = "DefCNProductPicPath";
                    }
                }
                return m_CNProductPath;
            }
        }

        public static string ENProductPath
        {
            get
            {
                if (m_ENProductPath == null)
                {
                    m_ENProductPath = ConfigurationSettings.AppSettings["ENProductPath"];
                    if (m_ENProductPath == null)
                    {
                        m_ENProductPath = "DefENProductPicPath";
                    }
                }
                return m_ENProductPath;
            }
        }

        public static string NewsPath
        {
            get
            {
                if (m_NewsPath == null)
                {
                    m_NewsPath = ConfigurationSettings.AppSettings["NewsPath"];
                    if (m_NewsPath == null)
                    {
                        m_NewsPath = "NewsPath";
                    }
                }
                return m_NewsPath;
            }
        }

        public static string VideoFilePath
        {
            get
            {
                if (m_VideoFilePath == null)
                {
                    m_VideoFilePath = ConfigurationSettings.AppSettings["VideoFilePath"];
                    if (m_VideoFilePath == null)
                    {
                        m_VideoFilePath = "VideoFilePath";
                    }
                }
                return m_VideoFilePath;
            }
        }

        public static string WebAppTitle
        {
            get
            {
                if (m_WebAppTitle == null)
                {
                    m_WebAppTitle = ConfigurationSettings.AppSettings["WebAppTitle"];
                    if (m_WebAppTitle == null)
                    {
                        m_WebAppTitle = "YingNetWebAppTitle By Jibf";
                    }
                }
                return m_WebAppTitle;
            }
        }
    }
}

