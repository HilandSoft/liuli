using System;
using System.IO;
using System.Text;

namespace YingNet.Common
{
	/// <summary>
	/// FileUtils ��ժҪ˵����
	/// </summary>
	public class FileUtils
	{
		public FileUtils()
		{
			//
			// TODO: �ڴ˴���ӹ��캯���߼�
			//
		}

		/// <summary>
		/// ��ȡ�ļ�����
		/// </summary>
		/// <param name="filename">�ļ���</param>
		/// <param name="encoding">�ļ�����</param>
		/// <returns>�ļ�����</returns>
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
