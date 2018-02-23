namespace YingNet.WeiXing.Business
{
    using System;
    using YingNet.Common;

    public class BasePage : CommonBasePage
    {
        public string WebAppTitle
        {
            get
            {
                return WebAppConfig.WebAppTitle;
            }
        }
    }
}

