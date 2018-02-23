namespace YingNet.WeiXing.DB
{
    using System;
    using System.Data;
    using YingNet.Common;
    using YingNet.Common.Database;
    using YingNet.WeiXing.STRUCTURE;

    public class LresidentDB : CommonBaseDB
    {
        public LresidentDB(DBOperate oper) : base(oper)
        {
        }

        public bool Add(LresidentDT detail)
        {
            int num = 0;
            string strSql = string.Concat(new object[] { 
                "INSERT INTO LResident (Status,UnitNo,StreetNum,Suburb,State,Postcode,TimeYears,TimeMonths,NameAgent,TelArea,LoanSid,Other1,Other2,Other3,Other4,Other5,Other6,UnitNo1,StreetNum1,Suburb1,State1,Postcode1,TimeYears1,TimeMonths1) VALUES ('", StringUtils.ToSQL(detail.Status), "','", StringUtils.ToSQL(detail.UnitNo), "','", StringUtils.ToSQL(detail.StreetNum), "','", StringUtils.ToSQL(detail.Suburb), "','", StringUtils.ToSQL(detail.State), "','", StringUtils.ToSQL(detail.Postcode), "','", StringUtils.ToSQL(detail.TimeYears), "','", StringUtils.ToSQL(detail.TimeMonths), 
                "','", StringUtils.ToSQL(detail.NameAgent), "','", StringUtils.ToSQL(detail.TelArea), "',", detail.LoanSid, ",'", StringUtils.ToSQL(detail.Other1), "','", StringUtils.ToSQL(detail.Other2), "','", StringUtils.ToSQL(detail.Other3), "',", detail.Other4, ",", detail.Other5, 
                ",", detail.Other6, ",'", StringUtils.ToSQL(detail.UnitNo1), "','", StringUtils.ToSQL(detail.StreetNum1), "','", StringUtils.ToSQL(detail.Suburb1), "','", StringUtils.ToSQL(detail.State1), "','", StringUtils.ToSQL(detail.Postcode1), "','", StringUtils.ToSQL(detail.TimeYears1), "','", StringUtils.ToSQL(detail.TimeMonths1), 
                "')"
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
            string strSql = "DELETE FROM LResident where (sid=" + sid + ")";
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

        public bool Edit(LresidentDT detail)
        {
            int num = 0;
            string strSql = string.Concat(new object[] { 
                "UPDATE LResident set Status='", StringUtils.ToSQL(detail.Status), "',UnitNo='", StringUtils.ToSQL(detail.UnitNo), "',StreetNum='", StringUtils.ToSQL(detail.StreetNum), "',Suburb='", StringUtils.ToSQL(detail.Suburb), "',State='", StringUtils.ToSQL(detail.State), "',Postcode='", StringUtils.ToSQL(detail.Postcode), "',TimeYears='", StringUtils.ToSQL(detail.TimeYears), "',TimeMonths='", StringUtils.ToSQL(detail.TimeMonths), 
                "',NameAgent='", StringUtils.ToSQL(detail.NameAgent), "',TelArea='", StringUtils.ToSQL(detail.TelArea), "',LoanSid=", detail.LoanSid, ",Other1='", StringUtils.ToSQL(detail.Other1), "',Other2='", StringUtils.ToSQL(detail.Other2), "',Other3='", StringUtils.ToSQL(detail.Other3), "',Other4=", detail.Other4, ",Other5=", detail.Other5, 
                ",Other6=", detail.Other6, ",UnitNo1='", StringUtils.ToSQL(detail.UnitNo1), "',StreetNum1='", StringUtils.ToSQL(detail.StreetNum1), "',Suburb1='", StringUtils.ToSQL(detail.Suburb1), "',State1='", StringUtils.ToSQL(detail.State1), "',Postcode1='", StringUtils.ToSQL(detail.Postcode1), "',TimeYears1='", StringUtils.ToSQL(detail.TimeYears1), "',TimeMonths1='", StringUtils.ToSQL(detail.TimeMonths1), 
                "' where (sid=", detail.sid, ")"
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

        public LresidentDT Get(int sid)
        {
            LresidentDT tdt = new LresidentDT();
            try
            {
                try
                {
                    string strSql = "select * from LResident where (sid=" + sid + ")";
                    DataTable table = base.ExecuteForDataTable(strSql);
                    DataRow row = null;
                    if (table.Rows.Count >= 0)
                    {
                        row = table.Rows[0];
                        tdt.sid = Convert.ToInt32(row["sid"]);
                        tdt.Status = Convert.ToString(row["Status"]);
                        tdt.UnitNo = Convert.ToString(row["UnitNo"]);
                        tdt.StreetNum = Convert.ToString(row["StreetNum"]);
                        tdt.Suburb = Convert.ToString(row["Suburb"]);
                        tdt.State = Convert.ToString(row["State"]);
                        tdt.Postcode = Convert.ToString(row["Postcode"]);
                        tdt.TimeYears = Convert.ToString(row["TimeYears"]);
                        tdt.TimeMonths = Convert.ToString(row["TimeMonths"]);
                        tdt.NameAgent = Convert.ToString(row["NameAgent"]);
                        tdt.TelArea = Convert.ToString(row["TelArea"]);
                        tdt.LoanSid = Convert.ToInt32(row["LoanSid"]);
                        tdt.Other1 = Convert.ToString(row["Other1"]);
                        tdt.Other2 = Convert.ToString(row["Other2"]);
                        tdt.Other3 = Convert.ToString(row["Other3"]);
                        tdt.Other4 = Convert.ToInt32(row["Other4"]);
                        tdt.Other5 = Convert.ToInt32(row["Other5"]);
                        tdt.Other6 = Convert.ToInt32(row["Other6"]);
                        tdt.UnitNo1 = Convert.ToString(row["UnitNo1"]);
                        tdt.StreetNum1 = Convert.ToString(row["StreetNum1"]);
                        tdt.Suburb1 = Convert.ToString(row["Suburb1"]);
                        tdt.State1 = Convert.ToString(row["State1"]);
                        tdt.Postcode1 = Convert.ToString(row["Postcode1"]);
                        tdt.TimeYears1 = Convert.ToString(row["TimeYears1"]);
                        tdt.TimeMonths1 = Convert.ToString(row["TimeMonths1"]);
                    }
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
                    string strSql = "select * from LResident";
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

