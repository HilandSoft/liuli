using System;
using System.Configuration;

namespace YingNet.WeiXing.Business.CommonLogic
{
	/// <summary>
	/// CommonInformation ��ժҪ˵����
	/// </summary>
	public class CommonInformation
	{
		public CommonInformation()
		{
			//
			// TODO: �ڴ˴���ӹ��캯���߼�
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
