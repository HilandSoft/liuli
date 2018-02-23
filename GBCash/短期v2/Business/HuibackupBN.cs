namespace YingNet.WeiXing.Business
{
    using System;
    using System.Data;
    using System.Web.UI;
    using YingNet.WeiXing.DB;
    using YingNet.WeiXing.DB.Data;

    public class HuibackupBN : BaseLib
    {
        public HuibackupBN(Page page) : base(page)
        {
        }

        public bool Add(HuibackupDT dt)
        {
            using (HuibackupDB pdb = new HuibackupDB())
            {
                return pdb.Insert(dt);
            }
        }

        public bool Del(int id)
        {
            using (HuibackupDB pdb = new HuibackupDB())
            {
                return pdb.Del(id);
            }
        }

        public bool Edit(HuibackupDT dt)
        {
            using (HuibackupDB pdb = new HuibackupDB())
            {
                return pdb.Update(dt);
            }
        }

        public DataTable GetList()
        {
            base.DBFieldList = "DBirth,Modtime,id,TYears,TMonths,Param4,Param5,IsEmployed,Param1,Param2,Param3,Mobile,Username,Password,State,Postcode,HTel,RAddress,SAddress,City,Email,Issued,DNumber,Fname,Lname,Mname";
            base.DBTable = "Huibackup";
            return base.CommonGetList();
        }

        public void QuerySid(string str)
        {
            base.Filter = "id =" + str + "";
        }

        public void QueryUsername(string str)
        {
            base.Filter = "Username ='" + str + "'";
        }
    }
}

