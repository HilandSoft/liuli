namespace YingNet.WeiXing.WebApp.manage.Long
{
    using System;
    using System.Data;
    using System.Web.UI;
    using YingNet.Common;

    public class LongApprove : Page
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
            if (base.Request["sid"] != null)
            {
                string commandText = "";
                commandText = "update LPerson set Status=1 where sid=" + base.Request["sid"].ToString();
                if (SqlHelper.ExecuteNonQuery(Config.DataSource, CommandType.Text, commandText) > 0)
                {
                    base.Response.Write("<script>alert('Success!');window.location='LongList.aspx';</script>");
                }
            }
        }
    }
}

