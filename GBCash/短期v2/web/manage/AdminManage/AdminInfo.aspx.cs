namespace YingNet.WeiXing.WebApp.manage.AdminManage
{
    using System;
    using System.Web.UI.HtmlControls;
    using System.Web.UI.WebControls;
    using YingNet.Common;
    using YingNet.Common.Utils;
    using YingNet.WeiXing.Business;
    using YingNet.WeiXing.DB.Data;

    public class AdminInfo : ManageBasePage2
    {
        protected HtmlInputButton Add;
        protected CheckBox chbEnable;
        protected CompareValidator CompareValidator1;
        private int currentUserID;
        protected TextBox txtPassword;
        protected TextBox txtPassword2;
        protected TextBox txtUserName;

        private void Add_ServerClick(object sender, EventArgs e)
        {
            bool flag = true;
            CSUserDT dt = null;
            CSUserBN rbn = new CSUserBN(this.Page);
            if (this.currentUserID > 0)
            {
                dt = rbn.Get(this.currentUserID);
                if (dt != null)
                {
                    if (this.chbEnable.Checked)
                    {
                        dt.Enable = 1;
                    }
                    else
                    {
                        dt.Enable = 0;
                    }
                    if (this.txtPassword.Text != string.Empty)
                    {
                        dt.Password = Cipher.EncryptMD5(this.txtPassword.Text);
                    }
                    dt.UserName = this.txtUserName.Text;
                    rbn.Edit(dt);
                }
            }
            else
            {
                dt = new CSUserDT();
                rbn.Filter = string.Format("userName = '{0}'", this.txtUserName.Text);
                if (rbn.GetList().Rows.Count > 0)
                {
                    flag = false;
                    base.Response.Write("<script>alert('There was same UserName already.Try another userName again please!');</script>");
                }
                else
                {
                    dt.DateCreated = SafeDateTime.LocalNow;
                    dt.Email = string.Empty;
                    if (this.chbEnable.Checked)
                    {
                        dt.Enable = 1;
                    }
                    else
                    {
                        dt.Enable = 0;
                    }
                    dt.Nickname = string.Empty;
                    dt.Password = Cipher.EncryptMD5(this.txtPassword.Text);
                    dt.PasswordFormat = 0;
                    dt.PasswordSalt = string.Empty;
                    dt.UserClass = string.Empty;
                    dt.UserName = this.txtUserName.Text;
                    dt.UserRank = 0;
                    dt.UserType = 0;
                    dt.LastLoginDate = new DateTime(0x6d9, 1, 2);
                    rbn.Add(dt);
                }
            }
            if (flag)
            {
                base.Response.Redirect("AdminList.aspx");
            }
        }

        private void InitializeComponent()
        {
            this.Add.ServerClick += new EventHandler(this.Add_ServerClick);
            base.Load += new EventHandler(this.Page_Load);
        }

        private void LoadUserInfo()
        {
            if ((this.currentUserID > 0) && !base.IsPostBack)
            {
                CSUserDT rdt = new CSUserBN(this.Page).Get(this.currentUserID);
                if (rdt != null)
                {
                    this.txtUserName.Text = rdt.UserName;
                    this.txtUserName.ReadOnly = true;
                    if (rdt.Enable == 1)
                    {
                        this.chbEnable.Checked = true;
                    }
                    else
                    {
                        this.chbEnable.Checked = false;
                    }
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
            try
            {
                this.currentUserID = int.Parse(base.Request.QueryString["userID"]);
            }
            catch
            {
            }
            this.LoadUserInfo();
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
                return FunnctionModuleEnum.ManagerInfo;
            }
            set
            {
                base.FunnctionModuleName = value;
            }
        }
    }
}

