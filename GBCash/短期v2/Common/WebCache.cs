using System;
using System.Collections;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Caching;

namespace TunyNet.Caching
{
	/// <summary>
	/// ����Web�еĻ���
	/// </summary>
	/// <remarks>
	/// <c>WebCache</c>��Ҫ���System.Web.Caching.Cache���з�װ���ṩ���Ѻõķ�����ʵ�ֻ���Ĳ���
	/// </remarks>
	public class WebCache
	{
		/// <summary>
		/// WebCache˽�й��캯��
		/// </summary>
		private WebCache() { }

		/// <summary>
		/// WebCache��̬���캯��
		/// </summary>
		static WebCache()
		{
			HttpContext context = HttpContext.Current;
			if (context != null)
				_cache = context.Cache;
			else
				_cache = HttpRuntime.Cache;
		}

		//>> Based on Factor = 5 default value

		/// <summary>
		/// ������
		/// </summary>
		public static readonly int DayFactor = 17280;

		/// <summary>
		/// Сʱ����
		/// </summary>
		public static readonly int HourFactor = 720;

		/// <summary>
		/// ��������
		/// </summary>
		public static readonly int MinuteFactor = 12;

		/// <summary>
		/// ������
		/// </summary>
		/// <note type="implementnotes">����ֱ��ʹ��SecondFactor������ʹ��SecondFactorCalculate(int)</note>
		private static readonly double SecondFactor = 0.2;

		private static int Factor = 5;
		private static readonly Cache _cache;

		/// <summary>
		/// �����������(�����������ʱ��)
		/// </summary>
		/// <param name="cacheFactor">����Ļ�������</param>
		public static void ReSetFactor(int cacheFactor)
		{
			Factor = cacheFactor;
		}

		/// <summary>
		/// �Ƿ����cacheKey�Ļ�����
		/// </summary>
		public static bool Contains(string cacheKey)
		{
			IDictionaryEnumerator cacheEnum = _cache.GetEnumerator();
			while (cacheEnum.MoveNext())
			{
				if (cacheEnum.Key.ToString().Equals(cacheKey))
					return true;
			}
			return false;
		}

		/// <summary>
		/// �ӻ�����������л�����
		/// </summary>
		public static void Clear()
		{
			IDictionaryEnumerator cacheEnum = _cache.GetEnumerator();
			
			while (cacheEnum.MoveNext())
			{
				_cache.Remove(cacheEnum.Key.ToString());
			}
		}

		/// <summary>
		/// ģ���Ƴ������еĻ�����
		/// </summary>
		/// <param name="pattern">Ҫ�Ƴ��Ļ�����ƥ��ģʽ</param>
		public static void RemoveByPattern(string pattern)
		{
			IDictionaryEnumerator cacheEnum = _cache.GetEnumerator();
			Regex regex = new Regex(pattern, RegexOptions.IgnoreCase | RegexOptions.Singleline | RegexOptions.Compiled);
			while (cacheEnum.MoveNext())
			{
				if (regex.IsMatch(cacheEnum.Key.ToString()))
					_cache.Remove(cacheEnum.Key.ToString());
			}
		}

		/// <summary>
		/// �Ƴ�ָ���Ļ�����
		/// </summary>
		/// <param name="key">Ҫ�Ƴ��Ļ������ʶ</param>
		public static void Remove(string key)
		{
			_cache.Remove(key);
		}

		#region Insert

		/// <overloads>���뻺����</overloads>
		/// <summary>
		/// ���뻺����
		/// </summary>
		/// <param name="key">�������ʶ</param>
		/// <param name="obj">������</param>
		/// <param name="dep">��������<see cref="System.Web.Caching.CacheDependency"/></param>
		public static void Insert(string key, object obj, CacheDependency dep)
		{
			Insert(key, obj, dep, HourFactor * 12);
		}

