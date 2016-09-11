namespace YingNet.WeiXing.WebApp.Long.Member
{
    using System;
    using System.Web.UI;

    public class MemberParent : Page
    {
        public void CheckLogin()
        {
            if (this.Session["LongMember"] == null)
            {
                base.Response.Write("<script>alert('You have exceeded the login time.For your protection please re-enter your user name and password.');parent.location.href='../Login.aspx';</script>");
            }
        }

        private void InitializeComponent()
        {
            base.Load += new EventHandler(this.Page_Load);
        }

        protected override void OnInit(EventArgs e)
        {
            this.InitializeComponent();
            base.OnInit(e);
            this.CheckLogin();
        }

        private void Page_Load(object sender, EventArgs e)
        {
        }
    }
}

