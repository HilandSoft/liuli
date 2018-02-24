namespace YingNet.WeiXing.WebApp.Long.Member
{
    using System;
    using System.Web.UI.WebControls;

    public class ContactUs : MemberParent
    {
        protected TextBox txLoanSid;

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
        }
    }
}

