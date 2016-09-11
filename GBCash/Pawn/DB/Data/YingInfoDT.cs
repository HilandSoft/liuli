using System;

namespace YingNet.WeiXing.DB.Data
{

	/// <summary>
	/// DepinfoDT的摘要说明。
	/// <summary>

	public class YingInfoDT
	{
		/// <summary>
		/// 
		/// <summary>
		private bool m_InfoIsTop;
		public bool InfoIsTop
		{
			get
			{
				 return m_InfoIsTop;
			}
			set
			{
				 m_InfoIsTop = value ;
			}
		}

		/// <summary>
		/// 
		/// <summary>
		private DateTime m_InfoPubDate;
		public DateTime InfoPubDate
		{
			get
			{
				 return m_InfoPubDate;
			}
			set
			{
				 m_InfoPubDate = value ;
			}
		}

		/// <summary>
		/// 
		/// <summary>
		private int m_InfoID;
		public int InfoID
		{
			get
			{
				 return m_InfoID;
			}
			set
			{
				 m_InfoID = value ;
			}
		}

		/// <summary>
		/// 
		/// <summary>
		private string m_InfoTitle;
		public string InfoTitle
		{
			get
			{
				 return m_InfoTitle;
			}
			set
			{
				 m_InfoTitle = value ;
			}
		}

		/// <summary>
		/// 
		/// <summary>
		private string m_ImgPath;
		public string ImgPath
		{
			get
			{
				 return m_ImgPath;
			}
			set
			{
				 m_ImgPath = value ;
			}
		}

		/// <summary>
		/// 
		/// <summary>
		private string m_InfoTypeNo;
		public string InfoTypeNo
		{
			get
			{
				 return m_InfoTypeNo;
			}
			set
			{
				 m_InfoTypeNo = value ;
			}
		}

		/// <summary>
		/// 
		/// <summary>
		private string m_InfoContent;
		public string InfoContent
		{
			get
			{
				 return m_InfoContent;
			}
			set
			{
				 m_InfoContent = value ;
			}
		}

	}
}
