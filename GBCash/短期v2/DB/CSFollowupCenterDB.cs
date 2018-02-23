namespace YingNet.WeiXing.DB
{
    using System;
    using System.Data;
    using System.Data.SqlClient;
    using YingNet.Common;
    using YingNet.Serialization;
    using YingNet.WeiXing.DB.Data;

    public class CSFollowupCenterDB : DBAccess
    {
        public override object ConvertItem(SqlDataReader reader)
        {
            CSFollowupCenterDT rdt = new CSFollowupCenterDT();
            if (reader["FollowupID"] != DBNull.Value)
            {
                rdt.FollowupID = Convert.ToInt32(reader["FollowupID"]);
            }
            if (reader["UserID"] != DBNull.Value)
            {
                rdt.UserID = Convert.ToInt32(reader["UserID"]);
            }
            if (reader["UserLoanType"] != DBNull.Value)
            {
                rdt.UserLoanType = (UserLoanTypes) Convert.ToInt32(reader["UserLoanType"]);
            }
            if (reader["FollowupStatus"] != DBNull.Value)
            {
                rdt.FollowupStatus = (FollowupCenterStatusEnum) Convert.ToInt32(reader["FollowupStatus"]);
            }
            if (reader["TaskInformation"] != DBNull.Value)
            {
                rdt.TaskInformation = Convert.ToString(reader["TaskInformation"]);
            }
            if (reader["RemindEnable"] != DBNull.Value)
            {
                rdt.RemindEnable = Convert.ToBoolean(reader["RemindEnable"]);
            }
            if (reader["RemindDate"] != DBNull.Value)
            {
                rdt.RemindDate = Convert.ToDateTime(reader["RemindDate"]);
            }
            if (reader["RemindDate2"] != DBNull.Value)
            {
                rdt.RemindDate2 = Convert.ToDateTime(reader["RemindDate2"]);
            }
            if (reader["RemindDate3"] != DBNull.Value)
            {
                rdt.RemindDate3 = Convert.ToDateTime(reader["RemindDate3"]);
            }
            if (reader["PostDate"] != DBNull.Value)
            {
                rdt.PostDate = Convert.ToDateTime(reader["PostDate"]);
            }
            if (reader["LastOperateUserID"] != DBNull.Value)
            {
                rdt.LastOperateUserID = Convert.ToInt32(reader["LastOperateUserID"]);
            }
            if (reader["LastOperateDate"] != DBNull.Value)
            {
                rdt.LastOperateDate = Convert.ToDateTime(reader["LastOperateDate"]);
            }
            rdt.SetSerializerData(ExtendedAttributesHelper.PopulateSerializerDataFromIDataReader(reader));
            return rdt;
        }

        private SqlParameter GetMainKeySqlParameter(int followupID)
        {
            if (followupID > 0)
            {
                return base.MakeInParam("@FollowupID", SqlDbType.Int, 4, followupID);
            }
            return base.MakeOutParam("@FollowupID", SqlDbType.Int, 4);
        }

        public override SqlParameter[] GetParameter(object obj)
        {
            CSFollowupCenterDT rdt = (CSFollowupCenterDT) obj;
            SerializerData serializerData = rdt.GetSerializerData();
            return new SqlParameter[] { this.GetMainKeySqlParameter(rdt.FollowupID), base.MakeInParam("@UserID", SqlDbType.Int, 4, rdt.UserID), base.MakeInParam("@UserLoanType", SqlDbType.Int, 4, (int) rdt.UserLoanType), base.MakeInParam("@FollowupStatus", SqlDbType.Int, 4, (int) rdt.FollowupStatus), base.MakeInParam("@TaskInformation", SqlDbType.NVarChar, 0xfa0, rdt.TaskInformation), base.MakeInParam("@RemindEnable", SqlDbType.Bit, 1, rdt.RemindEnable), base.MakeInParam("@RemindDate", SqlDbType.DateTime, 8, rdt.RemindDate), base.MakeInParam("@RemindDate2", SqlDbType.DateTime, 8, rdt.RemindDate2), base.MakeInParam("@RemindDate3", SqlDbType.DateTime, 8, rdt.RemindDate3), base.MakeInParam("@PostDate", SqlDbType.DateTime, 8, rdt.PostDate), base.MakeInParam("@LastOperateUserID", SqlDbType.Int, 4, rdt.LastOperateUserID), base.MakeInParam("@LastOperateDate", SqlDbType.DateTime, 8, rdt.LastOperateDate), base.MakeInParam("@PropertyNames", SqlDbType.NText, 0, serializerData.Keys), base.MakeInParam("@PropertyValues", SqlDbType.NText, 0, serializerData.Values) };
        }

        public override string GetTableName()
        {
            return "cs_FollowupCenter";
        }
    }
}

