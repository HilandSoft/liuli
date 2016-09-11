namespace YingNet.WeiXing.WebApp.Long
{
    using System;
    using System.Data;
    using System.Web.UI;
    using System.Web.UI.HtmlControls;
    using System.Web.UI.WebControls;
    using YingNet.Common;
    using YingNet.WeiXing.Business;
    using YingNet.WeiXing.STRUCTURE;
	using YingNet.Common.Utils;

    public class Lagreement : Page
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
        public string FCost = "";
		public string FFee= "";
        public string fDay = "";
        public string fMonth = "";
        public string fYear = "";
        protected HtmlInputText HomeAddress1;
        protected HtmlInputText HomeAddress2;
        public string Installments = "";
        public string Interest = "";
        protected LinkButton LinkButton1;
        protected LinkButton LinkButton2;
        public string LoanAccount = "";
        public string OtherCharges = "";
        public string Per = "";
        public string Period = "";
        public string rCount = "";
        public string reEnd = "";
        public string Regtime = "";
        public string Repaydue1 = "";
        public string Repaydue2 = "";
        public string Repaydue3 = "";
        public string reStart = "";
        public string sRepaydue = "";
        protected HtmlInputText Text1;
        protected HtmlInputText Text2;
        protected HtmlInputText Text3;
        public string TotalRepayable = "";
        protected HtmlInputText txId;
        protected TextBox txPerSid;
        public string Wpaid = "";

        private void InitializeComponent()
        {
            this.LinkButton2.Click += new EventHandler(this.LinkButton2_Click);
            this.LinkButton1.Click += new EventHandler(this.LinkButton1_Click);
            base.Load += new EventHandler(this.Page_Load);
        }

        private void LinkButton1_Click(object sender, EventArgs e)
        {
            base.Response.Redirect("DirectDebit.aspx?Sid=" + Cipher.DesEncrypt(this.txPerSid.Text, "12345678"));
        }

        private void LinkButton2_Click(object sender, EventArgs e)
        {
            base.Response.Redirect("CustomInfo.aspx?Sid=" + Cipher.DesEncrypt(this.txPerSid.Text, "12345678"));
        }

        protected override void OnInit(EventArgs e)
        {
            this.InitializeComponent();
            base.OnInit(e);
        }

        private void Page_Load(object sender, EventArgs e)
        {
			PaidPeriodTypes paidPeriodType=	PaidPeriodTypes.Weekly;
            string str2;
            if (base.Request["sid"] == null)
            {
                return;
            }
            this.CustomerId = this.txPerSid.Text = Cipher.DesDecrypt(base.Request["sid"].ToString(), "12345678");
            DataTable list = new DataTable();
            this.fDay = SafeDateTime.LocalNow.Day.ToString();
            this.fMonth = SafeDateTime.LocalNow.Month.ToString();
            this.fYear = SafeDateTime.LocalNow.Year.ToString();
            LiniloanBN nbn = new LiniloanBN(this.Page);
            nbn.QueryPersid(Convert.ToInt32(this.txPerSid.Text));
            list = nbn.GetList();
            if (list.Rows.Count > 0)
            {
                this.LoanAccount = list.Rows[0]["Loan"].ToString();
            }
            LpersonDT ndt = new LpersonBN(this.Page).Get(Convert.ToInt32(this.txPerSid.Text));
            this.BorrowerName.Value = ndt.Fname + " " + ndt.Mname + " " + ndt.Sname;
            this.DriverLicense.Value = ndt.LicNum;
            this.ContactW.Value = ndt.WTelnum;
            this.ContactH.Value = ndt.HTelnum;
            this.ContactC.Value = ndt.Mobile;
            LresidentBN tbn = new LresidentBN(this.Page);
            tbn.QueryLoanSid(Convert.ToInt32(this.txPerSid.Text));
            list = tbn.GetList();
            if (list.Rows.Count > 0)
            {
                this.HomeAddress1.Value = list.Rows[0]["UnitNo"].ToString() + " " + list.Rows[0]["StreetNum"].ToString();
                this.HomeAddress2.Value = list.Rows[0]["Suburb"].ToString() + " " + list.Rows[0]["State"].ToString() + " " + list.Rows[0]["Postcode"].ToString();
            }
            LemploymentBN tbn2 = new LemploymentBN(this.Page);
            tbn2.QueryLoanSid(Convert.ToInt32(this.txPerSid.Text));
            list = tbn2.GetList();
            string per = "";
            if (list.Rows.Count > 0)
            {
                this.Per = list.Rows[0]["Per"].ToString();
                per = this.Per;
                switch (this.Per)
                {
					case "0":
						this.Per = "Weekly";
						paidPeriodType= PaidPeriodTypes.Weekly;
						goto Label_03B2;

					case "1":
						this.Per = "F'nightly";
						paidPeriodType= PaidPeriodTypes.Fnightly;
						goto Label_03B2;

					case "2":
						this.Per = "Bi-Monthly";
						paidPeriodType= PaidPeriodTypes.BiMonthly;
						break;

					case "3":
						this.Per = "Monthly";
						paidPeriodType= PaidPeriodTypes.Monthly;
						break;
                }
            }
        Label_03B2:
            str2 = "";
            str2 = "select * from Lpay where PerSid=" + this.txPerSid.Text;
            list = SqlHelper.ExecuteDataset(Config.DataSource, CommandType.Text, str2).Tables[0];
            if (list.Rows.Count <= 0)
            {
                goto Label_058E;
            }
            int count = list.Rows.Count;
            this.sRepaydue = list.Rows[0]["Repaydue"].ToString();
            this.TotalRepayable = (Convert.ToDouble(list.Rows[0]["Repaydue"]) * count).ToString("0.00");
            this.rCount = count.ToString();
            this.reStart = list.Rows[0]["Datedue"].ToString();
            this.reEnd = list.Rows[count - 1]["Datedue"].ToString();
            double num3 = Convert.ToDouble(list.Rows[0]["Interest"]);
            switch (per)
            {
                case "0":
                    num3 *= 52.18;
                    goto Label_0556;

                case "1":
                    num3 *= 26.09;
                    goto Label_0556;

                case "2":
                    num3 *= 24.0;
                    break;

                case "3":
                    num3 *= 12.0;
                    break;
            }
        Label_0556:
			//Interest的计算采用新查表模式20101102
			this.Interest = LMisc.GetAnnualRatePercent(paidPeriodType,count);//num3.ToString("0.00");
            double FCostDouble= Convert.ToDouble(this.TotalRepayable) - Convert.ToDouble(this.LoanAccount);
			this.FCost = FCostDouble.ToString();
			this.FFee= (FCostDouble / Convert.ToDouble(this.LoanAccount) / Convert.ToInt32(rCount) * 100).ToString("0.00");
        Label_058E:
            this.OtherCharges = "0";
        }
    }
}

