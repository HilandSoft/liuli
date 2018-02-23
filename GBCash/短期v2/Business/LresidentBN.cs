namespace YingNet.WeiXing.Business
{
    using System;
    using System.Data;
    using System.Web.UI;
    using YingNet.Common;
    using YingNet.Common.Database;
    using YingNet.WeiXing.DB;
    using YingNet.WeiXing.STRUCTURE;

    public class LresidentBN : BaseBusiness
    {
        private LresidentDB db;

        public LresidentBN(Page page) : base(page)
        {
            this.db = null;
            this.db = new LresidentDB(base.curDBOperater);
        }

        public LresidentBN(Page page, DBOperate oper) : base(page, oper)
        {
            this.db = null;
            this.db = new LresidentDB(base.curDBOperater);
        }

        public bool Add(LresidentDT detail)
        {
            bool flag = false;
            try
            {
                try
                {
                    flag = this.db.Add(detail);
                }
                catch (Exception exception)
                {
                    throw exception;
                }
            }
            finally
            {
            }
            return flag;
        }

        public bool Delete(int sid)
        {
            bool flag = false;
            try
            {
                try
                {
                    flag = this.db.Delete(sid);
                }
                catch (Exception exception)
                {
                    throw exception;
                }
            }
            finally
            {
            }
            return flag;
        }

        public void Dispose()
        {
            base.Dispose();
            if (this.db != null)
            {
                this.db = null;
            }
        }

        public bool Edit(LresidentDT detail)
        {
            bool flag = false;
            try
            {
                try
                {
                    flag = this.db.Edit(detail);
                }
                catch (Exception exception)
                {
                    throw exception;
                }
            }
            finally
            {
            }
            return flag;
        }

        public LresidentDT Get(int sid)
        {
            LresidentDT tdt = null;
            try
            {
                try
                {
                    tdt = this.db.Get(sid);
                }
                catch (Exception exception)
                {
                    throw exception;
                }
            }
            finally
            {
            }
            return tdt;
        }

        public DataTable GetList()
        {
            base.DBFieldList = "sid,Status,UnitNo,StreetNum,Suburb,State,Postcode,TimeYears,TimeMonths,NameAgent,TelArea,LoanSid,Other1,Other2,Other3,Other4,Other5,Other6,UnitNo1,StreetNum1,Suburb1,State1,Postcode1,TimeYears1,TimeMonths1";
            base.DBTable = "LResident";
            return base.CommonGetList();
        }

        public void QueryLoanSid(int LoanSid)
        {
            base.Filter = "LoanSid= " + LoanSid;
        }

        public void QueryNameAgent(string NameAgent)
        {
            if ((NameAgent != null) && (NameAgent.Trim() != ""))
            {
                base.Filter = "NameAgent like '%" + StringUtils.ToSQL(NameAgent) + "%'";
            }
        }

        public void QueryOther1(string Other1)
        {
            if ((Other1 != null) && (Other1.Trim() != ""))
            {
                base.Filter = "Other1 like '%" + StringUtils.ToSQL(Other1) + "%'";
            }
        }

        public void QueryOther2(string Other2)
        {
            if ((Other2 != null) && (Other2.Trim() != ""))
            {
                base.Filter = "Other2 like '%" + StringUtils.ToSQL(Other2) + "%'";
            }
        }

        public void QueryOther3(string Other3)
        {
            if ((Other3 != null) && (Other3.Trim() != ""))
            {
                base.Filter = "Other3 like '%" + StringUtils.ToSQL(Other3) + "%'";
            }
        }

        public void QueryOther4(int Other4)
        {
            base.Filter = "Other4= " + Other4;
        }

        public void QueryOther5(int Other5)
        {
            base.Filter = "Other5= " + Other5;
        }

        public void QueryOther6(int Other6)
        {
            base.Filter = "Other6= " + Other6;
        }

        public void QueryPostcode(string Postcode)
        {
            if ((Postcode != null) && (Postcode.Trim() != ""))
            {
                base.Filter = "Postcode like '%" + StringUtils.ToSQL(Postcode) + "%'";
            }
        }

        public void QueryPostcode1(string Postcode1)
        {
            if ((Postcode1 != null) && (Postcode1.Trim() != ""))
            {
                base.Filter = "Postcode1 like '%" + StringUtils.ToSQL(Postcode1) + "%'";
            }
        }

        public void Querysid(int sid)
        {
            base.Filter = "sid= " + sid;
        }

        public void QueryState(string State)
        {
            if ((State != null) && (State.Trim() != ""))
            {
                base.Filter = "State like '%" + StringUtils.ToSQL(State) + "%'";
            }
        }

        public void QueryState1(string State1)
        {
            if ((State1 != null) && (State1.Trim() != ""))
            {
                base.Filter = "State1 like '%" + StringUtils.ToSQL(State1) + "%'";
            }
        }

        public void QueryStatus(string Status)
        {
            if ((Status != null) && (Status.Trim() != ""))
            {
                base.Filter = "Status like '%" + StringUtils.ToSQL(Status) + "%'";
            }
        }

        public void QueryStreetNum(string StreetNum)
        {
            if ((StreetNum != null) && (StreetNum.Trim() != ""))
            {
                base.Filter = "StreetNum like '%" + StringUtils.ToSQL(StreetNum) + "%'";
            }
        }

        public void QueryStreetNum1(string StreetNum1)
        {
            if ((StreetNum1 != null) && (StreetNum1.Trim() != ""))
            {
                base.Filter = "StreetNum1 like '%" + StringUtils.ToSQL(StreetNum1) + "%'";
            }
        }

        public void QuerySuburb(string Suburb)
        {
            if ((Suburb != null) && (Suburb.Trim() != ""))
            {
                base.Filter = "Suburb like '%" + StringUtils.ToSQL(Suburb) + "%'";
            }
        }

        public void QuerySuburb1(string Suburb1)
        {
            if ((Suburb1 != null) && (Suburb1.Trim() != ""))
            {
                base.Filter = "Suburb1 like '%" + StringUtils.ToSQL(Suburb1) + "%'";
            }
        }

        public void QueryTelArea(string TelArea)
        {
            if ((TelArea != null) && (TelArea.Trim() != ""))
            {
                base.Filter = "TelArea like '%" + StringUtils.ToSQL(TelArea) + "%'";
            }
        }

        public void QueryTimeMonths(string TimeMonths)
        {
            if ((TimeMonths != null) && (TimeMonths.Trim() != ""))
            {
                base.Filter = "TimeMonths like '%" + StringUtils.ToSQL(TimeMonths) + "%'";
            }
        }

        public void QueryTimeMonths1(string TimeMonths1)
        {
            if ((TimeMonths1 != null) && (TimeMonths1.Trim() != ""))
            {
                base.Filter = "TimeMonths1 like '%" + StringUtils.ToSQL(TimeMonths1) + "%'";
            }
        }

        public void QueryTimeYears(string TimeYears)
        {
            if ((TimeYears != null) && (TimeYears.Trim() != ""))
            {
                base.Filter = "TimeYears like '%" + StringUtils.ToSQL(TimeYears) + "%'";
            }
        }

        public void QueryTimeYears1(string TimeYears1)
        {
            if ((TimeYears1 != null) && (TimeYears1.Trim() != ""))
            {
                base.Filter = "TimeYears1 like '%" + StringUtils.ToSQL(TimeYears1) + "%'";
            }
        }

        public void QueryUnitNo(string UnitNo)
        {
            if ((UnitNo != null) && (UnitNo.Trim() != ""))
            {
                base.Filter = "UnitNo like '%" + StringUtils.ToSQL(UnitNo) + "%'";
            }
        }

        public void QueryUnitNo1(string UnitNo1)
        {
            if ((UnitNo1 != null) && (UnitNo1.Trim() != ""))
            {
                base.Filter = "UnitNo1 like '%" + StringUtils.ToSQL(UnitNo1) + "%'";
            }
        }
    }
}

