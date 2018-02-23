namespace YingNet.WeiXing.Business
{
    using System;
    using System.Data;
    using System.Web.UI;
    using YingNet.WeiXing.DB;
    using YingNet.WeiXing.DB.Data;

    public class ProductBN : BaseLib
    {
        public ProductBN(Page page) : base(page)
        {
        }

        public bool Add(ProductDT dt)
        {
            using (ProductDB tdb = new ProductDB())
            {
                if (tdb.Insert(dt))
                {
                    StorageConn.ReInit();
                    return true;
                }
                return false;
            }
        }

        public bool Del(int id)
        {
            using (ProductDB tdb = new ProductDB())
            {
                if (tdb.TrueDel(id))
                {
                    StorageConn.ReInit();
                    return true;
                }
                return false;
            }
        }

        public bool Edit(ProductDT dt)
        {
            using (ProductDB tdb = new ProductDB())
            {
                if (tdb.Update(dt))
                {
                    StorageConn.ReInit();
                    return true;
                }
                return false;
            }
        }

        public ProductDT Get(int id)
        {
            using (ProductDB tdb = new ProductDB())
            {
                return tdb.GetOneDT(id);
            }
        }

        public DataTable GetList()
        {
            base.DBFieldList = "ProductIsTop,PubDate,PriductID,ProductName,ImgPath,ProductTypeNo,ProductInfo";
            base.DBTable = "Product";
            base.Order = "PubDate desc";
            return base.CommonGetList();
        }

        public DataTable GetList(string num)
        {
            base.DBFieldList = "ProductIsTop,PubDate,PriductID,ProductName";
            base.DBTable = "Product";
            base.Filter = "ProductTypeNo like '" + num + "%'";
            return base.CommonGetList();
        }
    }
}

