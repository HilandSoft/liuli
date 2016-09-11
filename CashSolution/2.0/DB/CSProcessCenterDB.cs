using System;
using System.Data;
using System.Data.SqlClient;
using YingNet.Common;
using YingNet.Serialization;
using YingNet.WeiXing.DB.Data;

namespace YingNet.WeiXing.DB
{
	/// <summary>
	/// CSProcessCenterDB 的摘要说明。
	/// </summary>
	public class CSProcessCenterDB:DBAccess
	{
		public CSProcessCenterDB()
		{
			//
			// TODO: 在此处添加构造函数逻辑
			//
		}
		
		public override string GetTableName()
		{
			return "cs_ProcessCenter";
		}
		
		public override object ConvertItem(System.Data.SqlClient.SqlDataReader reader)
		{
			CSProcessCenterDT entity= new CSProcessCenterDT();
			
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
				entity.UserLoanType = (UserLoanTypes)Convert.ToInt32(reader["UserLoanType"]);
			}
			if(reader["IsFirstLoan"]!= DBNull.Value)
			{
				entity.IsFirstLoan = Convert.ToBoolean(reader["IsFirstLoan"]);
			}
			if(reader["ProcessStatus"]!= DBNull.Value)
			{
				entity.ProcessStatus = (ProcessCenterStatusEnum)Convert.ToInt32(reader["ProcessStatus"]);
			}
			if(reader["ConversationTrack"]!= DBNull.Value)
			{
				entity.ConversationTrack = Convert.ToString(reader["ConversationTrack"]);
			}
			if(reader["Task"]!= DBNull.Value)
			{
				entity.Task = Convert.ToString(reader["Task"]);
			}
			if(reader["DocumentRequired"]!= DBNull.Value)
			{
				entity.DocumentRequired = Convert.ToString(reader["DocumentRequired"]);
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
			
			if(reader["LoanID"]!= DBNull.Value)
			{
				entity.LoanID = Convert.ToInt32(reader["LoanID"]);
			}
			if(reader["ProcessOther1"]!= DBNull.Value)
			{
				entity.CurrentStateIsAlerted = (InformationAlertStates)Convert.ToInt32(reader["ProcessOther1"]);
			}
			if(reader["ProcessOther2"]!= DBNull.Value)
			{
				entity.ProcessOther2 = Convert.ToInt32(reader["ProcessOther2"]);
			}
			if(reader["ProcessOther3"]!= DBNull.Value)
			{
				entity.ProcessOther3 = Convert.ToString(reader["ProcessOther3"]);
			}
			if(reader["ProcessOther4"]!= DBNull.Value)
			{
				entity.ProcessOther4 = Convert.ToString(reader["ProcessOther4"]);
			}
			
			entity.SetSerializerData(ExtendedAttributesHelper.PopulateSerializerDataFromIDataReader(reader));
			
			return entity;
		}
		
		public override SqlParameter[] GetParameter( object obj )
		{
			CSProcessCenterDT entity = (CSProcessCenterDT)obj;
			SerializerData data = entity.GetSerializerData();
			SqlParameter[] prams =
			{
				GetMainKeySqlParameter(entity.ProcessID),
				MakeInParam("@UserID" ,SqlDbType.Int,4,entity.UserID),
				MakeInParam("@UserLoanType" ,SqlDbType.Int,4,(int)entity.UserLoanType),
				MakeInParam("@IsFirstLoan" ,SqlDbType.Bit,1,entity.IsFirstLoan),
				MakeInParam("@ProcessStatus" ,SqlDbType.Int,4,(int)entity.ProcessStatus),
				MakeInParam("@ConversationTrack" ,SqlDbType.NVarChar,4000,entity.ConversationTrack),
				MakeInParam("@Task" ,SqlDbType.NVarChar,4000,entity.Task),
				MakeInParam("@DocumentRequired" ,SqlDbType.NVarChar,4000,entity.DocumentRequired),
				MakeInParam("@PostDate" ,SqlDbType.DateTime,8,entity.PostDate),
				MakeInParam("@LastOperateUserID" ,SqlDbType.Int,4,entity.LastOperateUserID),
				MakeInParam("@LastOperateDate" ,SqlDbType.DateTime,8,entity.LastOperateDate),
				
				MakeInParam("@PropertyNames" ,SqlDbType.NText,0,data.Keys),
				MakeInParam("@PropertyValues" ,SqlDbType.NText,0,data.Values),
				
				MakeInParam("@LoanID" ,SqlDbType.Int,4,entity.LoanID),
				MakeInParam("@ProcessOther1" ,SqlDbType.Int,4,(int)entity.CurrentStateIsAlerted),
				MakeInParam("@ProcessOther2" ,SqlDbType.Int,4,entity.ProcessOther2),
				MakeInParam("@ProcessOther3" ,SqlDbType.NVarChar,2000,entity.ProcessOther3),
				MakeInParam("@ProcessOther4" ,SqlDbType.NVarChar,2000,entity.ProcessOther4),
			};	
			return prams;
		}
		
		private SqlParameter GetMainKeySqlParameter(int processID)
		{
			SqlParameter para= null;			
			if(processID>0)
			{
				para = MakeInParam("@ProcessID", SqlDbType.Int, 4, processID);
			}
			else
			{
				para = MakeOutParam("@ProcessID", SqlDbType.Int, 4);
			}
			
			return para;
		}
	}
}
