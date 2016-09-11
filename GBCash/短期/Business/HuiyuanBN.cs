/// <copyright> 英网A1999-2005 </copyright>
/// <version>1.0</version>
/// <author>季宝福</author>
/// <email>jizhe@msn.com</email>
/// <log date="2005年8月6日">创建</log>

using System;
using System.Data;
using System.Web.UI;
using YingNet.WeiXing.DB;
using YingNet.WeiXing.DB.Data;


namespace YingNet.WeiXing.Business
{
	/// <summary>
	/// DepinfoDT的摘要说明。
	/// <summary>

	public class HuiyuanBN:BaseLib
	{
		public HuiyuanBN(Page page) : base(page)
		{}

		public bool Add( HuiyuanDT dt )
		{
			using ( HuiyuanDB db = new HuiyuanDB() )
			{
				return db.Insert(dt);
			}
		}

		public int Add2( HuiyuanDT dt )
		{
			using ( HuiyuanDB db = new HuiyuanDB() )
			{
				return db.Insert2(dt);
			}
		}
		public bool Del(int id) 		{
			using ( HuiyuanDB db = new HuiyuanDB() )
			{
				return db.Del(id);
			}
		}
		public bool Edit( HuiyuanDT dt )
		{
			using ( HuiyuanDB db = new HuiyuanDB() )
			{
				return db.Update(dt);
			}
		}
		public HuiyuanDT Get( int id )
		{
			using ( HuiyuanDB db = new HuiyuanDB() )
			{
				return db.GetOneDT( id );
			}
		}
		public DataTable GetList ( ) 
		{
			DBFieldList = "H.DBirth,H.Regtime,H.IsEmployed,H.IsValid,H.id,H.TYears,H.TMonths,H.Param4,H.Param5,H.Param1,H.Param2,H.Param3,H.Mobile,H.Username,H.Password,H.State,H.Postcode,H.HTel,H.RAddress,H.SAddress,H.City,H.Email,H.Issued,H.DNumber,H.Fname,H.Lname,H.Mname,M.NoteContent as Note,M.NodeDesc as followUpHistory";
			DBTable = "Huiyuan H left join MemberLoadNote M on H.id= M.MemberID ";
			this.Order="H.Regtime desc";
			return base.CommonGetList();
		}

		public DataTable GetListJoinEmployment ( ) 
		{
			DBFieldList = "H.DBirth,H.Regtime,H.IsEmployed,H.IsValid,H.id,H.TYears,H.TMonths,H.Param4,H.Param5,H.Param1,H.Param2,H.Param3,H.Mobile,H.Username,H.Password,H.State,H.Postcode,H.HTel,H.RAddress,H.SAddress,H.City,H.Email,H.Issued,H.DNumber,H.Fname,H.Lname,H.Mname,M.NoteContent as Note,M.NodeDesc as followUpHistory";
			DBTable = "Huiyuan H join Employed E ON H.id= E.huiSid left join MemberLoadNote M on H.id= M.MemberID";
			//this.Order="H.Regtime desc";
			return base.CommonGetList();
		}
		
		public void QueryUsername( string str )
		{
			Filter="H.Username ='"+str+"'";
		}
		
		public void QueryIsValid( string str )
		{
			Filter="H.IsValid ="+str+"";
		}
		
		public void QueryNotValid( string str )
		{
			Filter="H.IsValid !="+str+"";
		}

//		public void QueryNotValidJoinEmployment( string str )
//		{
//			Filter="H.IsValid !="+str+"";
//		}
		
		public void QuerySid( string str )
		{
			Filter="H.id ="+str+"";
		}

	}
}