namespace YingNet.WeiXing.Business
{
    using System;
    using System.Data;
    using System.Web.UI;
    using YingNet.WeiXing.DB;
    using YingNet.WeiXing.DB.Data;

    public class EmployedBN : BaseLib
    {
        public EmployedBN(Page page) : base(page)
        {
        }

        public bool Add(EmployedDT dt)
        {
            using (EmployedDB ddb = new EmployedDB())
            {
                return ddb.Insert(dt);
            }
        }

        public int Add2(EmployedDT dt)
        {
            using (EmployedDB ddb = new EmployedDB())
            {
                return ddb.Insert2(dt);
            }
        }

        public bool Del(int id)
        {
            using (EmployedDB ddb = new EmployedDB())
            {
                return ddb.Del(id);
            }
        }

        public bool Edit(EmployedDT dt)
        {
            using (EmployedDB ddb = new EmployedDB())
            {
                return ddb.Update(dt);
            }
        }

        public EmployedDT Get(int id)
        {
            using (EmployedDB ddb = new EmployedDB())
            {
                return ddb.GetOneDT(id);
            }
        }

        public DataTable GetList()
        {
            base.DBFieldList = " * ";
            base.DBTable = "Employed";
            return base.CommonGetList();
        }

        public void QueryhuiSid(string str)
        {
            base.Filter = "huiSid =" + str + "";
        }

        public void QueryIsValid(string str)
        {
            base.Filter = "IsValid =" + str + "";
        }

        public void QueryNotIsvalid(string str)
        {
            base.Filter = "IsValid!=" + str + "";
        }

        public void QueryParam3(string str)
        {
            base.Filter = "Param3 ='" + str + "'";
        }
    }
}

