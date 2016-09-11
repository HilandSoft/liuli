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
	/// LiniloanBN的摘要说明。
	/// </summary>
	public class LiniloanBN : BaseBusiness
	{
		private LiniloanDB db = null;
		/// <summary>
		/// 构造函数
		/// </summary>
		public LiniloanBN(Page page) : base(page)
		{
			this.db = new LiniloanDB(this.curDBOperater);
		}
		
		/// <summary>
		/// 构造函数
		/// </summary>
		public LiniloanBN(Page page, DBOperate oper) : base(page, oper)
		{
			this.db = new LiniloanDB(this.curDBOperater);
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
		public bool Add(LiniloanDT detail)
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
		
		public int AddId(LiniloanDT detail)
		{
			int ret=0;
			try
			{
				ret = db.AddId(detail);
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
		public bool Edit(LiniloanDT detail)
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
		public LiniloanDT Get(int sid)
		{
			LiniloanDT detail = null;
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
			DBFieldList = "sid,PrimaryPurpose,Loan,Term,Other1,Other2,Other3,Other4,Other5,Other6,Persid	";
			DBTable = "LIniLoan";
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
		public void QueryPrimaryPurpose(string PrimaryPurpose)
		{
			if(PrimaryPurpose!= null &&PrimaryPurpose.Trim()!= "")
			{
				Filter = "PrimaryPurpose like '%" +StringUtils.ToSQL(PrimaryPurpose)+ "%'";
			}
		}

		/// <summary>
		///
		/// </summary>
		public void QueryLoan(double Loan)
		{
			Filter = "Loan= "+Loan;
		}

		/// <summary>
		///
		/// </summary>
		public void QueryTerm(int Term)
		{
			Filter = "Term= "+Term;
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

		/// <summary>
		///
		/// </summary>
		public void QueryPersid(int Persid)
		{
			Filter = "Persid= "+Persid;
		}
	}
}