namespace YingNet.WeiXing.WebApp.manage.ProcessCenter
{
    using System;
    using YingNet.WeiXing.Business;

    public class MainFrameSet : ManageBasePage
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
        }
    }
}

