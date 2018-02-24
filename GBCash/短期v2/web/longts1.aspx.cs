namespace YingNet.WeiXing.WebApp
{
    using System;
    using System.Web.UI;
    using System.Web.UI.HtmlControls;
    using System.Web.UI.WebControls;
    using YingNet.Common.Utils;
    using YingNet.WeiXing.Business;
    using YingNet.WeiXing.DB.Data;

    public class longts1 : Page
    {
        protected HtmlSelect dlexisting;
        protected HtmlSelect dlgender;
        protected HtmlSelect dlmastatus;
        protected HtmlSelect dlrestatus;
        protected HtmlSelect dlterms;
        protected HtmlSelect dltitle;
        protected HtmlInputText mobiletel;
        protected Panel Panel1;
        protected Panel Panel2;
        protected HtmlInputButton Submit1;
        protected HtmlInputButton Submit2;
        protected HtmlInputText Text1;
        protected HtmlInputText Text2;
        protected HtmlInputText Text3;
        protected HtmlInputText txareatel;
        protected HtmlInputText txborrow;
        protected HtmlInputText txDated;
        protected HtmlInputText txDatem;
        protected HtmlInputText txDatey;
        protected HtmlInputText txEmail;
        protected HtmlInputText txfname;
        protected HtmlInputText txhometel;
        protected HtmlInputText txlandlord;
        protected HtmlInputText txlnumber;
        protected HtmlInputText txlstate;
        protected HtmlInputText txmname;
        protected HtmlSelect txMonth;
        protected HtmlInputText txPost;
        protected HtmlTextArea txpurpose;
        protected HtmlInputText txrefnumber;
        protected HtmlInputText txsname;
        protected HtmlInputText txState;
        protected HtmlInputText txStreet;
        protected HtmlInputText txSuburb;
        protected HtmlInputText txunitno;
        protected HtmlInputText txworktel;
        protected HtmlSelect txYear;

        private void InitializeComponent()
        {
            this.Submit1.ServerClick += new EventHandler(this.Submit1_ServerClick);
            this.Submit2.ServerClick += new EventHandler(this.Submit2_ServerClick);
            base.Load += new EventHandler(this.Page_Load);
        }

        protected override void OnInit(EventArgs e)
        {
            this.InitializeComponent();
            base.OnInit(e);
        }

        private void Page_Load(object sender, EventArgs e)
        {
            this.Submit1.Attributes.Add("onclick", "return CheckFeedback();");
            this.Submit2.Attributes.Add("onclick", "return CheckFeedback2();");
        }

        private void Submit1_ServerClick(object sender, EventArgs e)
        {
            this.Panel1.Visible = false;
            this.Panel2.Visible = true;
        }

        private void Submit2_ServerClick(object sender, EventArgs e)
        {
            LongtpBN pbn = new LongtpBN(this.Page);
            LongtpDT dt = new LongtpDT();
            dt.purpose = this.txpurpose.Value;
            dt.borrow = Convert.ToDouble(this.txborrow.Value);
            dt.terms = this.dlterms.Value;
            dt.existing = this.dlexisting.Value;
            dt.refnumber = this.txrefnumber.Value;
            dt.title = this.dltitle.Value;
            dt.fname = this.txfname.Value;
            dt.mname = this.txmname.Value;
            dt.sname = this.txsname.Value;
            dt.gender = this.dlgender.Value;
            dt.birth = this.txDated.Value + "/" + this.txDatem.Value + "/" + this.txDatey.Value;
            dt.hometel = this.txhometel.Value;
            dt.worktel = this.txworktel.Value;
            dt.mobiletel = this.mobiletel.Value;
            dt.email = this.txEmail.Value;
            dt.lnumber = this.txlnumber.Value;
            dt.lstate = this.txlstate.Value;
            dt.mastatus = this.dlmastatus.Value;
            dt.restatus = this.dlrestatus.Value;
            dt.unitno = this.txunitno.Value;
            dt.street = this.txStreet.Value;
            dt.suburb = this.txSuburb.Value;
            dt.state = this.txState.Value;
            dt.postcode = this.txPost.Value;
            dt.timeaddress = this.txYear.Value + "Years  " + this.txMonth.Value + "Months";
            dt.landlord = this.txlandlord.Value;
            dt.areatel = this.txareatel.Value;
            dt.regdate = SafeDateTime.LocalNow;
            int num = pbn.Add2(dt);
            base.Response.Write("<script>alert('Success!');window.location='longts2.aspx?sid=" + num.ToString() + "';</script>");
        }
    }
}

