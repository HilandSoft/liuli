namespace YingNet.WeiXing.WebApp
{
    using System;
    using System.Web;
    using System.Web.UI;

    public class sslTest : Page
    {
        private void InitializeComponent()
        {
            base.Load += new EventHandler(this.Page_Load);
        }

        protected override void OnInit(EventArgs e)
        {
            this.InitializeComponent();
            base.OnInit(e);
        }

        private void Page_Load(object sender, EventArgs e)
        {
            string absoluteUri = HttpContext.Current.Request.Url.AbsoluteUri;
        }
    }
}

