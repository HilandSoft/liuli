namespace YingNet.WeiXing.WebApp.manage.Long
{
    using System;
    using System.Data;
    using System.Web.UI;
    using System.Web.UI.WebControls;
    using YingNet.Common;

    public class renew : Page
    {
        protected Button Button1;
        protected TextBox TextBox1;

        private void Button1_Click(object sender, EventArgs e)
        {
            string commandText = "";
            commandText = "update LPerson set Status=0 where sid=" + this.TextBox1.Text;
            if (SqlHelper.ExecuteNonQuery(Config.DataSource, CommandType.Text, commandText) > 0)
            {
                base.Response.Write("<script>alert('Success!');window.location='LongList.aspx';</script>");
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

