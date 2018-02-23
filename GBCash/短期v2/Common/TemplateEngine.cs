using System;
using System.Collections;
using System.IO;
using System.Text;

namespace YingNet.Common
{
	/// <summary>
	/// TemplateEngine 的摘要说明。
	/// </summary>
	public class TemplateEngine
	{
		private Hashtable hs = new Hashtable();
		/// <summary>
		/// 构造器
		/// </summary>
		/// <param name="tempfile">模板文件名</param>
		public TemplateEngine(string tempfile) : this(tempfile, "gb2312")
		{
		}

		/// <summary>
		/// 构造器
		/// </summary>
		/// <param name="tempfile">模板文件名</param>
		/// <param name="encoding">文件编码</param>
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
		/// 正文
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
