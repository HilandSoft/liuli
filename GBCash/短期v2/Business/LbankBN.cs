namespace YingNet.WeiXing.Business
{
    using System;
    using System.Data;
    using System.Web.UI;
    using YingNet.Common;
    using YingNet.Common.Database;
    using YingNet.WeiXing.DB;
    using YingNet.WeiXing.STRUCTURE;

    public class LbankBN : BaseBusiness
    {
        private LbankDB db;

        public LbankBN(Page page) : base(page)
        {
            this.db = null;
            this.db = new LbankDB(base.curDBOperater);
        }

        public LbankBN(Page page, DBOperate oper) : base(page, oper)
        {
            this.db = null;
            this.db = new LbankDB(base.curDBOperater);
        }

        public bool Add(LbankDT detail)
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

        public bool Edit(LbankDT detail)
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

        public LbankDT Get(int sid)
        {
            LbankDT kdt = null;
            try
            {
                try
                {
                    kdt = this.db.Get(sid);
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
            base.DBFieldList = "sid,BankName,Branch,AccountName,Bsb,AccountNum,PContact,Rname1,Rship1,Rnum1,Rname2,Rship2,Rnum2,Rname3,Rship3,Rnum3,LoanSid,Other1,Other2,Other3,Other4,Other5,Other6";
            base.DBTable = "LBank";
            return base.CommonGetList();
        }

        public void QueryAccountName(string AccountName)
        {
            if ((AccountName != null) && (AccountName.Trim() != ""))
            {
                base.Filter = "AccountName like '%" + StringUtils.ToSQL(AccountName) + "%'";
            }
        }

        public void QueryAccountNum(string AccountNum)
        {
            if ((AccountNum != null) && (AccountNum.Trim() != ""))
            {
                base.Filter = "AccountNum like '%" + StringUtils.ToSQL(AccountNum) + "%'";
            }
        }

        public void QueryBankName(string BankName)
        {
            if ((BankName != null) && (BankName.Trim() != ""))
            {
                base.Filter = "BankName like '%" + StringUtils.ToSQL(BankName) + "%'";
            }
        }

        public void QueryBranch(string Branch)
        {
            if ((Branch != null) && (Branch.Trim() != ""))
            {
                base.Filter = "Branch like '%" + StringUtils.ToSQL(Branch) + "%'";
            }
        }

        public void QueryBsb(string Bsb)
        {
            if ((Bsb != null) && (Bsb.Trim() != ""))
            {
                base.Filter = "Bsb like '%" + StringUtils.ToSQL(Bsb) + "%'";
            }
        }

        public void QueryLoanSid(int LoanSid)
        {
            base.Filter = "LoanSid= " + LoanSid;
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

        public void QueryPContact(string PContact)
        {
            if ((PContact != null) && (PContact.Trim() != ""))
            {
                base.Filter = "PContact like '%" + StringUtils.ToSQL(PContact) + "%'";
            }
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
    }
}

