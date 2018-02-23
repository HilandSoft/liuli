namespace YingNet.WeiXing.DB
{
    using System;
    using System.Data;
    using YingNet.Common;
    using YingNet.Common.Database;
    using YingNet.WeiXing.STRUCTURE;

    public class LiniloanDB : CommonBaseDB
    {
        public LiniloanDB(DBOperate oper) : base(oper)
        {
        }

        public bool Add(LiniloanDT detail)
        {
            int num = 0;
            string strSql = string.Concat(new object[] { 
                "INSERT INTO LIniLoan (PrimaryPurpose,Loan,Term,Other1,Other2,Other3,Other4,Other5,Other6,Persid) VALUES ('", StringUtils.ToSQL(detail.PrimaryPurpose), "',", detail.Loan, ",", detail.Term, ",'", StringUtils.ToSQL(detail.Other1), "','", StringUtils.ToSQL(detail.Other2), "','", StringUtils.ToSQL(detail.Other3), "',", detail.Other4, ",", detail.Other5, 
                ",", detail.Other6, ",", detail.Persid, ")"
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

        public int AddId(LiniloanDT detail)
        {
            int num = 0;
            int num2 = 0;
            string strSql = string.Concat(new object[] { "INSERT INTO LIniLoan (PrimaryPurpose,Loan,Term,Persid,Other1,Other2,Other3,Other4,Other5,Other6) VALUES ('", StringUtils.ToSQL(detail.PrimaryPurpose), "',", detail.Loan, ",", detail.Term, ",0,'", StringUtils.ToSQL(detail.Other1), "','", StringUtils.ToSQL(detail.Other2), "','", StringUtils.ToSQL(detail.Other3), "',0,0,0)" });
            try
            {
                try
                {
                    num = base.ExecuteForInt(strSql);
                    if (num > 0)
                    {
                        strSql = "SELECT @@IDENTITY AS 'Identity'";
                        DataTable table = base.ExecuteForDataTable(strSql);
                        if (table.Rows.Count > 0)
                        {
                            num2 = Convert.ToInt32(table.Rows[0][0].ToString());
                        }
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
            if (num == 1)
            {
                return num2;
            }
            return 0;
        }

        public bool Delete(int sid)
        {
            int num = 0;
            string strSql = "DELETE FROM LIniLoan where (sid=" + sid + ")";
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

        public bool Edit(LiniloanDT detail)
        {
            int num = 0;
            string strSql = string.Concat(new object[] { "UPDATE LIniLoan set PrimaryPurpose='", StringUtils.ToSQL(detail.PrimaryPurpose), "',Loan=", detail.Loan, ",Term=", detail.Term, " where (sid=", detail.sid, ")" });
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

        public LiniloanDT Get(int sid)
        {
            LiniloanDT ndt = new LiniloanDT();
            try
            {
                try
                {
                    string strSql = "select * from LIniLoan where (sid=" + sid + ")";
                    DataTable table = base.ExecuteForDataTable(strSql);
                    DataRow row = null;
                    if (table.Rows.Count >= 0)
                    {
                        row = table.Rows[0];
                        ndt.sid = Convert.ToInt32(row["sid"]);
                        ndt.PrimaryPurpose = Convert.ToString(row["PrimaryPurpose"]);
                        ndt.Loan = Convert.ToDouble(row["Loan"]);
                        ndt.Term = Convert.ToInt32(row["Term"]);
                        try
                        {
                            ndt.Other1 = Convert.ToString(row["Other1"]);
                            ndt.Other2 = Convert.ToString(row["Other2"]);
                            ndt.Other3 = Convert.ToString(row["Other3"]);
                            ndt.Other4 = Convert.ToInt32(row["Other4"]);
                            ndt.Other5 = Convert.ToInt32(row["Other5"]);
                            ndt.Other6 = Convert.ToInt32(row["Other6"]);
                        }
                        catch
                        {
                        }
                        ndt.Persid = Convert.ToInt32(row["Persid"]);
                    }
                    return ndt;
                }
                catch (Exception exception)
                {
                    throw exception;
                }
            }
            finally
            {
            }
            return ndt;
        }

        public DataTable GetList()
        {
            DataTable table = null;
            try
            {
                try
                {
                    string strSql = "select * from LIniLoan";
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

