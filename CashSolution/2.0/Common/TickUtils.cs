//<copyright>英网资讯技术有限公司 1999-2004</copyright>
//<version>V1.0</verion>
//<createdate>2004-3-15</createdate>
//<author>wuhp</author>
//<email>wuhp@yingnet.com</email>
//<log date="2004-3-15">创建</log>

using System;

namespace YingNet.Common {
    /// <summary>
    /// 毫秒时间转换工具集,自0001/01/01开始
    /// </summary>
    public class TickUtils {
        public TickUtils() {
        }

        /// <summary>
        /// 返回当前时间的毫秒表示
        /// </summary>
        /// <returns>毫秒时间</returns>
        public static long GetTick () {
            return ConvertToMilli(System.DateTime.Now.Ticks);
        }

        /// <summary>
        /// 返回指定日期的开始时间的毫秒表示
        /// </summary>
        /// <param name="date">时间</param>
        /// <returns>毫秒时间</returns>
        public static long GetTick (string date) {
            return ConvertToMilli(Convert.ToDateTime(date).Ticks);
        }

        /// <summary>
        /// 增加指定的天数
        /// </summary>
        /// <param name="tick">毫秒时间</param>
        /// <param name="daydiff">时间差</param>
        /// <returns>毫秒时间</returns>
        public static long AddDays (long tick, int daydiff) {
            return (tick + 24L * 60 * 60 * 1000 * daydiff);
        }

        /// <summary>
        /// 格式化时间
        /// </summary>
        /// <param name="tick">毫秒时间</param>
        /// <returns>格式化后的时间字符串</returns>
        public static string DateFormat (long tick) {
            return DateUtils.DateFormat(ConvertToDateTime(tick));
        }

        /// <summary>
        /// 格式化时间
        /// </summary>
        /// <param name="tick">毫秒时间</param>
        /// <param name="format">格式化串</param>
        /// <returns>格式化后的时间字符串</returns>
        public static string DateFormat (long tick, string format) {
            return DateUtils.DateFormat(ConvertToDateTime(tick), format);
        }

        /// <summary>
        /// 格式化日期时间
        /// </summary>
        /// <param name="tick">毫秒时间</param>
        /// <returns>格式化后的日期时间字符串</returns>
        public static string DateTimeFormat (long tick) {
            return DateUtils.DateFormat(ConvertToDateTime(tick));
        }

        /// <summary>
        /// 格式化日期时间
        /// </summary>
        /// <param name="tick">毫秒时间</param>
        /// <param name="format">格式化串</param>
        /// <returns>格式化后的日期时间字符串</returns>
        public static string DateTimeFormat (long tick, string format) {
            return DateUtils.DateFormat(ConvertToDateTime(tick), format);
        }

        /// <summary>
        /// 将dotnet 100毫微秒转换为毫秒
        /// </summary>
        /// <param name="nano">dotnet的100毫微秒</param>
        /// <returns>毫秒时间</returns>
        private static long ConvertToMilli (long nano) {
            return nano / 10000;
        }

        /// <summary>
        /// 将毫秒转为datetime对象
        /// </summary>
        /// <param name="tick">毫秒时间</param>
        /// <returns>时间对象</returns>
        public static DateTime ConvertToDateTime (long tick) {
            return new DateTime(tick * 10000);
        }
    }
}
