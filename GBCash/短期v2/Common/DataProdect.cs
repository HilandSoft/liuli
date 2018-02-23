using System;
using System.IO;
using System.Text;

using System.Security.Cryptography;

namespace YingNet.Common
{
	/// <summary>
	/// DataProdect 的摘要说明。
	/// </summary>
	public class DataProdect
	{
		public DataProdect()
		{
			//
			// TODO: 在此处添加构造函数逻辑
			//
		}

		private static string sKey="wjtzcdys";//加密密匙

		/// <summary>
		/// 进行DES加密。
		/// </summary>
		/// <param name="pToEncrypt">要加密的字符串。</param>
		/// <returns>以Base64格式返回的加密字符串。</returns>
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
		/// 进行DES解密。
		/// </summary>
		/// <param name="pToDecrypt">要解密的以Base64</param>
		/// <returns>已解密的字符串。</returns>
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
