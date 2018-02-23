namespace YingNet.WeiXing.Business
{
    using System;
    using System.Data;
    using System.Web.UI;
    using YingNet.WeiXing.DB;
    using YingNet.WeiXing.DB.Data;

    public class CSFollowupCenterBN : BaseLib
    {
        public CSFollowupCenterBN(Page page) : base(page)
        {
        }

        public bool Add(CSFollowupCenterDT dt)
        {
            using (CSFollowupCenterDB rdb = new CSFollowupCenterDB())
            {
                return rdb.Insert(dt);
            }
        }

        public bool Del(int id)
        {
            using (CSFollowupCenterDB rdb = new CSFollowupCenterDB())
            {
                return rdb.Del(id, true, "FollowupID");
            }
        }

        public bool Edit(CSFollowupCenterDT dt)
        {
            using (CSFollowupCenterDB rdb = new CSFollowupCenterDB())
            {
                return rdb.Update(dt);
            }
        }

        public CSFollowupCenterDT Get(int id)
        {
            using (CSFollowupCenterDB rdb = new CSFollowupCenterDB())
            {
                return (rdb.GetOneItem(id, "followupID") as CSFollowupCenterDT);
            }
        }

        public DataTable GetList()
        {
            base.DBFieldList = "*";
            base.DBTable = "CS_FollowupCenter";
            base.Order = "FollowupID desc";
            return base.CommonGetList();
        }
    }
}

