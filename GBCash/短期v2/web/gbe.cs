namespace YingNet.WeiXing.WebApp
{
    using System;
    using System.Data;
    using System.Web.UI;
    using System.Web.UI.HtmlControls;
    using System.Web.UI.WebControls;
    using YingNet.WeiXing.Business;
    using YingNet.WeiXing.DB.Data;

    public class gbe : Page
    {
        protected HtmlInputHidden Hidden1;
        protected LinkButton LinkButton1;
        protected LinkButton LinkButton2;
        protected HtmlInputText txAddress;
        protected HtmlInputText txAName;
        protected HtmlInputText txANumber;
        protected HtmlInputText txBank;
        protected HtmlInputText txBranch;
        protected HtmlInputText txBsb;
        protected HtmlInputText txCity;
        protected HtmlInputText txEPhone;
        protected HtmlInputText txFname;
        protected HtmlInputText txHPhone;
        protected HtmlInputText txId;
        protected HtmlInputText txLname;
        protected HtmlInputText txMobile;
        protected HtmlInputText txPostcode;
        protected HtmlInputText txState;

        private void InitializeComponent()
        {
            this.LinkButton2.Click += new EventHandler(this.LinkButton2_Click);
            this.LinkButton1.Click += new EventHandler(this.LinkButton1_Click);
            base.Load += new EventHandler(this.Page_Load);
        }

        private void LinkButton1_Click(object sender, EventArgs e)
        {
            base.Response.Write("<script>window.parent.location.href='newcu5.htm';</script>");
        }

        private void LinkButton2_Click(object sender, EventArgs e)
        {
            this.Session["huiSid"] = this.Hidden1.Value;
            base.Response.Write("<script>window.location='agreement.aspx';</script>");
        }

        protected override void OnInit(EventArgs e)
        {
            this.InitializeComponent();
            base.OnInit(e);
        }

        private void Page_Load(object sender, EventArgs e)
        {
            this.Hidden1.Value = this.Session["huiSid"].ToString();
            HuiyuanDT ndt = new HuiyuanBN(this.Page).Get(Convert.ToInt32(this.Hidden1.Value));
            this.txId.Value = ndt.id.ToString();
            this.txLname.Value = ndt.Lname;
            this.txFname.Value = ndt.Fname;
            this.txAddress.Value = ndt.RAddress + "  " + ndt.SAddress;
            this.txCity.Value = ndt.City;
            this.txState.Value = ndt.State;
            this.txPostcode.Value = ndt.Postcode;
            this.txHPhone.Value = ndt.HTel;
            this.txMobile.Value = ndt.Mobile;
            EmployedBN dbn = new EmployedBN(this.Page);
            dbn.QueryhuiSid(this.Hidden1.Value);
            dbn.QueryParam3("1");
            DataTable list = dbn.GetList();
            if (list.Rows[0]["IsEmployed"].ToString().Equals("1"))
            {
                this.txEPhone.Value = list.Rows[0]["EPhone"].ToString();
            }
            this.txBank.Value = list.Rows[0]["BankName"].ToString();
            this.txBranch.Value = list.Rows[0]["Branch"].ToString();
            this.txBsb.Value = list.Rows[0]["Bsb"].ToString();
            this.txANumber.Value = list.Rows[0]["ANumber"].ToString();
            this.txAName.Value = list.Rows[0]["AName"].ToString();
        }
    }
}

