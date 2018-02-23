

using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;

namespace YingNet.Utils
{
    /// <summary>
    /// BBCode转换工具
    /// </summary>
    public class BBCodeTransforms
    {
        /// <summary>
        /// 引用(Quote)转换成Html
        /// </summary>
        /// <param name="encodedString">BBCode表示引用代码</param>        
        public static string BBQuoteCodeToHtml(string encodedString)
        {
            string quoteStartHtml = "<BLOCKQUOTE><div> <strong>$1:</strong></div><div>";
            string quoteEndHtml = "</div></BLOCKQUOTE>";

            // Used for when a username is not supplied.
            //
            string emptyquoteStartHtml = "<BLOCKQUOTE><div>";
            string emptyquoteEndHtml = "</div></BLOCKQUOTE>";

            RegexOptions options = RegexOptions.IgnoreCase | RegexOptions.Compiled;

            // Quote
            //
            encodedString = Regex.Replace(encodedString, "\\[quote(?:\\s*)user=(?:\"|&quot;|&#34;)(.*?)(?:\"|&quot;|&#34;)\\]", quoteStartHtml, options);
            encodedString = Regex.Replace(encodedString, "\\[/quote(\\s*)\\]", quoteEndHtml, options);
            encodedString = Regex.Replace(encodedString, "\\[quote(\\s*)\\]", emptyquoteStartHtml, options);
            encodedString = Regex.Replace(encodedString, "\\[/quote(\\s*)\\]", emptyquoteEndHtml, options);

            return encodedString;
        }

