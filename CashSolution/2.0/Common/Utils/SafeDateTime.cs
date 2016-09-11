using System;

namespace YingNet.Common.Utils
{
	/// <summary>
	/// SafeDateTime 的摘要说明。
	/// </summary>
	public class SafeDateTime
	{
		public SafeDateTime()
		{
			//
			// TODO: 在此处添加构造函数逻辑
			//
		}

		private static int zoneDiff=25;
		/// <summary>
		/// 本地时间跟服务器的时差
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
