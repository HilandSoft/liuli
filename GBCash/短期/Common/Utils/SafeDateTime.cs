using System;

namespace YingNet.Common.Utils
{
	/// <summary>
	/// SafeDateTime ��ժҪ˵����
	/// </summary>
	public class SafeDateTime
	{
		public SafeDateTime()
		{
			//
			// TODO: �ڴ˴���ӹ��캯���߼�
			//
		}

		private static int zoneDiff=25;
		/// <summary>
		/// ����ʱ�����������ʱ��
		/// </summary>
		public static int ZoneDiff
		{
			get
			{
				if(zoneDiff==25)
				{
					string temp= Config.AppSetting("ZoneDiff");
					if(temp==null || temp==string.Empty)
					{
						zoneDiff=0;
					}
					else
					{
						zoneDiff= Convert.ToInt32(temp);
					}
				}

				return zoneDiff;
			}
		}


		public static DateTime LocalNow
		{
			get
			{
				return DateTime.Now.AddHours(ZoneDiff);
			}
		}


		public static DateTime LocalToday
		{
			get
			{
				return LocalNow.Date;
			}
		}
	}
}
