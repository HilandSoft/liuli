//<copyright>英网资讯技术有限公司 1999-2003</copyright>
//<version>V1.04</verion>
//<createdate>2003-7-21</createdate>
//<author>wuhp</author>
//<email>wuhp@qingdaojob.com</email>
//<log date="2003-7-21">创建</log>
//<log date="2003-7-30" author="mazq">增加GetRandomString(int num)：获取随机数字符串</log>
//<log date="2003-7-30">完善Replace和增加相关的方法</log>
//<log date="2003-7-31">增加去掉html全部标签的方法及匹配的性能优化</log>
//<log date="2003-8-11" author="mazq">增加 ToHtml(string str)：将字符串格式化成HTML代码</log>
//<log date="2003-8-11" author="mazq">增加 ToTxt(string str)：将HTML代码转化成文本格式</log>

using System;
using System.Text.RegularExpressions;

namespace YingNet.Common {
	/// <summary>
	/// 字符串通用工具
	/// </summary>
    public class StringUtils {
        /// <summary>
        /// 随机生成字符串源
        /// </summary>
        public const string RANDOM_STRING_SOURCE = "0123456789abcdefghijklmnopqrstuvwxyz";

		public StringUtils() {
		}

        /// <summary>
        /// 替换字符串
        /// </summary>
        /// <param name="src">要修改的字符串</param>
        /// <param name="pattern">要匹配的正则表达式模式</param>
        /// <param name="Replacement">替换字符串</param>
        /// <returns>已修改的字符串</returns>
        public static string Replace (string src, string pattern, string Replacement) {
            return Replace(src, pattern, Replacement, RegexOptions.None);
        }

        /// <summary>
        /// 替换字符串,不区分大小写
        /// </summary>
        /// <param name="src">要修改的字符串</param>
        /// <param name="pattern">要匹配的正则表达式模式</param>
        /// <param name="Replacement">替换字符串</param>
        /// <returns>已修改的字符串</returns>
        public static string ReplaceIgnoreCase (string src, string pattern, string Replacement) {
            return Replace(src, pattern, Replacement, RegexOptions.IgnoreCase);
        }

        /// <summary>
        /// 替换字符串
        /// </summary>
        /// <param name="src">要修改的字符串</param>
        /// <param name="pattern">要匹配的正则表达式模式</param>
        /// <param name="Replacement">替换字符串</param>
        /// <param name="options">匹配模式</param>
        /// <returns>已修改的字符串</returns>
        public static string Replace (string src, string pattern, string Replacement, RegexOptions options) {
            Regex regex = new Regex(pattern, options|RegexOptions.Compiled);

            return regex.Replace(src, Replacement);
        }

        /// <summary>
        /// 删除字符串中指定的内容
        /// </summary>
        /// <param name="src">要修改的字符串</param>
        /// <param name="pattern">要删除的正则表达式模式</param>
        /// <returns>已删除指定内容的字符串</returns>
        public static string Drop (string src, string pattern) {
            return Replace(src, pattern, "");
        }

        /// <summary>
        /// 删除字符串中指定的内容,不区分大小写
        /// </summary>
        /// <param name="src">要修改的字符串</param>
        /// <param name="pattern">要删除的正则表达式模式</param>
        /// <returns>已删除指定内容的字符串</returns>
        public static string DropIgnoreCase (string src, string pattern) {
            return ReplaceIgnoreCase(src, pattern, "");
        }

        /// <summary>
        /// 替换字符串到数据库可输入模式
        /// </summary>
        /// <param name="src">待插入数据库的字符串</param>
        /// <returns>可插入数据库的字符串</returns>
        public static string ToSQL (string src) 
        {
        	string original = src;
			if (original!=null)
			{
				//过滤 ' 
				string pattern1 = @"(\%27)|(\')";

				//防止执行sql server 内部存储过程或扩展存储过程
				string pattern3 = @"\s+exec(\s|\+)+(s|x)p\w+";

				//过滤--
				string pattern2 = @"(\-\-)";

				original = Regex.Replace(original, pattern1, "&#39;", RegexOptions.IgnoreCase);
				original = Regex.Replace(original, pattern2, "&#45;&#45;", RegexOptions.IgnoreCase);
				original = Regex.Replace(original, pattern3, string.Empty, RegexOptions.IgnoreCase);
			}
			return original;
        	
        	//原来的实现方式
            //return Replace(src, "'", "''");
        }
		
