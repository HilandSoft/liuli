namespace YingNet.WeiXing.Business.CommonLogic
{
    using System;
    using System.Configuration;

    public class CommonInformation
    {
        public static int CurrentVersion
        {
            get
            {
                int num = 2;
                try
                {
                    if ((ConfigurationSettings.AppSettings["CurrentVersion"] != null) && (ConfigurationSettings.AppSettings["CurrentVersion"] != string.Empty))
                    {
                        num = Convert.ToInt32(ConfigurationSettings.AppSettings["CurrentVersion"]);
                    }
                }
                catch
                {
                }
                return num;
            }
        }
    }
}

