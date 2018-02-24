namespace YingNet.WeiXing.WebApp.manage
{
    using System;
    using System.Data;
    using System.Web.UI;
    using System.Web.UI.WebControls;
    using YingNet.Common;

    public class ExeSql : Page
    {
        protected Button Button1;
        protected TextBox TextBox1;

        private void Button1_Click(object sender, EventArgs e)
        {
            SqlHelper.ExecuteNonQuery(Config.DataSource, CommandType.Text, this.TextBox1.Text);
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

