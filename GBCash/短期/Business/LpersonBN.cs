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
	/// LpersonBN的摘要说明。
	/// </summary>
	public class LpersonBN : BaseBusiness
	{
		private LpersonDB db = null;
		/// <summary>
		/// 构造函数
		/// </summary>
		public LpersonBN(Page page) : base(page)
		{
			this.db = new LpersonDB(this.curDBOperater);
		}
		
		/// <summary>
		/// 构造函数
		/// </summary>
		public LpersonBN(Page page, DBOperate oper) : base(page, oper)
		{
			this.db = new LpersonDB(this.curDBOperater);
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
		public bool Add(LpersonDT detail)
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
		
		public int AddId(LpersonDT detail)
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
		public bool Edit(LpersonDT detail)
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
		public LpersonDT Get(int sid)
		{
			LpersonDT detail = null;
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
			DBFieldList = "sid,IsExist,ReferenceNum,Title,Fname,Mname,Sname,Gender,DBirth,HTelcode,HTelnum,WTelcode,WTelnum,Mobile,Email,LicNum,LicState,MaritalStatus,RegTime,LoanSid,Rname1,Rship1,Rnum1,Rname2,Rship2,Rnum2,Rname3,Rship3,Rnum3,Other1,Other2,Other3,Other4,Other5,Other6,Status,Username,Pwd";
			DBTable = "LPerson";
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
		public void QueryIsExist(int IsExist)
		{
			Filter = "IsExist= "+IsExist;
		}

		/// <summary>
		///
		/// </summary>
		public void QueryReferenceNum(string ReferenceNum)
		{
			if(ReferenceNum!= null &&ReferenceNum.Trim()!= "")
			{
				Filter = "ReferenceNum like '%" +StringUtils.ToSQL(ReferenceNum)+ "%'";
			}
		}

		/// <summary>
		///
		/// </summary>
		public void QueryTitle(string Title)
		{
			if(Title!= null &&Title.Trim()!= "")
			{
				Filter = "Title like '%" +StringUtils.ToSQL(Title)+ "%'";
			}
		}

		/// <summary>
		///
		/// </summary>
		public void QueryFname(string Fname)
		{
			if(Fname!= null &&Fname.Trim()!= "")
			{
				Filter = "Fname like '%" +StringUtils.ToSQL(Fname)+ "%'";
			}
		}

		/// <summary>
		///
		/// </summary>
		public void QueryMname(string Mname)
		{
			if(Mname!= null &&Mname.Trim()!= "")
			{
				Filter = "Mname like '%" +StringUtils.ToSQL(Mname)+ "%'";
			}
		}

		/// <summary>
		///
		/// </summary>
		public void QuerySname(string Sname)
		{
			if(Sname!= null &&Sname.Trim()!= "")
			{
				Filter = "Sname like '%" +StringUtils.ToSQL(Sname)+ "%'";
			}
		}

		/// <summary>
		///
		/// </summary>
		public void QueryGender(string Gender)
		{
			if(Gender!= null &&Gender.Trim()!= "")
			{
				Filter = "Gender like '%" +StringUtils.ToSQL(Gender)+ "%'";
			}
		}

		/// <summary>
		///
		/// </summary>
		public void QueryDBirth(string DBirth)
		{
			if(DBirth!= null &&DBirth.Trim()!= "")
			{
				Filter = "DBirth like '%" +StringUtils.ToSQL(DBirth)+ "%'";
			}
		}

		/// <summary>
		///
		/// </summary>
		public void QueryHTelcode(string HTelcode)
		{
			if(HTelcode!= null &&HTelcode.Trim()!= "")
			{
				Filter = "HTelcode like '%" +StringUtils.ToSQL(HTelcode)+ "%'";
			}
		}

		/// <summary>
		///
		/// </summary>
		public void QueryHTelnum(string HTelnum)
		{
			if(HTelnum!= null &&HTelnum.Trim()!= "")
			{
				Filter = "HTelnum like '%" +StringUtils.ToSQL(HTelnum)+ "%'";
			}
		}

		/// <summary>
		///
		/// </summary>
		public void QueryWTelcode(string WTelcode)
		{
			if(WTelcode!= null &&WTelcode.Trim()!= "")
			{
				Filter = "WTelcode like '%" +StringUtils.ToSQL(WTelcode)+ "%'";
			}
		}

		/// <summary>
		///
		/// </summary>
		public void QueryWTelnum(string WTelnum)
		{
			if(WTelnum!= null &&WTelnum.Trim()!= "")
			{
				Filter = "WTelnum like '%" +StringUtils.ToSQL(WTelnum)+ "%'";
			}
		}

		/// <summary>
		///
		/// </summary>
		public void QueryMobile(string Mobile)
		{
			if(Mobile!= null &&Mobile.Trim()!= "")
			{
				Filter = "Mobile like '%" +StringUtils.ToSQL(Mobile)+ "%'";
			}
		}

		/// <summary>
		///
		/// </summary>
		public void QueryEmail(string Email)
		{
			if(Email!= null &&Email.Trim()!= "")
			{
				Filter = "Email like '%" +StringUtils.ToSQL(Email)+ "%'";
			}
		}

		/// <summary>
		///
		/// </summary>
		public void QueryLicNum(string LicNum)
		{
			if(LicNum!= null &&LicNum.Trim()!= "")
			{
				Filter = "LicNum like '%" +StringUtils.ToSQL(LicNum)+ "%'";
			}
		}

		/// <summary>
		///
		/// </summary>
		public void QueryLicState(string LicState)
		{
			if(LicState!= null &&LicState.Trim()!= "")
			{
				Filter = "LicState like '%" +StringUtils.ToSQL(LicState)+ "%'";
			}
		}

		/// <summary>
		///
		/// </summary>
		public void QueryMaritalStatus(string MaritalStatus)
		{
			if(MaritalStatus!= null &&MaritalStatus.Trim()!= "")
			{
				Filter = "MaritalStatus like '%" +StringUtils.ToSQL(MaritalStatus)+ "%'";
			}
		}

		/// <summary>
		///
		/// </summary>
		public void QueryRegTime(DateTime RegTime)
		{
			Filter = "RegTime= "+RegTime;
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
		public void QueryStatus(int Status)
		{
			Filter = "Status= "+Status;
		}

		/// <summary>
		///
		/// </summary>
		public void QueryUsername(string Username)
		{
			if(Username!= null &&Username.Trim()!= "")
			{
				Filter = "Username like '%" +StringUtils.ToSQL(Username)+ "%'";
			}
		}

		/// <summary>
		///
		/// </summary>
		public void QueryPwd(string Pwd)
		{
			if(Pwd!= null &&Pwd.Trim()!= "")
			{
				Filter = "Pwd like '%" +StringUtils.ToSQL(Pwd)+ "%'";
			}
		}
	}
}