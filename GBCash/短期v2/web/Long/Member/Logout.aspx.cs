namespace YingNet.WeiXing.WebApp.Long.Member
{
    using System;
    using System.Web.UI;

    public class Logout : Page
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
            this.Session["LongMember"] = null;
            base.Response.Write("<script>window.location='../Login.aspx';</script>");
        }
    }
}

