namespace YingNet.WeiXing.WebApp.manage.AdminManage
{
    using System;
    using System.Web.UI.HtmlControls;
    using System.Web.UI.WebControls;
    using YingNet.Common;
    using YingNet.WeiXing.Business;
    using YingNet.WeiXing.DB.Data;

    public class PermissionInfo : ManageBasePage2
    {
        protected HtmlInputButton Add;
        protected PermissionCheckBoxList cblFollowupCenter;
        protected PermissionCheckBoxList cblLFollowupCenter;
        protected PermissionCheckBoxList cblLProcessCenter;
        protected PermissionCheckBoxList cblManagerInfo;
        protected PermissionCheckBoxList cblPaydayInfo;
        protected PermissionCheckBoxList cblProcessCenter;
        private int currentDualedUserID = 0;
        protected Label labUserName;

        private void Add_ServerClick(object sender, EventArgs e)
        {
            bool flag = false;
            int num = 0;
            for (int i = 0; i < this.cblProcessCenter.Items.Count; i++)
            {
                if (this.cblProcessCenter.Items[i].Selected)
                {
                    num += Convert.ToInt32(this.cblProcessCenter.Items[i].Value);
                }
            }
            int num3 = 0;
            for (int j = 0; j < this.cblLProcessCenter.Items.Count; j++)
            {
                if (this.cblLProcessCenter.Items[j].Selected)
                {
                    num3 += Convert.ToInt32(this.cblLProcessCenter.Items[j].Value);
                }
            }
            int num5 = 0;
            for (int k = 0; k < this.cblFollowupCenter.Items.Count; k++)
            {
                if (this.cblFollowupCenter.Items[k].Selected)
                {
                    num5 += Convert.ToInt32(this.cblFollowupCenter.Items[k].Value);
                }
            }
            int num7 = 0;
            for (int m = 0; m < this.cblLFollowupCenter.Items.Count; m++)
            {
                if (this.cblLFollowupCenter.Items[m].Selected)
                {
                    num7 += Convert.ToInt32(this.cblLFollowupCenter.Items[m].Value);
                }
            }
            int num9 = 0;
            for (int n = 0; n < this.cblManagerInfo.Items.Count; n++)
            {
                if (this.cblManagerInfo.Items[n].Selected)
                {
                    num9 += Convert.ToInt32(this.cblManagerInfo.Items[n].Value);
                }
            }
            int num11 = 0;
            for (int num12 = 0; num12 < this.cblPaydayInfo.Items.Count; num12++)
            {
                if (this.cblPaydayInfo.Items[num12].Selected)
                {
                    num11 += Convert.ToInt32(this.cblPaydayInfo.Items[num12].Value);
                }
            }
            CSUserPermissionBN nbn = new CSUserPermissionBN(this.Page);
            CSUserPermissionDT dt = nbn.Get(this.currentDualedUserID);
            if ((dt == null) || (dt.UserID < 0))
            {
                flag = true;
                dt = new CSUserPermissionDT();
            }
            dt.UserID = this.currentDualedUserID;
            dt.PermissionProcessCenter = num;
            dt.PermissionLProcessCenter = num3;
            dt.PermissionFollowupCenter = num5;
            dt.PermissionLFollowupCenter = num7;
            dt.PermissionPaydayInfo = num11;
            dt.PermissionManagerInfo = num9;
            if (flag)
            {
                nbn.Add(dt);
            }
            else
            {
                nbn.Edit(dt);
            }
            base.Response.Redirect("AdminList.aspx");
        }

        private void InitializeComponent()
        {
            this.Add.ServerClick += new EventHandler(this.Add_ServerClick);
            base.Load += new EventHandler(this.Page_Load);
        }

