using YingNet.WeiXing.DB.Data;

namespace YingNet.WeiXing.WebApp.manage.Long.FollowupCenter
{
    using System;
    using System.Data;
    using System.Web.UI.WebControls;
    using YingNet.Common;
    using YingNet.WeiXing.Business;
	using System.Globalization;
	using System.Configuration;
	using YingNet.Common.Utils;

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
    	

        private void DataGridTable1_DataBinding(object sender, EventArgs e)
        {
			CSFollowupCenterBN followupCenterBN = new CSFollowupCenterBN(this.Page);
			
			DataTable dt=null;
			followupCenterBN.CleanStatus();
			followupCenterBN.Filter = string.Format(" UserLoanType={0} ",(int)UserLoanTypes.Long);
			
			string tempStatus= (int)FollowupCenterStatusEnum.FollowupByDate+ ","+(int)FollowupCenterStatusEnum.FinalNotice+","+
				(int)FollowupCenterStatusEnum.Part9AwaitingDividends+","+ (int)FollowupCenterStatusEnum.Part9AwaitingResult;
			followupCenterBN.Filter= string.Format(" FollowupStatus in ({0}) ",tempStatus);
			followupCenterBN.Filter=string.Format(" RemindEnable=1 ");
			
			string cultureInfoFormat= ConfigurationSettings.AppSettings["CultureInfoFormat"];
			if(cultureInfoFormat==null||cultureInfoFormat==string.Empty)
			{
				cultureInfoFormat= "en-AU";
			}

			string strToday= SafeDateTime.LocalToday.ToString(new CultureInfo(cultureInfoFormat));
			string strMinDate= new DateTime(1753,1,2).ToString(new CultureInfo(cultureInfoFormat));

			followupCenterBN.Filter= string.Format(" ((RemindDate<='{0}' and RemindDate>'{1}') or (RemindDate2<='{0}' and RemindDate2>'{1}') or (RemindDate3<='{0}' and RemindDate3>'{1}')) ",strToday,strMinDate);
			dt = followupCenterBN.GetList();
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
				CSFollowupCenterDT followupCenterDT = null;
				if(rowView==null)
				{
					return;
				}
				else
				{
					followupCenterDT = new CSFollowupCenterBN(this.Page).Get(Convert.ToInt32(rowView["FollowupID"]));
				}
				
				if(followupCenterDT!=null)
				{
					Literal litStatus = e.Item.FindControl("litStatus") as Literal;
					if(litStatus!=null)
					{
						litStatus.Text = Convert.ToString(followupCenterDT.FollowupStatus);
					}

					Literal LitActionDueDate= e.Item.FindControl("LitActionDueDate") as Literal;
					if(LitActionDueDate!=null&& followupCenterDT.RemindDate>new DateTime(1753,1,2))
					{
						LitActionDueDate.Text= followupCenterDT.RemindDate.ToString("dd-MM-yyyy");
					}
					
					if(followupCenterDT.UserID>0)
					{
						HuiyuanBN huiyuanBN= new HuiyuanBN(this.Page);
						HuiyuanDT huiyuanDT = huiyuanBN.Get(followupCenterDT.UserID);
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

