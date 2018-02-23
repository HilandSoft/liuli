namespace YingNet.WeiXing.DB
{
    using System;
    using System.Data;
    using System.Data.SqlClient;
    using YingNet.Common;
    using YingNet.WeiXing.DB.Data;

    public class LongtpDB : DBAccess
    {
        public override object ConvertItem(SqlDataReader dr)
        {
            LongtpDT pdt = new LongtpDT();
            pdt.regdate = Convert.ToDateTime(dr["regdate"]);
            pdt.borrow = Convert.ToDouble(dr["borrow"]);
            pdt.sid = Convert.ToInt32(dr["sid"]);
            pdt.param3 = Convert.ToString(dr["param3"]);
            pdt.param4 = Convert.ToString(dr["param4"]);
            pdt.param5 = Convert.ToString(dr["param5"]);
            pdt.terms = Convert.ToString(dr["terms"]);
            pdt.param1 = Convert.ToString(dr["param1"]);
            pdt.param2 = Convert.ToString(dr["param2"]);
            pdt.timeaddress = Convert.ToString(dr["timeaddress"]);
            pdt.landlord = Convert.ToString(dr["landlord"]);
            pdt.areatel = Convert.ToString(dr["areatel"]);
            pdt.suburb = Convert.ToString(dr["suburb"]);
            pdt.state = Convert.ToString(dr["state"]);
            pdt.postcode = Convert.ToString(dr["postcode"]);
            pdt.restatus = Convert.ToString(dr["restatus"]);
            pdt.unitno = Convert.ToString(dr["unitno"]);
            pdt.street = Convert.ToString(dr["street"]);
            pdt.lnumber = Convert.ToString(dr["lnumber"]);
            pdt.lstate = Convert.ToString(dr["lstate"]);
            pdt.mastatus = Convert.ToString(dr["mastatus"]);
            pdt.worktel = Convert.ToString(dr["worktel"]);
            pdt.mobiletel = Convert.ToString(dr["mobiletel"]);
            pdt.email = Convert.ToString(dr["email"]);
            pdt.gender = Convert.ToString(dr["gender"]);
            pdt.birth = Convert.ToString(dr["birth"]);
            pdt.hometel = Convert.ToString(dr["hometel"]);
            pdt.fname = Convert.ToString(dr["fname"]);
            pdt.mname = Convert.ToString(dr["mname"]);
            pdt.sname = Convert.ToString(dr["sname"]);
            pdt.existing = Convert.ToString(dr["existing"]);
            pdt.refnumber = Convert.ToString(dr["refnumber"]);
            pdt.title = Convert.ToString(dr["title"]);
            pdt.purpose = Convert.ToString(dr["purpose"]);
            return pdt;
        }

        public LongtpDT GetOneDT(int id)
        {
            return (LongtpDT) this.GetOneItem(id);
        }

        public override SqlParameter[] GetParameter(object obj)
        {
            LongtpDT pdt = (LongtpDT) obj;
            return new SqlParameter[] { 
                base.MakeInParam("@regdate", SqlDbType.DateTime, 8, pdt.regdate), base.MakeInParam("@borrow", SqlDbType.Float, 8, pdt.borrow), base.MakeInParam("@sid", SqlDbType.Int, 4, pdt.sid), base.MakeInParam("@param3", SqlDbType.NVarChar, 0x3e8, pdt.param3), base.MakeInParam("@param4", SqlDbType.NVarChar, 0x3e8, pdt.param4), base.MakeInParam("@param5", SqlDbType.NVarChar, 0x3e8, pdt.param5), base.MakeInParam("@terms", SqlDbType.NVarChar, 0x3e8, pdt.terms), base.MakeInParam("@param1", SqlDbType.NVarChar, 0x3e8, pdt.param1), base.MakeInParam("@param2", SqlDbType.NVarChar, 0x3e8, pdt.param2), base.MakeInParam("@timeaddress", SqlDbType.NVarChar, 0x3e8, pdt.timeaddress), base.MakeInParam("@landlord", SqlDbType.NVarChar, 0x3e8, pdt.landlord), base.MakeInParam("@areatel", SqlDbType.NVarChar, 0x3e8, pdt.areatel), base.MakeInParam("@suburb", SqlDbType.NVarChar, 0x3e8, pdt.suburb), base.MakeInParam("@state", SqlDbType.NVarChar, 0x3e8, pdt.state), base.MakeInParam("@postcode", SqlDbType.NVarChar, 0x3e8, pdt.postcode), base.MakeInParam("@restatus", SqlDbType.NVarChar, 0x3e8, pdt.restatus), 
                base.MakeInParam("@unitno", SqlDbType.NVarChar, 0x3e8, pdt.unitno), base.MakeInParam("@street", SqlDbType.NVarChar, 0x3e8, pdt.street), base.MakeInParam("@lnumber", SqlDbType.NVarChar, 0x3e8, pdt.lnumber), base.MakeInParam("@lstate", SqlDbType.NVarChar, 0x3e8, pdt.lstate), base.MakeInParam("@mastatus", SqlDbType.NVarChar, 0x3e8, pdt.mastatus), base.MakeInParam("@worktel", SqlDbType.NVarChar, 0x3e8, pdt.worktel), base.MakeInParam("@mobiletel", SqlDbType.NVarChar, 0x3e8, pdt.mobiletel), base.MakeInParam("@email", SqlDbType.NVarChar, 0x3e8, pdt.email), base.MakeInParam("@gender", SqlDbType.NVarChar, 0x3e8, pdt.gender), base.MakeInParam("@birth", SqlDbType.NVarChar, 0x3e8, pdt.birth), base.MakeInParam("@hometel", SqlDbType.NVarChar, 0x3e8, pdt.hometel), base.MakeInParam("@fname", SqlDbType.NVarChar, 0x3e8, pdt.fname), base.MakeInParam("@mname", SqlDbType.NVarChar, 0x3e8, pdt.mname), base.MakeInParam("@sname", SqlDbType.NVarChar, 0x3e8, pdt.sname), base.MakeInParam("@existing", SqlDbType.NVarChar, 0x3e8, pdt.existing), base.MakeInParam("@refnumber", SqlDbType.NVarChar, 0xfa0, pdt.refnumber), 
                base.MakeInParam("@title", SqlDbType.NVarChar, 0x3e8, pdt.title), base.MakeInParam("@purpose", SqlDbType.Text, 0x10, pdt.purpose)
             };
        }

        public int Insert2(object ob)
        {
            int num = -1;
            try
            {
                num = Convert.ToInt32(SqlHelper.ExecuteDataset(Config.DataSource, CommandType.StoredProcedure, "proc_LongtpDB_Insert2", this.GetParameter(ob)).Tables[0].Rows[0][0]);
            }
            catch (Exception exception)
            {
                throw exception;
            }
            return num;
        }
    }
}

