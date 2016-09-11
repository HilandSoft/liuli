using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Web;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using YingNet.Common;
using YingNet.WeiXing.Business;
using YingNet.WeiXing.DB.Data;
using YingNet.WeiXing.STRUCTURE;

namespace YingNet.WeiXing.WebApp.manage.Long
{
	/// <summary>
	/// LProcessList 的摘要说明。
	/// </summary>
	public class LProcessList : ManageBasePage2
	{
		protected System.Web.UI.WebControls.DropDownList ddlQuery;
		protected System.Web.UI.WebControls.TextBox txKey;
		protected System.Web.UI.WebControls.Button btnQuery;
		protected System.Web.UI.WebControls.Label Label1;
		protected System.Web.UI.WebControls.TextBox txCondition;
		protected System.Web.UI.WebControls.Button btnDelete;
		protected YingNet.Common.DataGridTable DataGridTable1;
		protected System.Web.UI.WebControls.CheckBox CheckBox1;
		protected System.Web.UI.WebControls.TextBox txtParamstr;
		
		protected override FunnctionModuleEnum FunnctionModuleName
		{
			get
			{
				return FunnctionModuleEnum.LProcessCenter;
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
				this.BindQueryInfo();
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
			this.btnQuery.Click += new System.EventHandler(this.btnQuery_Click);
			this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
			this.DataGridTable1.PageIndexChanged += new System.Web.UI.WebControls.DataGridPageChangedEventHandler(this.DataGridTable1_PageIndexChanged);
			this.DataGridTable1.DataBinding += new System.EventHandler(this.DataGridTable1_DataBinding);
			this.DataGridTable1.ItemDataBound += new System.Web.UI.WebControls.DataGridItemEventHandler(this.DataGridTable1_ItemDataBound);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion
		
		private void DataGridTable1_DataBinding(object sender, EventArgs e)
		{
			CSProcessCenterBN processCenterBN = new CSProcessCenterBN(this.Page);
			
			DataTable dt=null;
			processCenterBN.CleanStatus();
			processCenterBN.Filter = string.Format(" UserLoanType={0} ",(int)UserLoanTypes.Long);
			if(this.txCondition.Text!=string.Empty)
			{
				processCenterBN.Filter = this.txCondition.Text;
			}
			dt = processCenterBN.GetList();
			CommonBasePage.SetPage(this.DataGridTable1, dt);
			base.AddValue("pageno", Convert.ToString((int) (this.DataGridTable1.CurrentPageIndex + 1)));
			this.txtParamstr.Text = base.PackPart(base.ParamValue);
		}
		
		private void DataGridTable1_ItemDataBound(object sender, DataGridItemEventArgs e)
		{
			if (e.Item.ItemIndex < 0)
			{
				return;
			}
			
			if(e.Item.ItemType== ListItemType.Item|| e.Item.ItemType== ListItemType.AlternatingItem||e.Item.ItemType== ListItemType.SelectedItem)
			{
				DataRowView rowView= (DataRowView)e.Item.DataItem;
				CSProcessCenterDT processCenterDT = null;
				if(rowView==null)
				{
					return;
				}
				else
				{
					processCenterDT = new CSProcessCenterBN(this.Page).Get(Convert.ToInt32(rowView["ProcessID"]));
				}
				
				if(processCenterDT!=null)
				{
					Literal litDocumentCheckList = e.Item.FindControl("litDocumentCheckList") as Literal;
					if(litDocumentCheckList!=null )
					{
						litDocumentCheckList.Text= Convert.ToString(processCenterDT.DocumentCheckListStatus);
					}
				
					Literal litDetailVerification = e.Item.FindControl("litDetailVerification") as Literal;
					if(litDetailVerification!=null)
					{
						litDetailVerification.Text = Convert.ToString(processCenterDT.DetailsVerificationStatus);
					}
					
					Literal litStatus = e.Item.FindControl("litStatus") as Literal;
					if(litStatus!=null)
					{
						litStatus.Text = Convert.ToString(processCenterDT.ProcessStatus);
					}
				
					Literal litOperate = e.Item.FindControl("litOperate") as Literal;
					if(litOperate!=null)
					{
						litOperate.Text = string.Format("<a href='LProcessInfo.aspx?ProcessID={0}'>Edit</a>",rowView["ProcessID"]);
					}
					
					Literal LitUserName = e.Item.FindControl("LitUserName") as Literal;
					if(LitUserName!=null&& processCenterDT.UserID>0)
					{
						LpersonBN personBN= new LpersonBN(this.Page);
						LpersonDT personDT = personBN.Get(processCenterDT.UserID);
						if(personDT!=null)
						{
							LitUserName.Text = string.Format("{0} {1}",personDT.Sname,personDT.Fname);
						}
					}
				}
			}
		}
		
		private void DataGridTable1_PageIndexChanged(object source, DataGridPageChangedEventArgs e)
		{
			this.DataGridTable1.CurrentPageIndex = e.NewPageIndex;
			this.DataGridTable1.DataBind();
		}

		/// <summary>
		/// 绑定查询条件
		/// </summary>
		private void BindQueryInfo()
		{
			ListItem itemSelect= new ListItem("PleaseSelect","PleaseSelect");
			this.ddlQuery.Items.Add(itemSelect);
			
			ListItem itemMemberID= new ListItem("MemberID","MemberID");
			this.ddlQuery.Items.Add(itemMemberID);
			
			ListItem itemPending= new ListItem(ProcessCenterStatusEnum.Pending.ToString(),"Pending");
			this.ddlQuery.Items.Add(itemPending);
			
			ListItem itemDetailVerified= new ListItem(ProcessCenterStatusEnum.DetailVerified.ToString(),"DetailVerified");
			this.ddlQuery.Items.Add(itemDetailVerified);
			
			ListItem itemPreApproval= new ListItem(ProcessCenterStatusEnum.PreApproval.ToString(),"PreApproval");
			this.ddlQuery.Items.Add(itemPreApproval);
			
			ListItem itemPreApproved= new ListItem(ProcessCenterStatusEnum.PreApproved.ToString(),"PreApproved");
			this.ddlQuery.Items.Add(itemPreApproved);
			
			ListItem itemFinalApproval= new ListItem(ProcessCenterStatusEnum.FinalApproval.ToString(),"FinalApproval");
			this.ddlQuery.Items.Add(itemFinalApproval);
		}

		private void btnQuery_Click(object sender, System.EventArgs e)
		{
			string conditionString = string.Empty;

			string selectedValue = this.ddlQuery.SelectedValue;
			switch(selectedValue)
			{
				case "PleaseSelect":
					conditionString = string.Empty;
					break;
				case "MemberID":
					conditionString = string.Format(" UserID={0} ",this.txKey.Text);
					break;
				case "Pending":
					conditionString = String.Format(" ProcessStatus={0} ", Convert.ToInt32(ProcessCenterStatusEnum.Pending));
					break;
				case "DetailVerified":
					conditionString = String.Format(" ProcessStatus={0} ", Convert.ToInt32(ProcessCenterStatusEnum.DetailVerified));
					break;
				case "PreApproval":
					conditionString = String.Format(" ProcessStatus={0} ", Convert.ToInt32(ProcessCenterStatusEnum.PreApproval));
					break;
				case "PreApproved":
					conditionString = String.Format(" ProcessStatus={0} ", Convert.ToInt32(ProcessCenterStatusEnum.PreApproved));
					break;
				case "FinalApproval":
					conditionString = String.Format(" ProcessStatus={0} ", Convert.ToInt32(ProcessCenterStatusEnum.FinalApproval));
					break;
			}
			
			this.txCondition.Text = conditionString;
			this.DataGridTable1.DataBind();
		}

		private void btnDelete_Click(object sender, System.EventArgs e)
		{
			string[] strArray = DataGridUtils.getID(this.DataGridTable1);
			if (strArray != null)
			{
				int num = 0;
				CSProcessCenterBN business = new CSProcessCenterBN(this.Page);
				for (int i = 0; i < strArray.Length; i++)
				{
					int id = Convert.ToInt32(strArray[i]);
					if (business.Del(id))
					{
						num++;
					}
				}
				this.Page.RegisterStartupScript("", "<script language=javascript>alert('" + num.ToString().Trim() + "items are deleted in total');window.location='LProcessList.aspx';</script>");
			}
		}
	}
}
