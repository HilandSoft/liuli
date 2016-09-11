/// <copyright> 英网A1999-2005 </copyright>
/// <version>1.0</version>
/// <author>季宝福</author>
/// <email>jizhe@msn.com</email>
/// <log date="2005年9月8日">创建</log>

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

	public class EmploybackupDB:DBAccess
	{

		/// <summary>
		///  按结构取值
		/// <summary>
		/// <param name='dr'>SqlDataReader</param>
		/// <param name='obj'>数据结构对象</param>
		/// <returns>数据结构对象</returns>
		public override object ConvertItem( SqlDataReader dr)
		{
			EmploybackupDT dt = new EmploybackupDT();
			dt.ModTime= Convert.ToDateTime(dr["ModTime"]);
			dt.Frequency= Convert.ToDouble(dr["Frequency"]);
			dt.IsEmployed= Convert.ToInt32(dr["IsEmployed"]);
			dt.huiSid= Convert.ToInt32(dr["huiSid"]);
			dt.NDayMM= Convert.ToInt32(dr["NDayMM"]);
			dt.NDayDD= Convert.ToInt32(dr["NDayDD"]);
			dt.NDayYY= Convert.ToInt32(dr["NDayYY"]);
			dt.id= Convert.ToInt32(dr["id"]);
			dt.TYears= Convert.ToInt32(dr["TYears"]);
			dt.TMonths= Convert.ToInt32(dr["TMonths"]);
			dt.MIncome= Convert.ToSingle(dr["MIncome"]);
			dt.Wpaid= Convert.ToString(dr["Wpaid"]);
			dt.huiName= Convert.ToString(dr["huiName"]);
			dt.Employer= Convert.ToString(dr["Employer"]);
			dt.EAddress= Convert.ToString(dr["EAddress"]);
			dt.EPhone= Convert.ToString(dr["EPhone"]);
			return dt;
		}

		/// <summary>
		///  组织参数列表
		/// <summary>
		/// <param name='obj'>数据结构对象</param>
		/// <returns>参数列表</returns>
		public override SqlParameter[] GetParameter( object obj )
		{
			EmploybackupDT dt = (EmploybackupDT)obj;
			SqlParameter[] prams =
			{
				MakeInParam("@ModTime" ,SqlDbType.DateTime,8,dt.ModTime),
				MakeInParam("@Frequency" ,SqlDbType.Float,8,dt.Frequency),
				MakeInParam("@IsEmployed" ,SqlDbType.Int,4,dt.IsEmployed),
				MakeInParam("@huiSid" ,SqlDbType.Int,4,dt.huiSid),
				MakeInParam("@NDayMM" ,SqlDbType.Int,4,dt.NDayMM),
				MakeInParam("@NDayDD" ,SqlDbType.Int,4,dt.NDayDD),
				MakeInParam("@NDayYY" ,SqlDbType.Int,4,dt.NDayYY),
				MakeInParam("@id" ,SqlDbType.Int,4,dt.id),
				MakeInParam("@TYears" ,SqlDbType.Int,4,dt.TYears),
				MakeInParam("@TMonths" ,SqlDbType.Int,4,dt.TMonths),
				MakeInParam("@MIncome" ,SqlDbType.Money,8,dt.MIncome),
				MakeInParam("@Wpaid" ,SqlDbType.NVarChar,100,dt.Wpaid),
				MakeInParam("@huiName" ,SqlDbType.NVarChar,400,dt.huiName),
				MakeInParam("@Employer" ,SqlDbType.NVarChar,100,dt.Employer),
				MakeInParam("@EAddress" ,SqlDbType.NVarChar,100,dt.EAddress),
				MakeInParam("@EPhone" ,SqlDbType.NVarChar,100,dt.EPhone)
			};
			return prams;
		}
		public EmploybackupDT GetOneDT(int id)
		{
			return (EmploybackupDT)GetOneItem(id);
		}
	}
}
