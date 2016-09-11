using System;
using System.Data;
using System.Web.UI;
using TunyNet.Caching;
using YingNet.WeiXing.DB;
using YingNet.WeiXing.DB.Data;

namespace YingNet.WeiXing.Business
{
	/// <summary>
	/// CSUserPermissionBN 的摘要说明。
	/// </summary>
	public class CSUserPermissionBN:BaseLib
	{
		public CSUserPermissionBN(Page page): base(page)
		{
			//
			// TODO: 在此处添加构造函数逻辑
			//
		}
		
		private string cacheKey= "CSUserPermission:user-";
		
		public bool Add( CSUserPermissionDT dt )
		{
			using ( CSUserPermissionDB db = new CSUserPermissionDB() )
			{
				bool temp= db.Insert(dt);
				if(temp==true)
				{
					WebCache.Max(this.cacheKey+ dt.UserID,dt);
				}
				return temp;
			}
		}

//		public bool Del(int id) 		
//		{
//			using ( CSUserPermissionDB db = new CSUserPermissionDB() )
//			{
//				bool temp= db.Del(id);
//				return temp;
//			}
//		}
		
		public bool Edit( CSUserPermissionDT dt )
		{
			using ( CSUserPermissionDB db = new CSUserPermissionDB() )
			{
				bool temp= db.Update(dt);
				if(temp==true)
				{
					WebCache.Max(this.cacheKey+ dt.UserID,dt);
				}
				return temp;
			}
		}
		public CSUserPermissionDT Get( int userID )
		{
			if(WebCache.Get(this.cacheKey+ string.Format("{0}",userID))!=null)
			{
				return (CSUserPermissionDT)WebCache.Get(this.cacheKey + string.Format("{0}", userID));
			}
			
			using ( CSUserPermissionDB db = new CSUserPermissionDB() )
			{
				return db.GetOneItem( userID,"UserID" ) as CSUserPermissionDT;
			}
		}
	}
}
