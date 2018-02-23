namespace YingNet.WeiXing.WebApp.Member
{
    using System;
    using System.Web.UI.HtmlControls;

    public class index : generagepage
    {
        protected HtmlGenericControl right;

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

