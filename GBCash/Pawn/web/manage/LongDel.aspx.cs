namespace YingNet.WeiXing.WebApp.manage
{
    using System;
    using System.Data;
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
                this.TextBox1.Text = base.Request["sid"];
                this.LabMsg.Text = "This item will be deleted permanently. Do you want to continue?";
            }
        }

        private void returnmain_ServerClick(object sender, EventArgs e)
        {
            string commandText = "delete from longtp where sid=" + this.TextBox1.Text + "";
            if (SqlHelper.ExecuteNonQuery(Config.DataSource, CommandType.Text, commandText).Equals(1))
            {
                int num = SqlHelper.ExecuteNonQuery(Config.DataSource, CommandType.Text, "delete from longte where personsid=" + this.TextBox1.Text + "");
            }
            base.Response.Write("<script>alert('Success!');window.location.href='LongTerm.aspx';</script>");
        }
    }
}

