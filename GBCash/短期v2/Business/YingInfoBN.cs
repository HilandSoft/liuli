namespace YingNet.WeiXing.Business
{
    using System;
    using System.Data;
    using System.Web.UI;
    using YingNet.WeiXing.DB;
    using YingNet.WeiXing.DB.Data;

    public class YingInfoBN : BaseLib
    {
        public YingInfoBN(Page page) : base(page)
        {
        }

        public bool Add(YingInfoDT dt)
        {
            using (YingInfoDB odb = new YingInfoDB())
            {
                if (odb.Insert(dt))
                {
                    StorageConn.ReInit();
                    return true;
                }
                return false;
            }
        }

        public bool Del(int id)
        {
            using (YingInfoDB odb = new YingInfoDB())
            {
                if (odb.TrueDel(id))
                {
                    StorageConn.ReInit();
                    return true;
                }
                return false;
            }
        }

        public bool Edit(YingInfoDT dt)
        {
            using (YingInfoDB odb = new YingInfoDB())
            {
                if (odb.Update(dt))
                {
                    StorageConn.ReInit();
                    return true;
                }
                return false;
            }
        }

        public YingInfoDT Get(int id)
        {
            using (YingInfoDB odb = new YingInfoDB())
            {
                return odb.GetOneDT(id);
            }
        }

        public DataTable GetList()
        {
            base.DBFieldList = "InfoIsTop,InfoTitle,ImgPath,InfoPubDate,InfoID,InfoTypeNO,InfoContent";
            base.DBTable = "YingInfo";
            base.Order = "InfoPubDate desc";
            return base.CommonGetList();
        }

        public DataTable GetList(string str)
        {
            using (YingInfoDB odb = new YingInfoDB())
            {
                return odb.RunSqlString("select * from YingInfo where InfoTypeNo like '%" + str + "%' order by InfoID desc", "list");
            }
        }

        public DataTable GetList(int i, string num)
        {
            using (YingInfoDB odb = new YingInfoDB())
            {
                return odb.RunSqlString(string.Concat(new object[] { "select  top ", i, " InfoTitle,InfoID,InfoPubDate,ImgPath,InfoContent from YingInfo where InfoTypeNo like '", num, "%' order by InfoID desc" }), "list");
            }
        }

        public DataTable GetListByTitle(string str)
        {
            using (YingInfoDB odb = new YingInfoDB())
            {
                return odb.RunSqlString("select * from YingInfo where InfoTitle like '%" + str + "%' order by InfoID desc", "list");
            }
        }

        public void QueryType(string id)
        {
            if ((id != null) && (id != string.Empty))
            {
                base.Filter = "InfoTypeNo like '" + id.ToString() + "%'";
            }
        }
    }
}

