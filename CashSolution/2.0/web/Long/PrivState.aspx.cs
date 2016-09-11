namespace YingNet.WeiXing.WebApp.Long
{
    using System;
    using System.Web.UI;
    using System.Web.UI.WebControls;
    using YingNet.Common;

    public class PrivState : Page
    {
        protected LinkButton LinkButton1;
        protected LinkButton Linkbutton3;
        protected TextBox txPerSid;

        private void InitializeComponent()
        {
            this.Linkbutton3.Click += new EventHandler(this.Linkbutton3_Click);
            this.LinkButton1.Click += new EventHandler(this.LinkButton1_Click);
            base.Load += new EventHandler(this.Page_Load);
        }

        private void LinkButton1_Click(object sender, EventArgs e)
        {
            base.Response.Write("<script>window.location='Finish.aspx';</script>");
        }

        private void Linkbutton3_Click(object sender, EventArgs e)
        {
            base.Response.Write("<script>window.location='DirectDebit.aspx?sid=" + Cipher.DesEncrypt(this.txPerSid.Text, "12345678") + "';</script>");
        }

        protected override void OnInit(EventArgs e)
        {
            this.InitializeComponent();
            base.OnInit(e);
        }

        private void Page_Load(object sender, EventArgs e)
        {
            if (base.Request["sid"] != null)
            {
                this.txPerSid.Text = Cipher.DesDecrypt(base.Request["sid"].ToString(), "12345678");
            }
        }
    }
}

