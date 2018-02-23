namespace YingNet.WeiXing.DB
{
    using System;
    using System.Data;
    using System.Data.SqlClient;
    using YingNet.Common;
    using YingNet.WeiXing.DB.Data;

    public class EmploybackupDB : DBAccess
    {
        public override object ConvertItem(SqlDataReader dr)
        {
            EmploybackupDT pdt = new EmploybackupDT();
            pdt.ModTime = Convert.ToDateTime(dr["ModTime"]);
            pdt.Frequency = Convert.ToDouble(dr["Frequency"]);
            pdt.IsEmployed = Convert.ToInt32(dr["IsEmployed"]);
            pdt.huiSid = Convert.ToInt32(dr["huiSid"]);
            pdt.NDayMM = Convert.ToInt32(dr["NDayMM"]);
            pdt.NDayDD = Convert.ToInt32(dr["NDayDD"]);
            pdt.NDayYY = Convert.ToInt32(dr["NDayYY"]);
            pdt.id = Convert.ToInt32(dr["id"]);
            pdt.TYears = Convert.ToInt32(dr["TYears"]);
            pdt.TMonths = Convert.ToInt32(dr["TMonths"]);
            pdt.MIncome = Convert.ToSingle(dr["MIncome"]);
            pdt.Wpaid = Convert.ToString(dr["Wpaid"]);
            pdt.huiName = Convert.ToString(dr["huiName"]);
            pdt.Employer = Convert.ToString(dr["Employer"]);
            pdt.EAddress = Convert.ToString(dr["EAddress"]);
            pdt.EPhone = Convert.ToString(dr["EPhone"]);
            return pdt;
        }

        public EmploybackupDT GetOneDT(int id)
        {
            return (EmploybackupDT) this.GetOneItem(id);
        }

        public override SqlParameter[] GetParameter(object obj)
        {
            EmploybackupDT pdt = (EmploybackupDT) obj;
            return new SqlParameter[] { base.MakeInParam("@ModTime", SqlDbType.DateTime, 8, pdt.ModTime), base.MakeInParam("@Frequency", SqlDbType.Float, 8, pdt.Frequency), base.MakeInParam("@IsEmployed", SqlDbType.Int, 4, pdt.IsEmployed), base.MakeInParam("@huiSid", SqlDbType.Int, 4, pdt.huiSid), base.MakeInParam("@NDayMM", SqlDbType.Int, 4, pdt.NDayMM), base.MakeInParam("@NDayDD", SqlDbType.Int, 4, pdt.NDayDD), base.MakeInParam("@NDayYY", SqlDbType.Int, 4, pdt.NDayYY), base.MakeInParam("@id", SqlDbType.Int, 4, pdt.id), base.MakeInParam("@TYears", SqlDbType.Int, 4, pdt.TYears), base.MakeInParam("@TMonths", SqlDbType.Int, 4, pdt.TMonths), base.MakeInParam("@MIncome", SqlDbType.Money, 8, pdt.MIncome), base.MakeInParam("@Wpaid", SqlDbType.NVarChar, 100, pdt.Wpaid), base.MakeInParam("@huiName", SqlDbType.NVarChar, 400, pdt.huiName), base.MakeInParam("@Employer", SqlDbType.NVarChar, 100, pdt.Employer), base.MakeInParam("@EAddress", SqlDbType.NVarChar, 100, pdt.EAddress), base.MakeInParam("@EPhone", SqlDbType.NVarChar, 100, pdt.EPhone) };
        }
    }
}

