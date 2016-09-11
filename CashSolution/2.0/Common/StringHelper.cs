using System;

namespace YingNet.Common
{
	/// <summary>
	/// StringHelper 的摘要说明。
	/// </summary>
	public class StringHelper
	{
		public static bool IsNullOrEmpty(string target)
		{
			if(target==null)
			{
				return true;
			}
			else
			{
				if(target== string.Empty)
				{
					return true;
				}
			}

			return false;
		}
	}
}
