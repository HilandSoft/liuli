namespace YingNet.WeiXing.WebApp.manage
{
    using System;
    using System.Data;
    using System.Web.UI.HtmlControls;
    using System.Web.UI.WebControls;
    using YingNet.WeiXing.Business;

    public class MemberDetail2 : ManageBasePage
    {
        protected HtmlInputHidden Hidden1;
        protected HtmlInputHidden Hidden2;
        protected LinkButton LinkButton1;
        public string selState = "";
        public string txCity = "";
        public string txDate = "";
        public string txDriver = "";
        public string txEmail = "";
        public string txFax = "";
        public string txFname = "";
        public string txIssue = "";
        public string txLname = "";
        public string txMname = "";
        public string txMobile = "";
        public string txMonthd = "";
        public string txPost = "";
        public string txResident = "";
        public string txStreet = "";
        public string txTel = "";
        public string txYeard = "";

        private void InitializeComponent()
        {
            this.LinkButton1.Click += new EventHandler(this.LinkButton1_Click);
            base.Load += new EventHandler(this.Page_Load);
        }

        private void LinkButton1_Click(object sender, EventArgs e)
        {
            base.Response.Write("<script>window.location='MemberHistory.aspx?id=" + this.Hidden2.Value + "';</script>");
        }

        protected override void OnInit(EventArgs e)
        {
            this.InitializeComponent();
            base.OnInit(e);
        }

        private void Page_Load(object sender, EventArgs e)
        {
            if (!this.Page.IsPostBack)
            {
                int num = Convert.ToInt32(base.Request["id"]);
                this.Hidden1.Value = num.ToString();
                HuibackupBN pbn = new HuibackupBN(this.Page);
                pbn.QuerySid(num.ToString());
                DataTable list = pbn.GetList();
                if (list.Rows.Count > 0)
                {
                    this.txFname = list.Rows[0]["Fname"].ToString();
                    this.txLname = list.Rows[0]["Lname"].ToString();
                    this.txMname = list.Rows[0]["Mname"].ToString();
                    this.txDate = Convert.ToDateTime(list.Rows[0]["DBirth"]).ToShortDateString();
                    this.txEmail = list.Rows[0]["Email"].ToString();
                    this.txIssue = list.Rows[0]["Issued"].ToString();
                    this.txDriver = list.Rows[0]["DNumber"].ToString();
                    this.txResident = list.Rows[0]["RAddress"].ToString();
                    this.txStreet = list.Rows[0]["SAddress"].ToString();
                    this.txCity = list.Rows[0]["City"].ToString();
                    this.selState = list.Rows[0]["State"].ToString();
                    this.txPost = list.Rows[0]["Postcode"].ToString();
                    this.txYeard = list.Rows[0]["TYears"].ToString();
                    this.txMonthd = list.Rows[0]["TMonths"].ToString();
                    this.txTel = list.Rows[0]["HTel"].ToString();
                    this.txMobile = list.Rows[0]["Mobile"].ToString();
                    this.txFax = list.Rows[0]["Param1"].ToString();
                    this.Hidden2.Value = list.Rows[0]["username"].ToString();
                }
            }
        }
    }
}

