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

	public class LongtpDB:DBAccess
	{

		/// <summary>
		///  按结构取值
		/// <summary>
		/// <param name='dr'>SqlDataReader</param>
		/// <param name='obj'>数据结构对象</param>
		/// <returns>数据结构对象</returns>
		public override object ConvertItem( SqlDataReader dr)
		{
			LongtpDT dt = new LongtpDT();
			dt.regdate= Convert.ToDateTime(dr["regdate"]);
			dt.borrow= Convert.ToDouble(dr["borrow"]);
			dt.sid= Convert.ToInt32(dr["sid"]);
			dt.param3= Convert.ToString(dr["param3"]);
			dt.param4= Convert.ToString(dr["param4"]);
			dt.param5= Convert.ToString(dr["param5"]);
			dt.terms= Convert.ToString(dr["terms"]);
			dt.param1= Convert.ToString(dr["param1"]);
			dt.param2= Convert.ToString(dr["param2"]);
			dt.timeaddress= Convert.ToString(dr["timeaddress"]);
			dt.landlord= Convert.ToString(dr["landlord"]);
			dt.areatel= Convert.ToString(dr["areatel"]);
			dt.suburb= Convert.ToString(dr["suburb"]);
			dt.state= Convert.ToString(dr["state"]);
			dt.postcode= Convert.ToString(dr["postcode"]);
			dt.restatus= Convert.ToString(dr["restatus"]);
			dt.unitno= Convert.ToString(dr["unitno"]);
			dt.street= Convert.ToString(dr["street"]);
			dt.lnumber= Convert.ToString(dr["lnumber"]);
			dt.lstate= Convert.ToString(dr["lstate"]);
			dt.mastatus= Convert.ToString(dr["mastatus"]);
			dt.worktel= Convert.ToString(dr["worktel"]);
			dt.mobiletel= Convert.ToString(dr["mobiletel"]);
			dt.email= Convert.ToString(dr["email"]);
			dt.gender= Convert.ToString(dr["gender"]);
			dt.birth= Convert.ToString(dr["birth"]);
			dt.hometel= Convert.ToString(dr["hometel"]);
			dt.fname= Convert.ToString(dr["fname"]);
			dt.mname= Convert.ToString(dr["mname"]);
			dt.sname= Convert.ToString(dr["sname"]);
			dt.existing= Convert.ToString(dr["existing"]);
			dt.refnumber= Convert.ToString(dr["refnumber"]);
			dt.title= Convert.ToString(dr["title"]);
			dt.purpose= Convert.ToString(dr["purpose"]);
			return dt;
		}

		/// <summary>
		///  组织参数列表
		/// <summary>
		/// <param name='obj'>数据结构对象</param>
		/// <returns>参数列表</returns>
		public override SqlParameter[] GetParameter( object obj )
		{
			LongtpDT dt = (LongtpDT)obj;
			SqlParameter[] prams =
			{
				MakeInParam("@regdate" ,SqlDbType.DateTime,8,dt.regdate),
				MakeInParam("@borrow" ,SqlDbType.Float,8,dt.borrow),
				MakeInParam("@sid" ,SqlDbType.Int,4,dt.sid),
				MakeInParam("@param3" ,SqlDbType.NVarChar,1000,dt.param3),
				MakeInParam("@param4" ,SqlDbType.NVarChar,1000,dt.param4),
				MakeInParam("@param5" ,SqlDbType.NVarChar,1000,dt.param5),
				MakeInParam("@terms" ,SqlDbType.NVarChar,1000,dt.terms),
				MakeInParam("@param1" ,SqlDbType.NVarChar,1000,dt.param1),
				MakeInParam("@param2" ,SqlDbType.NVarChar,1000,dt.param2),
				MakeInParam("@timeaddress" ,SqlDbType.NVarChar,1000,dt.timeaddress),
				MakeInParam("@landlord" ,SqlDbType.NVarChar,1000,dt.landlord),
				MakeInParam("@areatel" ,SqlDbType.NVarChar,1000,dt.areatel),
				MakeInParam("@suburb" ,SqlDbType.NVarChar,1000,dt.suburb),
				MakeInParam("@state" ,SqlDbType.NVarChar,1000,dt.state),
				MakeInParam("@postcode" ,SqlDbType.NVarChar,1000,dt.postcode),
				MakeInParam("@restatus" ,SqlDbType.NVarChar,1000,dt.restatus),
				MakeInParam("@unitno" ,SqlDbType.NVarChar,1000,dt.unitno),
				MakeInParam("@street" ,SqlDbType.NVarChar,1000,dt.street),
				MakeInParam("@lnumber" ,SqlDbType.NVarChar,1000,dt.lnumber),
				MakeInParam("@lstate" ,SqlDbType.NVarChar,1000,dt.lstate),
				MakeInParam("@mastatus" ,SqlDbType.NVarChar,1000,dt.mastatus),
				MakeInParam("@worktel" ,SqlDbType.NVarChar,1000,dt.worktel),
				MakeInParam("@mobiletel" ,SqlDbType.NVarChar,1000,dt.mobiletel),
				MakeInParam("@email" ,SqlDbType.NVarChar,1000,dt.email),
				MakeInParam("@gender" ,SqlDbType.NVarChar,1000,dt.gender),
				MakeInParam("@birth" ,SqlDbType.NVarChar,1000,dt.birth),
				MakeInParam("@hometel" ,SqlDbType.NVarChar,1000,dt.hometel),
				MakeInParam("@fname" ,SqlDbType.NVarChar,1000,dt.fname),
				MakeInParam("@mname" ,SqlDbType.NVarChar,1000,dt.mname),
				MakeInParam("@sname" ,SqlDbType.NVarChar,1000,dt.sname),
				MakeInParam("@existing" ,SqlDbType.NVarChar,1000,dt.existing),
				MakeInParam("@refnumber" ,SqlDbType.NVarChar,4000,dt.refnumber),
				MakeInParam("@title" ,SqlDbType.NVarChar,1000,dt.title),
				MakeInParam("@purpose" ,SqlDbType.Text,16,dt.purpose)
			};
			return prams;
		}
		public LongtpDT GetOneDT(int id)
		{
			return (LongtpDT)GetOneItem(id);
		}

		public int Insert2(object ob)
		{
			int identity=-1;
			try 
			{
				DataSet ds=SqlHelper.ExecuteDataset(Common.Config.DataSource,CommandType.StoredProcedure,"proc_LongtpDB_Insert2", GetParameter(ob));
				identity=Convert.ToInt32(ds.Tables[0].Rows[0][0]);
			}
			catch(Exception ex)
			{
				throw ex;
			}
			return identity;
		}
	}
}
