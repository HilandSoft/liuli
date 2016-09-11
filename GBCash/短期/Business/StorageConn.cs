using System;
using System.Data;
using System.Text;
using YingNet.WeiXing.DB;

namespace YingNet.WeiXing.Business
{
	/// <summary>
	/// StorageConn 的摘要说明。
	/// </summary>
	public class StorageConn
	{
        protected static DataTable m_InfoList = null;
        protected static DataTable m_InfoTypeList = null;
		protected static DataTable m_ProductList = null;
		protected static DataTable m_ProductTypeList = null;

		public static void ReInit()
		{
            m_InfoList = null;
            m_InfoTypeList = null;
			m_ProductList = null;
			m_ProductTypeList = null;
		}

		public static DataTable GetInfoList()
		{
			lock( typeof( StorageConn ))
			{
				if( m_InfoList == null )
				{
					using ( YingInfoDB db = new YingInfoDB() )
					{
						m_InfoList = db.GetList();
					}
				}

				return m_InfoList;
			}
		}

		public static DataTable GetInfoTypeList()
		{
			lock( typeof( StorageConn ))
			{
				if( m_InfoTypeList == null )
				{
					using ( YingInfoTypeDB db = new YingInfoTypeDB() )
					{
						m_InfoTypeList = db.GetList();
					}
				}

				return m_InfoTypeList;
			}
		}
		public static DataTable GetProductList()
		{
			lock( typeof( StorageConn ))
			{
				if( m_ProductList == null )
				{
					using ( ProductDB db = new ProductDB() )
					{
						m_ProductList = db.GetList();
					}
				}

				return m_ProductList;
			}
		}

		public static DataTable GetProductTypeList()
		{
			lock( typeof( StorageConn ))
			{
				if( m_ProductTypeList == null )
				{
					using ( ProductTypeDB db = new ProductTypeDB() )
					{
						m_ProductTypeList = db.GetList();
					}
				}

				return m_ProductTypeList;
			}
		}

		public static DataTable GetInfoListByType( string type)
		{
			DataTable dt = StorageConn.GetInfoList();
			DataTable newdt = dt.Clone();
			
			foreach ( DataRow dr in dt.Select("[InfoTypeNo] like '"+type+"%' ","InfoPubDate desc"))
			{
				newdt.Rows.Add( dr.ItemArray );
			}

			return newdt;
		}

		public static DataTable GetInfoSeaList( string title,string type)
		{
			DataTable dt = StorageConn.GetInfoList();
			DataTable newdt = dt.Clone();
			
			foreach ( DataRow dr in dt.Select("[InfoTitle] like '%"+title+"%' and [InfoTypeNo] like '"+type+"%' ","InfoPubDate desc"))
			{
				newdt.Rows.Add( dr.ItemArray );
			}

			return newdt;
		}

		public static DataTable GetInfoTopList( string num ,int topnum)
		{
			DataTable dt = StorageConn.GetInfoList();
			DataTable newdt = dt.Clone();
			
			int i = 1;
			
			foreach ( DataRow dr in dt.Select("[InfoTypeNo] like '"+num+"%'","InfoID desc"))
			{
				if ( i > topnum )
					break;
				newdt.Rows.Add( dr.ItemArray );
				i++;
			}

			return newdt;
		}

		public static DataTable GetProductTypeRootList( )
		{
			DataTable dt = StorageConn.GetProductTypeList();
			DataTable newdt = dt.Clone();
			foreach ( DataRow dr in dt.Select("[Parent]='001'"))
			{
				newdt.Rows.Add( dr.ItemArray );
			}

			return newdt;
		}
	}
}
