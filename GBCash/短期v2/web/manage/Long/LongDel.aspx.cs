namespace YingNet.WeiXing.WebApp.manage.Long
{
    using System;
    using System.Data;
    using System.Data.SqlClient;
    using System.Web.UI;
    using System.Web.UI.HtmlControls;
    using System.Web.UI.WebControls;
    using YingNet.Common;

    public class LongDel : Page
    {
        protected Label LabMsg;
        protected HtmlInputButton returnmain;
        protected TextBox TextBox1;
        protected TextBox txtParamstr;

        private void InitializeComponent()
        {
            this.returnmain.ServerClick += new EventHandler(this.returnmain_ServerClick);
            base.Load += new EventHandler(this.Page_Load);
        }

        protected override void OnInit(EventArgs e)
        {
            this.InitializeComponent();
            base.OnInit(e);
        }

        private void Page_Load(object sender, EventArgs e)
        {
            if (!base.IsPostBack && (base.Request["sid"] != null))
            {
                this.TextBox1.Text = base.Request["sid"].ToString();
            }
        }

        private void returnmain_ServerClick(object sender, EventArgs e)
        {
            SqlParameter[] commandParameters = new SqlParameter[] { new SqlParameter("@sid", this.TextBox1.Text) };
            if (SqlHelper.ExecuteNonQuery(Config.DataSource, CommandType.StoredProcedure, "Del_LongMember", commandParameters) > 0)
            {
                base.Response.Write("<script>alert('Success!');window.location='LongList.aspx';</script>");
            }
        }
    }
}

