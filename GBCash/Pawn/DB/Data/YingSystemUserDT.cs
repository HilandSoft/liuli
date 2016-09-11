using System;
using System.Collections;

namespace YingNet.WeiXing.DB.Data
{
	
	/// <summary>
	/// DepinfoDT的摘要说明。
	/// <summary>
	
	public class YingSystemUserDT
	{
		/// <summary>
		/// 
		/// <summary>
		private Hashtable m_permit;
		public Hashtable permit
		{
			get
			{
				return m_permit;
			}
			set
			{
				m_permit = value ;
			}
		}

		/// <summary>
		/// 
		/// <summary>
		private bool m_isactive;
		public bool isactive
		{
			get
			{
				return m_isactive;
			}
			set
			{
				m_isactive = value ;
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
		private string m_account;
		public string account
		{
			get
			{
				return m_account;
			}
			set
			{
				m_account = value ;
			}
		}

		/// <summary>
		/// 
		/// <summary>
		private string m_password;
		public string password
		{
			get
			{
				return m_password;
			}
			set
			{
				m_password = value ;
			}
		}

		/// <summary>
		/// 
		/// <summary>
		private string m_deptpermit;
		public string deptpermit
		{
			get
			{
				return m_deptpermit;
			}
			set
			{
				m_deptpermit = value ;
			}
		}
		/// <summary>
		/// 
		/// <summary>
		private string m_name;
		public string name
		{
			get
			{
				return m_name;
			}
			set
			{
				m_name = value ;
			}
		}

	}
}
