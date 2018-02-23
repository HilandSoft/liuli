namespace YingNet.WeiXing.WebApp.manage.FollowupCenter
{
    using System;
    using System.Web.UI.WebControls;
    using YingNet.Common;
    using YingNet.Common.Utils;
    using YingNet.WeiXing.Business;
    using YingNet.WeiXing.DB.Data;

    public class FollowupInfo : ManageBasePage2
    {
        protected Button bnReturn;
        protected Button bnSave;
        protected Button btnSave;
        protected CheckBox cbRemindEnable;
        protected DropDownList ddlChooseFollowupStatus;
        private int followupID = 0;
        protected string status = "0";
        protected TextBox tbDay;
        protected TextBox tbMonth;
        protected TextBox tbYear;
        protected TextBox txPerSid;
        protected TextBox txSid;

        private void BindStatus()
        {
            ListItem item = new ListItem(Convert.ToString(FollowupCenterStatusEnum.FollowupEveryday), Convert.ToInt32(FollowupCenterStatusEnum.FollowupEveryday).ToString());
            this.ddlChooseFollowupStatus.Items.Add(item);
            ListItem item2 = new ListItem(Convert.ToString(FollowupCenterStatusEnum.FollowupByDate), Convert.ToInt32(FollowupCenterStatusEnum.FollowupByDate).ToString());
            this.ddlChooseFollowupStatus.Items.Add(item2);
            ListItem item3 = new ListItem(Convert.ToString(FollowupCenterStatusEnum.Collection), Convert.ToInt32(FollowupCenterStatusEnum.Collection).ToString());
            this.ddlChooseFollowupStatus.Items.Add(item3);
            ListItem item4 = new ListItem(Convert.ToString(FollowupCenterStatusEnum.DefaultLetter), Convert.ToInt32(FollowupCenterStatusEnum.DefaultLetter).ToString());
            this.ddlChooseFollowupStatus.Items.Add(item4);
            ListItem item5 = new ListItem(Convert.ToString(FollowupCenterStatusEnum.FinalNotice), Convert.ToInt32(FollowupCenterStatusEnum.FinalNotice).ToString());
            this.ddlChooseFollowupStatus.Items.Add(item5);
            ListItem item6 = new ListItem(Convert.ToString(FollowupCenterStatusEnum.OnHold), Convert.ToInt32(FollowupCenterStatusEnum.OnHold).ToString());
            this.ddlChooseFollowupStatus.Items.Add(item6);
            ListItem item7 = new ListItem(Convert.ToString(FollowupCenterStatusEnum.Part9AwaitingDividends), Convert.ToInt32(FollowupCenterStatusEnum.Part9AwaitingDividends).ToString());
            this.ddlChooseFollowupStatus.Items.Add(item7);
            ListItem item8 = new ListItem(Convert.ToString(FollowupCenterStatusEnum.Part9AwaitingResult), Convert.ToInt32(FollowupCenterStatusEnum.Part9AwaitingResult).ToString());
            this.ddlChooseFollowupStatus.Items.Add(item8);
            ListItem item9 = new ListItem(Convert.ToString(FollowupCenterStatusEnum.ReDDed), Convert.ToInt32(FollowupCenterStatusEnum.ReDDed).ToString());
            this.ddlChooseFollowupStatus.Items.Add(item9);
            ListItem item10 = new ListItem(Convert.ToString(FollowupCenterStatusEnum.ScheduledPayment), Convert.ToInt32(FollowupCenterStatusEnum.ScheduledPayment).ToString());
            this.ddlChooseFollowupStatus.Items.Add(item10);
            ListItem item11 = new ListItem(Convert.ToString(FollowupCenterStatusEnum.BlackList), Convert.ToInt32(FollowupCenterStatusEnum.BlackList).ToString());
            this.ddlChooseFollowupStatus.Items.Add(item11);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            CSFollowupCenterBN rbn = new CSFollowupCenterBN(this.Page);
            CSFollowupCenterDT dt = rbn.Get(this.followupID);
            int year = 0x6d9;
            int month = 1;
            int day = 2;
            if (this.tbDay.Text.Trim() != string.Empty)
            {
                try
                {
                    day = int.Parse(this.tbDay.Text.Trim());
                }
                catch
                {
                }
            }
            if (this.tbMonth.Text.Trim() != string.Empty)
            {
                try
                {
                    month = int.Parse(this.tbMonth.Text.Trim());
                }
                catch
                {
                }
            }
            if (this.tbYear.Text.Trim() != string.Empty)
            {
                try
                {
                    year = int.Parse(this.tbYear.Text.Trim());
                }
                catch
                {
                }
            }
            dt.RemindDate = new DateTime(year, month, day);
            dt.RemindEnable = this.cbRemindEnable.Checked;
            dt.PreviewStatus = dt.FollowupStatus;
            dt.FollowupStatus = (FollowupCenterStatusEnum) int.Parse(this.ddlChooseFollowupStatus.SelectedValue);
            dt.LastOperateDate = SafeDateTime.LocalNow;
            rbn.Edit(dt);
            base.Response.Redirect("FollowupList.aspx?status=" + this.status);
        }

        private void InitializeComponent()
        {
            this.btnSave.Click += new EventHandler(this.btnSave_Click);
            base.Load += new EventHandler(this.Page_Load);
        }

        private void LoadInfo()
        {
            CSFollowupCenterDT rdt = new CSFollowupCenterBN(this.Page).Get(this.followupID);
            if (rdt != null)
            {
                this.ddlChooseFollowupStatus.SelectedValue = ((int) rdt.FollowupStatus).ToString();
                this.cbRemindEnable.Checked = rdt.RemindEnable;
                if (rdt.RemindDate > new DateTime(0x6d9, 1, 2))
                {
                    this.tbYear.Text = rdt.RemindDate.Year.ToString();
                    this.tbMonth.Text = rdt.RemindDate.Month.ToString();
                    this.tbDay.Text = rdt.RemindDate.Day.ToString();
                }
            }
        }

        protected override void OnInit(EventArgs e)
        {
            this.InitializeComponent();
            base.OnInit(e);
        }

        private void Page_Load(object sender, EventArgs e)
        {
            this.followupID = Convert.ToInt32(base.Request.QueryString["followupID"]);
            this.status = base.Request.QueryString["status"];
            if (!base.IsPostBack)
            {
                this.BindStatus();
                this.LoadInfo();
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
    }
}

