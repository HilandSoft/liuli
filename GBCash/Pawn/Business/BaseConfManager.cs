
using System;

namespace YingNet.WeiXing.Business
{
	/// <summary>
	/// ConfigManager ��ժҪ˵����
	/// </summary>
	public class BaseConfManager:WebConfigManager
	{
		public static WebConfigManager webConf = new WebConfigManager();

		public BaseConfManager()
		{
			//
			// TODO: �ڴ˴���ӹ��캯���߼�
			//
		}

		public static string GetKeyValue(string key)
		{
			return webConf.GetValue(key);
		}

		#region ��ȡ��ֵ
		/// <summary>
		/// ��ȡ���ݿ��������IP��ַ���߷�������
		/// </summary>
		/// <returns></returns>
		public static string GetDBServer()
		{
			return webConf.GetValue("DBServer");
		}

		/// <summary>
		/// ��ȡ���ݿ�����
		/// </summary>
		/// <returns></returns>
		public static string GetDBType()
		{
			return webConf.GetValue("DBType");
		}

		/// <summary>
		/// ��ȡ���ݿ���
		/// </summary>
		/// <returns></returns>
		public static string GetDBName()
		{
			return webConf.GetValue("DBName");
		}

		/// <summary>
		/// ��ȡ���ݿ��û���
		/// </summary>
		/// <returns></returns>
		public static string GetDBUser()
		{
			return webConf.GetValue("DBUser");
		}

		

		/// <summary>
		/// ��ȡ���ݿ��û�����
		/// </summary>
		/// <returns></returns>
		public static string GetDBPwd()
		{
			return webConf.GetValue("DBPwd");
		}

		/// <summary>
		/// ��ȡ��ǰӦ�õ�����
		/// </summary>
		/// <returns></returns>
		public static string GetAppName() 
		{
			return webConf.GetValue("AppName");
		}

		/// <summary>
		/// ��ȡ��Դ�ļ�����·��,�����Ӧ�õĸ�·��
		/// </summary>
		/// <returns></returns>
		public static string GetDiskName() 
		{
			return webConf.GetValue("DiskName");
		}

		/// <summary>
		/// ��ȡ�ʼ��������ĸ�����Ϣ
		/// </summary>
		/// <returns></returns>BaseConfManager.cs
		public static string GetMailSender()
		{
			return webConf.GetValue("MailSender");
		}
		public static string GetMailReceiver()
		{
			return webConf.GetValue("MailReceiver");
		} 
		public static string GetMailServer()
		{
			return webConf.GetValue("MailServer");
		}
		public static string GetMailUserName()
		{
			return webConf.GetValue("MailUserName");
		}
		public static string GetMailPassWord()
		{
			return webConf.GetValue("MailPassWord");
		}
		public static string GetImagePath()
		{
			return webConf.GetValue("imagePath");
		}
		public static string GetImagePath1()
		{
			return webConf.GetValue("imagePath1");
		}

		public static string GetPicPath()
		{
			return webConf.GetValue("PicPath");
		}

		public static string GetFilePath()
		{
			return webConf.GetValue("filePath");
		}
		public static string GetConnectionStr()
		{
			string connStr = "server="+BaseConfManager.GetDBServer()+";database="+BaseConfManager.GetDBName()+";user id="+BaseConfManager.GetDBUser()+";pwd="+BaseConfManager.GetDBPwd();
			return connStr;
		}
		#endregion
	}
}

