using System;
using System.Data;
using System.Data.SqlClient;
using YingNet.Common;
using YingNet.Serialization;
using YingNet.WeiXing.DB.Data;

namespace YingNet.WeiXing.DB
{
	/// <summary>
	/// CSUserPermissionDB 的摘要说明。
	/// </summary>
	public class CSUserPermissionDB:DBAccess
	{
		public CSUserPermissionDB()
		{
			//
			// TODO: 在此处添加构造函数逻辑
			//
		}
		
		public override string GetTableName()
		{
			return "cs_UserPermission";
		}
		
		public override object ConvertItem(System.Data.SqlClient.SqlDataReader reader)
		{
			CSUserPermissionDT entity= new CSUserPermissionDT();
			
			if(reader["UserID"]!= DBNull.Value)
			{
				entity.UserID = Convert.ToInt32(reader["UserID"]);
			}
			
			if(reader["PermissionOther1"]!= DBNull.Value)
			{
				entity.PermissionOther1 = Convert.ToInt32(reader["PermissionOther1"]);
			}
			if(reader["PermissionOther2"]!= DBNull.Value)
			{
				entity.PermissionOther2 = Convert.ToInt32(reader["PermissionOther2"]);
			}
			if(reader["PermissionOther3"]!= DBNull.Value)
			{
				entity.PermissionOther3 = Convert.ToString(reader["PermissionOther3"]);
			}
			if(reader["PermissionOther4"]!= DBNull.Value)
			{
				entity.PermissionOther4 = Convert.ToString(reader["PermissionOther4"]);
			}
			
			entity.SetSerializerData(ExtendedAttributesHelper.PopulateSerializerDataFromIDataReader(reader));
			
			return entity;
		}
		
		public override SqlParameter[] GetParameter( object obj )
		{
			CSUserPermissionDT entity = (CSUserPermissionDT)obj;
			SerializerData data = entity.GetSerializerData(); 
			
			SqlParameter[] prams =
			{
				MakeInParam("@UserID" ,SqlDbType.Int,4,entity.UserID),
				MakeInParam("@PermissionOther1" ,SqlDbType.Int,4,entity.PermissionOther1),
				MakeInParam("@PermissionOther2" ,SqlDbType.Int,4,entity.PermissionOther2),
				MakeInParam("@PermissionOther3" ,SqlDbType.NVarChar,256,entity.PermissionOther3),
				MakeInParam("@PermissionOther4" ,SqlDbType.NVarChar,256,entity.PermissionOther4),
				
				MakeInParam("@PropertyNames" ,SqlDbType.NText,0,data.Keys),
				MakeInParam("@PropertyValues" ,SqlDbType.NText,0,data.Values)
			};	
			return prams;
		}
	}
}
