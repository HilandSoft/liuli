namespace YingNet.WeiXing.WebApp.manage.Long
{
    using System;
    using System.Web.UI;
    using System.Web.UI.HtmlControls;
    using System.Web.UI.WebControls;
    using YingNet.Common.Utils;
    using YingNet.WeiXing.Business;
    using YingNet.WeiXing.DB.Data;

    public class SendToProcessCenter : Page
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
                this.LabMsg.Text = "This item will be sent to ProcessCenter. Do you want to continue?";
            }
        }

        private void returnmain_ServerClick(object sender, EventArgs e)
        {
            int num = Convert.ToInt32(this.TextBox1.Text);
            CSProcessCenterBN rbn = new CSProcessCenterBN(this.Page);
            CSProcessCenterDT dt = new CSProcessCenterDT();
            dt.ConversationTrack = string.Empty;
            dt.IsFirstLoan = true;
            dt.LoanID = 0;
            dt.PostDate = SafeDateTime.LocalNow;
            dt.ProcessStatus = ProcessCenterStatusEnum.Pending;
            dt.UserID = num;
            dt.UserLoanType = UserLoanTypes.Long;
            dt.LastOperateDate = SafeDateTime.LocalNow;
            rbn.Add(dt);
            base.Response.Write("<script>alert('Success!');window.location.href='LongList.aspx';</script>");
        }
    }
}

