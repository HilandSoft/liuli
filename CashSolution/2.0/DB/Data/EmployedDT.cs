/// <copyright> 英网A1999-2005 </copyright>
/// <version>1.0</version>
/// <author>季宝福</author>
/// <email>jizhe@msn.com</email>
/// <log date="2005年8月11日">创建</log>

using System;
using YingNet.WeiXing.STRUCTURE;

namespace YingNet.WeiXing.DB.Data
{

	/// <summary>
	/// DepinfoDT的摘要说明。
	/// <summary>
	public class EmployedDT
	{
		/// <summary>
		/// 贷款时间
		/// <summary>
		private DateTime m_RTime;
		public DateTime RTime
		{
			get
			{
				 return m_RTime;
			}
			set
			{
				 m_RTime = value ;
			}
		}

		/// <summary>
		/// 手续费总额
		/// <summary>
		private double m_Param2;
		public double Param2
		{
			get
			{
				 return m_Param2;
			}
			set
			{
				 m_Param2 = value ;
			}
		}

		/// <summary>
		/// 利息
		/// <summary>
		private double m_Interest;
		public double Interest
		{
			get
			{
				 return m_Interest;
			}
			set
			{
				 m_Interest = value ;
			}
		}

		/// <summary>
		/// 支付周期
		/// <summary>
		private double m_Frequency;
		public double Frequency
		{
			get
			{
				 return m_Frequency;
			}
			set
			{
				 m_Frequency = value ;
			}
		}

		/// <summary>
		/// 还款总额
		/// <summary>
		private double m_Param1;
		public double Param1
		{
			get
			{
				 return m_Param1;
			}
			set
			{
				 m_Param1 = value ;
			}
		}

		/// <summary>
		/// 居第一次付款日的天数
		/// <summary>
		private int m_XDay;
		public int XDay
		{
			get
			{
				 return m_XDay;
			}
			set
			{
				 m_XDay = value ;
			}
		}

		/// <summary>
		/// 第几次贷款
		/// <summary>
		private int m_Param3;
		public int Param3
		{
			get
			{
				 return m_Param3;
			}
			set
			{
				 m_Param3 = value ;
			}
		}

		/// <summary>
		/// 会员SID,外键
		/// <summary>
		private int m_huiSid;
		public int huiSid
		{
			get
			{
				 return m_huiSid;
			}
			set
			{
				 m_huiSid = value ;
			}
		}

		/// <summary>
		/// 是否被雇佣 1:被 0:否
		/// <summary>
		private int m_IsEmployed;
		public int IsEmployed
		{
			get
			{
				 return m_IsEmployed;
			}
			set
			{
				 m_IsEmployed = value ;
			}
		}

		/// <summary>
		/// 1 有效(偿还完毕),0 无效,2:偿还进行中,3:未决的
		/// <summary>
		private int m_IsValid;
		public int IsValid
		{
			get
			{
				 return m_IsValid;
			}
			set
			{
				 m_IsValid = value ;
			}
		}

		/// <summary>
		/// 还款次数
		/// <summary>
		private int m_NInstallment;
		public int NInstallment
		{
			get
			{
				 return m_NInstallment;
			}
			set
			{
				 m_NInstallment = value ;
			}
		}

		/// <summary>
		/// 
		/// <summary>
		private int m_NDayMM;
		public int NDayMM
		{
			get
			{
				 return m_NDayMM;
			}
			set
			{
				 m_NDayMM = value ;
			}
		}

		/// <summary>
		/// 
		/// <summary>
		private int m_NDayDD;
		public int NDayDD
		{
			get
			{
				 return m_NDayDD;
			}
			set
			{
				 m_NDayDD = value ;
			}
		}

		/// <summary>
		/// 
		/// <summary>
		private int m_NDayYY;
		public int NDayYY
		{
			get
			{
				 return m_NDayYY;
			}
			set
			{
				 m_NDayYY = value ;
			}
		}

		/// <summary>
		/// 
		/// <summary>
		private int m_id;
		public int id
		{
			get
			{
				 return m_id;
			}
			set
			{
				 m_id = value ;
			}
		}

		/// <summary>
		/// 
		/// <summary>
		private int m_TYears;
		public int TYears
		{
			get
			{
				 return m_TYears;
			}
			set
			{
				 m_TYears = value ;
			}
		}

		/// <summary>
		/// 
		/// <summary>
		private int m_TMonths;
		public int TMonths
		{
			get
			{
				 return m_TMonths;
			}
			set
			{
				 m_TMonths = value ;
			}
		}

		/// <summary>
		/// Monthly Benefit
		/// <summary>
		private float m_MIncome;
		public float MIncome
		{
			get
			{
				 return m_MIncome;
			}
			set
			{
				 m_MIncome = value ;
			}
		}

		/// <summary>
		/// 贷款金额
		/// <summary>
		private float m_Loan;
		public float Loan
		{
			get
			{
				 return m_Loan;
			}
			set
			{
				 m_Loan = value ;
			}
		}

		/// <summary>
		/// 
		/// <summary>
		private string m_Rnum3;
		public string Rnum3
		{
			get
			{
				 return m_Rnum3;
			}
			set
			{
				 m_Rnum3 = value ;
			}
		}

		/// <summary>
		/// 
		/// <summary>
		private string m_Param4;
		public string Param4
		{
			get
			{
				 return m_Param4;
			}
			set
			{
				 m_Param4 = value ;
			}
		}

		/// <summary>
		/// 
		/// <summary>
		private string m_Param5;
		public string Param5
		{
			get
			{
				 return m_Param5;
			}
			set
			{
				 m_Param5 = value ;
			}
		}

