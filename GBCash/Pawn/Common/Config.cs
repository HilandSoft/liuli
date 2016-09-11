using System;

namespace YingNet.Common
{
	public class Config
	{
		
		private static string m_strDataSource = null;
		/// <summary>
		/// ���ݿ������ַ���
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
		/// ���ݿ��¼����ʹ�õĸ�ʽ
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
		/// ����ʹ�õ����ڸ�ʽ,����վǰ̨��ʾ�ĸ�ʽ
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
		/// ��ȡָ����������
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
