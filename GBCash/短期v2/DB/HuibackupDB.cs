namespace YingNet.WeiXing.DB
{
    using System;
    using System.Data;
    using System.Data.SqlClient;
    using YingNet.Common;
    using YingNet.WeiXing.DB.Data;

    public class HuibackupDB : DBAccess
    {
        public override object ConvertItem(SqlDataReader dr)
        {
            HuibackupDT pdt = new HuibackupDT();
            pdt.DBirth = Convert.ToDateTime(dr["DBirth"]);
            pdt.Modtime = Convert.ToDateTime(dr["Modtime"]);
            pdt.id = Convert.ToInt32(dr["id"]);
            pdt.TYears = Convert.ToInt32(dr["TYears"]);
            pdt.TMonths = Convert.ToInt32(dr["TMonths"]);
            pdt.Param4 = Convert.ToString(dr["Param4"]);
            pdt.Param5 = Convert.ToString(dr["Param5"]);
            pdt.IsEmployed = Convert.ToString(dr["IsEmployed"]);
            pdt.Param1 = Convert.ToString(dr["Param1"]);
            pdt.Param2 = Convert.ToString(dr["Param2"]);
            pdt.Param3 = Convert.ToString(dr["Param3"]);
            pdt.Mobile = Convert.ToString(dr["Mobile"]);
            pdt.Username = Convert.ToString(dr["Username"]);
            pdt.Password = Convert.ToString(dr["Password"]);
            pdt.State = Convert.ToString(dr["State"]);
            pdt.Postcode = Convert.ToString(dr["Postcode"]);
            pdt.HTel = Convert.ToString(dr["HTel"]);
            pdt.RAddress = Convert.ToString(dr["RAddress"]);
            pdt.SAddress = Convert.ToString(dr["SAddress"]);
            pdt.City = Convert.ToString(dr["City"]);
            pdt.Email = Convert.ToString(dr["Email"]);
            pdt.Issued = Convert.ToString(dr["Issued"]);
            pdt.DNumber = Convert.ToString(dr["DNumber"]);
            pdt.Fname = Convert.ToString(dr["Fname"]);
            pdt.Lname = Convert.ToString(dr["Lname"]);
            pdt.Mname = Convert.ToString(dr["Mname"]);
            return pdt;
        }

        public HuibackupDT GetOneDT(int id)
        {
            return (HuibackupDT) this.GetOneItem(id);
        }

        public override SqlParameter[] GetParameter(object obj)
        {
            HuibackupDT pdt = (HuibackupDT) obj;
            return new SqlParameter[] { 
                base.MakeInParam("@DBirth", SqlDbType.DateTime, 8, pdt.DBirth), base.MakeInParam("@Modtime", SqlDbType.DateTime, 8, pdt.Modtime), base.MakeInParam("@id", SqlDbType.Int, 4, pdt.id), base.MakeInParam("@TYears", SqlDbType.Int, 4, pdt.TYears), base.MakeInParam("@TMonths", SqlDbType.Int, 4, pdt.TMonths), base.MakeInParam("@Param4", SqlDbType.NVarChar, 400, pdt.Param4), base.MakeInParam("@Param5", SqlDbType.NVarChar, 400, pdt.Param5), base.MakeInParam("@IsEmployed", SqlDbType.NVarChar, 400, pdt.IsEmployed), base.MakeInParam("@Param1", SqlDbType.NVarChar, 400, pdt.Param1), base.MakeInParam("@Param2", SqlDbType.NVarChar, 400, pdt.Param2), base.MakeInParam("@Param3", SqlDbType.NVarChar, 400, pdt.Param3), base.MakeInParam("@Mobile", SqlDbType.NVarChar, 400, pdt.Mobile), base.MakeInParam("@Username", SqlDbType.NVarChar, 400, pdt.Username), base.MakeInParam("@Password", SqlDbType.NVarChar, 400, pdt.Password), base.MakeInParam("@State", SqlDbType.NVarChar, 400, pdt.State), base.MakeInParam("@Postcode", SqlDbType.NVarChar, 400, pdt.Postcode), 
                base.MakeInParam("@HTel", SqlDbType.NVarChar, 400, pdt.HTel), base.MakeInParam("@RAddress", SqlDbType.NVarChar, 400, pdt.RAddress), base.MakeInParam("@SAddress", SqlDbType.NVarChar, 400, pdt.SAddress), base.MakeInParam("@City", SqlDbType.NVarChar, 400, pdt.City), base.MakeInParam("@Email", SqlDbType.NVarChar, 400, pdt.Email), base.MakeInParam("@Issued", SqlDbType.NVarChar, 400, pdt.Issued), base.MakeInParam("@DNumber", SqlDbType.NVarChar, 400, pdt.DNumber), base.MakeInParam("@Fname", SqlDbType.NVarChar, 400, pdt.Fname), base.MakeInParam("@Lname", SqlDbType.NVarChar, 400, pdt.Lname), base.MakeInParam("@Mname", SqlDbType.NVarChar, 400, pdt.Mname)
             };
        }
    }
}

