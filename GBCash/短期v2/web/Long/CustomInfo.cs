namespace YingNet.WeiXing.WebApp.Long
{
    using System;
    using System.Data;
    using System.Web.UI;
    using System.Web.UI.WebControls;
    using YingNet.Common;
    using YingNet.WeiXing.Business;
    using YingNet.WeiXing.STRUCTURE;

    public class CustomInfo : Page
    {
        public string CustomerId = "";
        protected LinkButton LinkButton1;
        public string sbirth = "";
        public string sdlestatus = "";
        public string sdlexisting = "";
        public string sdlgender = "";
        public string sdlmastatus = "";
        public string sdlrestatus = "";
        public string sdlterms = "";
        public string sdltitle = "";
        public string sHousePaymentInfo = string.Empty;
        public string smethods = "";
        public string snpayday = "";
        public string sOtherLenderInfo = string.Empty;
        public string sPer = "";
        public string sselReShip1 = "";
        public string sselReShip2 = "";
        public string sselReShip3 = "";
        public string stimeaddress = "";
        public string stimeemployed = "";
        public string stxAddress = "";
        public string stxAname = "";
        public string stxAnumber = "";
        public string stxareatel = "";
        public string stxBank = "";
        public string stxborrow = "";
        public string stxBranch = "";
        public string stxBsb = "";
        public string stxEmail = "";
        public string stxEmployer = "";
        public string stxfname = "";
        public string stxhometel = "";
        public string stxIncome = "";
        public string stxJob = "";
        public string stxlandlord = "";
        public string stxlnumber = "";
        public string stxlstate = "";
        public string stxmname = "";
        public string stxmobiletel = "";
        public string stxPhone = "";
        public string stxPost = "";
        public string stxpurpose = "";
        public string stxrefnumber = "";
        public string stxReName1 = "";
        public string stxReName2 = "";
        public string stxReName3 = "";
        public string stxReNum1 = "";
        public string stxReNum2 = "";
        public string stxReNum3 = "";
        public string stxsname = "";
        public string stxState = "";
        public string stxStreet = "";
        public string stxSuburb = "";
        public string stxunitno = "";
        public string stxworktel = "";
        protected TextBox txPerSid;

        private void InitializeComponent()
        {
            this.LinkButton1.Click += new EventHandler(this.LinkButton1_Click);
            base.Load += new EventHandler(this.Page_Load);
        }

        private void LinkButton1_Click(object sender, EventArgs e)
        {
            base.Response.Write("<script>window.location='Lagreement.aspx?sid=" + Cipher.DesEncrypt(this.txPerSid.Text, "12345678") + "';</script>");
        }

        protected override void OnInit(EventArgs e)
        {
            this.InitializeComponent();
            base.OnInit(e);
        }

        private void Page_Load(object sender, EventArgs e)
        {
            if (!this.Page.IsPostBack && (base.Request["sid"] != null))
            {
                this.CustomerId = this.txPerSid.Text = Cipher.DesDecrypt(base.Request["sid"].ToString(), "12345678");
                int persid = Convert.ToInt32(this.txPerSid.Text);
                LiniloanBN nbn = new LiniloanBN(this.Page);
                nbn.QueryPersid(persid);
                DataTable list = nbn.GetList();
                if (list.Rows.Count > 0)
                {
                    this.stxpurpose = StringUtils.ToHtml(list.Rows[0]["PrimaryPurpose"].ToString());
                    this.stxborrow = list.Rows[0]["Loan"].ToString();
                    this.sdlterms = list.Rows[0]["Term"].ToString() + " Months";
                }
                LpersonBN nbn2 = new LpersonBN(this.Page);
                nbn2.Querysid(persid);
                DataTable table2 = nbn2.GetList();
                if (table2.Rows.Count > 0)
                {
                    if (table2.Rows[0]["IsExist"].Equals(1))
                    {
                        this.sdlexisting = "True";
                    }
                    else
                    {
                        this.sdlexisting = "False";
                    }
                    this.stxrefnumber = table2.Rows[0]["ReferenceNum"].ToString();
                    this.sdltitle = table2.Rows[0]["Title"].ToString();
                    this.stxfname = table2.Rows[0]["Fname"].ToString();
                    this.stxmname = table2.Rows[0]["Mname"].ToString();
                    this.stxsname = table2.Rows[0]["Sname"].ToString();
                    this.sdlgender = table2.Rows[0]["Gender"].ToString();
                    this.sbirth = table2.Rows[0]["DBirth"].ToString();
                    this.stxhometel = table2.Rows[0]["HTelnum"].ToString();
                    this.stxworktel = table2.Rows[0]["WTelnum"].ToString();
                    this.stxmobiletel = table2.Rows[0]["Mobile"].ToString();
                    this.stxEmail = table2.Rows[0]["Email"].ToString();
                    this.stxlnumber = table2.Rows[0]["LicNum"].ToString();
                    this.stxlstate = table2.Rows[0]["LicState"].ToString();
                    this.sdlmastatus = table2.Rows[0]["MaritalStatus"].ToString();
                    this.stxReName1 = table2.Rows[0]["Rname1"].ToString();
                    this.sselReShip1 = table2.Rows[0]["Rship1"].ToString();
                    this.stxReNum1 = table2.Rows[0]["Rnum1"].ToString();
                    this.stxReName2 = table2.Rows[0]["Rname2"].ToString();
                    this.sselReShip2 = table2.Rows[0]["Rship2"].ToString();
                    this.stxReNum2 = table2.Rows[0]["Rnum2"].ToString();
                    this.stxReName3 = table2.Rows[0]["Rname3"].ToString();
                    this.sselReShip3 = table2.Rows[0]["Rship3"].ToString();
                    this.stxReNum3 = table2.Rows[0]["Rnum3"].ToString();
                }
                LresidentBN tbn = new LresidentBN(this.Page);
                tbn.QueryLoanSid(persid);
                DataTable table3 = tbn.GetList();
                if (table3.Rows.Count > 0)
                {
                    this.sdlrestatus = table3.Rows[0]["Status"].ToString();
                    this.stxunitno = table3.Rows[0]["UnitNo"].ToString();
                    this.stxStreet = table3.Rows[0]["StreetNum"].ToString();
                    this.stxSuburb = table3.Rows[0]["Suburb"].ToString();
                    this.stxState = table3.Rows[0]["State"].ToString();
                    this.stxPost = table3.Rows[0]["Postcode"].ToString();
                    this.stimeaddress = table3.Rows[0]["TimeYears"].ToString() + "Years " + table3.Rows[0]["TimeMonths"].ToString() + "Months";
                    this.stxlandlord = table3.Rows[0]["NameAgent"].ToString();
                    this.stxareatel = table3.Rows[0]["TelArea"].ToString();
                }
                LemploymentBN tbn2 = new LemploymentBN(this.Page);
                tbn2.QueryLoanSid(persid);
                DataTable table4 = tbn2.GetList();
                if (table4.Rows.Count > 0)
                {
                    this.stxEmployer = table4.Rows[0]["EName"].ToString();
                    this.stxAddress = table4.Rows[0]["EAddress"].ToString();
                    this.stxPhone = table4.Rows[0]["ECode"].ToString();
                    this.sdlestatus = table4.Rows[0]["EStatus"].ToString();
                    this.stxJob = table4.Rows[0]["JobTitle"].ToString();
                    this.stimeemployed = table4.Rows[0]["TimeYears"].ToString() + "Years " + table4.Rows[0]["TimeMonths"].ToString() + "Months";
                    this.stxIncome = table4.Rows[0]["TakePay"].ToString();
                    switch (table4.Rows[0]["Per"].ToString())
                    {
                        case "0":
                            this.sPer = "Weekly";
                            break;

                        case "1":
                            this.sPer = "F'nightly";
                            break;

                        case "2":
                            this.sPer = "Bi-Monthly";
                            break;

                        case "3":
                            this.sPer = "Monthly";
                            break;
                    }
                    this.snpayday = table4.Rows[0]["NextDay"].ToString() + "/" + table4.Rows[0]["NextMonth"].ToString() + "/" + table4.Rows[0]["NextYear"].ToString();
                    this.sHousePaymentInfo = string.Format("{0} {1}", table4.Rows[0]["HousePaymentValue"].ToString(), EnumsOP.GetHousePaymentCircleLiteral(table4.Rows[0]["HousePaymentCircle"]));
                    this.sOtherLenderInfo = string.Format("{0} {1}", table4.Rows[0]["OtherLenderValue"].ToString(), EnumsOP.GetOtherLenderCircleLiteral(table4.Rows[0]["OtherLenderCircle"]));
                }
                LbankBN kbn = new LbankBN(this.Page);
                kbn.QueryLoanSid(persid);
                DataTable table5 = kbn.GetList();
                if (table5.Rows.Count > 0)
                {
                    this.stxBank = table5.Rows[0]["BankName"].ToString();
                    this.stxBranch = table5.Rows[0]["Branch"].ToString();
                    this.stxAname = table5.Rows[0]["AccountName"].ToString();
                    this.stxBsb = table5.Rows[0]["Bsb"].ToString();
                    this.stxAnumber = table5.Rows[0]["AccountNum"].ToString();
                    this.smethods = table5.Rows[0]["PContact"].ToString();
                }
            }
        }
    }
}

