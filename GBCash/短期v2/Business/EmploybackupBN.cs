namespace YingNet.WeiXing.Business
{
    using System;
    using System.Data;
    using System.Web.UI;
    using YingNet.WeiXing.DB;
    using YingNet.WeiXing.DB.Data;

    public class EmploybackupBN : BaseLib
    {
        public EmploybackupBN(Page page) : base(page)
        {
        }

        public bool Add(EmploybackupDT dt)
        {
            using (EmploybackupDB pdb = new EmploybackupDB())
            {
                return pdb.Insert(dt);
            }
        }

        public bool Del(int id)
        {
            using (EmploybackupDB pdb = new EmploybackupDB())
            {
                return pdb.Del(id);
            }
        }

        public bool Edit(EmploybackupDT dt)
        {
            using (EmploybackupDB pdb = new EmploybackupDB())
            {
                return pdb.Update(dt);
            }
        }

        public DataTable GetList()
        {
            base.DBFieldList = "ModTime,Frequency,IsEmployed,huiSid,NDayMM,NDayDD,NDayYY,id,TYears,TMonths,MIncome,Wpaid,huiName,Employer,EAddress,EPhone";
            base.DBTable = "Employbackup";
            return base.CommonGetList();
        }

        public void QueryHuisid(string str)
        {
            base.Filter = "huiSid =" + str + "";
        }

        public void Querysid(string str)
        {
            base.Filter = "id =" + str + "";
        }
    }
}

