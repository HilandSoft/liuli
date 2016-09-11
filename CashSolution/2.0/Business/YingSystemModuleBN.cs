/// <copyright>青岛英网资讯技术有限公司  1999-2004</copyright>
/// <version>1.0</version>
/// <author>季宝福</author>
/// <email>jibf@YingNet.com</email>
/// <log date="2004-5-9">创建</log>

using System;
using System.Data;
using System.Web.UI;
using YingNet.WeiXing.DB;
using YingNet.WeiXing.DB.Data;

namespace YingNet.WeiXing.Business
{
	
	/// <summary>
	/// DepinfoDT的摘要说明。
	/// <summary>

	public class YingSystemModuleBN:BaseLib
	{
		public YingSystemModuleBN(Page page) : base(page)
		{}

		public YingSystemModuleDT Get(string strCode)
		{
			using ( YingSystemModuleDB db = new YingSystemModuleDB() )
			{
				return db.GetOneDT( strCode );
			}

		}
		public bool Add( YingSystemModuleDT dt )
		{
			using ( YingSystemModuleDB db = new YingSystemModuleDB() )
			{
				return db.Insert(dt);
			}
		}
		public bool Del(int id) 		
		{
			using ( YingSystemModuleDB db = new YingSystemModuleDB() )
			{
				return db.Del(id);
			}
		}
		public bool Edit( YingSystemModuleDT dt )
		{
			using ( YingSystemModuleDB db = new YingSystemModuleDB() )
			{
				return db.Update(dt);
			}
		}
		public DataTable GetList ( ) 
		{
			DBFieldList = "code,name,displayname";
			DBTable = "YingSystemModule";
			return base.CommonGetList();
		}
	}

}
