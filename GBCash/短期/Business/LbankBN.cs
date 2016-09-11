using System;
using System.Data;
using System.Collections;
using System.Web.UI;

using YingNet.WeiXing.STRUCTURE;
using YingNet.WeiXing.DB;
using YingNet.Common;
using YingNet.Common.Database;

namespace YingNet.WeiXing.Business
{
	/// <summary>
	/// LbankBN的摘要说明。
	/// </summary>
	public class LbankBN : BaseBusiness
	{
		private LbankDB db = null;
		/// <summary>
		/// 构造函数
		/// </summary>
		public LbankBN(Page page) : base(page)
		{
			this.db = new LbankDB(this.curDBOperater);
		}
		
		/// <summary>
		/// 构造函数
		/// </summary>
		public LbankBN(Page page, DBOperate oper) : base(page, oper)
		{
			this.db = new LbankDB(this.curDBOperater);
		}

		/// <summary>
		/// 销毁方法
		/// </summary>
		public new void Dispose ()
		{
			base.Dispose();
			if(this.db!=null)
			{
				this.db = null;
			}
		}

		/// <summary>
		/// 添加一条记录
		/// </summary>
		/// <param name="detail"></param>
		/// <returns>true 成功 false 失败</returns>
		public bool Add(LbankDT detail)
		{
			bool ret=false;
			try
			{
				ret = db.Add(detail);
			}
			catch(Exception ex)
			{
				throw ex;
			}
			finally
			{
			}
			return ret;
		}

		/// <summary>
		/// 修改一条记录
		/// </summary>
		/// <param name="detail"></param>
		/// <returns>true 成功 false 失败</returns>
		public bool Edit(LbankDT detail)
		{
			bool ret= false;
			try
			{
				ret = db.Edit(detail);
			}
			catch(Exception ex)
			{
				throw ex;
			}
			finally
			{
			}
			return ret;
		}

		/// <summary>
		/// 删除一条记录
		/// </summary>
		/// <param name="detail"></param>
		/// <returns>true 成功 false 失败</returns>
		public bool Delete(int sid)
		{
			bool ret= false;
			try
			{
				ret= db.Delete(sid);
			}
			catch(Exception ex)
			{
				throw ex;
			}
			finally
			{
			}
			return ret;
		}

		/// <summary>
		/// 获取一条记录
		/// </summary>
		public LbankDT Get(int sid)
		{
			LbankDT detail = null;
			try
			{
				detail= db.Get(sid);
			}
			catch(Exception ex)
			{
				throw ex;
			}
			finally
			{
			}
			return detail;
		}

		/// <summary>
		/// 获取记录集
		/// </summary>
		/// <returns></returns>
		public DataTable GetList()
		{
			DBFieldList = "sid,BankName,Branch,AccountName,Bsb,AccountNum,PContact,Rname1,Rship1,Rnum1,Rname2,Rship2,Rnum2,Rname3,Rship3,Rnum3,LoanSid,Other1,Other2,Other3,Other4,Other5,Other6";
			DBTable = "LBank";
			return base.CommonGetList();
		}

		/// <summary>
		///
		/// </summary>
		public void Querysid(int sid)
		{
			Filter = "sid= "+sid;
		}

		/// <summary>
		///
		/// </summary>
		public void QueryBankName(string BankName)
		{
			if(BankName!= null &&BankName.Trim()!= "")
			{
				Filter = "BankName like '%" +StringUtils.ToSQL(BankName)+ "%'";
			}
		}

		/// <summary>
		///
		/// </summary>
		public void QueryBranch(string Branch)
		{
			if(Branch!= null &&Branch.Trim()!= "")
			{
				Filter = "Branch like '%" +StringUtils.ToSQL(Branch)+ "%'";
			}
		}

		/// <summary>
		///
		/// </summary>
		public void QueryAccountName(string AccountName)
		{
			if(AccountName!= null &&AccountName.Trim()!= "")
			{
				Filter = "AccountName like '%" +StringUtils.ToSQL(AccountName)+ "%'";
			}
		}

		/// <summary>
		///
		/// </summary>
		public void QueryBsb(string Bsb)
		{
			if(Bsb!= null &&Bsb.Trim()!= "")
			{
				Filter = "Bsb like '%" +StringUtils.ToSQL(Bsb)+ "%'";
			}
		}

		/// <summary>
		///
		/// </summary>
		public void QueryAccountNum(string AccountNum)
		{
			if(AccountNum!= null &&AccountNum.Trim()!= "")
			{
				Filter = "AccountNum like '%" +StringUtils.ToSQL(AccountNum)+ "%'";
			}
		}

