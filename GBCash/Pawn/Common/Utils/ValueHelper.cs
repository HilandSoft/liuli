

using System;

using System.Text;
using System.Collections;
using System.Web.UI;

namespace YingNet.Utils
{
    /// <summary>
    /// 数值处理辅助类
    /// </summary>
    public class ValueHelper
    {
        private ValueHelper() { }

        /// <summary>
        /// 获取text的整型值
        /// </summary>
        /// <param name="text"></param>
        /// <param name="defaultValue">text不能正常转换则返回defaultValue</param>
        public static int SafeInt(string text, int defaultValue)
        {
            if (!IsNullOrEmpty(text))
            {
                try
                {
                    return Int32.Parse(text);
                }
                catch (Exception) { }
            }
            return defaultValue;
        }

        /// <summary>
        /// 获取text的布尔值
        /// </summary>
        /// <param name="text"></param>
        /// <param name="defaultValue">text不能正常转换则返回defaultValue</param>
        public static bool SafeBool(string text, bool defaultValue)
        {
            if (!IsNullOrEmpty(text))
            {
                try
                {
                    return bool.Parse(text);
                }
                catch (Exception) { }

            }

            return defaultValue;
        }

        /// <summary>
        /// 安全的获取用户词典的Value
        /// </summary>
        public static string SafeWordValue(SortedList sortedList, object key, string defaultValue)
        {
            if (sortedList.ContainsKey(key))
                return (string)sortedList[key];
            else
                return defaultValue;
        }

        /// <summary>
        /// 判断text是否是null或空字符串
        /// </summary>
        public static bool IsNullOrEmpty(string text)
        {
            return text == null || text.Trim() == string.Empty;
        }

        #region DB values

        /// <summary>
        /// 获取安全的SQL Server DateTime
        /// </summary>
        public static System.DateTime GetSafeSqlDateTime(System.DateTime date)
        {
            if (date < (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue)
                return (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue;
            else if (date > (DateTime)System.Data.SqlTypes.SqlDateTime.MaxValue)
                return (DateTime)System.Data.SqlTypes.SqlDateTime.MaxValue;
            return date;
        }

        /// <summary>
        /// 获取安全的SQL Server int
        /// </summary>
        public static int GetSafeSqlInt(int i)
        {
            if (i <= (int)System.Data.SqlTypes.SqlInt32.MinValue)
                return (int)System.Data.SqlTypes.SqlInt32.MinValue + 1;
            else if (i >= (int)System.Data.SqlTypes.SqlInt32.MaxValue)
                return (int)System.Data.SqlTypes.SqlInt32.MaxValue - 1;
            return i;
        }

        //public static object StringOrDBNull(string text)
        //{
        //    if (IsNullOrEmpty(text))
        //        return DBNull.Value;

        //    return text;
        //}

        #endregion


        #region ViewState

        /// <summary>
        /// 从ViewState中获取bool
        /// </summary>
        /// <param name="stateBag">StateBag</param>
        /// <param name="key">需要获取的键值</param>
        /// <param name="defaultValue">key不存在时默认返回的值</param>
        public static bool GetBoolFromViewState(StateBag stateBag, string key, bool defaultValue)
        {
            object obj = stateBag[key];
            if (obj == null)
            {
                return defaultValue;
            }
            return (bool)obj;
        }

        /// <summary>
        /// 从ViewState中获取int
        /// </summary>
        /// <param name="stateBag">StateBag</param>
        /// <param name="key">需要获取的键值</param>
        /// <param name="defaultValue">key不存在时默认返回的值</param>
        public static int GetIntFromViewState(StateBag stateBag, string key, int defaultValue)
        {
            object obj = stateBag[key];
            if (obj == null)
            {
                return defaultValue;
            }
            return (int)obj;
        }

        /// <summary>
        /// 从ViewState中获取string
        /// </summary>
        /// <param name="stateBag">StateBag</param>
        /// <param name="key">需要获取的键值</param>
        /// <param name="defaultValue">key不存在时默认返回的值</param>
        public static string GetStringFromViewState(StateBag stateBag, string key, string defaultValue)
        {
            string text = stateBag[key] as string;
            if (text == null)
            {
                return defaultValue;
            }
            return text;
        }

        #endregion
    }
}
