namespace YingNet.WeiXing.WebApp.Long.Member
{
    using System;
    using System.Data;
    using System.Web.UI.WebControls;
    using YingNet.Common;

    public class MyLoan : MemberParent
    {
        public DataTable dtPay = new DataTable();
        public string sNumber = "";
        protected TextBox txPerSid;

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
            if (this.Session["LongMember"] != null)
            {
                this.txPerSid.Text = this.Session["LongMember"].ToString();
                string commandText = "";
                commandText = "select * from LPay where PerSid=" + this.txPerSid.Text;
                this.dtPay = SqlHelper.ExecuteDataset(Config.DataSource, CommandType.Text, commandText).Tables[0];
                if (this.dtPay.Rows.Count > 0)
                {
                    this.sNumber = this.dtPay.Rows[0]["PerSid"].ToString();
                }
            }
        }
    }
}

