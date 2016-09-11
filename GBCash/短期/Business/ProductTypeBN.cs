using System;
using System.Data;
using System.Web.UI;
using YingNet.WeiXing.DB;
using YingNet.WeiXing.DB.Data;
using System.Data.SqlClient;


namespace YingNet.WeiXing.Business
{
	/// <summary>
	/// DepinfoDT的摘要说明。
	/// <summary>

	public class ProductTypeBN:BaseLib
	{
		public ProductTypeBN(Page page) : base(page){}

		public bool Add( ProductTypeDT dt )
		{
			using ( ProductTypeDB db = new ProductTypeDB() )
			{
				dt = CouvDt( dt );
				if ( db.Insert(dt))
				{
					updatehas_sub();
					StorageConn.ReInit();
					return true;
				}
				else
				{
					return false;
				}
			}
		}
		public bool Del(string  num) 		
		{
			using ( ProductTypeDB db = new ProductTypeDB() )
			{
				if ( !db.ISHasDel( num ) && !db.ISHasSub( num ))
				{
					if( db.Del(num))
					{
						updatehas_sub();
						StorageConn.ReInit();
						return true;
					}
					else
					{
						return false;
					}
				}
				else
				{
					return false;
				}
			}
		}
		public bool Edit( ProductTypeDT dt )
		{
			using ( ProductTypeDB db = new ProductTypeDB() )
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

		public ProductTypeDT Get( string i )
		{
			using ( ProductTypeDB db = new ProductTypeDB() )
			{
				return db.GetByNum( i );
			}
		}

		public DataTable GetList ( ) 
		{
			DBFieldList = "Has_Sub,id,ImgPath,num,TypeName,Parent,TypeInfo";
			DBTable = "ProductType";
			return base.CommonGetList();
		}
		
		public void updatehas_sub()
		 {
			 using ( ProductTypeDB db = new ProductTypeDB() )
			 {
				 db.RunSqlStringNoReturn("update [ProductType] set has_sub=1 update [ProductType] set has_sub=0 where num in (select parent from ProductType where parent is not null)");
			 }
		 }

		public DataTable GetListByNum(string num)
		{
			using ( ProductTypeDB db = new ProductTypeDB() )
			{
				return db.RunSqlString("SELECT * FROM Product LEFT OUTER JOIN ProductType ON ProductType.Num = Product.ProductTypeNo where Parent='"+num+"'","list");
			}
		}

		public ProductTypeDT CouvDt( ProductTypeDT dt )
		{
			ProductTypeDB db = new ProductTypeDB();
			dt.Has_Sub = true ;

			string parent = dt.Parent;  //父编号

			int last = 0;               //最后兄弟ID
                      
			if ( parent == null || parent.Equals("") ) parent = "0";

			// 取得所有兄弟部门

			SqlDataReader reader = db.RunSqlString("SELECT substring(num, "+(parent.Length+1)+", 3) as newnum FROM ProductType where parent='"+parent+"' ORDER BY num");
            
			// 搜索本级部门没有使用的序列号
			while ( last < 999 && reader.Read()) 
			{
				int next = Int32.Parse( reader[ 0 ].ToString());
				if ( next - last > 1 ) break;
				last = next;
			}
			reader.Close();

			if ( last > 999 ) 
			{ // 找到一个序列号
				return null;
			}
			// 构造序列号
			if ( parent !="0") 
			{
				dt.num = parent + ( last + 1 ).ToString( "D3" );
			}
			else 
			{
				dt.Parent ="0";
				dt.num = ( last + 1 ).ToString( "D3" );
			}
			return dt;
		}
		
		public bool ISHasSub( string s )
		{
			using ( ProductTypeDB db = new ProductTypeDB() )
			{
				return db.ISHasSub(s);
			}
		}
		public ProductTypeDT GetByNum( string s )
		{
			using ( ProductTypeDB db = new ProductTypeDB() )
			{
				return db.GetByNum(s);
			}
		}
	}
}
