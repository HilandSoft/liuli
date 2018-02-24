namespace YingNet.WeiXing.WebApp.Long
{
    using System;
    using System.Data;
    using System.Web.UI;
    using System.Web.UI.WebControls;
    using YingNet.Common;
    using YingNet.WeiXing.Business;

    public class DirectDebit : Page
    {
        public string CustomerId = "";
        protected LinkButton LinkButton1;
        protected LinkButton LinkButton2;
        protected LinkButton Linkbutton3;
        public string stxAname = "";
        public string stxAnumber = "";
        public string stxBank = "";
        public string stxBranch = "";
        public string stxBsb = "";
        public string stxEmail = "";
        public string stxfname = "";
        public string stxmobiletel = "";
        public string stxsname = "";
        protected TextBox txPerSid;

        private void InitializeComponent()
        {
            this.LinkButton1.Click += new EventHandler(this.LinkButton1_Click);
            this.Linkbutton3.Click += new EventHandler(this.Linkbutton3_Click);
            this.LinkButton2.Click += new EventHandler(this.LinkButton2_Click);
            base.Load += new EventHandler(this.Page_Load);
        }

        private void LinkButton1_Click(object sender, EventArgs e)
        {
            base.Response.Write("<script>window.location='DirectDebit2.aspx?sid=" + Cipher.DesEncrypt(this.txPerSid.Text, "12345678") + "';</script>");
        }

        private void LinkButton2_Click(object sender, EventArgs e)
        {
            base.Response.Write("<script>window.location='PrivState.aspx?sid=" + Cipher.DesEncrypt(this.txPerSid.Text, "12345678") + "';</script>");
        }

        private void Linkbutton3_Click(object sender, EventArgs e)
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
                int sid = Convert.ToInt32(this.CustomerId);
                LpersonBN nbn = new LpersonBN(this.Page);
                nbn.Querysid(sid);
                DataTable list = nbn.GetList();
                if (list.Rows.Count > 0)
                {
                    this.stxfname = list.Rows[0]["Fname"].ToString();
                    this.stxsname = list.Rows[0]["Sname"].ToString();
                    this.stxmobiletel = list.Rows[0]["Mobile"].ToString();
                    this.stxEmail = list.Rows[0]["Email"].ToString();
                }
                LbankBN kbn = new LbankBN(this.Page);
                kbn.QueryLoanSid(sid);
                DataTable table2 = kbn.GetList();
                if (table2.Rows.Count > 0)
                {
                    this.stxBank = table2.Rows[0]["BankName"].ToString();
                    this.stxBranch = table2.Rows[0]["Branch"].ToString();
                    this.stxAname = table2.Rows[0]["AccountName"].ToString();
                    this.stxBsb = table2.Rows[0]["Bsb"].ToString();
                    this.stxAnumber = table2.Rows[0]["AccountNum"].ToString();
                }
            }
        }
    }
}

