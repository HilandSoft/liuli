/// <copyright> 英网A1999-2005 </copyright>
/// <version>1.0</version>
/// <author>季宝福</author>
/// <email>jizhe@msn.com</email>
/// <log date="2005年8月11日">创建</log>

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

	public class EmployedBN:BaseLib
	{
		public EmployedBN(Page page) : base(page)
		{}

		public bool Add( EmployedDT dt )
		{
			using ( EmployedDB db = new EmployedDB() )
			{
				return db.Insert(dt);
			}
		}

		public int Add2( EmployedDT dt)
		{
			using ( EmployedDB db = new EmployedDB() )
			{
				return db.Insert2(dt);
			}
		}

		public bool Del(int id) 		{
			using ( EmployedDB db = new EmployedDB() )
			{
				return db.Del(id);
			}
		}
		public bool Edit( EmployedDT dt )
		{
			using ( EmployedDB db = new EmployedDB() )
			{
				return db.Update(dt);
			}
		}
		public EmployedDT Get( int id )
		{
			using ( EmployedDB db = new EmployedDB() )
			{
				return db.GetOneDT( id );
			}
		}
		public DataTable GetList ( ) 
		{
			DBFieldList = "*";
			DBTable = "Employed";
			return base.CommonGetList();
		}
		
		public void QueryhuiSid( string str )
		{
			Filter="huiSid ="+str+"";
		}
		
		public void QueryParam3( string str )
		{
			Filter="Param3 ='"+str+"'";
		}
		
		public void QueryIsValid( string str )
		{
			Filter="IsValid ="+str+"";
		}
		
		//完成或者删除
//		public void QueryCompleteOrDelete( string str,string str2 )
//		{
//			Filter="IsValid ="+str+" or IsValid="+str2+"";
//		}

		public void QueryNotIsvalid(string str)
		{
			Filter="IsValid!="+str+"";
		}
	}
}
