namespace YingNet.WeiXing.Business
{
    using System;
    using System.Data;
    using System.Web.UI;
    using YingNet.WeiXing.DB;
    using YingNet.WeiXing.DB.Data;

    public class HuiyuanBN : BaseLib
    {
        public HuiyuanBN(Page page) : base(page)
        {
        }

        public bool Add(HuiyuanDT dt)
        {
            using (HuiyuanDB ndb = new HuiyuanDB())
            {
                return ndb.Insert(dt);
            }
        }

        public int Add2(HuiyuanDT dt)
        {
            using (HuiyuanDB ndb = new HuiyuanDB())
            {
                return ndb.Insert2(dt);
            }
        }

        public bool Del(int id)
        {
            using (HuiyuanDB ndb = new HuiyuanDB())
            {
                return ndb.Del(id);
            }
        }

        public bool Edit(HuiyuanDT dt)
        {
            using (HuiyuanDB ndb = new HuiyuanDB())
            {
                return ndb.Update(dt);
            }
        }

        public HuiyuanDT Get(int id)
        {
            using (HuiyuanDB ndb = new HuiyuanDB())
            {
                return ndb.GetOneDT(id);
            }
        }

        public DataTable GetList()
        {
            base.DBFieldList = "H.DBirth,H.Regtime,H.IsEmployed,H.IsValid,H.id,H.TYears,H.TMonths,H.Param4,H.Param5,H.Param1,H.Param2,H.Param3,H.Mobile,H.Username,H.Password,H.State,H.Postcode,H.HTel,H.RAddress,H.SAddress,H.City,H.Email,H.Issued,H.DNumber,H.Fname,H.Lname,H.Mname,M.NoteContent as Note,M.NodeDesc as followUpHistory";
            base.DBTable = "Huiyuan H left join MemberLoadNote M on H.id= M.MemberID ";
            base.Order = "H.Regtime desc";
            return base.CommonGetList();
        }

        public DataTable GetListJoinEmployment()
        {
            base.DBFieldList = "H.DBirth,H.Regtime,H.IsEmployed,H.IsValid,H.id,H.TYears,H.TMonths,H.Param4,H.Param5,H.Param1,H.Param2,H.Param3,H.Mobile,H.Username,H.Password,H.State,H.Postcode,H.HTel,H.RAddress,H.SAddress,H.City,H.Email,H.Issued,H.DNumber,H.Fname,H.Lname,H.Mname,M.NoteContent as Note,M.NodeDesc as followUpHistory";
            base.DBTable = "Huiyuan H join Employed E ON H.id= E.huiSid left join MemberLoadNote M on H.id= M.MemberID";
            return base.CommonGetList();
        }

        public void QueryIsValid(string str)
        {
            base.Filter = "H.IsValid =" + str + "";
        }

        public void QueryNotValid(string str)
        {
            base.Filter = "H.IsValid !=" + str + "";
        }

        public void QuerySid(string str)
        {
            base.Filter = "H.id =" + str + "";
        }

        public void QueryUsername(string str)
        {
            base.Filter = "H.Username ='" + str + "'";
        }
    }
}

