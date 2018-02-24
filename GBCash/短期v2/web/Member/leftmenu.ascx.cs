namespace YingNet.WeiXing.WebApp.Member
{
    using Microsoft.Web.UI.WebControls;
    using System;
    using System.Web.UI;

    public class leftmenu : UserControl
    {
        protected TreeView TreeView1;

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

