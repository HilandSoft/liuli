namespace YingNet.WeiXing.WebApp.manage
{
    using System;
    using System.Web.UI;
    using YingNet.WeiXing.Business;
    using YingNet.WeiXing.DB.Data;

    public class openoperate : Page
    {
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
            if (base.Request["id"] != null)
            {
                int id = Convert.ToInt32(base.Request["id"]);
                InfoBN obn = new InfoBN(this.Page);
                InfoDT dt = obn.Get(id);
                dt.isvalid = 0;
                obn.Edit(dt);
                base.Response.Write("<script>alert('删除成功!');window.location.href='openwindow.aspx';</script>");
            }
        }
    }
}

