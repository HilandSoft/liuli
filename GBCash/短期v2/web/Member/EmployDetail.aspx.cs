namespace YingNet.WeiXing.WebApp.Member
{
    using System;
    using System.Data;
    using System.Web.UI.HtmlControls;
    using YingNet.WeiXing.Business;
    using YingNet.WeiXing.STRUCTURE;

    public class EmployDetail : generagepage
    {
        public string EmploymentInfo = "";
        protected HtmlInputHidden Hidden3;
        public string houseInfo = string.Empty;
        public string IsEmployed = "";
        public string loanPurpose = string.Empty;
        public string otherLenderInfo = string.Empty;
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
        public string txMonth = "";
        public string txPhone = "";
        public string txYear = "";
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
            EmployedBN dbn = new EmployedBN(this.Page);
            this.Hidden3.Value = base.HuiSid;
            DataTable list = dbn.GetList();
            dbn.QueryhuiSid(this.Hidden3.Value);
            list = dbn.GetList();
            this.txEmployer = list.Rows[0]["Employer"].ToString();
            this.txAddress = list.Rows[0]["EAddress"].ToString();
            this.txPhone = list.Rows[0]["EPhone"].ToString();
            this.txYear = list.Rows[0]["TYears"].ToString();
            this.txMonth = list.Rows[0]["TMonths"].ToString();
            this.txIncome = Convert.ToSingle(list.Rows[0]["MIncome"]).ToString("0.00");
            this.IsEmployed = list.Rows[0]["IsEmployed"].ToString();
            this.txJob = list.Rows[0]["Param5"].ToString();
            int num = list.Rows.Count - 1;
            DataRow row = list.Rows[num];
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

