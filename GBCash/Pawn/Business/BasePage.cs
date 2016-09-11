using System;
using YingNet.Common;

namespace YingNet.WeiXing.Business
{
	/// <summary>
	/// BaseManagePage 的摘要说明。
	/// </summary>
	public class BasePage : CommonBasePage 
	{
		public BasePage() : base() 
		{
			//
			// TODO: 在此处添加构造函数逻辑
			//
		}
		/// <summary>
		/// 标题
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
