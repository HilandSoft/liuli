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
using YingNet.Common.Utils;

namespace YingNet.WeiXing.WebApp.manage.Long.ProcessCenter
{
	/// <summary>
	/// ProcessInfo 的摘要说明。
	/// </summary>
	public class ProcessInfo : ManageBasePage2
	{
		protected System.Web.UI.WebControls.TextBox txSid;
		protected System.Web.UI.WebControls.TextBox txPerSid;
		protected System.Web.UI.WebControls.Button bnSave;
		protected System.Web.UI.WebControls.CheckBox cbMasterLoanAgreement;
		protected System.Web.UI.WebControls.CheckBox cbBankStatement;
		protected System.Web.UI.WebControls.CheckBox cbUtilityBill;
		protected System.Web.UI.WebControls.CheckBox cbDirectDebitRequest;
		protected System.Web.UI.WebControls.CheckBox cbPaySlip;
		protected System.Web.UI.WebControls.CheckBox cbID;
		protected System.Web.UI.WebControls.Button btnSendForPreApproval;
		protected System.Web.UI.WebControls.Button btnPreApproval;
		protected System.Web.UI.WebControls.Button btnDetailsVerified;
		protected System.Web.UI.WebControls.Button btnFinalApproval;
		protected System.Web.UI.WebControls.TextBox ConversationTrack;
		protected System.Web.UI.WebControls.Button bnReturn;
		protected System.Web.UI.WebControls.TextBox tbNextPaydayDD;
		protected System.Web.UI.WebControls.TextBox tbNextPaydayMM;
		protected System.Web.UI.WebControls.TextBox tbNextPaydayYYYY;
		protected System.Web.UI.WebControls.HyperLink HyperLink1;
		protected System.Web.UI.WebControls.Button btnSave;
		protected System.Web.UI.WebControls.Label LabMemberID;
		protected System.Web.UI.WebControls.TextBox tbEmpolyerName2;
		protected System.Web.UI.WebControls.TextBox tbEmployerAddress2;
		protected System.Web.UI.WebControls.TextBox tbEmployerTelephone2;
		protected System.Web.UI.WebControls.TextBox tbWorkTelephone2;
		protected System.Web.UI.WebControls.TextBox tbEmploymentStatus2;
		protected System.Web.UI.WebControls.TextBox tbJobTitle2;
		protected System.Web.UI.WebControls.TextBox tbTimeEmployed2;
		protected System.Web.UI.WebControls.TextBox tbPayAfterTaxes2;
		protected System.Web.UI.WebControls.TextBox tbPayFrequency2;
		protected System.Web.UI.WebControls.TextBox tbHomeTelephone2;
		protected System.Web.UI.WebControls.TextBox tbEmpolyerName;
		protected System.Web.UI.WebControls.TextBox tbEmployerAddress;
		protected System.Web.UI.WebControls.TextBox tbEmployerTelephone;
		protected System.Web.UI.WebControls.TextBox tbWorkTelephone;
		protected System.Web.UI.WebControls.TextBox tbEmploymentStatus;
		protected System.Web.UI.WebControls.TextBox tbJobTitle;
		protected System.Web.UI.WebControls.TextBox tbTimeEmployed;
		protected System.Web.UI.WebControls.TextBox tbPayAfterTaxes;
		protected System.Web.UI.WebControls.TextBox tbPayFrequency;
		protected System.Web.UI.WebControls.TextBox tbHomeTelephone;
		
