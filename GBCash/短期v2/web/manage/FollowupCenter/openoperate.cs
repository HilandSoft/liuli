namespace YingNet.WeiXing.WebApp.manage.FollowupCenter
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
                CSFollowupCenterBN rbn = new CSFollowupCenterBN(this.Page);
                CSFollowupCenterDT dt = rbn.Get(id);
                dt.RemindEnable = false;
                rbn.Edit(dt);
                base.Response.Write("<script>alert('delete item successfully!');window.location.href='openwindow.aspx';</script>");
            }
        }
    }
}

