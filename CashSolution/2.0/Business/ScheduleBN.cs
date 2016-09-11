/// <copyright> 英网A1999-2005 </copyright>
/// <version>1.0</version>
/// <author>季宝福</author>
/// <email>jizhe@msn.com</email>
/// <log date="2005年8月11日">创建</log>

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

	public class ScheduleBN:BaseLib
	{
		public ScheduleBN(Page page) : base(page)
		{}

		public bool Add( ScheduleDT dt )
		{
			using ( ScheduleDB db = new ScheduleDB() )
			{
				return db.Insert(dt);
			}
		}
		public bool Del(int id) 		{
			using ( ScheduleDB db = new ScheduleDB() )
			{
				return db.Del(id);
			}
		}
		
		public void DelByHuiSid(int huiSid)
		{
			using ( ScheduleDB db = new ScheduleDB() )
			{
				db.DelByHuiSid(huiSid);
			}
		}
		
		/// <summary>
		/// 删除会员的某次贷款
		/// </summary>
		/// <param name="employedID"></param>
		/// <remarks>会员的每次贷款都在Employed表生成一条记录</remarks>
		public void DelByEmployedID(int employedID)
		{
			using ( ScheduleDB db = new ScheduleDB() )
			{
				db.DelByEmployedID(employedID);
			}
		}
		
		public bool Edit( ScheduleDT dt )
		{
			using ( ScheduleDB db = new ScheduleDB() )
			{
				return db.Update(dt);
			}
		}
		public DataTable GetList ( ) 
		{
			DBFieldList = "Datedue,RepayTime,OperateTime,Penalty,Balance,Repaydue,Param5,Paid,Numberment,id,huiSid,IsValid,Param4,Param1,Param2,Param3";
			DBTable = "Schedule";
			return base.CommonGetList();
		}
		
		public DataTable GetListByTime ( ) 
		{
			DBFieldList = "Datedue,RepayTime,OperateTime,Penalty,Balance,Repaydue,Param5,Paid,Numberment,id,huiSid,IsValid,Param4,Param1,Param2,Param3";
			DBTable = "Schedule";
			this.Order="Datedue asc";
			return base.CommonGetList();
		}
		public ScheduleDT Get( int id )
		{
			using ( ScheduleDB db = new ScheduleDB() )
			{
				return db.GetOneDT( id );
			}
		}
		
		public void QueryhuiSid( string str )
		{
			Filter="huiSid ="+str+"";
		}
		
		public void QueryIsValid( string str )
		{
			Filter="IsValid ="+str+"";
		}
		
		public void QueryNotValid( string str )
		{
			Filter="IsValid !="+str+"";
		}

		public void QueryNumberment(string str)
		{
			Filter="Numberment ="+str+"";
		}

		public void QueryParam1(string str)
		{
			Filter="Param1 ='"+str+"'";
		}

		public void QueryParam2(string str)
		{
			Filter="Param2 ='"+str+"'";
		}
	}
}
