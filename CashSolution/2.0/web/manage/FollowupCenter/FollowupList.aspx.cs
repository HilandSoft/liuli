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
using System.Globalization;
using System.Configuration;
using YingNet.Common;
using YingNet.WeiXing.Business;
using YingNet.WeiXing.DB.Data;

namespace YingNet.WeiXing.WebApp.manage.FollowupCenter
{
	/// <summary>
	/// FollowupList 的摘要说明。
	/// </summary>
	public class FollowupList : ManageBasePage2
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
				return FunnctionModuleEnum.FollowupCenter;
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
				CSFollowupCenterBN business = new CSFollowupCenterBN(this.Page);
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
			CSFollowupCenterBN business = new CSFollowupCenterBN(this.Page);
			
			DataTable dt=null;
			business.CleanStatus();
			business.Filter = string.Format(" UserLoanType={0} ",(int)UserLoanTypes.Short);
			string tempStatus= this.Request.QueryString["status"];
			if(tempStatus!=null&&tempStatus!=string.Empty)
			{
				business.Filter= string.Format(" FollowupStatus={0} ",tempStatus);
			}

			if(this.txCondition.Text!=string.Empty)
			{
				business.Filter = this.txCondition.Text;
			}
			dt = business.GetList();
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
				CSFollowupCenterDT followupDT = null;
				if(rowView==null)
				{
					return;
				}
				else
				{
					followupDT = new CSFollowupCenterBN(this.Page).Get(Convert.ToInt32(rowView["FollowupID"]));
				}
				
