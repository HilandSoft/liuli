/// <copyright> 英网A1999-2005 </copyright>
/// <version>1.0</version>
/// <author>季宝福</author>
/// <email>jizhe@msn.com</email>
/// <log date="2005年8月11日">创建</log>

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

	public class ScheduleDB:DBAccess
	{

		/// <summary>
		///  按结构取值
		/// <summary>
		/// <param name='dr'>SqlDataReader</param>
		/// <param name='obj'>数据结构对象</param>
		/// <returns>数据结构对象</returns>
		public override object ConvertItem( SqlDataReader dr)
		{
			ScheduleDT dt = new ScheduleDT();
			dt.Datedue= Convert.ToDateTime(dr["Datedue"]);
			dt.RepayTime= Convert.ToDateTime(dr["RepayTime"]);
			dt.OperateTime= Convert.ToDateTime(dr["OperateTime"]);
			dt.Penalty= Convert.ToDouble(dr["Penalty"]);
			dt.Balance= Convert.ToDouble(dr["Balance"]);
			dt.Repaydue= Convert.ToDouble(dr["Repaydue"]);
			dt.Param5= Convert.ToDouble(dr["Param5"]);
			dt.Paid= Convert.ToDouble(dr["Paid"]);
			dt.Numberment= Convert.ToInt32(dr["Numberment"]);
			dt.id= Convert.ToInt32(dr["id"]);
			dt.huiSid= Convert.ToInt32(dr["huiSid"]);
			dt.IsValid= Convert.ToInt32(dr["IsValid"]);
			dt.Param4= Convert.ToString(dr["Param4"]);
			dt.Param1= Convert.ToString(dr["Param1"]);
			dt.Param2= Convert.ToString(dr["Param2"]);
			dt.Param3= Convert.ToString(dr["Param3"]);
			return dt;
		}

		/// <summary>
		///  组织参数列表
		/// <summary>
		/// <param name='obj'>数据结构对象</param>
		/// <returns>参数列表</returns>
		public override SqlParameter[] GetParameter( object obj )
		{
			ScheduleDT dt = (ScheduleDT)obj;
			SqlParameter[] prams =
			{
				MakeInParam("@Datedue" ,SqlDbType.DateTime,8,dt.Datedue),
				MakeInParam("@RepayTime" ,SqlDbType.DateTime,8,dt.RepayTime),
				MakeInParam("@OperateTime" ,SqlDbType.DateTime,8,dt.OperateTime),
				MakeInParam("@Penalty" ,SqlDbType.Float,8,dt.Penalty),
				MakeInParam("@Balance" ,SqlDbType.Float,8,dt.Balance),
				MakeInParam("@Repaydue" ,SqlDbType.Float,8,dt.Repaydue),
				MakeInParam("@Param5" ,SqlDbType.Float,8,dt.Param5),
				MakeInParam("@Paid" ,SqlDbType.Float,8,dt.Paid),
				MakeInParam("@Numberment" ,SqlDbType.Int,4,dt.Numberment),
				MakeInParam("@id" ,SqlDbType.Int,4,dt.id),
				MakeInParam("@huiSid" ,SqlDbType.Int,4,dt.huiSid),
				MakeInParam("@IsValid" ,SqlDbType.Int,4,dt.IsValid),
				MakeInParam("@Param4" ,SqlDbType.NVarChar,100,dt.Param4),
				MakeInParam("@Param1" ,SqlDbType.NVarChar,400,dt.Param1),
				MakeInParam("@Param2" ,SqlDbType.NVarChar,400,dt.Param2),
				MakeInParam("@Param3" ,SqlDbType.NVarChar,400,dt.Param3)
			};
			return prams;
		}

		public SqlParameter[] GetParameter2( object obj )
		{
			ScheduleDT dt = (ScheduleDT)obj;
			SqlParameter[] prams =
			{
				MakeInParam("@Datedue" ,SqlDbType.DateTime,8,dt.Datedue),
				MakeInParam("@Penalty" ,SqlDbType.Float,8,dt.Penalty),
				MakeInParam("@Balance" ,SqlDbType.Float,8,dt.Balance),
				MakeInParam("@Repaydue" ,SqlDbType.Float,8,dt.Repaydue),
				MakeInParam("@Param5" ,SqlDbType.Float,8,dt.Param5),
				MakeInParam("@Paid" ,SqlDbType.Float,8,dt.Paid),
				MakeInParam("@Numberment" ,SqlDbType.Int,4,dt.Numberment),
				MakeInParam("@id" ,SqlDbType.Int,4,dt.id),
				MakeInParam("@huiSid" ,SqlDbType.Int,4,dt.huiSid),
				MakeInParam("@IsValid" ,SqlDbType.Int,4,dt.IsValid),
				MakeInParam("@Param4" ,SqlDbType.NVarChar,100,dt.Param4),
				MakeInParam("@Param1" ,SqlDbType.NVarChar,400,dt.Param1),
				MakeInParam("@Param2" ,SqlDbType.NVarChar,400,dt.Param2),
				MakeInParam("@Param3" ,SqlDbType.NVarChar,400,dt.Param3)
			};
			return prams;
		}
		public ScheduleDT GetOneDT(int id)
		{
			return (ScheduleDT)GetOneItem(id);
		}
		
		public void DelByHuiSid(int huiSid)
		{
			string commandText = " delete from [Schedule] where huiSid= "+ huiSid;
			Open();
			try
			{
				SqlHelper.ExecuteNonQuery(oConn,CommandType.Text,commandText);
			}
			catch(Exception ex)
			{
				throw ex;
			}
			finally
			{
				Close();
			}
		}
		
		/// <summary>
		/// 删除会员的某次贷款
		/// </summary>
		/// <param name="employedID"></param>
		/// <remarks>会员的每次贷款都在Employed表生成一条记录</remarks>
		public void DelByEmployedID(int employedID)
		{
			//在Schedule表中,Param1表示Employed表的ID
			string commandText = " delete from [Schedule] where Param1= '"+ employedID+"'";
			Open();
			try
			{
				SqlHelper.ExecuteNonQuery(oConn,CommandType.Text,commandText);
			}
			catch(Exception ex)
			{
				throw ex;
			}
			finally
			{
				Close();
			}
		}

//		public override  bool Insert(object ob)
//		{
//			Open();
//			try 
//			{
//				SqlHelper.ExecuteNonQuery(oConn,CommandType.StoredProcedure,"proc_ScheduleDB_Insert2", GetParameter2(ob));
//
//			}
//			catch(Exception ex)
//			{
//				throw ex;
//			}
//			finally
//			{
//				Close();
//			}
//			return true;
//		}
	}
}
