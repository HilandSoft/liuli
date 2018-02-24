namespace YingNet.WeiXing.WebApp.Member
{
    using System;
    using System.Web.UI.WebControls;

    public class newloan1 : generagepage
    {
        protected LinkButton LinkButton1;
        protected Panel Panel1;

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
        }
    }
}

