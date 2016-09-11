using System;
using System.Data;
using System.Collections;

using YingNet.WeiXing.STRUCTURE;
using YingNet.Common;
using YingNet.Common.Database;

namespace YingNet.WeiXing.DB
{
	/// <summary>
	/// LbankDB的摘要说明。
	/// </summary>
	public class LbankDB : CommonBaseDB
	{
		public LbankDB(DBOperate oper) : base(oper)
		{
		}

		/// <summary>
		/// 添加一条记录
		/// </summary>
		/// <param name="detail"></param>
		/// <returns>true 成功 false 失败</returns>
		public bool Add(LbankDT detail)
		{
			int affected = 0;
			string sql= "INSERT INTO LBank (BankName,Branch,AccountName,Bsb,AccountNum,PContact,Rname1,Rship1,Rnum1,Rname2,Rship2,Rnum2,Rname3,Rship3,Rnum3,LoanSid,Other1,Other2,Other3,Other4,Other5,Other6) VALUES ('"+ StringUtils.ToSQL(detail.BankName)+"'"+ ",'"+ StringUtils.ToSQL(detail.Branch)+"'"+ ",'"+ StringUtils.ToSQL(detail.AccountName)+"'"+ ",'"+ StringUtils.ToSQL(detail.Bsb)+"'"+ ",'"+ StringUtils.ToSQL(detail.AccountNum)+"'"+ ",'"+ StringUtils.ToSQL(detail.PContact)+"'"+ ",'"+ StringUtils.ToSQL(detail.Rname1)+"'"+ ",'"+ StringUtils.ToSQL(detail.Rship1)+"'"+ ",'"+ StringUtils.ToSQL(detail.Rnum1)+"'"+ ",'"+ StringUtils.ToSQL(detail.Rname2)+"'"+ ",'"+ StringUtils.ToSQL(detail.Rship2)+"'"+ ",'"+ StringUtils.ToSQL(detail.Rnum2)+"'"+ ",'"+ StringUtils.ToSQL(detail.Rname3)+"'"+ ",'"+ StringUtils.ToSQL(detail.Rship3)+"'"+ ",'"+ StringUtils.ToSQL(detail.Rnum3)+"'"+ ","+ detail.LoanSid+ ",'"+ StringUtils.ToSQL(detail.Other1)+"'"+ ",'"+ StringUtils.ToSQL(detail.Other2)+"'"+ ",'"+ StringUtils.ToSQL(detail.Other3)+"'"+ ","+ detail.Other4+ ","+ detail.Other5+ ","+ detail.Other6+")";

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
		public bool Edit(LbankDT detail)
		{
			int affected = 0;
			string sql= "UPDATE LBank set BankName='"+ StringUtils.ToSQL(detail.BankName)+"'"+",Branch='"+ StringUtils.ToSQL(detail.Branch)+"'"+",AccountName='"+ StringUtils.ToSQL(detail.AccountName)+"'"+",Bsb='"+ StringUtils.ToSQL(detail.Bsb)+"'"+",AccountNum='"+ StringUtils.ToSQL(detail.AccountNum)+"'"+",PContact='"+ StringUtils.ToSQL(detail.PContact)+"'"+",Rname1='"+ StringUtils.ToSQL(detail.Rname1)+"'"+",Rship1='"+ StringUtils.ToSQL(detail.Rship1)+"'"+",Rnum1='"+ StringUtils.ToSQL(detail.Rnum1)+"'"+",Rname2='"+ StringUtils.ToSQL(detail.Rname2)+"'"+",Rship2='"+ StringUtils.ToSQL(detail.Rship2)+"'"+",Rnum2='"+ StringUtils.ToSQL(detail.Rnum2)+"'"+",Rname3='"+ StringUtils.ToSQL(detail.Rname3)+"'"+",Rship3='"+ StringUtils.ToSQL(detail.Rship3)+"'"+",Rnum3='"+ StringUtils.ToSQL(detail.Rnum3)+"'"+",LoanSid="+ detail.LoanSid+",Other1='"+ StringUtils.ToSQL(detail.Other1)+"'"+",Other2='"+ StringUtils.ToSQL(detail.Other2)+"'"+",Other3='"+ StringUtils.ToSQL(detail.Other3)+"'"+",Other4="+ detail.Other4+",Other5="+ detail.Other5+",Other6="+ detail.Other6+" where (sid="+ detail.sid+")";

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
			string sql= "DELETE FROM LBank where (sid="+ sid+")";

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
		public LbankDT Get(int sid)
		{
			LbankDT detail= new LbankDT();
			try
			{
				string sql= "select * from LBank where (sid="+ sid+")";
				DataTable dt= this.ExecuteForDataTable(sql);
				DataRow dr=null;
				int rowCount= dt.Rows.Count;
				if (rowCount>=0)
				{
					dr= dt.Rows[0];
					detail.sid= Convert.ToInt32(dr["sid"]);
					detail.BankName= Convert.ToString(dr["BankName"]);
					detail.Branch= Convert.ToString(dr["Branch"]);
					detail.AccountName= Convert.ToString(dr["AccountName"]);
					detail.Bsb= Convert.ToString(dr["Bsb"]);
					detail.AccountNum= Convert.ToString(dr["AccountNum"]);
					detail.PContact= Convert.ToString(dr["PContact"]);
					detail.Rname1= Convert.ToString(dr["Rname1"]);
					detail.Rship1= Convert.ToString(dr["Rship1"]);
					detail.Rnum1= Convert.ToString(dr["Rnum1"]);
					detail.Rname2= Convert.ToString(dr["Rname2"]);
					detail.Rship2= Convert.ToString(dr["Rship2"]);
					detail.Rnum2= Convert.ToString(dr["Rnum2"]);
					detail.Rname3= Convert.ToString(dr["Rname3"]);
					detail.Rship3= Convert.ToString(dr["Rship3"]);
					detail.Rnum3= Convert.ToString(dr["Rnum3"]);
					detail.LoanSid= Convert.ToInt32(dr["LoanSid"]);
					detail.Other1= Convert.ToString(dr["Other1"]);
					detail.Other2= Convert.ToString(dr["Other2"]);
					detail.Other3= Convert.ToString(dr["Other3"]);
					detail.Other4= Convert.ToInt32(dr["Other4"]);
					detail.Other5= Convert.ToInt32(dr["Other5"]);
					detail.Other6= Convert.ToInt32(dr["Other6"]);
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
				string sql= "select * from LBank";
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