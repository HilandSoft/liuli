namespace YingNet.WeiXing.WebApp.Long
{
    using System;
    using System.Data;
    using System.Web.UI;
    using System.Web.UI.WebControls;
    using YingNet.WeiXing.Business;

    public class Payroll : Page
    {
        protected LinkButton LinkButton1;
        protected LinkButton LinkButton2;
        protected LinkButton Linkbutton3;
        public string stxEmployer = "";
        public string stxfname = "";
        public string stxmname = "";
        public string stxsname = "";
        protected TextBox txPerSid;

        private void InitializeComponent()
        {
            this.Linkbutton3.Click += new EventHandler(this.Linkbutton3_Click);
            this.LinkButton1.Click += new EventHandler(this.LinkButton1_Click);
            this.LinkButton2.Click += new EventHandler(this.LinkButton2_Click);
            base.Load += new EventHandler(this.Page_Load);
        }

        private void LinkButton1_Click(object sender, EventArgs e)
        {
            base.Response.Write("<script>window.location='PrivState.aspx?sid=" + this.txPerSid.Text + "';</script>");
        }

        private void LinkButton2_Click(object sender, EventArgs e)
        {
            base.Response.Write("<script>window.location='Finish.aspx';</script>");
        }

        private void Linkbutton3_Click(object sender, EventArgs e)
        {
            base.Response.Write("<script>window.location='DirectDebit.aspx?sid=" + this.txPerSid.Text + "';</script>");
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
                this.txPerSid.Text = base.Request["sid"].ToString();
                int sid = Convert.ToInt32(this.txPerSid.Text);
                LpersonBN nbn = new LpersonBN(this.Page);
                nbn.Querysid(sid);
                DataTable list = nbn.GetList();
                if (list.Rows.Count > 0)
                {
                    this.stxfname = list.Rows[0]["Fname"].ToString();
                    this.stxmname = list.Rows[0]["Mname"].ToString();
                    this.stxsname = list.Rows[0]["Sname"].ToString();
                }
                LemploymentBN tbn = new LemploymentBN(this.Page);
                tbn.QueryLoanSid(sid);
                DataTable table2 = tbn.GetList();
                if (table2.Rows.Count > 0)
                {
                    this.stxEmployer = table2.Rows[0]["EName"].ToString();
                }
            }
        }
    }
}

