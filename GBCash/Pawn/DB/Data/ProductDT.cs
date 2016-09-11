using System;

namespace YingNet.WeiXing.DB.Data
{

	/// <summary>
	/// DepinfoDT的摘要说明。
	/// <summary>

	public class ProductDT
	{
		/// <summary>
		/// 
		/// <summary>
		private bool m_ProductIsTop;
		public bool ProductIsTop
		{
			get
			{
				 return m_ProductIsTop;
			}
			set
			{
				 m_ProductIsTop = value ;
			}
		}

		/// <summary>
		/// 
		/// <summary>
		private DateTime m_PubDate;
		public DateTime PubDate
		{
			get
			{
				 return m_PubDate;
			}
			set
			{
				 m_PubDate = value ;
			}
		}

		/// <summary>
		/// 
		/// <summary>
		private int m_PriductID;
		public int PriductID
		{
			get
			{
				 return m_PriductID;
			}
			set
			{
				 m_PriductID = value ;
			}
		}

		/// <summary>
		/// 
		/// <summary>
		private string m_ProductName;
		public string ProductName
		{
			get
			{
				 return m_ProductName;
			}
			set
			{
				 m_ProductName = value ;
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
		private string m_ProductTypeNo;
		public string ProductTypeNo
		{
			get
			{
				 return m_ProductTypeNo;
			}
			set
			{
				 m_ProductTypeNo = value ;
			}
		}

		/// <summary>
		/// 
		/// <summary>
		private string m_ProductInfo;
		public string ProductInfo
		{
			get
			{
				 return m_ProductInfo;
			}
			set
			{
				 m_ProductInfo = value ;
			}
		}

	}
}
