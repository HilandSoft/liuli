/// <copyright> 英网A1999-2005 </copyright>
/// <version>1.0</version>
/// <author>季宝福</author>
/// <email>jizhe@msn.com</email>
/// <log date="2005年8月11日">创建</log>

using System;

namespace YingNet.WeiXing.DB.Data
{

	/// <summary>
	/// DepinfoDT的摘要说明。
	/// <summary>

	public class ScheduleDT
	{
		/// <summary>
		/// 
		/// <summary>
		private DateTime m_Datedue;
		public DateTime Datedue
		{
			get
			{
				 return m_Datedue;
			}
			set
			{
				 m_Datedue = value ;
			}
		}

		/// <summary>
		/// 
		/// <summary>
		private DateTime m_RepayTime;
		public DateTime RepayTime
		{
			get
			{
				 return m_RepayTime;
			}
			set
			{
				 m_RepayTime = value ;
			}
		}

		/// <summary>
		/// 
		/// <summary>
		private DateTime m_OperateTime;
		public DateTime OperateTime
		{
			get
			{
				 return m_OperateTime;
			}
			set
			{
				 m_OperateTime = value ;
			}
		}

		/// <summary>
		/// 罚款
		/// <summary>
		private double m_Penalty;
		public double Penalty
		{
			get
			{
				 return m_Penalty;
			}
			set
			{
				 m_Penalty = value ;
			}
		}

		/// <summary>
		/// 结余
		/// <summary>
		private double m_Balance;
		public double Balance
		{
			get
			{
				 return m_Balance;
			}
			set
			{
				 m_Balance = value ;
			}
		}

		/// <summary>
		/// 
		/// <summary>
		private double m_Repaydue;
		public double Repaydue
		{
			get
			{
				 return m_Repaydue;
			}
			set
			{
				 m_Repaydue = value ;
			}
		}

		/// <summary>
		/// 
		/// <summary>
		private double m_Param5;
		public double Param5
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
		/// 已经付款
		/// <summary>
		private double m_Paid;
		public double Paid
		{
			get
			{
				 return m_Paid;
			}
			set
			{
				 m_Paid = value ;
			}
		}

		/// <summary>
		/// 相应第几次贷款
		/// <summary>
		private int m_Numberment;
		public int Numberment
		{
			get
			{
				 return m_Numberment;
			}
			set
			{
				 m_Numberment = value ;
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
		/// 是否有效
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
		/// 外键,关联Employed
		/// <summary>
		private string m_Param1;
		public string Param1
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
		/// 是否贷款延期,1:是,0:否
		/// <summary>
		private string m_Param2;
		public string Param2
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
		/// 
		/// <summary>
		private string m_Param3;
		public string Param3
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

	}
}
