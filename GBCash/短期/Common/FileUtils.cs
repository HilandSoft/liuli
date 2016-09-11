using System;
using System.IO;
using System.Text;

namespace YingNet.Common
{
	/// <summary>
	/// FileUtils 的摘要说明。
	/// </summary>
	public class FileUtils
	{
		public FileUtils()
		{
			//
			// TODO: 在此处添加构造函数逻辑
			//
		}

		/// <summary>
		/// 读取文件内容
		/// </summary>
		/// <param name="filename">文件名</param>
		/// <param name="encoding">文件编码</param>
		/// <returns>文件正文</returns>
		public static StringBuilder GetContent (string filename, string encoding) 
		{
			StringBuilder sb = new StringBuilder();
			StreamReader reader = new StreamReader(filename ,System.Text.Encoding.GetEncoding(encoding));
			string line = null;
			while ((line = reader.ReadLine()) != null) 
			{
				sb.Append(line + "\r\n");
			}
			reader.Close();
			return sb;
		}
	}
}
