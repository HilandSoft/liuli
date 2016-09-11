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
using YingNet.WeiXing.STRUCTURE;

namespace YingNet.WeiXing.WebApp.manage.Long.FollowupCenter
{
	/// <summary>
	/// FollowupStat 的摘要说明。
	/// </summary>
	public class FollowupStat : ManageBasePage2
	{
		protected System.Web.UI.WebControls.DropDownList ddlQuery;
		protected System.Web.UI.WebControls.Button btnQuery;
		protected System.Web.UI.WebControls.Label Label1;
		protected System.Web.UI.WebControls.TextBox txCondition;
		protected System.Web.UI.WebControls.CheckBox chkID;
		protected System.Web.UI.WebControls.Literal LitCustomerNumber;
		protected System.Web.UI.WebControls.Literal LitFirstName;
		protected System.Web.UI.WebControls.Literal LitMiddleName;
		protected System.Web.UI.WebControls.Literal LitLastName;
		protected System.Web.UI.WebControls.Literal LitPassword;
		protected System.Web.UI.WebControls.Literal LitDateBirth;
		protected System.Web.UI.WebControls.Literal LitDriverNumber;
		protected System.Web.UI.WebControls.Literal LitRegtime;
		protected System.Web.UI.WebControls.Literal litStatus;
		protected System.Web.UI.WebControls.Literal LitPreStatus;
		protected System.Web.UI.WebControls.Literal LitActionDueDate;
		protected System.Web.UI.WebControls.Literal litOperate;
		protected System.Web.UI.WebControls.CheckBox CheckBox1;
		protected System.Web.UI.WebControls.TextBox txtParamstr;
		protected System.Web.UI.WebControls.TextBox tbxBeginDateD;
		protected System.Web.UI.WebControls.TextBox tbxBeginDateM;
		protected System.Web.UI.WebControls.TextBox tbxBeginDateY;
		protected System.Web.UI.WebControls.TextBox tbxEndDateD;
		protected System.Web.UI.WebControls.TextBox tbxEndDateM;
		protected System.Web.UI.WebControls.TextBox tbxEndDateY;
		protected YingNet.Common.DataGridTable DataGridTable1;
	
