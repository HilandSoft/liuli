

using System;

using System.Text;
using System.Text.RegularExpressions;
using System.IO;

namespace YingNet.Utils
{
    /// <summary>
    /// 源代码格式转换工具类
    /// </summary>
    public class SourceCodeTransforms
    {
        const int _fontsize = 2;
        const string TAG_FNTRED = "<font color= \"red\">";
        const string TAG_FNTBLUE = "<font color= \"blue\">";
        const string TAG_FNTGRN = "<font color= \"green\">";
        const string TAG_FNTMRN = "<font color=\"maroon\">";
        const string TAG_EFONT = "</font>";

        public static string FormatSource(string htmlEncodedSource, Language language)
        {
            StringWriter textBuffer = new StringWriter();
            textBuffer.Write("<font face=\"Lucida Console\" size=\"" + _fontsize + "\">");

            if (language == Language.CS)
            {
                textBuffer.Write(FixCSLine(htmlEncodedSource));
            }
            else if (language == Language.JScript)
            {
                textBuffer.Write(FixJSLine(htmlEncodedSource));
            }
            else if (language == Language.VB)
            {
                textBuffer.Write(FixVBLine(htmlEncodedSource));
            }

            textBuffer.Write("</font>");

            return textBuffer.ToString();
        }

        #region SourceCodeMarkup
        public static string SourceCodeMarkup(string stringToTransform)
        {
            StringBuilder formattedSource = new StringBuilder();
            string[] table = new string[3];

            table[0] = "<table border=\"0\" cellspacing=\"0\" width=\"100%\">";
            table[1] = "<tr><td width=\"15\"></td><td bgcolor=\"lightgrey\" width=\"15\"></td><td bgcolor=\"lightgrey\"><br>";
            table[2] = "<br>&nbsp;</td></tr></table>";
            MatchCollection matchs;

            // Look for code
            //
            matchs = Regex.Matches(stringToTransform, "\\[code language=\"(?<lang>(.|\\n)*?)\"\\](?<code>(.|\\n)*?)\\[/code\\]", RegexOptions.IgnoreCase | RegexOptions.Multiline | RegexOptions.Compiled);

            foreach (Match match in matchs)
            {
                // Remove HTML formatting code
                //
                string codeToFormat = match.Groups["code"].ToString().Replace("</P>\r\n", "<br>").Replace("<P>", "");

                // Get the formatted source code
                //
                formattedSource.Append(table[0]);
                formattedSource.Append(table[1]);
                formattedSource.Append(FormatSource(codeToFormat, GetLanguageType(match.Groups["lang"].ToString())).Replace(WebUtils.HtmlNewLine, ""));
                formattedSource.Append(table[2]);

                // Update the main string
                //
                stringToTransform = stringToTransform.Replace(match.ToString(), formattedSource.ToString());
                formattedSource.Remove(0, formattedSource.Length);
            }

            return stringToTransform;
        }
        #endregion

        #region EncodeCodeBlocks
        public static string EncodeCodeBlocks(string taggedString)
        {
            StringBuilder sb = new StringBuilder();
            string output = "";
            bool encodeThisBlock = false;
            //			string[] blocks = Regex.Split(taggedString, @"\[(?:code|pre).*\].*\[\/(?:code|pre).*\]", RegexOptions.IgnoreCase | RegexOptions.Multiline | RegexOptions.IgnorePatternWhitespace );
            string[] blocks = Regex.Split(taggedString, @"(\[(?:\/)?code\s*(?:language\s*=\s*"".*"")?\s*\])", RegexOptions.IgnoreCase | RegexOptions.Multiline | RegexOptions.IgnorePatternWhitespace);
            string language = "";
            foreach (string block in blocks)
            {
                output = block;

                if (encodeThisBlock)
                {
                    // temporary fix for FTB putting in </pre><pre class=source> tags in place of two \n\n
                    output = Regex.Replace(output, @"\<\/pre\s*?\>\<pre\s+class=""?source""?\s*?\>", @"<br/><br/>", RegexOptions.IgnoreCase | RegexOptions.Multiline | RegexOptions.IgnorePatternWhitespace);
                    output = WebUtils.HtmlEncode(Regex.Unescape(output));//Regex.Replace( block, @"(?'openingTag'<)(.*?)(?>(?!=[\/\?]?>)(?'closingSlash'\/\?)?(?'closingTag'>))", @"&lt;$1${closingSlash}]", RegexOptions.IgnoreCase | RegexOptions.Multiline | RegexOptions.IgnorePatternWhitespace );
                    output = Regex.Replace(output, @"(\<|\&lt;)br?(\s*|(\&nbsp;)*)(?:\/)?(\>|\&gt;)", "<br/>", RegexOptions.IgnoreCase | RegexOptions.Multiline | RegexOptions.IgnorePatternWhitespace);
                    output = FormatSource(output, GetLanguageType(language));
                    encodeThisBlock = false;
                }

                // dont write out the code blocks
                if (block.StartsWith("[code"))
                {
                    encodeThisBlock = true;
                    language = "CS";
                }
                else if (block.StartsWith("[/code"))
                {
                    // skip this block
                    encodeThisBlock = false;
                    language = "";
                }
                else
                {
                    sb.Append(output);
                }
            }

            return sb.ToString();
        }
        #endregion

