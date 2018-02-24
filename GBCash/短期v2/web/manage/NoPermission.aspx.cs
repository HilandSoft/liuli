namespace YingNet.WeiXing.WebApp.manage
{
    using System;
    using System.Web.UI;
    using System.Web.UI.WebControls;

    public class NoPermission : Page
    {
        protected TextBox TextBox1;
        protected TextBox txtParamstr;

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

