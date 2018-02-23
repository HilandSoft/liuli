namespace YingNet.WeiXing.WebApp
{
    using System;
    using System.Web.UI;
    using System.Web.UI.WebControls;

    public class step4 : Page
    {
        protected LinkButton LinkButton1;

        private void InitializeComponent()
        {
            this.LinkButton1.Click += new EventHandler(this.LinkButton1_Click);
            base.Load += new EventHandler(this.Page_Load);
        }

        private void LinkButton1_Click(object sender, EventArgs e)
        {
            base.Response.Write("<script>window.parent.location.href='agreement.aspx'</script>");
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

