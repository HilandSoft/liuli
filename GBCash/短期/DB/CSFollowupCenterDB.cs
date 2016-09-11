using System;
using System.Data;
using System.Data.SqlClient;
using YingNet.Common;
using YingNet.Serialization;
using YingNet.WeiXing.DB.Data;

namespace YingNet.WeiXing.DB
{
	/// <summary>
	/// CSFollowupCenterDB 的摘要说明。
	/// </summary>
	public class CSFollowupCenterDB:DBAccess
	{
		public CSFollowupCenterDB()
		{
			//
			// TODO: 在此处添加构造函数逻辑
			//
		}
		
		public override string GetTableName()
		{
			return "cs_FollowupCenter";
		}
		
		public override object ConvertItem(System.Data.SqlClient.SqlDataReader reader)
		{
			CSFollowupCenterDT entity= new CSFollowupCenterDT();
			
			if(reader["FollowupID"]!= DBNull.Value)
			{
				entity.FollowupID = Convert.ToInt32(reader["FollowupID"]);
			}
			if(reader["UserID"]!= DBNull.Value)
			{
				entity.UserID = Convert.ToInt32(reader["UserID"]);
			}
			if(reader["UserLoanType"]!= DBNull.Value)
			{
				entity.UserLoanType = (UserLoanTypes)Convert.ToInt32(reader["UserLoanType"]);
			}
			if(reader["FollowupStatus"]!= DBNull.Value)
			{
				entity.FollowupStatus =(FollowupCenterStatusEnum)Convert.ToInt32(reader["FollowupStatus"]);
			}
			if(reader["TaskInformation"]!= DBNull.Value)
			{
				entity.TaskInformation = Convert.ToString(reader["TaskInformation"]);
			}
			if(reader["RemindEnable"]!= DBNull.Value)
			{
				entity.RemindEnable = Convert.ToBoolean(reader["RemindEnable"]);
			}
			if(reader["RemindDate"]!= DBNull.Value)
			{
				entity.RemindDate = Convert.ToDateTime(reader["RemindDate"]);
			}
			if(reader["RemindDate2"]!= DBNull.Value)
			{
				entity.RemindDate2 = Convert.ToDateTime(reader["RemindDate2"]);
			}
			if(reader["RemindDate3"]!= DBNull.Value)
			{
				entity.RemindDate3 = Convert.ToDateTime(reader["RemindDate3"]);
			}
			if(reader["PostDate"]!= DBNull.Value)
			{
				entity.PostDate = Convert.ToDateTime(reader["PostDate"]);
			}
			if(reader["LastOperateUserID"]!= DBNull.Value)
			{
				entity.LastOperateUserID = Convert.ToInt32(reader["LastOperateUserID"]);
			}
			if(reader["LastOperateDate"]!= DBNull.Value)
			{
				entity.LastOperateDate = Convert.ToDateTime(reader["LastOperateDate"]);
			}
			
			entity.SetSerializerData(ExtendedAttributesHelper.PopulateSerializerDataFromIDataReader(reader));
			
			return entity;
		}
		
		public override SqlParameter[] GetParameter( object obj )
		{
			CSFollowupCenterDT entity = (CSFollowupCenterDT)obj;
			SerializerData data = entity.GetSerializerData();
			SqlParameter[] prams =
			{
				GetMainKeySqlParameter(entity.FollowupID),
				//MakeOutParam("@FollowupID" ,SqlDbType.Int,4),
				MakeInParam("@UserID" ,SqlDbType.Int,4,entity.UserID),
				MakeInParam("@UserLoanType" ,SqlDbType.Int,4,(int)entity.UserLoanType),
				MakeInParam("@FollowupStatus" ,SqlDbType.Int,4,(int)entity.FollowupStatus),
				MakeInParam("@TaskInformation" ,SqlDbType.NVarChar,4000,entity.TaskInformation),
				MakeInParam("@RemindEnable" ,SqlDbType.Bit,1,entity.RemindEnable),
				MakeInParam("@RemindDate" ,SqlDbType.DateTime,8,entity.RemindDate),
				MakeInParam("@RemindDate2" ,SqlDbType.DateTime,8,entity.RemindDate2),
				MakeInParam("@RemindDate3" ,SqlDbType.DateTime,8,entity.RemindDate3),
				MakeInParam("@PostDate" ,SqlDbType.DateTime,8,entity.PostDate),
				MakeInParam("@LastOperateUserID" ,SqlDbType.Int,4,entity.LastOperateUserID),
				MakeInParam("@LastOperateDate" ,SqlDbType.DateTime,8,entity.LastOperateDate),
				
				MakeInParam("@PropertyNames" ,SqlDbType.NText,0,data.Keys),
				MakeInParam("@PropertyValues" ,SqlDbType.NText,0,data.Values)
			};	
			return prams;
		}
		
		private SqlParameter GetMainKeySqlParameter(int followupID)
		{
			SqlParameter para= null;			
			if(followupID>0)
			{
				para = MakeInParam("@FollowupID", SqlDbType.Int, 4, followupID);
			}
			else
			{
				para = MakeOutParam("@FollowupID", SqlDbType.Int, 4);
			}
			
			return para;
		}
	}
}
