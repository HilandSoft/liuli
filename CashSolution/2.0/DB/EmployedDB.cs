/// <copyright> 英网A1999-2005 </copyright>
/// <version>1.0</version>
/// <author>季宝福</author>
/// <email>jizhe@msn.com</email>
/// <log date="2005年8月11日">创建</log>

using System;
using System.Data;
using System.Data.SqlClient;
using YingNet.Common;
using YingNet.WeiXing.DB.Data;
using YingNet.WeiXing.STRUCTURE;


namespace YingNet.WeiXing.DB
{

	/// <summary>
	/// DepinfoDT的摘要说明。
	/// <summary>

	public class EmployedDB:DBAccess
	{

		/// <summary>
		///  按结构取值
		/// <summary>
		/// <param name='dr'>SqlDataReader</param>
		/// <param name='obj'>数据结构对象</param>
		/// <returns>数据结构对象</returns>
		public override object ConvertItem( SqlDataReader dr)
		{
			EmployedDT dt = new EmployedDT();
			dt.RTime= Convert.ToDateTime(dr["RTime"]);
			dt.Param2= Convert.ToDouble(dr["Param2"]);
			dt.Interest= Convert.ToDouble(dr["Interest"]);
			dt.Frequency= Convert.ToDouble(dr["Frequency"]);
			dt.Param1= Convert.ToDouble(dr["Param1"]);
			dt.XDay= Convert.ToInt32(dr["XDay"]);
			dt.Param3= Convert.ToInt32(dr["Param3"]);
			dt.huiSid= Convert.ToInt32(dr["huiSid"]);
			dt.IsEmployed= Convert.ToInt32(dr["IsEmployed"]);
			dt.IsValid= Convert.ToInt32(dr["IsValid"]);
			dt.NInstallment= Convert.ToInt32(dr["NInstallment"]);
			dt.NDayMM= Convert.ToInt32(dr["NDayMM"]);
			dt.NDayDD= Convert.ToInt32(dr["NDayDD"]);
			dt.NDayYY= Convert.ToInt32(dr["NDayYY"]);
			dt.id= Convert.ToInt32(dr["id"]);
			dt.TYears= Convert.ToInt32(dr["TYears"]);
			dt.TMonths= Convert.ToInt32(dr["TMonths"]);
			dt.MIncome= Convert.ToSingle(dr["MIncome"]);
			dt.Loan= Convert.ToSingle(dr["Loan"]);
			dt.Rnum3= Convert.ToString(dr["Rnum3"]);
			dt.Param4= Convert.ToString(dr["Param4"]);
			dt.Param5= Convert.ToString(dr["Param5"]);
			dt.Rnum2= Convert.ToString(dr["Rnum2"]);
			dt.Rname3= Convert.ToString(dr["Rname3"]);
			dt.Rship3= Convert.ToString(dr["Rship3"]);
			dt.Rnum1= Convert.ToString(dr["Rnum1"]);
			dt.Rname2= Convert.ToString(dr["Rname2"]);
			dt.Rship2= Convert.ToString(dr["Rship2"]);
			dt.MContact= Convert.ToString(dr["MContact"]);
			dt.Rname1= Convert.ToString(dr["Rname1"]);
			dt.Rship1= Convert.ToString(dr["Rship1"]);
			dt.AName= Convert.ToString(dr["AName"]);
			dt.Bsb= Convert.ToString(dr["Bsb"]);
			dt.ANumber= Convert.ToString(dr["ANumber"]);
			dt.Wpaid= Convert.ToString(dr["Wpaid"]);
			dt.Branch= Convert.ToString(dr["Branch"]);
			dt.BankName= Convert.ToString(dr["BankName"]);
			dt.Employer= Convert.ToString(dr["Employer"]);
			dt.EAddress= Convert.ToString(dr["EAddress"]);
			dt.EPhone= Convert.ToString(dr["EPhone"]);

			if(Convert.IsDBNull(dr["LoanPurpose"])==false)
			{
				dt.LoanPurpose= Convert.ToString( dr["LoanPurpose"]);
			}

			if(Convert.IsDBNull(dr["HousePaymentValue"])==false)
			{
				dt.HousePaymentValue= Convert.ToSingle( dr["HousePaymentValue"]);
			}

			if(Convert.IsDBNull(dr["HousePaymentCircle"])==false)
			{
				dt.HousePaymentCircle=(HousePaymentCircles) Convert.ToInt32( dr["HousePaymentCircle"]);
			}

			if(Convert.IsDBNull(dr["OtherLenderValue"])==false)
			{
				dt.OtherLenderValue= Convert.ToSingle( dr["OtherLenderValue"]);
			}

			if(Convert.IsDBNull(dr["OtherLenderCircle"])==false)
			{
				dt.OtherLenderCircle= (OtherLenderCircles)Convert.ToInt32( dr["OtherLenderCircle"]);
			}

			if(Convert.IsDBNull(dr["OtherSamllCreditHas"])==false)
			{
				dt.OtherSamllCreditHas= Convert.ToInt32( dr["OtherSamllCreditHas"]);
			}

			if(Convert.IsDBNull(dr["OtherSmallCreditCount"])==false)
			{
				dt.OtherSmallCreditCount= Convert.ToInt32( dr["OtherSmallCreditCount"]);
			}

			return dt;
		}

