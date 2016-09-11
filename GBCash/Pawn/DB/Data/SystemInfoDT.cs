/// <copyright> 英网A1999-2005 </copyright>
/// <version>1.0</version>
/// <author>季宝福</author>
/// <email>jizhe@msn.com</email>
/// <log date="2005年8月6日">创建</log>

using System;

namespace YingNet.WeiXing.DB.Data
{

	/// <summary>
	/// DepinfoDT的摘要说明。
	/// <summary>

	public class SystemInfoDT
	{
		/// <summary>
		/// 
		/// <summary>
		private double m_param2;
		public double param2
		{
			get
			{
				 return m_param2;
			}
			set
			{
				 m_param2 = value ;
			}
		}

		/// <summary>
		/// 多次还款的贷款下限
		/// <summary>
		private double m_lowerlimit2;
		public double lowerlimit2
		{
			get
			{
				 return m_lowerlimit2;
			}
			set
			{
				 m_lowerlimit2 = value ;
			}
		}

		/// <summary>
		/// 会员贷款上限
		/// <summary>
		private double m_upperlimit2;
		public double upperlimit2
		{
			get
			{
				 return m_upperlimit2;
			}
			set
			{
				 m_upperlimit2 = value ;
			}
		}

		/// <summary>
		/// 
		/// <summary>
		private double m_param1;
		public double param1
		{
			get
			{
				 return m_param1;
			}
			set
			{
				 m_param1 = value ;
			}
		}

		/// <summary>
		/// 月天数
		/// <summary>
		private double m_frequency;
		public double frequency
		{
			get
			{
				 return m_frequency;
			}
			set
			{
				 m_frequency = value ;
			}
		}

		/// <summary>
		/// 利息
		/// <summary>
		private double m_interest;
		public double interest
		{
			get
			{
				 return m_interest;
			}
			set
			{
				 m_interest = value ;
			}
		}

		/// <summary>
		/// 手续费
		/// <summary>
		private double m_poundage;
		public double poundage
		{
			get
			{
				 return m_poundage;
			}
			set
			{
				 m_poundage = value ;
			}
		}

		/// <summary>
		/// 最高贷款百分比
		/// <summary>
		private double m_percentage;
		public double percentage
		{
			get
			{
				 return m_percentage;
			}
			set
			{
				 m_percentage = value ;
			}
		}

		/// <summary>
		/// 首次贷款上限
		/// <summary>
		private double m_upperlimit;
		public double upperlimit
		{
			get
			{
				 return m_upperlimit;
			}
			set
			{
				 m_upperlimit = value ;
			}
		}

		/// <summary>
		/// 多次还款的贷款下限
		/// <summary>
		private double m_lowerlimit;
		public double lowerlimit
		{
			get
			{
				 return m_lowerlimit;
			}
			set
			{
				 m_lowerlimit = value ;
			}
		}

		/// <summary>
		/// 
		/// <summary>
		private int m_param3;
		public int param3
		{
			get
			{
				 return m_param3;
			}
			set
			{
				 m_param3 = value ;
			}
		}

		/// <summary>
		/// 
		/// <summary>
		private int m_param4;
		public int param4
		{
			get
			{
				 return m_param4;
			}
			set
			{
				 m_param4 = value ;
			}
		}

		/// <summary>
		/// 贷款日与第一次发工资日时间差（周）
		/// <summary>
		private int m_datediffw;
		public int datediffw
		{
			get
			{
				 return m_datediffw;
			}
			set
			{
				 m_datediffw = value ;
			}
		}

		/// <summary>
		/// 贷款日与第一次发工资日时间差（双周）
		/// <summary>
		private int m_datedifff;
		public int datedifff
		{
			get
			{
				 return m_datedifff;
			}
			set
			{
				 m_datedifff = value ;
			}
		}

		/// <summary>
		/// 贷款日与第一次发工资日时间差（月）
		/// <summary>
		private int m_datediffm;
		public int datediffm
		{
			get
			{
				 return m_datediffm;
			}
			set
			{
				 m_datediffm = value ;
			}
		}

		/// <summary>
		/// 	确定延展第一次付款日天数
		/// <summary>
		private int m_shortday;
		public int shortday
		{
			get
			{
				 return m_shortday;
			}
			set
			{
				 m_shortday = value ;
			}
		}

		/// <summary>
		/// 上限是否选择百分比,1:是,0:否
		/// <summary>
		private int m_IsPercent;
		public int IsPercent
		{
			get
			{
				 return m_IsPercent;
			}
			set
			{
				 m_IsPercent = value ;
			}
		}

		/// <summary>
		/// 	贷款延期次数
		/// <summary>
		private int m_yanqinum;
		public int yanqinum
		{
			get
			{
				 return m_yanqinum;
			}
			set
			{
				 m_yanqinum = value ;
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
		/// 还款次数
		/// <summary>
		private int m_installment;
		public int installment
		{
			get
			{
				 return m_installment;
			}
			set
			{
				 m_installment = value ;
			}
		}

		/// <summary>
		/// 贷款期限上限
		/// <summary>
		private int m_term;
		public int term
		{
			get
			{
				 return m_term;
			}
			set
			{
				 m_term = value ;
			}
		}

	}
}
