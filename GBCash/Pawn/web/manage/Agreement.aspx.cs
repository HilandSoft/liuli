namespace YingNet.WeiXing.WebApp.manage
{
    using System;
    using System.Data;
    using System.Web.UI.HtmlControls;
    using System.Web.UI.WebControls;
    using YingNet.WeiXing.Business;
	using YingNet.WeiXing.Business.CommonLogic;
	using YingNet.WeiXing.STRUCTURE;
	using YingNet.Common.Utils;

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
        public string Tcoc1 = "";
        public string Tcoc2 = "";
        public string TotalRepayable = "";
        public string Wpaid = "";
		protected Literal ItemDescription;
		protected Literal pawnTicketNumber;
		protected Literal photoNo;

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
                //this.DriverLicense.Value = list.Rows[0]["DNumber"].ToString();
                
				this.ItemDescription.Text= list.Rows[0]["ItemDescription"].ToString();
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
				this.photoNo.Text=table2.Rows[0]["ItemPhotoNumber"].ToString();;
				this.pawnTicketNumber.Text=  table2.Rows[0]["id"].ToString();
				

                string str = table2.Rows[0]["id"].ToString();
                ScheduleBN ebn = new ScheduleBN(this.Page);
                ebn.QueryParam1(str);
                ebn.QueryNotValid("3");
                DataTable table3 = ebn.GetList();
                TimeSpan span = new TimeSpan(0x3e8L);
                int paidCount= table3.Rows.Count;
				switch (paidCount)
                {
                    case 1:
                        this.Datedue1 = Convert.ToDateTime(table3.Rows[0]["Datedue"]).Day.ToString() + "/" + Convert.ToDateTime(table3.Rows[0]["Datedue"]).Month.ToString() + "/" + Convert.ToDateTime(table3.Rows[0]["Datedue"]).Year.ToString();
                        this.Repaydue1 = Convert.ToSingle(table3.Rows[0]["Repaydue"]).ToString("0.00");
                        span = (TimeSpan) (Convert.ToDateTime(table3.Rows[0]["Datedue"]) - Convert.ToDateTime(this.Regtime));
                        break;

                    case 2:
                        this.Datedue1 = Convert.ToDateTime(table3.Rows[0]["Datedue"]).Day.ToString() + "/" + Convert.ToDateTime(table3.Rows[0]["Datedue"]).Month.ToString() + "/" + Convert.ToDateTime(table3.Rows[0]["Datedue"]).Year.ToString();
                        this.Repaydue1 = Convert.ToSingle(table3.Rows[0]["Repaydue"]).ToString("0.00");
                        this.Datedue2 = Convert.ToDateTime(table3.Rows[1]["Datedue"]).Day.ToString() + "/" + Convert.ToDateTime(table3.Rows[1]["Datedue"]).Month.ToString() + "/" + Convert.ToDateTime(table3.Rows[1]["Datedue"]).Year.ToString();
                        this.Repaydue2 = Convert.ToSingle(table3.Rows[1]["Repaydue"]).ToString("0.00");
                        span = (TimeSpan) (Convert.ToDateTime(table3.Rows[1]["Datedue"]) - Convert.ToDateTime(this.Regtime));
                        break;

                    case 3:
                        this.Datedue1 = Convert.ToDateTime(table3.Rows[0]["Datedue"]).Day.ToString() + "/" + Convert.ToDateTime(table3.Rows[0]["Datedue"]).Month.ToString() + "/" + Convert.ToDateTime(table3.Rows[0]["Datedue"]).Year.ToString();
                        this.Repaydue1 = Convert.ToSingle(table3.Rows[0]["Repaydue"]).ToString("0.00");
                        this.Datedue2 = Convert.ToDateTime(table3.Rows[1]["Datedue"]).Day.ToString() + "/" + Convert.ToDateTime(table3.Rows[1]["Datedue"]).Month.ToString() + "/" + Convert.ToDateTime(table3.Rows[1]["Datedue"]).Year.ToString();
                        this.Repaydue2 = Convert.ToSingle(table3.Rows[1]["Repaydue"]).ToString("0.00");
                        this.Datedue3 = Convert.ToDateTime(table3.Rows[2]["Datedue"]).Day.ToString() + "/" + Convert.ToDateTime(table3.Rows[2]["Datedue"]).Month.ToString() + "/" + Convert.ToDateTime(table3.Rows[2]["Datedue"]).Year.ToString();
                        this.Repaydue3 = Convert.ToSingle(table3.Rows[2]["Repaydue"]).ToString("0.00");
                        span = (TimeSpan) (Convert.ToDateTime(table3.Rows[2]["Datedue"]) - Convert.ToDateTime(this.Regtime));
                        break;
                }
                this.Period = (span.Days + 1).ToString();
                float num = 0f;
                DataTable table4 = new SystemInfoBN(this.Page).GetList();
                if (table4.Rows.Count > 0)
                {
                    num = Convert.ToSingle(table4.Rows[0]["interest"]);
                }
                
				//利率计算暂时采用固定值进行
				//this.Tcoc1 = (((365.26 * num) * 100.0)).ToString("0.00") + "%";
				PaidPeriodTypes paidPeriodType= PaidPeriodTypes.Weekly;
				switch(this.Wpaid.Trim().ToLower())
				{
					case "weekly":
						paidPeriodType= PaidPeriodTypes.Weekly;
						break;
					case "f'nightly":
						paidPeriodType= PaidPeriodTypes.Fnightly;
						break;
					case "monthly":
						paidPeriodType= PaidPeriodTypes.Monthly;
						break;
					default:
						paidPeriodType= PaidPeriodTypes.Other;
						break;
				}
				string interrestDisplay= string.Empty;
				interrestDisplay= AnnualPercentageRate.GetAnnualPercentageRatePercent(paidPeriodType,paidCount);

				this.Tcoc1= interrestDisplay;
                this.Tcoc2 = (Convert.ToSingle(this.TotalRepayable) - Convert.ToSingle(this.LoanAccount)).ToString("0.00");
                this.AnnualRate = "";
            }
        }
    }
}

