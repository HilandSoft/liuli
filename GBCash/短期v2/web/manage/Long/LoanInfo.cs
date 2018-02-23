namespace YingNet.WeiXing.WebApp.manage.Long
{
    using System;
    using System.Data;
    using System.Web.UI;
    using System.Web.UI.WebControls;
    using YingNet.Common;

    public class LoanInfo : Page
    {
        public DataTable dtPay = new DataTable();
        public string sLoan = "";
        public string sNumber = "";
        public string sRegTime = "";
        protected TextBox txPerSid;

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
                this.txPerSid.Text = base.Request["sid"].ToString();
                this.sNumber = base.Request["sid"].ToString();
                string commandText = "";
                commandText = "select * from LPay where PerSid=" + this.txPerSid.Text;
                this.dtPay = SqlHelper.ExecuteDataset(Config.DataSource, 1, commandText).Tables[0];
                commandText = "select Loan from LIniLoan where PerSid=" + this.sNumber;
                DataTable table = SqlHelper.ExecuteDataset(Config.DataSource, 1, commandText).Tables[0];
                if (table.Rows.Count > 0)
                {
                    this.sLoan = table.Rows[0]["Loan"].ToString();
                }
                commandText = "select * from LPerson where Sid=" + this.sNumber;
                table = SqlHelper.ExecuteDataset(Config.DataSource, 1, commandText).Tables[0];
                if (table.Rows.Count > 0)
                {
                    this.sRegTime = Convert.ToDateTime(table.Rows[0]["RegTime"]).ToString("dd/MM/yyyy hh:mm:ss");
                }
            }
        }
    }
}

