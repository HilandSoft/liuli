using System;
using System.Data;
using System.Web.UI.WebControls;
using YingNet.Common;
using YingNet.WeiXing.Business;
using YingNet.WeiXing.DB.Data;

namespace YingNet.WeiXing.WebApp.manage.AdminManage
{
	/// <summary>
	/// PermissionInfo 的摘要说明。
	/// </summary>
	public class PermissionInfo : ManageBasePage2
	{
		protected System.Web.UI.WebControls.Label labUserName;
		protected System.Web.UI.HtmlControls.HtmlInputButton Add;
		protected YingNet.Common.PermissionCheckBoxList cblManagerInfo;
		protected YingNet.Common.PermissionCheckBoxList cblPaydayInfo;
		
		protected YingNet.Common.PermissionCheckBoxList cblProcessCenter;
		protected YingNet.Common.PermissionCheckBoxList cblLProcessCenter;
		
		protected YingNet.Common.PermissionCheckBoxList cblFollowupCenter;
		protected YingNet.Common.PermissionCheckBoxList cblLFollowupCenter;
		
		private int currentDualedUserID= 0;
	
		/// <summary>
		/// 功能模块名称
		/// </summary>
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
		
		/// <summary>
		/// 功能操作
		/// </summary>
		protected override CommonOperateEnum CommonOperate
		{
			get
			{
				return CommonOperateEnum.CreateEdit;
			}
			set
			{
				base.CommonOperate = value;
			}
		}
		
		private void Page_Load(object sender, System.EventArgs e)
		{
			try
			{
				currentDualedUserID = Convert.ToInt32(this.Request.QueryString["userID"]);
			}
			catch
			{
			}
			
			if(this.IsPostBack==false)
			{
				this.LoadUserInfo();
			}
		}
		
		private void LoadUserInfo()
		{
			if(this.currentDualedUserID>0)
			{
				CSUserBN userBN= new CSUserBN(this.Page);
				CSUserDT userDT = userBN.Get(this.currentDualedUserID);
				if(userDT!=null)
				{
					this.labUserName.Text = userDT.UserName;
					
					CSUserPermissionBN permissionBN= new CSUserPermissionBN(this.Page);
					CSUserPermissionDT permissionDT = permissionBN.Get(this.currentDualedUserID);
					if(permissionDT==null || permissionDT.UserID<0)
					{
						//Do Nothing;
					}
					else
					{
						CommonOperateEnum commonOperateProcessCenter = (CommonOperateEnum) permissionDT.PermissionProcessCenter;
						LoadUserModulePermission(commonOperateProcessCenter,this.cblProcessCenter);
						
						CommonOperateEnum commonOperateLProcessCenter = (CommonOperateEnum) permissionDT.PermissionLProcessCenter;
						LoadUserModulePermission(commonOperateLProcessCenter,this.cblLProcessCenter);
						
						
						CommonOperateEnum commonOperateFollowupCenter = (CommonOperateEnum) permissionDT.PermissionFollowupCenter;
						LoadUserModulePermission(commonOperateFollowupCenter,this.cblFollowupCenter);
						
						CommonOperateEnum commonOperateLFollowupCenter = (CommonOperateEnum) permissionDT.PermissionLFollowupCenter;
						LoadUserModulePermission(commonOperateLFollowupCenter,this.cblLFollowupCenter);
						
						
						CommonOperateEnum commonOperatePaydayInfo = (CommonOperateEnum) permissionDT.PermissionPaydayInfo;
						LoadUserModulePermission(commonOperatePaydayInfo,this.cblPaydayInfo);
						
						CommonOperateEnum commonOperateManagerInfo = (CommonOperateEnum) permissionDT.PermissionManagerInfo;
						LoadUserModulePermission(commonOperateManagerInfo,this.cblManagerInfo);
					}
				}
			}
		}
		