		/// <summary>
		///
		/// </summary>
		public void QueryPContact(string PContact)
		{
			if(PContact!= null &&PContact.Trim()!= "")
			{
				Filter = "PContact like '%" +StringUtils.ToSQL(PContact)+ "%'";
			}
		}

		/// <summary>
		///
		/// </summary>
		public void QueryRname1(string Rname1)
		{
			if(Rname1!= null &&Rname1.Trim()!= "")
			{
				Filter = "Rname1 like '%" +StringUtils.ToSQL(Rname1)+ "%'";
			}
		}

		/// <summary>
		///
		/// </summary>
		public void QueryRship1(string Rship1)
		{
			if(Rship1!= null &&Rship1.Trim()!= "")
			{
				Filter = "Rship1 like '%" +StringUtils.ToSQL(Rship1)+ "%'";
			}
		}

		/// <summary>
		///
		/// </summary>
		public void QueryRnum1(string Rnum1)
		{
			if(Rnum1!= null &&Rnum1.Trim()!= "")
			{
				Filter = "Rnum1 like '%" +StringUtils.ToSQL(Rnum1)+ "%'";
			}
		}

		/// <summary>
		///
		/// </summary>
		public void QueryRname2(string Rname2)
		{
			if(Rname2!= null &&Rname2.Trim()!= "")
			{
				Filter = "Rname2 like '%" +StringUtils.ToSQL(Rname2)+ "%'";
			}
		}

		/// <summary>
		///
		/// </summary>
		public void QueryRship2(string Rship2)
		{
			if(Rship2!= null &&Rship2.Trim()!= "")
			{
				Filter = "Rship2 like '%" +StringUtils.ToSQL(Rship2)+ "%'";
			}
		}

		/// <summary>
		///
		/// </summary>
		public void QueryRnum2(string Rnum2)
		{
			if(Rnum2!= null &&Rnum2.Trim()!= "")
			{
				Filter = "Rnum2 like '%" +StringUtils.ToSQL(Rnum2)+ "%'";
			}
		}

		/// <summary>
		///
		/// </summary>
		public void QueryRname3(string Rname3)
		{
			if(Rname3!= null &&Rname3.Trim()!= "")
			{
				Filter = "Rname3 like '%" +StringUtils.ToSQL(Rname3)+ "%'";
			}
		}

		/// <summary>
		///
		/// </summary>
		public void QueryRship3(string Rship3)
		{
			if(Rship3!= null &&Rship3.Trim()!= "")
			{
				Filter = "Rship3 like '%" +StringUtils.ToSQL(Rship3)+ "%'";
			}
		}

		/// <summary>
		///
		/// </summary>
		public void QueryRnum3(string Rnum3)
		{
			if(Rnum3!= null &&Rnum3.Trim()!= "")
			{
				Filter = "Rnum3 like '%" +StringUtils.ToSQL(Rnum3)+ "%'";
			}
		}

		/// <summary>
		///
		/// </summary>
		public void QueryLoanSid(int LoanSid)
		{
			Filter = "LoanSid= "+LoanSid;
		}

		/// <summary>
		///
		/// </summary>
		public void QueryOther1(string Other1)
		{
			if(Other1!= null &&Other1.Trim()!= "")
			{
				Filter = "Other1 like '%" +StringUtils.ToSQL(Other1)+ "%'";
			}
		}

		/// <summary>
		///
		/// </summary>
		public void QueryOther2(string Other2)
		{
			if(Other2!= null &&Other2.Trim()!= "")
			{
				Filter = "Other2 like '%" +StringUtils.ToSQL(Other2)+ "%'";
			}
		}

		/// <summary>
		///
		/// </summary>
		public void QueryOther3(string Other3)
		{
			if(Other3!= null &&Other3.Trim()!= "")
			{
				Filter = "Other3 like '%" +StringUtils.ToSQL(Other3)+ "%'";
			}
		}

		/// <summary>
		///
		/// </summary>
		public void QueryOther4(int Other4)
		{
			Filter = "Other4= "+Other4;
		}

		/// <summary>
		///
		/// </summary>
		public void QueryOther5(int Other5)
		{
			Filter = "Other5= "+Other5;
		}

		/// <summary>
		///
		/// </summary>
		public void QueryOther6(int Other6)
		{
			Filter = "Other6= "+Other6;
		}
	}
}