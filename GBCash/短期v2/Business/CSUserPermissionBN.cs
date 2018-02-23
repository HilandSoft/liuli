namespace YingNet.WeiXing.Business
{
    using System;
    using System.Web.UI;
    using TunyNet.Caching;
    using YingNet.WeiXing.DB;
    using YingNet.WeiXing.DB.Data;

    public class CSUserPermissionBN : BaseLib
    {
        private string cacheKey;

        public CSUserPermissionBN(Page page) : base(page)
        {
            this.cacheKey = "CSUserPermission:user-";
        }

        public bool Add(CSUserPermissionDT dt)
        {
            using (CSUserPermissionDB ndb = new CSUserPermissionDB())
            {
                bool flag = ndb.Insert(dt);
                if (flag)
                {
                    WebCache.Max(this.cacheKey + dt.UserID, dt);
                }
                return flag;
            }
        }

        public bool Edit(CSUserPermissionDT dt)
        {
            using (CSUserPermissionDB ndb = new CSUserPermissionDB())
            {
                bool flag = ndb.Update(dt);
                if (flag)
                {
                    WebCache.Max(this.cacheKey + dt.UserID, dt);
                }
                return flag;
            }
        }

        public CSUserPermissionDT Get(int userID)
        {
            if (WebCache.Get(this.cacheKey + string.Format("{0}", userID)) != null)
            {
                return (CSUserPermissionDT) WebCache.Get(this.cacheKey + string.Format("{0}", userID));
            }
            using (CSUserPermissionDB ndb = new CSUserPermissionDB())
            {
                return (ndb.GetOneItem(userID, "UserID") as CSUserPermissionDT);
            }
        }
    }
}

