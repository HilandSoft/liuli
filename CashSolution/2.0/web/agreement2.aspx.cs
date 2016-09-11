namespace YingNet.WeiXing.WebApp
{
    using System;
    using System.Data;
    using System.Web.UI;
    using YingNet.WeiXing.Business;

    public class agreement2 : Page
    {
        public string AnnualRate = "";
        public string BorrowerName = "";
        public string ContactC = "";
        public string ContactH = "";
        public string ContactW = "";
        public string CustomerId = "";
        public string Datedue1 = "";
        public string Datedue2 = "";
        public string Datedue3 = "";
        public string DriverLicense = "";
        public string HomeAddress1 = "";
        public string HomeAddress2 = "";
        public string Installments = "";
        public string LoanAccount = "";
        public string OtherCharges = "";
        public string Period = "";
        public string Regtime = "";
        public string Repaydue1 = "";
        public string Repaydue2 = "";
        public string Repaydue3 = "";
        public string Tcoc1 = "";
        public string Tcoc2 = "";
        public string TotalRepayable = "";
        public string Wpaid = "";

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
            this.Session["huiSid"] = 0x2ef8;
            this.CustomerId = this.Session["huiSid"].ToString();
            HuiyuanBN nbn = new HuiyuanBN(this.Page);
            nbn.QuerySid(this.Session["huiSid"].ToString());
            DataTable list = nbn.GetList();
            EmployedBN dbn = new EmployedBN(this.Page);
            dbn.QueryhuiSid(this.Session["huiSid"].ToString());
            DataTable table2 = dbn.GetList();
            this.BorrowerName = list.Rows[0]["Fname"].ToString() + " " + list.Rows[0]["Mname"].ToString() + " " + list.Rows[0]["Lname"].ToString();
            this.DriverLicense = list.Rows[0]["DNumber"].ToString();
            this.HomeAddress1 = list.Rows[0]["SAddress"].ToString();
            this.HomeAddress2 = list.Rows[0]["City"].ToString() + " " + list.Rows[0]["State"].ToString() + " " + list.Rows[0]["Postcode"].ToString();
            this.ContactH = list.Rows[0]["HTel"].ToString();
            this.ContactC = list.Rows[0]["Mobile"].ToString();
            this.ContactW = table2.Rows[0]["EPhone"].ToString();
            this.LoanAccount = Convert.ToSingle(table2.Rows[0]["Loan"]).ToString("0.00");
            this.OtherCharges = table2.Rows[0]["Param2"].ToString();
            this.Installments = table2.Rows[0]["NInstallment"].ToString();
            this.TotalRepayable = Convert.ToSingle(table2.Rows[0]["Param1"]).ToString("0.00");
            this.Wpaid = table2.Rows[0]["Wpaid"].ToString();
            this.Regtime = table2.Rows[0]["RTime"].ToString();
            ScheduleBN ebn = new ScheduleBN(this.Page);
            ebn.QueryhuiSid(this.Session["huiSid"].ToString());
            DataTable table3 = ebn.GetList();
            TimeSpan span = new TimeSpan(0x3e8L);
            switch (table3.Rows.Count)
            {
                case 1:
                    this.Datedue1 = Convert.ToDateTime(table3.Rows[0]["Datedue"]).ToShortDateString();
                    this.Repaydue1 = Convert.ToSingle(table3.Rows[0]["Repaydue"]).ToString("0.00");
                    span = (TimeSpan) (Convert.ToDateTime(this.Datedue1) - Convert.ToDateTime(this.Regtime));
                    break;

                case 2:
                    this.Datedue1 = Convert.ToDateTime(table3.Rows[0]["Datedue"]).ToShortDateString();
                    this.Repaydue1 = Convert.ToSingle(table3.Rows[0]["Repaydue"]).ToString("0.00");
                    this.Datedue2 = Convert.ToDateTime(table3.Rows[1]["Datedue"]).ToShortDateString();
                    this.Repaydue2 = Convert.ToSingle(table3.Rows[1]["Repaydue"]).ToString("0.00");
                    span = (TimeSpan) (Convert.ToDateTime(this.Datedue2) - Convert.ToDateTime(this.Regtime));
                    break;

                case 3:
                    this.Datedue1 = Convert.ToDateTime(table3.Rows[0]["Datedue"]).ToShortDateString();
                    this.Repaydue1 = Convert.ToSingle(table3.Rows[0]["Repaydue"]).ToString("0.00");
                    this.Datedue2 = Convert.ToDateTime(table3.Rows[1]["Datedue"]).ToShortDateString();
                    this.Repaydue2 = Convert.ToSingle(table3.Rows[1]["Repaydue"]).ToString("0.00");
                    this.Datedue3 = Convert.ToDateTime(table3.Rows[2]["Datedue"]).ToShortDateString();
                    this.Repaydue3 = Convert.ToSingle(table3.Rows[2]["Repaydue"]).ToString("0.00");
                    span = (TimeSpan) (Convert.ToDateTime(this.Datedue3) - Convert.ToDateTime(this.Regtime));
                    break;
            }
            this.Period = (span.Days + 1).ToString();
            float num = 0f;
            DataTable table4 = new SystemInfoBN(this.Page).GetList();
            if (table4.Rows.Count > 0)
            {
                num = Convert.ToSingle(table4.Rows[0]["interest"]);
            }
            this.Tcoc1 = (((365.26 * num) * 100.0)).ToString("0.00") + "%";
            this.Tcoc2 = (Convert.ToSingle(this.TotalRepayable) - Convert.ToSingle(this.LoanAccount)).ToString("0.00");
            this.AnnualRate = "";
        }
    }
}