		private int ProcessID=0;
		
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
				return CommonOperateEnum.CreateEdit;
			}
			set
			{
				base.CommonOperate = value;
			}
		}
		
		protected override bool ValitadePermissionOperate(CommonOperateEnum operatesOwned,CommonOperateEnum operateNeedValited)
		{
			if(operateNeedValited== CommonOperateEnum.CreateEdit)
			{
				if((operatesOwned& CommonOperateEnum.DetailsVerification)!=0)
				{
					return true;
				}
				
				if((operatesOwned& CommonOperateEnum.DocumentCheckList)!=0)
				{
					return true;
				}
				
				if((operatesOwned& CommonOperateEnum.FinalApproval)!=0)
				{
					return true;
				}
				
				if((operatesOwned& CommonOperateEnum.PreApproval)!=0)
				{
					return true;
				}
			}
			
			return base.ValitadePermissionOperate(operatesOwned,operateNeedValited);
		}
	
		private void Page_Load(object sender, System.EventArgs e)
		{
			this.ProcessID =Convert.ToInt32( this.Request.QueryString["ProcessID"]);
			
			SetState();
			if(this.IsPostBack==false)
			{
				this.LoadInfo();
			}
		}
		
		/// <summary>
		/// 根据用户的权限设置页面控件的可操作性
		/// </summary>
		private void SetState()
		{
			bool isPerDocumentCheckList = false;
			bool isPerDetailsVerification = false;
			bool isPerPreApproval = false;
			bool isPerFinalApproval = false;
			
			if(UserPermission==null)
			{
				if(this.SystemUserAccount.ToLower()=="superlily")
				{
					isPerDocumentCheckList = true;
					isPerDetailsVerification = true;
					isPerPreApproval = true;
					isPerFinalApproval = true;
				}
			}
			else
			{
				isPerDocumentCheckList= ValitadePermissionOperate((CommonOperateEnum) UserPermission.PermissionProcessCenter,
					CommonOperateEnum.DocumentCheckList);
				isPerDetailsVerification = ValitadePermissionOperate((CommonOperateEnum) UserPermission.PermissionProcessCenter,
					CommonOperateEnum.DetailsVerification);
				isPerPreApproval= ValitadePermissionOperate((CommonOperateEnum) UserPermission.PermissionProcessCenter,
					CommonOperateEnum.PreApproval);
				isPerFinalApproval= ValitadePermissionOperate((CommonOperateEnum) UserPermission.PermissionProcessCenter,
					CommonOperateEnum.FinalApproval);
			}
			
			if(isPerDocumentCheckList==false)
			{
				btnSendForPreApproval.Enabled = false;
				cbBankStatement.Enabled = false;
				cbDirectDebitRequest.Enabled = false;
				cbID.Enabled = false;
				cbMasterLoanAgreement.Enabled = false;
				cbPaySlip.Enabled = false;
				cbUtilityBill.Enabled = false;
			}
			
			if(isPerDetailsVerification==false)
			{
				btnDetailsVerified.Enabled = false;
				tbEmployerAddress.Enabled = false;
				tbEmployerTelephone.Enabled = false;
				tbEmploymentStatus.Enabled = false;
				tbEmpolyerName.Enabled = false;
				tbHomeTelephone.Enabled = false;
				tbJobTitle.Enabled = false;
			}
			
			
			if(isPerPreApproval==false)
			{
				btnPreApproval.Enabled = false;
			}
			
			if(isPerFinalApproval==false)
			{
				btnFinalApproval.Enabled = false;
			}
		}
		
		private void LoadInfo()
		{
			CSProcessCenterBN business= new CSProcessCenterBN(this.Page);
			CSProcessCenterDT entity=  business.Get(this.ProcessID);
			if(entity!=null)
			{
				this.LabMemberID.Text= entity.UserID.ToString();

				this.ConversationTrack.Text = entity.ConversationTrack;
				
				this.cbBankStatement.Checked = entity.IsDocumentBankStatement;
				this.cbDirectDebitRequest.Checked = entity.IsDocumentDirectDebitRequest;
				this.cbID.Checked = entity.IsDocumentID;
				this.cbMasterLoanAgreement.Checked = entity.IsDocumentMasterLoanAgreemnet;
				this.cbPaySlip.Checked = entity.IsDocumentPaySlip;
				this.cbUtilityBill.Checked = entity.IsDocumentUtilityBill;
				
				CSUserLoanInfoCheckBN checkBN= new CSUserLoanInfoCheckBN(this.Page);
				CSUserLoanInfoCheckDT checkDT = checkBN.Get(this.ProcessID);
				
				/* 如果当前处理有Employer验证信息,则填写当前信息;如果没有,则读取该用户的最近处理的一次验证信息*/
				if(checkDT==null)
				{
					checkBN.CleanStatus();
					checkBN.Filter = string.Format(" UserLoanType={0} ",(int)entity.UserLoanType);
					checkBN.Filter = String.Format(" UserID={0} ", entity.UserID);
					DataTable table = checkBN.GetList();
					if(table!=null&& table.Rows.Count>0)
					{
						DataRow row= table.Rows[0];
									
						this.tbEmployerAddress.Text = Convert.ToString(row["EmployerAddress"]);
						this.tbEmpolyerName.Text = Convert.ToString(row["EmployerName"]);
						this.tbEmployerTelephone.Text = Convert.ToString(row["EmployerTelephone"]);
						this.tbHomeTelephone.Text = Convert.ToString(row["HomeTelephone"]);
						this.tbPayFrequency.Text = Convert.ToString(row["PayFrequency"]);
						this.tbPayAfterTaxes.Text= Convert.ToString(row["TakeHomePayAfterTaxes"]);
					
						this.tbJobTitle.Text = Convert.ToString(row["JobTitle"]);
						this.tbTimeEmployed.Text = Convert.ToString(row["TimeEmployed"]);
						this.tbWorkTelephone.Text = Convert.ToString(row["WorkTelephone"]);
						
						if(row["NextPayday"]!= DBNull.Value)
						{
							DateTime tempTime = Convert.ToDateTime(row["NextPayday"]);
							if(tempTime>new DateTime(1753,1,3))
							{
								this.tbNextPaydayDD.Text = tempTime.Day.ToString("00");
								this.tbNextPaydayMM.Text = tempTime.Month.ToString("00");
								this.tbNextPaydayYYYY.Text = tempTime.Year.ToString("0000");
							}
						}
					}
					else
					{
						//do nothing;
					}
				}
				else
				{
					this.tbEmployerAddress.Text = checkDT.EmployerAddress;
					this.tbEmpolyerName.Text = checkDT.EmployerName;
					this.tbEmployerTelephone.Text = checkDT.EmployerTelephone;
					this.tbHomeTelephone.Text = checkDT.HomeTelephone;
					this.tbPayFrequency.Text = checkDT.PayFrequency;
					this.tbPayAfterTaxes.Text= checkDT.TakeHomePayAfterTaxes.ToString();
					
					this.tbJobTitle.Text = checkDT.JobTitle;
					this.tbTimeEmployed.Text = checkDT.TimeEmployed;
					this.tbWorkTelephone.Text = checkDT.WorkTelephone;
					this.tbEmploymentStatus.Text= checkDT.EmploymentStatusText;
					
					if(checkDT.NextPayday>new DateTime(1753,1,3))
					{
						this.tbNextPaydayDD.Text = checkDT.NextPayday.Day.ToString("00");
						this.tbNextPaydayMM.Text = checkDT.NextPayday.Month.ToString("00");
						this.tbNextPaydayYYYY.Text = checkDT.NextPayday.Year.ToString("0000");
					}
				}

				//用户原有的信息
				LpersonBN personBN= new LpersonBN(this.Page);
				LpersonDT personDT= personBN.Get(entity.UserID);
				if(personDT!=null)
				{
					this.tbEmployerTelephone2.Text= personDT.Mobile;
					this.tbHomeTelephone2.Text= personDT.HTelnum;
					this.tbWorkTelephone2.Text= personDT.WTelnum;
				}

				LemploymentBN empBN= new LemploymentBN(this.Page);
				empBN.QueryLoanSid(entity.UserID);
				DataTable empTable= empBN.GetList();

				if(empTable!=null&& empTable.Rows.Count>0)
				{
					DataRow empRow= empTable.Rows[0];

					//将Emp的id保存在Session中,供保存这个emp的时候使用
					this.Session["CurrentEmpID"]= Convert.ToInt32(empRow["sid"]);

					this.tbEmployerAddress2.Text= Convert.ToString(empRow["EAddress"]);
					this.tbEmpolyerName2.Text= Convert.ToString(empRow["EName"]);
					this.tbEmploymentStatus2.Text= Convert.ToString(empRow["EStatus"]);
					this.tbJobTitle2.Text= Convert.ToString(empRow["JobTitle"]);
					this.tbPayAfterTaxes2.Text= Convert.ToString(empRow["TakePay"]);
					this.tbTimeEmployed2.Text= Convert.ToString(empRow["TimeYears"])+"Year(s)"+Convert.ToString(empRow["TimeMonths"])+"Month(s)";
				}
				else
				{
					this.Session["CurrentEmpID"]=0;
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
			this.btnSendForPreApproval.Click += new System.EventHandler(this.btnSendForPreApproval_Click);
			this.btnPreApproval.Click += new System.EventHandler(this.btnPreApproval_Click);
			this.btnDetailsVerified.Click += new System.EventHandler(this.btnDetailsVerified_Click);
			this.btnFinalApproval.Click += new System.EventHandler(this.btnFinalApproval_Click);
			this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		private void btnSendForPreApproval_Click(object sender, System.EventArgs e)
		{
			CSProcessCenterBN business= new CSProcessCenterBN(this.Page);
			CSProcessCenterDT entity=  business.Get(this.ProcessID);
			if(entity!=null)
			{
				entity.ConversationTrack = this.ConversationTrack.Text;
				entity.DocumentCheckListStatus = DocumentCheckListStatusEnum.Checked;
				entity.ProcessStatus = ProcessCenterStatusEnum.PreApproval;
				entity.LastOperateDate= SafeDateTime.LocalNow;
				
				entity.IsDocumentBankStatement=this.cbBankStatement.Checked;
				entity.IsDocumentDirectDebitRequest = this.cbDirectDebitRequest.Checked;
				entity.IsDocumentID = this.cbID.Checked;
				entity.IsDocumentMasterLoanAgreemnet = this.cbMasterLoanAgreement.Checked;
				entity.IsDocumentPaySlip = this.cbPaySlip.Checked;
				entity.IsDocumentUtilityBill = this.cbUtilityBill.Checked;
				
				business.Edit(entity);
				
				this.Response.Redirect("ProcessList.aspx");
			}
		}

		private void btnPreApproval_Click(object sender, System.EventArgs e)
		{
			CSProcessCenterBN business= new CSProcessCenterBN(this.Page);
			CSProcessCenterDT entity=  business.Get(this.ProcessID);
			if(entity!=null)
			{
				entity.ConversationTrack = this.ConversationTrack.Text;
				entity.ProcessStatus = ProcessCenterStatusEnum.PreApproved;
				entity.LastOperateDate= SafeDateTime.LocalNow;
				
				business.Edit(entity);
				
				this.Response.Redirect("ProcessList.aspx");
			}
		}

		private void btnDetailsVerified_Click(object sender, System.EventArgs e)
		{
			CSProcessCenterBN business= new CSProcessCenterBN(this.Page);
			CSProcessCenterDT entity=  business.Get(this.ProcessID);
			if(entity!=null)
			{
				entity.ConversationTrack = this.ConversationTrack.Text;
				entity.DetailsVerificationStatus = DetailsVerificationStatusEnum.Done;
				entity.ProcessStatus = ProcessCenterStatusEnum.DetailVerified;
				entity.LastOperateDate= SafeDateTime.LocalNow;
				
				business.Edit(entity);
				
				bool isNewCheck = false;
				CSUserLoanInfoCheckBN checkBN= new CSUserLoanInfoCheckBN(this.Page);
				CSUserLoanInfoCheckDT checkDT = checkBN.Get(this.ProcessID);
				if(checkDT==null)
				{
					isNewCheck = true;
					checkDT= new CSUserLoanInfoCheckDT();
					
					checkDT.CheckOther1 = 0;
					checkDT.CheckOther2 = 0;
					checkDT.CheckOther3 = string.Empty;
					checkDT.CheckOther4 = string.Empty;
					checkDT.UserLoanType = UserLoanTypes.Short;
					checkDT.UserID = entity.UserID;
					checkDT.ProcessID = entity.ProcessID;
				}
				
				checkDT.EmployerAddress = this.tbEmployerAddress.Text;
				checkDT.EmployerName = this.tbEmpolyerName.Text;
				checkDT.EmployerTelephone = this.tbEmployerTelephone.Text;
				checkDT.HomeTelephone = this.tbHomeTelephone.Text;
				checkDT.PayFrequency = this.tbPayFrequency.Text;
				try
				{
					checkDT.TakeHomePayAfterTaxes = Convert.ToDecimal( this.tbPayAfterTaxes.Text);
				}
				catch
				{
				}
				checkDT.JobTitle = this.tbJobTitle.Text;
				checkDT.TimeEmployed = this.tbTimeEmployed.Text;
				checkDT.WorkTelephone = this.tbWorkTelephone.Text;
				try
				{
					checkDT.NextPayday= new DateTime(Convert.ToInt32(this.tbNextPaydayYYYY.Text),Convert.ToInt32(this.tbNextPaydayMM.Text),
					                                 Convert.ToInt32(this.tbNextPaydayDD.Text));
				}
				catch
				{
					checkDT.NextPayday= new DateTime(1753,1,2);
				}
				
				checkDT.EmploymentStatusText = this.tbEmploymentStatus.Text;


				
				if(isNewCheck==true)
				{
					checkBN.Add(checkDT);
				}
				else
				{
					checkBN.Edit(checkDT);
				}

				//另外保持LEmployee信息以及LPerson信息
				if(this.Session["CurrentEmpID"]!=null&&Convert.ToInt32(this.Session["CurrentEmpID"])>0)
				{
					LemploymentBN empBN= new LemploymentBN(this.Page);
					LemploymentDT empDT= empBN.Get(Convert.ToInt32(this.Session["CurrentEmpID"]));

					empDT.EAddress= this.tbEmployerAddress2.Text;
					empDT.EName= this.tbEmpolyerName2.Text;
					empDT.EStatus= this.tbEmploymentStatus2.Text;
					empDT.JobTitle= this.tbJobTitle2.Text;
					try
					{
						empDT.TakePay= Convert.ToDouble(this.tbPayAfterTaxes2.Text);
					}
					catch{}

					empBN.Edit(empDT);
				}

				LpersonBN personBN= new LpersonBN(this.Page);
				LpersonDT personDT= personBN.Get(entity.UserID);
				if(personDT!=null)
				{
					personDT.Mobile= this.tbEmployerTelephone2.Text;
					personDT.HTelnum= this.tbHomeTelephone2.Text;
					personDT.WTelnum= this.tbWorkTelephone2.Text;

					personBN.Edit(personDT);
				}
				
				this.Response.Redirect("ProcessList.aspx");
			}
		}

		private void btnFinalApproval_Click(object sender, System.EventArgs e)
		{
			CSProcessCenterBN business= new CSProcessCenterBN(this.Page);
			CSProcessCenterDT entity=  business.Get(this.ProcessID);
			if(entity!=null)
			{
				entity.ConversationTrack = this.ConversationTrack.Text;
				entity.ProcessStatus = ProcessCenterStatusEnum.FinalApproval;
				entity.LastOperateDate= SafeDateTime.LocalNow;
				
				business.Edit(entity);
				
				this.Response.Redirect("ProcessList.aspx");
			}
		}

		private void btnSave_Click(object sender, System.EventArgs e)
		{
			CSProcessCenterBN business= new CSProcessCenterBN(this.Page);
			CSProcessCenterDT entity=  business.Get(this.ProcessID);
			if(entity!=null)
			{
				entity.ConversationTrack = this.ConversationTrack.Text;
				business.Edit(entity,false);
				
				this.Response.Redirect("ProcessList.aspx");
			}
		}
	}
}