		private void Page_Load(object sender, System.EventArgs e)
		{
			if (!base.IsPostBack)
			{
				this.BindQueryInfo();
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

		protected override FunnctionModuleEnum FunnctionModuleName
		{
			get
			{
				return FunnctionModuleEnum.LFollowupCenter;
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

		/// <summary>
		/// 绑定查询条件
		/// </summary>
		private void BindQueryInfo()
		{
			ListItem itemSelect= new ListItem("PleaseSelect","");
			this.ddlQuery.Items.Add(itemSelect);
			
		
			ListItem itemEveryday= new ListItem("Everyday","0");
			this.ddlQuery.Items.Add(itemEveryday);
						
			ListItem itemByDate= new ListItem("ByDate","10");
			this.ddlQuery.Items.Add(itemByDate);
						
			ListItem itemScheduled= new ListItem("Scheduled","20");
			this.ddlQuery.Items.Add(itemScheduled);
						
			ListItem itemReDDed= new ListItem("Re-DDed","30");
			this.ddlQuery.Items.Add(itemReDDed);
						
			ListItem itemDefaultLetter= new ListItem("DefaultLetter","40");
			this.ddlQuery.Items.Add(itemDefaultLetter);

			ListItem itemFinalNotice= new ListItem("FinalNotice","50");
			this.ddlQuery.Items.Add(itemFinalNotice);
						
			ListItem itemCollection= new ListItem("Collection","60");
			this.ddlQuery.Items.Add(itemCollection);
						
			ListItem itemOnHold= new ListItem("OnHold","70");
			this.ddlQuery.Items.Add(itemOnHold);
						
			ListItem itemAwaitingResult= new ListItem("AwaitingResult(P9)","80");
			this.ddlQuery.Items.Add(itemAwaitingResult);

			ListItem itemAwaitingDividends= new ListItem("AwaitingDividends(P9)","90");
			this.ddlQuery.Items.Add(itemAwaitingDividends);

			ListItem itemBlackList= new ListItem("BlackList","100");
			this.ddlQuery.Items.Add(itemBlackList);
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
			this.DataGridTable1.PageIndexChanged += new System.Web.UI.WebControls.DataGridPageChangedEventHandler(this.DataGridTable1_PageIndexChanged);
			this.DataGridTable1.DataBinding += new System.EventHandler(this.DataGridTable1_DataBinding);
			this.DataGridTable1.ItemDataBound += new System.Web.UI.WebControls.DataGridItemEventHandler(this.DataGridTable1_ItemDataBound);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		private void btnQuery_Click(object sender, System.EventArgs e)
		{
			string conditionString = string.Empty;
			string cultureInfoFormat= ConfigurationSettings.AppSettings["CultureInfoFormat"];
			if(cultureInfoFormat==null||cultureInfoFormat==string.Empty)
			{
				cultureInfoFormat= "en-AU";
			}

			if(this.tbxBeginDateD.Text.Trim()!=string.Empty&&this.tbxBeginDateM.Text.Trim()!=string.Empty&&this.tbxBeginDateY.Text.Trim()!=string.Empty)
			{
				try
				{
					DateTime tempBeginDate= new DateTime(Convert.ToInt32(this.tbxBeginDateY.Text.Trim()),Convert.ToInt32(this.tbxBeginDateM.Text.Trim()),Convert.ToInt32(this.tbxBeginDateD.Text.Trim()));
					string strBeginDate= tempBeginDate.ToString(new CultureInfo(cultureInfoFormat));
					conditionString= string.Format(" PostDate>='{0}' ",strBeginDate);
				}
				catch{}
			}

			if(this.tbxEndDateD.Text.Trim()!=string.Empty&&this.tbxEndDateM.Text.Trim()!=string.Empty&&this.tbxEndDateY.Text.Trim()!=string.Empty)
			{
				try
				{
					DateTime tempEndDate= new DateTime(Convert.ToInt32(this.tbxEndDateY.Text.Trim()),Convert.ToInt32(this.tbxEndDateM.Text.Trim()),Convert.ToInt32(this.tbxEndDateD.Text.Trim()));
					string strEndDate= tempEndDate.ToString(new CultureInfo(cultureInfoFormat));
					if(conditionString!=string.Empty)
					{
						conditionString+=" and ";
					}
					conditionString+= string.Format(" PostDate<='{0}' ",strEndDate);
				}
				catch{}
			}

			string selectedValue = this.ddlQuery.SelectedValue;
			switch(selectedValue)
			{
				case "":
					//conditionString = string.Empty;
					break;

				default:
					if(conditionString!=string.Empty)
					{
						conditionString+=" and ";
					}
					conditionString= string.Format("  FollowupStatus={0}  ",selectedValue);
					break;

			}

			this.txCondition.Text = conditionString;
			this.DataGridTable1.DataBind();
		}

		private void DataGridTable1_DataBinding(object sender, System.EventArgs e)
		{
			CSFollowupCenterBN business = new CSFollowupCenterBN(this.Page);
			
			DataTable dt=null;
			business.CleanStatus();
			business.Filter = string.Format(" UserLoanType={0} ",(int)UserLoanTypes.Long);

			if(this.txCondition.Text!=string.Empty)
			{
				business.Filter = this.txCondition.Text;
			}
			dt = business.GetList();
			CommonBasePage.SetPage(this.DataGridTable1, dt);
			base.AddValue("pageno", Convert.ToString((int) (this.DataGridTable1.CurrentPageIndex + 1)));
			this.txtParamstr.Text = base.PackPart(base.ParamValue);
		}

		private void DataGridTable1_ItemDataBound(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
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
						litCustomerNumber.Text=String.Format("<a target='_blank' href='../LongDetail.aspx?sid={0}'>{0}</a>",followupDT.UserID); 
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

					Literal litOperate = e.Item.FindControl("litOperate") as Literal;
					if(litOperate!=null)
					{
						litOperate.Text = string.Format("<a href='FollowupDele.aspx?followupID={0}'>Delete</a>",rowView["followupID"]);
						//litOperate.Text = string.Format("<a href='FollowupInfo.aspx?followupID={0}&status={1}'>Edit</a>",rowView["followupID"],this.Request.QueryString["status"]);
					}

					Literal LitActionDueDate= e.Item.FindControl("LitActionDueDate") as Literal;
					if(LitActionDueDate!=null&& followupDT.RemindDate>new DateTime(1753,1,2))
					{
						LitActionDueDate.Text= followupDT.RemindDate.ToString("dd-MM-yyyy");
					}
					
					if(followupDT.UserID>0)
					{
						LpersonBN personBN= new LpersonBN(this.Page);
						LpersonDT huiyuanDT= personBN.Get(followupDT.UserID);
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
							
							Literal LitRegtime = e.Item.FindControl("LitRegtime") as Literal;
							if(LitRegtime!=null)
							{
								LitRegtime.Text = huiyuanDT.RegTime.ToString("dd-MM-yyyy");
							}
						}
					}
				}
			}
		}

		private void DataGridTable1_PageIndexChanged(object source, System.Web.UI.WebControls.DataGridPageChangedEventArgs e)
		{
			this.DataGridTable1.CurrentPageIndex = e.NewPageIndex;
			this.DataGridTable1.DataBind();
		}
	}
}
