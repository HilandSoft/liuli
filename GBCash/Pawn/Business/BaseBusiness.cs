using System;
using System.Collections;
using System.Data;
using System.Web;
using System.Web.UI;

using YingNet.Common;
using YingNet.Common.Database;

namespace YingNet.WeiXing.Business
{
	/// <summary>
	/// BaseBusiness 的摘要说明。
	/// </summary>
	public class BaseBusiness:CommonBaseBusiness 
	{

		/// <summary>
		/// 登录人id的session名称
		/// </summary>
		public  const string SESSION_USER_ID = "User.ID";
		public  const string SESSION_ADMIN_ID = "Admin.ID";

		//企业会员所属公司
		public  const string SESSION_USER_COMPANYID="Company.ID";

		/// <summary>
		/// 登录人账号的session名称
		/// </summary>
		public  const string SESSION_USER_ACCOUNT = "User.Account";
		public  const string SESSION_ADMIN_ACCOUNT = "Admin.Account";
		public const string SESSION_USER_COMPANYACCOUNT="Company.Account";
      
		/// <summary>
		/// 登录人姓名的session名称
		/// </summary>
		public  const string SESSION_USER_NAME = "User.Name";
		public  const string SESSION_ADMIN_NAME = "Admin.Name";
		public const string SESSION_USER_COMPANYNAME="Company.Name";


		public  const string PARAM_NAME = CommonBasePage.PARAM_NAME;
		/// <summary>
		/// 登录人权限的session
		/// </summary>
		public  const string SESSION_USER_Permission = "User.Permission";
		/// <summary>
		/// 登录人所属会员类型的session
		/// </summary>
		public  const string SESSION_USER_Type = "User.Type";

		/// <summary>
		/// 设计师会员类型的session设计师id
		/// </summary>
		public  const string SESSION_DesignerID = "User.DesignerID";
		/// <summary>
		/// web页面
		/// </summary>
		protected Page page = null;

		/*//=======================================================================
		// ***** [ADDED BY DoItNow,2004/7/22]
		//-----------------------------------------------------------------------
		public BaseBusiness () : base(BaseConfManager.GetDBServer(),BaseConfManager.GetDBName(),BaseConfManager.GetDBUser(),BaseConfManager.GetDBPwd(),int.Parse(BaseConfManager.GetDBType())) 
		{
			this.page= (Page)HttpContext.Current.Handler;
		}
		//=======[ADDED END]=====================================================
		*/

		public BaseBusiness (DBOperate dbOper) : base(dbOper) 
		{
			this.page = page;
		}
		
		public BaseBusiness () : base(BaseConfManager.GetDBServer(),BaseConfManager.GetDBName(),BaseConfManager.GetDBUser(),BaseConfManager.GetDBPwd(),int.Parse(BaseConfManager.GetDBType())) 
		{
			this.page= (Page)HttpContext.Current.Handler;
		}
		//=======[ADDED END]=====================================================
		
		public BaseBusiness (Page page) : base(BaseConfManager.GetDBServer(),BaseConfManager.GetDBName(),BaseConfManager.GetDBUser(),BaseConfManager.GetDBPwd(),int.Parse(BaseConfManager.GetDBType())) 
		{
			this.page = page;
			//base.GetCurDB();
		}

		public BaseBusiness (Page page, DBOperate dbOper) : base(dbOper) 
		{
			this.page = page;
		}


		public static DBOperate GetDBOperate () 
		{
			return DBOperatorFactory.GetDBOperator(BaseConfManager.GetDBServer(),BaseConfManager.GetDBName(),BaseConfManager.GetDBUser(),BaseConfManager.GetDBPwd(),int.Parse(BaseConfManager.GetDBType()));
		}

		public static new void SetPage (System.Web.UI.WebControls.DataGrid dg, DataTable dt) 
		{
			dg.PageSize = 12;
			CommonBaseBusiness.SetPage(dg, dt);
		}

		public static void AutoSetPage (int pageSize,System.Web.UI.WebControls.DataGrid dg, DataTable dt) 
		{
			dg.PageSize = pageSize;
			CommonBaseBusiness.SetPage(dg, dt);
		}
	
	}
}
