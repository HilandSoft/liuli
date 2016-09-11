namespace YingNet.WeiXing.WebApp.Long.Member
{
    using System;
    using System.Web.UI.HtmlControls;
    using System.Web.UI.WebControls;
    using YingNet.Common;
    using YingNet.WeiXing.Business;
    using YingNet.WeiXing.STRUCTURE;

    public class ChangePwd : MemberParent
    {
        protected Button Button2;
        protected HtmlInputText oldPwd;
        protected HtmlInputText Password1;
        protected HtmlInputText Password2;
        protected TextBox txLoanSid;
        protected TextBox txPerSid;

        private void Button2_Click(object sender, EventArgs e)
        {
            string str = Cipher.EncryptMD5(this.oldPwd.Value);
            string str2 = Cipher.EncryptMD5(this.Password1.Value);
            LpersonBN nbn = new LpersonBN(this.Page);
            LpersonDT detail = nbn.Get(Convert.ToInt32(this.txPerSid.Text));
            if (detail.Pwd == str)
            {
                detail.Pwd = str2;
                if (nbn.Edit(detail))
                {
                    base.Response.Write("<script>alert('Success!');</script>");
                }
            }
            else
            {
                base.Response.Write("<script>alert('Error,fill the old password again!');</script>");
            }
        }

        private void InitializeComponent()
        {
            this.Button2.Click += new EventHandler(this.Button2_Click);
            base.Load += new EventHandler(this.Page_Load);
        }

        protected override void OnInit(EventArgs e)
        {
            this.InitializeComponent();
            base.OnInit(e);
        }

        private void Page_Load(object sender, EventArgs e)
        {
            this.Button2.Attributes.Add("onclick", "return CheckFeed();");
            if (this.Session["LongMember"] != null)
            {
                this.txPerSid.Text = this.Session["LongMember"].ToString();
            }
        }
    }
}

