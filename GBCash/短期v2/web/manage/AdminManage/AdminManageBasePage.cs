namespace YingNet.WeiXing.WebApp.manage.AdminManage
{
    using System;
    using YingNet.Common;
    using YingNet.WeiXing.Business;

    public class AdminManageBasePage : ManageBasePage2
    {
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

