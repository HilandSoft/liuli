namespace YingNet.WeiXing.DB
{
    using System;
    using System.Data;
    using System.Data.SqlClient;
    using YingNet.Common;
    using YingNet.WeiXing.DB.Data;

    public class ProductTypeDB : DBAccess
    {
        public override object ConvertItem(SqlDataReader dr)
        {
            ProductTypeDT edt = new ProductTypeDT();
            edt.Has_Sub = Convert.ToBoolean(dr["Has_Sub"]);
            edt.id = Convert.ToInt32(dr["id"]);
            edt.ImgPath = Convert.ToString(dr["ImgPath"]);
            edt.num = Convert.ToString(dr["num"]);
            edt.TypeName = Convert.ToString(dr["TypeName"]);
            edt.Parent = Convert.ToString(dr["Parent"]);
            edt.TypeInfo = Convert.ToString(dr["TypeInfo"]);
            return edt;
        }

        public bool Del(string num)
        {
            base.Open();
            try
            {
                if (SqlHelper.ExecuteNonQuery(base.oConn, CommandType.Text, "DELETE FROM ProductType where num='" + num + "'") == 1)
                {
                    base.Close();
                    return true;
                }
                base.Close();
                return false;
            }
            catch (SqlException)
            {
                return false;
            }
        }

        public ProductTypeDT GetByNum(string s)
        {
            return (ProductTypeDT) this.GetOneItem(s);
        }

        public DataTable GetList()
        {
            return this.RunSqlString("SELECT id, num, TypeName, Parent, Has_Sub,SUBSTRING(TypeInfo, 0, 100) as TypeInfo,ImgPath FROM ProductType ORDER BY num", "data");
        }

        public DataTable GetList(string parentid)
        {
            return this.RunSqlString("SELECT id, num, TypeName, Parent, Has_Sub,SUBSTRING(TypeInfo, 0, 100) as TypeInfo,ImgPath FROM ProductType where [Parent]='" + parentid + "'   ORDER BY num", "data");
        }

        public ProductTypeDT GetOneDT(int id)
        {
            return (ProductTypeDT) this.GetOneItem(id);
        }

        public virtual object GetOneItem(string num)
        {
            object obj2 = null;
            SqlDataReader dr = null;
            base.Open();
            try
            {
                dr = this.RunSqlString("Select * from ProductType where num='" + num + "'");
                if (dr.Read())
                {
                    obj2 = this.ConvertItem(dr);
                }
                else
                {
                    obj2 = null;
                }
                dr.Close();
            }
            catch (SqlException)
            {
                return null;
            }
            finally
            {
                base.Close();
            }
            base.Close();
            return obj2;
        }

        public override SqlParameter[] GetParameter(object obj)
        {
            ProductTypeDT edt = (ProductTypeDT) obj;
            return new SqlParameter[] { base.MakeInParam("@Has_Sub", SqlDbType.Bit, 1, edt.Has_Sub), base.MakeInParam("@id", SqlDbType.Int, 4, edt.id), base.MakeInParam("@ImgPath", SqlDbType.NVarChar, 600, edt.ImgPath), base.MakeInParam("@num", SqlDbType.NVarChar, 240, edt.num), base.MakeInParam("@TypeName", SqlDbType.NVarChar, 300, edt.TypeName), base.MakeInParam("@Parent", SqlDbType.NVarChar, 240, edt.Parent), base.MakeInParam("@TypeInfo", SqlDbType.Text, 0, edt.TypeInfo) };
        }

        public bool ISHasDel(string num)
        {
            base.Open();
            try
            {
                if (this.RunSqlString("select id FROM ProductType where Num like '" + num + "%'", "t").Rows.Count > 1)
                {
                    base.Close();
                    return true;
                }
                base.Close();
                return false;
            }
            catch (SqlException)
            {
                return false;
            }
        }

        public bool ISHasSub(string num)
        {
            base.Open();
            try
            {
                if (this.RunSqlString("select id FROM Product where ProductTypeNo like '" + num + "%'", "t").Rows.Count > 0)
                {
                    base.Close();
                    return true;
                }
                base.Close();
                return false;
            }
            catch (SqlException)
            {
                return false;
            }
        }
    }
}

