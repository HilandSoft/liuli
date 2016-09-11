using System;
using System.Data;
using System.Collections;

using YingNet.WeiXing.STRUCTURE;
using YingNet.Common;
using YingNet.Common.Database;


namespace YingNet.WeiXing.DB
{
	/// <summary>
	/// LiniloanDB的摘要说明。
	/// </summary>
	public class LiniloanDB : CommonBaseDB
	{
		public LiniloanDB(DBOperate oper) : base(oper)
		{
		}

		/// <summary>
		/// 添加一条记录
		/// </summary>
		/// <param name="detail"></param>
		/// <returns>true 成功 false 失败</returns>
		public bool Add(LiniloanDT detail)
		{
			int affected = 0;
			string sql= "INSERT INTO LIniLoan (PrimaryPurpose,Loan,Term,Other1,Other2,Other3,Other4,Other5,Other6,Persid) VALUES ('"+ StringUtils.ToSQL(detail.PrimaryPurpose)+"'"+ ","+ detail.Loan+ ","+ detail.Term+ ",'"+ StringUtils.ToSQL(detail.Other1)+"'"+ ",'"+ StringUtils.ToSQL(detail.Other2)+"'"+ ",'"+ StringUtils.ToSQL(detail.Other3)+"'"+ ","+ detail.Other4+ ","+ detail.Other5+ ","+ detail.Other6+ ","+ detail.Persid+")";

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
		
		public int AddId(LiniloanDT detail)
		{
			int affected = 0;
			int result=0;
			//string sql= "INSERT INTO LIniLoan (PrimaryPurpose,Loan,Term,Other1,Other2,Other3,Other4,Other5,Other6,Persid) VALUES ('"+ StringUtils.ToSQL(detail.PrimaryPurpose)+"'"+ ","+ detail.Loan+ ","+ detail.Term+ ",'"+ StringUtils.ToSQL(detail.Other1)+"'"+ ",'"+ StringUtils.ToSQL(detail.Other2)+"'"+ ",'"+ StringUtils.ToSQL(detail.Other3)+"'"+ ","+ detail.Other4+ ","+ detail.Other5+ ","+ detail.Other6+ ","+ detail.Persid+")";
			string sql= "INSERT INTO LIniLoan (PrimaryPurpose,Loan,Term,Persid,Other1,Other2,Other3,Other4,Other5,Other6) VALUES ('"+ StringUtils.ToSQL(detail.PrimaryPurpose)+"'"+ ","+ detail.Loan+ ","+ detail.Term+ ",0,'"+  StringUtils.ToSQL(detail.Other1)+"','" +StringUtils.ToSQL(detail.Other2)+"','"+StringUtils.ToSQL(detail.Other3)+"',0,0,0)";

			try
			{
				affected = ExecuteForInt(sql);
				if (affected>0) 
				{
					sql="SELECT @@IDENTITY AS 'Identity'";
					DataTable ddt = ExecuteForDataTable(sql);
					if (ddt.Rows.Count>0) 
					{
						result=Convert.ToInt32(ddt.Rows[0][0].ToString());
					}
				} 
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
				return result;
			}
			else
			{
				return 0;
			}
		}

		/// <summary>
		/// 修改一条纪录
		/// </summary>
		/// <param name="detail"></param>
		/// <returns>true 成功 false 失败</returns>
		public bool Edit(LiniloanDT detail)
		{
			int affected = 0;
			string sql= "UPDATE LIniLoan set PrimaryPurpose='"+ StringUtils.ToSQL(detail.PrimaryPurpose)+"',Loan="+ detail.Loan+",Term="+ detail.Term+" where (sid="+ detail.sid+")";

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
			string sql= "DELETE FROM LIniLoan where (sid="+ sid+")";

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
		public LiniloanDT Get(int sid)
		{
			LiniloanDT detail= new LiniloanDT();
			try
			{
				string sql= "select * from LIniLoan where (sid="+ sid+")";
				DataTable dt= this.ExecuteForDataTable(sql);
				DataRow dr=null;
				int rowCount= dt.Rows.Count;
				if (rowCount>=0)
				{
					dr= dt.Rows[0];
					detail.sid= Convert.ToInt32(dr["sid"]);
					detail.PrimaryPurpose= Convert.ToString(dr["PrimaryPurpose"]);
					detail.Loan= Convert.ToDouble(dr["Loan"]);
					detail.Term= Convert.ToInt32(dr["Term"]);
					try
					{
						detail.Other1= Convert.ToString(dr["Other1"]);
						detail.Other2= Convert.ToString(dr["Other2"]);
						detail.Other3= Convert.ToString(dr["Other3"]);
						detail.Other4= Convert.ToInt32(dr["Other4"]);
						detail.Other5= Convert.ToInt32(dr["Other5"]);
						detail.Other6= Convert.ToInt32(dr["Other6"]);
					}
					catch
					{}
					detail.Persid= Convert.ToInt32(dr["Persid"]);
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
				string sql= "select * from LIniLoan";
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