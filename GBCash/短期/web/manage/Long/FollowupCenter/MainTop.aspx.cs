using System.Text;
using System.Web.UI.WebControls;
using YingNet.WeiXing.Business.CommonLogic;

namespace YingNet.WeiXing.WebApp.manage.Long.FollowupCenter
{
    using System;
    using YingNet.WeiXing.Business;

    public class MainTop : ManageBasePage
    {
        protected Literal litMenu;
    	protected Literal litLogUserAccount;
    	
    	private void InitializeComponent()
        {
			this.Load += new System.EventHandler(this.Page_Load);

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
				sb.AppendFormat(menuItemString, "a0","<a href='javascript:jumps(\"../../MainHome.aspx\")'>Home&nbsp;&nbsp;");

				sb.AppendFormat(menuItemString,"b0","<a href='javascript:jumps(\"FollowupStat.aspx\")'>Stat&nbsp;&nbsp;");

				sb.AppendFormat(menuItemString, "c0", "<a href='javascript:jumps(\"FollowupList.aspx?status=0\")'>Everyday&nbsp;&nbsp;</a>");
				sb.AppendFormat(menuItemString, "c1", "<a href='javascript:jumps(\"FollowupList.aspx?status=10\")'>ByDate&nbsp;&nbsp;</a>");
				sb.AppendFormat(menuItemString, "c2", "<a href='javascript:jumps(\"FollowupList.aspx?status=20\")'>Scheduled&nbsp;&nbsp;</a>");
				sb.AppendFormat(menuItemString, "c3", "<a href='javascript:jumps(\"FollowupList.aspx?status=30\")'>Re-DDed&nbsp;&nbsp;</a>");
				sb.AppendFormat(menuItemString, "c4", "<a href='javascript:jumps(\"FollowupList.aspx?status=40\")'>DefaultLetter&nbsp;&nbsp;</a>");
				sb.AppendFormat(menuItemString, "c5", "<a href='javascript:jumps(\"FollowupList.aspx?status=50\")'>FinalNotice&nbsp;&nbsp;</a>");
				sb.AppendFormat(menuItemString, "c6", "<a href='javascript:jumps(\"FollowupList.aspx?status=60\")'>Collection&nbsp;&nbsp;</a>");
				sb.AppendFormat(menuItemString, "c7", "<a href='javascript:jumps(\"FollowupList.aspx?status=70\")'>OnHold&nbsp;&nbsp;</a>");
				sb.AppendFormat(menuItemString, "c8", "<a href='javascript:jumps(\"FollowupList.aspx?status=80\")'>AwaitingResult(P9)&nbsp;&nbsp;</a>");
				sb.AppendFormat(menuItemString, "c9", "<a href='javascript:jumps(\"FollowupList.aspx?status=90\")'>AwaitingDividends(P9)</a>");
				sb.AppendFormat(menuItemString, "c10", "<a href='javascript:jumps(\"FollowupList.aspx?status=100\")'>BlackList</a>");
				this.litMenu.Text = sb.ToString();
			}
    	}
    }
}

