namespace YingNet.WeiXing.WebApp.Long
{
    using System;
    using System.Web.UI;
    using System.Web.UI.HtmlControls;

    public class Finish : Page
    {
        protected HtmlInputButton Submit1;

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

