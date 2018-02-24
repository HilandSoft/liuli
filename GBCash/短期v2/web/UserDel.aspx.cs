namespace YingNet.WeiXing.WebApp
{
    using System;
    using System.Web.UI.HtmlControls;
    using System.Web.UI.WebControls;
    using YingNet.WeiXing.Business;

    public class UserDel : ManageBasePage
    {
        protected Label LabMsg;
        protected HtmlInputButton returnmain;
        protected TextBox TextBox1;
        protected TextBox txtParamstr;

        private void ButReturn_Click(object sender, EventArgs e)
        {
            base.Response.Redirect("UserManage.Aspx?" + base.PackFull(this.txtParamstr.Text));
        }

        private void InitializeComponent()
        {
            this.returnmain.ServerClick += new EventHandler(this.returnmain_ServerClick);
            base.Load += new EventHandler(this.Page_Load);
        }

        protected override void OnInit(EventArgs e)
        {
            base.Code = "001001";
            this.InitializeComponent();
            base.OnInit(e);
        }

        private void Page_Load(object sender, EventArgs e)
        {
            if (!base.IsPostBack)
            {
                base.ParamValue = base.UnPack();
                this.txtParamstr.Text = base.PackPart(base.ParamValue);
                if (base.Request["id"] != null)
                {
                    this.TextBox1.Text = base.Request["id"];
                    this.LabMsg.Text = "This item will be deleted permanently. Do you want to continue?";
                }
            }
            else
            {
                base.ParamValue = base.UnPackPart(this.txtParamstr.Text);
            }
        }

        private void returnmain_ServerClick(object sender, EventArgs e)
        {
            if (this.TextBox1.Text != null)
            {
                YingSystemUserBN rbn = new YingSystemUserBN(this.Page);
                if (rbn.Del(Convert.ToInt32(this.TextBox1.Text)))
                {
                    base.Response.Write("<script>alert('删除成功!');window.location =\"UserManage.Aspx\"; </script>");
                }
                else
                {
                    base.Response.Write("<script>alert('删除失败!'); window.location =\"UserManage.Aspx\";</script>");
                }
            }
            else
            {
                this.LabMsg.Text = "操作错误！";
            }
        }
    }
}

