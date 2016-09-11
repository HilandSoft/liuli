/// <copyright> 英网A1999-2005 </copyright>
/// <version>1.0</version>
/// <author>季宝福</author>
/// <email>jizhe@msn.com</email>
/// <log date="2005年9月16日">创建</log>

using System;

namespace YingNet.WeiXing.DB.Data
{

	/// <summary>
	/// DepinfoDT的摘要说明。
	/// <summary>

	public class InfoDT
	{
		/// <summary>
		/// 
		/// <summary>
		private DateTime m_regtime;
		public DateTime regtime
		{
			get
			{
				 return m_regtime;
			}
			set
			{
				 m_regtime = value ;
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
		/// 
		/// <summary>
		private int m_isvalid;
		public int isvalid
		{
			get
			{
				 return m_isvalid;
			}
			set
			{
				 m_isvalid = value ;
			}
		}

		/// <summary>
		/// 
		/// <summary>
		private string m_param2;
		public string param2
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
		/// 
		/// <summary>
		private string m_param3;
		public string param3
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
		private string m_Username;
		public string Username
		{
			get
			{
				 return m_Username;
			}
			set
			{
				 m_Username = value ;
			}
		}

		/// <summary>
		/// 
		/// <summary>
		private string m_type;
		public string type
		{
			get
			{
				 return m_type;
			}
			set
			{
				 m_type = value ;
			}
		}

		/// <summary>
		/// 
		/// <summary>
		private string m_param1;
		public string param1
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

	}
}
