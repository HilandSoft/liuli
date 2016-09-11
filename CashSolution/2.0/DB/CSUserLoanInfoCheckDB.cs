using System;
using System.Data;
using System.Data.SqlClient;
using YingNet.Common;
using YingNet.Serialization;
using YingNet.WeiXing.DB.Data;

namespace YingNet.WeiXing.DB
{
	/// <summary>
	/// CSUserLoanInfoCheckDB 的摘要说明。
	/// </summary>
	public class CSUserLoanInfoCheckDB:DBAccess
	{
		public CSUserLoanInfoCheckDB()
		{
			//
			// TODO: 在此处添加构造函数逻辑
			//
		}
		
		public override string GetTableName()
		{
			return "cs_UserLoanInfoCheck";
		}
		
		public override object ConvertItem(System.Data.SqlClient.SqlDataReader reader)
		{
			CSUserLoanInfoCheckDT entity= new CSUserLoanInfoCheckDT();
			
			if(reader["ProcessID"]!= DBNull.Value)
			{
				entity.ProcessID = Convert.ToInt32(reader["ProcessID"]);
			}
			if(reader["UserID"]!= DBNull.Value)
			{
				entity.UserID = Convert.ToInt32(reader["UserID"]);
			}
			if(reader["UserLoanType"]!= DBNull.Value)
			{
				entity.UserLoanType =(UserLoanTypes) Convert.ToInt32(reader["UserLoanType"]);
			}
			if(reader["EmployerName"]!= DBNull.Value)
			{
				entity.EmployerName = Convert.ToString(reader["EmployerName"]);
			}
			if(reader["EmployerAddress"]!= DBNull.Value)
			{
				entity.EmployerAddress = Convert.ToString(reader["EmployerAddress"]);
			}
			if(reader["EmployerTelephone"]!= DBNull.Value)
			{
				entity.EmployerTelephone = Convert.ToString(reader["EmployerTelephone"]);
			}
			if(reader["WorkTelephone"]!= DBNull.Value)
			{
				entity.WorkTelephone = Convert.ToString(reader["WorkTelephone"]);
			}
			if(reader["HomeTelephone"]!= DBNull.Value)
			{
				entity.HomeTelephone = Convert.ToString(reader["HomeTelephone"]);
			}
			if(reader["EmploymentStatus"]!= DBNull.Value)
			{
				entity.EmploymentStatus = Convert.ToInt32(reader["EmploymentStatus"]);
			}
			if(reader["JobTitle"]!= DBNull.Value)
			{
				entity.JobTitle = Convert.ToString(reader["JobTitle"]);
			}
			if(reader["TimeEmployed"]!= DBNull.Value)
			{
				entity.TimeEmployed = Convert.ToString(reader["TimeEmployed"]);
			}
			if(reader["TakeHomePayAfterTaxes"]!= DBNull.Value)
			{
				entity.TakeHomePayAfterTaxes = Convert.ToDecimal(reader["TakeHomePayAfterTaxes"]);
			}
			if(reader["PayFrequency"]!= DBNull.Value)
			{
				entity.PayFrequency = Convert.ToString(reader["PayFrequency"]);
			}
			if(reader["NextPayday"]!= DBNull.Value)
			{
				entity.NextPayday = Convert.ToDateTime(reader["NextPayday"]);
			}

			if(reader["CheckOther1"]!= DBNull.Value)
			{
				entity.CheckOther1 = Convert.ToInt32(reader["CheckOther1"]);
			}
			if(reader["CheckOther2"]!= DBNull.Value)
			{
				entity.CheckOther2 = Convert.ToInt32(reader["CheckOther2"]);
			}
			if(reader["CheckOther3"]!= DBNull.Value)
			{
				entity.CheckOther3 = Convert.ToString(reader["CheckOther3"]);
			}
			if(reader["CheckOther4"]!= DBNull.Value)
			{
				entity.CheckOther4 = Convert.ToString(reader["CheckOther4"]);
			}
			
			entity.SetSerializerData(ExtendedAttributesHelper.PopulateSerializerDataFromIDataReader(reader));
			
			return entity;
		}
		
		public override SqlParameter[] GetParameter( object obj )
		{
			CSUserLoanInfoCheckDT entity = (CSUserLoanInfoCheckDT)obj;
			SerializerData data = entity.GetSerializerData();
			SqlParameter[] prams =
			{
				MakeInParam("@ProcessID" ,SqlDbType.Int,4,entity.ProcessID),
				MakeInParam("@UserID" ,SqlDbType.Int,4,entity.UserID),
				MakeInParam("@UserLoanType" ,SqlDbType.Int,4,(int)entity.UserLoanType),
				MakeInParam("@EmployerName" ,SqlDbType.NVarChar,128,entity.EmployerName),
				MakeInParam("@EmployerAddress" ,SqlDbType.NVarChar,128,entity.EmployerAddress),
				MakeInParam("@EmployerTelephone" ,SqlDbType.NVarChar,128,entity.EmployerTelephone),
				MakeInParam("@WorkTelephone" ,SqlDbType.NVarChar,128,entity.WorkTelephone),
				MakeInParam("@HomeTelephone" ,SqlDbType.NVarChar,128,entity.HomeTelephone),
				MakeInParam("@EmploymentStatus" ,SqlDbType.Int,4,entity.EmploymentStatus),
				MakeInParam("@JobTitle" ,SqlDbType.NVarChar,128,entity.JobTitle),
				MakeInParam("@TimeEmployed" ,SqlDbType.NVarChar,128,entity.TimeEmployed),
				MakeInParam("@TakeHomePayAfterTaxes" ,SqlDbType.Money,8,entity.TakeHomePayAfterTaxes),
				MakeInParam("@PayFrequency" ,SqlDbType.NVarChar,128,entity.PayFrequency),
				MakeInParam("@NextPayday" ,SqlDbType.DateTime,8,entity.NextPayday),
				MakeInParam("@CheckOther1" ,SqlDbType.Int,4,entity.CheckOther1),
				MakeInParam("@CheckOther2" ,SqlDbType.Int,4,entity.CheckOther2),
				MakeInParam("@CheckOther3" ,SqlDbType.NVarChar,256,entity.CheckOther3),
				MakeInParam("@CheckOther4" ,SqlDbType.NVarChar,256,entity.CheckOther4),
				
				MakeInParam("@PropertyNames" ,SqlDbType.NText,0,data.Keys),
				MakeInParam("@PropertyValues" ,SqlDbType.NText,0,data.Values)
			};	
			return prams;
		}
		
//		private SqlParameter GetMainKeySqlParameter(int InfoID)
//		{
//			SqlParameter para= null;			
//			if(InfoID>0)
//			{
//				para = MakeInParam("@InfoID", SqlDbType.Int, 4, InfoID);
//			}
//			else
//			{
//				para = MakeOutParam("@InfoID", SqlDbType.Int, 4);
//			}
//			
//			return para;
//		}
	}
}
