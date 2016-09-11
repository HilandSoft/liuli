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
	/// LresidentBN的摘要说明。
	/// </summary>
	public class LresidentBN : BaseBusiness
	{
		private LresidentDB db = null;
		/// <summary>
		/// 构造函数
		/// </summary>
		public LresidentBN(Page page) : base(page)
		{
			this.db = new LresidentDB(this.curDBOperater);
		}
		
		/// <summary>
		/// 构造函数
		/// </summary>
		public LresidentBN(Page page, DBOperate oper) : base(page, oper)
		{
			this.db = new LresidentDB(this.curDBOperater);
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
		public bool Add(LresidentDT detail)
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
		public bool Edit(LresidentDT detail)
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
		public LresidentDT Get(int sid)
		{
			LresidentDT detail = null;
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
			DBFieldList = "sid,Status,UnitNo,StreetNum,Suburb,State,Postcode,TimeYears,TimeMonths,NameAgent,TelArea,LoanSid,Other1,Other2,Other3,Other4,Other5,Other6,UnitNo1,StreetNum1,Suburb1,State1,Postcode1,TimeYears1,TimeMonths1";
			DBTable = "LResident";
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
		public void QueryStatus(string Status)
		{
			if(Status!= null &&Status.Trim()!= "")
			{
				Filter = "Status like '%" +StringUtils.ToSQL(Status)+ "%'";
			}
		}

		/// <summary>
		///
		/// </summary>
		public void QueryUnitNo(string UnitNo)
		{
			if(UnitNo!= null &&UnitNo.Trim()!= "")
			{
				Filter = "UnitNo like '%" +StringUtils.ToSQL(UnitNo)+ "%'";
			}
		}

		/// <summary>
		///
		/// </summary>
		public void QueryStreetNum(string StreetNum)
		{
			if(StreetNum!= null &&StreetNum.Trim()!= "")
			{
				Filter = "StreetNum like '%" +StringUtils.ToSQL(StreetNum)+ "%'";
			}
		}

		/// <summary>
		///
		/// </summary>
		public void QuerySuburb(string Suburb)
		{
			if(Suburb!= null &&Suburb.Trim()!= "")
			{
				Filter = "Suburb like '%" +StringUtils.ToSQL(Suburb)+ "%'";
			}
		}

		/// <summary>
		///
		/// </summary>
		public void QueryState(string State)
		{
			if(State!= null &&State.Trim()!= "")
			{
				Filter = "State like '%" +StringUtils.ToSQL(State)+ "%'";
			}
		}

		/// <summary>
		///
		/// </summary>
		public void QueryPostcode(string Postcode)
		{
			if(Postcode!= null &&Postcode.Trim()!= "")
			{
				Filter = "Postcode like '%" +StringUtils.ToSQL(Postcode)+ "%'";
			}
		}

		/// <summary>
		///
		/// </summary>
		public void QueryTimeYears(string TimeYears)
		{
			if(TimeYears!= null &&TimeYears.Trim()!= "")
			{
				Filter = "TimeYears like '%" +StringUtils.ToSQL(TimeYears)+ "%'";
			}
		}

		/// <summary>
		///
		/// </summary>
		public void QueryTimeMonths(string TimeMonths)
		{
			if(TimeMonths!= null &&TimeMonths.Trim()!= "")
			{
				Filter = "TimeMonths like '%" +StringUtils.ToSQL(TimeMonths)+ "%'";
			}
		}

		/// <summary>
		///
		/// </summary>
		public void QueryNameAgent(string NameAgent)
		{
			if(NameAgent!= null &&NameAgent.Trim()!= "")
			{
				Filter = "NameAgent like '%" +StringUtils.ToSQL(NameAgent)+ "%'";
			}
		}

		/// <summary>
		///
		/// </summary>
		public void QueryTelArea(string TelArea)
		{
			if(TelArea!= null &&TelArea.Trim()!= "")
			{
				Filter = "TelArea like '%" +StringUtils.ToSQL(TelArea)+ "%'";
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

		/// <summary>
		///
		/// </summary>
		public void QueryUnitNo1(string UnitNo1)
		{
			if(UnitNo1!= null &&UnitNo1.Trim()!= "")
			{
				Filter = "UnitNo1 like '%" +StringUtils.ToSQL(UnitNo1)+ "%'";
			}
		}

		/// <summary>
		///
		/// </summary>
		public void QueryStreetNum1(string StreetNum1)
		{
			if(StreetNum1!= null &&StreetNum1.Trim()!= "")
			{
				Filter = "StreetNum1 like '%" +StringUtils.ToSQL(StreetNum1)+ "%'";
			}
		}

		/// <summary>
		///
		/// </summary>
		public void QuerySuburb1(string Suburb1)
		{
			if(Suburb1!= null &&Suburb1.Trim()!= "")
			{
				Filter = "Suburb1 like '%" +StringUtils.ToSQL(Suburb1)+ "%'";
			}
		}

		/// <summary>
		///
		/// </summary>
		public void QueryState1(string State1)
		{
			if(State1!= null &&State1.Trim()!= "")
			{
				Filter = "State1 like '%" +StringUtils.ToSQL(State1)+ "%'";
			}
		}

		/// <summary>
		///
		/// </summary>
		public void QueryPostcode1(string Postcode1)
		{
			if(Postcode1!= null &&Postcode1.Trim()!= "")
			{
				Filter = "Postcode1 like '%" +StringUtils.ToSQL(Postcode1)+ "%'";
			}
		}

		/// <summary>
		///
		/// </summary>
		public void QueryTimeYears1(string TimeYears1)
		{
			if(TimeYears1!= null &&TimeYears1.Trim()!= "")
			{
				Filter = "TimeYears1 like '%" +StringUtils.ToSQL(TimeYears1)+ "%'";
			}
		}

		/// <summary>
		///
		/// </summary>
		public void QueryTimeMonths1(string TimeMonths1)
		{
			if(TimeMonths1!= null &&TimeMonths1.Trim()!= "")
			{
				Filter = "TimeMonths1 like '%" +StringUtils.ToSQL(TimeMonths1)+ "%'";
			}
		}
	}
}