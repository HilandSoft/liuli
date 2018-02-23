namespace YingNet.WeiXing.DB
{
    using System;
    using System.Data;
    using System.Data.SqlClient;
    using YingNet.Common;
    using YingNet.WeiXing.DB.Data;

    public class InfoDB : DBAccess
    {
        public override object ConvertItem(SqlDataReader dr)
        {
            InfoDT odt = new InfoDT();
            odt.regtime = Convert.ToDateTime(dr["regtime"]);
            odt.id = Convert.ToInt32(dr["id"]);
            odt.huiSid = Convert.ToInt32(dr["huiSid"]);
            odt.isvalid = Convert.ToInt32(dr["isvalid"]);
            odt.param2 = Convert.ToString(dr["param2"]);
            odt.param3 = Convert.ToString(dr["param3"]);
            odt.Username = Convert.ToString(dr["Username"]);
            odt.type = Convert.ToString(dr["type"]);
            odt.param1 = Convert.ToString(dr["param1"]);
            return odt;
        }

        public InfoDT GetOneDT(int id)
        {
            return (InfoDT) this.GetOneItem(id);
        }

        public override SqlParameter[] GetParameter(object obj)
        {
            InfoDT odt = (InfoDT) obj;
            return new SqlParameter[] { base.MakeInParam("@regtime", SqlDbType.DateTime, 8, odt.regtime), base.MakeInParam("@id", SqlDbType.Int, 4, odt.id), base.MakeInParam("@huiSid", SqlDbType.Int, 4, odt.huiSid), base.MakeInParam("@isvalid", SqlDbType.Int, 4, odt.isvalid), base.MakeInParam("@param2", SqlDbType.NVarChar, 400, odt.param2), base.MakeInParam("@param3", SqlDbType.NVarChar, 400, odt.param3), base.MakeInParam("@Username", SqlDbType.NVarChar, 400, odt.Username), base.MakeInParam("@type", SqlDbType.NVarChar, 400, odt.type), base.MakeInParam("@param1", SqlDbType.NVarChar, 400, odt.param1) };
        }
    }
}

