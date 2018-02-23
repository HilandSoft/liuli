namespace YingNet.WeiXing.Business
{
    using System;
    using System.Data;
    using System.Web.UI;
    using YingNet.Common;
    using YingNet.WeiXing.DB;
    using YingNet.WeiXing.DB.Data;

    public class YingSystemUserBN : BaseLib, IDisposable
    {
        public YingSystemUserBN(Page page) : base(page)
        {
        }

        public bool Add(YingSystemUserDT dt)
        {
            using (YingSystemUserDB rdb = new YingSystemUserDB())
            {
                return rdb.Insert(dt);
            }
        }

        public bool Del(int id)
        {
            using (YingSystemUserDB rdb = new YingSystemUserDB())
            {
                return rdb.TrueDel(id);
            }
        }

        public void Dispose()
        {
        }

        public bool Edit(YingSystemUserDT dt)
        {
            using (YingSystemUserDB rdb = new YingSystemUserDB())
            {
                return rdb.Update(dt);
            }
        }

        public YingSystemUserDT Get(int id)
        {
            using (YingSystemUserDB rdb = new YingSystemUserDB())
            {
                return rdb.GetOneDT(id);
            }
        }

        public DataTable GetList()
        {
            base.DBFieldList = "[id],account,password,[name],deptpermit, [name]+'('+Account+')' UserName";
            base.DBTable = "YingSystemUser";
            base.Filter = "isactive=1";
            return base.CommonGetList();
        }

        public YingSystemUserDT GetModel(int id)
        {
            YingSystemUserDT oneDT;
            try
            {
                using (YingSystemUserDB rdb = new YingSystemUserDB())
                {
                    oneDT = rdb.GetOneDT(id);
                }
            }
            catch
            {
                oneDT = null;
            }
            return oneDT;
        }

        public bool isAccount(string strAccouunt)
        {
            if ((strAccouunt != null) && (strAccouunt != ""))
            {
                base.Filter = null;
                base.Filter = "account='" + StringUtils.ToSQL(strAccouunt) + "'";
                DataTable list = this.GetList();
                if (list.Rows.Count > 0)
                {
                    list = null;
                    return true;
                }
                if (list != null)
                {
                    list = null;
                }
                return false;
            }
            return false;
        }

        public YingSystemUserDT Login(string strAccount, string strPassword)
        {
            using (YingSystemUserDB rdb = new YingSystemUserDB())
            {
                return rdb.Login(strAccount, strPassword);
            }
        }
    }
}