		/// <summary>
		///  组织参数列表
		/// <summary>
		/// <param name='obj'>数据结构对象</param>
		/// <returns>参数列表</returns>
		public override SqlParameter[] GetParameter( object obj )
		{
			EmployedDT dt = (EmployedDT)obj;
			SqlParameter[] prams =
			{
				MakeInParam("@RTime" ,SqlDbType.DateTime,8,dt.RTime),
				MakeInParam("@Param2" ,SqlDbType.Float,8,dt.Param2),
				MakeInParam("@Interest" ,SqlDbType.Float,8,dt.Interest),
				MakeInParam("@Frequency" ,SqlDbType.Float,8,dt.Frequency),
				MakeInParam("@Param1" ,SqlDbType.Float,8,dt.Param1),
				MakeInParam("@XDay" ,SqlDbType.Int,4,dt.XDay),
				MakeInParam("@Param3" ,SqlDbType.Int,4,dt.Param3),
				MakeInParam("@huiSid" ,SqlDbType.Int,4,dt.huiSid),
				MakeInParam("@IsEmployed" ,SqlDbType.Int,4,dt.IsEmployed),
				MakeInParam("@IsValid" ,SqlDbType.Int,4,dt.IsValid),
				MakeInParam("@NInstallment" ,SqlDbType.Int,4,dt.NInstallment),
				MakeInParam("@NDayMM" ,SqlDbType.Int,4,dt.NDayMM),
				MakeInParam("@NDayDD" ,SqlDbType.Int,4,dt.NDayDD),
				MakeInParam("@NDayYY" ,SqlDbType.Int,4,dt.NDayYY),
				MakeInParam("@id" ,SqlDbType.Int,4,dt.id),
				MakeInParam("@TYears" ,SqlDbType.Int,4,dt.TYears),
				MakeInParam("@TMonths" ,SqlDbType.Int,4,dt.TMonths),
				MakeInParam("@MIncome" ,SqlDbType.Money,8,dt.MIncome),
				MakeInParam("@Loan" ,SqlDbType.Money,8,dt.Loan),
				MakeInParam("@Rnum3" ,SqlDbType.NVarChar,400,dt.Rnum3),
				MakeInParam("@Param4" ,SqlDbType.NVarChar,400,dt.Param4),
				MakeInParam("@Param5" ,SqlDbType.NVarChar,400,dt.Param5),
				MakeInParam("@Rnum2" ,SqlDbType.NVarChar,400,dt.Rnum2),
				MakeInParam("@Rname3" ,SqlDbType.NVarChar,400,dt.Rname3),
				MakeInParam("@Rship3" ,SqlDbType.NVarChar,400,dt.Rship3),
				MakeInParam("@Rnum1" ,SqlDbType.NVarChar,400,dt.Rnum1),
				MakeInParam("@Rname2" ,SqlDbType.NVarChar,400,dt.Rname2),
				MakeInParam("@Rship2" ,SqlDbType.NVarChar,400,dt.Rship2),
				MakeInParam("@MContact" ,SqlDbType.NVarChar,400,dt.MContact),
				MakeInParam("@Rname1" ,SqlDbType.NVarChar,400,dt.Rname1),
				MakeInParam("@Rship1" ,SqlDbType.NVarChar,400,dt.Rship1),
				MakeInParam("@AName" ,SqlDbType.NVarChar,400,dt.AName),
				MakeInParam("@Bsb" ,SqlDbType.NVarChar,400,dt.Bsb),
				MakeInParam("@ANumber" ,SqlDbType.NVarChar,400,dt.ANumber),
				MakeInParam("@Wpaid" ,SqlDbType.NVarChar,400,dt.Wpaid),
				MakeInParam("@Branch" ,SqlDbType.NVarChar,400,dt.Branch),
				MakeInParam("@BankName" ,SqlDbType.NVarChar,400,dt.BankName),
				MakeInParam("@Employer" ,SqlDbType.NVarChar,400,dt.Employer),
				MakeInParam("@EAddress" ,SqlDbType.NVarChar,400,dt.EAddress),
				MakeInParam("@EPhone" ,SqlDbType.NVarChar,400,dt.EPhone),

				MakeInParam("@LoanPurpose",SqlDbType.NVarChar,500,dt.LoanPurpose),
				MakeInParam("@HousePaymentCircle",SqlDbType.Int,4,(int)dt.HousePaymentCircle),
				MakeInParam("@HousePaymentValue",SqlDbType.Money,8,dt.HousePaymentValue),
				MakeInParam("@OtherLenderCircle",SqlDbType.Int,4,(int)dt.OtherLenderCircle),
				MakeInParam("@OtherLenderValue",SqlDbType.Money,8,dt.OtherLenderValue),
				MakeInParam("@OtherSamllCreditHas",SqlDbType.Int,4,dt.OtherSamllCreditHas),
				MakeInParam("@OtherSmallCreditCount",SqlDbType.Int,4,dt.OtherSmallCreditCount)
			};
			return prams;
		}
		public EmployedDT GetOneDT(int id)
		{
			return (EmployedDT)GetOneItem(id);
		}

		public int Insert2(object ob)
		{
			int identity=-1;
			try 
			{
				DataSet ds=SqlHelper.ExecuteDataset(Common.Config.DataSource,CommandType.StoredProcedure,"proc_EmployedDB_Insert2", GetParameter(ob));
                identity=Convert.ToInt32(ds.Tables[0].Rows[0][0]);
			}
			catch(Exception ex)
			{
				throw ex;
			}
			return identity;
		}
	}
}
