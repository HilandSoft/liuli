namespace YingNet.WeiXing.DB
{
    using System;
    using System.Data;
    using YingNet.Common;
    using YingNet.Common.Database;
    using YingNet.WeiXing.STRUCTURE;

    public class LemploymentDB : CommonBaseDB
    {
        public LemploymentDB(DBOperate oper) : base(oper)
        {
        }

        public bool Add(LemploymentDT detail)
        {
            int num = 0;
            string strSql = string.Concat(new object[] { 
                "INSERT INTO LEmployment (EName,EAddress,ECode,ENum,EStatus,JobTitle,TimeYears,TimeMonths,TakePay,Per,NextDay,NextMonth,NextYear,LoanSid,Other1,Other2,Other3,Other4,Other5,Other6,FollowDay,FollowMonth,FollowYear,HousePaymentValue,HousePaymentCircle,OtherLenderValue,OtherLenderCircle) VALUES ('", StringUtils.ToSQL(detail.EName), "','", StringUtils.ToSQL(detail.EAddress), "','", StringUtils.ToSQL(detail.ECode), "','", StringUtils.ToSQL(detail.ENum), "','", StringUtils.ToSQL(detail.EStatus), "','", StringUtils.ToSQL(detail.JobTitle), "',", detail.TimeYears, ",", detail.TimeMonths, 
                ",", detail.TakePay, ",", detail.Per, ",", detail.NextDay, ",", detail.NextMonth, ",", detail.NextYear, ",", detail.LoanSid, ",'", StringUtils.ToSQL(detail.Other1), "','", StringUtils.ToSQL(detail.Other2), 
                "','", StringUtils.ToSQL(detail.Other3), "',", detail.Other4, ",", detail.Other5, ",", detail.Other6, ",", detail.FollowDay, ",", detail.FollowMonth, ",", detail.FollowYear, ",", detail.HousePaymentValue, 
                ",", (int) detail.HousePaymentCircle, ",", detail.OtherLenderValue, ",", (int) detail.OtherLenderCircle, ")"
             });
            try
            {
                try
                {
                    num = base.ExecuteForInt(strSql);
                }
                catch (Exception exception)
                {
                    throw exception;
                }
            }
            finally
            {
            }
            return (num == 1);
        }

        public bool Delete(int sid)
        {
            int num = 0;
            string strSql = "DELETE FROM LEmployment where (sid=" + sid + ")";
            try
            {
                try
                {
                    num = base.ExecuteForInt(strSql);
                }
                catch (Exception exception)
                {
                    throw exception;
                }
            }
            finally
            {
            }
            return (num == 1);
        }

        public bool Edit(LemploymentDT detail)
        {
            int num = 0;
            string strSql = string.Concat(new object[] { 
                "UPDATE LEmployment set EName='", StringUtils.ToSQL(detail.EName), "',EAddress='", StringUtils.ToSQL(detail.EAddress), "',ECode='", StringUtils.ToSQL(detail.ECode), "',ENum='", StringUtils.ToSQL(detail.ENum), "',EStatus='", StringUtils.ToSQL(detail.EStatus), "',JobTitle='", StringUtils.ToSQL(detail.JobTitle), "',TimeYears=", detail.TimeYears, ",TimeMonths=", detail.TimeMonths, 
                ",TakePay=", detail.TakePay, ",Per=", detail.Per, ",NextDay=", detail.NextDay, ",NextMonth=", detail.NextMonth, ",NextYear=", detail.NextYear, ",LoanSid=", detail.LoanSid, ",Other1='", StringUtils.ToSQL(detail.Other1), "',Other2='", StringUtils.ToSQL(detail.Other2), 
                "',Other3='", StringUtils.ToSQL(detail.Other3), "',Other4=", detail.Other4, ",Other5=", detail.Other5, ",Other6=", detail.Other6, ",FollowDay=", detail.FollowDay, ",FollowMonth=", detail.FollowMonth, ",FollowYear=", detail.FollowYear, ",HousePaymentValue=", detail.HousePaymentValue, 
                ",HousePaymentCircle=", (int) detail.HousePaymentCircle, ",OtherLenderValue=", detail.OtherLenderValue, ",OtherLenderCircle=", (int) detail.OtherLenderCircle, " where (sid=", detail.sid, ")"
             });
            try
            {
                try
                {
                    num = base.ExecuteForInt(strSql);
                }
                catch (Exception exception)
                {
                    throw exception;
                }
            }
            finally
            {
            }
            return (num == 1);
        }

        public LemploymentDT Get(int sid)
        {
            LemploymentDT tdt = new LemploymentDT();
            try
            {
                try
                {
                    string strSql = "select * from LEmployment where (sid=" + sid + ")";
                    DataTable table = base.ExecuteForDataTable(strSql);
                    DataRow row = null;
                    if (table.Rows.Count >= 0)
                    {
                        row = table.Rows[0];
                        tdt.sid = Convert.ToInt32(row["sid"]);
                        tdt.EName = Convert.ToString(row["EName"]);
                        tdt.EAddress = Convert.ToString(row["EAddress"]);
                        tdt.ECode = Convert.ToString(row["ECode"]);
                        tdt.ENum = Convert.ToString(row["ENum"]);
                        tdt.EStatus = Convert.ToString(row["EStatus"]);
                        tdt.JobTitle = Convert.ToString(row["JobTitle"]);
                        tdt.TimeYears = Convert.ToInt32(row["TimeYears"]);
                        tdt.TimeMonths = Convert.ToInt32(row["TimeMonths"]);
                        tdt.TakePay = Convert.ToDouble(row["TakePay"]);
                        tdt.Per = Convert.ToInt32(row["Per"]);
                        tdt.NextDay = Convert.ToInt32(row["NextDay"]);
                        tdt.NextMonth = Convert.ToInt32(row["NextMonth"]);
                        tdt.NextYear = Convert.ToInt32(row["NextYear"]);
                        tdt.LoanSid = Convert.ToInt32(row["LoanSid"]);
                        tdt.Other1 = Convert.ToString(row["Other1"]);
                        tdt.Other2 = Convert.ToString(row["Other2"]);
                        tdt.Other3 = Convert.ToString(row["Other3"]);
                        tdt.Other4 = Convert.ToInt32(row["Other4"]);
                        tdt.Other5 = Convert.ToInt32(row["Other5"]);
                        tdt.Other6 = Convert.ToInt32(row["Other6"]);
                        tdt.FollowDay = Convert.ToInt32(row["FollowDay"]);
                        tdt.FollowMonth = Convert.ToInt32(row["FollowMonth"]);
                        tdt.FollowYear = Convert.ToInt32(row["FollowYear"]);
                        if (!Convert.IsDBNull(row["HousePaymentCircle"]))
                        {
                            tdt.HousePaymentCircle = (HousePaymentCircles) Convert.ToInt32(row["HousePaymentCircle"]);
                        }
                        if (!Convert.IsDBNull(row["HousePaymentValue"]))
                        {
                            tdt.HousePaymentValue = Convert.ToSingle(row["HousePaymentValue"]);
                        }
                        if (!Convert.IsDBNull(row["OtherLenderCircle"]))
                        {
                            tdt.OtherLenderCircle = (OtherLenderCircles) Convert.ToInt32(row["OtherLenderCircle"]);
                        }
                        if (!Convert.IsDBNull(row["OtherLenderValue"]))
                        {
                            tdt.OtherLenderValue = Convert.ToSingle(row["OtherLenderValue"]);
                        }
                    }
                    return tdt;
                }
                catch (Exception exception)
                {
                    throw exception;
                }
            }
            finally
            {
            }
            return tdt;
        }

        public DataTable GetList()
        {
            DataTable table = null;
            try
            {
                try
                {
                    string strSql = "select * from LEmployment";
                    table = base.ExecuteForDataTable(strSql);
                }
                catch (Exception exception)
                {
                    throw exception;
                }
            }
            finally
            {
            }
            return table;
        }
    }
}

