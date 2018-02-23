namespace YingNet.WeiXing.Business
{
    using System;
    using System.Data;
    using System.Web;
    using System.Web.UI;
    using System.Web.UI.WebControls;
    using YingNet.Common;
    using YingNet.Common.Database;

    public class BaseBusiness : CommonBaseBusiness
    {
        protected Page page;
        public const string PARAM_NAME = "paramstr";
        public const string SESSION_ADMIN_ACCOUNT = "Admin.Account";
        public const string SESSION_ADMIN_ID = "Admin.ID";
        public const string SESSION_ADMIN_NAME = "Admin.Name";
        public const string SESSION_DesignerID = "User.DesignerID";
        public const string SESSION_USER_ACCOUNT = "User.Account";
        public const string SESSION_USER_COMPANYACCOUNT = "Company.Account";
        public const string SESSION_USER_COMPANYID = "Company.ID";
        public const string SESSION_USER_COMPANYNAME = "Company.Name";
        public const string SESSION_USER_ID = "User.ID";
        public const string SESSION_USER_NAME = "User.Name";
        public const string SESSION_USER_Permission = "User.Permission";
        public const string SESSION_USER_Type = "User.Type";

        public BaseBusiness() : base(BaseConfManager.GetDBServer(), BaseConfManager.GetDBName(), BaseConfManager.GetDBUser(), BaseConfManager.GetDBPwd(), int.Parse(BaseConfManager.GetDBType()))
        {
            this.page = null;
            this.page = (Page) HttpContext.Current.Handler;
        }

        public BaseBusiness(Page page) : base(BaseConfManager.GetDBServer(), BaseConfManager.GetDBName(), BaseConfManager.GetDBUser(), BaseConfManager.GetDBPwd(), int.Parse(BaseConfManager.GetDBType()))
        {
            this.page = null;
            this.page = page;
        }

        public BaseBusiness(DBOperate dbOper) : base(dbOper)
        {
            this.page = null;
            this.page = this.page;
        }

        public BaseBusiness(Page page, DBOperate dbOper) : base(dbOper)
        {
            this.page = null;
            this.page = page;
        }

        public static void AutoSetPage(int pageSize, DataGrid dg, DataTable dt)
        {
            dg.PageSize = pageSize;
            CommonBaseBusiness.SetPage(dg, dt);
        }

        public static DBOperate GetDBOperate()
        {
            return DBOperatorFactory.GetDBOperator(BaseConfManager.GetDBServer(), BaseConfManager.GetDBName(), BaseConfManager.GetDBUser(), BaseConfManager.GetDBPwd(), int.Parse(BaseConfManager.GetDBType()));
        }

        public static void SetPage(DataGrid dg, DataTable dt)
        {
            dg.PageSize = 12;
            CommonBaseBusiness.SetPage(dg, dt);
        }
    }
}

