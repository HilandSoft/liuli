namespace YingNet.WeiXing.Business
{
    using System;
    using System.Data;
    using System.Web.UI;
    using YingNet.WeiXing.DB;
    using YingNet.WeiXing.DB.Data;

    public class CSProcessCenterBN : BaseLib
    {
        public CSProcessCenterBN(Page page) : base(page)
        {
        }

        public bool Add(CSProcessCenterDT dt)
        {
            using (CSProcessCenterDB rdb = new CSProcessCenterDB())
            {
                dt.CurrentStateIsAlerted = InformationAlertStates.UnRead;
                return rdb.Insert(dt);
            }
        }

        public bool Del(int id)
        {
            using (CSProcessCenterDB rdb = new CSProcessCenterDB())
            {
                return rdb.Del(id, true, "ProcessID");
            }
        }

        public bool Edit(CSProcessCenterDT dt)
        {
            using (CSProcessCenterDB rdb = new CSProcessCenterDB())
            {
                dt.CurrentStateIsAlerted = InformationAlertStates.UnRead;
                return rdb.Update(dt);
            }
        }

        public bool Edit(CSProcessCenterDT dt, bool isChangeReadStatus)
        {
            using (CSProcessCenterDB rdb = new CSProcessCenterDB())
            {
                if (isChangeReadStatus)
                {
                    dt.CurrentStateIsAlerted = InformationAlertStates.UnRead;
                }
                return rdb.Update(dt);
            }
        }

        public CSProcessCenterDT Get(int id)
        {
            using (CSProcessCenterDB rdb = new CSProcessCenterDB())
            {
                return (rdb.GetOneItem(id, "ProcessID") as CSProcessCenterDT);
            }
        }

        public DataTable GetList()
        {
            base.DBFieldList = "*";
            base.DBTable = "cs_ProcessCenter";
            if ((base.Order == null) || (base.Order == string.Empty))
            {
                base.Order = "ProcessID desc";
            }
            return base.CommonGetList();
        }

        public bool SetAlertState(int id, InformationAlertStates state)
        {
            using (CSProcessCenterDB rdb = new CSProcessCenterDB())
            {
                CSProcessCenterDT oneItem = rdb.GetOneItem(id, "ProcessID") as CSProcessCenterDT;
                oneItem.CurrentStateIsAlerted = state;
                return rdb.Update(oneItem);
            }
        }
    }
}

