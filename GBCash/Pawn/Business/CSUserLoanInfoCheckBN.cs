using System;
using System.Data;
using System.Web.UI;
using YingNet.WeiXing.DB;
using YingNet.WeiXing.DB.Data;

namespace YingNet.WeiXing.Business
{
	/// <summary>
	/// CSUserLoanInfoCheckBN 的摘要说明。
	/// </summary>
	public class CSUserLoanInfoCheckBN:BaseLib
	{
		public CSUserLoanInfoCheckBN(Page page): base(page)
		{
			//
			// TODO: 在此处添加构造函数逻辑
			//
		}
		
		public bool Add( CSUserLoanInfoCheckDT dt )
		{
			using ( CSUserLoanInfoCheckDB db = new CSUserLoanInfoCheckDB() )
			{
				return db.Insert(dt);
			}
		}

		public bool Del(int id) 		
		{
			using ( CSUserLoanInfoCheckDB db = new CSUserLoanInfoCheckDB() )
			{
				return db.Del(id,true,"InfoID");
			}
		}
		public bool Edit( CSUserLoanInfoCheckDT dt )
		{
			using ( CSUserLoanInfoCheckDB db = new CSUserLoanInfoCheckDB() )
			{
				return db.Update(dt);
			}
		}
		public CSUserLoanInfoCheckDT Get( int id )
		{
			using ( CSUserLoanInfoCheckDB db = new CSUserLoanInfoCheckDB() )
			{
				return db.GetOneItem( id ,"ProcessID") as CSUserLoanInfoCheckDT;
			}
		}
		
		public DataTable GetList ( ) 
		{
			DBFieldList = "*";
			DBTable = "cs_UserLoanInfoCheck";
			this.Order="ProcessID desc";
			return base.CommonGetList();
		}
		
//		/// <summary>
//		/// 获取某一用户最新的一次验证信息
//		/// </summary>
//		/// <param name="userID"></param>
//		/// <returns></returns>
//		public CSUserLoanInfoCheckDT GetLastest(int userID,UserLoanTypes loanType)
//		{
//			this.CleanStatus();
//			this.Filter = string.Format(" UserLoanType={0} ",(int)loanType);
//			this.Filter = String.Format(" UserID={0} ", userID);
//			DataTable table = GetList();
//			if(table!=null&& table.Rows.Count>0)
//			{
//				//return null;
//			}
//			else
//			{
//				return null;
//			}
//		}
	}
}
