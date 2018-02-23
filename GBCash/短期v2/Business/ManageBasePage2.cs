namespace YingNet.WeiXing.Business
{
    using System;
    using YingNet.Common;
    using YingNet.WeiXing.DB.Data;

    public class ManageBasePage2 : ManageBasePage
    {
        private CommonOperateEnum commonOperate = CommonOperateEnum.All;
        private FunnctionModuleEnum funnctionModuleName = FunnctionModuleEnum.None;
        private bool isNeedValidate = true;

        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);
            this.ValitadePermission();
        }

        protected void ValitadePermission()
        {
            if ((this.IsNeedValidate && (base.SystemUserAccount.ToLower() != "superlily")) && (this.FunnctionModuleName != FunnctionModuleEnum.None))
            {
                bool flag = true;
                if (this.UserPermission != null)
                {
                    switch (this.FunnctionModuleName)
                    {
                        case FunnctionModuleEnum.ProcessCenter:
                            flag = this.ValitadePermissionOperate((CommonOperateEnum) this.UserPermission.PermissionProcessCenter, this.CommonOperate);
                            break;

                        case FunnctionModuleEnum.FollowupCenter:
                            flag = this.ValitadePermissionOperate((CommonOperateEnum) this.UserPermission.PermissionFollowupCenter, this.CommonOperate);
                            break;

                        case FunnctionModuleEnum.ManagerInfo:
                            flag = this.ValitadePermissionOperate((CommonOperateEnum) this.UserPermission.PermissionManagerInfo, this.CommonOperate);
                            break;

                        case FunnctionModuleEnum.PaydayInfo:
                            flag = this.ValitadePermissionOperate((CommonOperateEnum) this.UserPermission.PermissionPaydayInfo, this.CommonOperate);
                            break;

                        case FunnctionModuleEnum.LProcessCenter:
                            flag = this.ValitadePermissionOperate((CommonOperateEnum) this.UserPermission.PermissionLProcessCenter, this.CommonOperate);
                            break;

                        case FunnctionModuleEnum.LFollowupCenter:
                            flag = this.ValitadePermissionOperate((CommonOperateEnum) this.UserPermission.PermissionLFollowupCenter, this.CommonOperate);
                            break;
                    }
                }
                else
                {
                    flag = false;
                }
                if (!flag)
                {
                    base.Response.Redirect("~/manage/NoPermission.aspx");
                }
            }
        }

        protected virtual bool ValitadePermissionOperate(CommonOperateEnum operatesOwned, CommonOperateEnum operateNeedValited)
        {
            return ((base.SystemUserAccount.ToLower() == "superlily") || (((operatesOwned & CommonOperateEnum.Manage) != 0) || ((operatesOwned & operateNeedValited) != 0)));
        }

        protected virtual CommonOperateEnum CommonOperate
        {
            get
            {
                return this.commonOperate;
            }
            set
            {
                this.commonOperate = value;
            }
        }

        protected virtual FunnctionModuleEnum FunnctionModuleName
        {
            get
            {
                return this.funnctionModuleName;
            }
            set
            {
                this.funnctionModuleName = value;
            }
        }

        protected virtual bool IsNeedValidate
        {
            get
            {
                return this.isNeedValidate;
            }
            set
            {
                this.isNeedValidate = value;
            }
        }

        protected CSUserPermissionDT UserPermission
        {
            get
            {
                CSUserPermissionBN nbn = new CSUserPermissionBN(this.Page);
                return nbn.Get(base.SystemUserID);
            }
        }
    }
}

