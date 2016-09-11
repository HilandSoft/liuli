/// <copyright> 英网A1999-2005 </copyright>
/// <version>1.0</version>
/// <author>季宝福</author>
/// <email>jizhe@msn.com</email>
/// <log date="2005年8月6日">创建</log>

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

	public class SystemInfoBN:BaseLib
	{
		public SystemInfoBN(Page page) : base(page)
		{}

		public bool Add( SystemInfoDT dt )
		{
			using ( SystemInfoDB db = new SystemInfoDB() )
			{
				return db.Insert(dt);
			}
		}
		public bool Del(int id) 		{
			using ( SystemInfoDB db = new SystemInfoDB() )
			{
				return db.Del(id);
			}
		}
		public bool Edit( SystemInfoDT dt )
		{
			using ( SystemInfoDB db = new SystemInfoDB() )
			{
				return db.Update(dt);
			}
		}
		public DataTable GetList ( ) 
		{
			DBFieldList = "param2,lowerlimit2,upperlimit2,param1,frequency,interest,poundage,percentage,upperlimit,lowerlimit,param3,param4,datediffw,datedifff,datediffm,shortday,IsPercent,yanqinum,id,installment,term";
			DBTable = "SystemInfo";
			return base.CommonGetList();
		}
		
		public SystemInfoDT Get( int id )
		{
			using ( SystemInfoDB db = new SystemInfoDB() )
			{
				return db.GetOneDT( id );
			}
		}
	}
}
