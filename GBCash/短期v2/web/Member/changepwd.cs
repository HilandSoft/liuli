namespace YingNet.WeiXing.WebApp.Member
{
    using System;
    using System.Web.UI.HtmlControls;
    using YingNet.WeiXing.Business;
    using YingNet.WeiXing.DB.Data;

    public class changepwd : generagepage
    {
        protected HtmlInputButton Button1;
        protected HtmlForm Form2;
        protected HtmlInputText oldPwd;
        protected HtmlInputText Password1;
        protected HtmlInputText Password2;

        private void Button1_ServerClick(object sender, EventArgs e)
        {
            HuiyuanDT ndt = new HuiyuanBN(this.Page).Get(Convert.ToInt32(base.HuiSid));
            if (this.oldPwd.Value != ndt.Password)
            {
                base.Response.Write("<script>alert('Error,fill it again!')</script>");
            }
            else if (this.Password1.Value == "")
            {
                base.Response.Write("<script>alert('Must fill in old password!')</script>");
            }
            else if (this.Password1.Value != this.Password2.Value)
            {
                base.Response.Write("<script>alert('Error,fill it again!')</script>");
            }
            else
            {
                HuiyuanBN nbn = new HuiyuanBN(this.Page);
                HuiyuanDT dt = nbn.Get(Convert.ToInt32(base.HuiSid));
                dt.Password = this.Password1.Value;
                nbn.Edit(dt);
                base.Response.Write("<script>alert('Success!')</script>");
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

