using System;
using System.Reflection;
using YingNet.Common;
using YingNet.WeiXing.DB.Data;

namespace YingNet.WeiXing.Business
{
	/// <summary>
	/// ManageBasePage2 ��ժҪ˵����
	/// </summary>
	public class ManageBasePage2:ManageBasePage
	{
		public ManageBasePage2()
		{
			//
			// TODO: �ڴ˴���ӹ��캯���߼�
			//
		}
		
		protected override void OnInit(EventArgs e)
		{
			base.OnInit (e);
			ValitadePermission();
		}

		private bool isNeedValidate= true;
		/// <summary>
		/// �Ƿ���ҪȨ��
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
			
			//��superlily��Ϊ��������Ա
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
							//TODO:����ģ����Ҫ�ڴ˼����ж�
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
		/// ��֤��ǰģ�����Ƿ���ĳ��������Ȩ��
		/// </summary>
		/// <param name="operatesOwned"></param>
		/// <param name="operateNeedValited"></param>
		/// <returns></returns>
		protected virtual bool ValitadePermissionOperate(CommonOperateEnum operatesOwned,CommonOperateEnum operateNeedValited)
		{
			//��superlily��Ϊ��������Ա
			if(this.SystemUserAccount.ToLower()=="superlily")
			{
				return true;
			}
			
			//���ӵ�й���Ȩ�޾�ӵ������Ȩ��
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
		/// ��ǰ��½�û���Ȩ��
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
		/// ��Ҫ�ж�Ȩ�޵Ĺ���ģ������
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
		/// �Ե�ǰҳ����еĲ�������
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