		/// <summary>
		/// 载入原来某个模块的权限
		/// </summary>
		private void LoadUserModulePermission(CommonOperateEnum commonOperate,PermissionCheckBoxList permissionCheckBoxList)
		{
			if((commonOperate& CommonOperateEnum.ReadOnly)!=0)
			{
				ListItem item = permissionCheckBoxList.Items.FindByValue(((int)CommonOperateEnum.ReadOnly).ToString());
				if(item!=null)
				{
					item.Selected = true;
				}
			}
			
			if((commonOperate& CommonOperateEnum.CreateEdit)!=0)
			{
				ListItem item = permissionCheckBoxList.Items.FindByValue(((int)CommonOperateEnum.CreateEdit).ToString());
				if(item!=null)
				{
					item.Selected = true;
				}
			}
			
			if((commonOperate& CommonOperateEnum.List)!=0)
			{
				ListItem item = permissionCheckBoxList.Items.FindByValue(((int)CommonOperateEnum.List).ToString());
				if(item!=null)
				{
					item.Selected = true;
				}
			}
			
			if((commonOperate& CommonOperateEnum.Delete)!=0)
			{
				ListItem item = permissionCheckBoxList.Items.FindByValue(((int)CommonOperateEnum.Delete).ToString());
				if(item!=null)
				{
					item.Selected = true;
				}
			}
			
			if((commonOperate& CommonOperateEnum.Manage)!=0)
			{
				ListItem item = permissionCheckBoxList.Items.FindByValue(((int)CommonOperateEnum.Manage).ToString());
				if(item!=null)
				{
					item.Selected = true;
				}
			}
			
			//以下处理ProcessCenter中的情形
			if((commonOperate& CommonOperateEnum.DocumentCheckList)!=0)
			{
				ListItem item = permissionCheckBoxList.Items.FindByValue(((int)CommonOperateEnum.DocumentCheckList).ToString());
				if(item!=null)
				{
					item.Selected = true;
				}
			}
			
			if((commonOperate& CommonOperateEnum.DetailsVerification)!=0)
			{
				ListItem item = permissionCheckBoxList.Items.FindByValue(((int)CommonOperateEnum.DetailsVerification).ToString());
				if(item!=null)
				{
					item.Selected = true;
				}
			}
			
			if((commonOperate& CommonOperateEnum.PreApproval)!=0)
			{
				ListItem item = permissionCheckBoxList.Items.FindByValue(((int)CommonOperateEnum.PreApproval).ToString());
				if(item!=null)
				{
					item.Selected = true;
				}
			}
			
			if((commonOperate& CommonOperateEnum.FinalApproval)!=0)
			{
				ListItem item = permissionCheckBoxList.Items.FindByValue(((int)CommonOperateEnum.FinalApproval).ToString());
				if(item!=null)
				{
					item.Selected = true;
				}
			}
		}

		#region Web 窗体设计器生成的代码
		override protected void OnInit(EventArgs e)
		{
			//
			// CODEGEN: 该调用是 ASP.NET Web 窗体设计器所必需的。
			//
			InitializeComponent();
			base.OnInit(e);
		}
		
		/// <summary>
		/// 设计器支持所需的方法 - 不要使用代码编辑器修改
		/// 此方法的内容。
		/// </summary>
		private void InitializeComponent()
		{    
			this.Add.ServerClick += new System.EventHandler(this.Add_ServerClick);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		private void Add_ServerClick(object sender, System.EventArgs e)
		{
			bool isNewPermission = false;
			int permissionProcessCenter = 0;
			for(int i=0;i<this.cblProcessCenter.Items.Count;i++)
			{
				if(this.cblProcessCenter.Items[i].Selected==true)
				{
					permissionProcessCenter += Convert.ToInt32(this.cblProcessCenter.Items[i].Value);
				}
			}
			
			int permissionLProcessCenter = 0;
			for(int i=0;i<this.cblLProcessCenter.Items.Count;i++)
			{
				if(this.cblLProcessCenter.Items[i].Selected==true)
				{
					permissionLProcessCenter += Convert.ToInt32(this.cblLProcessCenter.Items[i].Value);
				}
			}
			
			
			
			int permissionFollowupCenter = 0;
			for(int i=0;i<this.cblFollowupCenter.Items.Count;i++)
			{
				if(this.cblFollowupCenter.Items[i].Selected==true)
				{
					permissionFollowupCenter += Convert.ToInt32(this.cblFollowupCenter.Items[i].Value);
				}
			}
			
			int permissionLFollowupCenter = 0;
			for(int i=0;i<this.cblLFollowupCenter.Items.Count;i++)
			{
				if(this.cblLFollowupCenter.Items[i].Selected==true)
				{
					permissionLFollowupCenter += Convert.ToInt32(this.cblLFollowupCenter.Items[i].Value);
				}
			}
			
			
			int permissionManagerInfo = 0;
			for(int i=0;i<this.cblManagerInfo.Items.Count;i++)
			{
				if(this.cblManagerInfo.Items[i].Selected==true)
				{
					permissionManagerInfo += Convert.ToInt32(this.cblManagerInfo.Items[i].Value);
				}
			}
			
			int permissionPaydayInfo = 0;
			for(int i=0;i<this.cblPaydayInfo.Items.Count;i++)
			{
				if(this.cblPaydayInfo.Items[i].Selected==true)
				{
					permissionPaydayInfo += Convert.ToInt32(this.cblPaydayInfo.Items[i].Value);
				}
			}
			
			CSUserPermissionBN permissionBN= new CSUserPermissionBN(this.Page);
			CSUserPermissionDT permissionDT = permissionBN.Get(this.currentDualedUserID);
			if(permissionDT==null || permissionDT.UserID<0)
			{
				isNewPermission = true;
				permissionDT= new CSUserPermissionDT();
			}
			permissionDT.UserID = this.currentDualedUserID;
			
			
			permissionDT.PermissionProcessCenter = permissionProcessCenter;
			permissionDT.PermissionLProcessCenter = permissionLProcessCenter;
			
			permissionDT.PermissionFollowupCenter = permissionFollowupCenter;
			permissionDT.PermissionLFollowupCenter = permissionLFollowupCenter;
			
			permissionDT.PermissionPaydayInfo = permissionPaydayInfo;
			permissionDT.PermissionManagerInfo = permissionManagerInfo;
			
			
			
			if(isNewPermission==true)
			{
				permissionBN.Add(permissionDT);
			}
			else
			{
				permissionBN.Edit(permissionDT);
			}
			
			this.Response.Redirect("AdminList.aspx");
		}
	}
}
