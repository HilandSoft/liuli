namespace YingNet.WeiXing.Business
{
    using System;
    using System.Data;
    using System.Web.UI;
    using YingNet.WeiXing.DB;
    using YingNet.WeiXing.DB.Data;

    public class YingSystemModuleBN : BaseLib
    {
        public YingSystemModuleBN(Page page) : base(page)
        {
        }

        public bool Add(YingSystemModuleDT dt)
        {
            using (YingSystemModuleDB edb = new YingSystemModuleDB())
            {
                return edb.Insert(dt);
            }
        }

        public bool Del(int id)
        {
            using (YingSystemModuleDB edb = new YingSystemModuleDB())
            {
                return edb.Del(id);
            }
        }

        public bool Edit(YingSystemModuleDT dt)
        {
            using (YingSystemModuleDB edb = new YingSystemModuleDB())
            {
                return edb.Update(dt);
            }
        }

        public YingSystemModuleDT Get(string strCode)
        {
            using (YingSystemModuleDB edb = new YingSystemModuleDB())
            {
                return edb.GetOneDT(strCode);
            }
        }

        public DataTable GetList()
        {
            base.DBFieldList = "code,name,displayname";
            base.DBTable = "YingSystemModule";
            return base.CommonGetList();
        }
    }
}

