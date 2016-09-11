
using System;

namespace YingNet.WeiXing.Business
{
	/// <summary>
	/// ConfigManager 的摘要说明。
	/// </summary>
	public class BaseConfManager:WebConfigManager
	{
		public static WebConfigManager webConf = new WebConfigManager();

		public BaseConfManager()
		{
			//
			// TODO: 在此处添加构造函数逻辑
			//
		}

		public static string GetKeyValue(string key)
		{
			return webConf.GetValue(key);
		}

		#region 读取键值
		/// <summary>
		/// 读取数据库服务器的IP地址或者服务器名
		/// </summary>
		/// <returns></returns>
		public static string GetDBServer()
		{
			return webConf.GetValue("DBServer");
		}

		/// <summary>
		/// 读取数据库类型
		/// </summary>
		/// <returns></returns>
		public static string GetDBType()
		{
			return webConf.GetValue("DBType");
		}

		/// <summary>
		/// 读取数据库名
		/// </summary>
		/// <returns></returns>
		public static string GetDBName()
		{
			return webConf.GetValue("DBName");
		}

		/// <summary>
		/// 读取数据库用户名
		/// </summary>
		/// <returns></returns>
		public static string GetDBUser()
		{
			return webConf.GetValue("DBUser");
		}

		

		/// <summary>
		/// 读取数据库用户密码
		/// </summary>
		/// <returns></returns>
		public static string GetDBPwd()
		{
			return webConf.GetValue("DBPwd");
		}

		/// <summary>
		/// 读取当前应用的名称
		/// </summary>
		/// <returns></returns>
		public static string GetAppName() 
		{
			return webConf.GetValue("AppName");
		}

		/// <summary>
		/// 读取资源文件保存路径,相对于应用的根路径
		/// </summary>
		/// <returns></returns>
		public static string GetDiskName() 
		{
			return webConf.GetValue("DiskName");
		}

		/// <summary>
		/// 读取邮件服务器的各种信息
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

