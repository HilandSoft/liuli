namespace YingNet.WeiXing.WebApp.manage.Long
{
    using System;
    using System.Data;
    using System.Web.UI;
    using System.Web.UI.WebControls;
    using YingNet.Common;
    using YingNet.WeiXing.Business;
	using YingNet.WeiXing.STRUCTURE;

    public class LongDetail : Page
    {
        public string birth = "";
        public string dlestatus = "";
        public string dlexisting = "";
        public string dlgender = "";
        public string dlmastatus = "";
        public string dlrestatus = "";
        public string dlterms = "";
        public string dltitle = "";
        public string methods = "";
        public string npayday = "";
        public string Per = "";
        public string selReShip1 = "";
        public string selReShip2 = "";
        public string selReShip3 = "";
        public string stimeaddress1 = "";
        public string stxPost1 = "";
        public string stxState1 = "";
        public string stxStreet1 = "";
        public string stxSuburb1 = "";
        public string stxunitno1 = "";
        protected TextBox TextBox1;
        public string timeaddress = "";
        public string timeemployed = "";
        public string txAddress = "";
        public string txAname = "";
        public string txAnumber = "";
        public string txareatel = "";
        public string txBank = "";
        public string txborrow = "";
        public string txBranch = "";
        public string txBsb = "";
        public string txEmail = "";
        public string txEmployer = "";
        public string txfname = "";
        public string txhometel = "";
        public string txIncome = "";
        public string txJob = "";
        public string txlandlord = "";
        public string txlnumber = "";
        public string txlstate = "";
        public string txmname = "";
        public string txmobiletel = "";
        public string txPhone = "";
        public string txPost = "";
        public string txpurpose = "";
        public string txrefnumber = "";
        public string txReName1 = "";
        public string txReName2 = "";
        public string txReName3 = "";
        public string txReNum1 = "";
        public string txReNum2 = "";
        public string txReNum3 = "";
        public string txsname = "";
        public string txState = "";
        public string txStreet = "";
        public string txSuburb = "";
        public string txunitno = "";
		protected System.Web.UI.HtmlControls.HtmlTable tbUnit;
        public string txworktel = "";
		protected System.Web.UI.WebControls.HyperLink hpEdit;
		public string sHousePaymentInfo= string.Empty;
		public string sOtherLenderInfo= string.Empty;

        private void InitializeComponent()
        {
			this.Load += new System.EventHandler(this.Page_Load);

		}

        protected override void OnInit(EventArgs e)
        {
            this.InitializeComponent();
            base.OnInit(e);
        }

        private void Page_Load(object sender, EventArgs e)
        {
            LbankBN kbn;
            if (base.Request["sid"] == null)
            {
                return;
            }
            this.TextBox1.Text = base.Request["sid"].ToString();
            int persid = Convert.ToInt32(this.TextBox1.Text);
            
			this.hpEdit.NavigateUrl= "LongDetailEdit.aspx?sid="+ persid;
			LiniloanBN nbn = new LiniloanBN(this.Page);
            nbn.QueryPersid(persid);
            DataTable list = nbn.GetList();
            if (list.Rows.Count > 0)
            {
                this.txpurpose = StringUtils.ToHtml(list.Rows[0]["PrimaryPurpose"].ToString());
                this.txborrow = list.Rows[0]["Loan"].ToString();
                this.dlterms = list.Rows[0]["Term"].ToString() + " Months";
            }
            LpersonBN nbn2 = new LpersonBN(this.Page);
            nbn2.Querysid(persid);
            DataTable table2 = nbn2.GetList();
            if (table2.Rows.Count > 0)
            {
                if (table2.Rows[0]["IsExist"].Equals(1))
                {
                    this.dlexisting = "True";
                }
                else
                {
                    this.dlexisting = "False";
                }
                this.txrefnumber = table2.Rows[0]["ReferenceNum"].ToString();
                this.dltitle = table2.Rows[0]["Title"].ToString();
                this.txfname = table2.Rows[0]["Fname"].ToString();
                this.txmname = table2.Rows[0]["Mname"].ToString();
                this.txsname = table2.Rows[0]["Sname"].ToString();
                this.dlgender = table2.Rows[0]["Gender"].ToString();
                this.birth = table2.Rows[0]["DBirth"].ToString();
                this.txhometel = table2.Rows[0]["HTelnum"].ToString();
                this.txworktel = table2.Rows[0]["WTelnum"].ToString();
                this.txmobiletel = table2.Rows[0]["Mobile"].ToString();
                this.txEmail = table2.Rows[0]["Email"].ToString();
                this.txlnumber = table2.Rows[0]["LicNum"].ToString();
                this.txlstate = table2.Rows[0]["LicState"].ToString();
                this.dlmastatus = table2.Rows[0]["MaritalStatus"].ToString();
                this.txReName1 = table2.Rows[0]["Rname1"].ToString();
                this.selReShip1 = table2.Rows[0]["Rship1"].ToString();
                this.txReNum1 = table2.Rows[0]["Rnum1"].ToString();
                this.txReName2 = table2.Rows[0]["Rname2"].ToString();
                this.selReShip2 = table2.Rows[0]["Rship2"].ToString();
                this.txReNum2 = table2.Rows[0]["Rnum2"].ToString();
                this.txReName3 = table2.Rows[0]["Rname3"].ToString();
                this.selReShip3 = table2.Rows[0]["Rship3"].ToString();
                this.txReNum3 = table2.Rows[0]["Rnum3"].ToString();
            }
            LresidentBN tbn = new LresidentBN(this.Page);
            tbn.QueryLoanSid(persid);
            DataTable table3 = tbn.GetList();
            if (table3.Rows.Count > 0)
            {
                this.dlrestatus = table3.Rows[0]["Status"].ToString();
                this.txunitno = table3.Rows[0]["UnitNo"].ToString();
                this.txStreet = table3.Rows[0]["StreetNum"].ToString();
                this.txSuburb = table3.Rows[0]["Suburb"].ToString();
                this.txState = table3.Rows[0]["State"].ToString();
                this.txPost = table3.Rows[0]["Postcode"].ToString();
                this.timeaddress = table3.Rows[0]["TimeYears"].ToString() + "Years " + table3.Rows[0]["TimeMonths"].ToString() + "Months";
                this.txlandlord = table3.Rows[0]["NameAgent"].ToString();
                this.txareatel = table3.Rows[0]["TelArea"].ToString();
                this.stxunitno1 = table3.Rows[0]["UnitNo1"].ToString();
                this.stxStreet1 = table3.Rows[0]["StreetNum1"].ToString();
                this.stxSuburb1 = table3.Rows[0]["Suburb1"].ToString();
                this.stxState1 = table3.Rows[0]["State1"].ToString();
                this.stxPost1 = table3.Rows[0]["Postcode1"].ToString();
                this.stimeaddress1 = table3.Rows[0]["TimeYears1"].ToString() + "Years " + table3.Rows[0]["TimeMonths1"].ToString() + "Months";
            }
            LemploymentBN tbn2 = new LemploymentBN(this.Page);
            tbn2.QueryLoanSid(persid);
            DataTable table4 = tbn2.GetList();
            if (table4.Rows.Count <= 0)
            {
                goto Label_0949;
            }
            this.txEmployer = table4.Rows[0]["EName"].ToString();
            this.txAddress = table4.Rows[0]["EAddress"].ToString();
            this.txPhone = table4.Rows[0]["ECode"].ToString();
            this.dlestatus = table4.Rows[0]["EStatus"].ToString();
            this.txJob = table4.Rows[0]["JobTitle"].ToString();
            this.timeemployed = table4.Rows[0]["TimeYears"].ToString() + "Years " + table4.Rows[0]["TimeMonths"].ToString() + "Months";
            this.txIncome = table4.Rows[0]["TakePay"].ToString();
            switch (table4.Rows[0]["Per"].ToString())
            {
                case "0":
                    this.Per = "Weekly";
                    goto Label_08C2;

                case "1":
                    this.Per = "F'nightly";
                    goto Label_08C2;

                case "2":
                    this.Per = "Bi-Monthly";
                    break;

                case "3":
                    this.Per = "Monthly";
                    break;
            }
        Label_08C2:;
            this.npayday = table4.Rows[0]["NextDay"].ToString() + "/" + table4.Rows[0]["NextMonth"].ToString() + "/" + table4.Rows[0]["NextYear"].ToString();
			this.sHousePaymentInfo= string.Format("{0} {1}", table4.Rows[0]["HousePaymentValue"].ToString(),EnumsOP.GetHousePaymentCircleLiteral(table4.Rows[0]["HousePaymentCircle"]));
			this.sOtherLenderInfo= string.Format("{0} {1}", table4.Rows[0]["OtherLenderValue"].ToString(),EnumsOP.GetOtherLenderCircleLiteral(table4.Rows[0]["OtherLenderCircle"]));
        Label_0949:
            kbn = new LbankBN(this.Page);
            kbn.QueryLoanSid(persid);
            DataTable table5 = kbn.GetList();
            if (table5.Rows.Count > 0)
            {
                this.txBank = table5.Rows[0]["BankName"].ToString();
                this.txBranch = table5.Rows[0]["Branch"].ToString();
                this.txAname = table5.Rows[0]["AccountName"].ToString();
                this.txBsb = table5.Rows[0]["Bsb"].ToString();
                this.txAnumber = table5.Rows[0]["AccountNum"].ToString();
                this.methods = table5.Rows[0]["PContact"].ToString();
            }

			
        }
    }
}

