namespace YingNet.WeiXing.WebApp.manage
{
    using System;
    using System.Data;
    using System.Web.UI.HtmlControls;
    using System.Web.UI.WebControls;
    using YingNet.Common.Utils;
    using YingNet.WeiXing.Business;
    using YingNet.WeiXing.STRUCTURE;

    public class Agreement : ManageBasePage
    {
        public string AnnualRate = "";
        protected HtmlInputText BorrowerName;
        protected HtmlInputText ContactC;
        protected HtmlInputText ContactH;
        protected HtmlInputText ContactW;
        public string CustomerId = "";
        public string Datedue1 = "";
        public string Datedue2 = "";
        public string Datedue3 = "";
        protected HtmlInputText DriverLicense;
        public string fDay = "";
        public string fMonth = "";
        public string fYear = "";
        protected HtmlInputHidden Hidden1;
        protected HtmlInputText HomeAddress1;
        protected HtmlInputText HomeAddress2;
        public string Installments = "";
        protected LinkButton LinkButton1;
        public string LoanAccount = "";
        public string OtherCharges = "";
        public string Period = "";
        public string Regtime = "";
        public string Repaydue1 = "";
        public string Repaydue2 = "";
        public string Repaydue3 = "";
        protected string ScheduleData = "";
        public string Tcoc1 = "";
        public string Tcoc2 = "";
        public string TotalRepayable = "";
        public string Wpaid = "";

        private void InitializeComponent()
        {
            this.LinkButton1.Click += new EventHandler(this.LinkButton1_Click);
            base.Load += new EventHandler(this.Page_Load);
        }

        private void LinkButton1_Click(object sender, EventArgs e)
        {
            this.Session["MANAGE_MEMBERID"] = this.Hidden1.Value;
            base.Response.Write("<script>window.location.href='gbe.aspx';</script>");
        }

        protected override void OnInit(EventArgs e)
        {
            this.InitializeComponent();
            base.OnInit(e);
        }

        private void Page_Load(object sender, EventArgs e)
        {
            if (this.Session["MANAGE_MEMBERID"] != null)
            {
                this.Hidden1.Value = this.Session["MANAGE_MEMBERID"].ToString();
            }
            else
            {
                this.Hidden1.Value = base.Request["id"].ToString();
            }
            this.fDay = SafeDateTime.LocalNow.Day.ToString();
            this.fMonth = SafeDateTime.LocalNow.Month.ToString();
            this.fYear = SafeDateTime.LocalNow.Year.ToString();
            this.CustomerId = this.Hidden1.Value;
            HuiyuanBN nbn = new HuiyuanBN(this.Page);
            nbn.QuerySid(this.Hidden1.Value);
            DataTable list = nbn.GetList();
            EmployedBN dbn = new EmployedBN(this.Page);
            dbn.QueryhuiSid(this.Hidden1.Value);
            DataTable table2 = dbn.GetList();
            if (list.Rows.Count > 0)
            {
                this.BorrowerName.Value = list.Rows[0]["Fname"].ToString() + " " + list.Rows[0]["Mname"].ToString() + " " + list.Rows[0]["Lname"].ToString();
                this.DriverLicense.Value = list.Rows[0]["DNumber"].ToString();
                this.HomeAddress1.Value = list.Rows[0]["RAddress"].ToString() + "  " + list.Rows[0]["SAddress"].ToString();
                this.HomeAddress2.Value = list.Rows[0]["City"].ToString() + " " + list.Rows[0]["State"].ToString() + " " + list.Rows[0]["Postcode"].ToString();
                this.ContactH.Value = list.Rows[0]["HTel"].ToString();
                this.ContactC.Value = list.Rows[0]["Mobile"].ToString();
                this.ContactW.Value = table2.Rows[0]["EPhone"].ToString();
                this.LoanAccount = Convert.ToSingle(table2.Rows[0]["Loan"]).ToString("0.00");
                this.OtherCharges = table2.Rows[0]["Param2"].ToString();
                this.Installments = table2.Rows[0]["NInstallment"].ToString();
                this.TotalRepayable = Convert.ToSingle(table2.Rows[0]["Param1"]).ToString("0.00");
                this.Wpaid = table2.Rows[0]["Wpaid"].ToString();
                this.Regtime = table2.Rows[0]["RTime"].ToString();
                string str = table2.Rows[0]["id"].ToString();
                ScheduleBN ebn = new ScheduleBN(this.Page);
                ebn.QueryParam1(str);
                ebn.QueryNotValid("3");
                DataTable table3 = ebn.GetList();
                TimeSpan span = new TimeSpan(0x3e8L);
                DateTime time = new DateTime(0x7d0, 1, 1);
                for (int i = 0; i < table3.Rows.Count; i++)
                {
                    time = Convert.ToDateTime(table3.Rows[i]["Datedue"]);
                    int num2 = i + 1;
                    object scheduleData = this.ScheduleData;
                    this.ScheduleData = string.Concat(new object[] { scheduleData, "Installment ", num2, "&nbsp;", Convert.ToDateTime(table3.Rows[i]["Datedue"]).ToString("dd/MM/yyyy"), "&nbsp;&nbsp;$", Convert.ToSingle(table3.Rows[0]["Repaydue"]).ToString("0.00"), "<br/>" });
                }
                span = (TimeSpan) (time - Convert.ToDateTime(this.Regtime));
                this.Period = (span.Days + 1).ToString();
                float num3 = 0f;
                DataTable table4 = new SystemInfoBN(this.Page).GetList();
                if (table4.Rows.Count > 0)
                {
                    num3 = Convert.ToSingle(table4.Rows[0]["interest"]);
                }
                PaidPeriodTypes weekly = PaidPeriodTypes.Weekly;
                switch (this.Wpaid.Trim().ToLower())
                {
                    case "weekly":
                        weekly = PaidPeriodTypes.Weekly;
                        break;

                    case "f'nightly":
                        weekly = PaidPeriodTypes.Fnightly;
                        break;

                    case "monthly":
                        weekly = PaidPeriodTypes.Monthly;
                        break;

                    default:
                        weekly = PaidPeriodTypes.Other;
                        break;
                }
                string str2 = string.Empty;
                str2 = (((28M / Convert.ToInt32(this.Period)) * 365M)).ToString("#0.00") + "%";
                this.Tcoc1 = str2;
                this.Tcoc2 = (Convert.ToSingle(this.TotalRepayable) - Convert.ToSingle(this.LoanAccount)).ToString("0.00");
                this.AnnualRate = "";
            }
        }
    }
}

