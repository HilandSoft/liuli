﻿namespace YingNet.WeiXing.WebApp.manage.LoanSet
{
    using System;
    using System.Web.UI;

    public class BlackList : Page
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

