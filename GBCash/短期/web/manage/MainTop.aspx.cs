﻿using System.Text;
using System.Web.UI.WebControls;
using YingNet.WeiXing.Business.CommonLogic;

namespace YingNet.WeiXing.WebApp.manage
{
    using System;
    using YingNet.WeiXing.Business;

    public class MainTop : ManageBasePage
    {
        protected Literal litMenu;
    	protected Literal litLogUserAccount;
    	
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
        	if(this.IsPostBack==false)
        	{
        		this.ShowMenu();
        	}
        }
    	
    	/// <summary>
    	/// 根据权限显示菜单
    	/// </summary>
    	private void ShowMenu()
    	{
    		if(this.SystemUserAccount!=null &&this.SystemUserAccount!= string.Empty)
    		{
    			litLogUserAccount.Text = string.Format("[{0}]",this.SystemUserAccount);
    		}
    		
    		if(this.SystemUserID!=0)
    		{
    			string menuItemString = "<td id=\"{0}\" width=\"80\" align=\"center\" class=\"wnd_label_active\" onmouseover=\"onOverWndLabel()\" onmouseout=\"onOutWndLabel()\" onclick=\"onClickWndLabel()\"><nobr>{1}</nobr></td><td width=\"1\" bgcolor=\"#000000\" class=\"wnd_label_normal\"></td>";
    			StringBuilder sb= new StringBuilder();
    			sb.AppendFormat(menuItemString, "a0","<a href='javascript:jumps(\"MainHome.aspx\")'> Home </a>");
    			
    			sb.AppendFormat(menuItemString, "a7"," <a href='javascript:jumps(\"MemberList.aspx\")'> MemberList </a>");
    			//sb.AppendFormat(menuItemString, "a8","SystemParameter");
    			sb.AppendFormat(menuItemString, "a3"," <a href='javascript:jumps(\"agreeinput.aspx\")'> Agreement </a>");
    			sb.AppendFormat(menuItemString, "a10"," <a href='javascript:jumps(\"renew.aspx\")'> Member Renew </a>");
    			this.litMenu.Text = sb.ToString();
    		}
    	}
    }
}

