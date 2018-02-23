namespace YingNet.WeiXing.DB
{
    using System;
    using System.Data;
    using System.Data.SqlClient;
    using YingNet.Common;
    using YingNet.WeiXing.DB.Data;

    public class YingInfoTypeDB : DBAccess
    {
        public override object ConvertItem(SqlDataReader dr)
        {
            YingInfoTypeDT edt = new YingInfoTypeDT();
            edt.Has_Sub = Convert.ToBoolean(dr["Has_Sub"]);
            edt.id = Convert.ToInt32(dr["id"]);
            edt.Num = Convert.ToString(dr["Num"]);
            edt.TypeName = Convert.ToString(dr["TypeName"]);
            edt.Parent = Convert.ToString(dr["Parent"]);
            return edt;
        }

        public bool Del(string num)
        {
            base.Open();
            try
            {
                if (SqlHelper.ExecuteNonQuery(base.oConn, CommandType.Text, "DELETE FROM YingInfoType where num='" + num + "'") == 1)
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

        public YingInfoTypeDT GetByNum(string s)
        {
            return (YingInfoTypeDT) this.GetOneItem(s);
        }

        public DataTable GetList()
        {
            return this.RunSqlString("SELECT id, Num, TypeName, Parent, Has_Sub FROM YingInfoType ORDER BY Num", "data");
        }

        public DataTable GetList(string parentid)
        {
            return this.RunSqlString("SELECT id, Num, TypeName, Parent, Has_Sub FROM YingInfoType where [Parent]='" + parentid + "'  ORDER BY Num", "data");
        }

        public YingInfoTypeDT GetOneDT(int id)
        {
            return (YingInfoTypeDT) this.GetOneItem(id);
        }

        public virtual object GetOneItem(string num)
        {
            object obj2 = null;
            SqlDataReader dr = null;
            base.Open();
            try
            {
                dr = this.RunSqlString("Select * from YingInfoType where num='" + num + "'");
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
            YingInfoTypeDT edt = (YingInfoTypeDT) obj;
            return new SqlParameter[] { base.MakeInParam("@Has_Sub", SqlDbType.Bit, 1, edt.Has_Sub), base.MakeInParam("@id", SqlDbType.Int, 4, edt.id), base.MakeInParam("@Num", SqlDbType.NVarChar, 240, edt.Num), base.MakeInParam("@TypeName", SqlDbType.NVarChar, 300, edt.TypeName), base.MakeInParam("@Parent", SqlDbType.NVarChar, 240, edt.Parent) };
        }

        public bool ISHasDel(string num)
        {
            base.Open();
            try
            {
                if (this.RunSqlString("select id FROM YingInfoType where Num like '" + num + "%'", "t").Rows.Count > 1)
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
                if (this.RunSqlString("select id FROM YingInfo where InfoTypeNo like '" + num + "%'", "t").Rows.Count > 0)
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

