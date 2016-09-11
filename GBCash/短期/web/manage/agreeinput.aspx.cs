namespace YingNet.WeiXing.WebApp.manage
{
    using System;
    using System.Web.UI.WebControls;
    using YingNet.WeiXing.Business;

    public class agreeinput : ManageBasePage
    {
        protected Button Button1;
        protected TextBox TextBox1;

        private void Button1_Click(object sender, EventArgs e)
        {
            if (this.TextBox1.Text != "")
            {
                this.Session["MANAGE_MEMBERID"] = this.TextBox1.Text;
                base.Response.Write("<script>window.location.href='Agreement.aspx?id=" + this.TextBox1.Text + "';</script>");
            }
        }

        private void InitializeComponent()
        {
            this.Button1.Click += new EventHandler(this.Button1_Click);
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

