namespace YingNet.WeiXing.DB
{
    using System;
    using System.Data;
    using YingNet.Common;
    using YingNet.Common.Database;
    using YingNet.WeiXing.STRUCTURE;

    public class LpersonDB : CommonBaseDB
    {
        public LpersonDB(DBOperate oper) : base(oper)
        {
        }

        public bool Add(LpersonDT detail)
        {
            int num = 0;
            string strSql = string.Concat(new object[] { 
                "INSERT INTO LPerson (IsExist,ReferenceNum,Title,Fname,Mname,Sname,Gender,DBirth,HTelcode,HTelnum,WTelcode,WTelnum,Mobile,Email,LicNum,LicState,MaritalStatus,RegTime,LoanSid,Rname1,Rship1,Rnum1,Rname2,Rship2,Rnum2,Rname3,Rship3,Rnum3,Other1,Other2,Other3,Other4,Other5,Other6,Status,Username,Pwd) VALUES (", detail.IsExist, ",'", StringUtils.ToSQL(detail.ReferenceNum), "','", StringUtils.ToSQL(detail.Title), "','", StringUtils.ToSQL(detail.Fname), "','", StringUtils.ToSQL(detail.Mname), "','", StringUtils.ToSQL(detail.Sname), "','", StringUtils.ToSQL(detail.Gender), "','", StringUtils.ToSQL(detail.DBirth), 
                "','", StringUtils.ToSQL(detail.HTelcode), "','", StringUtils.ToSQL(detail.HTelnum), "','", StringUtils.ToSQL(detail.WTelcode), "','", StringUtils.ToSQL(detail.WTelnum), "','", StringUtils.ToSQL(detail.Mobile), "','", StringUtils.ToSQL(detail.Email), "','", StringUtils.ToSQL(detail.LicNum), "','", StringUtils.ToSQL(detail.LicState), 
                "','", StringUtils.ToSQL(detail.MaritalStatus), "','", detail.RegTime, "',", detail.LoanSid, ",'", StringUtils.ToSQL(detail.Rname1), "','", StringUtils.ToSQL(detail.Rship1), "','", StringUtils.ToSQL(detail.Rnum1), "','", StringUtils.ToSQL(detail.Rname2), "','", StringUtils.ToSQL(detail.Rship2), 
                "','", StringUtils.ToSQL(detail.Rnum2), "','", StringUtils.ToSQL(detail.Rname3), "','", StringUtils.ToSQL(detail.Rship3), "','", StringUtils.ToSQL(detail.Rnum3), "','", StringUtils.ToSQL(detail.Other1), "','", StringUtils.ToSQL(detail.Other2), "','", StringUtils.ToSQL(detail.Other3), "',", detail.Other4, 
                ",", detail.Other5, ",", detail.Other6, ",", detail.Status, ",'", StringUtils.ToSQL(detail.Username), "','", StringUtils.ToSQL(detail.Pwd), "')"
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

        public int AddId(LpersonDT detail)
        {
            int num = 0;
            int num2 = 0;
            string strSql = string.Concat(new object[] { 
                "INSERT INTO LPerson (IsExist,ReferenceNum,Title,Fname,Mname,Sname,Gender,DBirth,HTelcode,HTelnum,WTelcode,WTelnum,Mobile,Email,LicNum,LicState,MaritalStatus,RegTime,LoanSid,Rname1,Rship1,Rnum1,Rname2,Rship2,Rnum2,Rname3,Rship3,Rnum3,Other1,Other2,Other3,Other4,Other5,Other6,Status,Username,Pwd) VALUES (", detail.IsExist, ",'", StringUtils.ToSQL(detail.ReferenceNum), "','", StringUtils.ToSQL(detail.Title), "','", StringUtils.ToSQL(detail.Fname), "','", StringUtils.ToSQL(detail.Mname), "','", StringUtils.ToSQL(detail.Sname), "','", StringUtils.ToSQL(detail.Gender), "','", StringUtils.ToSQL(detail.DBirth), 
                "','", StringUtils.ToSQL(detail.HTelcode), "','", StringUtils.ToSQL(detail.HTelnum), "','", StringUtils.ToSQL(detail.WTelcode), "','", StringUtils.ToSQL(detail.WTelnum), "','", StringUtils.ToSQL(detail.Mobile), "','", StringUtils.ToSQL(detail.Email), "','", StringUtils.ToSQL(detail.LicNum), "','", StringUtils.ToSQL(detail.LicState), 
                "','", StringUtils.ToSQL(detail.MaritalStatus), "','", detail.RegTime, "',", detail.LoanSid, ",'", StringUtils.ToSQL(detail.Rname1), "','", StringUtils.ToSQL(detail.Rship1), "','", StringUtils.ToSQL(detail.Rnum1), "','", StringUtils.ToSQL(detail.Rname2), "','", StringUtils.ToSQL(detail.Rship2), 
                "','", StringUtils.ToSQL(detail.Rnum2), "','", StringUtils.ToSQL(detail.Rname3), "','", StringUtils.ToSQL(detail.Rship3), "','", StringUtils.ToSQL(detail.Rnum3), "','", StringUtils.ToSQL(detail.Other1), "','", StringUtils.ToSQL(detail.Other2), "','", StringUtils.ToSQL(detail.Other3), "',", detail.Other4, 
                ",", detail.Other5, ",", detail.Other6, ",", detail.Status, ",'", StringUtils.ToSQL(detail.Username), "','", StringUtils.ToSQL(detail.Pwd), "')"
             });
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
            string strSql = "DELETE FROM LPerson where (sid=" + sid + ")";
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

        public bool Edit(LpersonDT detail)
        {
            int num = 0;
            string strSql = string.Concat(new object[] { 
                "UPDATE LPerson set IsExist=", detail.IsExist, ",ReferenceNum='", StringUtils.ToSQL(detail.ReferenceNum), "',Title='", StringUtils.ToSQL(detail.Title), "',Fname='", StringUtils.ToSQL(detail.Fname), "',Mname='", StringUtils.ToSQL(detail.Mname), "',Sname='", StringUtils.ToSQL(detail.Sname), "',Gender='", StringUtils.ToSQL(detail.Gender), "',DBirth='", StringUtils.ToSQL(detail.DBirth), 
                "',HTelcode='", StringUtils.ToSQL(detail.HTelcode), "',HTelnum='", StringUtils.ToSQL(detail.HTelnum), "',WTelcode='", StringUtils.ToSQL(detail.WTelcode), "',WTelnum='", StringUtils.ToSQL(detail.WTelnum), "',Mobile='", StringUtils.ToSQL(detail.Mobile), "',Email='", StringUtils.ToSQL(detail.Email), "',LicNum='", StringUtils.ToSQL(detail.LicNum), "',LicState='", StringUtils.ToSQL(detail.LicState), 
                "',MaritalStatus='", StringUtils.ToSQL(detail.MaritalStatus), "',RegTime='", detail.RegTime, "',LoanSid=", detail.LoanSid, ",Rname1='", StringUtils.ToSQL(detail.Rname1), "',Rship1='", StringUtils.ToSQL(detail.Rship1), "',Rnum1='", StringUtils.ToSQL(detail.Rnum1), "',Rname2='", StringUtils.ToSQL(detail.Rname2), "',Rship2='", StringUtils.ToSQL(detail.Rship2), 
                "',Rnum2='", StringUtils.ToSQL(detail.Rnum2), "',Rname3='", StringUtils.ToSQL(detail.Rname3), "',Rship3='", StringUtils.ToSQL(detail.Rship3), "',Rnum3='", StringUtils.ToSQL(detail.Rnum3), "',Other1='", StringUtils.ToSQL(detail.Other1), "',Other2='", StringUtils.ToSQL(detail.Other2), "',Other3='", StringUtils.ToSQL(detail.Other3), "',Other4=", detail.Other4, 
                ",Other5=", detail.Other5, ",Other6=", detail.Other6, ",Status=", detail.Status, ",Username='", StringUtils.ToSQL(detail.Username), "',Pwd='", StringUtils.ToSQL(detail.Pwd), "' where (sid=", detail.sid, ")"
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

        public LpersonDT Get(int sid)
        {
            LpersonDT ndt = new LpersonDT();
            try
            {
                try
                {
                    string strSql = "select * from LPerson where (sid=" + sid + ")";
                    DataTable table = base.ExecuteForDataTable(strSql);
                    DataRow row = null;
                    if (table.Rows.Count >= 0)
                    {
                        row = table.Rows[0];
                        ndt.sid = Convert.ToInt32(row["sid"]);
                        ndt.IsExist = Convert.ToInt32(row["IsExist"]);
                        ndt.ReferenceNum = Convert.ToString(row["ReferenceNum"]);
                        ndt.Title = Convert.ToString(row["Title"]);
                        ndt.Fname = Convert.ToString(row["Fname"]);
                        ndt.Mname = Convert.ToString(row["Mname"]);
                        ndt.Sname = Convert.ToString(row["Sname"]);
                        ndt.Gender = Convert.ToString(row["Gender"]);
                        ndt.DBirth = Convert.ToString(row["DBirth"]);
                        ndt.HTelcode = Convert.ToString(row["HTelcode"]);
                        ndt.HTelnum = Convert.ToString(row["HTelnum"]);
                        ndt.WTelcode = Convert.ToString(row["WTelcode"]);
                        ndt.WTelnum = Convert.ToString(row["WTelnum"]);
                        ndt.Mobile = Convert.ToString(row["Mobile"]);
                        ndt.Email = Convert.ToString(row["Email"]);
                        ndt.LicNum = Convert.ToString(row["LicNum"]);
                        ndt.LicState = Convert.ToString(row["LicState"]);
                        ndt.MaritalStatus = Convert.ToString(row["MaritalStatus"]);
                        ndt.RegTime = Convert.ToDateTime(row["RegTime"]);
                        ndt.LoanSid = Convert.ToInt32(row["LoanSid"]);
                        ndt.Rname1 = Convert.ToString(row["Rname1"]);
                        ndt.Rship1 = Convert.ToString(row["Rship1"]);
                        ndt.Rnum1 = Convert.ToString(row["Rnum1"]);
                        ndt.Rname2 = Convert.ToString(row["Rname2"]);
                        ndt.Rship2 = Convert.ToString(row["Rship2"]);
                        ndt.Rnum2 = Convert.ToString(row["Rnum2"]);
                        ndt.Rname3 = Convert.ToString(row["Rname3"]);
                        ndt.Rship3 = Convert.ToString(row["Rship3"]);
                        ndt.Rnum3 = Convert.ToString(row["Rnum3"]);
                        ndt.Other1 = Convert.ToString(row["Other1"]);
                        ndt.Other2 = Convert.ToString(row["Other2"]);
                        ndt.Other3 = Convert.ToString(row["Other3"]);
                        ndt.Other4 = Convert.ToInt32(row["Other4"]);
                        ndt.Other5 = Convert.ToInt32(row["Other5"]);
                        ndt.Other6 = Convert.ToInt32(row["Other6"]);
                        ndt.Status = Convert.ToInt32(row["Status"]);
                        ndt.Username = Convert.ToString(row["Username"]);
                        ndt.Pwd = Convert.ToString(row["Pwd"]);
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
            return ndt;
        }

        public DataTable GetList()
        {
            DataTable table = null;
            try
            {
                try
                {
                    string strSql = "select * from LPerson";
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

