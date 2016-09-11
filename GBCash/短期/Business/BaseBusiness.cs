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
	/// BaseBusiness ��ժҪ˵����
	/// </summary>
	public class BaseBusiness:CommonBaseBusiness 
	{

		/// <summary>
		/// ��¼��id��session����
		/// </summary>
		public  const string SESSION_USER_ID = "User.ID";
		public  const string SESSION_ADMIN_ID = "Admin.ID";

		//��ҵ��Ա������˾
		public  const string SESSION_USER_COMPANYID="Company.ID";

		/// <summary>
		/// ��¼���˺ŵ�session����
		/// </summary>
		public  const string SESSION_USER_ACCOUNT = "User.Account";
		public  const string SESSION_ADMIN_ACCOUNT = "Admin.Account";
		public const string SESSION_USER_COMPANYACCOUNT="Company.Account";
      
		/// <summary>
		/// ��¼��������session����
		/// </summary>
		public  const string SESSION_USER_NAME = "User.Name";
		public  const string SESSION_ADMIN_NAME = "Admin.Name";
		public const string SESSION_USER_COMPANYNAME="Company.Name";


		public  const string PARAM_NAME = CommonBasePage.PARAM_NAME;
		/// <summary>
		/// ��¼��Ȩ�޵�session
		/// </summary>
		public  const string SESSION_USER_Permission = "User.Permission";
		/// <summary>
		/// ��¼��������Ա���͵�session
		/// </summary>
		public  const string SESSION_USER_Type = "User.Type";

		/// <summary>
		/// ���ʦ��Ա���͵�session���ʦid
		/// </summary>
		public  const string SESSION_DesignerID = "User.DesignerID";
		/// <summary>
		/// webҳ��
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
