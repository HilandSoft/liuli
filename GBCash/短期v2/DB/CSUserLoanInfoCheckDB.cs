namespace YingNet.WeiXing.DB
{
    using System;
    using System.Data;
    using System.Data.SqlClient;
    using YingNet.Common;
    using YingNet.Serialization;
    using YingNet.WeiXing.DB.Data;

    public class CSUserLoanInfoCheckDB : DBAccess
    {
        public override object ConvertItem(SqlDataReader reader)
        {
            CSUserLoanInfoCheckDT kdt = new CSUserLoanInfoCheckDT();
            if (reader["ProcessID"] != DBNull.Value)
            {
                kdt.ProcessID = Convert.ToInt32(reader["ProcessID"]);
            }
            if (reader["UserID"] != DBNull.Value)
            {
                kdt.UserID = Convert.ToInt32(reader["UserID"]);
            }
            if (reader["UserLoanType"] != DBNull.Value)
            {
                kdt.UserLoanType = (UserLoanTypes) Convert.ToInt32(reader["UserLoanType"]);
            }
            if (reader["EmployerName"] != DBNull.Value)
            {
                kdt.EmployerName = Convert.ToString(reader["EmployerName"]);
            }
            if (reader["EmployerAddress"] != DBNull.Value)
            {
                kdt.EmployerAddress = Convert.ToString(reader["EmployerAddress"]);
            }
            if (reader["EmployerTelephone"] != DBNull.Value)
            {
                kdt.EmployerTelephone = Convert.ToString(reader["EmployerTelephone"]);
            }
            if (reader["WorkTelephone"] != DBNull.Value)
            {
                kdt.WorkTelephone = Convert.ToString(reader["WorkTelephone"]);
            }
            if (reader["HomeTelephone"] != DBNull.Value)
            {
                kdt.HomeTelephone = Convert.ToString(reader["HomeTelephone"]);
            }
            if (reader["EmploymentStatus"] != DBNull.Value)
            {
                kdt.EmploymentStatus = Convert.ToInt32(reader["EmploymentStatus"]);
            }
            if (reader["JobTitle"] != DBNull.Value)
            {
                kdt.JobTitle = Convert.ToString(reader["JobTitle"]);
            }
            if (reader["TimeEmployed"] != DBNull.Value)
            {
                kdt.TimeEmployed = Convert.ToString(reader["TimeEmployed"]);
            }
            if (reader["TakeHomePayAfterTaxes"] != DBNull.Value)
            {
                kdt.TakeHomePayAfterTaxes = Convert.ToDecimal(reader["TakeHomePayAfterTaxes"]);
            }
            if (reader["PayFrequency"] != DBNull.Value)
            {
                kdt.PayFrequency = Convert.ToString(reader["PayFrequency"]);
            }
            if (reader["NextPayday"] != DBNull.Value)
            {
                kdt.NextPayday = Convert.ToDateTime(reader["NextPayday"]);
            }
            if (reader["CheckOther1"] != DBNull.Value)
            {
                kdt.CheckOther1 = Convert.ToInt32(reader["CheckOther1"]);
            }
            if (reader["CheckOther2"] != DBNull.Value)
            {
                kdt.CheckOther2 = Convert.ToInt32(reader["CheckOther2"]);
            }
            if (reader["CheckOther3"] != DBNull.Value)
            {
                kdt.CheckOther3 = Convert.ToString(reader["CheckOther3"]);
            }
            if (reader["CheckOther4"] != DBNull.Value)
            {
                kdt.CheckOther4 = Convert.ToString(reader["CheckOther4"]);
            }
            kdt.SetSerializerData(ExtendedAttributesHelper.PopulateSerializerDataFromIDataReader(reader));
            return kdt;
        }

        public override SqlParameter[] GetParameter(object obj)
        {
            CSUserLoanInfoCheckDT kdt = (CSUserLoanInfoCheckDT) obj;
            SerializerData serializerData = kdt.GetSerializerData();
            return new SqlParameter[] { 
                base.MakeInParam("@ProcessID", SqlDbType.Int, 4, kdt.ProcessID), base.MakeInParam("@UserID", SqlDbType.Int, 4, kdt.UserID), base.MakeInParam("@UserLoanType", SqlDbType.Int, 4, (int) kdt.UserLoanType), base.MakeInParam("@EmployerName", SqlDbType.NVarChar, 0x80, kdt.EmployerName), base.MakeInParam("@EmployerAddress", SqlDbType.NVarChar, 0x80, kdt.EmployerAddress), base.MakeInParam("@EmployerTelephone", SqlDbType.NVarChar, 0x80, kdt.EmployerTelephone), base.MakeInParam("@WorkTelephone", SqlDbType.NVarChar, 0x80, kdt.WorkTelephone), base.MakeInParam("@HomeTelephone", SqlDbType.NVarChar, 0x80, kdt.HomeTelephone), base.MakeInParam("@EmploymentStatus", SqlDbType.Int, 4, kdt.EmploymentStatus), base.MakeInParam("@JobTitle", SqlDbType.NVarChar, 0x80, kdt.JobTitle), base.MakeInParam("@TimeEmployed", SqlDbType.NVarChar, 0x80, kdt.TimeEmployed), base.MakeInParam("@TakeHomePayAfterTaxes", SqlDbType.Money, 8, kdt.TakeHomePayAfterTaxes), base.MakeInParam("@PayFrequency", SqlDbType.NVarChar, 0x80, kdt.PayFrequency), base.MakeInParam("@NextPayday", SqlDbType.DateTime, 8, kdt.NextPayday), base.MakeInParam("@CheckOther1", SqlDbType.Int, 4, kdt.CheckOther1), base.MakeInParam("@CheckOther2", SqlDbType.Int, 4, kdt.CheckOther2), 
                base.MakeInParam("@CheckOther3", SqlDbType.NVarChar, 0x100, kdt.CheckOther3), base.MakeInParam("@CheckOther4", SqlDbType.NVarChar, 0x100, kdt.CheckOther4), base.MakeInParam("@PropertyNames", SqlDbType.NText, 0, serializerData.Keys), base.MakeInParam("@PropertyValues", SqlDbType.NText, 0, serializerData.Values)
             };
        }

        public override string GetTableName()
        {
            return "cs_UserLoanInfoCheck";
        }
    }
}

