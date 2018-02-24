namespace YingNet.WeiXing.WebApp.manage
{
    using System;
    using System.Data;
    using System.Web.UI;
    using System.Web.UI.HtmlControls;
    using System.Web.UI.WebControls;
    using YingNet.WeiXing.Business;

    public class InforDetail : Page
    {
        public string EAddress = "";
        public string Employer = "";
        public string EPhone = "";
        public string Frequency = "";
        protected HtmlInputHidden Hidden1;
        protected HtmlInputHidden Hidden2;
        public string huiName = "";
        public string huiSid = "";
        public string IsEmployed = "";
        protected LinkButton LinkButton1;
        protected LinkButton LinkButton2;
        public string MIncome = "";
        public string ModTime = "";
        public string NDayDD = "";
        public string NDayMM = "";
        public string NDayYY = "";
        protected Panel Panel1;
        protected Panel Panel2;
        public string TMonths = "";
        public string TYears = "";
        public string Wpaid = "";

        private void InitializeComponent()
        {
            this.LinkButton1.Click += new EventHandler(this.LinkButton1_Click);
            this.LinkButton2.Click += new EventHandler(this.LinkButton2_Click);
            base.Load += new EventHandler(this.Page_Load);
        }

        private void LinkButton1_Click(object sender, EventArgs e)
        {
            base.Response.Write("<script>window.location='InforHistory.aspx?id=" + this.Hidden2.Value + "'</script>");
        }

        private void LinkButton2_Click(object sender, EventArgs e)
        {
            base.Response.Write("<script>window.location='InforHistory.aspx?id=" + this.Hidden2.Value + "'</script>");
        }

        protected override void OnInit(EventArgs e)
        {
            this.InitializeComponent();
            base.OnInit(e);
        }

        private void Page_Load(object sender, EventArgs e)
        {
            if (base.Request["id"] != null)
            {
                this.Hidden1.Value = base.Request["id"].ToString();
                EmploybackupBN pbn = new EmploybackupBN(this.Page);
                pbn.Querysid(this.Hidden1.Value);
                DataTable list = pbn.GetList();
                if (list.Rows.Count > 0)
                {
                    this.Employer = list.Rows[0]["Employer"].ToString();
                    this.EAddress = list.Rows[0]["EAddress"].ToString();
                    this.EPhone = list.Rows[0]["EPhone"].ToString();
                    this.TYears = list.Rows[0]["TYears"].ToString();
                    this.TMonths = list.Rows[0]["TMonths"].ToString();
                    this.MIncome = list.Rows[0]["MIncome"].ToString();
                    this.Wpaid = list.Rows[0]["Wpaid"].ToString();
                    this.NDayMM = list.Rows[0]["NDayMM"].ToString();
                    this.NDayDD = list.Rows[0]["NDayDD"].ToString();
                    this.NDayYY = list.Rows[0]["NDayYY"].ToString();
                    this.IsEmployed = list.Rows[0]["IsEmployed"].ToString();
                    this.Frequency = list.Rows[0]["Frequency"].ToString();
                    this.huiSid = list.Rows[0]["huiSid"].ToString();
                    this.ModTime = list.Rows[0]["ModTime"].ToString();
                    this.huiName = list.Rows[0]["huiName"].ToString();
                    this.IsEmployed = list.Rows[0]["IsEmployed"].ToString();
                    this.Hidden2.Value = list.Rows[0]["huiSid"].ToString();
                    if (this.IsEmployed.Equals("1"))
                    {
                        this.Panel1.Visible = true;
                        this.Panel2.Visible = false;
                    }
                    else
                    {
                        this.Panel1.Visible = false;
                        this.Panel2.Visible = true;
                    }
                }
            }
        }
    }
}

