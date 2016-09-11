using System;
using System.Data;
using System.Web.UI;
using YingNet.WeiXing.DB;
using YingNet.WeiXing.DB.Data;

namespace YingNet.WeiXing.Business
{
	/// <summary>
	/// CSUserBN 的摘要说明。
	/// </summary>
	public class CSUserBN:BaseLib
	{
		public CSUserBN(Page page): base(page)
		{}
		
		
		public bool Add( CSUserDT dt )
		{
			using ( CSUserDB db = new CSUserDB() )
			{
				return db.Insert(dt);
			}
		}

		public bool Del(int id) 		
		{
			using ( CSUserDB db = new CSUserDB() )
			{
				return db.Del(id,true,"UserID");
			}
		}
		public bool Edit( CSUserDT dt )
		{
			using ( CSUserDB db = new CSUserDB() )
			{
				return db.Update(dt);
			}
		}
		public CSUserDT Get( int id )
		{
			using ( CSUserDB db = new CSUserDB() )
			{
				return db.GetOneItem( id,"UserID" ) as CSUserDT;
			}
		}
		public DataTable GetList ( ) 
		{
			DBFieldList = "*";
			DBTable = "CS_User";
			this.Order="UserID asc";
			return base.CommonGetList();
		}
	}
}
