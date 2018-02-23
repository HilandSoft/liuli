namespace YingNet.WeiXing.WebApp.manage.Long
{
    using System;
    using System.Data;
    using System.Web.UI;
    using System.Web.UI.WebControls;
    using YingNet.Common;
    using YingNet.Common.Utils;

    public class LoanInfoForPrint : Page
    {
        public string amountOutstanding = string.Empty;
        public DataTable dtPay = new DataTable();
        public string sLoan = "";
        public string sNumber = "";
        public string sRegTime = "";
        public string statementIssuedDate = SafeDateTime.LocalNow.ToString("dd-MM-yyyy");
        protected TextBox txPerSid;
        public string userAddressDetail = string.Empty;
        public string userFullName = string.Empty;

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
                    DataRow row = table.Rows[0];
                    this.sRegTime = Convert.ToDateTime(row["RegTime"]).ToString("dd/MM/yyyy hh:mm:ss");
                    this.userFullName = Convert.ToString(row["Title"]) + " " + Convert.ToString(row["Fname"]) + " " + Convert.ToString(row["Sname"]);
                }
                for (int i = 0; i < this.dtPay.Rows.Count; i++)
                {
                    DateTime localToday = SafeDateTime.LocalToday;
                    try
                    {
                        string[] strArray = Convert.ToString(this.dtPay.Rows[i]["Datedue"]).Split(new char[] { '/', '-' });
                        if (strArray.Length == 3)
                        {
                            localToday = new DateTime(Convert.ToInt32(strArray[2]), Convert.ToInt32(strArray[1]), Convert.ToInt32(strArray[0]));
                        }
                    }
                    catch
                    {
                    }
                    if ((this.dtPay.Rows[i]["Balance"].ToString() != "") && (localToday <= SafeDateTime.LocalNow))
                    {
                        this.amountOutstanding = "$" + Convert.ToDouble(this.dtPay.Rows[i]["Balance"]).ToString("0.00");
                    }
                }
                if (this.amountOutstanding == string.Empty)
                {
                    this.amountOutstanding = "$0";
                }
            }
        }
    }
}

