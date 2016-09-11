namespace YingNet.WeiXing.WebApp.Member
{
    using System;
    using YingNet.Common;

    public class generagepage : CommonBasePage
    {
        public void CheckLogin()
        {
			string userIDInCookie= CookieHelper.GetCookie("huiSid");
			if (this.Session["huiSid"] == null && (userIDInCookie==null|| userIDInCookie==""))
            {
                base.Response.Write("<script>alert('You have exceeded the login time.For your protection please re-enter your user name and password.');parent.location.href='../login.htm';</script>");
				this.Response.Redirect("../login.htm");
            }
        }

		private string huisid= "";
		protected string HuiSid
		{
			get
			{
				if(this.huisid=="")
				{
					if(this.Session["huiSid"] != null)
					{
						huisid= this.Session["huiSid"].ToString();
					}
				}

				if(this.huisid=="")
				{
					string userIDInCookie= CookieHelper.GetCookie("huiSid");
					if(userIDInCookie!=null&& userIDInCookie!="")
					{
						huisid= CookieHelper.GetCookie("huiSid");
					}
				}

				return this.huisid;
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

