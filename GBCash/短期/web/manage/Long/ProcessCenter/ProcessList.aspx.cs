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

namespace YingNet.WeiXing.WebApp.manage.Long.ProcessCenter
{
	/// <summary>
	/// ProcessList 的摘要说明。
	/// </summary>
	public class ProcessList : ManageBasePage2
	{
		protected System.Web.UI.WebControls.TextBox txKey;
		protected System.Web.UI.WebControls.Label Label1;
		protected System.Web.UI.WebControls.TextBox txCondition;
		protected System.Web.UI.WebControls.Button btnDelete;
		protected YingNet.Common.DataGridTable DataGridTable1;
		protected System.Web.UI.WebControls.CheckBox CheckBox1;
		protected System.Web.UI.WebControls.DropDownList ddlQuery;
		protected System.Web.UI.WebControls.Button btnQuery;
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
		
		
		
		private void btnDelete_Click(object sender, EventArgs e)
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
				this.Page.RegisterStartupScript("", "<script language=javascript>alert('" + num.ToString().Trim() + "items are deleted in total');window.location='ProcessList.aspx';</script>");
			}
		}
		
		
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
					Literal litCustomerNumber= e.Item.FindControl("LitCustomerNumber") as Literal;
					if(litCustomerNumber!=null)
					{
						litCustomerNumber.Text=String.Format("<a target='_blank' href='../../loandetail.aspx?id={0}'>{0}</a>",processCenterDT.UserID); 
					}

					Literal litDocumentCheckList = e.Item.FindControl("litDocumentCheckList") as Literal;
					if(litDocumentCheckList!=null )
					{
						if(processCenterDT.IsFirstLoan==true)
						{
							litDocumentCheckList.Text= Convert.ToString(processCenterDT.DocumentCheckListStatus);
						}
						else
						{
							litDocumentCheckList.Text = Convert.ToString(processCenterDT.DocumentRequiredStatus);
						}
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
						if(processCenterDT.IsFirstLoan == true)
						{
							litOperate.Text = string.Format("<a href='ProcessInfo.aspx?ProcessID={0}'>Edit</a>",rowView["ProcessID"]);
						}
						else
						{
							litOperate.Text = string.Format("<a href='ProcessInfoForNotFirst.aspx?ProcessID={0}'>Edit</a>",rowView["ProcessID"]);
						}
					}
					
					if(processCenterDT.UserID>0)
					{
						LpersonBN huiyuanBN= new LpersonBN(this.Page);
						LpersonDT huiyuanDT = huiyuanBN.Get(processCenterDT.UserID);
						if(huiyuanDT!=null)
						{
							Literal LitUserName = e.Item.FindControl("LitUserName") as Literal;
							if(LitUserName!=null)
							{
								LitUserName.Text = huiyuanDT.Username;
							}
							
							Literal LitFirstName = e.Item.FindControl("LitFirstName") as Literal;
							if(LitFirstName!=null)
							{
								LitFirstName.Text = huiyuanDT.Fname;
							}
							
							Literal LitMiddleName = e.Item.FindControl("LitMiddleName") as Literal;
							if(LitMiddleName!=null)
							{
								LitMiddleName.Text = huiyuanDT.Mname;
							}

							Literal LitLastName= e.Item.FindControl("LitLastName") as Literal;
							if(LitLastName!=null)
							{
								LitLastName.Text= huiyuanDT.Sname;
							}
							
							Literal LitPassword = e.Item.FindControl("LitPassword") as Literal;
							if(LitPassword!=null)
							{
								LitPassword.Text = huiyuanDT.Pwd;
							}
							
							Literal LitDateBirth = e.Item.FindControl("LitDateBirth") as Literal;
							if(LitDateBirth!=null)
							{
								LitDateBirth.Text = huiyuanDT.DBirth;
							}
							
							Literal LitDriverNumber = e.Item.FindControl("LitDriverNumber") as Literal;
							if(LitDriverNumber!=null)
							{
								LitDriverNumber.Text = huiyuanDT.LicNum;
							}
							
							Literal LitRegtime = e.Item.FindControl("LitRegtime") as Literal;
							if(LitRegtime!=null)
							{
								LitRegtime.Text = huiyuanDT.RegTime.ToString("dd-MM-yyyy");
							}

							Literal LitNote= e.Item.FindControl("LitNote") as Literal;
							if(LitNote!=null)
							{
								string noteDisplay= string.Empty;
								if( huiyuanDT.Other1==null||huiyuanDT.Other1==string.Empty)
								{
									noteDisplay= "Empty";
									noteDisplay= string.Format("<a href='../LMemberLoadNotes.aspx?id={0}&from=lp'>{1}</a>",huiyuanDT.sid,noteDisplay);
								}
								else
								{
									noteDisplay= "Attention";
									noteDisplay= string.Format("<a dealed='Attention' href='../LMemberLoadNotes.aspx?id={0}&from=lp'>{1}</a>",huiyuanDT.sid,noteDisplay);
								}

								LitNote.Text= noteDisplay;
							}

							Literal LitFollowUpHistory= e.Item.FindControl("LitFollowUpHistory") as Literal;
							if(LitFollowUpHistory!=null)
							{
								string followupDisplay= string.Empty;
								if(huiyuanDT.Other2==null|| huiyuanDT.Other2==string.Empty)
								{
									followupDisplay= "Empty";
									followupDisplay= string.Format("<a href='../LMemberLoadFollowUpHistory.aspx?id={0}&from=lp'>{1}</a>",huiyuanDT.sid,followupDisplay);
								}
								else
								{
									followupDisplay= "Attention";
									followupDisplay= string.Format("<a dealed='Attention' href='../LMemberLoadFollowUpHistory.aspx?id={0}&from=lp'>{1}</a>",huiyuanDT.sid,followupDisplay);
								}

								LitFollowUpHistory.Text= followupDisplay;
							}
						}
					}
					
					Literal LitIsFirstLoan = e.Item.FindControl("LitIsFirstLoan") as Literal;
					if(LitIsFirstLoan!=null)
					{
						if(processCenterDT.IsFirstLoan==true)
						{
							LitIsFirstLoan.Text= "new";
						}
						else
						{
							LitIsFirstLoan.Text= "member";
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
					if(this.txKey.Text.Trim()==string.Empty)
					{
						conditionString= string.Empty;
					}
					else
					{
						conditionString = string.Format(" UserID={0} ",this.txKey.Text);
					}
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
	}
}
