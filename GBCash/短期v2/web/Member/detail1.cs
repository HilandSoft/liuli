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
        public string EmploymentInfo = "";
        public string houseInfo = string.Empty;
        public string IsEmployed = "";
        protected HtmlGenericControl left;
        public string loanPurpose = string.Empty;
        public string otherLenderInfo = string.Empty;
        public string paid = "";
        public string selState = "";
        public string tip1 = "";
        public string tip2 = "";
        public string tip3 = "";
        public string tip4 = "";
        public string tip5 = "";
        public string tip6 = "";
        public string tip7 = "";
        public string txAddress = "";
        public string txCity = "";
        public string txDate = "";
        public string txDd1 = "";
        public string txDriver = "";
        public string txEmail = "";
        public string txEmployer = "";
        public string txFax = "";
        public string txFname = "";
        public string txIncome = "";
        public string txIssue = "";
        public string txJob = "";
        public string txLname = "";
        public string txMm1 = "";
        public string txMname = "";
        public string txMobile = "";
        public string txMonth = "";
        public string txMonth2 = "";
        public string txPhone = "";
        public string txPost = "";
        public string txResident = "";
        public string txStreet = "";
        public string txTel = "";
        public string txYear = "";
        public string txYear2 = "";
        public string txYy1 = "";

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
                nbn.QuerySid(base.HuiSid);
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
                DataTable table2 = dbn.GetList();
                dbn.QueryhuiSid(base.HuiSid);
                table2 = dbn.GetList();
                this.txEmployer = table2.Rows[0]["Employer"].ToString();
                this.txAddress = table2.Rows[0]["EAddress"].ToString();
                this.txPhone = table2.Rows[0]["EPhone"].ToString();
                this.txYear2 = table2.Rows[0]["TYears"].ToString();
                this.txMonth2 = table2.Rows[0]["TMonths"].ToString();
                this.txIncome = Convert.ToSingle(table2.Rows[0]["MIncome"]).ToString("0.00");
                this.IsEmployed = table2.Rows[0]["IsEmployed"].ToString();
                this.txJob = table2.Rows[0]["Param5"].ToString();
                int num = table2.Rows.Count - 1;
                DataRow row = table2.Rows[num];
                this.paid = row["Wpaid"].ToString();
                this.txMm1 = row["NDayMM"].ToString();
                this.txDd1 = row["NDayDD"].ToString();
                this.txYy1 = row["NDayYY"].ToString();
                this.loanPurpose = row["LoanPurpose"].ToString();
                this.houseInfo = string.Format("{0} {1}", row["HousePaymentValue"].ToString(), EnumsOP.GetHousePaymentCircleLiteral(row["HousePaymentCircle"]));
                this.otherLenderInfo = string.Format("{0} {1}", row["OtherLenderValue"].ToString(), EnumsOP.GetOtherLenderCircleLiteral(row["OtherLenderCircle"]));
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

