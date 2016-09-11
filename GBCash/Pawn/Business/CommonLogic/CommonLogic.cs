using System;
using System.Configuration;

namespace YingNet.WeiXing.Business.CommonLogic
{
	/// <summary>
	/// CommonInformation 的摘要说明。
	/// </summary>
	public class CommonInformation
	{
		public CommonInformation()
		{
			//
			// TODO: 在此处添加构造函数逻辑
			//
		}
		
		public static int CurrentVersion
		{
			get
			{
				int temp = 2;

				try
				{
					if(ConfigurationSettings.AppSettings["CurrentVersion"]!=null && ConfigurationSettings.AppSettings["CurrentVersion"]!=string.Empty)
					{
						temp = Convert.ToInt32(ConfigurationSettings.AppSettings["CurrentVersion"]);
					}
				}
				catch{}
				return temp;
			}
		}
	}
}