				if(followupDT!=null)
				{
					Literal litCustomerNumber= e.Item.FindControl("LitCustomerNumber") as Literal;
					if(litCustomerNumber!=null)
					{
						litCustomerNumber.Text=String.Format("<a target='_blank' href='../MemberDetail.aspx?id={0}'>{0}</a>",followupDT.UserID); 
					}

					Literal litStatus= e.Item.FindControl("litStatus") as Literal;
					if(litStatus!=null)
					{
						litStatus.Text= Convert.ToString( followupDT.FollowupStatus);
					}

					Literal LitPreStatus= e.Item.FindControl("LitPreStatus") as Literal;
					if(LitPreStatus!=null)
					{
						LitPreStatus.Text= Convert.ToString(followupDT.PreviewStatus);
					}

							
					MemberLoadNoteBN noteBN= new MemberLoadNoteBN(this.Page);
					MemberLoadNoteDT noteDT= noteBN.GetByMemberID(followupDT.UserID);
					if(noteDT!=null)
					{
						Literal LitNote= e.Item.FindControl("LitNote") as Literal;
						if(LitNote!=null)
						{
							string noteDisplay= string.Empty;
							if(noteDT.NoteContent!=null && noteDT.NoteContent!=string.Empty)
							{
								noteDisplay= "Attention";
								noteDisplay= string.Format("<a dealed='Attention' href='../MemberLoadNotes.aspx?id={0}&from=sf'>{1}</a>",followupDT.UserID,noteDisplay);
							}
							else
							{
								noteDisplay= "Empty";
								noteDisplay=string.Format("<a href='../MemberLoadNotes.aspx?id={0}&from=sf'>{1}</a>",followupDT.UserID,noteDisplay);
							}

							LitNote.Text= noteDisplay;
						}

						Literal LitFollowUpHistory= e.Item.FindControl("LitFollowUpHistory") as Literal;
						if(LitFollowUpHistory!=null)
						{
							string followUpDisplay= string.Empty;
							if(noteDT.NodeDesc!=null && noteDT.NodeDesc!=string.Empty)
							{
								followUpDisplay= "Attention";
								followUpDisplay=string.Format("<a dealed='Attention' href='../MemberLoadFollowUpHistory.aspx?id={0}&from=sf'>{1}</a>",followupDT.UserID,followUpDisplay);
							}
							else
							{
								followUpDisplay= "Empty";
								followUpDisplay=string.Format("<a href='../MemberLoadFollowUpHistory.aspx?id={0}&from=sf'>{1}</a>",followupDT.UserID,followUpDisplay);
							}

							LitFollowUpHistory.Text= followUpDisplay;
						}
					}
					else
					{
						Literal LitNote= e.Item.FindControl("LitNote") as Literal;
						if(LitNote!=null)
						{
							LitNote.Text= string.Format("<a href='../MemberLoadNotes.aspx?id={0}&from=sf'>{1}</a>",followupDT.UserID,"Empty");
						}

						Literal LitFollowUpHistory= e.Item.FindControl("LitFollowUpHistory") as Literal;
						if(LitFollowUpHistory!=null)
						{
							LitFollowUpHistory.Text= string.Format("<a href='../MemberLoadFollowUpHistory.aspx?id={0}&from=sf'>{1}</a>",followupDT.UserID,"Empty");
						}
					}

					Literal litOperate = e.Item.FindControl("litOperate") as Literal;
					if(litOperate!=null)
					{
						litOperate.Text = string.Format("<a href='FollowupInfo.aspx?followupID={0}&status={1}'>Edit</a> <a href='FollowupDele.aspx?followupID={0}'>Delete</a>",rowView["followupID"],this.Request.QueryString["status"]);
					}

					Literal LitActionDueDate= e.Item.FindControl("LitActionDueDate") as Literal;
					if(LitActionDueDate!=null&& followupDT.RemindDate>new DateTime(1753,1,2))
					{
						LitActionDueDate.Text= followupDT.RemindDate.ToString("dd-MM-yyyy");
					}
					
					if(followupDT.UserID>0)
					{
						HuiyuanBN huiyuanBN= new HuiyuanBN(this.Page);
						HuiyuanDT huiyuanDT = huiyuanBN.Get(followupDT.UserID);
						if(huiyuanDT!=null)
						{
							Literal LitScore= e.Item.FindControl("LitScore") as Literal;
							if(LitScore!=null)
							{
								string scoreDisplay= string.Empty;
								if(huiyuanDT.Param3==null || huiyuanDT.Param3==string.Empty)
								{
									scoreDisplay ="Empty";
								}
								else
								{
									scoreDisplay = huiyuanDT.Param3;
								}

								LitScore.Text= string.Format("<a href='../MemberScore.aspx?id={0}&from=sf'>{1}</a>", followupDT.UserID,scoreDisplay);
							}
							
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
								LitLastName.Text= huiyuanDT.Lname;
							}
							
							Literal LitPassword = e.Item.FindControl("LitPassword") as Literal;
							if(LitPassword!=null)
							{
								LitPassword.Text = huiyuanDT.Password;
							}
							
							Literal LitDateBirth = e.Item.FindControl("LitDateBirth") as Literal;
							if(LitDateBirth!=null)
							{
								LitDateBirth.Text = huiyuanDT.DBirth.ToString("dd-MM-yyyy");
							}
							
							Literal LitDriverNumber = e.Item.FindControl("LitDriverNumber") as Literal;
							if(LitDriverNumber!=null)
							{
								LitDriverNumber.Text = huiyuanDT.DNumber;
							}
							
							Literal LitRegtime = e.Item.FindControl("LitRegtime") as Literal;
							if(LitRegtime!=null)
							{
								LitRegtime.Text = huiyuanDT.Regtime.ToString("dd-MM-yyyy");
							}
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
			
//			ListItem itemPending= new ListItem(ProcessCenterStatusEnum.Pending.ToString(),"Pending");
//			this.ddlQuery.Items.Add(itemPending);
//			
//			ListItem itemDetailVerified= new ListItem(ProcessCenterStatusEnum.DetailVerified.ToString(),"DetailVerified");
//			this.ddlQuery.Items.Add(itemDetailVerified);
//			
//			ListItem itemPreApproval= new ListItem(ProcessCenterStatusEnum.PreApproval.ToString(),"PreApproval");
//			this.ddlQuery.Items.Add(itemPreApproval);
//			
//			ListItem itemPreApproved= new ListItem(ProcessCenterStatusEnum.PreApproved.ToString(),"PreApproved");
//			this.ddlQuery.Items.Add(itemPreApproved);
//			
//			ListItem itemFinalApproval= new ListItem(ProcessCenterStatusEnum.FinalApproval.ToString(),"FinalApproval");
//			this.ddlQuery.Items.Add(itemFinalApproval);
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
//				case "Pending":
//					conditionString = String.Format(" ProcessStatus={0} ", Convert.ToInt32(ProcessCenterStatusEnum.Pending));
//					break;
//				case "DetailVerified":
//					conditionString = String.Format(" ProcessStatus={0} ", Convert.ToInt32(ProcessCenterStatusEnum.DetailVerified));
//					break;
//				case "PreApproval":
//					conditionString = String.Format(" ProcessStatus={0} ", Convert.ToInt32(ProcessCenterStatusEnum.PreApproval));
//					break;
//				case "PreApproved":
//					conditionString = String.Format(" ProcessStatus={0} ", Convert.ToInt32(ProcessCenterStatusEnum.PreApproved));
//					break;
//				case "FinalApproval":
//					conditionString = String.Format(" ProcessStatus={0} ", Convert.ToInt32(ProcessCenterStatusEnum.FinalApproval));
//					break;
			}
			
			this.txCondition.Text = conditionString;
			this.DataGridTable1.DataBind();
		}

//		private void btnStat_Click(object sender, System.EventArgs e)
//		{
//			string conditionString = string.Empty;
//			string cultureInfoFormat= ConfigurationSettings.AppSettings["CultureInfoFormat"];
//			if(cultureInfoFormat==null||cultureInfoFormat==string.Empty)
//			{
//				cultureInfoFormat= "en-AU";
//			}
//
//			if(this.tbxBeginDateD.Text.Trim()!=string.Empty&&this.tbxBeginDateM.Text.Trim()!=string.Empty&&this.tbxBeginDateY.Text.Trim()!=string.Empty)
//			{
//				try
//				{
//					DateTime tempBeginDate= new DateTime(Convert.ToInt32(this.tbxBeginDateY.Text.Trim()),Convert.ToInt32(this.tbxBeginDateM.Text.Trim()),Convert.ToInt32(this.tbxBeginDateD.Text.Trim()));
//					string strBeginDate= tempBeginDate.ToString(new CultureInfo(cultureInfoFormat));
//					conditionString= string.Format(" PostDate>='{0}' ",strBeginDate);
//				}
//				catch{}
//			}
//
//			if(this.tbxEndDateD.Text.Trim()!=string.Empty&&this.tbxEndDateM.Text.Trim()!=string.Empty&&this.tbxEndDateY.Text.Trim()!=string.Empty)
//			{
//				try
//				{
//					DateTime tempEndDate= new DateTime(Convert.ToInt32(this.tbxEndDateY.Text.Trim()),Convert.ToInt32(this.tbxEndDateM.Text.Trim()),Convert.ToInt32(this.tbxEndDateD.Text.Trim()));
//					string strEndDate= tempEndDate.ToString(new CultureInfo(cultureInfoFormat));
//					if(conditionString!=string.Empty)
//					{
//						conditionString+=" and ";
//					}
//					conditionString+= string.Format(" PostDate<='{0}' ",strEndDate);
//				}
//				catch{}
//			}
//
//			this.txCondition.Text = conditionString;
//			this.DataGridTable1.DataBind();
//		}
	}
}
