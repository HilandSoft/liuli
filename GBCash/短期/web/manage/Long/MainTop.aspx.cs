using System.Text;
using System.Web.UI.WebControls;
using YingNet.WeiXing.Business;
using YingNet.WeiXing.Business.CommonLogic;

namespace YingNet.WeiXing.WebApp.manage.Long
{
    using System;
    using System.Web.UI;

    public class MainTop : ManageBasePage
    {
		protected Literal litLogUserAccount;
    	protected Literal litMenu;
	
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

				if(CommonInformation.CurrentVersion >2)
				{
					sb.AppendFormat(menuItemString, "b2", "<a href='javascript:jumps(\"LProcessList.aspx\")'> ProcessCenter </a>");
					//TODO:FollowUpCenter需要处理
					//sb.AppendFormat(menuItemString, "b3", "FollowupCenter");
				}
				
				sb.AppendFormat(menuItemString, "a10","<a href='javascript:jumps(\"renew.aspx\")'> Member Renew </a>");
				sb.AppendFormat(menuItemString, "a11","<a href='javascript:jumps(\"LongList.aspx\")'> Long Term </a>");
				sb.AppendFormat(menuItemString, "a12","<a href='javascript:jumps(\"ParamsSet.aspx\")'> Long Term Set </a>");
				this.litMenu.Text = sb.ToString();
			}
		}
	
    }
}

