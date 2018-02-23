namespace YingNet.WeiXing.Business
{
    using System;
    using System.Data;
    using System.Web.UI;
    using YingNet.WeiXing.DB;
    using YingNet.WeiXing.DB.Data;

    public class LongteBN : BaseLib
    {
        public LongteBN(Page page) : base(page)
        {
        }

        public bool Add(LongteDT dt)
        {
            using (LongteDB edb = new LongteDB())
            {
                return edb.Insert(dt);
            }
        }

        public bool Del(int id)
        {
            using (LongteDB edb = new LongteDB())
            {
                return edb.Del(id);
            }
        }

        public bool Edit(LongteDT dt)
        {
            using (LongteDB edb = new LongteDB())
            {
                return edb.Update(dt);
            }
        }

        public DataTable GetList()
        {
            base.DBFieldList = "thome,sid,personsid,param5,tper,param3,param4,Rnum3,param1,param2,Rnum2,Rname3,Rship3,Rnum1,Rname2,Rship2,premethods,Rname1,Rship1,acname,bsb,acnumber,npayday,bankname,branch,estatus,jobtitle,timeemployed,ename,eaddress,etel";
            base.DBTable = "Longte";
            return base.CommonGetList();
        }
    }
}

