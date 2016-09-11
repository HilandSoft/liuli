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

	public class YingInfoTypeBN:BaseLib
	{
		public YingInfoTypeBN(Page page) : base(page)
		{}

		public bool Add( YingInfoTypeDT dt )
		{
			using ( YingInfoTypeDB db = new YingInfoTypeDB() )
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
		public bool Del(string num)
		{
			using ( YingInfoTypeDB db = new YingInfoTypeDB() )
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
		public bool Edit( YingInfoTypeDT dt )
		{
			using ( YingInfoTypeDB db = new YingInfoTypeDB() )
			{
				StorageConn.ReInit();
				return db.Update(dt);
			}
		}
		public DataTable GetList ( ) 
		{
			DBFieldList = "Has_Sub,Num,TypeName,Parent,id";
			DBTable = "YingInfoType";
			return base.CommonGetList();
		}

		public DataTable GetListByParent(string parent)
		{
			DBFieldList = "Has_Sub,Num,TypeName,Parent,id";
			DBTable = "YingInfoType";
			Filter = "parent like '"+parent+"%'";
			Order="id desc";
			//Filter = "Has_Sub=1";
			return base.CommonGetList();
		}

		public DataTable GetList ( string num ) 
		{
			DBFieldList = "Has_Sub,Num,TypeName,Parent,id";
			DBTable = "YingInfoType";
			Filter = "num like '"+num+"%'";
			//Filter = "Has_Sub=1";
			return base.CommonGetList();
		}

		public void updatehas_sub()
		{
			using ( YingInfoTypeDB db = new YingInfoTypeDB() )
			{
				db.RunSqlStringNoReturn("update [YingInfoType] set has_sub=1 update [YingInfoType] set has_sub=0 where num in (select parent from YingInfoType where parent is not null)");
			}
		}

		public DataTable GetListByNum(string num)
		{
			using ( YingInfoTypeDB db = new YingInfoTypeDB() )
			{
				return db.RunSqlString("SELECT * FROM YingInfo LEFT OUTER JOIN YingInfoType ON YingInfoType.Num = YingInfo.InfoTypeNo where Parent='"+num+"'","list");
			}
		}

		public YingInfoTypeDT CouvDt( YingInfoTypeDT dt )
		{
			YingInfoTypeDB db = new YingInfoTypeDB();
			dt.Has_Sub = true ;

			string parent = dt.Parent;  //父编号

			int last = 0;               //最后兄弟ID
                      
			if ( parent == null || parent.Equals("") ) parent = "0";

			// 取得所有兄弟部门

			SqlDataReader reader = db.RunSqlString("SELECT substring(num, "+(parent.Length+1)+", 3) as newnum FROM YingInfoType where parent='"+parent+"' ORDER BY num");
            
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
				dt.Num = parent + ( last + 1 ).ToString( "D3" );
			}
			else 
			{
				dt.Parent ="0";
				dt.Num = ( last + 1 ).ToString( "D3" );
			}
			return dt;
		}
		public YingInfoTypeDT GetByNum( string s )
		{
			using ( YingInfoTypeDB db = new YingInfoTypeDB() )
			{
				return db.GetByNum(s);
			}
		}
		public bool ISHasSub( string s )
		{
			using ( YingInfoTypeDB db = new YingInfoTypeDB() )
			{
				return db.ISHasSub(s);
			}
		}
	}
}
