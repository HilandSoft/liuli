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

	public class ProductBN:BaseLib
	{
		public ProductBN(Page page) : base(page)
		{}

		public bool Add( ProductDT dt )
		{
			using ( ProductDB db = new ProductDB() )
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
			using ( ProductDB db = new ProductDB() )
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

		public bool Edit( ProductDT dt )
		{
			using ( ProductDB db = new ProductDB() )
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

		public ProductDT Get ( int id )
		{
			using ( ProductDB db = new ProductDB() )
			{
				return db.GetOneDT(id);
			}
		}

		public DataTable GetList ( ) 
		{
			DBFieldList = "ProductIsTop,PubDate,PriductID,ProductName,ImgPath,ProductTypeNo,ProductInfo";
			DBTable = "Product";
			Order = "PubDate desc";
			return base.CommonGetList();
		}
		public DataTable GetList ( string num ) 
		{
			DBFieldList = "ProductIsTop,PubDate,PriductID,ProductName";
			DBTable = "Product";
			Filter = "ProductTypeNo like '"+num+"%'";
			return base.CommonGetList();
		}
	}
}
