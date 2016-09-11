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
				sb.AppendFormat(menuItemString, "a0","Home&nbsp;&nbsp;");

				sb.AppendFormat(menuItemString,"b0","Stat&nbsp;&nbsp;");

				sb.AppendFormat(menuItemString, "c0", "Everyday&nbsp;&nbsp;");
				sb.AppendFormat(menuItemString, "c1", "ByDate&nbsp;&nbsp;");
				sb.AppendFormat(menuItemString, "c2", "Scheduled&nbsp;&nbsp;");
				sb.AppendFormat(menuItemString, "c3", "Re-DDed&nbsp;&nbsp;");
				sb.AppendFormat(menuItemString, "c4", "DefaultLetter&nbsp;&nbsp;");
				sb.AppendFormat(menuItemString, "c5", "FinalNotice&nbsp;&nbsp;");
				sb.AppendFormat(menuItemString, "c6", "Collection&nbsp;&nbsp;");
				sb.AppendFormat(menuItemString, "c7", "OnHold&nbsp;&nbsp;");
				sb.AppendFormat(menuItemString, "c8", "AwaitingResult(P9)&nbsp;&nbsp;");
				sb.AppendFormat(menuItemString, "c9", "AwaitingDividends(P9)");
				sb.AppendFormat(menuItemString, "c10", "BlackList");
				this.litMenu.Text = sb.ToString();
			}
    	}
    }
}

