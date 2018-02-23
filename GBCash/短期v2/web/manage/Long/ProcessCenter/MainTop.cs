namespace YingNet.WeiXing.WebApp.manage.Long.ProcessCenter
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
                builder.AppendFormat(format, "a0", "<a href='javascript:jumps(\"../../MainHome.aspx\")'>Home </a>");
                builder.AppendFormat(format, "b2", "<a href='javascript:jumps(\"ProcessList.aspx\")'>ProcessCenter </a>");
                this.litMenu.Text = builder.ToString();
            }
        }
    }
}

