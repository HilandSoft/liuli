namespace YingNet.WeiXing.Business
{
    using System;
    using System.Data;
    using System.Web.UI;
    using YingNet.WeiXing.DB;
    using YingNet.WeiXing.DB.Data;

    public class CSUserLoanInfoCheckBN : BaseLib
    {
        public CSUserLoanInfoCheckBN(Page page) : base(page)
        {
        }

        public bool Add(CSUserLoanInfoCheckDT dt)
        {
            using (CSUserLoanInfoCheckDB kdb = new CSUserLoanInfoCheckDB())
            {
                return kdb.Insert(dt);
            }
        }

        public bool Del(int id)
        {
            using (CSUserLoanInfoCheckDB kdb = new CSUserLoanInfoCheckDB())
            {
                return kdb.Del(id, true, "InfoID");
            }
        }

        public bool Edit(CSUserLoanInfoCheckDT dt)
        {
            using (CSUserLoanInfoCheckDB kdb = new CSUserLoanInfoCheckDB())
            {
                return kdb.Update(dt);
            }
        }

        public CSUserLoanInfoCheckDT Get(int id)
        {
            using (CSUserLoanInfoCheckDB kdb = new CSUserLoanInfoCheckDB())
            {
                return (kdb.GetOneItem(id, "ProcessID") as CSUserLoanInfoCheckDT);
            }
        }

        public DataTable GetList()
        {
            base.DBFieldList = "*";
            base.DBTable = "cs_UserLoanInfoCheck";
            base.Order = "ProcessID desc";
            return base.CommonGetList();
        }
    }
}

