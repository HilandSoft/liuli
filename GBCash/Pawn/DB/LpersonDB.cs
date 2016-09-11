using System;
using System.Data;
using System.Collections;

using YingNet.WeiXing.STRUCTURE;
using YingNet.Common;
using YingNet.Common.Database;

namespace YingNet.WeiXing.DB
{
	/// <summary>
	/// LpersonDB的摘要说明。
	/// </summary>
	public class LpersonDB : CommonBaseDB
	{
		public LpersonDB(DBOperate oper) : base(oper)
		{
		}

		/// <summary>
		/// 添加一条记录
		/// </summary>
		/// <param name="detail"></param>
		/// <returns>true 成功 false 失败</returns>
		public bool Add(LpersonDT detail)
		{
			int affected = 0;
			string sql= "INSERT INTO LPerson (IsExist,ReferenceNum,Title,Fname,Mname,Sname,Gender,DBirth,HTelcode,HTelnum,WTelcode,WTelnum,Mobile,Email,LicNum,LicState,MaritalStatus,RegTime,LoanSid,Rname1,Rship1,Rnum1,Rname2,Rship2,Rnum2,Rname3,Rship3,Rnum3,Other1,Other2,Other3,Other4,Other5,Other6,Status,Username,Pwd) VALUES ("+ detail.IsExist+ ",'"+ StringUtils.ToSQL(detail.ReferenceNum)+"'"+ ",'"+ StringUtils.ToSQL(detail.Title)+"'"+ ",'"+ StringUtils.ToSQL(detail.Fname)+"'"+ ",'"+ StringUtils.ToSQL(detail.Mname)+"'"+ ",'"+ StringUtils.ToSQL(detail.Sname)+"'"+ ",'"+ StringUtils.ToSQL(detail.Gender)+"'"+ ",'"+ StringUtils.ToSQL(detail.DBirth)+"'"+ ",'"+ StringUtils.ToSQL(detail.HTelcode)+"'"+ ",'"+ StringUtils.ToSQL(detail.HTelnum)+"'"+ ",'"+ StringUtils.ToSQL(detail.WTelcode)+"'"+ ",'"+ StringUtils.ToSQL(detail.WTelnum)+"'"+ ",'"+ StringUtils.ToSQL(detail.Mobile)+"'"+ ",'"+ StringUtils.ToSQL(detail.Email)+"'"+ ",'"+ StringUtils.ToSQL(detail.LicNum)+"'"+ ",'"+ StringUtils.ToSQL(detail.LicState)+"'"+ ",'"+ StringUtils.ToSQL(detail.MaritalStatus)+"'"+ ",'"+ detail.RegTime+ "',"+ detail.LoanSid+ ",'"+ StringUtils.ToSQL(detail.Rname1)+"'"+ ",'"+ StringUtils.ToSQL(detail.Rship1)+"'"+ ",'"+ StringUtils.ToSQL(detail.Rnum1)+"'"+ ",'"+ StringUtils.ToSQL(detail.Rname2)+"'"+ ",'"+ StringUtils.ToSQL(detail.Rship2)+"'"+ ",'"+ StringUtils.ToSQL(detail.Rnum2)+"'"+ ",'"+ StringUtils.ToSQL(detail.Rname3)+"'"+ ",'"+ StringUtils.ToSQL(detail.Rship3)+"'"+ ",'"+ StringUtils.ToSQL(detail.Rnum3)+"'"+ ",'"+ StringUtils.ToSQL(detail.Other1)+"'"+ ",'"+ StringUtils.ToSQL(detail.Other2)+"'"+ ",'"+ StringUtils.ToSQL(detail.Other3)+"'"+ ","+ detail.Other4+ ","+ detail.Other5+ ","+ detail.Other6+ ","+ detail.Status+ ",'"+ StringUtils.ToSQL(detail.Username)+"'"+ ",'"+ StringUtils.ToSQL(detail.Pwd)+"'"+")";

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
		
		public int AddId(LpersonDT detail)
		{
			int affected = 0;
			int result=0;
			string sql= "INSERT INTO LPerson (IsExist,ReferenceNum,Title,Fname,Mname,Sname,Gender,DBirth,HTelcode,HTelnum,WTelcode,WTelnum,Mobile,Email,LicNum,LicState,MaritalStatus,RegTime,LoanSid,Rname1,Rship1,Rnum1,Rname2,Rship2,Rnum2,Rname3,Rship3,Rnum3,Other1,Other2,Other3,Other4,Other5,Other6,Status,Username,Pwd) VALUES ("+ detail.IsExist+ ",'"+ StringUtils.ToSQL(detail.ReferenceNum)+"'"+ ",'"+ StringUtils.ToSQL(detail.Title)+"'"+ ",'"+ StringUtils.ToSQL(detail.Fname)+"'"+ ",'"+ StringUtils.ToSQL(detail.Mname)+"'"+ ",'"+ StringUtils.ToSQL(detail.Sname)+"'"+ ",'"+ StringUtils.ToSQL(detail.Gender)+"'"+ ",'"+ StringUtils.ToSQL(detail.DBirth)+"'"+ ",'"+ StringUtils.ToSQL(detail.HTelcode)+"'"+ ",'"+ StringUtils.ToSQL(detail.HTelnum)+"'"+ ",'"+ StringUtils.ToSQL(detail.WTelcode)+"'"+ ",'"+ StringUtils.ToSQL(detail.WTelnum)+"'"+ ",'"+ StringUtils.ToSQL(detail.Mobile)+"'"+ ",'"+ StringUtils.ToSQL(detail.Email)+"'"+ ",'"+ StringUtils.ToSQL(detail.LicNum)+"'"+ ",'"+ StringUtils.ToSQL(detail.LicState)+"'"+ ",'"+ StringUtils.ToSQL(detail.MaritalStatus)+"'"+ ",'"+ detail.RegTime+ "',"+ detail.LoanSid+ ",'"+ StringUtils.ToSQL(detail.Rname1)+"'"+ ",'"+ StringUtils.ToSQL(detail.Rship1)+"'"+ ",'"+ StringUtils.ToSQL(detail.Rnum1)+"'"+ ",'"+ StringUtils.ToSQL(detail.Rname2)+"'"+ ",'"+ StringUtils.ToSQL(detail.Rship2)+"'"+ ",'"+ StringUtils.ToSQL(detail.Rnum2)+"'"+ ",'"+ StringUtils.ToSQL(detail.Rname3)+"'"+ ",'"+ StringUtils.ToSQL(detail.Rship3)+"'"+ ",'"+ StringUtils.ToSQL(detail.Rnum3)+"'"+ ",'"+ StringUtils.ToSQL(detail.Other1)+"'"+ ",'"+ StringUtils.ToSQL(detail.Other2)+"'"+ ",'"+ StringUtils.ToSQL(detail.Other3)+"'"+ ","+ detail.Other4+ ","+ detail.Other5+ ","+ detail.Other6+ ","+ detail.Status+ ",'"+ StringUtils.ToSQL(detail.Username)+"'"+ ",'"+ StringUtils.ToSQL(detail.Pwd)+"'"+")";

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
		public bool Edit(LpersonDT detail)
		{
			int affected = 0;
			string sql= "UPDATE LPerson set IsExist="+ detail.IsExist+",ReferenceNum='"+ StringUtils.ToSQL(detail.ReferenceNum)+"'"+",Title='"+ StringUtils.ToSQL(detail.Title)+"'"+",Fname='"+ StringUtils.ToSQL(detail.Fname)+"'"+",Mname='"+ StringUtils.ToSQL(detail.Mname)+"'"+",Sname='"+ StringUtils.ToSQL(detail.Sname)+"'"+",Gender='"+ StringUtils.ToSQL(detail.Gender)+"'"+",DBirth='"+ StringUtils.ToSQL(detail.DBirth)+"'"+",HTelcode='"+ StringUtils.ToSQL(detail.HTelcode)+"'"+",HTelnum='"+ StringUtils.ToSQL(detail.HTelnum)+"'"+",WTelcode='"+ StringUtils.ToSQL(detail.WTelcode)+"'"+",WTelnum='"+ StringUtils.ToSQL(detail.WTelnum)+"'"+",Mobile='"+ StringUtils.ToSQL(detail.Mobile)+"'"+",Email='"+ StringUtils.ToSQL(detail.Email)+"'"+",LicNum='"+ StringUtils.ToSQL(detail.LicNum)+"'"+",LicState='"+ StringUtils.ToSQL(detail.LicState)+"'"+",MaritalStatus='"+ StringUtils.ToSQL(detail.MaritalStatus)+"'"+",RegTime='"+ detail.RegTime+"',LoanSid="+ detail.LoanSid+",Rname1='"+ StringUtils.ToSQL(detail.Rname1)+"'"+",Rship1='"+ StringUtils.ToSQL(detail.Rship1)+"'"+",Rnum1='"+ StringUtils.ToSQL(detail.Rnum1)+"'"+",Rname2='"+ StringUtils.ToSQL(detail.Rname2)+"'"+",Rship2='"+ StringUtils.ToSQL(detail.Rship2)+"'"+",Rnum2='"+ StringUtils.ToSQL(detail.Rnum2)+"'"+",Rname3='"+ StringUtils.ToSQL(detail.Rname3)+"'"+",Rship3='"+ StringUtils.ToSQL(detail.Rship3)+"'"+",Rnum3='"+ StringUtils.ToSQL(detail.Rnum3)+"'"+",Other1='"+ StringUtils.ToSQL(detail.Other1)+"'"+",Other2='"+ StringUtils.ToSQL(detail.Other2)+"'"+",Other3='"+ StringUtils.ToSQL(detail.Other3)+"'"+",Other4="+ detail.Other4+",Other5="+ detail.Other5+",Other6="+ detail.Other6+",Status="+ detail.Status+",Username='"+ StringUtils.ToSQL(detail.Username)+"'"+",Pwd='"+ StringUtils.ToSQL(detail.Pwd)+"'"+" where (sid="+ detail.sid+")";

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
			string sql= "DELETE FROM LPerson where (sid="+ sid+")";

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
		public LpersonDT Get(int sid)
		{
			LpersonDT detail= new LpersonDT();
			try
			{
				string sql= "select * from LPerson where (sid="+ sid+")";
				DataTable dt= this.ExecuteForDataTable(sql);
				DataRow dr=null;
				int rowCount= dt.Rows.Count;
				if (rowCount>=0)
				{
					dr= dt.Rows[0];
					detail.sid= Convert.ToInt32(dr["sid"]);
					detail.IsExist= Convert.ToInt32(dr["IsExist"]);
					detail.ReferenceNum= Convert.ToString(dr["ReferenceNum"]);
					detail.Title= Convert.ToString(dr["Title"]);
					detail.Fname= Convert.ToString(dr["Fname"]);
					detail.Mname= Convert.ToString(dr["Mname"]);
					detail.Sname= Convert.ToString(dr["Sname"]);
					detail.Gender= Convert.ToString(dr["Gender"]);
					detail.DBirth= Convert.ToString(dr["DBirth"]);
					detail.HTelcode= Convert.ToString(dr["HTelcode"]);
					detail.HTelnum= Convert.ToString(dr["HTelnum"]);
					detail.WTelcode= Convert.ToString(dr["WTelcode"]);
					detail.WTelnum= Convert.ToString(dr["WTelnum"]);
					detail.Mobile= Convert.ToString(dr["Mobile"]);
					detail.Email= Convert.ToString(dr["Email"]);
					detail.LicNum= Convert.ToString(dr["LicNum"]);
					detail.LicState= Convert.ToString(dr["LicState"]);
					detail.MaritalStatus= Convert.ToString(dr["MaritalStatus"]);
					detail.RegTime= Convert.ToDateTime(dr["RegTime"]);
					detail.LoanSid= Convert.ToInt32(dr["LoanSid"]);
					detail.Rname1= Convert.ToString(dr["Rname1"]);
					detail.Rship1= Convert.ToString(dr["Rship1"]);
					detail.Rnum1= Convert.ToString(dr["Rnum1"]);
					detail.Rname2= Convert.ToString(dr["Rname2"]);
					detail.Rship2= Convert.ToString(dr["Rship2"]);
					detail.Rnum2= Convert.ToString(dr["Rnum2"]);
					detail.Rname3= Convert.ToString(dr["Rname3"]);
					detail.Rship3= Convert.ToString(dr["Rship3"]);
					detail.Rnum3= Convert.ToString(dr["Rnum3"]);
					detail.Other1= Convert.ToString(dr["Other1"]);
					detail.Other2= Convert.ToString(dr["Other2"]);
					detail.Other3= Convert.ToString(dr["Other3"]);
					detail.Other4= Convert.ToInt32(dr["Other4"]);
					detail.Other5= Convert.ToInt32(dr["Other5"]);
					detail.Other6= Convert.ToInt32(dr["Other6"]);
					detail.Status= Convert.ToInt32(dr["Status"]);
					detail.Username= Convert.ToString(dr["Username"]);
					detail.Pwd= Convert.ToString(dr["Pwd"]);
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
				string sql= "select * from LPerson";
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