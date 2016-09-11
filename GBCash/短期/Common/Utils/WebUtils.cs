
using System;

using System.Text;
using System.Web;
using System.Globalization;
using System.Text.RegularExpressions;

namespace YingNet.Utils
{

    public class WebUtils
    {
        // the HTML newline character
        public const String HtmlNewLine = "<br />";
        public static Regex _pathComponentTextToEscape = new Regex(@"([^A-Za-z0-9\- ]+|\.| )", RegexOptions.Singleline | RegexOptions.Compiled);
        public static Regex _pathComponentTextToUnescape = new Regex(@"((?:_(?:[0-9a-f][0-9a-f][0-9a-f][0-9a-f])+_)|\+)", RegexOptions.Singleline | RegexOptions.IgnoreCase | RegexOptions.Compiled);
        public static Regex _fileComponentTextToEscape = new Regex(@"([^A-Za-z0-9 ]+|\.| )", RegexOptions.Singleline | RegexOptions.Compiled);
        public static Regex _fileComponentTextToUnescape = new Regex(@"((?:_(?:[0-9a-f][0-9a-f][0-9a-f][0-9a-f])+_)|_|\-)", RegexOptions.Singleline | RegexOptions.IgnoreCase | RegexOptions.Compiled);

        private WebUtils() { }

        /// <summary>
        /// 应用程序根路径
        /// </summary>
        public static string ApplicationPath
        {
            get
            {
                string applicationPath = "/";
                if (HttpContext.Current != null)
                    applicationPath = HttpContext.Current.Request.ApplicationPath;

                if (applicationPath == "/")
                    return string.Empty;
                else
                    return applicationPath;
            }
        }

        #region Encode/Decode
        /// <summary>
        /// Converts a prepared subject line back into a raw text subject line.
        /// </summary>
        /// <param name="textToFormat">The prepared subject line.</param>
        /// <returns>A raw text subject line.</returns>
        /// <remarks>This function is only needed when editing an existing message or when replying to
        /// a message - it turns the HTML escaped characters back into their pre-escaped status.</remarks>
        public static string HtmlDecode(String textToFormat)
        {
            if (ValueHelper.IsNullOrEmpty(textToFormat))
                return textToFormat;

            return System.Web.HttpUtility.HtmlDecode(textToFormat);
            // strip the HTML - i.e., turn < into &lt;, > into &gt;
        }

        /// <summary>
        /// Converts a prepared subject line back into a raw text subject line.
        /// </summary>
        /// <param name="textToFormat">The prepared subject line.</param>
        /// <returns>A raw text subject line.</returns>
        /// <remarks>
        ///  调用HttpUtility.HtmlEncode()，当前已知仅作如下转换：
        /// < = &lt;
        /// > = &gt;
        /// & = &amp;
        /// " = &quot;
        /// </remarks>
        public static string HtmlEncode(String textToFormat)
        {
            // strip the HTML - i.e., turn < into &lt;, > into &gt;

            if (ValueHelper.IsNullOrEmpty(textToFormat))
                return textToFormat;

            return HttpUtility.HtmlEncode(textToFormat);
        }

        public static string UrlEncode(string urlToEncode)
        {
            if (ValueHelper.IsNullOrEmpty(urlToEncode))
                return urlToEncode;

            return HttpUtility.UrlEncode(urlToEncode).Replace("'", "%27");
        }

        public static string UrlDecode(string urlToDecode)
        {
            if (ValueHelper.IsNullOrEmpty(urlToDecode))
                return urlToDecode;

            return System.Web.HttpUtility.UrlEncode(urlToDecode);
        }

        public static string UrlEncodePathComponent(string text)
        {
            return UrlEncode(text, _pathComponentTextToEscape, '+', '_');
        }

        public static string UrlDecodePathComponent(string text)
        {
            return UrlDecode(text, _pathComponentTextToUnescape);
        }

        public static string UrlEncodeFileComponent(string text)
        {
            return UrlEncode(text, _fileComponentTextToEscape, '-', '_');
        }

        public static string UrlDecodeFileComponent(string text)
        {
            return UrlDecode(text, _fileComponentTextToUnescape);
        }

        private static string UrlEncode(string text, Regex pattern, char spaceReplacement, char escapePrefix)
        {
            if (ValueHelper.IsNullOrEmpty(text))
                return text;

            Match match = pattern.Match(text);
            StringBuilder encText = new StringBuilder();
            int lastEndIndex = 0;
            while (match.Value != string.Empty)
            {
                if (lastEndIndex != match.Index)
                    encText.Append(text.Substring(lastEndIndex, match.Index - lastEndIndex));

                if (match.Value == " ")
                    encText.Append(spaceReplacement);
                else if (match.Value == "." && match.Index != text.Length - 1)
                    encText.Append("."); // . at the end of text causes a 404... only encode . at the end of text
                else
                {
                    encText.Append(escapePrefix);
                    byte[] bytes = Encoding.Unicode.GetBytes(match.Value);
                    if (bytes != null)
                    {
                        foreach (byte b in bytes)
                        {
                            string hexByte = b.ToString("X");

                            if (hexByte.Length == 1)
                                encText.Append("0");

                            encText.Append(hexByte);
                        }
                    }
                    encText.Append(escapePrefix);
                }

                lastEndIndex = match.Index + match.Length;
                match = pattern.Match(text, lastEndIndex);
            }

            if (lastEndIndex < text.Length)
                encText.Append(text.Substring(lastEndIndex));

            return encText.ToString();
        }

