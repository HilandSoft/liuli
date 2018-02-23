namespace YingNet.WeiXing.DB
{
    using System;
    using System.Data;
    using System.Data.SqlClient;
    using YingNet.Common;
    using YingNet.WeiXing.DB.Data;

    public class ScheduleDB : DBAccess
    {
        public override object ConvertItem(SqlDataReader dr)
        {
            ScheduleDT edt = new ScheduleDT();
            edt.Datedue = Convert.ToDateTime(dr["Datedue"]);
            edt.RepayTime = Convert.ToDateTime(dr["RepayTime"]);
            edt.OperateTime = Convert.ToDateTime(dr["OperateTime"]);
            edt.Penalty = Convert.ToDouble(dr["Penalty"]);
            edt.Balance = Convert.ToDouble(dr["Balance"]);
            edt.Repaydue = Convert.ToDouble(dr["Repaydue"]);
            edt.Param5 = Convert.ToDouble(dr["Param5"]);
            edt.Paid = Convert.ToDouble(dr["Paid"]);
            edt.Numberment = Convert.ToInt32(dr["Numberment"]);
            edt.id = Convert.ToInt32(dr["id"]);
            edt.huiSid = Convert.ToInt32(dr["huiSid"]);
            edt.IsValid = Convert.ToInt32(dr["IsValid"]);
            edt.Param4 = Convert.ToString(dr["Param4"]);
            edt.Param1 = Convert.ToString(dr["Param1"]);
            edt.Param2 = Convert.ToString(dr["Param2"]);
            edt.Param3 = Convert.ToString(dr["Param3"]);
            return edt;
        }

        public void DelByEmployedID(int employedID)
        {
            string commandText = " delete from [Schedule] where Param1= '" + employedID + "'";
            base.Open();
            try
            {
                SqlHelper.ExecuteNonQuery(base.oConn, CommandType.Text, commandText);
            }
            catch (Exception exception)
            {
                throw exception;
            }
            finally
            {
                base.Close();
            }
        }

        public void DelByHuiSid(int huiSid)
        {
            string commandText = " delete from [Schedule] where huiSid= " + huiSid;
            base.Open();
            try
            {
                SqlHelper.ExecuteNonQuery(base.oConn, CommandType.Text, commandText);
            }
            catch (Exception exception)
            {
                throw exception;
            }
            finally
            {
                base.Close();
            }
        }

        public ScheduleDT GetOneDT(int id)
        {
            return (ScheduleDT) this.GetOneItem(id);
        }

        public override SqlParameter[] GetParameter(object obj)
        {
            ScheduleDT edt = (ScheduleDT) obj;
            return new SqlParameter[] { base.MakeInParam("@Datedue", SqlDbType.DateTime, 8, edt.Datedue), base.MakeInParam("@RepayTime", SqlDbType.DateTime, 8, edt.RepayTime), base.MakeInParam("@OperateTime", SqlDbType.DateTime, 8, edt.OperateTime), base.MakeInParam("@Penalty", SqlDbType.Float, 8, edt.Penalty), base.MakeInParam("@Balance", SqlDbType.Float, 8, edt.Balance), base.MakeInParam("@Repaydue", SqlDbType.Float, 8, edt.Repaydue), base.MakeInParam("@Param5", SqlDbType.Float, 8, edt.Param5), base.MakeInParam("@Paid", SqlDbType.Float, 8, edt.Paid), base.MakeInParam("@Numberment", SqlDbType.Int, 4, edt.Numberment), base.MakeInParam("@id", SqlDbType.Int, 4, edt.id), base.MakeInParam("@huiSid", SqlDbType.Int, 4, edt.huiSid), base.MakeInParam("@IsValid", SqlDbType.Int, 4, edt.IsValid), base.MakeInParam("@Param4", SqlDbType.NVarChar, 100, edt.Param4), base.MakeInParam("@Param1", SqlDbType.NVarChar, 400, edt.Param1), base.MakeInParam("@Param2", SqlDbType.NVarChar, 400, edt.Param2), base.MakeInParam("@Param3", SqlDbType.NVarChar, 400, edt.Param3) };
        }

        public SqlParameter[] GetParameter2(object obj)
        {
            ScheduleDT edt = (ScheduleDT) obj;
            return new SqlParameter[] { base.MakeInParam("@Datedue", SqlDbType.DateTime, 8, edt.Datedue), base.MakeInParam("@Penalty", SqlDbType.Float, 8, edt.Penalty), base.MakeInParam("@Balance", SqlDbType.Float, 8, edt.Balance), base.MakeInParam("@Repaydue", SqlDbType.Float, 8, edt.Repaydue), base.MakeInParam("@Param5", SqlDbType.Float, 8, edt.Param5), base.MakeInParam("@Paid", SqlDbType.Float, 8, edt.Paid), base.MakeInParam("@Numberment", SqlDbType.Int, 4, edt.Numberment), base.MakeInParam("@id", SqlDbType.Int, 4, edt.id), base.MakeInParam("@huiSid", SqlDbType.Int, 4, edt.huiSid), base.MakeInParam("@IsValid", SqlDbType.Int, 4, edt.IsValid), base.MakeInParam("@Param4", SqlDbType.NVarChar, 100, edt.Param4), base.MakeInParam("@Param1", SqlDbType.NVarChar, 400, edt.Param1), base.MakeInParam("@Param2", SqlDbType.NVarChar, 400, edt.Param2), base.MakeInParam("@Param3", SqlDbType.NVarChar, 400, edt.Param3) };
        }
    }
}