		/// <summary>
		/// ���뻺����
		/// </summary>
		/// <param name="key">�������ʶ</param>
		/// <param name="obj">������</param>
		/// <param name="secondsBase">���������(���������ļ���ΪFactor * secondsBase) </param>
		public static void Insert(string key, object obj, int secondsBase)
		{
			Insert(key, obj, null, secondsBase);
		}

		/// <summary>
		/// ���뻺����
		/// </summary>
		/// <param name="key">�������ʶ</param>
		/// <param name="obj">������</param>
		/// <param name="secondsBase">���������(���������ļ���ΪFactor * secondsBase) </param>
		/// <param name="dep">�������ȼ�<see cref="System.Web.Caching.CacheItemPriority"/></param>
		public static void Insert(string key, object obj, int secondsBase, CacheItemPriority priority)
		{
			Insert(key, obj, null, secondsBase, priority);
		}

		/// <summary>
		/// ���뻺����
		/// </summary>
		/// <param name="key">�������ʶ</param>
		/// <param name="obj">������</param>
		/// <param name="dep">��������<see cref="System.Web.Caching.CacheDependency"/></param>
		/// <param name="seconds">���������</param>
		public static void Insert(string key, object obj, CacheDependency dep, int seconds)
		{
			Insert(key, obj, dep, seconds, CacheItemPriority.Normal);
		}

		/// <summary>
		/// ���뻺����
		/// </summary>
		/// <param name="key">�������ʶ</param>
		/// <param name="obj">������</param>
		/// <param name="dep">��������<see cref="System.Web.Caching.CacheDependency"/></param>
		/// <param name="secondsBase">���������(���������ļ���ΪFactor * secondsBase) </param>
		/// <param name="priority">�������ȼ�<see cref="System.Web.Caching.CacheItemPriority"/></param>
		public static void Insert(string key, object obj, CacheDependency dep, int secondsBase, CacheItemPriority priority)
		{
			if (obj != null)
				_cache.Insert(key, obj, dep, DateTime.Now.AddSeconds(Factor * secondsBase), TimeSpan.Zero, priority, null);
		}


		//public static void MicroInsert(string key, object obj, int secondFactor)
		//{
		//    if (obj != null)
		//        _cache.Insert(key, obj, null, DateTime.Now.AddSeconds(Factor * secondFactor), TimeSpan.Zero);
		//}


		/// <overloads>���ü��뻺��������ʧЧ����ʱ����������أ�</overloads>
		/// <summary>
		/// ���ü��뻺��������ʧЧ����ʱ����������أ�
		/// </summary>
		/// <param name="key">�������ʶ</param>
		/// <param name="obj">������</param>
		public static void Max(string key, object obj)
		{
			Max(key, obj, null);
		}

		/// <summary>
		/// ���ü��뻺��������ʧЧ����ʱ����������أ�
		/// </summary>
		/// <param name="key">�������ʶ</param>
		/// <param name="obj">������</param>
		/// <param name="dep">��������</param>
		public static void Max(string key, object obj, CacheDependency dep)
		{
			if (obj != null)
				_cache.Insert(key, obj, dep, DateTime.MaxValue, TimeSpan.Zero, CacheItemPriority.AboveNormal, null);
		}

		#endregion

		/// <summary>
		/// ��ȡ������
		/// </summary>
		/// <param name="key">�������ʶ</param>
		/// <returns>������</returns>
		public static object Get(string key)
		{
			return _cache[key];
		}


		/// <summary>
		/// Return int of seconds * SecondFactor
		/// </summary>
		/// <example>
		/// �������������������ʾ���������û���ʱ��Ϊ10��
		/// <code>
		/// WebCache.Insert(cacheKey, obj, WebCache.SecondFactorCalculate(10));
		/// </code>
		/// </example>
		public static int SecondFactorCalculate(int seconds)
		{
			// Insert method below takes integer seconds, so we have to round any fractional values
			return Convert.ToInt32(Math.Round((double)seconds * SecondFactor));
		}

		#region ����

		/// <summary>
		/// �������
		/// </summary>
		public static Cache Cache
		{
			get { return _cache; }
		}

		#endregion

	}
}