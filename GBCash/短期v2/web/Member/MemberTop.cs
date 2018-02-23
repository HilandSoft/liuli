namespace YingNet.WeiXing.WebApp.Member
{
    using System;
    using System.Web.UI;
    using System.Web.UI.WebControls;
    using YingNet.Common;
    using YingNet.WeiXing.Business;
    using YingNet.WeiXing.DB.Data;

    public class MemberTop : UserControl
    {
        private string huisid = "";
        protected Literal litUserNameDisplay;

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
            this.litUserNameDisplay.Text = string.Empty;
            if (this.HuiSid != "")
            {
                HuiyuanDT ndt = new HuiyuanBN(this.Page).Get(Convert.ToInt32(this.HuiSid));
                if (ndt != null)
                {
                    this.litUserNameDisplay.Text = ndt.Fname + " " + ndt.Lname;
                }
            }
        }

        protected string HuiSid
        {
            get
            {
                if ((this.huisid == "") && (base.Session["huiSid"] != null))
                {
                    this.huisid = base.Session["huiSid"].ToString();
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

