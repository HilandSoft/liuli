
using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Collections;
using System.Web.Caching;

namespace YingNet.Utils
{
    /// <summary>
    /// Html工具类
    /// </summary>
    public class HtmlUtils
    {

        #region Strip All Tags from a String

        ///<overloads>移除所有Html Elemtnts及HTML Entities</overloads>
        /// <summary>
        /// 移除所有Html Elemtnts及HTML Entities
        /// </summary>
        /// <param name="stringToStrip">需要格式化的字符串</param>
        public static string StripAllTags(string stringToStrip)
        {
            return StripAllTags(stringToStrip, true);
        }

        /// <summary>
        /// 移除所有Html Elemtnts及HTML Entities
        /// </summary>
        /// <param name="stringToStrip">需要格式化的字符串</param>
        /// <param name="enableMultiLine">是否启用多行(是否使用\n)</param>
        public static string StripAllTags(string stringToStrip, bool enableMultiLine)
        {
            stringToStrip = Regex.Replace(stringToStrip, "</p(?:\\s*)>(?:\\s*)<p(?:\\s*)>", "\n\n", RegexOptions.IgnoreCase | RegexOptions.Compiled);
            stringToStrip = Regex.Replace(stringToStrip, "<br(?:\\s*)/>", "\n", RegexOptions.IgnoreCase | RegexOptions.Compiled);
            stringToStrip = Regex.Replace(stringToStrip, "\"", "''", RegexOptions.IgnoreCase | RegexOptions.Compiled);

            //StripEntities removes the HTML Entities 
            stringToStrip = Regex.Replace(stringToStrip, "&[^;]*;", string.Empty, RegexOptions.IgnoreCase | RegexOptions.Compiled);

            stringToStrip = StripHtmlXmlTags(stringToStrip);

            return stringToStrip;
        }

        /// <summary>
        /// 移除html内的Elemtnts/Attributes及&nbsp;，超过charLimit个字符进行截断
        /// </summary>
        /// <param name="sourceHtml"></param>
        /// <param name="charLimit">最多允许返回的字符数</param>
        public static string TrimHtml(string sourceHtml, int charLimit)
        {
            if (ValueHelper.IsNullOrEmpty(sourceHtml))
                return string.Empty;

            //string nonhtml = Regex.Replace(sourceHtml, "<[^>]+>|\\&nbsp\\;", "", RegexOptions.IgnoreCase | RegexOptions.Compiled);
            string nonhtml = StripAllTags(sourceHtml, false);

            if (charLimit <= 0 || charLimit >= nonhtml.Length)
                return nonhtml;
            else
                return StringUtils.Trim(nonhtml, charLimit);
        }

        #endregion

        #region Format Email

        /// <summary>
        /// Email转换成mailto格式
        /// </summary>
        public static string FormatEmail(string email)
        {
            return FormatEmail(email, true);
        }

        /// <summary>
        /// Email转换成mailto格式
        /// </summary>
        /// <param name="email">Email地址</param>
        /// <param name="replaceAtMark">是否把@替换成#</param>
        public static string FormatEmail(string email, bool replaceAtMark)
        {
            string formatedEmail = string.Empty;

            if (!ValueHelper.IsNullOrEmpty(email))
            {
                string emailText = replaceAtMark ? email.Replace('@', '#') : email;

                if (email.IndexOfAny(new char[] { '@', '#' }) > -1)
                    formatedEmail = string.Format("<a herf=\"mailto:{0}\">{1}</a>", email.Replace('#', '@'), emailText);
                else
                    formatedEmail = email;
            }
            return formatedEmail;
        }

        #endregion

        #region Strip Tags

        /// <summary>
        /// 移除Html用于预览显示
        /// </summary>
        /// <param name="content">用于预览的文本</param>
        public static string StripForPreview(string content)
        {
            content = Regex.Replace(content, "<br>", "\n", RegexOptions.IgnoreCase | RegexOptions.Compiled);
            content = Regex.Replace(content, "<br/>", "\n", RegexOptions.IgnoreCase | RegexOptions.Compiled);
            content = Regex.Replace(content, "<br />", "\n", RegexOptions.IgnoreCase | RegexOptions.Compiled);
            content = Regex.Replace(content, "<p>", "\n", RegexOptions.IgnoreCase | RegexOptions.Compiled);
            content = content.Replace("'", "&#39;");

            return StripHtmlXmlTags(content);
        }

        /// <summary>
        /// 移除Html(Xml)的Elemtnts
        /// </summary>
        /// <param name="content"></param>
        public static string StripHtmlXmlTags(string content)
        {
            return Regex.Replace(content, "<[^>]+>", string.Empty, RegexOptions.IgnoreCase | RegexOptions.Compiled);
        }


        /// <summary>
        /// 移除script标签
        /// Helper function used to ensure we don't inject script into the db.
        /// </summary>
        /// <remarks>
        /// 移除&lt;script&gt;及javascript:
        /// </remarks>
        public static string StripScriptTags(string content)
        {
            string cleanText;
            // Perform RegEx
            content = Regex.Replace(content, "<script((.|\n)*?)</script>", "", RegexOptions.IgnoreCase | RegexOptions.Multiline);
            cleanText = Regex.Replace(content, "\"javascript:", "", RegexOptions.IgnoreCase | RegexOptions.Multiline);

            return cleanText;
        }
        #endregion

   }
}
