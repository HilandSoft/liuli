namespace YingNet.WeiXing.WebApp.Member
{
    using System;
    using System.Data;
    using System.Web.UI;
    using System.Web.UI.HtmlControls;
    using YingNet.Common;
    using YingNet.WeiXing.Business;

    public class login : Page
    {
        protected HtmlInputButton Button1;
        protected HtmlInputText txPassword;
        protected HtmlInputText txUsername;

        private void Button1_ServerClick(object sender, EventArgs e)
        {
            HuiyuanBN nbn = new HuiyuanBN(this.Page);
            if (this.txUsername.Value == "")
            {
                base.Response.Write("<script>alert('Username is not valid!');</script>");
            }
            else if (this.txPassword.Value == "")
            {
                base.Response.Write("<script>alert('Password is not valid!');</script>");
            }
            else
            {
                nbn.QueryUsername(this.txUsername.Value);
                nbn.QueryNotValid("9");
                nbn.QueryNotValid("3");
                nbn.QueryNotValid("5");
                nbn.QueryNotValid("6");
                DataTable list = nbn.GetList();
                if (list.Rows.Count <= 0)
                {
                    base.Response.Write("<script>alert('Please re-enter your username and password. If you have forgotten your username or password please call 1300 137 906.');</script>");
                }
                else if (list.Rows[0]["Password"].ToString() != this.txPassword.Value)
                {
                    base.Response.Write("<script>alert('Password is not valid!');</script>");
                }
                else
                {
                    this.Session["huiSid"] = list.Rows[0]["id"].ToString();
                    CookieHelper.SetCookie("huiSid", list.Rows[0]["id"].ToString());
                    base.Response.Write("<script>alert('Welcome " + list.Rows[0]["Fname"] + "!');parent.location='detail1.aspx';</script>");
                }
            }
        }

        private void InitializeComponent()
        {
            this.Button1.ServerClick += new EventHandler(this.Button1_ServerClick);
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

