namespace YingNet.WeiXing.WebApp.Long
{
    using System;
    using System.Web.UI;

    public class uLeft : UserControl
    {
        public string Sid = "0";

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
            if (base.Request["Sid"] != null)
            {
                this.Sid = base.Request["Sid"].ToString();
            }
        }
    }
}

