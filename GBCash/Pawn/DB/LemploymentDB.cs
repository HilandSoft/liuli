using System;
using System.Data;
using System.Collections;

using YingNet.WeiXing.STRUCTURE;
using YingNet.Common;
using YingNet.Common.Database;

namespace YingNet.WeiXing.DB
{
	/// <summary>
	/// LemploymentDB的摘要说明。
	/// </summary>
	public class LemploymentDB : CommonBaseDB
	{
		public LemploymentDB(DBOperate oper) : base(oper)
		{
		}

		/// <summary>
		/// 添加一条记录
		/// </summary>
		/// <param name="detail"></param>
		/// <returns>true 成功 false 失败</returns>
		public bool Add(LemploymentDT detail)
		{
			int affected = 0;
			string sql= "INSERT INTO LEmployment (EName,EAddress,ECode,ENum,EStatus,JobTitle,TimeYears,TimeMonths,TakePay,Per,NextDay,NextMonth,NextYear,LoanSid,Other1,Other2,Other3,Other4,Other5,Other6,FollowDay,FollowMonth,FollowYear,HousePaymentValue,HousePaymentCircle,OtherLenderValue,OtherLenderCircle) VALUES ('"+
				StringUtils.ToSQL(detail.EName)+"'"+ ",'"+ StringUtils.ToSQL(detail.EAddress)+"'"+ ",'"+ StringUtils.ToSQL(detail.ECode)+"'"+ 
				",'"+ StringUtils.ToSQL(detail.ENum)+"'"+ ",'"+ StringUtils.ToSQL(detail.EStatus)+"'"+ ",'"+ StringUtils.ToSQL(detail.JobTitle)+
				"'"+ ","+ detail.TimeYears+ ","+ detail.TimeMonths+ ","+ detail.TakePay+ ","+ detail.Per+ ","+ detail.NextDay+ ","+
				detail.NextMonth+ ","+ detail.NextYear+ ","+ detail.LoanSid+ ",'"+ StringUtils.ToSQL(detail.Other1)+"'"+ ",'"+ 
				StringUtils.ToSQL(detail.Other2)+"'"+ ",'"+ StringUtils.ToSQL(detail.Other3)+"'"+ ","+ detail.Other4+ ","+ 
				detail.Other5+ ","+ detail.Other6+ ","+ detail.FollowDay+ ","+ detail.FollowMonth+ ","+ detail.FollowYear+","+ 
				detail.HousePaymentValue+","+ (int)detail.HousePaymentCircle+ ","+ detail.OtherLenderValue+ ","+ (int)detail.OtherLenderCircle +")";

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
		public bool Edit(LemploymentDT detail)
		{
			int affected = 0;
			string sql= "UPDATE LEmployment set EName='"+ StringUtils.ToSQL(detail.EName)+"'"+",EAddress='"+ 
				StringUtils.ToSQL(detail.EAddress)+"'"+",ECode='"+ StringUtils.ToSQL(detail.ECode)+"'"+",ENum='"+ 
				StringUtils.ToSQL(detail.ENum)+"'"+",EStatus='"+ StringUtils.ToSQL(detail.EStatus)+"'"+",JobTitle='"+ 
				StringUtils.ToSQL(detail.JobTitle)+"'"+",TimeYears="+ detail.TimeYears+",TimeMonths="+ 
				detail.TimeMonths+",TakePay="+ detail.TakePay+",Per="+ detail.Per+",NextDay="+ detail.NextDay+",NextMonth="+ 
				detail.NextMonth+",NextYear="+ detail.NextYear+",LoanSid="+ detail.LoanSid+",Other1='"+ 
				StringUtils.ToSQL(detail.Other1)+"'"+",Other2='"+ StringUtils.ToSQL(detail.Other2)+"'"+",Other3='"+ 
				StringUtils.ToSQL(detail.Other3)+"'"+",Other4="+ detail.Other4+",Other5="+ detail.Other5+",Other6="+ 
				detail.Other6+",FollowDay="+ detail.FollowDay+",FollowMonth="+ detail.FollowMonth+",FollowYear="+ 
				detail.FollowYear+ ",HousePaymentValue="+ detail.HousePaymentValue+ ",HousePaymentCircle="+ 
				(int)detail.HousePaymentCircle+ ",OtherLenderValue="+detail.OtherLenderValue+ ",OtherLenderCircle="+ 
				(int)detail.OtherLenderCircle +" where (sid="+ detail.sid+")";

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
			string sql= "DELETE FROM LEmployment where (sid="+ sid+")";

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
		public LemploymentDT Get(int sid)
		{
			LemploymentDT detail= new LemploymentDT();
			try
			{
				string sql= "select * from LEmployment where (sid="+ sid+")";
				DataTable dt= this.ExecuteForDataTable(sql);
				DataRow dr=null;
				int rowCount= dt.Rows.Count;
				if (rowCount>=0)
				{
					dr= dt.Rows[0];
					detail.sid= Convert.ToInt32(dr["sid"]);
					detail.EName= Convert.ToString(dr["EName"]);
					detail.EAddress= Convert.ToString(dr["EAddress"]);
					detail.ECode= Convert.ToString(dr["ECode"]);
					detail.ENum= Convert.ToString(dr["ENum"]);
					detail.EStatus= Convert.ToString(dr["EStatus"]);
					detail.JobTitle= Convert.ToString(dr["JobTitle"]);
					detail.TimeYears= Convert.ToInt32(dr["TimeYears"]);
					detail.TimeMonths= Convert.ToInt32(dr["TimeMonths"]);
					detail.TakePay= Convert.ToDouble(dr["TakePay"]);
					detail.Per= Convert.ToInt32(dr["Per"]);
					detail.NextDay= Convert.ToInt32(dr["NextDay"]);
					detail.NextMonth= Convert.ToInt32(dr["NextMonth"]);
					detail.NextYear= Convert.ToInt32(dr["NextYear"]);
					detail.LoanSid= Convert.ToInt32(dr["LoanSid"]);
					detail.Other1= Convert.ToString(dr["Other1"]);
					detail.Other2= Convert.ToString(dr["Other2"]);
					detail.Other3= Convert.ToString(dr["Other3"]);
					detail.Other4= Convert.ToInt32(dr["Other4"]);
					detail.Other5= Convert.ToInt32(dr["Other5"]);
					detail.Other6= Convert.ToInt32(dr["Other6"]);
					detail.FollowDay= Convert.ToInt32(dr["FollowDay"]);
					detail.FollowMonth= Convert.ToInt32(dr["FollowMonth"]);
					detail.FollowYear= Convert.ToInt32(dr["FollowYear"]);

					if(Convert.IsDBNull(dr["HousePaymentCircle"])==false)
					{
						detail.HousePaymentCircle=(HousePaymentCircles) Convert.ToInt32(dr["HousePaymentCircle"]);
					}

					if(Convert.IsDBNull(dr["HousePaymentValue"])==false)
					{
						detail.HousePaymentValue=Convert.ToSingle(dr["HousePaymentValue"]);
					}

					if(Convert.IsDBNull(dr["OtherLenderCircle"])==false)
					{
						detail.OtherLenderCircle=(OtherLenderCircles) Convert.ToInt32(dr["OtherLenderCircle"]);
					}

					if(Convert.IsDBNull(dr["OtherLenderValue"])==false)
					{
						detail.OtherLenderValue=Convert.ToSingle(dr["OtherLenderValue"]);
					}
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
				string sql= "select * from LEmployment";
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