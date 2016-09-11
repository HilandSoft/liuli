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

	public class YingInfoBN:BaseLib
	{
		public YingInfoBN(Page page) : base(page)
		{}

		public bool Add( YingInfoDT dt )
		{
			using ( YingInfoDB db = new YingInfoDB() )
			{
				if ( db.Insert(dt) )
				{
					StorageConn.ReInit();
					return true;
				}
				else
				{
					return false;
				}
			}
		}
		public bool Del(int id) 		
		{
			using ( YingInfoDB db = new YingInfoDB() )
			{
				if  ( db.TrueDel(id))
				{
					StorageConn.ReInit();
					return true;
				}
				else
				{
					return false;
				}
			}
		}
		public bool Edit( YingInfoDT dt )
		{
			using ( YingInfoDB db = new YingInfoDB() )
			{
				if ( db.Update(dt) )
				{
					StorageConn.ReInit();
					return true;
				}
				else
				{
					return false;
				}
			}
		}
		public YingInfoDT Get( int id )
		{
			using ( YingInfoDB db = new YingInfoDB() )
			{
				return db.GetOneDT( id );
			}
		}
		public DataTable GetList ( ) 
		{
			DBFieldList = "InfoIsTop,InfoTitle,ImgPath,InfoPubDate,InfoID,InfoTypeNO,InfoContent";
			DBTable = "YingInfo";
			Order = "InfoPubDate desc";
			return base.CommonGetList();
		}

		public DataTable GetList ( int i , string num) 
		{
			using ( YingInfoDB db = new YingInfoDB() )
			{
				return db.RunSqlString("select  top "+i+" InfoTitle,InfoID,InfoPubDate,ImgPath,InfoContent from YingInfo where InfoTypeNo like '"+num+"%' order by InfoID desc","list");
			}
		}

		public DataTable GetList(string str)
		{
			using ( YingInfoDB db = new YingInfoDB() )
			{
				return db.RunSqlString("select * from YingInfo where InfoTypeNo like '%"+str+"%' order by InfoID desc","list");
			}
		}

		public DataTable GetListByTitle(string str)
		{
			using ( YingInfoDB db = new YingInfoDB() )
			{
				return db.RunSqlString("select * from YingInfo where InfoTitle like '%"+str+"%' order by InfoID desc","list");
			}
		}
		
		public void QueryType( string id )
		{
			if ( id !=null && id != string.Empty )
			{
				Filter="InfoTypeNo like '"+id.ToString()+"%'";
			}
		}

	}
}
