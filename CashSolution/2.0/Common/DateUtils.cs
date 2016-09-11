//<copyright>Ӣ����Ѷ�������޹�˾ 1999-2003</copyright>
//<version>V1.0</verion>
//<createdate>2003-7-24</createdate>
//<author>wuhp</author>
//<email>wuhp@qingdaojob.com</email>
//<log date="2003-7-24">����</log>

using System;

namespace YingNet.Common 
{
	/// <summary>
	/// ���ڲ������ù���
	/// </summary>
	public class DateUtils 
	{
		public DateUtils() 
		{
		}

		/// <summary>
		/// �Ƚ����ڵ���ݲ�
		/// </summary>
		/// <param name="start">��ʼ����</param>
		/// <returns>�뵱ǰ���ڵ���ݲ�</returns>
		public static int DiffYear (string start) 
		{
			return DiffYear(Convert.ToDateTime(start));
		}

		/// <summary>
		/// �Ƚ����ڵ���ݲ�
		/// </summary>
		/// <param name="start">��ʼ����</param>
		/// <param name="end">��������</param>
		/// <returns>��ݲ�</returns>
		public static int DiffYear (string start, string end) 
		{
			return DiffYear(Convert.ToDateTime(start), Convert.ToDateTime(end));
		}
        
		/// <summary>
		/// �Ƚ����ڵ���ݲ�
		/// </summary>
		/// <param name="start">��ʼ����</param>
		/// <returns>�뵱ǰ���ڵ���ݲ�</returns>
		public static int DiffYear (DateTime start) 
		{
			return (DiffYear(start, DateTime.Now));
		}

		/// <summary>
		/// �Ƚ��������ڵ���ݲ�
		/// </summary>
		/// <param name="start">��ʼ����</param>
		/// <param name="end">��������</param>
		/// <returns>��ݲ�</returns>
		public static int DiffYear (DateTime start, DateTime end) 
		{
			return (end.Year - start.Year);
		}

		/// <summary>
		/// ��ʽ������(yyyy-MM-dd)
		/// </summary>
		/// <param name="date">����ʽ��������</param>
		/// <returns>��ʽ����������ַ���</returns>
		public static string DateFormat (string date) 
		{
			return DateFormat(Convert.ToDateTime(date));
		}

		/// <summary>
		/// ��ʽ������
		/// </summary>
		/// <param name="date">����ʽ��������</param>
		/// <param name="format">��ʽ����</param>
		/// <returns>��ʽ����������ַ���</returns>
		public static string DateFormat (string date, string format) 
		{
			return DateFormat(Convert.ToDateTime(date), format);
		}

		/// <summary>
		/// ��ʽ������(yyyy-MM-dd)
		/// </summary>
		/// <param name="date">����ʽ��������</param>
		/// <returns>��ʽ����������ַ���</returns>
		public static string DateFormat (DateTime date) 
		{
			return DateFormat(date, "yyyy-MM-dd");
		}

		/// <summary>
		/// ��ʽ������
		/// </summary>
		/// <param name="date">����ʽ��������</param>
		/// <param name="format">��ʽ����</param>
		/// <returns>��ʽ����������ַ���</returns>
		public static string DateFormat (DateTime date, string format) 
		{
			return date.ToString(format);
		}

		/// <summary>
		/// ���һ��ʱ���Ƿ��ǺϷ��� MQSQL ��ʱ�䡣
		/// </summary>
		/// <param name="dt">������ʱ��</param>
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
