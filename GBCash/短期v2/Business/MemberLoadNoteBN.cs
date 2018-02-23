namespace YingNet.WeiXing.Business
{
    using System;
    using System.Web.UI;
    using YingNet.WeiXing.DB;
    using YingNet.WeiXing.DB.Data;

    public class MemberLoadNoteBN : BaseLib
    {
        public MemberLoadNoteBN(Page page) : base(page)
        {
        }

        public bool Add(MemberLoadNoteDT dt)
        {
            using (MemberLoadNoteDB edb = new MemberLoadNoteDB())
            {
                edb.Insert(dt);
                return true;
            }
        }

        public bool Edit(MemberLoadNoteDT dt)
        {
            using (MemberLoadNoteDB edb = new MemberLoadNoteDB())
            {
                return edb.Update(dt);
            }
        }

        public MemberLoadNoteDT Get(int noteID)
        {
            using (MemberLoadNoteDB edb = new MemberLoadNoteDB())
            {
                return edb.GetOneItem(noteID);
            }
        }

        public MemberLoadNoteDT GetByMemberID(int memberID)
        {
            using (MemberLoadNoteDB edb = new MemberLoadNoteDB())
            {
                return edb.GetOneItemByMemberID(memberID);
            }
        }
    }
}

