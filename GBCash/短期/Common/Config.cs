using System;

namespace YingNet.Common
{
	public class Config
	{
		
		private static string m_strDataSource = null;
		/// <summary>
		/// 数据库连接字符串
		/// </summary>
		public static string DataSource
		{
			get
			{
				if( m_strDataSource == null )
				{
					m_strDataSource = System.Configuration.ConfigurationSettings.AppSettings["ConnectionString"] ;
				}
				return m_strDataSource;
			}
			set
			{
				m_strDataSource = value;
			}
		}

		private static string dateRecordFormat= "MM/dd/yyyy";
		/// <summary>
		/// 数据库记录日期使用的格式
		/// </summary>
		public static string DateRecordFormat
		{
			get
			{
				string temp= System.Configuration.ConfigurationSettings.AppSettings["DateRecordFormat"] ;
				if(temp!=null && temp!=string.Empty)
				{
					dateRecordFormat= temp;
				}

				return dateRecordFormat;
			}
		}

		private static string dateDisplayFormat= "dd/MM/yyyy";
		/// <summary>
		/// 澳洲使用的日期格式,在网站前台显示的格式
		/// </summary>
		public static string DateDisplayFormat
		{
			get
			{
				string temp= System.Configuration.ConfigurationSettings.AppSettings["DateDisplayFormat"] ;
				if(temp!=null && temp!=string.Empty)
				{
					dateDisplayFormat= temp;
				}

				return dateDisplayFormat;
			}
		}

		/// <summary>
		/// 获取指定的设置项
		/// </summary>
		/// <param name="stettingName"></param>
		/// <returns></returns>
		public static string AppSetting(string stettingName)
		{
			string temp= System.Configuration.ConfigurationSettings.AppSettings[stettingName] ;
			return temp;
		}

	}
}
