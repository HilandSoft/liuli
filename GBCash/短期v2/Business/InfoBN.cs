namespace YingNet.WeiXing.Business
{
    using System;
    using System.Data;
    using System.Web.UI;
    using YingNet.WeiXing.DB;
    using YingNet.WeiXing.DB.Data;

    public class InfoBN : BaseLib
    {
        public InfoBN(Page page) : base(page)
        {
        }

        public bool Add(InfoDT dt)
        {
            using (InfoDB odb = new InfoDB())
            {
                return odb.Insert(dt);
            }
        }

        public bool Del(int id)
        {
            using (InfoDB odb = new InfoDB())
            {
                return odb.Del(id);
            }
        }

        public bool Edit(InfoDT dt)
        {
            using (InfoDB odb = new InfoDB())
            {
                return odb.Update(dt);
            }
        }

        public InfoDT Get(int id)
        {
            using (InfoDB odb = new InfoDB())
            {
                return odb.GetOneDT(id);
            }
        }

        public DataTable GetList()
        {
            base.DBFieldList = "regtime,id,huiSid,isvalid,param2,param3,Username,type,param1";
            base.DBTable = "Info";
            base.Order = "regtime desc";
            return base.CommonGetList();
        }

        public void QueryValid(string str)
        {
            base.Filter = "isvalid =" + str + "";
        }
    }
}

