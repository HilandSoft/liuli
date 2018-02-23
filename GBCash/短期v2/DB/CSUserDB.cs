namespace YingNet.WeiXing.DB
{
    using System;
    using System.Data;
    using System.Data.SqlClient;
    using YingNet.Common;
    using YingNet.Serialization;
    using YingNet.WeiXing.DB.Data;

    public class CSUserDB : DBAccess
    {
        public override object ConvertItem(SqlDataReader reader)
        {
            CSUserDT rdt = new CSUserDT();
            if (reader["UserID"] != DBNull.Value)
            {
                rdt.UserID = Convert.ToInt32(reader["UserID"]);
            }
            if (reader["UserName"] != DBNull.Value)
            {
                rdt.UserName = Convert.ToString(reader["UserName"]);
            }
            if (reader["Password"] != DBNull.Value)
            {
                rdt.Password = Convert.ToString(reader["Password"]);
            }
            if (reader["PasswordSalt"] != DBNull.Value)
            {
                rdt.PasswordSalt = Convert.ToString(reader["PasswordSalt"]);
            }
            if (reader["PasswordFormat"] != DBNull.Value)
            {
                rdt.PasswordFormat = Convert.ToInt32(reader["PasswordFormat"]);
            }
            if (reader["Nickname"] != DBNull.Value)
            {
                rdt.Nickname = Convert.ToString(reader["Nickname"]);
            }
            if (reader["Email"] != DBNull.Value)
            {
                rdt.Email = Convert.ToString(reader["Email"]);
            }
            if (reader["UserType"] != DBNull.Value)
            {
                rdt.UserType = Convert.ToInt32(reader["UserType"]);
            }
            if (reader["UserRank"] != DBNull.Value)
            {
                rdt.UserRank = Convert.ToInt32(reader["UserRank"]);
            }
            if (reader["UserClass"] != DBNull.Value)
            {
                rdt.UserClass = Convert.ToString(reader["UserClass"]);
            }
            if (reader["DateCreated"] != DBNull.Value)
            {
                rdt.DateCreated = Convert.ToDateTime(reader["DateCreated"]);
            }
            if (reader["LastLoginDate"] != DBNull.Value)
            {
                rdt.LastLoginDate = Convert.ToDateTime(reader["LastLoginDate"]);
            }
            if (reader["Enable"] != DBNull.Value)
            {
                rdt.Enable = Convert.ToInt32(reader["Enable"]);
            }
            rdt.SetSerializerData(ExtendedAttributesHelper.PopulateSerializerDataFromIDataReader(reader));
            return rdt;
        }

        public override SqlParameter[] GetParameter(object obj)
        {
            CSUserDT rdt = (CSUserDT) obj;
            SerializerData serializerData = rdt.GetSerializerData();
            SqlParameter[] parameterArray = new SqlParameter[15];
            if (rdt.UserID > 0)
            {
                parameterArray[0] = base.MakeInParam("@UserID", SqlDbType.Int, 4, rdt.UserID);
            }
            else
            {
                parameterArray[0] = base.MakeOutParam("@UserID", SqlDbType.Int, 4);
            }
            parameterArray[1] = base.MakeInParam("@UserName", SqlDbType.NVarChar, 0x80, rdt.UserName);
            parameterArray[2] = base.MakeInParam("@Password", SqlDbType.NVarChar, 0x80, rdt.Password);
            parameterArray[3] = base.MakeInParam("@PasswordSalt", SqlDbType.NVarChar, 0x80, rdt.PasswordSalt);
            parameterArray[4] = base.MakeInParam("@PasswordFormat", SqlDbType.Int, 4, rdt.PasswordFormat);
            parameterArray[5] = base.MakeInParam("@Nickname", SqlDbType.NVarChar, 0x80, rdt.Nickname);
            parameterArray[6] = base.MakeInParam("@Email", SqlDbType.NVarChar, 0x80, rdt.Email);
            parameterArray[7] = base.MakeInParam("@UserType", SqlDbType.Int, 4, rdt.UserType);
            parameterArray[8] = base.MakeInParam("@UserRank", SqlDbType.Int, 4, rdt.UserRank);
            parameterArray[9] = base.MakeInParam("@UserClass", SqlDbType.NVarChar, 0x80, rdt.UserClass);
            parameterArray[10] = base.MakeInParam("@DateCreated", SqlDbType.DateTime, 8, rdt.DateCreated);
            parameterArray[11] = base.MakeInParam("@LastLoginDate", SqlDbType.DateTime, 8, rdt.LastLoginDate);
            parameterArray[12] = base.MakeInParam("@Enable", SqlDbType.Int, 4, rdt.Enable);
            parameterArray[13] = base.MakeInParam("@PropertyNames", SqlDbType.NText, 0, serializerData.Keys);
            parameterArray[14] = base.MakeInParam("@PropertyValues", SqlDbType.NText, 0, serializerData.Values);
            return parameterArray;
        }

        public override string GetTableName()
        {
            return "cs_User";
        }
    }
}

