namespace YingNet.WeiXing.WebApp.manage
{
    using System;
    using System.Web.UI;
    using System.Web.UI.WebControls;
    using YingNet.WeiXing.Business;
    using YingNet.WeiXing.DB.Data;

    public class renew : Page
    {
        protected Button Button1;
        protected TextBox TextBox1;

        private void Button1_Click(object sender, EventArgs e)
        {
            if (this.TextBox1.Text != "")
            {
                HuiyuanBN nbn = new HuiyuanBN(this.Page);
                int id = Convert.ToInt32(this.TextBox1.Text);
                HuiyuanDT dt = nbn.Get(id);
                dt.IsValid = 0;
                nbn.Edit(dt);
                base.Response.Write("<script>alert('Success!');window.location.href='MemberList.aspx';</script>");
            }
        }

        private void InitializeComponent()
        {
            this.Button1.Click += new EventHandler(this.Button1_Click);
            base.Load += new EventHandler(this.Page_Load);
        }

        protected override void OnInit(EventArgs e)
        {
            this.InitializeComponent();
            base.OnInit(e);
        }

        private void Page_Load(object sender, EventArgs e)
        {
            this.Button1.Text = "Renew";
        }
    }
}

