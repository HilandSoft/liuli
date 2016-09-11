namespace YingNet.WeiXing.WebApp.Long
{
    using System;
    using System.Data;
    using System.Web.UI;
    using System.Web.UI.HtmlControls;
    using YingNet.Common;
    using YingNet.WeiXing.Business;

    public class Login : Page
    {
        protected HtmlInputButton Submit1;
        protected HtmlInputText txPwd;
        protected HtmlInputText txUsername;

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
            LpersonBN nbn = new LpersonBN(this.Page);
            nbn.QueryUsername(this.txUsername.Value);
            nbn.QueryPwd(Cipher.EncryptMD5(this.txPwd.Value));
            nbn.QueryStatus(1);
            DataTable list = nbn.GetList();
            if (list.Rows.Count > 0)
            {
                this.Session["LongMember"] = list.Rows[0]["sid"].ToString();
                base.Response.Write("<script>alert('Welcome " + this.txUsername.Value + "!');parent.location='Member/Index.aspx';</script>");
            }
            else
            {
                base.Response.Write("<script>alert('Please re-enter your username and password. If you have forgotten your username or password please call 1300 137 906.');</script>");
            }
        }
    }
}

