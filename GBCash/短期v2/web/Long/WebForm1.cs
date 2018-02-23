namespace YingNet.WeiXing.WebApp.Long
{
    using System;
    using System.Web.UI;

    public class WebForm1 : Page
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
            DateTime time = new DateTime(0x7d7, 7, 0x1f);
            DateTime time2 = new DateTime(0x7d7, 8, 15);
            TimeSpan span = (TimeSpan) (time2 - time);
            base.Response.Write(span.Days.ToString());
        }
    }
}

