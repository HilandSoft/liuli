namespace YingNet.WeiXing.WebApp.Long.Member
{
    using System;
    using System.Data;
    using System.Web.UI.HtmlControls;
    using System.Web.UI.WebControls;
    using YingNet.Common.Utils;
    using YingNet.WeiXing.Business;
    using YingNet.WeiXing.STRUCTURE;

    public class Index : MemberParent
    {
        protected Button bnApption;
        protected HtmlInputButton bnBank;
        protected HtmlInputButton bnEdit2;
        protected HtmlInputButton bnEdit4;
        protected HtmlSelect dlexisting;
        protected HtmlSelect dlgender;
        protected HtmlSelect dlmastatus;
        protected DropDownList dlrestatus;
        protected HtmlSelect dltitle;
        protected HtmlInputText mobiletel;
        protected Panel Panel3;
        protected Panel Panel4;
        protected Panel Panel7;
        protected Panel Panel8;
        protected RadioButtonList RadioButtonList1;
        public string sbirth = "";
        public string sdlestatus = "";
        public string sdlexisting = "";
        public string sdlgender = "";
        public string sdlmastatus = "";
        public string sdlrestatus = "";
        public string sdlterms = "";
        public string sdltitle = "";
        protected HtmlInputText selReShip1;
        protected HtmlInputText selReShip2;
        protected HtmlInputText selReShip3;
        public string smethods = "";
        public string snpayday = "";
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
        protected HtmlInputButton Submit2;
        protected HtmlTable Table1;
        protected HtmlTable Table2;
        protected HtmlInputText txAname;
        protected HtmlInputText txAnumber;
        protected HtmlInputText txareatel;
        protected HtmlInputText txBank;
        protected TextBox txBankSid;
        protected HtmlInputText txBranch;
        protected HtmlInputText txBsb;
        protected HtmlInputText txCAnumber;
        protected HtmlInputText txDated;
        protected HtmlInputText txDatem;
        protected HtmlInputText txDatey;
        protected HtmlInputText txDd2;
        protected HtmlInputText txEmail;
        protected HtmlInputText txfname;
        protected HtmlInputText txhometel;
        protected HtmlInputText txlandlord;
        protected HtmlInputText txlnumber;
        protected TextBox txLoanSid;
        protected HtmlInputText txlstate;
        protected HtmlInputText txMm2;
        protected HtmlInputText txmname;
        protected HtmlSelect txMonth;
        protected HtmlSelect txMonthr;
        protected TextBox txPerSid;
        protected HtmlInputText txPost;
        protected HtmlInputText txrefnumber;
        protected HtmlInputText txReName1;
        protected HtmlInputText txReName2;
        protected HtmlInputText txReName3;
        protected HtmlInputText txReNum1;
        protected HtmlInputText txReNum2;
        protected HtmlInputText txReNum3;
        protected TextBox txReSid;
        protected HtmlInputText txsname;
        protected HtmlInputText txState;
        protected HtmlInputText txStreet;
        protected HtmlInputText txSuburb;
        protected HtmlInputText txunitno;
        protected HtmlInputText txworktel;
        protected HtmlSelect txYear;
        protected HtmlSelect txYearr;
        protected HtmlInputText txYy2;

        private void bnBank_ServerClick(object sender, EventArgs e)
        {
            LbankBN kbn = new LbankBN(this.Page);
            LbankDT detail = kbn.Get(Convert.ToInt32(this.txBankSid.Text));
            detail.BankName = this.txBank.Value;
            detail.Branch = this.txBranch.Value;
            detail.AccountName = this.txAname.Value;
            detail.AccountNum = this.txAnumber.Value;
            detail.Bsb = this.txBsb.Value;
            detail.PContact = this.RadioButtonList1.SelectedValue;
            detail.LoanSid = Convert.ToInt32(this.txPerSid.Text);
            detail.Rname1 = "";
            detail.Rnum1 = "";
            detail.Rship1 = "";
            detail.Rname2 = "";
            detail.Rnum2 = "";
            detail.Rship2 = "";
            detail.Rname3 = "";
            detail.Rnum3 = "";
            detail.Rship3 = "";
            detail.Other1 = "";
            detail.Other2 = "";
            detail.Other3 = "";
            detail.Other4 = 0;
            detail.Other5 = 0;
            detail.Other6 = 0;
            if (kbn.Edit(detail))
            {
                base.Response.Write("<script>window.location='Index.aspx';</script>");
            }
        }

        private void bnEdit2_ServerClick(object sender, EventArgs e)
        {
            this.Panel3.Visible = this.Panel7.Visible = this.Panel8.Visible = false;
            this.Panel4.Visible = true;
        }

        private void bnEdit4_ServerClick(object sender, EventArgs e)
        {
            this.Panel3.Visible = this.Panel4.Visible = this.Panel7.Visible = false;
            this.Panel8.Visible = true;
        }

        public void GetBank(string sid)
        {
            LbankBN kbn = new LbankBN(this.Page);
            kbn.QueryLoanSid(Convert.ToInt32(sid));
            DataTable list = kbn.GetList();
            if (list.Rows.Count > 0)
            {
                this.txBankSid.Text = list.Rows[0]["sid"].ToString();
                this.txBank.Value = list.Rows[0]["BankName"].ToString();
                this.txBranch.Value = list.Rows[0]["Branch"].ToString();
                this.txAname.Value = list.Rows[0]["AccountName"].ToString();
                this.txAnumber.Value = list.Rows[0]["AccountNum"].ToString();
                this.txCAnumber.Value = list.Rows[0]["AccountNum"].ToString();
                this.txBsb.Value = list.Rows[0]["Bsb"].ToString();
                this.RadioButtonList1.SelectedValue = list.Rows[0]["PContact"].ToString();
            }
        }

        public void GetPerson(string sid)
        {
            LpersonBN nbn = new LpersonBN(this.Page);
            nbn.Querysid(Convert.ToInt32(sid));
            DataTable list = nbn.GetList();
            if (list.Rows.Count > 0)
            {
                this.txPerSid.Text = list.Rows[0]["sid"].ToString();
                this.dlexisting.Value = list.Rows[0]["IsExist"].ToString();
                this.txrefnumber.Value = list.Rows[0]["ReferenceNum"].ToString();
                this.dltitle.Value = list.Rows[0]["Title"].ToString();
                this.txfname.Value = list.Rows[0]["Fname"].ToString();
                this.txmname.Value = list.Rows[0]["Mname"].ToString();
                this.txsname.Value = list.Rows[0]["Sname"].ToString();
                this.dlgender.Value = list.Rows[0]["Gender"].ToString();
                string str = list.Rows[0]["DBirth"].ToString();
                int index = str.IndexOf("/");
                this.txDated.Value = str.Substring(0, index);
                str = str.Substring(index + 1);
                int length = str.IndexOf("/");
                this.txDatem.Value = str.Substring(0, length);
                this.txDatey.Value = str.Substring(length + 1);
                this.txhometel.Value = list.Rows[0]["HTelnum"].ToString();
                this.txworktel.Value = list.Rows[0]["WTelnum"].ToString();
                this.mobiletel.Value = list.Rows[0]["Mobile"].ToString();
                this.txEmail.Value = list.Rows[0]["Email"].ToString();
                this.txlnumber.Value = list.Rows[0]["LicNum"].ToString();
                this.txlstate.Value = list.Rows[0]["LicState"].ToString();
                this.dlmastatus.Value = list.Rows[0]["MaritalStatus"].ToString();
                this.txReName1.Value = list.Rows[0]["Rname1"].ToString();
                this.txReNum1.Value = list.Rows[0]["Rnum1"].ToString();
                this.selReShip1.Value = list.Rows[0]["Rship1"].ToString();
                this.txReName2.Value = list.Rows[0]["Rname2"].ToString();
                this.txReNum2.Value = list.Rows[0]["Rnum2"].ToString();
                this.selReShip2.Value = list.Rows[0]["Rship2"].ToString();
                this.txReName3.Value = list.Rows[0]["Rname3"].ToString();
                this.txReNum3.Value = list.Rows[0]["Rnum3"].ToString();
                this.selReShip3.Value = list.Rows[0]["Rship3"].ToString();
            }
        }

        public void GetResident(string sid)
        {
            LresidentBN tbn = new LresidentBN(this.Page);
            tbn.QueryLoanSid(Convert.ToInt32(sid));
            DataTable list = tbn.GetList();
            if (list.Rows.Count > 0)
            {
                this.txReSid.Text = list.Rows[0]["sid"].ToString();
                this.dlrestatus.SelectedValue = list.Rows[0]["Status"].ToString();
                this.txunitno.Value = list.Rows[0]["UnitNo"].ToString();
                this.txStreet.Value = list.Rows[0]["StreetNum"].ToString();
                this.txSuburb.Value = list.Rows[0]["Suburb"].ToString();
                this.txState.Value = list.Rows[0]["State"].ToString();
                this.txPost.Value = list.Rows[0]["Postcode"].ToString();
                this.txMonthr.Value = list.Rows[0]["TimeMonths"].ToString();
                this.txYearr.Value = list.Rows[0]["TimeYears"].ToString();
                this.txlandlord.Value = list.Rows[0]["NameAgent"].ToString();
                this.txareatel.Value = list.Rows[0]["TelArea"].ToString();
            }
        }

        private void InitializeComponent()
        {
            this.bnEdit2.ServerClick += new EventHandler(this.bnEdit2_ServerClick);
            this.Submit2.ServerClick += new EventHandler(this.Submit2_ServerClick);
            this.bnEdit4.ServerClick += new EventHandler(this.bnEdit4_ServerClick);
            this.bnBank.ServerClick += new EventHandler(this.bnBank_ServerClick);
            base.Load += new EventHandler(this.Page_Load);
        }

        protected override void OnInit(EventArgs e)
        {
            this.InitializeComponent();
            base.OnInit(e);
        }

        private void Page_Load(object sender, EventArgs e)
        {
            this.Submit2.Attributes.Add("onclick", "return CheckFeedback2();");
            this.bnBank.Attributes.Add("onclick", "return CheckFeedback4();");
            if (!this.Page.IsPostBack && (this.Session["LongMember"] != null))
            {
                this.txPerSid.Text = this.Session["LongMember"].ToString();
                int sid = Convert.ToInt32(this.txPerSid.Text);
                LpersonBN nbn = new LpersonBN(this.Page);
                nbn.Querysid(sid);
                DataTable list = nbn.GetList();
                if (list.Rows.Count > 0)
                {
                    if (list.Rows[0]["IsExist"].Equals(1))
                    {
                        this.sdlexisting = "True";
                    }
                    else
                    {
                        this.sdlexisting = "False";
                    }
                    this.stxrefnumber = list.Rows[0]["ReferenceNum"].ToString();
                    this.sdltitle = list.Rows[0]["Title"].ToString();
                    this.stxfname = list.Rows[0]["Fname"].ToString();
                    this.stxmname = list.Rows[0]["Mname"].ToString();
                    this.stxsname = list.Rows[0]["Sname"].ToString();
                    this.sdlgender = list.Rows[0]["Gender"].ToString();
                    this.sbirth = list.Rows[0]["DBirth"].ToString();
                    this.stxhometel = list.Rows[0]["HTelnum"].ToString();
                    this.stxworktel = list.Rows[0]["WTelnum"].ToString();
                    this.stxmobiletel = list.Rows[0]["Mobile"].ToString();
                    this.stxEmail = list.Rows[0]["Email"].ToString();
                    this.stxlnumber = list.Rows[0]["LicNum"].ToString();
                    this.stxlstate = list.Rows[0]["LicState"].ToString();
                    this.sdlmastatus = list.Rows[0]["MaritalStatus"].ToString();
                    this.stxReName1 = list.Rows[0]["Rname1"].ToString();
                    this.sselReShip1 = list.Rows[0]["Rship1"].ToString();
                    this.stxReNum1 = list.Rows[0]["Rnum1"].ToString();
                    this.stxReName2 = list.Rows[0]["Rname2"].ToString();
                    this.sselReShip2 = list.Rows[0]["Rship2"].ToString();
                    this.stxReNum2 = list.Rows[0]["Rnum2"].ToString();
                    this.stxReName3 = list.Rows[0]["Rname3"].ToString();
                    this.sselReShip3 = list.Rows[0]["Rship3"].ToString();
                    this.stxReNum3 = list.Rows[0]["Rnum3"].ToString();
                }
                LresidentBN tbn = new LresidentBN(this.Page);
                tbn.QueryLoanSid(sid);
                DataTable table2 = tbn.GetList();
                if (table2.Rows.Count > 0)
                {
                    this.sdlrestatus = table2.Rows[0]["Status"].ToString();
                    this.stxunitno = table2.Rows[0]["UnitNo"].ToString();
                    this.stxStreet = table2.Rows[0]["StreetNum"].ToString();
                    this.stxSuburb = table2.Rows[0]["Suburb"].ToString();
                    this.stxState = table2.Rows[0]["State"].ToString();
                    this.stxPost = table2.Rows[0]["Postcode"].ToString();
                    this.stimeaddress = table2.Rows[0]["TimeYears"].ToString() + "Years " + table2.Rows[0]["TimeMonths"].ToString() + "Months";
                    this.stxlandlord = table2.Rows[0]["NameAgent"].ToString();
                    this.stxareatel = table2.Rows[0]["TelArea"].ToString();
                }
                LbankBN kbn = new LbankBN(this.Page);
                kbn.QueryLoanSid(sid);
                DataTable table3 = kbn.GetList();
                if (table3.Rows.Count > 0)
                {
                    this.stxBank = table3.Rows[0]["BankName"].ToString();
                    this.stxBranch = table3.Rows[0]["Branch"].ToString();
                    this.stxAname = table3.Rows[0]["AccountName"].ToString();
                    this.stxBsb = table3.Rows[0]["Bsb"].ToString();
                    this.stxAnumber = table3.Rows[0]["AccountNum"].ToString();
                    this.smethods = table3.Rows[0]["PContact"].ToString();
                }
                this.GetPerson(this.txPerSid.Text);
                this.GetResident(this.txPerSid.Text);
                this.GetBank(this.txPerSid.Text);
                this.Panel4.Visible = this.Panel8.Visible = false;
            }
        }

        private void Submit2_ServerClick(object sender, EventArgs e)
        {
            LpersonBN nbn = new LpersonBN(this.Page);
            LpersonDT detail = nbn.Get(Convert.ToInt32(this.txPerSid.Text));
            detail.IsExist = Convert.ToInt32(this.dlexisting.Value);
            detail.ReferenceNum = this.txrefnumber.Value;
            detail.Title = this.dltitle.Value;
            detail.Fname = this.txfname.Value;
            detail.Mname = this.txmname.Value;
            detail.Sname = this.txsname.Value;
            detail.Gender = this.dlgender.Value;
            detail.DBirth = this.txDated.Value + "/" + this.txDatem.Value + "/" + this.txDatey.Value;
            detail.HTelnum = this.txhometel.Value;
            detail.WTelnum = this.txworktel.Value;
            detail.HTelcode = "";
            detail.WTelcode = "";
            detail.Mobile = this.mobiletel.Value;
            detail.Email = this.txEmail.Value;
            detail.LicNum = this.txlnumber.Value;
            detail.LicState = this.txlstate.Value;
            detail.MaritalStatus = this.dlmastatus.Value;
            detail.RegTime = SafeDateTime.LocalNow;
            detail.LoanSid = 0;
            detail.Rname1 = this.txReName1.Value;
            detail.Rnum1 = this.txReNum1.Value;
            detail.Rship1 = this.selReShip1.Value;
            detail.Rname2 = this.txReName2.Value;
            detail.Rnum2 = this.txReNum2.Value;
            detail.Rship2 = this.selReShip2.Value;
            detail.Rname3 = this.txReName3.Value;
            detail.Rnum3 = this.txReNum3.Value;
            detail.Rship3 = this.selReShip3.Value;
            detail.Other1 = "";
            detail.Other2 = "";
            detail.Other3 = "";
            detail.Other4 = 0;
            detail.Other5 = 0;
            detail.Other6 = 0;
            detail.Status = 1;
            if (nbn.Edit(detail))
            {
                LresidentBN tbn = new LresidentBN(this.Page);
                LresidentDT tdt = tbn.Get(Convert.ToInt32(this.txReSid.Text));
                tdt.Status = this.dlrestatus.SelectedValue;
                tdt.UnitNo = this.txunitno.Value;
                tdt.StreetNum = this.txStreet.Value;
                tdt.Suburb = this.txSuburb.Value;
                tdt.State = this.txState.Value;
                tdt.Postcode = this.txPost.Value;
                tdt.TimeMonths = this.txMonthr.Value;
                tdt.TimeYears = this.txYearr.Value;
                tdt.NameAgent = this.txlandlord.Value;
                tdt.TelArea = this.txareatel.Value;
                tdt.LoanSid = Convert.ToInt32(this.txPerSid.Text);
                tdt.Other1 = "";
                tdt.Other2 = "";
                tdt.Other3 = "";
                tdt.Other4 = 0;
                tdt.Other5 = 0;
                tdt.Other6 = 0;
                if (tbn.Edit(tdt))
                {
                    base.Response.Write("<script>window.location='Index.aspx';</script>");
                }
            }
        }
    }
}

