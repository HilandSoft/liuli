//<copyright>Ӣ����Ѷ�������޹�˾ 1999-2003</copyright>
//<version>V1.04</verion>
//<createdate>2003-7-21</createdate>
//<author>wuhp</author>
//<email>wuhp@qingdaojob.com</email>
//<log date="2003-7-21">����</log>
//<log date="2003-7-30" author="mazq">����GetRandomString(int num)����ȡ������ַ���</log>
//<log date="2003-7-30">����Replace��������صķ���</log>
//<log date="2003-7-31">����ȥ��htmlȫ����ǩ�ķ�����ƥ��������Ż�</log>
//<log date="2003-8-11" author="mazq">���� ToHtml(string str)�����ַ�����ʽ����HTML����</log>
//<log date="2003-8-11" author="mazq">���� ToTxt(string str)����HTML����ת�����ı���ʽ</log>

using System;
using System.Text.RegularExpressions;

namespace YingNet.Common {
	/// <summary>
	/// �ַ���ͨ�ù���
	/// </summary>
    public class StringUtils {
        /// <summary>
        /// ��������ַ���Դ
        /// </summary>
        public const string RANDOM_STRING_SOURCE = "0123456789abcdefghijklmnopqrstuvwxyz";

		public StringUtils() {
		}

        /// <summary>
        /// �滻�ַ���
        /// </summary>
        /// <param name="src">Ҫ�޸ĵ��ַ���</param>
        /// <param name="pattern">Ҫƥ���������ʽģʽ</param>
        /// <param name="Replacement">�滻�ַ���</param>
        /// <returns>���޸ĵ��ַ���</returns>
        public static string Replace (string src, string pattern, string Replacement) {
            return Replace(src, pattern, Replacement, RegexOptions.None);
        }

        /// <summary>
        /// �滻�ַ���,�����ִ�Сд
        /// </summary>
        /// <param name="src">Ҫ�޸ĵ��ַ���</param>
        /// <param name="pattern">Ҫƥ���������ʽģʽ</param>
        /// <param name="Replacement">�滻�ַ���</param>
        /// <returns>���޸ĵ��ַ���</returns>
        public static string ReplaceIgnoreCase (string src, string pattern, string Replacement) {
            return Replace(src, pattern, Replacement, RegexOptions.IgnoreCase);
        }

        /// <summary>
        /// �滻�ַ���
        /// </summary>
        /// <param name="src">Ҫ�޸ĵ��ַ���</param>
        /// <param name="pattern">Ҫƥ���������ʽģʽ</param>
        /// <param name="Replacement">�滻�ַ���</param>
        /// <param name="options">ƥ��ģʽ</param>
        /// <returns>���޸ĵ��ַ���</returns>
        public static string Replace (string src, string pattern, string Replacement, RegexOptions options) {
            Regex regex = new Regex(pattern, options|RegexOptions.Compiled);

            return regex.Replace(src, Replacement);
        }

        /// <summary>
        /// ɾ���ַ�����ָ��������
        /// </summary>
        /// <param name="src">Ҫ�޸ĵ��ַ���</param>
        /// <param name="pattern">Ҫɾ����������ʽģʽ</param>
        /// <returns>��ɾ��ָ�����ݵ��ַ���</returns>
        public static string Drop (string src, string pattern) {
            return Replace(src, pattern, "");
        }

        /// <summary>
        /// ɾ���ַ�����ָ��������,�����ִ�Сд
        /// </summary>
        /// <param name="src">Ҫ�޸ĵ��ַ���</param>
        /// <param name="pattern">Ҫɾ����������ʽģʽ</param>
        /// <returns>��ɾ��ָ�����ݵ��ַ���</returns>
        public static string DropIgnoreCase (string src, string pattern) {
            return ReplaceIgnoreCase(src, pattern, "");
        }

        /// <summary>
        /// �滻�ַ��������ݿ������ģʽ
        /// </summary>
        /// <param name="src">���������ݿ���ַ���</param>
        /// <returns>�ɲ������ݿ���ַ���</returns>
        public static string ToSQL (string src) 
        {
        	string original = src;
			if (original!=null)
			{
				//���� ' 
				string pattern1 = @"(\%27)|(\')";

				//��ִֹ��sql server �ڲ��洢���̻���չ�洢����
				string pattern3 = @"\s+exec(\s|\+)+(s|x)p\w+";

				//����--
				string pattern2 = @"(\-\-)";

				original = Regex.Replace(original, pattern1, "&#39;", RegexOptions.IgnoreCase);
				original = Regex.Replace(original, pattern2, "&#45;&#45;", RegexOptions.IgnoreCase);
				original = Regex.Replace(original, pattern3, string.Empty, RegexOptions.IgnoreCase);
			}
			return original;
        	
        	//ԭ����ʵ�ַ�ʽ
            //return Replace(src, "'", "''");
        }
		
		/// <summary>
		/// ��ת����������ַ���ת����
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
        /// ȥ��html�����е�ָ����html��ǩ
        /// </summary>
        /// <param name="content">html����</param>
        /// <param name="tagName">html��ǩ</param>
        /// <returns>ȥ����ǩ������</returns>
        public static string DropHtmlTag (string content, string tagName) {
            //ȥ��<tagname>��</tagname>
            return DropIgnoreCase(content, "<[/]{0,1}" + tagName + "[^\\>]*\\>");
        }

        /// <summary>
        /// ȥ��html������ȫ����ǩ
        /// </summary>
        /// <param name="content">html����</param>
        /// <returns>ȥ��html��ǩ������</returns>
        public static string DropHtmlTag (string content) {
            //ȥ��<*>
            return Drop(content, "<[^\\>]*>");
        }

        /// <summary>
        /// ��������ַ���
        /// </summary>
        /// <param name="num">�ַ�����λ��</param>
        /// <returns>�ɲ������ݿ���ַ���</returns>
        public static string GetRandomString (int num) {
            string rndStr="";
            Random rnd=new Random();
            for (int i=0;i<num;i++){
                rndStr += RANDOM_STRING_SOURCE.Substring(Convert.ToInt32(Math.Round(rnd.NextDouble()*36,0)),1);
            }
            return rndStr;
        }

        /// <summary>
        /// �ж�һ�������ǲ�������
        /// </summary>
        /// <param name="inputData">�ַ���</param>
        /// <returns>���</returns>
        public static bool IsNumeric(string inputData){
            Regex _isNumber = new Regex(@"^\d+$");
            Match m = _isNumber.Match(inputData);
            return m.Success;
        }



        /// <summary>
        /// ���ַ�����ʽ����HTML����
        /// </summary>
        /// <param name="str">Ҫ��ʽ�����ַ���</param>
        /// <returns>��ʽ������ַ���</returns>
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
        /// ��HTML����ת�����ı���ʽ
        /// </summary>
        /// <param name="str">Ҫ��ʽ�����ַ���</param>
        /// <returns>��ʽ������ַ���</returns>
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
