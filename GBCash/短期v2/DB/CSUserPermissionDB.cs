namespace YingNet.WeiXing.DB
{
    using System;
    using System.Data;
    using System.Data.SqlClient;
    using YingNet.Common;
    using YingNet.Serialization;
    using YingNet.WeiXing.DB.Data;

    public class CSUserPermissionDB : DBAccess
    {
        public override object ConvertItem(SqlDataReader reader)
        {
            CSUserPermissionDT ndt = new CSUserPermissionDT();
            if (reader["UserID"] != DBNull.Value)
            {
                ndt.UserID = Convert.ToInt32(reader["UserID"]);
            }
            if (reader["PermissionOther1"] != DBNull.Value)
            {
                ndt.PermissionOther1 = Convert.ToInt32(reader["PermissionOther1"]);
            }
            if (reader["PermissionOther2"] != DBNull.Value)
            {
                ndt.PermissionOther2 = Convert.ToInt32(reader["PermissionOther2"]);
            }
            if (reader["PermissionOther3"] != DBNull.Value)
            {
                ndt.PermissionOther3 = Convert.ToString(reader["PermissionOther3"]);
            }
            if (reader["PermissionOther4"] != DBNull.Value)
            {
                ndt.PermissionOther4 = Convert.ToString(reader["PermissionOther4"]);
            }
            ndt.SetSerializerData(ExtendedAttributesHelper.PopulateSerializerDataFromIDataReader(reader));
            return ndt;
        }

        public override SqlParameter[] GetParameter(object obj)
        {
            CSUserPermissionDT ndt = (CSUserPermissionDT) obj;
            SerializerData serializerData = ndt.GetSerializerData();
            return new SqlParameter[] { base.MakeInParam("@UserID", SqlDbType.Int, 4, ndt.UserID), base.MakeInParam("@PermissionOther1", SqlDbType.Int, 4, ndt.PermissionOther1), base.MakeInParam("@PermissionOther2", SqlDbType.Int, 4, ndt.PermissionOther2), base.MakeInParam("@PermissionOther3", SqlDbType.NVarChar, 0x100, ndt.PermissionOther3), base.MakeInParam("@PermissionOther4", SqlDbType.NVarChar, 0x100, ndt.PermissionOther4), base.MakeInParam("@PropertyNames", SqlDbType.NText, 0, serializerData.Keys), base.MakeInParam("@PropertyValues", SqlDbType.NText, 0, serializerData.Values) };
        }

        public override string GetTableName()
        {
            return "cs_UserPermission";
        }
    }
}

