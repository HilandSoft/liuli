

using System;

using System.Text;
using System.Collections.Specialized;
using System.Globalization;

namespace YingNet.Utils
{
    /// <summary>
    /// Mime对照
    /// </summary>
    public class MimeMap
    {
        private static StringDictionary _mimeMap = new StringDictionary();

        static MimeMap()
        {
            _mimeMap.Add("csv", "application/vnd.ms-excel");
            _mimeMap.Add("css", "text/css");
            _mimeMap.Add("js", "text/javascript");
            _mimeMap.Add("doc", "application/msword");
            _mimeMap.Add("gif", "image/gif");
            _mimeMap.Add("bmp", "image/bmp");
            _mimeMap.Add("htm", "text/html");
            _mimeMap.Add("html", "text/html");
            _mimeMap.Add("jpeg", "image/jpeg");
            _mimeMap.Add("jpg", "image/jpeg");
            _mimeMap.Add("pdf", "application/pdf");
            _mimeMap.Add("png", "image/png");
            _mimeMap.Add("ppt", "application/vnd.ms-powerpoint");
            _mimeMap.Add("rtf", "application/msword");
            _mimeMap.Add("txt", "text/plain");
            _mimeMap.Add("xls", "application/vnd.ms-excel");
            _mimeMap.Add("xml", "text/xml");
            _mimeMap.Add("wmv", "video/x-ms-wmv");
            _mimeMap.Add("wma", "video/x-ms-wmv");
            _mimeMap.Add("mpeg", "video/mpeg");
            _mimeMap.Add("mpg", "video/mpeg");
            _mimeMap.Add("mpa", "video/mpeg");
            _mimeMap.Add("mpe", "video/mpeg");
            _mimeMap.Add("mov", "video/quicktime");
            _mimeMap.Add("qt", "video/quicktime");
            _mimeMap.Add("avi", "video/x-msvideo");
            _mimeMap.Add("asf", "video/x-ms-asf");
            _mimeMap.Add("asr", "video/x-ms-asf");
            _mimeMap.Add("asx", "video/x-ms-asf");
            _mimeMap.Add("swf", "application/x-shockwave-flash");
        }

        /// <summary>
        /// 去除文件名中的无效字符
        /// </summary>
        public static string Encode(string unencoded)
        {
            string[] textArray = unencoded.Split(new char[] { 
            '!', '@', '#', '$', '%', '^', '&', '*', '(', ')', '[', ']', '{', '}', '<', '>', 
            ',', '?', '\\', '/', '\'', '+', '=', '~', '`', '|' });
            return string.Join("", textArray);
        }

        /// <summary>
        /// 通过filename获取mime
        /// </summary>
        public static string GetMapping(string filename)
        {
            string text = null;
            int num = filename.LastIndexOf('.');
            if ((num > 0) && (num > filename.LastIndexOf('\\')))
            {
                text = _mimeMap[filename.Substring(num + 1).ToLower(CultureInfo.InvariantCulture)];
            }
            if (text == null)
            {
                return "application/octet-stream";
            }
            return text;
        }
    }
}