/// <copyright> 英网A1999-2006 </copyright>
/// <version>1.0</version>
/// <author>季宝福</author>
/// <email>jizhe@msn.com</email>
/// <log date="2006年4月19日">创建</log>

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

	public class LongteDB:DBAccess
	{

		/// <summary>
		///  按结构取值
		/// <summary>
		/// <param name='dr'>SqlDataReader</param>
		/// <param name='obj'>数据结构对象</param>
		/// <returns>数据结构对象</returns>
		public override object ConvertItem( SqlDataReader dr)
		{
			LongteDT dt = new LongteDT();
			dt.thome= Convert.ToDouble(dr["thome"]);
			dt.sid= Convert.ToInt32(dr["sid"]);
			dt.personsid= Convert.ToInt32(dr["personsid"]);
			dt.param5= Convert.ToString(dr["param5"]);
			dt.tper= Convert.ToString(dr["tper"]);
			dt.param3= Convert.ToString(dr["param3"]);
			dt.param4= Convert.ToString(dr["param4"]);
			dt.Rnum3= Convert.ToString(dr["Rnum3"]);
			dt.param1= Convert.ToString(dr["param1"]);
			dt.param2= Convert.ToString(dr["param2"]);
			dt.Rnum2= Convert.ToString(dr["Rnum2"]);
			dt.Rname3= Convert.ToString(dr["Rname3"]);
			dt.Rship3= Convert.ToString(dr["Rship3"]);
			dt.Rnum1= Convert.ToString(dr["Rnum1"]);
			dt.Rname2= Convert.ToString(dr["Rname2"]);
			dt.Rship2= Convert.ToString(dr["Rship2"]);
			dt.premethods= Convert.ToString(dr["premethods"]);
			dt.Rname1= Convert.ToString(dr["Rname1"]);
			dt.Rship1= Convert.ToString(dr["Rship1"]);
			dt.acname= Convert.ToString(dr["acname"]);
			dt.bsb= Convert.ToString(dr["bsb"]);
			dt.acnumber= Convert.ToString(dr["acnumber"]);
			dt.npayday= Convert.ToString(dr["npayday"]);
			dt.bankname= Convert.ToString(dr["bankname"]);
			dt.branch= Convert.ToString(dr["branch"]);
			dt.estatus= Convert.ToString(dr["estatus"]);
			dt.jobtitle= Convert.ToString(dr["jobtitle"]);
			dt.timeemployed= Convert.ToString(dr["timeemployed"]);
			dt.ename= Convert.ToString(dr["ename"]);
			dt.eaddress= Convert.ToString(dr["eaddress"]);
			dt.etel= Convert.ToString(dr["etel"]);
			return dt;
		}

		/// <summary>
		///  组织参数列表
		/// <summary>
		/// <param name='obj'>数据结构对象</param>
		/// <returns>参数列表</returns>
		public override SqlParameter[] GetParameter( object obj )
		{
			LongteDT dt = (LongteDT)obj;
			SqlParameter[] prams =
			{
				MakeInParam("@thome" ,SqlDbType.Float,8,dt.thome),
				MakeInParam("@sid" ,SqlDbType.Int,4,dt.sid),
				MakeInParam("@personsid" ,SqlDbType.Int,4,dt.personsid),
				MakeInParam("@param5" ,SqlDbType.NVarChar,1000,dt.param5),
				MakeInParam("@tper" ,SqlDbType.NVarChar,1000,dt.tper),
				MakeInParam("@param3" ,SqlDbType.NVarChar,1000,dt.param3),
				MakeInParam("@param4" ,SqlDbType.NVarChar,1000,dt.param4),
				MakeInParam("@Rnum3" ,SqlDbType.NVarChar,1000,dt.Rnum3),
				MakeInParam("@param1" ,SqlDbType.NVarChar,1000,dt.param1),
				MakeInParam("@param2" ,SqlDbType.NVarChar,1000,dt.param2),
				MakeInParam("@Rnum2" ,SqlDbType.NVarChar,1000,dt.Rnum2),
				MakeInParam("@Rname3" ,SqlDbType.NVarChar,1000,dt.Rname3),
				MakeInParam("@Rship3" ,SqlDbType.NVarChar,1000,dt.Rship3),
				MakeInParam("@Rnum1" ,SqlDbType.NVarChar,1000,dt.Rnum1),
				MakeInParam("@Rname2" ,SqlDbType.NVarChar,1000,dt.Rname2),
				MakeInParam("@Rship2" ,SqlDbType.NVarChar,1000,dt.Rship2),
				MakeInParam("@premethods" ,SqlDbType.NVarChar,1000,dt.premethods),
				MakeInParam("@Rname1" ,SqlDbType.NVarChar,1000,dt.Rname1),
				MakeInParam("@Rship1" ,SqlDbType.NVarChar,1000,dt.Rship1),
				MakeInParam("@acname" ,SqlDbType.NVarChar,1000,dt.acname),
				MakeInParam("@bsb" ,SqlDbType.NVarChar,1000,dt.bsb),
				MakeInParam("@acnumber" ,SqlDbType.NVarChar,1000,dt.acnumber),
				MakeInParam("@npayday" ,SqlDbType.NVarChar,1000,dt.npayday),
				MakeInParam("@bankname" ,SqlDbType.NVarChar,1000,dt.bankname),
				MakeInParam("@branch" ,SqlDbType.NVarChar,1000,dt.branch),
				MakeInParam("@estatus" ,SqlDbType.NVarChar,1000,dt.estatus),
				MakeInParam("@jobtitle" ,SqlDbType.NVarChar,1000,dt.jobtitle),
				MakeInParam("@timeemployed" ,SqlDbType.NVarChar,1000,dt.timeemployed),
				MakeInParam("@ename" ,SqlDbType.NVarChar,1000,dt.ename),
				MakeInParam("@eaddress" ,SqlDbType.NVarChar,4000,dt.eaddress),
				MakeInParam("@etel" ,SqlDbType.NVarChar,1000,dt.etel)
			};
			return prams;
		}
		public LongteDT GetOneDT(int id)
		{
			return (LongteDT)GetOneItem(id);
		}
	}
}
