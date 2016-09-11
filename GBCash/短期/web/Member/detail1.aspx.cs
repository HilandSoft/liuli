namespace YingNet.WeiXing.WebApp.Member
{
    using System;
    using System.Data;
    using System.Web.UI.HtmlControls;
    using YingNet.WeiXing.Business;
	using YingNet.WeiXing.STRUCTURE;

    public class detail1 : generagepage
    {
        public string customno = "";
        public string dlTitle = "";
        protected HtmlGenericControl left;
        public string selState = "";
        public string txCity = "";
        public string txDate = "";
        public string txDriver = "";
        public string txEmail = "";
        public string txFax = "";
        public string txFname = "";
        public string txIssue = "";
        public string txLname = "";
        public string txMname = "";
        public string txMobile = "";
        public string txMonth = "";
        public string txPost = "";
        public string txResident = "";
        public string txStreet = "";
        public string txTel = "";
        public string txYear = "";

		public string EmploymentInfo = "";
		public string IsEmployed = "";
		public string paid = "";
		public string tip1 = "";
		public string tip2 = "";
		public string tip3 = "";
		public string tip4 = "";
		public string tip5 = "";
		public string tip6 = "";
		public string tip7 = "";
		public string txAddress = "";
		public string txDd1 = "";
		public string txEmployer = "";
		public string txIncome = "";
		public string txJob = "";
		public string txMm1 = "";
		public string txMonth2 = "";
		public string txPhone = "";
		public string txYear2 = "";
		public string txYy1 = "";
		public string loanPurpose= string.Empty;
		public string houseInfo= string.Empty;
		public string otherLenderInfo= string.Empty;

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
            if (!this.Page.IsPostBack)
            {
                HuiyuanBN nbn = new HuiyuanBN(this.Page);
                nbn.QuerySid(this.HuiSid);
                DataTable list = nbn.GetList();
                this.dlTitle = list.Rows[0]["Param2"].ToString();
                this.txFname = list.Rows[0]["Fname"].ToString();
                this.txLname = list.Rows[0]["Lname"].ToString();
                this.txMname = list.Rows[0]["Mname"].ToString();
                this.txDate = Convert.ToDateTime(list.Rows[0]["DBirth"]).Day.ToString() + "/" + Convert.ToDateTime(list.Rows[0]["DBirth"]).Month.ToString() + "/" + Convert.ToDateTime(list.Rows[0]["DBirth"]).Year.ToString();
                this.txEmail = list.Rows[0]["Email"].ToString();
                this.txIssue = list.Rows[0]["Issued"].ToString();
                this.txDriver = list.Rows[0]["DNumber"].ToString();
                this.txResident = list.Rows[0]["RAddress"].ToString();
                this.txStreet = list.Rows[0]["SAddress"].ToString();
                this.txCity = list.Rows[0]["City"].ToString();
                this.selState = list.Rows[0]["State"].ToString();
                this.txPost = list.Rows[0]["Postcode"].ToString();
                this.txYear = list.Rows[0]["TYears"].ToString();
                this.txMonth = list.Rows[0]["TMonths"].ToString();
                this.txTel = list.Rows[0]["HTel"].ToString();
                this.txMobile = list.Rows[0]["Mobile"].ToString();
                this.txFax = list.Rows[0]["Param1"].ToString();
                this.customno = list.Rows[0]["id"].ToString();


				EmployedBN dbn = new EmployedBN(this.Page);
				DataTable list2 = dbn.GetList();
				//dbn.QueryParam3("1");
				dbn.QueryhuiSid(this.HuiSid);
				list2 = dbn.GetList();
				this.txEmployer = list2.Rows[0]["Employer"].ToString();
				this.txAddress = list2.Rows[0]["EAddress"].ToString();
				this.txPhone = list2.Rows[0]["EPhone"].ToString();
				this.txYear2 = list2.Rows[0]["TYears"].ToString();
				this.txMonth2 = list2.Rows[0]["TMonths"].ToString();
				this.txIncome = Convert.ToSingle(list2.Rows[0]["MIncome"]).ToString("0.00");
				this.IsEmployed = list2.Rows[0]["IsEmployed"].ToString();
				this.txJob = list2.Rows[0]["Param5"].ToString();
            
				//----------------------------------------------------------------------
				/*//以下信息取最后一次贷款的数据
				this.paid = list.Rows[0]["Wpaid"].ToString();
				this.txMm1 = list.Rows[0]["NDayMM"].ToString();
				this.txDd1 = list.Rows[0]["NDayDD"].ToString();
				this.txYy1 = list.Rows[0]["NDayYY"].ToString();
				*/

				int lastRowIndex= list2.Rows.Count-1;
				DataRow lastRow= list2.Rows[lastRowIndex];
				this.paid = lastRow["Wpaid"].ToString();
				this.txMm1 = lastRow["NDayMM"].ToString();
				this.txDd1 = lastRow["NDayDD"].ToString();
				this.txYy1 = lastRow["NDayYY"].ToString();
					
				this.loanPurpose= lastRow["LoanPurpose"].ToString();
				this.houseInfo= string.Format("{0} {1}",lastRow["HousePaymentValue"].ToString(),EnumsOP.GetHousePaymentCircleLiteral( lastRow["HousePaymentCircle"]));
				this.otherLenderInfo= string.Format("{0} {1}",lastRow["OtherLenderValue"].ToString(),EnumsOP.GetOtherLenderCircleLiteral( lastRow["OtherLenderCircle"]));
				//----------------------------------------------------------------------
			
				if (this.IsEmployed.Equals("1"))
				{
					this.tip1 = "Your Occupation:";
					this.tip2 = "Employer:";
					this.tip3 = "Employer’s Address:";
					this.tip4 = "Employer Phone:";
					this.tip5 = "Time Employed: ";
					this.tip6 = "Take home pay after taxes: ";
					this.tip7 = "<tr><td>JobTitle: </td><td colSpan='3'>" + this.txJob + "</td></tr>";
				}
				else
				{
					this.tip1 = "";
					this.tip2 = "Type of benefit:";
					this.tip3 = "Centreline Office:";
					this.tip4 = "Contact Name:";
					this.tip5 = "How long on this benefit: ";
					this.tip6 = "Take Home Benefit:";
				}
            }
        }
    }
}

