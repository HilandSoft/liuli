using System;
using YingNet.Common;
using YingNet.WeiXing.Business;

namespace YingNet.WeiXing.WebApp.manage.AdminManage
{
	/// <summary>
	/// AdminManageBasePage ��ժҪ˵����
	/// </summary>
	public class AdminManageBasePage:ManageBasePage2
	{
		public AdminManageBasePage()
		{

		}
		
		protected override FunnctionModuleEnum FunnctionModuleName
		{
			get
			{
				return FunnctionModuleEnum.ManagerInfo;
			}
			set
			{
				base.FunnctionModuleName = value;
			}
		}

	}
}
