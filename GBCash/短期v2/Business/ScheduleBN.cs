namespace YingNet.WeiXing.Business
{
    using System;
    using System.Data;
    using System.Web.UI;
    using YingNet.WeiXing.DB;
    using YingNet.WeiXing.DB.Data;

    public class ScheduleBN : BaseLib
    {
        public ScheduleBN(Page page) : base(page)
        {
        }

        public bool Add(ScheduleDT dt)
        {
            using (ScheduleDB edb = new ScheduleDB())
            {
                return edb.Insert(dt);
            }
        }

        public bool Del(int id)
        {
            using (ScheduleDB edb = new ScheduleDB())
            {
                return edb.Del(id);
            }
        }

        public void DelByEmployedID(int employedID)
        {
            using (ScheduleDB edb = new ScheduleDB())
            {
                edb.DelByEmployedID(employedID);
            }
        }

        public void DelByHuiSid(int huiSid)
        {
            using (ScheduleDB edb = new ScheduleDB())
            {
                edb.DelByHuiSid(huiSid);
            }
        }

        public bool Edit(ScheduleDT dt)
        {
            using (ScheduleDB edb = new ScheduleDB())
            {
                return edb.Update(dt);
            }
        }

        public ScheduleDT Get(int id)
        {
            using (ScheduleDB edb = new ScheduleDB())
            {
                return edb.GetOneDT(id);
            }
        }

        public DataTable GetList()
        {
            base.DBFieldList = "Datedue,RepayTime,OperateTime,Penalty,Balance,Repaydue,Param5,Paid,Numberment,id,huiSid,IsValid,Param4,Param1,Param2,Param3";
            base.DBTable = "Schedule";
            return base.CommonGetList();
        }

        public DataTable GetListByTime()
        {
            base.DBFieldList = "Datedue,RepayTime,OperateTime,Penalty,Balance,Repaydue,Param5,Paid,Numberment,id,huiSid,IsValid,Param4,Param1,Param2,Param3";
            base.DBTable = "Schedule";
            base.Order = "Datedue asc";
            return base.CommonGetList();
        }

        public void QueryhuiSid(string str)
        {
            base.Filter = "huiSid =" + str + "";
        }

        public void QueryIsValid(string str)
        {
            base.Filter = "IsValid =" + str + "";
        }

        public void QueryNotValid(string str)
        {
            base.Filter = "IsValid !=" + str + "";
        }

        public void QueryNumberment(string str)
        {
            base.Filter = "Numberment =" + str + "";
        }

        public void QueryParam1(string str)
        {
            base.Filter = "Param1 ='" + str + "'";
        }

        public void QueryParam2(string str)
        {
            base.Filter = "Param2 ='" + str + "'";
        }
    }
}

