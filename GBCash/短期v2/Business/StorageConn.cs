namespace YingNet.WeiXing.Business
{
    using System;
    using System.Data;
    using YingNet.WeiXing.DB;

    public class StorageConn
    {
        protected static DataTable m_InfoList = null;
        protected static DataTable m_InfoTypeList = null;
        protected static DataTable m_ProductList = null;
        protected static DataTable m_ProductTypeList = null;

        public static DataTable GetInfoList()
        {
            lock (typeof(StorageConn))
            {
                if (m_InfoList == null)
                {
                    using (YingInfoDB odb = new YingInfoDB())
                    {
                        m_InfoList = odb.GetList();
                    }
                }
                return m_InfoList;
            }
        }

        public static DataTable GetInfoListByType(string type)
        {
            DataTable infoList = GetInfoList();
            DataTable table2 = infoList.Clone();
            foreach (DataRow row in infoList.Select("[InfoTypeNo] like '" + type + "%' ", "InfoPubDate desc"))
            {
                table2.Rows.Add(row.ItemArray);
            }
            return table2;
        }

        public static DataTable GetInfoSeaList(string title, string type)
        {
            DataTable infoList = GetInfoList();
            DataTable table2 = infoList.Clone();
            foreach (DataRow row in infoList.Select("[InfoTitle] like '%" + title + "%' and [InfoTypeNo] like '" + type + "%' ", "InfoPubDate desc"))
            {
                table2.Rows.Add(row.ItemArray);
            }
            return table2;
        }

        public static DataTable GetInfoTopList(string num, int topnum)
        {
            DataTable infoList = GetInfoList();
            DataTable table2 = infoList.Clone();
            int num2 = 1;
            foreach (DataRow row in infoList.Select("[InfoTypeNo] like '" + num + "%'", "InfoID desc"))
            {
                if (num2 > topnum)
                {
                    return table2;
                }
                table2.Rows.Add(row.ItemArray);
                num2++;
            }
            return table2;
        }

        public static DataTable GetInfoTypeList()
        {
            lock (typeof(StorageConn))
            {
                if (m_InfoTypeList == null)
                {
                    using (YingInfoTypeDB edb = new YingInfoTypeDB())
                    {
                        m_InfoTypeList = edb.GetList();
                    }
                }
                return m_InfoTypeList;
            }
        }

        public static DataTable GetProductList()
        {
            lock (typeof(StorageConn))
            {
                if (m_ProductList == null)
                {
                    using (ProductDB tdb = new ProductDB())
                    {
                        m_ProductList = tdb.GetList();
                    }
                }
                return m_ProductList;
            }
        }

        public static DataTable GetProductTypeList()
        {
            lock (typeof(StorageConn))
            {
                if (m_ProductTypeList == null)
                {
                    using (ProductTypeDB edb = new ProductTypeDB())
                    {
                        m_ProductTypeList = edb.GetList();
                    }
                }
                return m_ProductTypeList;
            }
        }

        public static DataTable GetProductTypeRootList()
        {
            DataTable productTypeList = GetProductTypeList();
            DataTable table2 = productTypeList.Clone();
            foreach (DataRow row in productTypeList.Select("[Parent]='001'"))
            {
                table2.Rows.Add(row.ItemArray);
            }
            return table2;
        }

        public static void ReInit()
        {
            m_InfoList = null;
            m_InfoTypeList = null;
            m_ProductList = null;
            m_ProductTypeList = null;
        }
    }
}

