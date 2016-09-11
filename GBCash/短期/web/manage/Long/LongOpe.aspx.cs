namespace YingNet.WeiXing.WebApp.manage.Long
{
    using System;
    using System.Data;
    using System.Web.UI;
    using YingNet.Common;

    public class LongOpe : Page
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
            string str = base.Request["ope"].ToString();
            string str2 = base.Request["Sid"].ToString();
            string commandText = "";
            commandText = "update Lperson set Status=" + str + " where sid=" + str2;
            if (SqlHelper.ExecuteNonQuery(Config.DataSource, CommandType.Text, commandText) > 0)
            {
                base.Response.Write("<script>alert('Success!');window.location='LongList.aspx';</script>");
            }
        }
    }
}

