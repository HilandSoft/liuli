/// <copyright> 英网A1999-2005 </copyright>
/// <version>1.0</version>
/// <author>季宝福</author>
/// <email>jizhe@msn.com</email>
/// <log date="2005年9月5日">创建</log>

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

	public class HuibackupBN:BaseLib
	{
		public HuibackupBN(Page page) : base(page)
		{}

		public bool Add( HuibackupDT dt )
		{
			using ( HuibackupDB db = new HuibackupDB() )
			{
				return db.Insert(dt);
			}
		}
		public bool Del(int id) 		{
			using ( HuibackupDB db = new HuibackupDB() )
			{
				return db.Del(id);
			}
		}
		public bool Edit( HuibackupDT dt )
		{
			using ( HuibackupDB db = new HuibackupDB() )
			{
				return db.Update(dt);
			}
		}
		public DataTable GetList ( ) 
		{
			DBFieldList = "DBirth,Modtime,id,TYears,TMonths,Param4,Param5,IsEmployed,Param1,Param2,Param3,Mobile,Username,Password,State,Postcode,HTel,RAddress,SAddress,City,Email,Issued,DNumber,Fname,Lname,Mname";
			DBTable = "Huibackup";
			return base.CommonGetList();
		}
		
		public void QuerySid( string str )
		{
			Filter="id ="+str+"";
		}
		
		public void QueryUsername( string str )
		{
			Filter="Username ='"+str+"'";
		}
	}
}
