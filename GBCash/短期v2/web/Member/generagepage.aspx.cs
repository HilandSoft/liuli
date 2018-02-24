namespace YingNet.WeiXing.WebApp.Member
{
    using System;
    using YingNet.Common;

    public class generagepage : CommonBasePage
    {
        private string huisid = "";

        public void CheckLogin()
        {
            string cookie = CookieHelper.GetCookie("huiSid");
            if ((this.Session["huiSid"] == null) && ((cookie == null) || (cookie == "")))
            {
                base.Response.Write("<script>alert('You have exceeded the login time.For your protection please re-enter your user name and password.');parent.location.href='../login.htm';</script>");
                base.Response.Redirect("../login.htm");
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

        protected string HuiSid
        {
            get
            {
                if ((this.huisid == "") && (this.Session["huiSid"] != null))
                {
                    this.huisid = this.Session["huiSid"].ToString();
                }
                if (this.huisid == "")
                {
                    string cookie = CookieHelper.GetCookie("huiSid");
                    if ((cookie != null) && (cookie != ""))
                    {
                        this.huisid = CookieHelper.GetCookie("huiSid");
                    }
                }
                return this.huisid;
            }
        }
    }
}

