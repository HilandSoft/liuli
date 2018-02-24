namespace YingNet.WeiXing.WebApp.Long
{
    using System;
    using System.Data;
    using System.Web.UI;
    using YingNet.Common;

    public class LongParent : Page
    {
        public bool CheckPay(string PerSid)
        {
            string commandText = "";
            commandText = "select * from LPay where PerSid=" + PerSid;
            DataTable table = SqlHelper.ExecuteDataset(Config.DataSource, CommandType.Text, commandText).Tables[0];
            return (table.Rows.Count > 0);
        }

        public bool CheckPay2(string LoanSid)
        {
            string commandText = "";
            commandText = "select * from LPay where PerSid=(select PerSid from LIniLoan where Sid=" + LoanSid + ")";
            DataTable table = SqlHelper.ExecuteDataset(Config.DataSource, CommandType.Text, commandText).Tables[0];
            return (table.Rows.Count > 0);
        }

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

