namespace YingNet.WeiXing.WebApp.Long
{
    using System;
    using System.Web.UI;
    using System.Web.UI.HtmlControls;
    using System.Web.UI.WebControls;
    using YingNet.Common.Utils;
    using YingNet.WeiXing.Business;
    using YingNet.WeiXing.STRUCTURE;

    public class Step1 : Page
    {
        protected DropDownList dlterms;
        protected Label Label1;
        protected HtmlInputButton Submit1;
        protected TextBox txborrow;
        protected TextBox txpurpose;

        private void InitializeComponent()
        {
            this.Submit1.ServerClick += new EventHandler(this.Submit1_ServerClick);
            base.Load += new EventHandler(this.Page_Load);
        }

        protected override void OnInit(EventArgs e)
        {
            this.InitializeComponent();
            base.OnInit(e);
        }

        private void Page_Load(object sender, EventArgs e)
        {
            this.Submit1.Attributes.Add("onclick", "return CheckFeedback();");
        }

        private void Submit1_ServerClick(object sender, EventArgs e)
        {
            LiniloanBN nbn = new LiniloanBN(this.Page);
            LiniloanDT detail = new LiniloanDT();
            detail.PrimaryPurpose = this.txpurpose.Text;
            detail.Loan = Convert.ToDouble(this.txborrow.Text);
            detail.Term = Convert.ToInt32(this.dlterms.SelectedValue);
            detail.Other1 = Convert.ToString(SafeDateTime.LocalToday);
            detail.Other2 = "";
            detail.Other3 = "";
            detail.Other4 = 0;
            detail.Other5 = 0;
            detail.Other6 = 0;
            detail.Persid = 0;
            int num = nbn.AddId(detail);
            nbn.Close();
            nbn.Dispose();
            if (num > 0)
            {
                base.Response.Write("<script>window.location='Step2.aspx?sid=" + num.ToString() + "';</script>");
            }
        }
    }
}

