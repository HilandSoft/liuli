using System;
using YingNet.Common;

namespace YingNet.WeiXing.Business
{
	/// <summary>
	/// BaseManagePage ��ժҪ˵����
	/// </summary>
	public class BasePage : CommonBasePage 
	{
		public BasePage() : base() 
		{
			//
			// TODO: �ڴ˴���ӹ��캯���߼�
			//
		}
		/// <summary>
		/// ����
		/// </summary>
		public string WebAppTitle 
		{
			get
			{
				return WebAppConfig.WebAppTitle;
			}

		}

	
	}
}
