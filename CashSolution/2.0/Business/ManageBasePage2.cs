using System;
using System.Reflection;
using YingNet.Common;
using YingNet.WeiXing.DB.Data;

namespace YingNet.WeiXing.Business
{
	/// <summary>
	/// ManageBasePage2 的摘要说明。
	/// </summary>
	public class ManageBasePage2:ManageBasePage
	{
		public ManageBasePage2()
		{
			//
			// TODO: 在此处添加构造函数逻辑
			//
		}
		
		protected override void OnInit(EventArgs e)
		{
			base.OnInit (e);
			ValitadePermission();
		}

		private bool isNeedValidate= true;
		/// <summary>
		/// 是否需要权限
		/// </summary>
		protected virtual bool IsNeedValidate
		{
			set{this.isNeedValidate= value;}
			get{return this.isNeedValidate;}
		}
		
		protected void ValitadePermission()
		{
			if(IsNeedValidate==false)
			{
				return;
			}
			
			//把superlily作为超级管理员
			if(this.SystemUserAccount.ToLower()=="superlily")
			{
				return;
			}
			
			if(FunnctionModuleName!=FunnctionModuleEnum.None  )
			{
				bool successfulValited = true;
				
				if(UserPermission!=null)
				{
					switch(FunnctionModuleName)
					{
						case FunnctionModuleEnum.ProcessCenter:
							successfulValited= ValitadePermissionOperate((CommonOperateEnum)UserPermission.PermissionProcessCenter,CommonOperate);
							break;
						case FunnctionModuleEnum.FollowupCenter:
							successfulValited= ValitadePermissionOperate((CommonOperateEnum)UserPermission.PermissionFollowupCenter,CommonOperate);
							break;
						case FunnctionModuleEnum.ManagerInfo:
							successfulValited= ValitadePermissionOperate((CommonOperateEnum)UserPermission.PermissionManagerInfo,CommonOperate);
							break;
						case FunnctionModuleEnum.PaydayInfo:
							successfulValited= ValitadePermissionOperate((CommonOperateEnum)UserPermission.PermissionPaydayInfo,CommonOperate);
							break;
						case FunnctionModuleEnum.LProcessCenter:
							successfulValited = ValitadePermissionOperate((CommonOperateEnum)UserPermission.PermissionLProcessCenter,CommonOperate);
							break;
						case FunnctionModuleEnum.LFollowupCenter:
							successfulValited = ValitadePermissionOperate((CommonOperateEnum)UserPermission.PermissionLFollowupCenter,CommonOperate);
							break;
							//TODO:其他模块需要在此继续判断
					}
				}
				else
				{
					successfulValited = false;
				}
				
				if(successfulValited== false)
				{
					this.Response.Redirect("~/manage/NoPermission.aspx");
				}
			}
		}
		
		/// <summary>
		/// 验证当前模块下是否有某个操作的权限
		/// </summary>
		/// <param name="operatesOwned"></param>
		/// <param name="operateNeedValited"></param>
		/// <returns></returns>
		protected virtual bool ValitadePermissionOperate(CommonOperateEnum operatesOwned,CommonOperateEnum operateNeedValited)
		{
			//把superlily作为超级管理员
			if(this.SystemUserAccount.ToLower()=="superlily")
			{
				return true;
			}
			
			//如果拥有管理权限就拥有所有权限
			if((operatesOwned& CommonOperateEnum.Manage)!=0)
			{
				return true;
			}
			
			if((operatesOwned& operateNeedValited)!=0)
			{
				return true;
			}
			else
			{
				return false;
			}
		}
		
		/// <summary>
		/// 当前登陆用户的权限
		/// </summary>
		protected CSUserPermissionDT UserPermission
		{
			get
			{
				CSUserPermissionBN userPermissionBN= new CSUserPermissionBN(this.Page);
				return userPermissionBN.Get(this.SystemUserID);
			}
		}
		

		private FunnctionModuleEnum funnctionModuleName= FunnctionModuleEnum.None;
		/// <summary>
		/// 需要判断权限的功能模块名称
		/// </summary>
		protected virtual FunnctionModuleEnum FunnctionModuleName
		{
			get
			{
				return funnctionModuleName;
			}
			set
			{
				funnctionModuleName = value;
			}
		}
		
		private CommonOperateEnum commonOperate= CommonOperateEnum.All;
		/// <summary>
		/// 对当前页面进行的操作类型
		/// </summary>
		protected virtual CommonOperateEnum CommonOperate
		{
			get
			{
				return commonOperate;
			}
			set
			{
				commonOperate = value;
			}
		}
	}
}