        #region Help Methods

        private static Language GetLanguageType(string language)
        {

            switch (language.ToUpper())
            {
                case "VB":
                    return Language.VB;
                case "JS":
                    return Language.JScript;
                case "JScript":
                    return Language.JScript;
                default:
                    return Language.CS;
            }
        }

        private static string FixVBLine(string source)
        {
            if (source == null)
                return null;

            source = Regex.Replace(source, @"(\<br(\s*|(\&nbsp;)*)\/{0,1}\>)", @"<br/>");
            return source;

            /*
                        // TDD I'm commenting this out for now for the 2.0.1 release. At a later point we'll figure out what is wrong with the color
                        // syntax hightlighting.
                                    source = Regex.Replace(source, "(?i)(\\t)", "    ");

                        String[] keywords = new String[] {
                                                             "Private", "Protected", "Public", "End Namespace", "Namespace",
                                                             "End Class", "Exit", "Class", "Goto", "Try", "Catch", "End Try",
                                                             "For", "End If", "If", "Else", "ElseIf", "Next", "While", "And",
                                                             "Do", "Loop", "Dim", "As", "End Select", "Select", "Case", "Or",
                                                             "Imports", "Then", "Integer", "Long", "String", "Overloads", "True",
                                                             "Overrides", "End Property", "End Sub", "End Function", "Sub", "Me",
                                                             "Function", "End Get", "End Set", "Get", "Friend", "Inherits",
                                                             "Implements","Return", "Not", "New", "Shared", "Nothing", "Finally",
                                                             "False", "Me", "My", "MyBase" };


                        String CombinedKeywords = "(?<keyword>" + String.Join("|", keywords) + ")";

                        source = Regex.Replace(source, "(?i)\\b" + CombinedKeywords + "\\b(?<!'.*)", TAG_FNTBLUE + "${keyword}" + TAG_EFONT);
                        source = Regex.Replace(source, "(?<comment>'(?![^']*&quot;).*$)", TAG_FNTGRN + "${comment}" + TAG_EFONT);

                        return source;
            */
        }

        private static string FixJSLine(string source)
        {
            if (source == null)
                return null;

            source = Regex.Replace(source, @"(\<br(\s*|(\&nbsp;)*)\/{0,1}\>)", @"<br/>");
            return source;

            /*
                        // TDD I'm commenting this out for now for the 2.0.1 release. At a later point we'll figure out what is wrong with the color
                        // syntax hightlighting.
                                    source = Regex.Replace(source, "(?i)(\\t)", "    ");

                        String[] keywords = new String[] {
                                                             "private", "protected", "public", "namespace", "class", "var",
                                                             "for", "if", "else", "while", "switch", "case", "using", "get",
                                                             "return", "null", "void", "int", "string", "float", "this", "set",
                                                             "new", "true", "false", "const", "static", "package", "function",
                                                             "internal", "extends", "super", "import", "default", "break", "try",
                                                             "catch", "finally" };

                        String CombinedKeywords = "(?<keyword>" + String.Join("|", keywords) + ")";

                        source = Regex.Replace(source, "\\b" + CombinedKeywords + "\\b(?<!//.*)", TAG_FNTBLUE + "${keyword}" + TAG_EFONT);
                        source = Regex.Replace(source, "(?<comment>//.*$)", TAG_FNTGRN + "${comment}" + TAG_EFONT);

                        return source;
            */
        }

        private static string FixCSLine(string source)
        {

            if (source == null)
                return null;

            source = Regex.Replace(source, @"(\<br(\s*|(\&nbsp;)*)\/{0,1}\>)", @"<br/>");
            return source;

            /*
                        // TDD I'm commenting this out for now for the 2.0.1 release. At a later point we'll figure out what is wrong with the color
                        // syntax hightlighting.
                                    source = Regex.Replace(source, "(?i)(\\t)", "    ");
                        source = Regex.Replace(source, "(?i) ", "&nbsp;");

                        String[] keywords = new String[] {
                                                             "private", "protected", "public", "namespace", "class", "break",
                                                             "for", "if", "else", "while", "switch", "case", "using",
                                                             "return", "null", "void", "int", "bool", "string", "float",
                                                             "this", "new", "true", "false", "const", "static", "base",
                                                             "foreach", "in", "try", "catch", "finally", "get", "set", "char", "default"};

                        String CombinedKeywords = "(?<keyword>" + String.Join("|", keywords) + ")";

                        source = Regex.Replace(source, "\\b" + CombinedKeywords + "\\b(?<!//.*)", TAG_FNTBLUE + "${keyword}" + TAG_EFONT);
                        source = Regex.Replace(source, "(?<comment>//.*$)", TAG_FNTGRN + "${comment}" + TAG_EFONT);

                        return source;
            */
        }

        #endregion

    }


    public enum Language
    {
        CS,
        VB,
        JScript
    }
}
