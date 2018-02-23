namespace YingNet.WeiXing.DB
{
    using System;
    using System.Data;
    using System.Data.SqlClient;
    using YingNet.Common;
    using YingNet.Serialization;
    using YingNet.WeiXing.DB.Data;

    public class CSProcessCenterDB : DBAccess
    {
        public override object ConvertItem(SqlDataReader reader)
        {
            CSProcessCenterDT rdt = new CSProcessCenterDT();
            if (reader["ProcessID"] != DBNull.Value)
            {
                rdt.ProcessID = Convert.ToInt32(reader["ProcessID"]);
            }
            if (reader["UserID"] != DBNull.Value)
            {
                rdt.UserID = Convert.ToInt32(reader["UserID"]);
            }
            if (reader["UserLoanType"] != DBNull.Value)
            {
                rdt.UserLoanType = (UserLoanTypes) Convert.ToInt32(reader["UserLoanType"]);
            }
            if (reader["IsFirstLoan"] != DBNull.Value)
            {
                rdt.IsFirstLoan = Convert.ToBoolean(reader["IsFirstLoan"]);
            }
            if (reader["ProcessStatus"] != DBNull.Value)
            {
                rdt.ProcessStatus = (ProcessCenterStatusEnum) Convert.ToInt32(reader["ProcessStatus"]);
            }
            if (reader["ConversationTrack"] != DBNull.Value)
            {
                rdt.ConversationTrack = Convert.ToString(reader["ConversationTrack"]);
            }
            if (reader["Task"] != DBNull.Value)
            {
                rdt.Task = Convert.ToString(reader["Task"]);
            }
            if (reader["DocumentRequired"] != DBNull.Value)
            {
                rdt.DocumentRequired = Convert.ToString(reader["DocumentRequired"]);
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
            if (reader["LoanID"] != DBNull.Value)
            {
                rdt.LoanID = Convert.ToInt32(reader["LoanID"]);
            }
            if (reader["ProcessOther1"] != DBNull.Value)
            {
                rdt.CurrentStateIsAlerted = (InformationAlertStates) Convert.ToInt32(reader["ProcessOther1"]);
            }
            if (reader["ProcessOther2"] != DBNull.Value)
            {
                rdt.ProcessOther2 = Convert.ToInt32(reader["ProcessOther2"]);
            }
            if (reader["ProcessOther3"] != DBNull.Value)
            {
                rdt.ProcessOther3 = Convert.ToString(reader["ProcessOther3"]);
            }
            if (reader["ProcessOther4"] != DBNull.Value)
            {
                rdt.ProcessOther4 = Convert.ToString(reader["ProcessOther4"]);
            }
            rdt.SetSerializerData(ExtendedAttributesHelper.PopulateSerializerDataFromIDataReader(reader));
            return rdt;
        }

        private SqlParameter GetMainKeySqlParameter(int processID)
        {
            if (processID > 0)
            {
                return base.MakeInParam("@ProcessID", SqlDbType.Int, 4, processID);
            }
            return base.MakeOutParam("@ProcessID", SqlDbType.Int, 4);
        }

        public override SqlParameter[] GetParameter(object obj)
        {
            CSProcessCenterDT rdt = (CSProcessCenterDT) obj;
            SerializerData serializerData = rdt.GetSerializerData();
            return new SqlParameter[] { 
                this.GetMainKeySqlParameter(rdt.ProcessID), base.MakeInParam("@UserID", SqlDbType.Int, 4, rdt.UserID), base.MakeInParam("@UserLoanType", SqlDbType.Int, 4, (int) rdt.UserLoanType), base.MakeInParam("@IsFirstLoan", SqlDbType.Bit, 1, rdt.IsFirstLoan), base.MakeInParam("@ProcessStatus", SqlDbType.Int, 4, (int) rdt.ProcessStatus), base.MakeInParam("@ConversationTrack", SqlDbType.NVarChar, 0xfa0, rdt.ConversationTrack), base.MakeInParam("@Task", SqlDbType.NVarChar, 0xfa0, rdt.Task), base.MakeInParam("@DocumentRequired", SqlDbType.NVarChar, 0xfa0, rdt.DocumentRequired), base.MakeInParam("@PostDate", SqlDbType.DateTime, 8, rdt.PostDate), base.MakeInParam("@LastOperateUserID", SqlDbType.Int, 4, rdt.LastOperateUserID), base.MakeInParam("@LastOperateDate", SqlDbType.DateTime, 8, rdt.LastOperateDate), base.MakeInParam("@PropertyNames", SqlDbType.NText, 0, serializerData.Keys), base.MakeInParam("@PropertyValues", SqlDbType.NText, 0, serializerData.Values), base.MakeInParam("@LoanID", SqlDbType.Int, 4, rdt.LoanID), base.MakeInParam("@ProcessOther1", SqlDbType.Int, 4, (int) rdt.CurrentStateIsAlerted), base.MakeInParam("@ProcessOther2", SqlDbType.Int, 4, rdt.ProcessOther2), 
                base.MakeInParam("@ProcessOther3", SqlDbType.NVarChar, 0x7d0, rdt.ProcessOther3), base.MakeInParam("@ProcessOther4", SqlDbType.NVarChar, 0x7d0, rdt.ProcessOther4)
             };
        }

        public override string GetTableName()
        {
            return "cs_ProcessCenter";
        }
    }
}

