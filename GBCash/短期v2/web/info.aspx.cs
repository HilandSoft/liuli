namespace YingNet.WeiXing.WebApp
{
    using System;
    using System.Web.UI;

    public class info : Page
    {
        public string Info = "";

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
            if (base.Request["id"] != "")
            {
                this.Info = base.Request["id"].ToString();
            }
        }
    }
}

