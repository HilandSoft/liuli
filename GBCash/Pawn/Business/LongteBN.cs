/// <copyright> 英网A1999-2006 </copyright>
/// <version>1.0</version>
/// <author>季宝福</author>
/// <email>jizhe@msn.com</email>
/// <log date="2006年4月19日">创建</log>

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

	public class LongteBN:BaseLib
	{
		public LongteBN(Page page) : base(page)
		{}

		public bool Add( LongteDT dt )
		{
			using ( LongteDB db = new LongteDB() )
			{
				return db.Insert(dt);
			}
		}
		public bool Del(int id) 		{
			using ( LongteDB db = new LongteDB() )
			{
				return db.Del(id);
			}
		}
		public bool Edit( LongteDT dt )
		{
			using ( LongteDB db = new LongteDB() )
			{
				return db.Update(dt);
			}
		}
		public DataTable GetList ( ) 
		{
			DBFieldList = "thome,sid,personsid,param5,tper,param3,param4,Rnum3,param1,param2,Rnum2,Rname3,Rship3,Rnum1,Rname2,Rship2,premethods,Rname1,Rship1,acname,bsb,acnumber,npayday,bankname,branch,estatus,jobtitle,timeemployed,ename,eaddress,etel";
			DBTable = "Longte";
			return base.CommonGetList();
		}
	}
}
