/// <copyright> 英网A1999-2005 </copyright>
/// <version>1.0</version>
/// <author>季宝福</author>
/// <email>jizhe@msn.com</email>
/// <log date="2005年9月8日">创建</log>

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

	public class EmploybackupBN:BaseLib
	{
		public EmploybackupBN(Page page) : base(page)
		{}

		public bool Add( EmploybackupDT dt )
		{
			using ( EmploybackupDB db = new EmploybackupDB() )
			{
				return db.Insert(dt);
			}
		}
		public bool Del(int id) 		{
			using ( EmploybackupDB db = new EmploybackupDB() )
			{
				return db.Del(id);
			}
		}
		public bool Edit( EmploybackupDT dt )
		{
			using ( EmploybackupDB db = new EmploybackupDB() )
			{
				return db.Update(dt);
			}
		}
		public DataTable GetList ( ) 
		{
			DBFieldList = "ModTime,Frequency,IsEmployed,huiSid,NDayMM,NDayDD,NDayYY,id,TYears,TMonths,MIncome,Wpaid,huiName,Employer,EAddress,EPhone";
			DBTable = "Employbackup";
			return base.CommonGetList();
		}
		
		public void Querysid( string str )
		{
			Filter="id ="+str+"";
		}
		
		public void QueryHuisid( string str )
		{
			Filter="huiSid ="+str+"";
		}
	}
}
