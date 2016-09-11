//<copyright>山东三维科技有限公司 1999-2004</copyright>
//<version>V1.0</verion>
//<createdate>2004-3-12</createdate>
//<author>wangyh</author>
//<email>wangyh@qingdaojob.com</email>
//<log date="2004-3-12">创建</log>


using System;


namespace YingNet.WeiXing.Business
{
	/// <summary>
	/// WebConfigManager 的摘要说明。
	/// </summary>
	public class WebConfigManager
	{
		public WebConfigManager()
		{
			//
			// TODO: 在此处添加构造函数逻辑
			//
		}

		/// <summary>
		/// 设定键值
		/// </summary>
		/// <param name="strKeyName"></param>
		/// <param name="strKeyValue"></param>
		/// <returns></returns>
		public void SetValue(string strKeyName, string strValue)
		{

		}

		/// <summary>
		/// 读取键值
		/// </summary>
		/// <param name="strKeyName"></param>
		/// <returns></returns>
		public string GetValue(string strKeyName)
		{
			return  System.Configuration.ConfigurationSettings.AppSettings[strKeyName];
		}

	}
}
