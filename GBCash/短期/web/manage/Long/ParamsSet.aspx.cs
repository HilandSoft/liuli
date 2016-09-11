namespace YingNet.WeiXing.WebApp.manage.Long
{
    using System;
    using System.Data;
    using System.Web.UI;
    using System.Web.UI.WebControls;
    using YingNet.Common;

    public class ParamsSet : Page
    {
        protected Button bnSave;
        protected DropDownList DropDownList1;
        protected TextBox txNrB;
        protected TextBox txNrF;
        protected TextBox txNrM;
        protected TextBox txNrW;
        protected TextBox txPsB;
        protected TextBox txPsF;
        protected TextBox txPsM;
        protected TextBox txPsW;
        protected TextBox txRdB;
        protected TextBox txRdF;
        protected TextBox txRdM;
        protected TextBox txRdW;

        private void bnSave_Click(object sender, EventArgs e)
        {
            string commandText = "update LParams set NrW=" + this.txNrW.Text + ",NrF=" + this.txNrF.Text + ",NrB=" + this.txNrB.Text + ",NrM=" + this.txNrM.Text + ",PsW=" + this.txPsW.Text + ",PsF=" + this.txPsF.Text + ",PsB=" + this.txPsB.Text + ",PsM=" + this.txPsM.Text + ",RdW=" + this.txRdW.Text + ",RdF=" + this.txRdF.Text + ",RdB=" + this.txRdB.Text + ",RdM=" + this.txRdM.Text + " where Sid=" + this.DropDownList1.SelectedValue;
            if (SqlHelper.ExecuteNonQuery(Config.DataSource, CommandType.Text, commandText).Equals(1))
            {
                base.Response.Write("<script>alert('Success!');</script>");
            }
        }

        private void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.GetParams(this.DropDownList1.SelectedValue);
        }

        public void GetParams(string sid)
        {
            string commandText = "select * from LParams where Sid=" + sid;
            DataTable table = SqlHelper.ExecuteDataset(Config.DataSource, CommandType.Text, commandText).Tables[0];
            if (table.Rows.Count > 0)
            {
                this.txNrW.Text = table.Rows[0]["NrW"].ToString();
                this.txNrF.Text = table.Rows[0]["NrF"].ToString();
                this.txNrB.Text = table.Rows[0]["NrB"].ToString();
                this.txNrM.Text = table.Rows[0]["NrM"].ToString();
                this.txPsW.Text = table.Rows[0]["PsW"].ToString();
                this.txPsF.Text = table.Rows[0]["PsF"].ToString();
                this.txPsB.Text = table.Rows[0]["PsB"].ToString();
                this.txPsM.Text = table.Rows[0]["PsM"].ToString();
                this.txRdW.Text = table.Rows[0]["RdW"].ToString();
                this.txRdF.Text = table.Rows[0]["RdF"].ToString();
                this.txRdB.Text = table.Rows[0]["RdB"].ToString();
                this.txRdM.Text = table.Rows[0]["RdM"].ToString();
            }
        }

        private void InitializeComponent()
        {
            this.bnSave.Click += new EventHandler(this.bnSave_Click);
            this.DropDownList1.SelectedIndexChanged += new EventHandler(this.DropDownList1_SelectedIndexChanged);
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
                this.GetParams(this.DropDownList1.Items[0].Value);
            }
        }
    }
}

