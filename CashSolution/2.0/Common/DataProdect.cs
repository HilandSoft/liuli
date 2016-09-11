using System;
using System.IO;
using System.Text;

using System.Security.Cryptography;

namespace YingNet.Common
{
	/// <summary>
	/// DataProdect ��ժҪ˵����
	/// </summary>
	public class DataProdect
	{
		public DataProdect()
		{
			//
			// TODO: �ڴ˴���ӹ��캯���߼�
			//
		}

		private static string sKey="wjtzcdys";//�����ܳ�

		/// <summary>
		/// ����DES���ܡ�
		/// </summary>
		/// <param name="pToEncrypt">Ҫ���ܵ��ַ�����</param>
		/// <returns>��Base64��ʽ���صļ����ַ�����</returns>
		public static string Encrypt(string pToEncrypt)
		{
			using(DESCryptoServiceProvider des = new DESCryptoServiceProvider())
			{
				byte[]  inputByteArray = Encoding.UTF8.GetBytes(pToEncrypt);
				des.Key = ASCIIEncoding.ASCII.GetBytes(sKey);
				des.IV = ASCIIEncoding.ASCII.GetBytes(sKey);
				System.IO.MemoryStream ms = new System.IO.MemoryStream();
				using(CryptoStream cs = new CryptoStream(ms,des.CreateEncryptor(),CryptoStreamMode.Write))
				{
					cs.Write(inputByteArray,0,inputByteArray.Length);
					cs.FlushFinalBlock();
					cs.Close();
				}
				string str = Convert.ToBase64String(ms.ToArray());
				ms.Close();
				return str;
			}
		}
	
		/// <summary>
		/// ����DES���ܡ�
		/// </summary>
		/// <param name="pToDecrypt">Ҫ���ܵ���Base64</param>
		/// <returns>�ѽ��ܵ��ַ�����</returns>
		public static string Decrypt(string pToDecrypt)
		{
			byte[] inputByteArray = Convert.FromBase64String(pToDecrypt);
			using(DESCryptoServiceProvider des = new DESCryptoServiceProvider())
			{
				des.Key=ASCIIEncoding.ASCII.GetBytes(sKey);
				des.IV=ASCIIEncoding.ASCII.GetBytes(sKey);
				System.IO.MemoryStream ms = new System.IO.MemoryStream();
				using(CryptoStream cs = new CryptoStream(ms,des.CreateDecryptor(),CryptoStreamMode.Write))
				{
					cs.Write(inputByteArray,0,inputByteArray.Length);
					cs.FlushFinalBlock();
					cs.Close();
				}
				string str = Encoding.UTF8.GetString(ms.ToArray());
				ms.Close();
				return str;
			}
		}

	}
}
