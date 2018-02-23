namespace YingNet.WeiXing.DB
{
    using System;
    using System.Collections;
    using System.Data;
    using System.Data.SqlClient;
    using System.IO;
    using System.Runtime.Serialization.Formatters.Binary;
    using YingNet.Common;
    using YingNet.WeiXing.DB.Data;

    public class YingSystemUserDB : DBAccess
    {
        public override object ConvertItem(SqlDataReader dr)
        {
            YingSystemUserDT rdt = new YingSystemUserDT();
            try
            {
                rdt.permit = (Hashtable) this.ReadData((byte[]) dr["permit"]);
            }
            catch
            {
                rdt.permit = new Hashtable();
            }
            rdt.isactive = Convert.ToBoolean(dr["isactive"]);
            rdt.id = Convert.ToInt32(dr["id"]);
            rdt.account = Convert.ToString(dr["account"]);
            rdt.password = Convert.ToString(dr["password"]);
            rdt.name = Convert.ToString(dr["name"]);
            rdt.deptpermit = Convert.ToString(dr["deptpermit"]);
            return rdt;
        }

        public YingSystemUserDT GetOneDT(int id)
        {
            return (YingSystemUserDT) this.GetOneItem(id);
        }

        public override SqlParameter[] GetParameter(object obj)
        {
            YingSystemUserDT rdt = (YingSystemUserDT) obj;
            return new SqlParameter[] { base.MakeInParam("@permit", SqlDbType.Binary, 0x1388, this.SaveData(rdt.permit)), base.MakeInParam("@isactive", SqlDbType.Bit, 1, rdt.isactive), base.MakeInParam("@id", SqlDbType.Int, 4, rdt.id), base.MakeInParam("@account", SqlDbType.VarChar, 50, rdt.account), base.MakeInParam("@password", SqlDbType.VarChar, 150, rdt.password), base.MakeInParam("@name", SqlDbType.VarChar, 50, rdt.name), base.MakeInParam("@deptpermit", SqlDbType.VarChar, 120, rdt.deptpermit) };
        }

        public SqlParameter[] GetParameter(string strAccount, string strPassword)
        {
            return new SqlParameter[] { base.MakeInParam("@account", SqlDbType.VarChar, 50, strAccount), base.MakeInParam("@password", SqlDbType.VarChar, 150, strPassword) };
        }

        public SqlParameter[] GetParameter(int id, string strAccount, string strPassword)
        {
            return new SqlParameter[] { base.MakeInParam("@account", SqlDbType.VarChar, 50, strAccount), base.MakeInParam("@password", SqlDbType.VarChar, 150, strPassword), base.MakeInParam("@id", SqlDbType.Int, 4, id) };
        }

        public virtual YingSystemUserDT Login(string strAccount, string strPassword)
        {
            YingSystemUserDT rdt = null;
            SqlDataReader dr = null;
            base.Open();
            try
            {
                dr = this.RunProc("proc_YingSystemUserDB_Login", this.GetParameter(strAccount, strPassword));
                if (dr.Read())
                {
                    rdt = (YingSystemUserDT) this.ConvertItem(dr);
                }
                else
                {
                    rdt = null;
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
            return rdt;
        }

        public object ReadData(byte[] bData)
        {
            MemoryStream serializationStream = null;
            BinaryFormatter formatter = null;
            object obj2 = null;
            try
            {
                serializationStream = new MemoryStream(bData);
                obj2 = new BinaryFormatter().Deserialize(serializationStream);
                serializationStream.Close();
                formatter = null;
                return obj2;
            }
            catch (Exception)
            {
                if (serializationStream != null)
                {
                    serializationStream.Close();
                }
                if (formatter != null)
                {
                    formatter = null;
                }
                return null;
            }
        }

        public byte[] SaveData(object objName)
        {
            byte[] buffer = null;
            BinaryFormatter formatter = null;
            MemoryStream serializationStream = new MemoryStream();
            try
            {
                new BinaryFormatter().Serialize(serializationStream, objName);
                formatter = null;
                buffer = serializationStream.ToArray();
                serializationStream.Close();
                return buffer;
            }
            catch (Exception)
            {
                if (formatter != null)
                {
                    formatter = null;
                }
                if (serializationStream != null)
                {
                    serializationStream.Close();
                }
                return null;
            }
        }

        public virtual YingSystemUserDT Update(int id, string strAccount, string strPassword)
        {
            YingSystemUserDT rdt = null;
            SqlDataReader dr = null;
            base.Open();
            try
            {
                dr = this.RunProc("proc_YingSystemUserDB_UpdatePass", this.GetParameter(id, strAccount, strPassword));
                if (dr.Read())
                {
                    rdt = (YingSystemUserDT) this.ConvertItem(dr);
                }
                else
                {
                    rdt = null;
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
            return rdt;
        }
    }
}