		/// <summary>
		/// 
		/// <summary>
		private string m_Rnum2;
		public string Rnum2
		{
			get
			{
				 return m_Rnum2;
			}
			set
			{
				 m_Rnum2 = value ;
			}
		}

		/// <summary>
		/// 
		/// <summary>
		private string m_Rname3;
		public string Rname3
		{
			get
			{
				 return m_Rname3;
			}
			set
			{
				 m_Rname3 = value ;
			}
		}

		/// <summary>
		/// 
		/// <summary>
		private string m_Rship3;
		public string Rship3
		{
			get
			{
				 return m_Rship3;
			}
			set
			{
				 m_Rship3 = value ;
			}
		}

		/// <summary>
		/// 
		/// <summary>
		private string m_Rnum1;
		public string Rnum1
		{
			get
			{
				 return m_Rnum1;
			}
			set
			{
				 m_Rnum1 = value ;
			}
		}

		/// <summary>
		/// 
		/// <summary>
		private string m_Rname2;
		public string Rname2
		{
			get
			{
				 return m_Rname2;
			}
			set
			{
				 m_Rname2 = value ;
			}
		}

		/// <summary>
		/// 
		/// <summary>
		private string m_Rship2;
		public string Rship2
		{
			get
			{
				 return m_Rship2;
			}
			set
			{
				 m_Rship2 = value ;
			}
		}

		/// <summary>
		/// 
		/// <summary>
		private string m_MContact;
		public string MContact
		{
			get
			{
				 return m_MContact;
			}
			set
			{
				 m_MContact = value ;
			}
		}

		/// <summary>
		/// 
		/// <summary>
		private string m_Rname1;
		public string Rname1
		{
			get
			{
				 return m_Rname1;
			}
			set
			{
				 m_Rname1 = value ;
			}
		}

		/// <summary>
		/// 
		/// <summary>
		private string m_Rship1;
		public string Rship1
		{
			get
			{
				 return m_Rship1;
			}
			set
			{
				 m_Rship1 = value ;
			}
		}

		/// <summary>
		/// 
		/// <summary>
		private string m_AName;
		public string AName
		{
			get
			{
				 return m_AName;
			}
			set
			{
				 m_AName = value ;
			}
		}

		/// <summary>
		/// 
		/// <summary>
		private string m_Bsb;
		public string Bsb
		{
			get
			{
				 return m_Bsb;
			}
			set
			{
				 m_Bsb = value ;
			}
		}

		/// <summary>
		/// 
		/// <summary>
		private string m_ANumber;
		public string ANumber
		{
			get
			{
				 return m_ANumber;
			}
			set
			{
				 m_ANumber = value ;
			}
		}

		/// <summary>
		/// 
		/// <summary>
		private string m_Wpaid;
		public string Wpaid
		{
			get
			{
				 return m_Wpaid;
			}
			set
			{
				 m_Wpaid = value ;
			}
		}

		/// <summary>
		/// 
		/// <summary>
		private string m_Branch;
		public string Branch
		{
			get
			{
				 return m_Branch;
			}
			set
			{
				 m_Branch = value ;
			}
		}

		/// <summary>
		/// 
		/// <summary>
		private string m_BankName;
		public string BankName
		{
			get
			{
				 return m_BankName;
			}
			set
			{
				 m_BankName = value ;
			}
		}

		/// <summary>
		/// Type of benefit
		/// <summary>
		private string m_Employer;
		public string Employer
		{
			get
			{
				 return m_Employer;
			}
			set
			{
				 m_Employer = value ;
			}
		}

		/// <summary>
		/// Centreline Office
		/// <summary>
		private string m_EAddress;
		public string EAddress
		{
			get
			{
				 return m_EAddress;
			}
			set
			{
				 m_EAddress = value ;
			}
		}

		/// <summary>
		/// Contact Name
		/// <summary>
		private string m_EPhone;
		public string EPhone
		{
			get
			{
				 return m_EPhone;
			}
			set
			{
				 m_EPhone = value ;
			}
		}

		private string loanPurpose= string.Empty;
		/// <summary>		/// 贷款目的		/// </summary>
		public string LoanPurpose
		{
			get{return this.loanPurpose;}
			set{this.loanPurpose=value;}
		}

		private float housePaymentValue=0F;
		/// <summary>		/// 住房费用		/// </summary>
		public float HousePaymentValue
		{
			get{return this.housePaymentValue;}
			set{this.housePaymentValue=value;}
		}


		private HousePaymentCircles housePaymentCircle= HousePaymentCircles.NonSet;
		/// <summary>		/// 住房费用还款周期		/// </summary>
		public HousePaymentCircles HousePaymentCircle
		{
			get{return this.housePaymentCircle;}
			set{this.housePaymentCircle=value;}
		}


		private float otherLenderValue=0F;
		/// <summary>		/// 其他的贷款费用		/// </summary>
		public float OtherLenderValue
		{
			get{return this.otherLenderValue;}
			set{this.otherLenderValue=value;}
		}


		private OtherLenderCircles otherLenderCircle= OtherLenderCircles.NonSet;
		/// <summary>		/// 其他的贷款还款周期		/// </summary>
		public OtherLenderCircles OtherLenderCircle
		{
			get{return this.otherLenderCircle;}
			set{this.otherLenderCircle=value;}
		}

		private int otherSamllCreditHas=0;
		/// <summary>		/// 是否有其他的小额贷款经历		/// </summary>
		public int OtherSamllCreditHas
		{
			get{return this.otherSamllCreditHas;}
			set{this.otherSamllCreditHas=value;}
		}

		private int otherSmallCreditCount=0;
		/// <summary>		/// 其他的小额贷款的数目		/// </summary>
		public int OtherSmallCreditCount
		{
			get{return this.otherSmallCreditCount;}
			set{this.otherSmallCreditCount=value;}
		}
	}

	
}