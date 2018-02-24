namespace YingNet.WeiXing.WebApp.Long
{
    using System;
    using System.Web.UI.HtmlControls;
    using System.Web.UI.WebControls;
    using YingNet.Common;
    using YingNet.WeiXing.Business;
    using YingNet.WeiXing.STRUCTURE;

    public class Step4 : LongParent
    {
        protected HtmlSelect dlestatus;
        protected RadioButtonList RadioButtonList1;
        protected RadioButtonList RadioButtonList2;
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
        protected TextBox txLoanSid;
        protected HtmlInputText txMm1;
        protected HtmlSelect txMonth;
        protected HtmlInputText txPhone;
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
                this.txLoanSid.Text = Cipher.DesDecrypt(base.Request["sid"].ToString(), "12345678");
            }
        }

        private void Submit1_ServerClick(object sender, EventArgs e)
        {
            if (base.CheckPay(this.txLoanSid.Text))
            {
                base.Response.Write("<script>alert('信息已经保存,不能再修改!');window.location='Step.aspx';</script>");
            }
            else
            {
                LbankBN kbn = new LbankBN(this.Page);
                LbankDT detail = new LbankDT();
                detail.BankName = this.txBank.Value;
                detail.Branch = this.txBranch.Value;
                detail.AccountName = this.txAname.Value;
                detail.AccountNum = this.txAnumber.Value;
                detail.Bsb = this.txBsb.Value;
                detail.PContact = this.RadioButtonList1.SelectedValue;
                detail.LoanSid = Convert.ToInt32(this.txLoanSid.Text);
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
                if (kbn.Add(detail))
                {
                    kbn.Close();
                    kbn.Dispose();
                    base.Response.Write("<script>window.location='Step5.aspx?sid=" + Cipher.DesEncrypt(this.txLoanSid.Text, "12345678") + "';</script>");
                }
            }
        }
    }
}

