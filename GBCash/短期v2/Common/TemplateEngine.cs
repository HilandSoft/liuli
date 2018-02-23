using System;
using System.Collections;
using System.IO;
using System.Text;

namespace YingNet.Common
{
	/// <summary>
	/// TemplateEngine ��ժҪ˵����
	/// </summary>
	public class TemplateEngine
	{
		private Hashtable hs = new Hashtable();
		/// <summary>
		/// ������
		/// </summary>
		/// <param name="tempfile">ģ���ļ���</param>
		public TemplateEngine(string tempfile) : this(tempfile, "gb2312")
		{
		}

		/// <summary>
		/// ������
		/// </summary>
		/// <param name="tempfile">ģ���ļ���</param>
		/// <param name="encoding">�ļ�����</param>
		public TemplateEngine (string tempfile, string encoding) 
		{
			m_content = FileUtils.GetContent(tempfile, encoding).ToString();
		}

		public void SetVar (string key, string keyvalue) 
		{
			if (hs.ContainsKey(key) )
			{
				hs.Remove(key);
			}
			hs.Add(key, keyvalue);
		}

		private String m_content = null;
		/// <summary>
		/// ����
		/// </summary>
		public String Content 
		{
//			get 
//			{
//				string s = m_content;
//				IDictionaryEnumerator myEnumerator = hs.GetEnumerator();
//
//				string key = null;
//				while ( myEnumerator.MoveNext() ) {
//					key = (string)myEnumerator.Key;
//					s = StringUtils.ReplaceIgnoreCase(s, "\\$" + key + "\\$", hs[key].ToString());
//				}
//				return s;
//
//			}
			get
			{
				StringBuilder sb= new StringBuilder(m_content);
				IDictionaryEnumerator myEnumerator= hs.GetEnumerator();
				string key= null;
				while(myEnumerator.MoveNext())
				{
					key= (string)myEnumerator.Key;
					sb= sb.Replace("$" + key + "$", hs[key].ToString());
				}
				return sb.ToString();
			}
		}
	}
}
