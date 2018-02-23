//<copyright>英网资讯技术有限公司 1999-2003</copyright>
//<version>V1.0</verion>
//<createdate>2003-7-24</createdate>
//<author>wuhp</author>
//<email>wuhp@qingdaojob.com</email>
//<log date="2003-7-24">创建</log>

using System;

namespace YingNet.Common 
{
	/// <summary>
	/// 日期操作常用工具
	/// </summary>
	public class DateUtils 
	{
		public DateUtils() 
		{
		}

		/// <summary>
		/// 比较日期的年份差
		/// </summary>
		/// <param name="start">开始日期</param>
		/// <returns>与当前日期的年份差</returns>
		public static int DiffYear (string start) 
		{
			return DiffYear(Convert.ToDateTime(start));
		}

		/// <summary>
		/// 比较日期的年份差
		/// </summary>
		/// <param name="start">开始日期</param>
		/// <param name="end">结束日期</param>
		/// <returns>年份差</returns>
		public static int DiffYear (string start, string end) 
		{
			return DiffYear(Convert.ToDateTime(start), Convert.ToDateTime(end));
		}
        
		/// <summary>
		/// 比较日期的年份差
		/// </summary>
		/// <param name="start">开始日期</param>
		/// <returns>与当前日期的年份差</returns>
		public static int DiffYear (DateTime start) 
		{
			return (DiffYear(start, DateTime.Now));
		}

		/// <summary>
		/// 比较两个日期的年份差
		/// </summary>
		/// <param name="start">开始日期</param>
		/// <param name="end">结束日期</param>
		/// <returns>年份差</returns>
		public static int DiffYear (DateTime start, DateTime end) 
		{
			return (end.Year - start.Year);
		}

		/// <summary>
		/// 格式化日期(yyyy-MM-dd)
		/// </summary>
		/// <param name="date">待格式化的日期</param>
		/// <returns>格式化后的日期字符串</returns>
		public static string DateFormat (string date) 
		{
			return DateFormat(Convert.ToDateTime(date));
		}

		/// <summary>
		/// 格式化日期
		/// </summary>
		/// <param name="date">待格式化的日期</param>
		/// <param name="format">格式化串</param>
		/// <returns>格式化后的日期字符串</returns>
		public static string DateFormat (string date, string format) 
		{
			return DateFormat(Convert.ToDateTime(date), format);
		}

		/// <summary>
		/// 格式化日期(yyyy-MM-dd)
		/// </summary>
		/// <param name="date">待格式化的日期</param>
		/// <returns>格式化后的日期字符串</returns>
		public static string DateFormat (DateTime date) 
		{
			return DateFormat(date, "yyyy-MM-dd");
		}

		/// <summary>
		/// 格式化日期
		/// </summary>
		/// <param name="date">待格式化的日期</param>
		/// <param name="format">格式化串</param>
		/// <returns>格式化后的日期字符串</returns>
		public static string DateFormat (DateTime date, string format) 
		{
			return date.ToString(format);
		}

		/// <summary>
		/// 检查一个时间是否是合法的 MQSQL 的时间。
		/// </summary>
		/// <param name="dt">待检查的时间</param>
		/// <returns></returns>
		public static bool IsSqlDateTime(DateTime dt)
		{
			try
			{
				new System.Data.SqlTypes.SqlDateTime(dt);
				return true;
			}
			catch
			{
				return false;
			}
		}
	}
}
