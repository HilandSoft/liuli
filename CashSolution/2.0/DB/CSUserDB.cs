using System;
using System.Data;
using System.Data.SqlClient;
using YingNet.Common;
using YingNet.Serialization;
using YingNet.WeiXing.DB.Data;

namespace YingNet.WeiXing.DB
{
	/// <summary>
	/// CSUserDB 的摘要说明。
	/// </summary>
	public class CSUserDB:DBAccess
	{
		public CSUserDB()
		{
			
		}
		
		public override string GetTableName()
		{
			return "cs_User";
		}
		
		public override object ConvertItem(System.Data.SqlClient.SqlDataReader reader)
		{
			CSUserDT entity= new CSUserDT();
			
			if(reader["UserID"]!= DBNull.Value)
			{
				entity.UserID = Convert.ToInt32(reader["UserID"]);
			}
			if(reader["UserName"]!= DBNull.Value)
			{
				entity.UserName = Convert.ToString(reader["UserName"]);
			}
			if(reader["Password"]!= DBNull.Value)
			{
				entity.Password = Convert.ToString(reader["Password"]);
			}
			if(reader["PasswordSalt"]!= DBNull.Value)
			{
				entity.PasswordSalt = Convert.ToString(reader["PasswordSalt"]);
			}
			if(reader["PasswordFormat"]!= DBNull.Value)
			{
				entity.PasswordFormat = Convert.ToInt32(reader["PasswordFormat"]);
			}
			if(reader["Nickname"]!= DBNull.Value)
			{
				entity.Nickname = Convert.ToString(reader["Nickname"]);
			}
			if(reader["Email"]!= DBNull.Value)
			{
				entity.Email = Convert.ToString(reader["Email"]);
			}
			if(reader["UserType"]!= DBNull.Value)
			{
				entity.UserType = Convert.ToInt32(reader["UserType"]);
			}
			if(reader["UserRank"]!= DBNull.Value)
			{
				entity.UserRank = Convert.ToInt32(reader["UserRank"]);
			}
			if(reader["UserClass"]!= DBNull.Value)
			{
				entity.UserClass = Convert.ToString(reader["UserClass"]);
			}
			if(reader["DateCreated"]!= DBNull.Value)
			{
				entity.DateCreated = Convert.ToDateTime(reader["DateCreated"]);
			}
			if(reader["LastLoginDate"]!= DBNull.Value)
			{
				entity.LastLoginDate = Convert.ToDateTime(reader["LastLoginDate"]);
			}
			if(reader["Enable"]!= DBNull.Value)
			{
				entity.Enable = Convert.ToInt32(reader["Enable"]);
			}
			
			entity.SetSerializerData(ExtendedAttributesHelper.PopulateSerializerDataFromIDataReader(reader));
			
			return entity;
		}

		
		public override SqlParameter[] GetParameter( object obj )
		{
			CSUserDT entity = (CSUserDT)obj;
			SerializerData data = entity.GetSerializerData();
			SqlParameter[] prams = new SqlParameter[15];
			if(entity.UserID>0)
			{
				prams[0] = MakeInParam("@UserID", SqlDbType.Int, 4, entity.UserID);
			}
			else
			{
				prams[0]= MakeOutParam("@UserID", SqlDbType.Int, 4);
			}	
					
			prams[1] = MakeInParam("@UserName", SqlDbType.NVarChar, 128, entity.UserName);
			prams[2]= MakeInParam("@Password", SqlDbType.NVarChar, 128, entity.Password);
			prams[3]= MakeInParam("@PasswordSalt", SqlDbType.NVarChar, 128, entity.PasswordSalt);
			prams[4]= MakeInParam("@PasswordFormat", SqlDbType.Int, 4, entity.PasswordFormat);
			prams[5]= MakeInParam("@Nickname", SqlDbType.NVarChar, 128, entity.Nickname);
			prams[6]= MakeInParam("@Email", SqlDbType.NVarChar, 128, entity.Email);
			prams[7]= MakeInParam("@UserType", SqlDbType.Int, 4, entity.UserType);
			prams[8]= MakeInParam("@UserRank", SqlDbType.Int, 4, entity.UserRank);
			prams[9]= MakeInParam("@UserClass", SqlDbType.NVarChar, 128, entity.UserClass);
			prams[10]= MakeInParam("@DateCreated", SqlDbType.DateTime, 8, entity.DateCreated);
			prams[11]= MakeInParam("@LastLoginDate", SqlDbType.DateTime, 8, entity.LastLoginDate);
			prams[12]= MakeInParam("@Enable", SqlDbType.Int, 4, entity.Enable);

			prams[13]= MakeInParam("@PropertyNames" ,SqlDbType.NText,0,data.Keys);
			prams[14]= MakeInParam("@PropertyValues" ,SqlDbType.NText,0,data.Values);
			
			return prams;
		}
	}
}
