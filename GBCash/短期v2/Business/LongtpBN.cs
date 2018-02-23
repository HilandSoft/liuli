namespace YingNet.WeiXing.Business
{
    using System;
    using System.Data;
    using System.Web.UI;
    using YingNet.WeiXing.DB;
    using YingNet.WeiXing.DB.Data;

    public class LongtpBN : BaseLib
    {
        public LongtpBN(Page page) : base(page)
        {
        }

        public bool Add(LongtpDT dt)
        {
            using (LongtpDB pdb = new LongtpDB())
            {
                return pdb.Insert(dt);
            }
        }

        public int Add2(LongtpDT dt)
        {
            using (LongtpDB pdb = new LongtpDB())
            {
                return pdb.Insert2(dt);
            }
        }

        public bool Del(int id)
        {
            using (LongtpDB pdb = new LongtpDB())
            {
                return pdb.Del(id);
            }
        }

        public bool Edit(LongtpDT dt)
        {
            using (LongtpDB pdb = new LongtpDB())
            {
                return pdb.Update(dt);
            }
        }

        public DataTable GetList()
        {
            base.DBFieldList = "regdate,borrow,sid,param3,param4,param5,terms,param1,param2,timeaddress,landlord,areatel,suburb,state,postcode,restatus,unitno,street,lnumber,lstate,mastatus,worktel,mobiletel,email,gender,birth,hometel,fname,mname,sname,existing,refnumber,title,purpose";
            base.DBTable = "Longtp";
            return base.CommonGetList();
        }
    }
}

