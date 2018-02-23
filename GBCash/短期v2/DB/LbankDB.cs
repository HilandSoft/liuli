namespace YingNet.WeiXing.DB
{
    using System;
    using System.Data;
    using YingNet.Common;
    using YingNet.Common.Database;
    using YingNet.WeiXing.STRUCTURE;

    public class LbankDB : CommonBaseDB
    {
        public LbankDB(DBOperate oper) : base(oper)
        {
        }

        public bool Add(LbankDT detail)
        {
            int num = 0;
            string strSql = string.Concat(new object[] { 
                "INSERT INTO LBank (BankName,Branch,AccountName,Bsb,AccountNum,PContact,Rname1,Rship1,Rnum1,Rname2,Rship2,Rnum2,Rname3,Rship3,Rnum3,LoanSid,Other1,Other2,Other3,Other4,Other5,Other6) VALUES ('", StringUtils.ToSQL(detail.BankName), "','", StringUtils.ToSQL(detail.Branch), "','", StringUtils.ToSQL(detail.AccountName), "','", StringUtils.ToSQL(detail.Bsb), "','", StringUtils.ToSQL(detail.AccountNum), "','", StringUtils.ToSQL(detail.PContact), "','", StringUtils.ToSQL(detail.Rname1), "','", StringUtils.ToSQL(detail.Rship1), 
                "','", StringUtils.ToSQL(detail.Rnum1), "','", StringUtils.ToSQL(detail.Rname2), "','", StringUtils.ToSQL(detail.Rship2), "','", StringUtils.ToSQL(detail.Rnum2), "','", StringUtils.ToSQL(detail.Rname3), "','", StringUtils.ToSQL(detail.Rship3), "','", StringUtils.ToSQL(detail.Rnum3), "',", detail.LoanSid, 
                ",'", StringUtils.ToSQL(detail.Other1), "','", StringUtils.ToSQL(detail.Other2), "','", StringUtils.ToSQL(detail.Other3), "',", detail.Other4, ",", detail.Other5, ",", detail.Other6, ")"
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
            string strSql = "DELETE FROM LBank where (sid=" + sid + ")";
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

        public bool Edit(LbankDT detail)
        {
            int num = 0;
            string strSql = string.Concat(new object[] { 
                "UPDATE LBank set BankName='", StringUtils.ToSQL(detail.BankName), "',Branch='", StringUtils.ToSQL(detail.Branch), "',AccountName='", StringUtils.ToSQL(detail.AccountName), "',Bsb='", StringUtils.ToSQL(detail.Bsb), "',AccountNum='", StringUtils.ToSQL(detail.AccountNum), "',PContact='", StringUtils.ToSQL(detail.PContact), "',Rname1='", StringUtils.ToSQL(detail.Rname1), "',Rship1='", StringUtils.ToSQL(detail.Rship1), 
                "',Rnum1='", StringUtils.ToSQL(detail.Rnum1), "',Rname2='", StringUtils.ToSQL(detail.Rname2), "',Rship2='", StringUtils.ToSQL(detail.Rship2), "',Rnum2='", StringUtils.ToSQL(detail.Rnum2), "',Rname3='", StringUtils.ToSQL(detail.Rname3), "',Rship3='", StringUtils.ToSQL(detail.Rship3), "',Rnum3='", StringUtils.ToSQL(detail.Rnum3), "',LoanSid=", detail.LoanSid, 
                ",Other1='", StringUtils.ToSQL(detail.Other1), "',Other2='", StringUtils.ToSQL(detail.Other2), "',Other3='", StringUtils.ToSQL(detail.Other3), "',Other4=", detail.Other4, ",Other5=", detail.Other5, ",Other6=", detail.Other6, " where (sid=", detail.sid, ")"
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

        public LbankDT Get(int sid)
        {
            LbankDT kdt = new LbankDT();
            try
            {
                try
                {
                    string strSql = "select * from LBank where (sid=" + sid + ")";
                    DataTable table = base.ExecuteForDataTable(strSql);
                    DataRow row = null;
                    if (table.Rows.Count >= 0)
                    {
                        row = table.Rows[0];
                        kdt.sid = Convert.ToInt32(row["sid"]);
                        kdt.BankName = Convert.ToString(row["BankName"]);
                        kdt.Branch = Convert.ToString(row["Branch"]);
                        kdt.AccountName = Convert.ToString(row["AccountName"]);
                        kdt.Bsb = Convert.ToString(row["Bsb"]);
                        kdt.AccountNum = Convert.ToString(row["AccountNum"]);
                        kdt.PContact = Convert.ToString(row["PContact"]);
                        kdt.Rname1 = Convert.ToString(row["Rname1"]);
                        kdt.Rship1 = Convert.ToString(row["Rship1"]);
                        kdt.Rnum1 = Convert.ToString(row["Rnum1"]);
                        kdt.Rname2 = Convert.ToString(row["Rname2"]);
                        kdt.Rship2 = Convert.ToString(row["Rship2"]);
                        kdt.Rnum2 = Convert.ToString(row["Rnum2"]);
                        kdt.Rname3 = Convert.ToString(row["Rname3"]);
                        kdt.Rship3 = Convert.ToString(row["Rship3"]);
                        kdt.Rnum3 = Convert.ToString(row["Rnum3"]);
                        kdt.LoanSid = Convert.ToInt32(row["LoanSid"]);
                        kdt.Other1 = Convert.ToString(row["Other1"]);
                        kdt.Other2 = Convert.ToString(row["Other2"]);
                        kdt.Other3 = Convert.ToString(row["Other3"]);
                        kdt.Other4 = Convert.ToInt32(row["Other4"]);
                        kdt.Other5 = Convert.ToInt32(row["Other5"]);
                        kdt.Other6 = Convert.ToInt32(row["Other6"]);
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
            return kdt;
        }

        public DataTable GetList()
        {
            DataTable table = null;
            try
            {
                try
                {
                    string strSql = "select * from LBank";
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

