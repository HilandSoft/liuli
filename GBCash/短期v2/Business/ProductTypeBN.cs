namespace YingNet.WeiXing.Business
{
    using System;
    using System.Data;
    using System.Data.SqlClient;
    using System.Web.UI;
    using YingNet.WeiXing.DB;
    using YingNet.WeiXing.DB.Data;

    public class ProductTypeBN : BaseLib
    {
        public ProductTypeBN(Page page) : base(page)
        {
        }

        public bool Add(ProductTypeDT dt)
        {
            using (ProductTypeDB edb = new ProductTypeDB())
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

        public ProductTypeDT CouvDt(ProductTypeDT dt)
        {
            ProductTypeDB edb = new ProductTypeDB();
            dt.Has_Sub = true;
            string parent = dt.Parent;
            int num = 0;
            if ((parent == null) || parent.Equals(""))
            {
                parent = "0";
            }
            SqlDataReader reader = edb.RunSqlString(string.Concat(new object[] { "SELECT substring(num, ", parent.Length + 1, ", 3) as newnum FROM ProductType where parent='", parent, "' ORDER BY num" }));
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
                dt.num = parent + ((num + 1)).ToString("D3");
            }
            else
            {
                dt.Parent = "0";
                dt.num = (num + 1).ToString("D3");
            }
            return dt;
        }

        public bool Del(string num)
        {
            using (ProductTypeDB edb = new ProductTypeDB())
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

        public bool Edit(ProductTypeDT dt)
        {
            using (ProductTypeDB edb = new ProductTypeDB())
            {
                if (edb.Update(dt))
                {
                    StorageConn.ReInit();
                    return true;
                }
                return false;
            }
        }

        public ProductTypeDT Get(string i)
        {
            using (ProductTypeDB edb = new ProductTypeDB())
            {
                return edb.GetByNum(i);
            }
        }

        public ProductTypeDT GetByNum(string s)
        {
            using (ProductTypeDB edb = new ProductTypeDB())
            {
                return edb.GetByNum(s);
            }
        }

        public DataTable GetList()
        {
            base.DBFieldList = "Has_Sub,id,ImgPath,num,TypeName,Parent,TypeInfo";
            base.DBTable = "ProductType";
            return base.CommonGetList();
        }

        public DataTable GetListByNum(string num)
        {
            using (ProductTypeDB edb = new ProductTypeDB())
            {
                return edb.RunSqlString("SELECT * FROM Product LEFT OUTER JOIN ProductType ON ProductType.Num = Product.ProductTypeNo where Parent='" + num + "'", "list");
            }
        }

        public bool ISHasSub(string s)
        {
            using (ProductTypeDB edb = new ProductTypeDB())
            {
                return edb.ISHasSub(s);
            }
        }

        public void updatehas_sub()
        {
            using (ProductTypeDB edb = new ProductTypeDB())
            {
                edb.RunSqlStringNoReturn("update [ProductType] set has_sub=1 update [ProductType] set has_sub=0 where num in (select parent from ProductType where parent is not null)");
            }
        }
    }
}

