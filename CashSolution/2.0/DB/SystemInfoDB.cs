/// <copyright> 英网A1999-2005 </copyright>
/// <version>1.0</version>
/// <author>季宝福</author>
/// <email>jizhe@msn.com</email>
/// <log date="2005年8月6日">创建</log>

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

	public class SystemInfoDB:DBAccess
	{

		/// <summary>
		///  按结构取值
		/// <summary>
		/// <param name='dr'>SqlDataReader</param>
		/// <param name='obj'>数据结构对象</param>
		/// <returns>数据结构对象</returns>
		public override object ConvertItem( SqlDataReader dr)
		{
			SystemInfoDT dt = new SystemInfoDT();
			dt.param2= Convert.ToDouble(dr["param2"]);
			dt.lowerlimit2= Convert.ToDouble(dr["lowerlimit2"]);
			dt.upperlimit2= Convert.ToDouble(dr["upperlimit2"]);
			dt.param1= Convert.ToDouble(dr["param1"]);
			dt.frequency= Convert.ToDouble(dr["frequency"]);
			dt.interest= Convert.ToDouble(dr["interest"]);
			dt.poundage= Convert.ToDouble(dr["poundage"]);
			dt.percentage= Convert.ToDouble(dr["percentage"]);
			dt.upperlimit= Convert.ToDouble(dr["upperlimit"]);
			dt.lowerlimit= Convert.ToDouble(dr["lowerlimit"]);
			dt.param3= Convert.ToInt32(dr["param3"]);
			dt.param4= Convert.ToInt32(dr["param4"]);
			dt.datediffw= Convert.ToInt32(dr["datediffw"]);
			dt.datedifff= Convert.ToInt32(dr["datedifff"]);
			dt.datediffm= Convert.ToInt32(dr["datediffm"]);
			dt.shortday= Convert.ToInt32(dr["shortday"]);
			dt.IsPercent= Convert.ToInt32(dr["IsPercent"]);
			dt.yanqinum= Convert.ToInt32(dr["yanqinum"]);
			dt.id= Convert.ToInt32(dr["id"]);
			dt.installment= Convert.ToInt32(dr["installment"]);
			dt.term= Convert.ToInt32(dr["term"]);
			return dt;
		}

		/// <summary>
		///  组织参数列表
		/// <summary>
		/// <param name='obj'>数据结构对象</param>
		/// <returns>参数列表</returns>
		public override SqlParameter[] GetParameter( object obj )
		{
			SystemInfoDT dt = (SystemInfoDT)obj;
			SqlParameter[] prams =
			{
				MakeInParam("@param2" ,SqlDbType.Float,8,dt.param2),
				MakeInParam("@lowerlimit2" ,SqlDbType.Float,8,dt.lowerlimit2),
				MakeInParam("@upperlimit2" ,SqlDbType.Float,8,dt.upperlimit2),
				MakeInParam("@param1" ,SqlDbType.Float,8,dt.param1),
				MakeInParam("@frequency" ,SqlDbType.Float,8,dt.frequency),
				MakeInParam("@interest" ,SqlDbType.Float,8,dt.interest),
				MakeInParam("@poundage" ,SqlDbType.Float,8,dt.poundage),
				MakeInParam("@percentage" ,SqlDbType.Float,8,dt.percentage),
				MakeInParam("@upperlimit" ,SqlDbType.Float,8,dt.upperlimit),
				MakeInParam("@lowerlimit" ,SqlDbType.Float,8,dt.lowerlimit),
				MakeInParam("@param3" ,SqlDbType.Int,4,dt.param3),
				MakeInParam("@param4" ,SqlDbType.Int,4,dt.param4),
				MakeInParam("@datediffw" ,SqlDbType.Int,4,dt.datediffw),
				MakeInParam("@datedifff" ,SqlDbType.Int,4,dt.datedifff),
				MakeInParam("@datediffm" ,SqlDbType.Int,4,dt.datediffm),
				MakeInParam("@shortday" ,SqlDbType.Int,4,dt.shortday),
				MakeInParam("@IsPercent" ,SqlDbType.Int,4,dt.IsPercent),
				MakeInParam("@yanqinum" ,SqlDbType.Int,4,dt.yanqinum),
				MakeInParam("@id" ,SqlDbType.Int,4,dt.id),
				MakeInParam("@installment" ,SqlDbType.Int,4,dt.installment),
				MakeInParam("@term" ,SqlDbType.Int,4,dt.term)
			};
			return prams;
		}
		public SystemInfoDT GetOneDT(int id)
		{
			return (SystemInfoDT)GetOneItem(id);
		}
	}
}
