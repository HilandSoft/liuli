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

	public class LongtpBN:BaseLib
	{
		public LongtpBN(Page page) : base(page)
		{}

		public bool Add( LongtpDT dt )
		{
			using ( LongtpDB db = new LongtpDB() )
			{
				return db.Insert(dt);
			}
		}

		public int Add2( LongtpDT dt )
		{
			using ( LongtpDB db = new LongtpDB() )
			{
				return db.Insert2(dt);
			}
		}
		public bool Del(int id) 		{
			using ( LongtpDB db = new LongtpDB() )
			{
				return db.Del(id);
			}
		}
		public bool Edit( LongtpDT dt )
		{
			using ( LongtpDB db = new LongtpDB() )
			{
				return db.Update(dt);
			}
		}
		public DataTable GetList ( ) 
		{
			DBFieldList = "regdate,borrow,sid,param3,param4,param5,terms,param1,param2,timeaddress,landlord,areatel,suburb,state,postcode,restatus,unitno,street,lnumber,lstate,mastatus,worktel,mobiletel,email,gender,birth,hometel,fname,mname,sname,existing,refnumber,title,purpose";
			DBTable = "Longtp";
			return base.CommonGetList();
		}
	}
}
