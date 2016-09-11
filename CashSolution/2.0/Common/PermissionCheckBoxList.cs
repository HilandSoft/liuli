using System;
using System.Web.UI.WebControls;


namespace YingNet.Common
{
	/// <summary>
	/// PermissionCheckBoxList 的摘要说明。
	/// </summary>
	public class PermissionCheckBoxList:CheckBoxList
	{
		public PermissionCheckBoxList()
		{
			
		}
		
		protected override void OnInit(EventArgs e)
		{
			//if(this.Page.IsPostBack==false)
			{
				this.AddItems();
			}
			base.OnInit (e);
		}

		
		private void AddItems()
		{
			this.Items.Clear();
			ListItem itemList= new ListItem("List",Convert.ToInt32(CommonOperateEnum.List).ToString());
			ListItem itemReadOnly= new ListItem("ReadOnly",Convert.ToInt32(CommonOperateEnum.ReadOnly).ToString());
			ListItem itemCreateEdit= new ListItem("Create/Edit",Convert.ToInt32(CommonOperateEnum.CreateEdit).ToString());
			ListItem itemDelete= new ListItem("Delete",Convert.ToInt32(CommonOperateEnum.Delete).ToString());
			ListItem itemManage= new ListItem("Manage",Convert.ToInt32(CommonOperateEnum.Manage).ToString());
			//ListItem itemAll= new ListItem("All",Convert.ToInt32(CommonOperateEnum.All).ToString());
			this.Items.Add(itemList);
			this.Items.Add(itemReadOnly);
			this.Items.Add(itemCreateEdit);
			this.Items.Add(itemDelete);
			this.Items.Add(itemManage);
			//this.Items.Add(itemAll);
			
			if(this.IsDisplayProcessCenterItems)
			{
				ListItem itemDocumentCheckList = new ListItem("DocumentCheckList",Convert.ToInt32(CommonOperateEnum.DocumentCheckList).ToString());
				this.Items.Add(itemDocumentCheckList);
				
				ListItem itemPreApproval = new ListItem("PreApproval",Convert.ToInt32(CommonOperateEnum.PreApproval).ToString());
				this.Items.Add(itemPreApproval);
				
				ListItem itemDetailsVerification = new ListItem("DetailsVerification",Convert.ToInt32(CommonOperateEnum.DetailsVerification).ToString());
				this.Items.Add(itemDetailsVerification);
				
				ListItem itemFinalApproval = new ListItem("FinalApproval",Convert.ToInt32(CommonOperateEnum.FinalApproval).ToString());
				this.Items.Add(itemFinalApproval);
			}
		}
		
		
		private bool isDisplayProcessCenterItems= false;
		/// <summary>
		/// 是否显示ProcessCenter的选项
		/// </summary>
		public bool IsDisplayProcessCenterItems
		{
			get
			{
				return isDisplayProcessCenterItems;
			}
			set
			{	
				isDisplayProcessCenterItems = value;
			}
		}
		
	}
}
