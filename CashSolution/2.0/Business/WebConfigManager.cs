//<copyright>ɽ����ά�Ƽ����޹�˾ 1999-2004</copyright>
//<version>V1.0</verion>
//<createdate>2004-3-12</createdate>
//<author>wangyh</author>
//<email>wangyh@qingdaojob.com</email>
//<log date="2004-3-12">����</log>


using System;


namespace YingNet.WeiXing.Business
{
	/// <summary>
	/// WebConfigManager ��ժҪ˵����
	/// </summary>
	public class WebConfigManager
	{
		public WebConfigManager()
		{
			//
			// TODO: �ڴ˴���ӹ��캯���߼�
			//
		}

		/// <summary>
		/// �趨��ֵ
		/// </summary>
		/// <param name="strKeyName"></param>
		/// <param name="strKeyValue"></param>
		/// <returns></returns>
		public void SetValue(string strKeyName, string strValue)
		{

		}

		/// <summary>
		/// ��ȡ��ֵ
		/// </summary>
		/// <param name="strKeyName"></param>
		/// <returns></returns>
		public string GetValue(string strKeyName)
		{
			return  System.Configuration.ConfigurationSettings.AppSettings[strKeyName];
		}

	}
}
