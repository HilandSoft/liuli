using System;
using System.Data;
using System.Web.UI.WebControls;
using YingNet.Common;
using YingNet.WeiXing.Business;
using YingNet.WeiXing.DB.Data;

namespace YingNet.WeiXing.WebApp.manage.AdminManage
{
	/// <summary>
	/// AdminList 的摘要说明。
	/// </summary>
	public class AdminList : ManageBasePage2
	{
		protected System.Web.UI.WebControls.Label Label1;
		protected System.Web.UI.WebControls.TextBox txCondition;
		protected System.Web.UI.WebControls.Button btnDelete;
		protected System.Web.UI.WebControls.CheckBox chkID;
		protected System.Web.UI.WebControls.CheckBox CheckBox1;
		protected YingNet.Common.DataGridTable DataGridTable1;
		protected System.Web.UI.WebControls.HyperLink hyCreate;
		protected System.Web.UI.WebControls.TextBox txtParamstr;
		
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
			this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
			this.DataGridTable1.PageIndexChanged += new System.Web.UI.WebControls.DataGridPageChangedEventHandler(this.DataGridTable1_PageIndexChanged);
			this.DataGridTable1.DataBinding += new System.EventHandler(this.DataGridTable1_DataBinding);
			this.DataGridTable1.ItemDataBound += new System.Web.UI.WebControls.DataGridItemEventHandler(this.DataGridTable1_ItemDataBound);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion
	
		
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
		
		protected override CommonOperateEnum CommonOperate
		{
			get
			{
				return CommonOperateEnum.List;
			}
			set
			{
				base.CommonOperate = value;
			}
		}

		
		private void Page_Load(object sender, System.EventArgs e)
		{
			if (!base.IsPostBack)
			{
				this.btnDelete.Text = "Delete";
				this.btnDelete.Attributes["onclick"] = "return deleteit(this.form)";
				this.txtParamstr.Text = base.PackPart(base.ParamValue);
				string str = base.GetValue("pageno");
				if (str != null)
				{
					this.DataGridTable1.CurrentPageIndex = Convert.ToInt32(str) - 1;
				}
				this.DataGridTable1.DataBind();
			}
			else
			{
				base.ParamValue = base.UnPackPart(this.txtParamstr.Text);
			}
		}
		

		private void btnDelete_Click(object sender, EventArgs e)
		{
			string[] strArray = DataGridUtils.getID(this.DataGridTable1);
			if (strArray != null)
			{
				int num = 0;
				CSUserBN nbn = new CSUserBN(this.Page);
				for (int i = 0; i < strArray.Length; i++)
				{
					int id = Convert.ToInt32(strArray[i]);
					if (nbn.Del(id))
					{
						num++;
					}
				}
				this.Page.RegisterStartupScript("", "<script language=javascript>alert('" + num.ToString().Trim() + "items are deleted in total');window.location='AdminList.aspx';</script>");
			}
		}
		
		private void DataGridTable1_DataBinding(object sender, EventArgs e)
		{
			CSUserBN userBN = new CSUserBN(this.Page);
			
			DataTable dt=null;
			dt = userBN.GetList();
			CommonBasePage.SetPage(this.DataGridTable1, dt);
			base.AddValue("pageno", Convert.ToString((int) (this.DataGridTable1.CurrentPageIndex + 1)));
			this.txtParamstr.Text = base.PackPart(base.ParamValue);
		}
		
		private void DataGridTable1_ItemDataBound(object sender, DataGridItemEventArgs e)
		{
			if (e.Item.ItemIndex <= -1)
			{
				return;
			}
			
			if(e.Item.ItemType== ListItemType.Item|| e.Item.ItemType== ListItemType.AlternatingItem||e.Item.ItemType== ListItemType.SelectedItem)
			{
				DataRowView rowView= (DataRowView)e.Item.DataItem;
				if(rowView==null)
				{
					return;
				}
				
				Literal litEnable = e.Item.FindControl("litEnable") as Literal;
				if(litEnable!=null)
				{
					int tempEnable = 1;
					try
					{
						tempEnable= Convert.ToInt32(rowView["Enable"]);
					}
					catch
					{
					}
					
					if(tempEnable==1)
					{
						litEnable.Text = "True";
					}
					else
					{
						litEnable.Text = "False";
					}
				}
				
				Literal litLastLoginDate = e.Item.FindControl("litLastLoginDate") as Literal;
				if(litLastLoginDate!=null)
				{
					DateTime tempLastLoginDate = new DateTime(1753,1,2);
					try
					{
						tempLastLoginDate = Convert.ToDateTime(rowView["LastLoginDate"]);
					}
					catch
					{
					}
					
					if(tempLastLoginDate<new DateTime(1753,1,3))
					{
						litLastLoginDate.Text = "Never Logined";
					}
					else
					{
						litLastLoginDate.Text = tempLastLoginDate.ToString("dd-MM-yyyy hh:mm");
					}
				}
				
				Literal litOperate = e.Item.FindControl("litOperate") as Literal;
				if(litOperate!=null)
				{
					litOperate.Text = string.Format("<a href='AdminInfo.aspx?userID={0}'>Edit</a>",rowView["userID"]);
					litOperate.Text += string.Format(" <a href='PermissionInfo.aspx?userID={0}'>Permission</a>",rowView["userID"]);
				}
			}
		}
		
		private void DataGridTable1_PageIndexChanged(object source, DataGridPageChangedEventArgs e)
		{
			this.DataGridTable1.CurrentPageIndex = e.NewPageIndex;
			this.DataGridTable1.DataBind();
		}
	}
}
