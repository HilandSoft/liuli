namespace YingNet.WeiXing.WebApp.manage.Long
{
    using System;
    using System.Text;
    using System.Web.UI.WebControls;
    using YingNet.WeiXing.Business;
    using YingNet.WeiXing.Business.CommonLogic;

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
                if (CommonInformation.CurrentVersion > 2)
                {
                    builder.AppendFormat(format, "b2", "<a href='javascript:jumps(\"LProcessList.aspx\")'> ProcessCenter </a>");
                }
                builder.AppendFormat(format, "a10", "<a href='javascript:jumps(\"renew.aspx\")'> Member Renew </a>");
                builder.AppendFormat(format, "a11", "<a href='javascript:jumps(\"LongList.aspx\")'> Long Term </a>");
                builder.AppendFormat(format, "a12", "<a href='javascript:jumps(\"ParamsSet.aspx\")'> Long Term Set </a>");
                this.litMenu.Text = builder.ToString();
            }
        }
    }
}

