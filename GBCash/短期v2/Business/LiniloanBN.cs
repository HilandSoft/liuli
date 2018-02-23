namespace YingNet.WeiXing.Business
{
    using System;
    using System.Data;
    using System.Web.UI;
    using YingNet.Common;
    using YingNet.Common.Database;
    using YingNet.WeiXing.DB;
    using YingNet.WeiXing.STRUCTURE;

    public class LiniloanBN : BaseBusiness
    {
        private LiniloanDB db;

        public LiniloanBN(Page page) : base(page)
        {
            this.db = null;
            this.db = new LiniloanDB(base.curDBOperater);
        }

        public LiniloanBN(Page page, DBOperate oper) : base(page, oper)
        {
            this.db = null;
            this.db = new LiniloanDB(base.curDBOperater);
        }

        public bool Add(LiniloanDT detail)
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

        public int AddId(LiniloanDT detail)
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

        public bool Edit(LiniloanDT detail)
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

        public LiniloanDT Get(int sid)
        {
            LiniloanDT ndt = null;
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
            base.DBFieldList = "sid,PrimaryPurpose,Loan,Term,Other1,Other2,Other3,Other4,Other5,Other6,Persid\t";
            base.DBTable = "LIniLoan";
            return base.CommonGetList();
        }

        public void QueryLoan(double Loan)
        {
            base.Filter = "Loan= " + Loan;
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

        public void QueryPersid(int Persid)
        {
            base.Filter = "Persid= " + Persid;
        }

        public void QueryPrimaryPurpose(string PrimaryPurpose)
        {
            if ((PrimaryPurpose != null) && (PrimaryPurpose.Trim() != ""))
            {
                base.Filter = "PrimaryPurpose like '%" + StringUtils.ToSQL(PrimaryPurpose) + "%'";
            }
        }

        public void Querysid(int sid)
        {
            base.Filter = "sid= " + sid;
        }

        public void QueryTerm(int Term)
        {
            base.Filter = "Term= " + Term;
        }
    }
}

