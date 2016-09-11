/// <copyright> 英网A1999-2005 </copyright>
/// <version>1.0</version>
/// <author>季宝福</author>
/// <email>jizhe@msn.com</email>
/// <log date="2005年9月16日">创建</log>

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

	public class InfoBN:BaseLib
	{
		public InfoBN(Page page) : base(page)
		{}


		public bool Add( InfoDT dt )
		{
			using ( InfoDB db = new InfoDB() )
			{
				return db.Insert(dt);
			}
		}
		public bool Del(int id) 		{
			using ( InfoDB db = new InfoDB() )
			{
				return db.Del(id);
			}
		}
		public bool Edit( InfoDT dt )
		{
			using ( InfoDB db = new InfoDB() )
			{
				return db.Update(dt);
			}
		}
		public InfoDT Get( int id )
		{
			using ( InfoDB db = new InfoDB() )
			{
				return db.GetOneDT( id );
			}
		}
		public DataTable GetList ( ) 
		{
			DBFieldList = "regtime,id,huiSid,isvalid,param2,param3,Username,type,param1";
			DBTable = "Info";
			this.Order="regtime desc";
			return base.CommonGetList();
		}

		public void QueryValid(string str)
		{
			this.Filter="isvalid ="+str+"";
		}
	}
}