        /// <summary>
        /// Transforms a BBCode encoded string in appropriate HTML
        /// </summary>
        public static string BBcodeToHtml(string encodedString)
        {
            // TDD TODO this shouldn't be hard coded, should be in a style sheet
            //

            RegexOptions options = RegexOptions.IgnoreCase | RegexOptions.Compiled;

            // Bold, Italic, Underline
            //
            encodedString = Regex.Replace(encodedString, @"\[b(?:\s*)\]((.|\n)*?)\[/b(?:\s*)\]", "<b>$1</b>", options);
            encodedString = Regex.Replace(encodedString, @"\[i(?:\s*)\]((.|\n)*?)\[/i(?:\s*)\]", "<i>$1</i>", options);
            encodedString = Regex.Replace(encodedString, @"\[u(?:\s*)\]((.|\n)*?)\[/u(?:\s*)\]", "<u>$1</u>", options);

            // Left, Right, Center
            encodedString = Regex.Replace(encodedString, @"\[left(?:\s*)\]((.|\n)*?)\[/left(?:\s*)]", "<div style=\"text-align:left\">$1</div>", options);
            encodedString = Regex.Replace(encodedString, @"\[center(?:\s*)\]((.|\n)*?)\[/center(?:\s*)]", "<div style=\"text-align:center\">$1</div>", options);
            encodedString = Regex.Replace(encodedString, @"\[right(?:\s*)\]((.|\n)*?)\[/right(?:\s*)]", "<div style=\"text-align:right\">$1</div>", options);

            // Note
            //
            encodedString = Regex.Replace(encodedString, @"\[note(?:\s*)header=(?:""|&quot;|&#34;)(.*?)(?:""|&quot;|&#34;)\]", "<blockquote><div><strong>$1:</strong></div><br /><div>", options);
            encodedString = Regex.Replace(encodedString, @"\[note(\s*)\]", "<blockquote><div>", options);
            encodedString = Regex.Replace(encodedString, @"\[/note(\s*)\]", "</div></blockquote>", options);

            // Code
            //
            encodedString = Regex.Replace(encodedString, @"\[code(?:\s*)file=(?:""|&quot;|&#34;)(.*?)(?:""|&quot;|&#34;)\]", "<blockquote style=\"overflow-x: scroll;\"><div><strong>$1:</strong></div><br /><pre style=\"margin: 0px;\">", options);
            encodedString = Regex.Replace(encodedString, @"\[code(?:\s*)\]", "<blockquote style=\"overflow-x: scroll;\"><pre style=\"margin: 0px;\">", options);
            encodedString = Regex.Replace(encodedString, @"\[/code(?:\s*)\]", "</pre></blockquote>", options);

            // Anchors
            //
            encodedString = Regex.Replace(encodedString, @"\[url(?:\s*)\]www\.(.*?)\[/url(?:\s*)\]", "<a href=\"http://www.$1\" target=\"_blank\" title=\"$1\">$1</a>", options);
            encodedString = Regex.Replace(encodedString, @"\[url(?:\s*)\]((.|\n)*?)\[/url(?:\s*)\]", "<a href=\"$1\" target=\"_blank\" title=\"$1\">$1</a>", options);
            encodedString = Regex.Replace(encodedString, @"\[url=(?:""|&quot;|&#34;)((.|\n)*?)(?:\s*)(?:""|&quot;|&#34;)\]((.|\n)*?)\[/url(?:\s*)\]", "<a href=\"$1\" target=\"_blank\" title=\"$1\">$3</a>", options);
            encodedString = Regex.Replace(encodedString, @"\[url=((.|\n)*?)(?:\s*)\]((.|\n)*?)\[/url(?:\s*)\]", "<a href=\"$1\" target=\"_blank\" title=\"$1\">$3</a>", options);
            encodedString = Regex.Replace(encodedString, @"\[link(?:\s*)\]((.|\n)*?)\[/link(?:\s*)\]", "<a href=\"$1\" target=\"_blank\" title=\"$1\">$1</a>", options);
            encodedString = Regex.Replace(encodedString, @"\[link=((.|\n)*?)(?:\s*)\]((.|\n)*?)\[/link(?:\s*)\]", "<a href=\"$1\" target=\"_blank\" title=\"$1\">$3</a>", options);

            // Image
            //
            encodedString = Regex.Replace(encodedString, @"\[img(?:\s*)\]((.|\n)*?)\[/img(?:\s*)\]", "<img src=\"$1\" border=\"0\" />", options);
            encodedString = Regex.Replace(encodedString, @"\[img=((.|\n)*?)x((.|\n)*?)(?:\s*)\]((.|\n)*?)\[/img(?:\s*)\]", "<img width=\"$1\" height=\"$3\" src=\"$5\" border=\"0\" />", options);

            // Color
            //
            encodedString = Regex.Replace(encodedString, @"\[color=((.|\n)*?)(?:\s*)\]((.|\n)*?)\[/color(?:\s*)\]", "<span style=\"color:$1;\">$3</span>", options);

            // Horizontal Rule
            //
            encodedString = Regex.Replace(encodedString, @"\[hr(?:\s*)\]", "<hr />", options);

            // Email
            //
            encodedString = Regex.Replace(encodedString, @"\[email(?:\s*)\]((.|\n)*?)\[/email(?:\s*)\]", "<a href=\"mailto:$1\">$1</a>", options);

            // Font size
            //
            encodedString = Regex.Replace(encodedString, @"\[size=((.|\n)*?)(?:\s*)\]((.|\n)*?)\[/size(?:\s*)\]", "<span style=\"font-size:$1\">$3</span>", options);
            encodedString = Regex.Replace(encodedString, @"\[font=((.|\n)*?)(?:\s*)\]((.|\n)*?)\[/font(?:\s*)\]", "<span style=\"font-family:$1;\">$3</span>", options);
            encodedString = Regex.Replace(encodedString, @"\[align=((.|\n)*?)(?:\s*)\]((.|\n)*?)\[/align(?:\s*)\]", "<div style=\"text-align:$1;\">$3</span>", options);
            encodedString = Regex.Replace(encodedString, @"\[float=((.|\n)*?)(?:\s*)\]((.|\n)*?)\[/float(?:\s*)\]", "<div style=\"float:$1;\">$3</div>", options);

            string sListFormat = "<ol class=\"anf_list\" style=\"list-style:{0};\">$1</ol>";
            // Lists
            encodedString = Regex.Replace(encodedString, @"\[\*(?:\s*)]\s*([^\[]*)", "<li>$1</li>", options);
            encodedString = Regex.Replace(encodedString, @"\[list(?:\s*)\]((.|\n)*?)\[/list(?:\s*)\]", "<ul class=\"anf_list\">$1</ul>", options);
            encodedString = Regex.Replace(encodedString, @"\[list=1(?:\s*)\]((.|\n)*?)\[/list(?:\s*)\]", string.Format(sListFormat, "decimal"), options);
            encodedString = Regex.Replace(encodedString, @"\[list=i(?:\s*)\]((.|\n)*?)\[/list(?:\s*)\]", string.Format(sListFormat, "lower-roman"), RegexOptions.Compiled);
            encodedString = Regex.Replace(encodedString, @"\[list=I(?:\s*)\]((.|\n)*?)\[/list(?:\s*)\]", string.Format(sListFormat, "upper-roman"), RegexOptions.Compiled);
            encodedString = Regex.Replace(encodedString, @"\[list=a(?:\s*)\]((.|\n)*?)\[/list(?:\s*)\]", string.Format(sListFormat, "lower-alpha"), RegexOptions.Compiled);
            encodedString = Regex.Replace(encodedString, @"\[list=A(?:\s*)\]((.|\n)*?)\[/list(?:\s*)\]", string.Format(sListFormat, "upper-alpha"), RegexOptions.Compiled);

            encodedString = Regex.Replace(encodedString, @"\[\]", "[", options);
            return encodedString;
        }

        /// <summary>
        /// This method will transform a HTML tagged string into a bbcoded string. We first convert all HTML tags to bbcode prior
        /// to performing our bbcode translations to strip out any dangerous attributes.
        /// </summary>
        /// <param name="htmlTaggedString"></param>
        public static string HtmlToBBCode(string htmlTaggedString)
        {
            return Regex.Replace(htmlTaggedString, @"(?'openingTag'<)(.*?)(?>(?!=[\/\?]?>)(?'closingSlash'\/\?)?(?'closingTag'>))", @"[$1${closingSlash}]", RegexOptions.IgnoreCase | RegexOptions.Multiline | RegexOptions.IgnorePatternWhitespace);
        }

    }
}
