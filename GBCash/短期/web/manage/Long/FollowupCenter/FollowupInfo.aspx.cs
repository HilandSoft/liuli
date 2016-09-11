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
using YingNet.Common.Utils;

namespace YingNet.WeiXing.WebApp.manage.Long.FollowupCenter
{
	/// <summary>
	/// FollowupInfo 的摘要说明。
	/// </summary>
	public class FollowupInfo : ManageBasePage2
	{
		protected System.Web.UI.WebControls.TextBox txSid;
		protected System.Web.UI.WebControls.TextBox txPerSid;
		protected System.Web.UI.WebControls.Button bnSave;
		protected System.Web.UI.WebControls.Button bnReturn;
		protected System.Web.UI.WebControls.CheckBox cbRemindEnable;
		protected System.Web.UI.WebControls.TextBox tbDay;
		protected System.Web.UI.WebControls.TextBox tbMonth;
		protected System.Web.UI.WebControls.TextBox tbYear;
		protected System.Web.UI.WebControls.DropDownList ddlChooseFollowupStatus;
		protected System.Web.UI.WebControls.Button btnSave;
		
		private int followupID=0;
		protected string status= "0";
		
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
				return CommonOperateEnum.CreateEdit;
			}
			set
			{
				base.CommonOperate = value;
			}
		}
		
		
	
		private void Page_Load(object sender, System.EventArgs e)
		{
			this.followupID =Convert.ToInt32( this.Request.QueryString["followupID"]);
			this.status= this.Request.QueryString["status"];
			
			if(this.IsPostBack==false)
			{
				this.BindStatus();
				this.LoadInfo();
			}
		}

		private void BindStatus()
		{
			ListItem itemFollowupEveryday= new ListItem(Convert.ToString( FollowupCenterStatusEnum.FollowupEveryday),Convert.ToInt32(FollowupCenterStatusEnum.FollowupEveryday).ToString());
			this.ddlChooseFollowupStatus.Items.Add(itemFollowupEveryday);

			ListItem itemFollowupByDate= new ListItem(Convert.ToString( FollowupCenterStatusEnum.FollowupByDate),Convert.ToInt32(FollowupCenterStatusEnum.FollowupByDate).ToString());
			this.ddlChooseFollowupStatus.Items.Add(itemFollowupByDate);

			ListItem itemCollection= new ListItem(Convert.ToString( FollowupCenterStatusEnum.Collection),Convert.ToInt32(FollowupCenterStatusEnum.Collection).ToString());
			this.ddlChooseFollowupStatus.Items.Add(itemCollection);

			ListItem itemDefaultLetter= new ListItem(Convert.ToString( FollowupCenterStatusEnum.DefaultLetter),Convert.ToInt32(FollowupCenterStatusEnum.DefaultLetter).ToString());
			this.ddlChooseFollowupStatus.Items.Add(itemDefaultLetter);

			ListItem itemFinalNotice= new ListItem(Convert.ToString( FollowupCenterStatusEnum.FinalNotice),Convert.ToInt32(FollowupCenterStatusEnum.FinalNotice).ToString());
			this.ddlChooseFollowupStatus.Items.Add(itemFinalNotice);

			ListItem itemOnHold= new ListItem(Convert.ToString( FollowupCenterStatusEnum.OnHold),Convert.ToInt32(FollowupCenterStatusEnum.OnHold).ToString());
			this.ddlChooseFollowupStatus.Items.Add(itemOnHold);

			ListItem itemPart9AwaitingDividends= new ListItem(Convert.ToString( FollowupCenterStatusEnum.Part9AwaitingDividends),Convert.ToInt32(FollowupCenterStatusEnum.Part9AwaitingDividends).ToString());
			this.ddlChooseFollowupStatus.Items.Add(itemPart9AwaitingDividends);

			ListItem itemPart9AwaitingResult= new ListItem(Convert.ToString( FollowupCenterStatusEnum.Part9AwaitingResult),Convert.ToInt32(FollowupCenterStatusEnum.Part9AwaitingResult).ToString());
			this.ddlChooseFollowupStatus.Items.Add(itemPart9AwaitingResult);

			ListItem itemReDDed= new ListItem(Convert.ToString( FollowupCenterStatusEnum.ReDDed),Convert.ToInt32(FollowupCenterStatusEnum.ReDDed).ToString());
			this.ddlChooseFollowupStatus.Items.Add(itemReDDed);

			ListItem itemScheduledPayment= new ListItem(Convert.ToString( FollowupCenterStatusEnum.ScheduledPayment),Convert.ToInt32(FollowupCenterStatusEnum.ScheduledPayment).ToString());
			this.ddlChooseFollowupStatus.Items.Add(itemScheduledPayment);

			ListItem itemBlackList= new ListItem(Convert.ToString(FollowupCenterStatusEnum.BlackList),Convert.ToInt32(FollowupCenterStatusEnum.BlackList).ToString());
			this.ddlChooseFollowupStatus.Items.Add(itemBlackList);
		}
		

		
		private void LoadInfo()
		{
			CSFollowupCenterBN business= new CSFollowupCenterBN(this.Page);
			CSFollowupCenterDT entity=  business.Get(this.followupID);
			if(entity!=null)
			{
				this.ddlChooseFollowupStatus.SelectedValue= ((int)entity.FollowupStatus).ToString();
				this.cbRemindEnable.Checked= entity.RemindEnable;
				
				if(entity.RemindDate>new DateTime(1753,1,2))
				{
					this.tbYear.Text= entity.RemindDate.Year.ToString();
					this.tbMonth.Text= entity.RemindDate.Month.ToString();
					this.tbDay.Text= entity.RemindDate.Day.ToString();
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
			this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		private void btnSave_Click(object sender, System.EventArgs e)
		{
			CSFollowupCenterBN business= new CSFollowupCenterBN(this.Page);
			CSFollowupCenterDT entity=  business.Get(this.followupID);
			
			int year=1753,month=1,day=2;
			if(this.tbDay.Text.Trim()!=string.Empty)
			{
				try
				{
					day= int.Parse(this.tbDay.Text.Trim());
				}
				catch{}
			}

			if(this.tbMonth.Text.Trim()!=string.Empty)
			{
				try
				{
					month= int.Parse(this.tbMonth.Text.Trim());
				}
				catch{}
			}

			if(this.tbYear.Text.Trim()!=string.Empty)
			{
				try
				{
					year= int.Parse(this.tbYear.Text.Trim());
				}
				catch{}
			}
			entity.RemindDate= new DateTime(year,month,day);

			entity.RemindEnable= this.cbRemindEnable.Checked;
			entity.PreviewStatus= entity.FollowupStatus;
			entity.FollowupStatus= (FollowupCenterStatusEnum)int.Parse(this.ddlChooseFollowupStatus.SelectedValue);
			entity.LastOperateDate= SafeDateTime.LocalNow;

			business.Edit(entity);

			Response.Redirect("FollowupList.aspx?status="+ status);
		}
	}
}
