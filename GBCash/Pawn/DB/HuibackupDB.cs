/// <copyright> 英网A1999-2005 </copyright>
/// <version>1.0</version>
/// <author>季宝福</author>
/// <email>jizhe@msn.com</email>
/// <log date="2005年9月5日">创建</log>

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

	public class HuibackupDB:DBAccess
	{

		/// <summary>
		///  按结构取值
		/// <summary>
		/// <param name='dr'>SqlDataReader</param>
		/// <param name='obj'>数据结构对象</param>
		/// <returns>数据结构对象</returns>
		public override object ConvertItem( SqlDataReader dr)
		{
			HuibackupDT dt = new HuibackupDT();
			dt.DBirth= Convert.ToDateTime(dr["DBirth"]);
			dt.Modtime= Convert.ToDateTime(dr["Modtime"]);
			dt.id= Convert.ToInt32(dr["id"]);
			dt.TYears= Convert.ToInt32(dr["TYears"]);
			dt.TMonths= Convert.ToInt32(dr["TMonths"]);
			dt.Param4= Convert.ToString(dr["Param4"]);
			dt.Param5= Convert.ToString(dr["Param5"]);
			dt.IsEmployed= Convert.ToString(dr["IsEmployed"]);
			dt.Param1= Convert.ToString(dr["Param1"]);
			dt.Param2= Convert.ToString(dr["Param2"]);
			dt.Param3= Convert.ToString(dr["Param3"]);
			dt.Mobile= Convert.ToString(dr["Mobile"]);
			dt.Username= Convert.ToString(dr["Username"]);
			dt.Password= Convert.ToString(dr["Password"]);
			dt.State= Convert.ToString(dr["State"]);
			dt.Postcode= Convert.ToString(dr["Postcode"]);
			dt.HTel= Convert.ToString(dr["HTel"]);
			dt.RAddress= Convert.ToString(dr["RAddress"]);
			dt.SAddress= Convert.ToString(dr["SAddress"]);
			dt.City= Convert.ToString(dr["City"]);
			dt.Email= Convert.ToString(dr["Email"]);
			dt.Issued= Convert.ToString(dr["Issued"]);
			dt.DNumber= Convert.ToString(dr["DNumber"]);
			dt.Fname= Convert.ToString(dr["Fname"]);
			dt.Lname= Convert.ToString(dr["Lname"]);
			dt.Mname= Convert.ToString(dr["Mname"]);
			return dt;
		}

		/// <summary>
		///  组织参数列表
		/// <summary>
		/// <param name='obj'>数据结构对象</param>
		/// <returns>参数列表</returns>
		public override SqlParameter[] GetParameter( object obj )
		{
			HuibackupDT dt = (HuibackupDT)obj;
			SqlParameter[] prams =
			{
				MakeInParam("@DBirth" ,SqlDbType.DateTime,8,dt.DBirth),
				MakeInParam("@Modtime" ,SqlDbType.DateTime,8,dt.Modtime),
				MakeInParam("@id" ,SqlDbType.Int,4,dt.id),
				MakeInParam("@TYears" ,SqlDbType.Int,4,dt.TYears),
				MakeInParam("@TMonths" ,SqlDbType.Int,4,dt.TMonths),
				MakeInParam("@Param4" ,SqlDbType.NVarChar,400,dt.Param4),
				MakeInParam("@Param5" ,SqlDbType.NVarChar,400,dt.Param5),
				MakeInParam("@IsEmployed" ,SqlDbType.NVarChar,400,dt.IsEmployed),
				MakeInParam("@Param1" ,SqlDbType.NVarChar,400,dt.Param1),
				MakeInParam("@Param2" ,SqlDbType.NVarChar,400,dt.Param2),
				MakeInParam("@Param3" ,SqlDbType.NVarChar,400,dt.Param3),
				MakeInParam("@Mobile" ,SqlDbType.NVarChar,400,dt.Mobile),
				MakeInParam("@Username" ,SqlDbType.NVarChar,400,dt.Username),
				MakeInParam("@Password" ,SqlDbType.NVarChar,400,dt.Password),
				MakeInParam("@State" ,SqlDbType.NVarChar,400,dt.State),
				MakeInParam("@Postcode" ,SqlDbType.NVarChar,400,dt.Postcode),
				MakeInParam("@HTel" ,SqlDbType.NVarChar,400,dt.HTel),
				MakeInParam("@RAddress" ,SqlDbType.NVarChar,400,dt.RAddress),
				MakeInParam("@SAddress" ,SqlDbType.NVarChar,400,dt.SAddress),
				MakeInParam("@City" ,SqlDbType.NVarChar,400,dt.City),
				MakeInParam("@Email" ,SqlDbType.NVarChar,400,dt.Email),
				MakeInParam("@Issued" ,SqlDbType.NVarChar,400,dt.Issued),
				MakeInParam("@DNumber" ,SqlDbType.NVarChar,400,dt.DNumber),
				MakeInParam("@Fname" ,SqlDbType.NVarChar,400,dt.Fname),
				MakeInParam("@Lname" ,SqlDbType.NVarChar,400,dt.Lname),
				MakeInParam("@Mname" ,SqlDbType.NVarChar,400,dt.Mname)
			};
			return prams;
		}
		public HuibackupDT GetOneDT(int id)
		{
			return (HuibackupDT)GetOneItem(id);
		}
	}
}
