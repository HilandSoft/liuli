namespace YingNet.WeiXing.WebApp.Long
{
    using System;
    using System.Web.UI;
    using System.Web.UI.HtmlControls;
    using System.Web.UI.WebControls;
    using YingNet.Common;
    using YingNet.WeiXing.Business;
    using YingNet.WeiXing.STRUCTURE;
    using YingNet.WeiXing.WebApp.UserControls;

    public class Step2r : Page
    {
        protected YingNet.WeiXing.WebApp.UserControls.AustralianStateDropDownList AustralianStateDropDownList;
        protected YingNet.WeiXing.WebApp.UserControls.AustralianStateDropDownList AustralianStateDropDownList1;
        protected DropDownList dlrestatus;
        protected DropDownList DropDownList1;
        protected Panel Panel1;
        protected HtmlInputButton Submit2;
        protected HtmlTable Table1;
        protected HtmlInputText txareatel;
        protected HtmlInputText txlandlord;
        protected TextBox txLoanSid;
        protected HtmlSelect txMonth;
        protected HtmlSelect txMonth1;
        protected HtmlInputText txPost;
        protected HtmlInputText txPost1;
        protected HtmlInputText txStreet;
        protected HtmlInputText txStreet1;
        protected HtmlInputText txSuburb;
        protected HtmlInputText txSuburb1;
        protected HtmlInputText txunitno;
        protected HtmlInputText txUnitNo1;
        protected HtmlSelect txYear1;

        private void dlrestatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.dlrestatus.SelectedValue.Equals("Renting"))
            {
                this.Table1.Visible = true;
            }
            else
            {
                this.Table1.Visible = false;
            }
        }

        private void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Convert.ToInt32(this.DropDownList1.SelectedValue) < 5)
            {
                this.Panel1.Visible = true;
            }
            else
            {
                this.Panel1.Visible = false;
            }
        }

        private void InitializeComponent()
        {
            this.Submit2.ServerClick += new EventHandler(this.Submit2_ServerClick);
            base.Load += new EventHandler(this.Page_Load);
            this.dlrestatus.SelectedIndexChanged += new EventHandler(this.dlrestatus_SelectedIndexChanged);
            this.DropDownList1.SelectedIndexChanged += new EventHandler(this.DropDownList1_SelectedIndexChanged);
        }

        protected override void OnInit(EventArgs e)
        {
            this.InitializeComponent();
            base.OnInit(e);
        }

        private void Page_Load(object sender, EventArgs e)
        {
            this.Submit2.Attributes.Add("onclick", "return CheckFeedback2();");
            if (base.Request["sid"] != null)
            {
                this.txLoanSid.Text = Cipher.DesDecrypt(base.Request["sid"].ToString(), "12345678");
            }
        }

        private void Submit2_ServerClick(object sender, EventArgs e)
        {
            LresidentBN tbn = new LresidentBN(this.Page);
            LresidentDT detail = new LresidentDT();
            detail.Status = this.dlrestatus.SelectedValue;
            detail.UnitNo = this.txunitno.Value;
            detail.StreetNum = this.txStreet.Value;
            detail.Suburb = this.txSuburb.Value;
            detail.State = this.AustralianStateDropDownList.SelectedValue;
            detail.Postcode = this.txPost.Value;
            detail.TimeMonths = this.txMonth.Value;
            detail.TimeYears = this.DropDownList1.SelectedValue;
            detail.NameAgent = this.txlandlord.Value;
            detail.TelArea = this.txareatel.Value;
            detail.LoanSid = Convert.ToInt32(this.txLoanSid.Text);
            detail.Other1 = "";
            detail.Other2 = "";
            detail.Other3 = "";
            detail.Other4 = 0;
            detail.Other5 = 0;
            detail.Other6 = 0;
            if (Convert.ToInt32(this.DropDownList1.SelectedValue) < 5)
            {
                detail.UnitNo1 = this.txUnitNo1.Value;
                detail.StreetNum1 = this.txStreet1.Value;
                detail.Suburb1 = this.txSuburb1.Value;
                detail.State1 = this.AustralianStateDropDownList1.SelectedValue;
                detail.Postcode1 = this.txPost1.Value;
                detail.TimeMonths1 = this.txMonth1.Value;
                detail.TimeYears1 = this.txYear1.Value;
            }
            else
            {
                detail.UnitNo1 = detail.StreetNum1 = detail.Suburb1 = detail.State1 = detail.Postcode1 = detail.TimeYears1 = detail.TimeMonths1 = "";
            }
            if (tbn.Add(detail))
            {
                tbn.Close();
                tbn.Dispose();
                base.Response.Write("<script>window.location='Step3.aspx?sid=" + Cipher.DesEncrypt(this.txLoanSid.Text, "12345678") + "';</script>");
            }
        }
    }
}

