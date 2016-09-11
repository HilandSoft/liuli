using System;
using System.Data;
using System.Web.UI;
using YingNet.WeiXing.DB;
using YingNet.WeiXing.DB.Data;

namespace YingNet.WeiXing.Business
{
	/// <summary>
	/// CSFollowupCenterBN 的摘要说明。
	/// </summary>
	public class CSFollowupCenterBN:BaseLib
	{
		public CSFollowupCenterBN(Page page): base(page)
		{
			//
			// TODO: 在此处添加构造函数逻辑
			//
		}
		
		public bool Add( CSFollowupCenterDT dt )
		{
			using ( CSFollowupCenterDB db = new CSFollowupCenterDB() )
			{
				return db.Insert(dt);
			}
		}

		public bool Del(int id) 		
		{
			using ( CSFollowupCenterDB db = new CSFollowupCenterDB() )
			{
				return db.Del(id,true,"FollowupID");
			}
		}
		public bool Edit( CSFollowupCenterDT dt )
		{
			using ( CSFollowupCenterDB db = new CSFollowupCenterDB() )
			{
				return db.Update(dt);
			}
		}
		public CSFollowupCenterDT Get( int id )
		{
			using ( CSFollowupCenterDB db = new CSFollowupCenterDB() )
			{
				return db.GetOneItem( id,"followupID" ) as CSFollowupCenterDT;
			}
		}
		public DataTable GetList ( ) 
		{
			DBFieldList = "*";
			DBTable = "CS_FollowupCenter";
			this.Order="FollowupID desc";
			return base.CommonGetList();
		}
	}
}
