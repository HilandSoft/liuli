using System;
using System.Data;
using System.Collections;

using YingNet.WeiXing.STRUCTURE;
using YingNet.Common;
using YingNet.Common.Database;

namespace YingNet.WeiXing.DB
{
	/// <summary>
	/// LresidentDB的摘要说明。
	/// </summary>
	public class LresidentDB : CommonBaseDB
	{
		public LresidentDB(DBOperate oper) : base(oper)
		{
		}

		/// <summary>
		/// 添加一条记录
		/// </summary>
		/// <param name="detail"></param>
		/// <returns>true 成功 false 失败</returns>
		public bool Add(LresidentDT detail)
		{
			int affected = 0;
			string sql= "INSERT INTO LResident (Status,UnitNo,StreetNum,Suburb,State,Postcode,TimeYears,TimeMonths,NameAgent,TelArea,LoanSid,Other1,Other2,Other3,Other4,Other5,Other6,UnitNo1,StreetNum1,Suburb1,State1,Postcode1,TimeYears1,TimeMonths1) VALUES ('"+ StringUtils.ToSQL(detail.Status)+"'"+ ",'"+ StringUtils.ToSQL(detail.UnitNo)+"'"+ ",'"+ StringUtils.ToSQL(detail.StreetNum)+"'"+ ",'"+ StringUtils.ToSQL(detail.Suburb)+"'"+ ",'"+ StringUtils.ToSQL(detail.State)+"'"+ ",'"+ StringUtils.ToSQL(detail.Postcode)+"'"+ ",'"+ StringUtils.ToSQL(detail.TimeYears)+"'"+ ",'"+ StringUtils.ToSQL(detail.TimeMonths)+"'"+ ",'"+ StringUtils.ToSQL(detail.NameAgent)+"'"+ ",'"+ StringUtils.ToSQL(detail.TelArea)+"'"+ ","+ detail.LoanSid+ ",'"+ StringUtils.ToSQL(detail.Other1)+"'"+ ",'"+ StringUtils.ToSQL(detail.Other2)+"'"+ ",'"+ StringUtils.ToSQL(detail.Other3)+"'"+ ","+ detail.Other4+ ","+ detail.Other5+ ","+ detail.Other6+ ",'"+ StringUtils.ToSQL(detail.UnitNo1)+"'"+ ",'"+ StringUtils.ToSQL(detail.StreetNum1)+"'"+ ",'"+ StringUtils.ToSQL(detail.Suburb1)+"'"+ ",'"+ StringUtils.ToSQL(detail.State1)+"'"+ ",'"+ StringUtils.ToSQL(detail.Postcode1)+"'"+ ",'"+ StringUtils.ToSQL(detail.TimeYears1)+"'"+ ",'"+ StringUtils.ToSQL(detail.TimeMonths1)+"'"+")";

			try
			{
				affected = ExecuteForInt(sql);
			}
			catch (Exception ex)
			{
				throw ex;
			}
			finally
			{
			}

			if (affected == 1)
			{
				return true;
			}
			else
			{
				return false;
			}
		}

		/// <summary>
		/// 修改一条纪录
		/// </summary>
		/// <param name="detail"></param>
		/// <returns>true 成功 false 失败</returns>
		public bool Edit(LresidentDT detail)
		{
			int affected = 0;
			string sql= "UPDATE LResident set Status='"+ StringUtils.ToSQL(detail.Status)+"'"+",UnitNo='"+ StringUtils.ToSQL(detail.UnitNo)+"'"+",StreetNum='"+ StringUtils.ToSQL(detail.StreetNum)+"'"+",Suburb='"+ StringUtils.ToSQL(detail.Suburb)+"'"+",State='"+ StringUtils.ToSQL(detail.State)+"'"+",Postcode='"+ StringUtils.ToSQL(detail.Postcode)+"'"+",TimeYears='"+ StringUtils.ToSQL(detail.TimeYears)+"'"+",TimeMonths='"+ StringUtils.ToSQL(detail.TimeMonths)+"'"+",NameAgent='"+ StringUtils.ToSQL(detail.NameAgent)+"'"+",TelArea='"+ StringUtils.ToSQL(detail.TelArea)+"'"+",LoanSid="+ detail.LoanSid+",Other1='"+ StringUtils.ToSQL(detail.Other1)+"'"+",Other2='"+ StringUtils.ToSQL(detail.Other2)+"'"+",Other3='"+ StringUtils.ToSQL(detail.Other3)+"'"+",Other4="+ detail.Other4+",Other5="+ detail.Other5+",Other6="+ detail.Other6+",UnitNo1='"+ StringUtils.ToSQL(detail.UnitNo1)+"'"+",StreetNum1='"+ StringUtils.ToSQL(detail.StreetNum1)+"'"+",Suburb1='"+ StringUtils.ToSQL(detail.Suburb1)+"'"+",State1='"+ StringUtils.ToSQL(detail.State1)+"'"+",Postcode1='"+ StringUtils.ToSQL(detail.Postcode1)+"'"+",TimeYears1='"+ StringUtils.ToSQL(detail.TimeYears1)+"'"+",TimeMonths1='"+ StringUtils.ToSQL(detail.TimeMonths1)+"'"+" where (sid="+ detail.sid+")";

			try
			{
				affected = ExecuteForInt(sql);
			}
			catch(Exception ex)
			{
				throw ex;
			}
			finally
			{
			}

			if (affected == 1)
			{
				return true;
			}
			else
			{
				return false;
			}
		}

