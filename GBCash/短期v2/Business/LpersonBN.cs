namespace YingNet.WeiXing.Business
{
    using System;
    using System.Data;
    using System.Web.UI;
    using YingNet.Common;
    using YingNet.Common.Database;
    using YingNet.WeiXing.DB;
    using YingNet.WeiXing.STRUCTURE;

    public class LpersonBN : BaseBusiness
    {
        private LpersonDB db;

        public LpersonBN(Page page) : base(page)
        {
            this.db = null;
            this.db = new LpersonDB(base.curDBOperater);
        }

        public LpersonBN(Page page, DBOperate oper) : base(page, oper)
        {
            this.db = null;
            this.db = new LpersonDB(base.curDBOperater);
        }

        public bool Add(LpersonDT detail)
        {
            bool flag = false;
            try
            {
                try
                {
                    flag = this.db.Add(detail);
                }
                catch (Exception exception)
                {
                    throw exception;
                }
            }
            finally
            {
            }
            return flag;
        }

        public int AddId(LpersonDT detail)
        {
            int num = 0;
            try
            {
                try
                {
                    num = this.db.AddId(detail);
                }
                catch (Exception exception)
                {
                    throw exception;
                }
            }
            finally
            {
            }
            return num;
        }

        public bool Delete(int sid)
        {
            bool flag = false;
            try
            {
                try
                {
                    flag = this.db.Delete(sid);
                }
                catch (Exception exception)
                {
                    throw exception;
                }
            }
            finally
            {
            }
            return flag;
        }

        public void Dispose()
        {
            base.Dispose();
            if (this.db != null)
            {
                this.db = null;
            }
        }

        public bool Edit(LpersonDT detail)
        {
            bool flag = false;
            try
            {
                try
                {
                    flag = this.db.Edit(detail);
                }
                catch (Exception exception)
                {
                    throw exception;
                }
            }
            finally
            {
            }
            return flag;
        }

        public LpersonDT Get(int sid)
        {
            LpersonDT ndt = null;
            try
            {
                try
                {
                    ndt = this.db.Get(sid);
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
            base.DBFieldList = "sid,IsExist,ReferenceNum,Title,Fname,Mname,Sname,Gender,DBirth,HTelcode,HTelnum,WTelcode,WTelnum,Mobile,Email,LicNum,LicState,MaritalStatus,RegTime,LoanSid,Rname1,Rship1,Rnum1,Rname2,Rship2,Rnum2,Rname3,Rship3,Rnum3,Other1,Other2,Other3,Other4,Other5,Other6,Status,Username,Pwd";
            base.DBTable = "LPerson";
            return base.CommonGetList();
        }

        public void QueryDBirth(string DBirth)
        {
            if ((DBirth != null) && (DBirth.Trim() != ""))
            {
                base.Filter = "DBirth like '%" + StringUtils.ToSQL(DBirth) + "%'";
            }
        }

        public void QueryEmail(string Email)
        {
            if ((Email != null) && (Email.Trim() != ""))
            {
                base.Filter = "Email like '%" + StringUtils.ToSQL(Email) + "%'";
            }
        }

        public void QueryFname(string Fname)
        {
            if ((Fname != null) && (Fname.Trim() != ""))
            {
                base.Filter = "Fname like '%" + StringUtils.ToSQL(Fname) + "%'";
            }
        }

        public void QueryGender(string Gender)
        {
            if ((Gender != null) && (Gender.Trim() != ""))
            {
                base.Filter = "Gender like '%" + StringUtils.ToSQL(Gender) + "%'";
            }
        }

        public void QueryHTelcode(string HTelcode)
        {
            if ((HTelcode != null) && (HTelcode.Trim() != ""))
            {
                base.Filter = "HTelcode like '%" + StringUtils.ToSQL(HTelcode) + "%'";
            }
        }

        public void QueryHTelnum(string HTelnum)
        {
            if ((HTelnum != null) && (HTelnum.Trim() != ""))
            {
                base.Filter = "HTelnum like '%" + StringUtils.ToSQL(HTelnum) + "%'";
            }
        }

        public void QueryIsExist(int IsExist)
        {
            base.Filter = "IsExist= " + IsExist;
        }

        public void QueryLicNum(string LicNum)
        {
            if ((LicNum != null) && (LicNum.Trim() != ""))
            {
                base.Filter = "LicNum like '%" + StringUtils.ToSQL(LicNum) + "%'";
            }
        }

        public void QueryLicState(string LicState)
        {
            if ((LicState != null) && (LicState.Trim() != ""))
            {
                base.Filter = "LicState like '%" + StringUtils.ToSQL(LicState) + "%'";
            }
        }

        public void QueryLoanSid(int LoanSid)
        {
            base.Filter = "LoanSid= " + LoanSid;
        }

        public void QueryMaritalStatus(string MaritalStatus)
        {
            if ((MaritalStatus != null) && (MaritalStatus.Trim() != ""))
            {
                base.Filter = "MaritalStatus like '%" + StringUtils.ToSQL(MaritalStatus) + "%'";
            }
        }

        public void QueryMname(string Mname)
        {
            if ((Mname != null) && (Mname.Trim() != ""))
            {
                base.Filter = "Mname like '%" + StringUtils.ToSQL(Mname) + "%'";
            }
        }

        public void QueryMobile(string Mobile)
        {
            if ((Mobile != null) && (Mobile.Trim() != ""))
            {
                base.Filter = "Mobile like '%" + StringUtils.ToSQL(Mobile) + "%'";
            }
        }

        public void QueryOther1(string Other1)
        {
            if ((Other1 != null) && (Other1.Trim() != ""))
            {
                base.Filter = "Other1 like '%" + StringUtils.ToSQL(Other1) + "%'";
            }
        }

        public void QueryOther2(string Other2)
        {
            if ((Other2 != null) && (Other2.Trim() != ""))
            {
                base.Filter = "Other2 like '%" + StringUtils.ToSQL(Other2) + "%'";
            }
        }

        public void QueryOther3(string Other3)
        {
            if ((Other3 != null) && (Other3.Trim() != ""))
            {
                base.Filter = "Other3 like '%" + StringUtils.ToSQL(Other3) + "%'";
            }
        }

        public void QueryOther4(int Other4)
        {
            base.Filter = "Other4= " + Other4;
        }

        public void QueryOther5(int Other5)
        {
            base.Filter = "Other5= " + Other5;
        }

        public void QueryOther6(int Other6)
        {
            base.Filter = "Other6= " + Other6;
        }

        public void QueryPwd(string Pwd)
        {
            if ((Pwd != null) && (Pwd.Trim() != ""))
            {
                base.Filter = "Pwd like '%" + StringUtils.ToSQL(Pwd) + "%'";
            }
        }

        public void QueryReferenceNum(string ReferenceNum)
        {
            if ((ReferenceNum != null) && (ReferenceNum.Trim() != ""))
            {
                base.Filter = "ReferenceNum like '%" + StringUtils.ToSQL(ReferenceNum) + "%'";
            }
        }

        public void QueryRegTime(DateTime RegTime)
        {
            base.Filter = "RegTime= " + RegTime;
        }

        public void QueryRname1(string Rname1)
        {
            if ((Rname1 != null) && (Rname1.Trim() != ""))
            {
                base.Filter = "Rname1 like '%" + StringUtils.ToSQL(Rname1) + "%'";
            }
        }

        public void QueryRname2(string Rname2)
        {
            if ((Rname2 != null) && (Rname2.Trim() != ""))
            {
                base.Filter = "Rname2 like '%" + StringUtils.ToSQL(Rname2) + "%'";
            }
        }

        public void QueryRname3(string Rname3)
        {
            if ((Rname3 != null) && (Rname3.Trim() != ""))
            {
                base.Filter = "Rname3 like '%" + StringUtils.ToSQL(Rname3) + "%'";
            }
        }

        public void QueryRnum1(string Rnum1)
        {
            if ((Rnum1 != null) && (Rnum1.Trim() != ""))
            {
                base.Filter = "Rnum1 like '%" + StringUtils.ToSQL(Rnum1) + "%'";
            }
        }

        public void QueryRnum2(string Rnum2)
        {
            if ((Rnum2 != null) && (Rnum2.Trim() != ""))
            {
                base.Filter = "Rnum2 like '%" + StringUtils.ToSQL(Rnum2) + "%'";
            }
        }

        public void QueryRnum3(string Rnum3)
        {
            if ((Rnum3 != null) && (Rnum3.Trim() != ""))
            {
                base.Filter = "Rnum3 like '%" + StringUtils.ToSQL(Rnum3) + "%'";
            }
        }

        public void QueryRship1(string Rship1)
        {
            if ((Rship1 != null) && (Rship1.Trim() != ""))
            {
                base.Filter = "Rship1 like '%" + StringUtils.ToSQL(Rship1) + "%'";
            }
        }

        public void QueryRship2(string Rship2)
        {
            if ((Rship2 != null) && (Rship2.Trim() != ""))
            {
                base.Filter = "Rship2 like '%" + StringUtils.ToSQL(Rship2) + "%'";
            }
        }

        public void QueryRship3(string Rship3)
        {
            if ((Rship3 != null) && (Rship3.Trim() != ""))
            {
                base.Filter = "Rship3 like '%" + StringUtils.ToSQL(Rship3) + "%'";
            }
        }

        public void Querysid(int sid)
        {
            base.Filter = "sid= " + sid;
        }

        public void QuerySname(string Sname)
        {
            if ((Sname != null) && (Sname.Trim() != ""))
            {
                base.Filter = "Sname like '%" + StringUtils.ToSQL(Sname) + "%'";
            }
        }

        public void QueryStatus(int Status)
        {
            base.Filter = "Status= " + Status;
        }

        public void QueryTitle(string Title)
        {
            if ((Title != null) && (Title.Trim() != ""))
            {
                base.Filter = "Title like '%" + StringUtils.ToSQL(Title) + "%'";
            }
        }

        public void QueryUsername(string Username)
        {
            if ((Username != null) && (Username.Trim() != ""))
            {
                base.Filter = "Username like '%" + StringUtils.ToSQL(Username) + "%'";
            }
        }

        public void QueryWTelcode(string WTelcode)
        {
            if ((WTelcode != null) && (WTelcode.Trim() != ""))
            {
                base.Filter = "WTelcode like '%" + StringUtils.ToSQL(WTelcode) + "%'";
            }
        }

        public void QueryWTelnum(string WTelnum)
        {
            if ((WTelnum != null) && (WTelnum.Trim() != ""))
            {
                base.Filter = "WTelnum like '%" + StringUtils.ToSQL(WTelnum) + "%'";
            }
        }
    }
}

