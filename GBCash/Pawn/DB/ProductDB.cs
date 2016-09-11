using System;
using System.Data;
using System.Data.SqlClient;
using YingNet.Common;
using YingNet.WeiXing.DB.Data;


namespace YingNet.WeiXing.DB
{

	/// <summary>
	/// DepinfoDT的摘要说明。
	/// <summary>

	public class ProductDB:DBAccess
	{

		/// <summary>
		///  按结构取值
		/// <summary>
		/// <param name='dr'>SqlDataReader</param>
		/// <param name='obj'>数据结构对象</param>
		/// <returns>数据结构对象</returns>
		public override object ConvertItem( SqlDataReader dr)
		{
			ProductDT dt = new ProductDT();
			dt.ProductIsTop= Convert.ToBoolean(dr["ProductIsTop"]);
			dt.PubDate= Convert.ToDateTime(dr["PubDate"]);
			dt.PriductID= Convert.ToInt32(dr["PriductID"]);
			dt.ProductName= Convert.ToString(dr["ProductName"]);
			dt.ImgPath= Convert.ToString(dr["ImgPath"]);
			dt.ProductTypeNo= Convert.ToString(dr["ProductTypeNo"]);
			dt.ProductInfo= Convert.ToString(dr["ProductInfo"]);
			return dt;
		}

		/// <summary>
		///  组织参数列表
		/// <summary>
		/// <param name='obj'>数据结构对象</param>
		/// <returns>参数列表</returns>
		public override SqlParameter[] GetParameter( object obj )
		{
			ProductDT dt = (ProductDT)obj;
			SqlParameter[] prams =
			{
				MakeInParam("@ProductIsTop" ,SqlDbType.Bit,1,dt.ProductIsTop),
				MakeInParam("@PubDate" ,SqlDbType.DateTime,8,dt.PubDate),
				MakeInParam("@PriductID" ,SqlDbType.Int,4,dt.PriductID),
				MakeInParam("@ProductName" ,SqlDbType.NVarChar,800,dt.ProductName),
				MakeInParam("@ImgPath" ,SqlDbType.NVarChar,600,dt.ImgPath),
				MakeInParam("@ProductTypeNo" ,SqlDbType.NVarChar,240,dt.ProductTypeNo),
				MakeInParam("@ProductInfo" ,SqlDbType.Text,0,dt.ProductInfo)
			};
			return prams;
		}
		public ProductDT GetOneDT(int id)
		{
			return (ProductDT)GetOneItem(id);
		}
	
		
	
		public override SqlParameter[] GetParameter(int id)
		{
			
			SqlParameter[] prams =
			{	
				MakeInParam("@PriductID" ,SqlDbType.Int,4,id)
			};

			return prams;
		}
		public DataTable GetList()
		{
			return RunSqlString("SELECT PriductID, ProductName, PubDate, ImgPath, ProductIsTop, ProductTypeNo FROM Product ORDER BY PubDate" ,"data");
		}
	}
}
