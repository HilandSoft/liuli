﻿namespace YingNet.WeiXing.WebApp
{
    using System;
    using System.Web.UI;
    using System.Web.UI.WebControls;

    public class demo2 : Page
    {
        protected TextBox txhuiSid;

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