		/// <summary>
		/// 删除一条纪录
		/// </summary>
		/// <param name="detail"></param>
		/// <returns>true 成功 false 失败</returns>
		public bool Delete(int sid)
		{
			int affected = 0;
			string sql= "DELETE FROM LResident where (sid="+ sid+")";

			try
			{
				affected = ExecuteForInt(sql);
			}
			catch(Exception ex)
			{
				throw ex;
			}
			finally
			{
			}

			if (affected == 1)
			{
				return true;
			}
			else
			{
				return false;
			}
		}

		/// <summary>
		/// 获取一条纪录
		/// </summary>
		public LresidentDT Get(int sid)
		{
			LresidentDT detail= new LresidentDT();
			try
			{
				string sql= "select * from LResident where (sid="+ sid+")";
				DataTable dt= this.ExecuteForDataTable(sql);
				DataRow dr=null;
				int rowCount= dt.Rows.Count;
				if (rowCount>=0)
				{
					dr= dt.Rows[0];
					detail.sid= Convert.ToInt32(dr["sid"]);
					detail.Status= Convert.ToString(dr["Status"]);
					detail.UnitNo= Convert.ToString(dr["UnitNo"]);
					detail.StreetNum= Convert.ToString(dr["StreetNum"]);
					detail.Suburb= Convert.ToString(dr["Suburb"]);
					detail.State= Convert.ToString(dr["State"]);
					detail.Postcode= Convert.ToString(dr["Postcode"]);
					detail.TimeYears= Convert.ToString(dr["TimeYears"]);
					detail.TimeMonths= Convert.ToString(dr["TimeMonths"]);
					detail.NameAgent= Convert.ToString(dr["NameAgent"]);
					detail.TelArea= Convert.ToString(dr["TelArea"]);
					detail.LoanSid= Convert.ToInt32(dr["LoanSid"]);
					detail.Other1= Convert.ToString(dr["Other1"]);
					detail.Other2= Convert.ToString(dr["Other2"]);
					detail.Other3= Convert.ToString(dr["Other3"]);
					detail.Other4= Convert.ToInt32(dr["Other4"]);
					detail.Other5= Convert.ToInt32(dr["Other5"]);
					detail.Other6= Convert.ToInt32(dr["Other6"]);
					detail.UnitNo1= Convert.ToString(dr["UnitNo1"]);
					detail.StreetNum1= Convert.ToString(dr["StreetNum1"]);
					detail.Suburb1= Convert.ToString(dr["Suburb1"]);
					detail.State1= Convert.ToString(dr["State1"]);
					detail.Postcode1= Convert.ToString(dr["Postcode1"]);
					detail.TimeYears1= Convert.ToString(dr["TimeYears1"]);
					detail.TimeMonths1= Convert.ToString(dr["TimeMonths1"]);
				}
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
		/// 获取数据集
		/// </summary>
		public DataTable GetList()
		{
			DataTable dt= null;
			try
			{
				string sql= "select * from LResident";
				dt= this.ExecuteForDataTable(sql);
			}
			catch(Exception ex)
			{
				throw ex;
			}
			finally
			{
			}
			return dt;
		}
	}
}