namespace YingNet.WeiXing.WebApp.manage.Long
{
    using System;
    using System.Data;
    using System.Data.SqlClient;
    using System.Web.UI;
    using System.Web.UI.WebControls;
    using YingNet.Common;
	using YingNet.Common.Utils;

    public class LoanPay : Page
    {
        protected Button bnReturn;
        protected Button bnSave;
        protected TextBox txDatedue;
        protected TextBox txLateCharge;
        protected TextBox txPaid;
        protected TextBox txPenalty;
        protected TextBox txPerSid;
        protected TextBox txRepaydue;
        protected TextBox txRepayTime;
        protected TextBox txSid;

        private void bnReturn_Click(object sender, EventArgs e)
        {
            base.Response.Redirect("LoanInfo.aspx?sid=" + this.txPerSid.Text);
        }

        private void bnSave_Click(object sender, EventArgs e)
        {
            string commandText = "";
            commandText = "update LPay set Repaydue=" + this.txRepaydue.Text + ",Paid=" + this.txPaid.Text + ",Penalty=" + this.txPenalty.Text + ",LateCharge=" + this.txLateCharge.Text + ",RepayTime='" + this.txRepayTime.Text + "',OperateTime='" + SafeDateTime.LocalNow.ToString("dd/MM/yyyy hh:mm:ss") + "' where sid=" + this.txSid.Text;
            if (SqlHelper.ExecuteNonQuery(Config.DataSource, CommandType.Text, commandText).Equals(1))
            {
                commandText = "update LPay set Balance=Repaydue+Penalty+LateCharge-Paid where sid=" + this.txSid.Text;
                SqlHelper.ExecuteNonQuery(Config.DataSource, CommandType.Text, commandText);
                SqlParameter[] commandParameters = new SqlParameter[] { new SqlParameter("@sid", this.txSid.Text), new SqlParameter("@PerSid", this.txPerSid.Text) };
                SqlHelper.ExecuteNonQuery(Config.DataSource, CommandType.StoredProcedure, "UpdateBalance", commandParameters);
                base.Response.Write("<script>alert('Success!');window.location='LoanInfo.aspx?sid=" + this.txPerSid.Text + "';</script>");
            }
        }

        public void GetInfo(string sid)
        {
            string commandText = "select * from LPay where sid=" + sid;
            DataTable table = SqlHelper.ExecuteDataset(Config.DataSource, CommandType.Text, commandText).Tables[0];
            if (table.Rows.Count > 0)
            {
                this.txDatedue.Text = table.Rows[0]["Datedue"].ToString();
                this.txRepaydue.Text = table.Rows[0]["Repaydue"].ToString();
                this.txPaid.Text = table.Rows[0]["Paid"].ToString();
                this.txPenalty.Text = table.Rows[0]["Penalty"].ToString();
                if (table.Rows[0]["LateCharge"].ToString() != "")
                {
                    this.txLateCharge.Text = table.Rows[0]["LateCharge"].ToString();
                }
                this.txRepayTime.Text = table.Rows[0]["RepayTime"].ToString();
            }
        }

        private void InitializeComponent()
        {
            this.bnSave.Click += new EventHandler(this.bnSave_Click);
            this.bnReturn.Click += new EventHandler(this.bnReturn_Click);
            base.Load += new EventHandler(this.Page_Load);
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
                this.txSid.Text = base.Request["sid"].ToString();
                this.GetInfo(this.txSid.Text);
                if (base.Request["psid"] != null)
                {
                    this.txPerSid.Text = base.Request["psid"].ToString();
                }
            }
        }
    }
}

