namespace YingNet.WeiXing.WebApp
{
    using System;
    using System.Web.UI;
    using System.Web.UI.HtmlControls;
    using System.Web.UI.WebControls;
    using YingNet.WeiXing.Business;
    using YingNet.WeiXing.DB.Data;

    public class longts2 : Page
    {
        protected HtmlSelect dlestatus;
        protected RadioButtonList RadioButtonList1;
        protected RadioButtonList RadioButtonList2;
        protected HtmlInputText selReShip1;
        protected HtmlInputText selReShip2;
        protected HtmlInputText selReShip3;
        protected HtmlInputButton Submit1;
        protected TextBox TextBox1;
        protected HtmlInputText txAddress;
        protected HtmlInputText txAname;
        protected HtmlInputText txAnumber;
        protected HtmlInputText txBank;
        protected HtmlInputText txBranch;
        protected HtmlInputText txBsb;
        protected HtmlInputText txCAnumber;
        protected HtmlInputText txDd1;
        protected HtmlInputText txEmployer;
        protected HtmlInputText txIncome;
        protected HtmlInputText txJob;
        protected HtmlInputText txMm1;
        protected HtmlSelect txMonth;
        protected HtmlInputText txPhone;
        protected HtmlInputText txReName1;
        protected HtmlInputText txReName2;
        protected HtmlInputText txReName3;
        protected HtmlInputText txReNum1;
        protected HtmlInputText txReNum2;
        protected HtmlInputText txReNum3;
        protected HtmlSelect txYear;
        protected HtmlInputText txYy1;

        private void InitializeComponent()
        {
            this.Submit1.ServerClick += new EventHandler(this.Submit1_ServerClick);
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
            if (base.Request["sid"] != null)
            {
                this.TextBox1.Text = base.Request["sid"].ToString();
            }
        }

        private void Submit1_ServerClick(object sender, EventArgs e)
        {
            LongteBN ebn = new LongteBN(this.Page);
            LongteDT dt = new LongteDT();
            dt.ename = this.txEmployer.Value;
            dt.eaddress = this.txAddress.Value;
            dt.etel = this.txPhone.Value;
            dt.estatus = this.dlestatus.Value;
            dt.jobtitle = this.txJob.Value;
            dt.timeemployed = this.txYear.Value + "Years  " + this.txMonth.Value + "Months";
            dt.thome = Convert.ToSingle(this.txIncome.Value);
            dt.tper = this.RadioButtonList2.SelectedValue;
            dt.npayday = this.txDd1.Value + "/" + this.txMm1.Value + "/" + this.txYy1.Value;
            dt.bankname = this.txBank.Value;
            dt.branch = this.txBranch.Value;
            dt.acname = this.txAname.Value;
            dt.bsb = this.txBsb.Value;
            dt.acnumber = this.txAnumber.Value;
            dt.premethods = this.RadioButtonList1.SelectedValue;
            dt.Rname1 = this.txReName1.Value;
            dt.Rship1 = this.selReShip1.Value;
            dt.Rnum1 = this.txReNum1.Value;
            dt.Rname2 = this.txReName2.Value;
            dt.Rship2 = this.selReShip2.Value;
            dt.Rnum2 = this.txReNum2.Value;
            dt.Rname3 = this.txReName3.Value;
            dt.Rship3 = this.selReShip3.Value;
            dt.Rnum3 = this.txReNum3.Value;
            dt.personsid = Convert.ToInt32(this.TextBox1.Text);
            ebn.Add(dt);
            base.Response.Write("<script>alert('Success!');</script>");
        }
    }
}

