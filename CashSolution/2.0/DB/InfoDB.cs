/// <copyright> 英网A1999-2005 </copyright>
/// <version>1.0</version>
/// <author>季宝福</author>
/// <email>jizhe@msn.com</email>
/// <log date="2005年9月16日">创建</log>

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

	public class InfoDB:DBAccess
	{

		/// <summary>
		///  按结构取值
		/// <summary>
		/// <param name='dr'>SqlDataReader</param>
		/// <param name='obj'>数据结构对象</param>
		/// <returns>数据结构对象</returns>
		public override object ConvertItem( SqlDataReader dr)
		{
			InfoDT dt = new InfoDT();
			dt.regtime= Convert.ToDateTime(dr["regtime"]);
			dt.id= Convert.ToInt32(dr["id"]);
			dt.huiSid= Convert.ToInt32(dr["huiSid"]);
			dt.isvalid= Convert.ToInt32(dr["isvalid"]);
			dt.param2= Convert.ToString(dr["param2"]);
			dt.param3= Convert.ToString(dr["param3"]);
			dt.Username= Convert.ToString(dr["Username"]);
			dt.type= Convert.ToString(dr["type"]);
			dt.param1= Convert.ToString(dr["param1"]);
			return dt;
		}

		/// <summary>
		///  组织参数列表
		/// <summary>
		/// <param name='obj'>数据结构对象</param>
		/// <returns>参数列表</returns>
		public override SqlParameter[] GetParameter( object obj )
		{
			InfoDT dt = (InfoDT)obj;
			SqlParameter[] prams =
			{
				MakeInParam("@regtime" ,SqlDbType.DateTime,8,dt.regtime),
				MakeInParam("@id" ,SqlDbType.Int,4,dt.id),
				MakeInParam("@huiSid" ,SqlDbType.Int,4,dt.huiSid),
				MakeInParam("@isvalid" ,SqlDbType.Int,4,dt.isvalid),
				MakeInParam("@param2" ,SqlDbType.NVarChar,400,dt.param2),
				MakeInParam("@param3" ,SqlDbType.NVarChar,400,dt.param3),
				MakeInParam("@Username" ,SqlDbType.NVarChar,400,dt.Username),
				MakeInParam("@type" ,SqlDbType.NVarChar,400,dt.type),
				MakeInParam("@param1" ,SqlDbType.NVarChar,400,dt.param1)
			};
			return prams;
		}
		public InfoDT GetOneDT(int id)
		{
			return (InfoDT)GetOneItem(id);
		}
	}
}
