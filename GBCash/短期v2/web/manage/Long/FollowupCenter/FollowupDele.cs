namespace YingNet.WeiXing.WebApp.manage.Long.FollowupCenter
{
    using System;
    using System.Web.UI;
    using YingNet.WeiXing.Business;

    public class FollowupDele : Page
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
            string str = base.Request.QueryString["followupID"];
            if ((str != null) && (str != string.Empty))
            {
                try
                {
                    new CSFollowupCenterBN(this.Page).Del(Convert.ToInt32(str));
                }
                catch
                {
                }
                finally
                {
                    base.Response.Write("<script>window.location='FollowupList.aspx';</script>");
                }
            }
        }
    }
}

