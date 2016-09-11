using YingNet.WeiXing.DB.Data;

namespace YingNet.WeiXing.WebApp.manage.Long.ProcessCenter
{
    using System;
    using System.Data;
    using System.Web.UI.WebControls;
    using YingNet.Common;
    using YingNet.WeiXing.Business;

    public class openwindow : ManageBasePage2
    {
        protected DataGridTable DataGridTable1;
        protected TextBox txtParamstr;

		/// <summary>
		/// 不需要使用权限
		/// </summary>
		protected override bool IsNeedValidate
		{
			get{return false;}
		}
    	
		protected override FunnctionModuleEnum FunnctionModuleName
		{
			get
			{
				return FunnctionModuleEnum.ProcessCenter;
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

        private void DataGridTable1_DataBinding(object sender, EventArgs e)
        {
			CSProcessCenterBN processCenterBN = new CSProcessCenterBN(this.Page);
			
			DataTable dt=null;
			processCenterBN.CleanStatus();
			processCenterBN.Filter = string.Format(" UserLoanType={0} ",(int)UserLoanTypes.Long);
			processCenterBN.Filter = string.Format(" processOther1={0} ",(int)InformationAlertStates.UnRead);
			string alertStateString= this.GetAlertStateWithPermission();
			if(alertStateString!=string.Empty)
			{
				processCenterBN.Filter= string.Format(" ProcessStatus in ({0}) ",alertStateString);
			}

			processCenterBN.Order=" LastOperateDate desc";

        	dt = processCenterBN.GetList();
			CommonBasePage.SetPage(this.DataGridTable1, dt);
			base.AddValue("pageno", Convert.ToString((int) (this.DataGridTable1.CurrentPageIndex + 1)));
			this.txtParamstr.Text = base.PackPart(base.ParamValue);
        }
    	
    	/// <summary>
    	/// 获取某人有权限操作的状态类型
    	/// </summary>
    	/// <returns></returns>
    	private string GetAlertStateWithPermission()
    	{
    		string states = string.Empty;
    		
			if(UserPermission==null)
			{
				if(this.SystemUserAccount.ToLower()=="superlily")
				{
					states= String.Empty;
				}
				else
				{
					states="101";//如果没有权限,则不显示任何数据,此处的101是一个在数据库中不存在的状态
				}
			}
			else
			{
				if(ValitadePermissionOperate((CommonOperateEnum)UserPermission.PermissionProcessCenter,CommonOperateEnum.DetailsVerification))
				{	
					states += ((int) ProcessCenterStatusEnum.PreApproved).ToString() + ",";
				}
    		
				if(ValitadePermissionOperate((CommonOperateEnum)UserPermission.PermissionProcessCenter,CommonOperateEnum.DocumentCheckList))
				{	
					states += ((int) ProcessCenterStatusEnum.Pending).ToString() + ",";
				}
    		
				if(ValitadePermissionOperate((CommonOperateEnum)UserPermission.PermissionProcessCenter,CommonOperateEnum.PreApproval))
				{	
					states += ((int) ProcessCenterStatusEnum.PreApproval).ToString() + ",";
				}
    		
				if(ValitadePermissionOperate((CommonOperateEnum)UserPermission.PermissionProcessCenter,CommonOperateEnum.FinalApproval))
				{	
					states += ((int) ProcessCenterStatusEnum.DetailVerified).ToString() + ",";
					states += ((int) ProcessCenterStatusEnum.FinalApproval).ToString() + ",";
				}
    		
				if(states.EndsWith(","))
				{
					states = states.Substring(0, states.Length - 1);
				}
			}
    		return states;
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
					Literal litStatus = e.Item.FindControl("litStatus") as Literal;
					if(litStatus!=null)
					{
						litStatus.Text = Convert.ToString(processCenterDT.ProcessStatus);
					}
					
					if(processCenterDT.UserID>0)
					{
						HuiyuanBN huiyuanBN= new HuiyuanBN(this.Page);
						HuiyuanDT huiyuanDT = huiyuanBN.Get(processCenterDT.UserID);
						if(huiyuanDT!=null)
						{
							Literal LitUserName = e.Item.FindControl("LitUserName") as Literal;
							if(LitUserName!=null)
							{
								LitUserName.Text = huiyuanDT.Username;
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

        private void InitializeComponent()
        {
            this.DataGridTable1.PageIndexChanged += new DataGridPageChangedEventHandler(this.DataGridTable1_PageIndexChanged);
            this.DataGridTable1.DataBinding += new EventHandler(this.DataGridTable1_DataBinding);
            this.DataGridTable1.ItemDataBound += new DataGridItemEventHandler(this.DataGridTable1_ItemDataBound);
            base.Load += new EventHandler(this.Page_Load);
        }

        protected override void OnInit(EventArgs e)
        {
            this.InitializeComponent();
            base.OnInit(e);
        }

        private void Page_Load(object sender, EventArgs e)
        {
            if (!base.IsPostBack)
            {
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
    }
}

