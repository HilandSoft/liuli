using System;

namespace YingNet.WeiXing.DB.Data
{

	/// <summary>
	/// DepinfoDT的摘要说明。
	/// <summary>

	public class YingInfoTypeDT
	{
		/// <summary>
		/// 
		/// <summary>
		private bool m_Has_Sub;
		public bool Has_Sub
		{
			get
			{
				 return m_Has_Sub;
			}
			set
			{
				 m_Has_Sub = value ;
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
		private string m_Num;
		public string Num
		{
			get
			{
				 return m_Num;
			}
			set
			{
				 m_Num = value ;
			}
		}

		/// <summary>
		/// 
		/// <summary>
		private string m_TypeName;
		public string TypeName
		{
			get
			{
				 return m_TypeName;
			}
			set
			{
				 m_TypeName = value ;
			}
		}

		/// <summary>
		/// 
		/// <summary>
		private string m_Parent;
		public string Parent
		{
			get
			{
				 return m_Parent;
			}
			set
			{
				 m_Parent = value ;
			}
		}

	}
}
