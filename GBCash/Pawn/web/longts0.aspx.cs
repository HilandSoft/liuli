namespace YingNet.WeiXing.WebApp
{
    using System;
    using System.Web.UI;
    using System.Web.UI.HtmlControls;
    using System.Web.UI.WebControls;

    public class longts0 : Page
    {
        protected HtmlInputButton bnSubmit;
        protected CheckBoxList CheckBoxList1;
        public string Info = "";

        private void bnSubmit_ServerClick(object sender, EventArgs e)
        {
            if (!this.CheckBoxList1.Items[0].Selected)
            {
                this.Info = this.Info + "You must be an Australian permanent resident and over 18 years old.&lt;br&gt;";
            }
            if (!this.CheckBoxList1.Items[1].Selected)
            {
                this.Info = this.Info + "You must be a wage or salary earner.&lt;br&gt;";
            }
            if (!this.CheckBoxList1.Items[2].Selected)
            {
                this.Info = this.Info + "You must have been with your current employer for at least 6 months.<br>";
            }
            if (!this.CheckBoxList1.Items[3].Selected)
            {
                this.Info = this.Info + "You must have a bank account in good standing verifying the income deposits.<br>";
            }
            if (!this.CheckBoxList1.Items[4].Selected)
            {
                this.Info = this.Info + "You must have been on your current address for at least the last 3 months.<br>";
            }
            if (!this.CheckBoxList1.Items[5].Selected)
            {
                this.Info = this.Info + "You must have read and understood Golden Bridge Cash Solution’s Information Statement.<br>";
            }
            if (this.Info.Length > 0)
            {
                this.Page.RegisterStartupScript("", "<script language=javascript>f1('info.aspx?id=" + this.Info + "')</script>");
            }
            else
            {
                base.Response.Write("<script>window.location='longts1.aspx';</script>");
            }
        }

        private void InitializeComponent()
        {
            this.bnSubmit.ServerClick += new EventHandler(this.bnSubmit_ServerClick);
            base.Load += new EventHandler(this.Page_Load);
        }

        protected override void OnInit(EventArgs e)
        {
            this.InitializeComponent();
            base.OnInit(e);
        }

        private void Page_Load(object sender, EventArgs e)
        {
        }
    }
}

