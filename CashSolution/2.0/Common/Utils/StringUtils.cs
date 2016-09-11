using System;

using System.Text;
using System.Globalization;
using System.Collections;
using System.Text.RegularExpressions;

namespace YingNet.Utils
{
    /// <summary>
    /// 字符串处理工具类
    /// </summary>
    public class StringUtils
    {
        #region String length formatter

        /// <summary>
        /// 对字符串进行裁剪
        /// </summary>
        public static string Trim(string stringTrim, int maxLength)
        {
            return Trim(stringTrim, maxLength, "...");
        }

        /// <summary>
        /// 对字符串进行裁剪(区分单字节及双字节字符)
        /// </summary>
        /// <param name="rawString">需要裁剪的字符串</param>
        /// <param name="maxLength">裁剪的长度，按双字节计数</param>
        /// <param name="appendString">如果进行了裁剪需要附加的字符</param>
        public static string Trim(string rawString, int maxLength, string appendString)
        {
            if (ValueHelper.IsNullOrEmpty(rawString) || rawString.Length <= maxLength)
            {
                return rawString;
            }
            else
            {
                int rawStringLength = Encoding.Default.GetBytes(rawString).Length;
                if (rawStringLength <= maxLength * 2)
                    return rawString;
            }

            int appendStringLength = Encoding.Default.GetBytes(appendString).Length;
            StringBuilder checkedStringBuilder = new StringBuilder();
            int appendedLenth = 0;
            for (int i = 0; i < rawString.Length; i++)
            {
                char _char = rawString[i];
                checkedStringBuilder.Append(_char);

                appendedLenth += Encoding.Default.GetBytes(new char[] { _char }).Length;

                if (appendedLenth >= maxLength * 2 - appendStringLength)
                    break;
            }

            return checkedStringBuilder.ToString() + appendString;

            #region 旧的实现方法

            //Char[] chars = rawString.ToCharArray();
            //int checkedStringLength = 0;
            //for (int i = 0; i < chars.Length; i++)
            //{
            //    checkedStringBuilder.Append(chars[i]);
            //    switch (Char.GetUnicodeCategory(chars[i]))
            //    {
            //        case UnicodeCategory.DecimalDigitNumber:
            //        case UnicodeCategory.LowercaseLetter:
            //        case UnicodeCategory.UppercaseLetter:
            //            checkedStringLength++;
            //            break;
            //        case UnicodeCategory.OtherLetter:
            //        case UnicodeCategory.OpenPunctuation:
            //            checkedStringLength += 2;
            //            break;
            //        default:
            //            checkedStringLength++;
            //            break;
            //    }
            //    if (appendString.Length > 0)
            //    {
            //        if (checkedStringLength >= ((maxLength - 1) * 2))
            //        {
            //            checkedStringBuilder.Append(appendString);
            //            break;
            //        }
            //    }
            //    else
            //    {
            //        if (checkedStringLength >= (maxLength * 2))
            //            break;
            //    }
            //}
            //return checkedStringBuilder.ToString();

            #endregion
        }


        #endregion

        /// <summary>
        /// Unicode转义序列
        /// </summary>
        public static string UnicodeEncode(string rawText)
        {
            if (rawText == null || rawText == string.Empty)
                return rawText;
            string text = "";
            foreach (int c in rawText)
            {
                string t = "";
                if (c > 126)
                {
                    text += "\\u";
                    t = c.ToString("x");
                    for (int x = 0; x < 4 - t.Length; x++)
                    {
                        text += "0";
                    }
                }
                else
                {
                    t = ((char)c).ToString();
                }
                text += t;
            }

            return text;
        }

        /// <summary>
        /// 进行字符串的转码
        /// </summary>
        public static string ConvertEncoding(Encoding fromEncoding, Encoding toEncoding, string str)
        {
            //return toEncoding.GetString(Encoding.Convert(fromEncoding, toEncoding, fromEncoding.GetBytes(str)));

            // Convert the string into a byte[].
            byte[] unicodeBytes = fromEncoding.GetBytes(str);

            // Perform the conversion from one encoding to the other.
            byte[] asciiBytes = Encoding.Convert(fromEncoding, toEncoding, unicodeBytes);

            // Convert the new byte[] into a char[] and then into a string.
            // This is a slightly different approach to converting to illustrate
            // the use of GetCharCount/GetChars.
            char[] asciiChars = new char[toEncoding.GetCharCount(asciiBytes, 0, asciiBytes.Length)];
            string asciiString = new string(asciiChars);

            return asciiString;
        }

        /// <summary>
        /// 删除SQL注入特殊字符
        /// 解然 20070622加入对输入参数sql为Null的判断
        /// </summary>
        public static string StripSQLInjection(string sql)
        {
            if (!ValueHelper.IsNullOrEmpty(sql))
            {
                //过滤 ' --
                string pattern1 = @"(\%27)|(\')|(\-\-)";

                //防止执行 ' or
                string pattern2 = @"((\%27)|(\'))\s*((\%6F)|o|(\%4F))((\%72)|r|(\%52))";

                //防止执行sql server 内部存储过程或扩展存储过程
                string pattern3 = @"\s+exec(\s|\+)+(s|x)p\w+";

                sql = Regex.Replace(sql, pattern1, string.Empty, RegexOptions.IgnoreCase);
                sql = Regex.Replace(sql, pattern2, string.Empty, RegexOptions.IgnoreCase);
                sql = Regex.Replace(sql, pattern3, string.Empty, RegexOptions.IgnoreCase);
            }
            return sql;
        }

        /// <summary>
        /// 清除xml中的不合法字符
        /// </summary>
        /// <remarks>
        /// 无效字符：
        /// 0x00 - 0x08
        /// 0x0b - 0x0c
        /// 0x0e - 0x1f
        /// </remarks>
        public static string CleanInvalidCharsForXML(string input)
        {
            if (ValueHelper.IsNullOrEmpty(input))
                return input;
            else
            {
                StringBuilder checkedStringBuilder = new StringBuilder();
                Char[] chars = input.ToCharArray();
                for (int i = 0; i < chars.Length; i++)
                {
                    int charValue = Convert.ToInt32(chars[i]);

                    if ((charValue >= 0x00 && charValue <= 0x08) || (charValue >= 0x0b && charValue <= 0x0c) || (charValue >= 0x0e && charValue <= 0x1f))
                        continue;
                    else
                        checkedStringBuilder.Append(chars[i]);
                }

                return checkedStringBuilder.ToString();

                //string result = checkedStringBuilder.ToString();
                //result = result.Replace("&#x0;", "");
                //return Regex.Replace(result, @"[\u0000-\u0008\u000B\u000C\u000E-\u001A\uD800-\uDFFF]", delegate(Match m) { int code = (int)m.Value.ToCharArray()[0]; return (code > 9 ? "&#" + code.ToString() : "&#0" + code.ToString()) + ";"; });
            }
        }



    }
}
