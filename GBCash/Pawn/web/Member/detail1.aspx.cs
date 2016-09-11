namespace YingNet.WeiXing.WebApp.Member
{
    using System;
    using System.Data;
    using System.Web.UI.HtmlControls;
    using YingNet.WeiXing.Business;

    public class detail1 : generagepage
    {
        public string customno = "";
        public string dlTitle = "";
        protected HtmlGenericControl left;
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
        public string txMonth = "";
        public string txPost = "";
        public string txResident = "";
        public string txStreet = "";
        public string txTel = "";
        public string txYear = "";

        private void InitializeComponent()
        {
            base.Load += new EventHandler(this.Page_Load);
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
                HuiyuanBN nbn = new HuiyuanBN(this.Page);
                nbn.QuerySid(this.Session["huiSid"].ToString());
                DataTable list = nbn.GetList();
                this.dlTitle = list.Rows[0]["Param2"].ToString();
                this.txFname = list.Rows[0]["Fname"].ToString();
                this.txLname = list.Rows[0]["Lname"].ToString();
                this.txMname = list.Rows[0]["Mname"].ToString();
                this.txDate = Convert.ToDateTime(list.Rows[0]["DBirth"]).Day.ToString() + "/" + Convert.ToDateTime(list.Rows[0]["DBirth"]).Month.ToString() + "/" + Convert.ToDateTime(list.Rows[0]["DBirth"]).Year.ToString();
                this.txEmail = list.Rows[0]["Email"].ToString();
                this.txIssue = list.Rows[0]["Issued"].ToString();
                this.txDriver = list.Rows[0]["DNumber"].ToString();
                this.txResident = list.Rows[0]["RAddress"].ToString();
                this.txStreet = list.Rows[0]["SAddress"].ToString();
                this.txCity = list.Rows[0]["City"].ToString();
                this.selState = list.Rows[0]["State"].ToString();
                this.txPost = list.Rows[0]["Postcode"].ToString();
                this.txYear = list.Rows[0]["TYears"].ToString();
                this.txMonth = list.Rows[0]["TMonths"].ToString();
                this.txTel = list.Rows[0]["HTel"].ToString();
                this.txMobile = list.Rows[0]["Mobile"].ToString();
                this.txFax = list.Rows[0]["Param1"].ToString();
                this.customno = list.Rows[0]["id"].ToString();
            }
        }
    }
}

