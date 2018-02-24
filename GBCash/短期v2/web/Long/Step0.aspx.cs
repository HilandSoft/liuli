namespace YingNet.WeiXing.WebApp.Long
{
    using System;
    using System.Web.UI;
    using System.Web.UI.HtmlControls;

    public class Step0 : Page
    {
        protected HtmlInputButton Submit1;

        private void InitializeComponent()
        {
            this.Submit1.ServerClick += new EventHandler(this.Submit1_ServerClick);
            base.Load += new EventHandler(this.Page_Load);
        }

        protected override void OnInit(EventArgs e)
        {
            this.InitializeComponent();
            base.OnInit(e);
        }

        private void Page_Load(object sender, EventArgs e)
        {
        }

        private void Submit1_ServerClick(object sender, EventArgs e)
        {
            base.Response.Write("<script>window.location='Step1.aspx';</script>");
        }
    }
}