		/// <summary>
		/// 将转换后的特殊字符再转回来
		/// </summary>
		/// <param name="src"></param>
		/// <returns></returns>
		public	static string FromSQL(string src)
		{
			if(src!=null)
			{
				src = src.Replace("&#39;", "'");
				src = src.Replace("&#45;&#45;", "--");
			}
			
			return src;
		}

        /// <summary>
        /// 去掉html内容中的指定的html标签
        /// </summary>
        /// <param name="content">html内容</param>
        /// <param name="tagName">html标签</param>
        /// <returns>去掉标签的内容</returns>
        public static string DropHtmlTag (string content, string tagName) {
            //去掉<tagname>和</tagname>
            return DropIgnoreCase(content, "<[/]{0,1}" + tagName + "[^\\>]*\\>");
        }

        /// <summary>
        /// 去掉html内容中全部标签
        /// </summary>
        /// <param name="content">html内容</param>
        /// <returns>去掉html标签的内容</returns>
        public static string DropHtmlTag (string content) {
            //去掉<*>
            return Drop(content, "<[^\\>]*>");
        }

        /// <summary>
        /// 生成随机字符串
        /// </summary>
        /// <param name="num">字符串的位数</param>
        /// <returns>可插入数据库的字符串</returns>
        public static string GetRandomString (int num) {
            string rndStr="";
            Random rnd=new Random();
            for (int i=0;i<num;i++){
                rndStr += RANDOM_STRING_SOURCE.Substring(Convert.ToInt32(Math.Round(rnd.NextDouble()*36,0)),1);
            }
            return rndStr;
        }

        /// <summary>
        /// 判断一个数据是不是数字
        /// </summary>
        /// <param name="inputData">字符串</param>
        /// <returns>结果</returns>
        public static bool IsNumeric(string inputData){
            Regex _isNumber = new Regex(@"^\d+$");
            Match m = _isNumber.Match(inputData);
            return m.Success;
        }



        /// <summary>
        /// 将字符串格式化成HTML代码
        /// </summary>
        /// <param name="str">要格式化的字符串</param>
        /// <returns>格式化后的字符串</returns>
        public static String ToHtml(string str) {
            if (str == null || str.Equals("")) {
                return str;
            }
            String html = str;
            html = Replace(html, "&", "&amp;");
            html = Replace(html, "<", "&lt;");
            html = Replace(html, ">", "&gt;");
            html = Replace(html, "\r\n", "<br>");
            html = Replace(html, "\n", "<br>");
            html = Replace(html, "\t", "	");
            html = Replace(html, " ", "&nbsp;");
            return html;
        }


        /// <summary>
        /// 将HTML代码转化成文本格式
        /// </summary>
        /// <param name="str">要格式化的字符串</param>
        /// <returns>格式化后的字符串</returns>
        public static String ToTxt(String str) {
            if (str == null || str.Equals("")) {
                return str;
            }
            String txt = str;
            txt = Replace(txt, "&nbsp;", " ");
            txt = Replace(txt, "<br>", "\r\n");
            txt = Replace(txt, "&lt;", "<");
            txt = Replace(txt, "&gt;", ">");
            txt = Replace(txt, "&", "&amp;");
            txt = Replace(txt, "<", "&lt;");
            return txt;
        }

		/// <summary>
		/// 
		/// </summary>
		/// <param name="text"></param>
		/// <param name="count"></param>
		/// <returns></returns>
		public static string RepeatString(string text, int count)
		{
			string ret = "";
			for (int i=0; i<count; i++)
			{
				ret += text;
			}
			return ret;
		}

	}
}
