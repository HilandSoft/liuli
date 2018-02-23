namespace YingNet.WeiXing.Business
{
    using System;
    using System.Data;
    using System.Data.SqlClient;
    using System.Web.UI;
    using YingNet.WeiXing.DB;
    using YingNet.WeiXing.DB.Data;

    public class YingInfoTypeBN : BaseLib
    {
        public YingInfoTypeBN(Page page) : base(page)
        {
        }

        public bool Add(YingInfoTypeDT dt)
        {
            using (YingInfoTypeDB edb = new YingInfoTypeDB())
            {
                dt = this.CouvDt(dt);
                if (edb.Insert(dt))
                {
                    this.updatehas_sub();
                    StorageConn.ReInit();
                    return true;
                }
                return false;
            }
        }

        public YingInfoTypeDT CouvDt(YingInfoTypeDT dt)
        {
            YingInfoTypeDB edb = new YingInfoTypeDB();
            dt.Has_Sub = true;
            string parent = dt.Parent;
            int num = 0;
            if ((parent == null) || parent.Equals(""))
            {
                parent = "0";
            }
            SqlDataReader reader = edb.RunSqlString(string.Concat(new object[] { "SELECT substring(num, ", parent.Length + 1, ", 3) as newnum FROM YingInfoType where parent='", parent, "' ORDER BY num" }));
            while ((num < 0x3e7) && reader.Read())
            {
                int num2 = int.Parse(reader[0].ToString());
                if ((num2 - num) > 1)
                {
                    break;
                }
                num = num2;
            }
            reader.Close();
            if (num > 0x3e7)
            {
                return null;
            }
            if (parent != "0")
            {
                dt.Num = parent + ((num + 1)).ToString("D3");
            }
            else
            {
                dt.Parent = "0";
                dt.Num = (num + 1).ToString("D3");
            }
            return dt;
        }

        public bool Del(string num)
        {
            using (YingInfoTypeDB edb = new YingInfoTypeDB())
            {
                if (!edb.ISHasDel(num) && !edb.ISHasSub(num))
                {
                    if (edb.Del(num))
                    {
                        this.updatehas_sub();
                        StorageConn.ReInit();
                        return true;
                    }
                    return false;
                }
                return false;
            }
        }

        public bool Edit(YingInfoTypeDT dt)
        {
            using (YingInfoTypeDB edb = new YingInfoTypeDB())
            {
                StorageConn.ReInit();
                return edb.Update(dt);
            }
        }

        public YingInfoTypeDT GetByNum(string s)
        {
            using (YingInfoTypeDB edb = new YingInfoTypeDB())
            {
                return edb.GetByNum(s);
            }
        }

        public DataTable GetList()
        {
            base.DBFieldList = "Has_Sub,Num,TypeName,Parent,id";
            base.DBTable = "YingInfoType";
            return base.CommonGetList();
        }

        public DataTable GetList(string num)
        {
            base.DBFieldList = "Has_Sub,Num,TypeName,Parent,id";
            base.DBTable = "YingInfoType";
            base.Filter = "num like '" + num + "%'";
            return base.CommonGetList();
        }

        public DataTable GetListByNum(string num)
        {
            using (YingInfoTypeDB edb = new YingInfoTypeDB())
            {
                return edb.RunSqlString("SELECT * FROM YingInfo LEFT OUTER JOIN YingInfoType ON YingInfoType.Num = YingInfo.InfoTypeNo where Parent='" + num + "'", "list");
            }
        }

        public DataTable GetListByParent(string parent)
        {
            base.DBFieldList = "Has_Sub,Num,TypeName,Parent,id";
            base.DBTable = "YingInfoType";
            base.Filter = "parent like '" + parent + "%'";
            base.Order = "id desc";
            return base.CommonGetList();
        }

        public bool ISHasSub(string s)
        {
            using (YingInfoTypeDB edb = new YingInfoTypeDB())
            {
                return edb.ISHasSub(s);
            }
        }

        public void updatehas_sub()
        {
            using (YingInfoTypeDB edb = new YingInfoTypeDB())
            {
                edb.RunSqlStringNoReturn("update [YingInfoType] set has_sub=1 update [YingInfoType] set has_sub=0 where num in (select parent from YingInfoType where parent is not null)");
            }
        }
    }
}

