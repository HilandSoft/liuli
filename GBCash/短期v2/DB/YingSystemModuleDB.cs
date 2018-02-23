namespace YingNet.WeiXing.DB
{
    using System;
    using System.Data;
    using System.Data.SqlClient;
    using YingNet.Common;
    using YingNet.WeiXing.DB.Data;

    public class YingSystemModuleDB : DBAccess
    {
        public override object ConvertItem(SqlDataReader dr)
        {
            YingSystemModuleDT edt = new YingSystemModuleDT();
            edt.code = Convert.ToString(dr["code"]);
            edt.name = Convert.ToString(dr["name"]);
            edt.displayname = Convert.ToString(dr["displayname"]);
            return edt;
        }

        public bool Del(string strCode)
        {
            base.Open();
            try
            {
                this.RunProc("proc_YingSystemModuleDB_Del", this.GetParameter(strCode));
            }
            catch (SqlException)
            {
                return false;
            }
            finally
            {
                base.Close();
            }
            base.Close();
            return true;
        }

        public YingSystemModuleDT GetOneDT(string strCode)
        {
            return (YingSystemModuleDT) this.GetOneItem(strCode);
        }

        public object GetOneItem(string strCode)
        {
            object obj2 = null;
            SqlDataReader dr = null;
            base.Open();
            try
            {
                dr = this.RunProc("proc_YingSystemModuleDB_GetItem", this.GetParameter(strCode));
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
            YingSystemModuleDT edt = (YingSystemModuleDT) obj;
            return new SqlParameter[] { base.MakeInParam("@code", SqlDbType.Char, 12, edt.code), base.MakeInParam("@name", SqlDbType.VarChar, 50, edt.name), base.MakeInParam("@displayname", SqlDbType.VarChar, 50, edt.displayname) };
        }

        public SqlParameter[] GetParameter(string strCode)
        {
            return new SqlParameter[] { base.MakeInParam("@code", SqlDbType.Char, 12, strCode) };
        }
    }
}

