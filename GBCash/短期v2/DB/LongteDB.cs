namespace YingNet.WeiXing.DB
{
    using System;
    using System.Data;
    using System.Data.SqlClient;
    using YingNet.Common;
    using YingNet.WeiXing.DB.Data;

    public class LongteDB : DBAccess
    {
        public override object ConvertItem(SqlDataReader dr)
        {
            LongteDT edt = new LongteDT();
            edt.thome = Convert.ToDouble(dr["thome"]);
            edt.sid = Convert.ToInt32(dr["sid"]);
            edt.personsid = Convert.ToInt32(dr["personsid"]);
            edt.param5 = Convert.ToString(dr["param5"]);
            edt.tper = Convert.ToString(dr["tper"]);
            edt.param3 = Convert.ToString(dr["param3"]);
            edt.param4 = Convert.ToString(dr["param4"]);
            edt.Rnum3 = Convert.ToString(dr["Rnum3"]);
            edt.param1 = Convert.ToString(dr["param1"]);
            edt.param2 = Convert.ToString(dr["param2"]);
            edt.Rnum2 = Convert.ToString(dr["Rnum2"]);
            edt.Rname3 = Convert.ToString(dr["Rname3"]);
            edt.Rship3 = Convert.ToString(dr["Rship3"]);
            edt.Rnum1 = Convert.ToString(dr["Rnum1"]);
            edt.Rname2 = Convert.ToString(dr["Rname2"]);
            edt.Rship2 = Convert.ToString(dr["Rship2"]);
            edt.premethods = Convert.ToString(dr["premethods"]);
            edt.Rname1 = Convert.ToString(dr["Rname1"]);
            edt.Rship1 = Convert.ToString(dr["Rship1"]);
            edt.acname = Convert.ToString(dr["acname"]);
            edt.bsb = Convert.ToString(dr["bsb"]);
            edt.acnumber = Convert.ToString(dr["acnumber"]);
            edt.npayday = Convert.ToString(dr["npayday"]);
            edt.bankname = Convert.ToString(dr["bankname"]);
            edt.branch = Convert.ToString(dr["branch"]);
            edt.estatus = Convert.ToString(dr["estatus"]);
            edt.jobtitle = Convert.ToString(dr["jobtitle"]);
            edt.timeemployed = Convert.ToString(dr["timeemployed"]);
            edt.ename = Convert.ToString(dr["ename"]);
            edt.eaddress = Convert.ToString(dr["eaddress"]);
            edt.etel = Convert.ToString(dr["etel"]);
            return edt;
        }

        public LongteDT GetOneDT(int id)
        {
            return (LongteDT) this.GetOneItem(id);
        }

        public override SqlParameter[] GetParameter(object obj)
        {
            LongteDT edt = (LongteDT) obj;
            return new SqlParameter[] { 
                base.MakeInParam("@thome", SqlDbType.Float, 8, edt.thome), base.MakeInParam("@sid", SqlDbType.Int, 4, edt.sid), base.MakeInParam("@personsid", SqlDbType.Int, 4, edt.personsid), base.MakeInParam("@param5", SqlDbType.NVarChar, 0x3e8, edt.param5), base.MakeInParam("@tper", SqlDbType.NVarChar, 0x3e8, edt.tper), base.MakeInParam("@param3", SqlDbType.NVarChar, 0x3e8, edt.param3), base.MakeInParam("@param4", SqlDbType.NVarChar, 0x3e8, edt.param4), base.MakeInParam("@Rnum3", SqlDbType.NVarChar, 0x3e8, edt.Rnum3), base.MakeInParam("@param1", SqlDbType.NVarChar, 0x3e8, edt.param1), base.MakeInParam("@param2", SqlDbType.NVarChar, 0x3e8, edt.param2), base.MakeInParam("@Rnum2", SqlDbType.NVarChar, 0x3e8, edt.Rnum2), base.MakeInParam("@Rname3", SqlDbType.NVarChar, 0x3e8, edt.Rname3), base.MakeInParam("@Rship3", SqlDbType.NVarChar, 0x3e8, edt.Rship3), base.MakeInParam("@Rnum1", SqlDbType.NVarChar, 0x3e8, edt.Rnum1), base.MakeInParam("@Rname2", SqlDbType.NVarChar, 0x3e8, edt.Rname2), base.MakeInParam("@Rship2", SqlDbType.NVarChar, 0x3e8, edt.Rship2), 
                base.MakeInParam("@premethods", SqlDbType.NVarChar, 0x3e8, edt.premethods), base.MakeInParam("@Rname1", SqlDbType.NVarChar, 0x3e8, edt.Rname1), base.MakeInParam("@Rship1", SqlDbType.NVarChar, 0x3e8, edt.Rship1), base.MakeInParam("@acname", SqlDbType.NVarChar, 0x3e8, edt.acname), base.MakeInParam("@bsb", SqlDbType.NVarChar, 0x3e8, edt.bsb), base.MakeInParam("@acnumber", SqlDbType.NVarChar, 0x3e8, edt.acnumber), base.MakeInParam("@npayday", SqlDbType.NVarChar, 0x3e8, edt.npayday), base.MakeInParam("@bankname", SqlDbType.NVarChar, 0x3e8, edt.bankname), base.MakeInParam("@branch", SqlDbType.NVarChar, 0x3e8, edt.branch), base.MakeInParam("@estatus", SqlDbType.NVarChar, 0x3e8, edt.estatus), base.MakeInParam("@jobtitle", SqlDbType.NVarChar, 0x3e8, edt.jobtitle), base.MakeInParam("@timeemployed", SqlDbType.NVarChar, 0x3e8, edt.timeemployed), base.MakeInParam("@ename", SqlDbType.NVarChar, 0x3e8, edt.ename), base.MakeInParam("@eaddress", SqlDbType.NVarChar, 0xfa0, edt.eaddress), base.MakeInParam("@etel", SqlDbType.NVarChar, 0x3e8, edt.etel)
             };
        }
    }
}

