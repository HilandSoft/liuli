namespace YingNet.WeiXing.WebApp.manage
{
    using System;
    using System.Web.UI;
    using System.Web.UI.HtmlControls;
    using System.Web.UI.WebControls;
    using YingNet.Common.Utils;
    using YingNet.WeiXing.Business;
    using YingNet.WeiXing.DB.Data;

    public class SendToFollowupCenter : Page
    {
        protected Label LabMsg;
        protected HtmlInputButton returnmain;
        protected TextBox TextBox1;
        protected TextBox txtParamstr;

        private void InitializeComponent()
        {
            this.returnmain.ServerClick += new EventHandler(this.returnmain_ServerClick);
            base.Load += new EventHandler(this.Page_Load);
        }

        protected override void OnInit(EventArgs e)
        {
            this.InitializeComponent();
            base.OnInit(e);
        }

        private void Page_Load(object sender, EventArgs e)
        {
            if (!base.IsPostBack && (base.Request["id"] != null))
            {
                this.TextBox1.Text = base.Request["id"];
                this.LabMsg.Text = "This item will be sent to FollowupCenter. Do you want to continue?";
            }
        }

        private void returnmain_ServerClick(object sender, EventArgs e)
        {
            int num = Convert.ToInt32(this.TextBox1.Text);
            CSFollowupCenterBN rbn = new CSFollowupCenterBN(this.Page);
            CSFollowupCenterDT dt = new CSFollowupCenterDT();
            dt.FollowupStatus = FollowupCenterStatusEnum.FollowupEveryday;
            dt.LastOperateDate = SafeDateTime.LocalNow;
            dt.PostDate = SafeDateTime.LocalNow;
            dt.RemindEnable = true;
            dt.UserID = num;
            dt.UserLoanType = UserLoanTypes.Short;
            dt.TaskInformation = string.Empty;
            dt.RemindDate = new DateTime(0x6d9, 1, 2);
            dt.RemindDate2 = new DateTime(0x6d9, 1, 2);
            dt.RemindDate3 = new DateTime(0x6d9, 1, 2);
            rbn.Add(dt);
            base.Response.Write("<script>alert('Success!');window.location.href='MemberList.aspx';</script>");
        }
    }
}

