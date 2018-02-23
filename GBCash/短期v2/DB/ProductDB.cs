namespace YingNet.WeiXing.DB
{
    using System;
    using System.Data;
    using System.Data.SqlClient;
    using YingNet.Common;
    using YingNet.WeiXing.DB.Data;

    public class ProductDB : DBAccess
    {
        public override object ConvertItem(SqlDataReader dr)
        {
            ProductDT tdt = new ProductDT();
            tdt.ProductIsTop = Convert.ToBoolean(dr["ProductIsTop"]);
            tdt.PubDate = Convert.ToDateTime(dr["PubDate"]);
            tdt.PriductID = Convert.ToInt32(dr["PriductID"]);
            tdt.ProductName = Convert.ToString(dr["ProductName"]);
            tdt.ImgPath = Convert.ToString(dr["ImgPath"]);
            tdt.ProductTypeNo = Convert.ToString(dr["ProductTypeNo"]);
            tdt.ProductInfo = Convert.ToString(dr["ProductInfo"]);
            return tdt;
        }

        public DataTable GetList()
        {
            return this.RunSqlString("SELECT PriductID, ProductName, PubDate, ImgPath, ProductIsTop, ProductTypeNo FROM Product ORDER BY PubDate", "data");
        }

        public ProductDT GetOneDT(int id)
        {
            return (ProductDT) this.GetOneItem(id);
        }

        public override SqlParameter[] GetParameter(int id)
        {
            return new SqlParameter[] { base.MakeInParam("@PriductID", SqlDbType.Int, 4, id) };
        }

        public override SqlParameter[] GetParameter(object obj)
        {
            ProductDT tdt = (ProductDT) obj;
            return new SqlParameter[] { base.MakeInParam("@ProductIsTop", SqlDbType.Bit, 1, tdt.ProductIsTop), base.MakeInParam("@PubDate", SqlDbType.DateTime, 8, tdt.PubDate), base.MakeInParam("@PriductID", SqlDbType.Int, 4, tdt.PriductID), base.MakeInParam("@ProductName", SqlDbType.NVarChar, 800, tdt.ProductName), base.MakeInParam("@ImgPath", SqlDbType.NVarChar, 600, tdt.ImgPath), base.MakeInParam("@ProductTypeNo", SqlDbType.NVarChar, 240, tdt.ProductTypeNo), base.MakeInParam("@ProductInfo", SqlDbType.Text, 0, tdt.ProductInfo) };
        }
    }
}

