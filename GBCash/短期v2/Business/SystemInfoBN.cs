namespace YingNet.WeiXing.Business
{
    using System;
    using System.Data;
    using System.Web.UI;
    using YingNet.WeiXing.DB;
    using YingNet.WeiXing.DB.Data;

    public class SystemInfoBN : BaseLib
    {
        public SystemInfoBN(Page page) : base(page)
        {
        }

        public bool Add(SystemInfoDT dt)
        {
            using (SystemInfoDB odb = new SystemInfoDB())
            {
                return odb.Insert(dt);
            }
        }

        public bool Del(int id)
        {
            using (SystemInfoDB odb = new SystemInfoDB())
            {
                return odb.Del(id);
            }
        }

        public bool Edit(SystemInfoDT dt)
        {
            using (SystemInfoDB odb = new SystemInfoDB())
            {
                return odb.Update(dt);
            }
        }

        public SystemInfoDT Get(int id)
        {
            using (SystemInfoDB odb = new SystemInfoDB())
            {
                return odb.GetOneDT(id);
            }
        }

        public DataTable GetList()
        {
            base.DBFieldList = "param2,lowerlimit2,upperlimit2,param1,frequency,interest,poundage,percentage,upperlimit,lowerlimit,param3,param4,datediffw,datedifff,datediffm,shortday,IsPercent,yanqinum,id,installment,term";
            base.DBTable = "SystemInfo";
            return base.CommonGetList();
        }
    }
}

