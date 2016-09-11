namespace YingNet.WeiXing.WebApp.manage.Long
{
    using System;
    using System.Data;
    using System.Web.UI;
    using YingNet.Common;

    public class openoperate : Page
    {
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
            string commandText = "";
            commandText = "update LPerson set Other4=1 where sid=" + base.Request["Sid"].ToString();
            if (SqlHelper.ExecuteNonQuery(Config.DataSource, CommandType.Text, commandText) > 0)
            {
                base.Response.Write("<script>window.location='openwindow.aspx';</script>");
            }
        }
    }
}

