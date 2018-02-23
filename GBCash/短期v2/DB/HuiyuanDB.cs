namespace YingNet.WeiXing.DB
{
    using System;
    using System.Data;
    using System.Data.SqlClient;
    using YingNet.Common;
    using YingNet.WeiXing.DB.Data;

    public class HuiyuanDB : DBAccess
    {
        public override object ConvertItem(SqlDataReader dr)
        {
            HuiyuanDT ndt = new HuiyuanDT();
            ndt.DBirth = Convert.ToDateTime(dr["DBirth"]);
            ndt.Regtime = Convert.ToDateTime(dr["Regtime"]);
            ndt.IsEmployed = Convert.ToInt32(dr["IsEmployed"]);
            ndt.IsValid = Convert.ToInt32(dr["IsValid"]);
            ndt.id = Convert.ToInt32(dr["id"]);
            ndt.TYears = Convert.ToInt32(dr["TYears"]);
            ndt.TMonths = Convert.ToInt32(dr["TMonths"]);
            ndt.Param4 = Convert.ToString(dr["Param4"]);
            ndt.Param5 = Convert.ToString(dr["Param5"]);
            ndt.Param1 = Convert.ToString(dr["Param1"]);
            ndt.Param2 = Convert.ToString(dr["Param2"]);
            ndt.Param3 = Convert.ToString(dr["Param3"]);
            ndt.Mobile = Convert.ToString(dr["Mobile"]);
            ndt.Username = Convert.ToString(dr["Username"]);
            ndt.Password = Convert.ToString(dr["Password"]);
            ndt.State = Convert.ToString(dr["State"]);
            ndt.Postcode = Convert.ToString(dr["Postcode"]);
            ndt.HTel = Convert.ToString(dr["HTel"]);
            ndt.RAddress = Convert.ToString(dr["RAddress"]);
            ndt.SAddress = Convert.ToString(dr["SAddress"]);
            ndt.City = Convert.ToString(dr["City"]);
            ndt.Email = Convert.ToString(dr["Email"]);
            ndt.Issued = Convert.ToString(dr["Issued"]);
            ndt.DNumber = Convert.ToString(dr["DNumber"]);
            ndt.Fname = Convert.ToString(dr["Fname"]);
            ndt.Lname = Convert.ToString(dr["Lname"]);
            ndt.Mname = Convert.ToString(dr["Mname"]);
            if (!Convert.IsDBNull(dr["NoExtensionTiped"]))
            {
                ndt.NoExtensionTiped = Convert.ToInt32(dr["NoExtensionTiped"]);
            }
            return ndt;
        }

        public HuiyuanDT GetOneDT(int id)
        {
            return (HuiyuanDT) this.GetOneItem(id);
        }

        public override SqlParameter[] GetParameter(object obj)
        {
            HuiyuanDT ndt = (HuiyuanDT) obj;
            return new SqlParameter[] { 
                base.MakeInParam("@DBirth", SqlDbType.DateTime, 8, ndt.DBirth), base.MakeInParam("@Regtime", SqlDbType.DateTime, 8, ndt.Regtime), base.MakeInParam("@IsEmployed", SqlDbType.Int, 4, ndt.IsEmployed), base.MakeInParam("@IsValid", SqlDbType.Int, 4, ndt.IsValid), base.MakeInParam("@id", SqlDbType.Int, 4, ndt.id), base.MakeInParam("@TYears", SqlDbType.Int, 4, ndt.TYears), base.MakeInParam("@TMonths", SqlDbType.Int, 4, ndt.TMonths), base.MakeInParam("@Param4", SqlDbType.NVarChar, 400, ndt.Param4), base.MakeInParam("@Param5", SqlDbType.NVarChar, 400, ndt.Param5), base.MakeInParam("@Param1", SqlDbType.NVarChar, 400, ndt.Param1), base.MakeInParam("@Param2", SqlDbType.NVarChar, 400, ndt.Param2), base.MakeInParam("@Param3", SqlDbType.NVarChar, 400, ndt.Param3), base.MakeInParam("@Mobile", SqlDbType.NVarChar, 400, ndt.Mobile), base.MakeInParam("@Username", SqlDbType.NVarChar, 400, ndt.Username), base.MakeInParam("@Password", SqlDbType.NVarChar, 400, ndt.Password), base.MakeInParam("@State", SqlDbType.NVarChar, 400, ndt.State), 
                base.MakeInParam("@Postcode", SqlDbType.NVarChar, 400, ndt.Postcode), base.MakeInParam("@HTel", SqlDbType.NVarChar, 400, ndt.HTel), base.MakeInParam("@RAddress", SqlDbType.NVarChar, 400, ndt.RAddress), base.MakeInParam("@SAddress", SqlDbType.NVarChar, 400, ndt.SAddress), base.MakeInParam("@City", SqlDbType.NVarChar, 400, ndt.City), base.MakeInParam("@Email", SqlDbType.NVarChar, 400, ndt.Email), base.MakeInParam("@Issued", SqlDbType.NVarChar, 400, ndt.Issued), base.MakeInParam("@DNumber", SqlDbType.NVarChar, 400, ndt.DNumber), base.MakeInParam("@Fname", SqlDbType.NVarChar, 400, ndt.Fname), base.MakeInParam("@Lname", SqlDbType.NVarChar, 400, ndt.Lname), base.MakeInParam("@Mname", SqlDbType.NVarChar, 400, ndt.Mname), base.MakeInParam("@NoExtensionTiped", SqlDbType.Int, 4, ndt.NoExtensionTiped)
             };
        }

        public int Insert2(object ob)
        {
            int num = -1;
            try
            {
                num = Convert.ToInt32(SqlHelper.ExecuteDataset(Config.DataSource, CommandType.StoredProcedure, "proc_HuiyuanDB_Insert2", this.GetParameter(ob)).Tables[0].Rows[0][0]);
            }
            catch (Exception exception)
            {
                throw exception;
            }
            return num;
        }
    }
}

