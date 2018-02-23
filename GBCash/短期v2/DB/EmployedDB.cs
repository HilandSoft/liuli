namespace YingNet.WeiXing.DB
{
    using System;
    using System.Data;
    using System.Data.SqlClient;
    using YingNet.Common;
    using YingNet.WeiXing.DB.Data;
    using YingNet.WeiXing.STRUCTURE;

    public class EmployedDB : DBAccess
    {
        public override object ConvertItem(SqlDataReader dr)
        {
            EmployedDT ddt = new EmployedDT();
            ddt.RTime = Convert.ToDateTime(dr["RTime"]);
            ddt.Param2 = Convert.ToDouble(dr["Param2"]);
            ddt.Interest = Convert.ToDouble(dr["Interest"]);
            ddt.Frequency = Convert.ToDouble(dr["Frequency"]);
            ddt.Param1 = Convert.ToDouble(dr["Param1"]);
            ddt.XDay = Convert.ToInt32(dr["XDay"]);
            ddt.Param3 = Convert.ToInt32(dr["Param3"]);
            ddt.huiSid = Convert.ToInt32(dr["huiSid"]);
            ddt.IsEmployed = Convert.ToInt32(dr["IsEmployed"]);
            ddt.IsValid = Convert.ToInt32(dr["IsValid"]);
            ddt.NInstallment = Convert.ToInt32(dr["NInstallment"]);
            ddt.NDayMM = Convert.ToInt32(dr["NDayMM"]);
            ddt.NDayDD = Convert.ToInt32(dr["NDayDD"]);
            ddt.NDayYY = Convert.ToInt32(dr["NDayYY"]);
            ddt.id = Convert.ToInt32(dr["id"]);
            ddt.TYears = Convert.ToInt32(dr["TYears"]);
            ddt.TMonths = Convert.ToInt32(dr["TMonths"]);
            ddt.MIncome = Convert.ToSingle(dr["MIncome"]);
            ddt.Loan = Convert.ToSingle(dr["Loan"]);
            ddt.Rnum3 = Convert.ToString(dr["Rnum3"]);
            ddt.Param4 = Convert.ToString(dr["Param4"]);
            ddt.Param5 = Convert.ToString(dr["Param5"]);
            ddt.Rnum2 = Convert.ToString(dr["Rnum2"]);
            ddt.Rname3 = Convert.ToString(dr["Rname3"]);
            ddt.Rship3 = Convert.ToString(dr["Rship3"]);
            ddt.Rnum1 = Convert.ToString(dr["Rnum1"]);
            ddt.Rname2 = Convert.ToString(dr["Rname2"]);
            ddt.Rship2 = Convert.ToString(dr["Rship2"]);
            ddt.MContact = Convert.ToString(dr["MContact"]);
            ddt.Rname1 = Convert.ToString(dr["Rname1"]);
            ddt.Rship1 = Convert.ToString(dr["Rship1"]);
            ddt.AName = Convert.ToString(dr["AName"]);
            ddt.Bsb = Convert.ToString(dr["Bsb"]);
            ddt.ANumber = Convert.ToString(dr["ANumber"]);
            ddt.Wpaid = Convert.ToString(dr["Wpaid"]);
            ddt.Branch = Convert.ToString(dr["Branch"]);
            ddt.BankName = Convert.ToString(dr["BankName"]);
            ddt.Employer = Convert.ToString(dr["Employer"]);
            ddt.EAddress = Convert.ToString(dr["EAddress"]);
            ddt.EPhone = Convert.ToString(dr["EPhone"]);
            if (!Convert.IsDBNull(dr["LoanPurpose"]))
            {
                ddt.LoanPurpose = Convert.ToString(dr["LoanPurpose"]);
            }
            if (!Convert.IsDBNull(dr["HousePaymentValue"]))
            {
                ddt.HousePaymentValue = Convert.ToSingle(dr["HousePaymentValue"]);
            }
            if (!Convert.IsDBNull(dr["HousePaymentCircle"]))
            {
                ddt.HousePaymentCircle = (HousePaymentCircles) Convert.ToInt32(dr["HousePaymentCircle"]);
            }
            if (!Convert.IsDBNull(dr["OtherLenderValue"]))
            {
                ddt.OtherLenderValue = Convert.ToSingle(dr["OtherLenderValue"]);
            }
            if (!Convert.IsDBNull(dr["OtherLenderCircle"]))
            {
                ddt.OtherLenderCircle = (OtherLenderCircles) Convert.ToInt32(dr["OtherLenderCircle"]);
            }
            if (!Convert.IsDBNull(dr["OtherSamllCreditHas"]))
            {
                ddt.OtherSamllCreditHas = Convert.ToInt32(dr["OtherSamllCreditHas"]);
            }
            if (!Convert.IsDBNull(dr["OtherSmallCreditCount"]))
            {
                ddt.OtherSmallCreditCount = Convert.ToInt32(dr["OtherSmallCreditCount"]);
            }
            if (!Convert.IsDBNull(dr["IsGrossIncomeChange"]))
            {
                ddt.IsGrossIncomeChange = Convert.ToInt32(dr["IsGrossIncomeChange"]);
            }
            if (!Convert.IsDBNull(dr["IsPayOtherCredit"]))
            {
                ddt.IsPayOtherCredit = Convert.ToInt32(dr["IsPayOtherCredit"]);
            }
            if (!Convert.IsDBNull(dr["GrossIncomeChangeValue"]))
            {
                ddt.GrossIncomeChangeValue = Convert.ToString(dr["GrossIncomeChangeValue"]);
            }
            if (!Convert.IsDBNull(dr["PayOtherCreditValue"]))
            {
                ddt.PayOtherCreditValue = Convert.ToString(dr["PayOtherCreditValue"]);
            }
            return ddt;
        }

        public EmployedDT GetOneDT(int id)
        {
            return (EmployedDT) this.GetOneItem(id);
        }

        public override SqlParameter[] GetParameter(object obj)
        {
            EmployedDT ddt = (EmployedDT) obj;
            return new SqlParameter[] { 
                base.MakeInParam("@RTime", SqlDbType.DateTime, 8, ddt.RTime), base.MakeInParam("@Param2", SqlDbType.Float, 8, ddt.Param2), base.MakeInParam("@Interest", SqlDbType.Float, 8, ddt.Interest), base.MakeInParam("@Frequency", SqlDbType.Float, 8, ddt.Frequency), base.MakeInParam("@Param1", SqlDbType.Float, 8, ddt.Param1), base.MakeInParam("@XDay", SqlDbType.Int, 4, ddt.XDay), base.MakeInParam("@Param3", SqlDbType.Int, 4, ddt.Param3), base.MakeInParam("@huiSid", SqlDbType.Int, 4, ddt.huiSid), base.MakeInParam("@IsEmployed", SqlDbType.Int, 4, ddt.IsEmployed), base.MakeInParam("@IsValid", SqlDbType.Int, 4, ddt.IsValid), base.MakeInParam("@NInstallment", SqlDbType.Int, 4, ddt.NInstallment), base.MakeInParam("@NDayMM", SqlDbType.Int, 4, ddt.NDayMM), base.MakeInParam("@NDayDD", SqlDbType.Int, 4, ddt.NDayDD), base.MakeInParam("@NDayYY", SqlDbType.Int, 4, ddt.NDayYY), base.MakeInParam("@id", SqlDbType.Int, 4, ddt.id), base.MakeInParam("@TYears", SqlDbType.Int, 4, ddt.TYears), 
                base.MakeInParam("@TMonths", SqlDbType.Int, 4, ddt.TMonths), base.MakeInParam("@MIncome", SqlDbType.Money, 8, ddt.MIncome), base.MakeInParam("@Loan", SqlDbType.Money, 8, ddt.Loan), base.MakeInParam("@Rnum3", SqlDbType.NVarChar, 400, ddt.Rnum3), base.MakeInParam("@Param4", SqlDbType.NVarChar, 400, ddt.Param4), base.MakeInParam("@Param5", SqlDbType.NVarChar, 400, ddt.Param5), base.MakeInParam("@Rnum2", SqlDbType.NVarChar, 400, ddt.Rnum2), base.MakeInParam("@Rname3", SqlDbType.NVarChar, 400, ddt.Rname3), base.MakeInParam("@Rship3", SqlDbType.NVarChar, 400, ddt.Rship3), base.MakeInParam("@Rnum1", SqlDbType.NVarChar, 400, ddt.Rnum1), base.MakeInParam("@Rname2", SqlDbType.NVarChar, 400, ddt.Rname2), base.MakeInParam("@Rship2", SqlDbType.NVarChar, 400, ddt.Rship2), base.MakeInParam("@MContact", SqlDbType.NVarChar, 400, ddt.MContact), base.MakeInParam("@Rname1", SqlDbType.NVarChar, 400, ddt.Rname1), base.MakeInParam("@Rship1", SqlDbType.NVarChar, 400, ddt.Rship1), base.MakeInParam("@AName", SqlDbType.NVarChar, 400, ddt.AName), 
                base.MakeInParam("@Bsb", SqlDbType.NVarChar, 400, ddt.Bsb), base.MakeInParam("@ANumber", SqlDbType.NVarChar, 400, ddt.ANumber), base.MakeInParam("@Wpaid", SqlDbType.NVarChar, 400, ddt.Wpaid), base.MakeInParam("@Branch", SqlDbType.NVarChar, 400, ddt.Branch), base.MakeInParam("@BankName", SqlDbType.NVarChar, 400, ddt.BankName), base.MakeInParam("@Employer", SqlDbType.NVarChar, 400, ddt.Employer), base.MakeInParam("@EAddress", SqlDbType.NVarChar, 400, ddt.EAddress), base.MakeInParam("@EPhone", SqlDbType.NVarChar, 400, ddt.EPhone), base.MakeInParam("@LoanPurpose", SqlDbType.NVarChar, 500, ddt.LoanPurpose), base.MakeInParam("@HousePaymentCircle", SqlDbType.Int, 4, (int) ddt.HousePaymentCircle), base.MakeInParam("@HousePaymentValue", SqlDbType.Money, 8, ddt.HousePaymentValue), base.MakeInParam("@OtherLenderCircle", SqlDbType.Int, 4, (int) ddt.OtherLenderCircle), base.MakeInParam("@OtherLenderValue", SqlDbType.Money, 8, ddt.OtherLenderValue), base.MakeInParam("@OtherSamllCreditHas", SqlDbType.Int, 4, ddt.OtherSamllCreditHas), base.MakeInParam("@OtherSmallCreditCount", SqlDbType.Int, 4, ddt.OtherSmallCreditCount), base.MakeInParam("@IsGrossIncomeChange", SqlDbType.Int, 4, ddt.IsGrossIncomeChange), 
                base.MakeInParam("@IsPayOtherCredit", SqlDbType.Int, 4, ddt.IsPayOtherCredit), base.MakeInParam("@GrossIncomeChangeValue", SqlDbType.NVarChar, 50, ddt.GrossIncomeChangeValue), base.MakeInParam("@PayOtherCreditValue", SqlDbType.NVarChar, 50, ddt.PayOtherCreditValue)
             };
        }

        public int Insert2(object ob)
        {
            int num = -1;
            try
            {
                num = Convert.ToInt32(SqlHelper.ExecuteDataset(Config.DataSource, CommandType.StoredProcedure, "proc_EmployedDB_Insert2", this.GetParameter(ob)).Tables[0].Rows[0][0]);
            }
            catch (Exception exception)
            {
                throw exception;
            }
            return num;
        }
    }
}

