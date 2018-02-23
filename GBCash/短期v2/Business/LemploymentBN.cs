namespace YingNet.WeiXing.Business
{
    using System;
    using System.Data;
    using System.Web.UI;
    using YingNet.Common;
    using YingNet.Common.Database;
    using YingNet.WeiXing.DB;
    using YingNet.WeiXing.STRUCTURE;

    public class LemploymentBN : BaseBusiness
    {
        private LemploymentDB db;

        public LemploymentBN(Page page) : base(page)
        {
            this.db = null;
            this.db = new LemploymentDB(base.curDBOperater);
        }

        public LemploymentBN(Page page, DBOperate oper) : base(page, oper)
        {
            this.db = null;
            this.db = new LemploymentDB(base.curDBOperater);
        }

        public bool Add(LemploymentDT detail)
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

        public bool Edit(LemploymentDT detail)
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

        public LemploymentDT Get(int sid)
        {
            LemploymentDT tdt = null;
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
            base.DBFieldList = "sid,EName,EAddress,ECode,ENum,EStatus,JobTitle,TimeYears,TimeMonths,TakePay,Per,NextDay,NextMonth,NextYear,LoanSid,Other1,Other2,Other3,Other4,Other5,Other6,FollowDay,FollowMonth,FollowYear,HousePaymentValue,HousePaymentCircle,OtherLenderValue,OtherLenderCircle";
            base.DBTable = "LEmployment";
            return base.CommonGetList();
        }

        public void QueryEAddress(string EAddress)
        {
            if ((EAddress != null) && (EAddress.Trim() != ""))
            {
                base.Filter = "EAddress like '%" + StringUtils.ToSQL(EAddress) + "%'";
            }
        }

        public void QueryECode(string ECode)
        {
            if ((ECode != null) && (ECode.Trim() != ""))
            {
                base.Filter = "ECode like '%" + StringUtils.ToSQL(ECode) + "%'";
            }
        }

        public void QueryEName(string EName)
        {
            if ((EName != null) && (EName.Trim() != ""))
            {
                base.Filter = "EName like '%" + StringUtils.ToSQL(EName) + "%'";
            }
        }

        public void QueryENum(string ENum)
        {
            if ((ENum != null) && (ENum.Trim() != ""))
            {
                base.Filter = "ENum like '%" + StringUtils.ToSQL(ENum) + "%'";
            }
        }

        public void QueryEStatus(string EStatus)
        {
            if ((EStatus != null) && (EStatus.Trim() != ""))
            {
                base.Filter = "EStatus like '%" + StringUtils.ToSQL(EStatus) + "%'";
            }
        }

        public void QueryFollowDay(int FollowDay)
        {
            base.Filter = "FollowDay= " + FollowDay;
        }

        public void QueryFollowMonth(int FollowMonth)
        {
            base.Filter = "FollowMonth= " + FollowMonth;
        }

        public void QueryFollowYear(int FollowYear)
        {
            base.Filter = "FollowYear= " + FollowYear;
        }

        public void QueryJobTitle(string JobTitle)
        {
            if ((JobTitle != null) && (JobTitle.Trim() != ""))
            {
                base.Filter = "JobTitle like '%" + StringUtils.ToSQL(JobTitle) + "%'";
            }
        }

        public void QueryLoanSid(int LoanSid)
        {
            base.Filter = "LoanSid= " + LoanSid;
        }

        public void QueryNextDay(int NextDay)
        {
            base.Filter = "NextDay= " + NextDay;
        }

        public void QueryNextMonth(int NextMonth)
        {
            base.Filter = "NextMonth= " + NextMonth;
        }

        public void QueryNextYear(int NextYear)
        {
            base.Filter = "NextYear= " + NextYear;
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

        public void QueryPer(int Per)
        {
            base.Filter = "Per= " + Per;
        }

        public void Querysid(int sid)
        {
            base.Filter = "sid= " + sid;
        }

        public void QueryTakePay(double TakePay)
        {
            base.Filter = "TakePay= " + TakePay;
        }

        public void QueryTimeMonths(int TimeMonths)
        {
            base.Filter = "TimeMonths= " + TimeMonths;
        }

        public void QueryTimeYears(int TimeYears)
        {
            base.Filter = "TimeYears= " + TimeYears;
        }
    }
}

