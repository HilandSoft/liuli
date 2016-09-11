using System;
using System.Data;
using System.Web.UI;
using YingNet.WeiXing.DB;
using YingNet.WeiXing.DB.Data;

namespace YingNet.WeiXing.Business
{
	/// <summary>
	/// MemberLoadNoteBN 的摘要说明。
	/// </summary>
	public class MemberLoadNoteBN : BaseLib
	{
		public MemberLoadNoteBN(Page page) : base(page)
		{
			
		}

		public bool Add( MemberLoadNoteDT dt )
		{
			using ( MemberLoadNoteDB db = new MemberLoadNoteDB() )
			{
				db.Insert(dt);
				return true;
			}
		}

		public bool Edit( MemberLoadNoteDT dt )
		{
			using ( MemberLoadNoteDB db = new MemberLoadNoteDB() )
			{
				return db.Update(dt);
			}
		}

		public MemberLoadNoteDT Get( int noteID )
		{
			using ( MemberLoadNoteDB db = new MemberLoadNoteDB() )
			{
				return db.GetOneItem( noteID );
			}
		}

		public MemberLoadNoteDT GetByMemberID( int memberID )
		{
			using ( MemberLoadNoteDB db = new MemberLoadNoteDB() )
			{
				return db.GetOneItemByMemberID( memberID );
			}
		}
	}
}
