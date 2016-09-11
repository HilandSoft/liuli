using System;
using System.IO;
using System.Text;

namespace YingNet.WeiXing.Business
{
	/// <summary>
	/// WebAppConfig 的摘要说明。
	/// </summary>
	public class WebAppConfig
	{
		protected static string m_WebAppTitle=null;
		
		public static string WebAppTitle
		{
			get
			{
				if ( m_WebAppTitle == null )
				{
					m_WebAppTitle = System.Configuration.ConfigurationSettings.AppSettings["WebAppTitle"];
					if ( m_WebAppTitle == null )
					{
						m_WebAppTitle = "YingNetWebAppTitle By Jibf";
					}
				}

				return m_WebAppTitle;
			}
		}
		
		protected static string m_CNProductPath=null;

		public static string CNProductPath
		{
			get
			{
				if ( m_CNProductPath == null )
				{
					m_CNProductPath = System.Configuration.ConfigurationSettings.AppSettings["CNProductPath"];
					if ( m_CNProductPath == null )
					{
						m_CNProductPath = "DefCNProductPicPath";
					}
				}

				return m_CNProductPath;
			}
		}

		protected static string m_ENProductPath=null;
		public static string ENProductPath
		{
			get
			{
				if ( m_ENProductPath == null )
				{
					m_ENProductPath = System.Configuration.ConfigurationSettings.AppSettings["ENProductPath"];
					if ( m_ENProductPath == null )
					{
						m_ENProductPath = "DefENProductPicPath";
					}
				}

				return m_ENProductPath;
			}
		}
		
		protected static string m_NewsPath=null;
		public static string NewsPath
		{
			get
			{
				if ( m_NewsPath == null )
				{
					m_NewsPath = System.Configuration.ConfigurationSettings.AppSettings["NewsPath"];
					if ( m_NewsPath == null )
					{
						m_NewsPath = "NewsPath";
					}
				}

				return m_NewsPath;
			}
		}

		protected static string m_VideoFilePath=null;
		public static string VideoFilePath
		{
			get
			{
				if ( m_VideoFilePath == null )
				{
					m_VideoFilePath = System.Configuration.ConfigurationSettings.AppSettings["VideoFilePath"];
					if ( m_VideoFilePath == null )
					{
						m_VideoFilePath = "VideoFilePath";
					}
				}

				return m_VideoFilePath;
			}
		}
		

		public static string GetFileExName(string filename)
		{
			int index=filename.LastIndexOf(".");
			if(index>0)
			{
				return filename.Substring(index);
			}
			return "";
		}

		public static String ToHtml(string str) 
		{
			if (str == null || str.Equals("")) 
			{
				return str;
			}
			str = str.Replace(  "\r\n", "<br>" );
			str = str.Replace(  "\r", "<br>" );
			str = str.Replace(  " ", "&nbsp;" );
			return str;
		}
	}
}
