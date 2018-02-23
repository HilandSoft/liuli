namespace YingNet.WeiXing.Business
{
    using System;
    using System.Data;
    using System.Web.UI;
    using YingNet.WeiXing.DB;
    using YingNet.WeiXing.DB.Data;

    public class CSUserBN : BaseLib
    {
        public CSUserBN(Page page) : base(page)
        {
        }

        public bool Add(CSUserDT dt)
        {
            using (CSUserDB rdb = new CSUserDB())
            {
                return rdb.Insert(dt);
            }
        }

        public bool Del(int id)
        {
            using (CSUserDB rdb = new CSUserDB())
            {
                return rdb.Del(id, true, "UserID");
            }
        }

        public bool Edit(CSUserDT dt)
        {
            using (CSUserDB rdb = new CSUserDB())
            {
                return rdb.Update(dt);
            }
        }

        public CSUserDT Get(int id)
        {
            using (CSUserDB rdb = new CSUserDB())
            {
                return (rdb.GetOneItem(id, "UserID") as CSUserDT);
            }
        }

        public DataTable GetList()
        {
            base.DBFieldList = "*";
            base.DBTable = "CS_User";
            base.Order = "UserID asc";
            return base.CommonGetList();
        }
    }
}

