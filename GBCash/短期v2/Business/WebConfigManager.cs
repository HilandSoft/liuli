namespace YingNet.WeiXing.Business
{
    using System;
    using System.Configuration;

    public class WebConfigManager
    {
        public string GetValue(string strKeyName)
        {
            return ConfigurationSettings.AppSettings[strKeyName];
        }

        public void SetValue(string strKeyName, string strValue)
        {
        }
    }
}

