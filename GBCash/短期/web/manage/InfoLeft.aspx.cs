﻿namespace YingNet.WeiXing.WebApp.manage
{
    using System;
    using YingNet.WeiXing.Business;

    public class InfoLeft : ManageBasePage
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

