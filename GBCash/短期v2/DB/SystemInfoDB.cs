namespace YingNet.WeiXing.DB
{
    using System;
    using System.Data;
    using System.Data.SqlClient;
    using YingNet.Common;
    using YingNet.WeiXing.DB.Data;

    public class SystemInfoDB : DBAccess
    {
        public override object ConvertItem(SqlDataReader dr)
        {
            SystemInfoDT odt = new SystemInfoDT();
            odt.param2 = Convert.ToDouble(dr["param2"]);
            odt.lowerlimit2 = Convert.ToDouble(dr["lowerlimit2"]);
            odt.upperlimit2 = Convert.ToDouble(dr["upperlimit2"]);
            odt.param1 = Convert.ToDouble(dr["param1"]);
            odt.frequency = Convert.ToDouble(dr["frequency"]);
            odt.interest = Convert.ToDouble(dr["interest"]);
            odt.poundage = Convert.ToDouble(dr["poundage"]);
            odt.percentage = Convert.ToDouble(dr["percentage"]);
            odt.upperlimit = Convert.ToDouble(dr["upperlimit"]);
            odt.lowerlimit = Convert.ToDouble(dr["lowerlimit"]);
            odt.param3 = Convert.ToInt32(dr["param3"]);
            odt.param4 = Convert.ToInt32(dr["param4"]);
            odt.datediffw = Convert.ToInt32(dr["datediffw"]);
            odt.datedifff = Convert.ToInt32(dr["datedifff"]);
            odt.datediffm = Convert.ToInt32(dr["datediffm"]);
            odt.shortday = Convert.ToInt32(dr["shortday"]);
            odt.IsPercent = Convert.ToInt32(dr["IsPercent"]);
            odt.yanqinum = Convert.ToInt32(dr["yanqinum"]);
            odt.id = Convert.ToInt32(dr["id"]);
            odt.installment = Convert.ToInt32(dr["installment"]);
            odt.term = Convert.ToInt32(dr["term"]);
            return odt;
        }

        public SystemInfoDT GetOneDT(int id)
        {
            return (SystemInfoDT) this.GetOneItem(id);
        }

        public override SqlParameter[] GetParameter(object obj)
        {
            SystemInfoDT odt = (SystemInfoDT) obj;
            return new SqlParameter[] { 
                base.MakeInParam("@param2", SqlDbType.Float, 8, odt.param2), base.MakeInParam("@lowerlimit2", SqlDbType.Float, 8, odt.lowerlimit2), base.MakeInParam("@upperlimit2", SqlDbType.Float, 8, odt.upperlimit2), base.MakeInParam("@param1", SqlDbType.Float, 8, odt.param1), base.MakeInParam("@frequency", SqlDbType.Float, 8, odt.frequency), base.MakeInParam("@interest", SqlDbType.Float, 8, odt.interest), base.MakeInParam("@poundage", SqlDbType.Float, 8, odt.poundage), base.MakeInParam("@percentage", SqlDbType.Float, 8, odt.percentage), base.MakeInParam("@upperlimit", SqlDbType.Float, 8, odt.upperlimit), base.MakeInParam("@lowerlimit", SqlDbType.Float, 8, odt.lowerlimit), base.MakeInParam("@param3", SqlDbType.Int, 4, odt.param3), base.MakeInParam("@param4", SqlDbType.Int, 4, odt.param4), base.MakeInParam("@datediffw", SqlDbType.Int, 4, odt.datediffw), base.MakeInParam("@datedifff", SqlDbType.Int, 4, odt.datedifff), base.MakeInParam("@datediffm", SqlDbType.Int, 4, odt.datediffm), base.MakeInParam("@shortday", SqlDbType.Int, 4, odt.shortday), 
                base.MakeInParam("@IsPercent", SqlDbType.Int, 4, odt.IsPercent), base.MakeInParam("@yanqinum", SqlDbType.Int, 4, odt.yanqinum), base.MakeInParam("@id", SqlDbType.Int, 4, odt.id), base.MakeInParam("@installment", SqlDbType.Int, 4, odt.installment), base.MakeInParam("@term", SqlDbType.Int, 4, odt.term)
             };
        }
    }
}