        private void LoadUserInfo()
        {
            if (this.currentDualedUserID > 0)
            {
                CSUserDT rdt = new CSUserBN(this.Page).Get(this.currentDualedUserID);
                if (rdt != null)
                {
                    this.labUserName.Text = rdt.UserName;
                    CSUserPermissionDT ndt = new CSUserPermissionBN(this.Page).Get(this.currentDualedUserID);
                    if ((ndt != null) && (ndt.UserID >= 0))
                    {
                        CommonOperateEnum permissionProcessCenter = (CommonOperateEnum) ndt.PermissionProcessCenter;
                        this.LoadUserModulePermission(permissionProcessCenter, this.cblProcessCenter);
                        CommonOperateEnum permissionLProcessCenter = (CommonOperateEnum) ndt.PermissionLProcessCenter;
                        this.LoadUserModulePermission(permissionLProcessCenter, this.cblLProcessCenter);
                        CommonOperateEnum permissionFollowupCenter = (CommonOperateEnum) ndt.PermissionFollowupCenter;
                        this.LoadUserModulePermission(permissionFollowupCenter, this.cblFollowupCenter);
                        CommonOperateEnum permissionLFollowupCenter = (CommonOperateEnum) ndt.PermissionLFollowupCenter;
                        this.LoadUserModulePermission(permissionLFollowupCenter, this.cblLFollowupCenter);
                        CommonOperateEnum permissionPaydayInfo = (CommonOperateEnum) ndt.PermissionPaydayInfo;
                        this.LoadUserModulePermission(permissionPaydayInfo, this.cblPaydayInfo);
                        CommonOperateEnum permissionManagerInfo = (CommonOperateEnum) ndt.PermissionManagerInfo;
                        this.LoadUserModulePermission(permissionManagerInfo, this.cblManagerInfo);
                    }
                }
            }
        }

        private void LoadUserModulePermission(CommonOperateEnum commonOperate, PermissionCheckBoxList permissionCheckBoxList)
        {
            if ((commonOperate & CommonOperateEnum.ReadOnly) != 0)
            {
                int num = 2;
                ListItem item = permissionCheckBoxList.Items.FindByValue(num.ToString());
                if (item != null)
                {
                    item.Selected = true;
                }
            }
            if ((commonOperate & CommonOperateEnum.CreateEdit) != 0)
            {
                int num2 = 4;
                ListItem item2 = permissionCheckBoxList.Items.FindByValue(num2.ToString());
                if (item2 != null)
                {
                    item2.Selected = true;
                }
            }
            if ((commonOperate & CommonOperateEnum.List) != 0)
            {
                int num3 = 1;
                ListItem item3 = permissionCheckBoxList.Items.FindByValue(num3.ToString());
                if (item3 != null)
                {
                    item3.Selected = true;
                }
            }
            if ((commonOperate & CommonOperateEnum.Delete) != 0)
            {
                int num4 = 8;
                ListItem item4 = permissionCheckBoxList.Items.FindByValue(num4.ToString());
                if (item4 != null)
                {
                    item4.Selected = true;
                }
            }
            if ((commonOperate & CommonOperateEnum.Manage) != 0)
            {
                int num5 = 0x10;
                ListItem item5 = permissionCheckBoxList.Items.FindByValue(num5.ToString());
                if (item5 != null)
                {
                    item5.Selected = true;
                }
            }
            if ((commonOperate & CommonOperateEnum.DocumentCheckList) != 0)
            {
                int num6 = 0x20;
                ListItem item6 = permissionCheckBoxList.Items.FindByValue(num6.ToString());
                if (item6 != null)
                {
                    item6.Selected = true;
                }
            }
            if ((commonOperate & CommonOperateEnum.DetailsVerification) != 0)
            {
                int num7 = 0x80;
                ListItem item7 = permissionCheckBoxList.Items.FindByValue(num7.ToString());
                if (item7 != null)
                {
                    item7.Selected = true;
                }
            }
            if ((commonOperate & CommonOperateEnum.PreApproval) != 0)
            {
                int num8 = 0x40;
                ListItem item8 = permissionCheckBoxList.Items.FindByValue(num8.ToString());
                if (item8 != null)
                {
                    item8.Selected = true;
                }
            }
            if ((commonOperate & CommonOperateEnum.FinalApproval) != 0)
            {
                int num9 = 0x100;
                ListItem item9 = permissionCheckBoxList.Items.FindByValue(num9.ToString());
                if (item9 != null)
                {
                    item9.Selected = true;
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
                this.currentDualedUserID = Convert.ToInt32(base.Request.QueryString["userID"]);
            }
            catch
            {
            }
            if (!base.IsPostBack)
            {
                this.LoadUserInfo();
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
                return FunnctionModuleEnum.ManagerInfo;
            }
            set
            {
                base.FunnctionModuleName = value;
            }
        }
    }
}

