namespace YingNet.WeiXing.WebApp.manage.FollowupCenter
{
    using System;
    using System.Text;
    using System.Web.UI.WebControls;
    using YingNet.WeiXing.Business;

    public class MainTop : ManageBasePage
    {
        protected Literal litLogUserAccount;
        protected Literal litMenu;

        private void InitializeComponent()
        {
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
                this.ShowMenu();
            }
        }

        private void ShowMenu()
        {
            if ((base.SystemUserAccount != null) && (base.SystemUserAccount != string.Empty))
            {
                this.litLogUserAccount.Text = string.Format("[{0}]", base.SystemUserAccount);
            }
            if (base.SystemUserID != 0)
            {
                string format = "<td id=\"{0}\" width=\"80\" align=\"center\" class=\"wnd_label_active\" onmouseover=\"onOverWndLabel()\" onmouseout=\"onOutWndLabel()\" onclick=\"onClickWndLabel()\"><nobr>{1}</nobr></td><td width=\"1\" bgcolor=\"#000000\" class=\"wnd_label_normal\"></td>";
                StringBuilder builder = new StringBuilder();
                builder.AppendFormat(format, "a0", "<a href='javascript:jumps(\"../MainHome.aspx\")'>Home&nbsp;&nbsp;</a>");
                builder.AppendFormat(format, "b0", "<a href='javascript:jumps(\"FollowupStat.aspx\")'>Stat&nbsp;&nbsp;</a>");
                builder.AppendFormat(format, "c0", "<a href='javascript:jumps(\"FollowupList.aspx?status=0\")'>Everyday&nbsp;&nbsp;</a>");
                builder.AppendFormat(format, "c1", "<a href='javascript:jumps(\"FollowupList.aspx?status=10\")'>ByDate&nbsp;&nbsp;</a>");
                builder.AppendFormat(format, "c2", "<a href='javascript:jumps(\"FollowupList.aspx?status=20\")'>Scheduled&nbsp;&nbsp;</a>");
                builder.AppendFormat(format, "c3", "<a href='javascript:jumps(\"FollowupList.aspx?status=30\")'>Re-DDed&nbsp;&nbsp;</a>");
                builder.AppendFormat(format, "c4", "<a href='javascript:jumps(\"FollowupList.aspx?status=40\")'>DefaultLetter&nbsp;&nbsp;</a>");
                builder.AppendFormat(format, "c5", "<a href='javascript:jumps(\"FollowupList.aspx?status=50\")'>FinalNotice&nbsp;&nbsp;</a>");
                builder.AppendFormat(format, "c6", "<a href='javascript:jumps(\"FollowupList.aspx?status=60\")'>Collection&nbsp;&nbsp;</a>");
                builder.AppendFormat(format, "c7", "<a href='javascript:jumps(\"FollowupList.aspx?status=70\")'>OnHold&nbsp;&nbsp;</a>");
                builder.AppendFormat(format, "c8", "<a href='javascript:jumps(\"FollowupList.aspx?status=80\")'>AwaitingResult(P9)&nbsp;&nbsp;</a>");
                builder.AppendFormat(format, "c9", "<a href='javascript:jumps(\"FollowupList.aspx?status=90\")'>AwaitingDividends(P9)&nbsp;&nbsp;</a>");
                builder.AppendFormat(format, "c10", "<a href='javascript:jumps(\"FollowupList.aspx?status=100\")'>BlackList</a>");
                this.litMenu.Text = builder.ToString();
            }
        }
    }
}

