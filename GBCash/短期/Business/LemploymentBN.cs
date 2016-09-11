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
	/// LemploymentBN的摘要说明。
	/// </summary>
	public class LemploymentBN : BaseBusiness
	{
		private LemploymentDB db = null;
		/// <summary>
		/// 构造函数
		/// </summary>
		public LemploymentBN(Page page) : base(page)
		{
			this.db = new LemploymentDB(this.curDBOperater);
		}
		
		/// <summary>
		/// 构造函数
		/// </summary>
		public LemploymentBN(Page page, DBOperate oper) : base(page, oper)
		{
			this.db = new LemploymentDB(this.curDBOperater);
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
		public bool Add(LemploymentDT detail)
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
		public bool Edit(LemploymentDT detail)
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
		public LemploymentDT Get(int sid)
		{
			LemploymentDT detail = null;
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
			DBFieldList = "sid,EName,EAddress,ECode,ENum,EStatus,JobTitle,TimeYears,TimeMonths,TakePay,Per,NextDay,NextMonth,NextYear,LoanSid,Other1,Other2,Other3,Other4,Other5,Other6,FollowDay,FollowMonth,FollowYear,HousePaymentValue,HousePaymentCircle,OtherLenderValue,OtherLenderCircle";
			DBTable = "LEmployment";
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
		public void QueryEName(string EName)
		{
			if(EName!= null &&EName.Trim()!= "")
			{
				Filter = "EName like '%" +StringUtils.ToSQL(EName)+ "%'";
			}
		}

		/// <summary>
		///
		/// </summary>
		public void QueryEAddress(string EAddress)
		{
			if(EAddress!= null &&EAddress.Trim()!= "")
			{
				Filter = "EAddress like '%" +StringUtils.ToSQL(EAddress)+ "%'";
			}
		}

		/// <summary>
		///
		/// </summary>
		public void QueryECode(string ECode)
		{
			if(ECode!= null &&ECode.Trim()!= "")
			{
				Filter = "ECode like '%" +StringUtils.ToSQL(ECode)+ "%'";
			}
		}

		/// <summary>
		///
		/// </summary>
		public void QueryENum(string ENum)
		{
			if(ENum!= null &&ENum.Trim()!= "")
			{
				Filter = "ENum like '%" +StringUtils.ToSQL(ENum)+ "%'";
			}
		}

		/// <summary>
		///
		/// </summary>
		public void QueryEStatus(string EStatus)
		{
			if(EStatus!= null &&EStatus.Trim()!= "")
			{
				Filter = "EStatus like '%" +StringUtils.ToSQL(EStatus)+ "%'";
			}
		}

		/// <summary>
		///
		/// </summary>
		public void QueryJobTitle(string JobTitle)
		{
			if(JobTitle!= null &&JobTitle.Trim()!= "")
			{
				Filter = "JobTitle like '%" +StringUtils.ToSQL(JobTitle)+ "%'";
			}
		}

		/// <summary>
		///
		/// </summary>
		public void QueryTimeYears(int TimeYears)
		{
			Filter = "TimeYears= "+TimeYears;
		}

		/// <summary>
		///
		/// </summary>
		public void QueryTimeMonths(int TimeMonths)
		{
			Filter = "TimeMonths= "+TimeMonths;
		}

		/// <summary>
		///
		/// </summary>
		public void QueryTakePay(double TakePay)
		{
			Filter = "TakePay= "+TakePay;
		}

		/// <summary>
		///
		/// </summary>
		public void QueryPer(int Per)
		{
			Filter = "Per= "+Per;
		}

		/// <summary>
		///
		/// </summary>
		public void QueryNextDay(int NextDay)
		{
			Filter = "NextDay= "+NextDay;
		}

		/// <summary>
		///
		/// </summary>
		public void QueryNextMonth(int NextMonth)
		{
			Filter = "NextMonth= "+NextMonth;
		}

		/// <summary>
		///
		/// </summary>
		public void QueryNextYear(int NextYear)
		{
			Filter = "NextYear= "+NextYear;
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

		/// <summary>
		///
		/// </summary>
		public void QueryFollowDay(int FollowDay)
		{
			Filter = "FollowDay= "+FollowDay;
		}

		/// <summary>
		///
		/// </summary>
		public void QueryFollowMonth(int FollowMonth)
		{
			Filter = "FollowMonth= "+FollowMonth;
		}

		/// <summary>
		///
		/// </summary>
		public void QueryFollowYear(int FollowYear)
		{
			Filter = "FollowYear= "+FollowYear;
		}
	}
}