        private static string UrlDecode(string text, Regex pattern)
        {
            if (ValueHelper.IsNullOrEmpty(text))
                return text;

            Match match = pattern.Match(text);
            StringBuilder decText = new StringBuilder();
            int lastEndIndex = 0;
            while (match.Value != string.Empty)
            {
                if (lastEndIndex != match.Index)
                    decText.Append(text.Substring(lastEndIndex, match.Index - lastEndIndex));

                if (match.Value.Length == 1)
                    decText.Append(" ");
                else
                {
                    byte[] bytes = new byte[(match.Value.Length - 2) / 2];

                    for (int i = 1; i < match.Value.Length - 1; i += 2)
                        bytes[(i - 1) / 2] = byte.Parse(match.Value.Substring(i, 2), NumberStyles.AllowHexSpecifier);

                    decText.Append(Encoding.Unicode.GetString(bytes));
                }

                lastEndIndex = match.Index + match.Length;
                match = pattern.Match(text, lastEndIndex);
            }

            if (lastEndIndex < text.Length)
                decText.Append(text.Substring(lastEndIndex));

            return decText.ToString();
        }


        #endregion

        #region IPAddress

        /// <summary>
        /// 获取IP地址
        /// </summary>
        static public string IPAddress
        {
            get
            {
                string ipAddress = "000.000.000.000";
                try
                {
                    // 有可能是后台调用
                    HttpContext context = HttpContext.Current;
                    ipAddress = GetUserIpAddress(context);
                }
                catch { }
                return ipAddress;
            }
        }

        /// <summary>
        /// 透过代理获取真实IP
        /// </summary>
        public static string GetUserIpAddress(HttpContext context)
        {
            string result = String.Empty;
            if (context == null)
                return result;

            // 透过代理取真实IP
            result = HttpContext.Current.Request.ServerVariables["HTTP_X_FORWARDED_FOR"];
            if (null == result || result == String.Empty)
                result = HttpContext.Current.Request.ServerVariables["REMOTE_ADDR"];

            if (null == result || result == String.Empty)
                result = HttpContext.Current.Request.UserHostAddress;

            return result;
        }

        #endregion


        public static string HostPath(Uri uri)
        {
            string portInfo = uri.Port == 80 ? string.Empty : ":" + uri.Port.ToString();
            return string.Format("{0}://{1}{2}", uri.Scheme, uri.Host, portInfo);
        }

        public static string FullPath(string local)
        {
            return FullPath(HostPath(HttpContext.Current.Request.Url), local);
        }

        public static string FullPath(string hostPath, string local)
        {
            return hostPath + local;
        }


        /// <summary>
        /// 获取属性值
        /// </summary>
        public static string GetAttributeFromHeader(string headerValue, string attrName)
        {
            int attrLen;
            if (headerValue == null)
            {
                return null;
            }
            int len = headerValue.Length;
            int attrNameLen = attrName.Length;
            int index = 1;
            while (index < len)
            {
                index = CultureInfo.InvariantCulture.CompareInfo.IndexOf(headerValue, attrName, index, CompareOptions.IgnoreCase);
                if ((index < 0) || ((index + attrNameLen) >= len))
                {
                    break;
                }
                char start = headerValue[index - 1];
                char end = headerValue[index + attrNameLen];
                if ((((start == ';') || (start == ',')) || char.IsWhiteSpace(start)) && ((end == '=') || char.IsWhiteSpace(end)))
                {
                    break;
                }
                index += attrNameLen;
            }
            if ((index < 0) || (index >= len))
            {
                return null;
            }
            index += attrNameLen;
            while ((index < len) && char.IsWhiteSpace(headerValue[index]))
            {
                index++;
            }
            if ((index >= len) || (headerValue[index] != '='))
            {
                return null;
            }
            index++;
            while ((index < len) && char.IsWhiteSpace(headerValue[index]))
            {
                index++;
            }
            if (index >= len)
            {
                return null;
            }
            if ((index < len) && (headerValue[index] == '"'))
            {
                if (index == (len - 1))
                {
                    return null;
                }
                attrLen = headerValue.IndexOf('"', (int)(index + 1));
                if ((attrLen < 0) || (attrLen == (index + 1)))
                {
                    return null;
                }
                return headerValue.Substring(index + 1, (attrLen - index) - 1).Trim();
            }
            attrLen = index;
            while (attrLen < len)
            {
                if ((headerValue[attrLen] == ' ') || (headerValue[attrLen] == ',') || (headerValue[attrLen] == ';'))
                {
                    break;
                }
                attrLen++;
            }
            if (attrLen == index)
            {
                return null;
            }
            return headerValue.Substring(index, attrLen - index).Trim();
        }

        /// <summary>
        /// 返回404错误
        /// </summary>
        /// <param name="Context"></param>
        public static void Return404(HttpContext Context)
        {
            Context.Response.StatusCode = 404;
            Context.Response.SuppressContent = true;
            Context.Response.End();
        }

    }
}
