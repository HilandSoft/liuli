namespace YingNet.WeiXing.Business
{
    using System;
    using System.Web;
    using YingNet.Common;
    using YingNet.WeiXing.DB.Data;

    public class ManageBasePage : CommonBasePage
    {
        private string m_code = "";
        private SystemRoles systemRole = SystemRoles.Manage;
        private string systemUserAccount = string.Empty;
        private int systemUserID = 0;
        private string systemUserName = string.Empty;

        protected void CheckLogin()
        {
            string str = HttpContext.Current.Request.Cookies["SystemUserID"].Value;
            int num = 0;
            if ((str != null) && (str != string.Empty))
            {
                num = Convert.ToInt32(str);
            }
            if (num <= 0)
            {
                base.Response.Redirect("NotLogin.aspx");
            }
            else
            {
                this.SystemUserAccount = HttpContext.Current.Request.Cookies["SystemUserAccount"].Value;
                this.SystemUserID = num;
                this.SystemUserName = HttpContext.Current.Request.Cookies["SystemUserName"].Value;
            }
        }

        protected void CheckPerm()
        {
        }

        protected override void OnInit(EventArgs e)
        {
            base.Response.Expires = 0;
            base.OnInit(e);
            this.CheckLogin();
            this.CheckPerm();
        }

        protected void ShowDialog(string url, string height, string width)
        {
            base.Response.Write("<script language='javascript'>");
            base.Response.Write("window.showModalDialog('" + url + "','','height: " + height + "; width: " + width + "; edge: Raised; center: Yes; help: No; resizable: No; status: No;');");
            base.Response.Write("</script>");
        }

        protected void ShowDialog(string url, string location, string height, string width)
        {
            base.Response.Write("<script language='javascript'>");
            base.Response.Write("window.showModalDialog('" + url + "','','height: " + height + "; width: " + width + "; edge: Raised; center: Yes; help: No; resizable: No; status: No;');");
            base.Response.Write("window.location = '" + location + "';");
            base.Response.Write("</script>");
        }

        protected void ShowWindow(string url, string height, string width)
        {
            base.Response.Write("<script language='javascript'>");
            base.Response.Write("window.open('" + url + "',null,'height=" + height + ",width=" + width + ",left=((window.screen.width-" + width + ")/2),channelmode=no,directories=no,fullscreen=no,location=no,menubar=no,resizable=no,scrollbars=no,status=no,titlebar=no,toolbar=no');");
            base.Response.Write("</script>");
        }

        protected void ShowWindow(string url, string location, string height, string width)
        {
            if (location == "")
            {
                this.ShowWindow(url, height, width);
            }
            else
            {
                base.Response.Write("<script language='javascript'>");
                base.Response.Write("window.open('" + url + "',null,'height=" + height + ",width=" + width + ",left=((window.screen.width-" + width + ")/2),channelmode=no,directories=no,fullscreen=no,location=no,menubar=no,resizable=no,scrollbars=no,status=no,titlebar=no,toolbar=no');");
                base.Response.Write("window.location = '" + location + "';");
                base.Response.Write("</script>");
            }
        }

        public string Code
        {
            get
            {
                return this.m_code;
            }
            set
            {
                this.m_code = value;
            }
        }

        public SystemRoles SystemRole
        {
            get
            {
                return this.systemRole;
            }
            set
            {
                this.systemRole = value;
            }
        }

        public string SystemUserAccount
        {
            get
            {
                return this.systemUserAccount;
            }
            set
            {
                this.systemUserAccount = value;
            }
        }

        public int SystemUserID
        {
            get
            {
                return this.systemUserID;
            }
            set
            {
                this.systemUserID = value;
            }
        }

        public string SystemUserName
        {
            get
            {
                return this.systemUserName;
            }
            set
            {
                this.systemUserName = value;
            }
        }

        public string WebAppTitle
        {
            get
            {
                return "CashSolution Manage Console";
            }
        }
    }
}

