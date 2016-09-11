using System;
using System.Web.Security;
using System.Security.Cryptography;
using System.Text;

using System.IO;

namespace YingNet.Common
{
	/// <summary>
	/// Cipher 的摘要说明。
	/// </summary>
	public class Cipher
	{
		
		/// <summary>
		/// 密匙长度取8位
		/// </summary>
		private static string s_key="        ";
		private static byte[] b_key=new byte[8];
		/// <summary>
		/// 获取设置密钥
		/// </summary>
		public static string	Key{
			get{
				return s_key;
			}
			set{
				s_key=value+"         ";
				char[] b_temp=new char[8];
				s_key.CopyTo(0,b_temp,0,8);				
				b_key=System.Text.Encoding.Unicode.GetBytes(b_temp);   				
			}
		}
		/// <summary>
		/// 向量长度取8位
		/// </summary>
		private static string s_iv="        ";
		/// <summary>
		/// 偏移量
		/// </summary>
		private static byte[] b_iv=new byte[8];
		/// <summary>
		/// 设置获取偏移量
		/// </summary>
		public static string IV{
			get{
				return s_iv;
			}
			set{
				s_iv=value+"         ";
				char[] b_temp=new char[8];
				s_iv.CopyTo(0,b_temp,0,8);				
				b_iv=System.Text.Encoding.Unicode.GetBytes(b_temp); 				
			}
		}
		public Cipher()
		{
			//
			// TODO: 在此处添加构造函数逻辑
			//
		}
		/// <summary>
		/// MD5的加密算法
		/// </summary>
		/// <param name="text">明文</param>
		/// <returns>密文</returns>
		public static string EncryptMD5(string text){
			return FormsAuthentication.HashPasswordForStoringInConfigFile(text,"MD5");			
		}
		/// <summary>
		/// Des字节组加密算法
		/// </summary>
		/// <param name="b">明文</param>
		/// <returns>密文</returns>
		public static byte[] EncryptDES(byte[] b){
			return Encrypt(b,true);													   
			
		}
		/// <summary>
		/// Des字节组解密算法
		/// </summary>
		/// <param name="b">密文</param>
		/// <returns>明文</returns>
		public static byte[] DecryptDES(byte[] b){
			return Encrypt(b,false);  			
		}
		/// <summary>
		/// Des加密
		/// </summary>
		/// <param name="b">传入的字节组</param>
		/// <param name="bl_crypt">true加密，false解密</param>
		/// <returns>加解密后的字节组</returns>
		private static byte[] Encrypt(byte[] b,bool bl_crypt){
			DES _des=DES.Create(	);
			Byte[] key = {0x01, 0x23, 0x45, 0x67, 0x89, 0xab, 0xcd, 0xef};
			Byte[] IV = {0x12, 0x34, 0x56, 0x78, 0x90, 0xab, 0xcd, 0xef};
			_des.IV=IV;    //b_iv;
			_des.Key=key;  //b_key;
			byte[] b_result;
			if(bl_crypt){
				b_result= _des.CreateEncryptor().TransformFinalBlock(b,0,b.Length);
			}
			else{
				b_result= _des.CreateDecryptor().TransformFinalBlock(b,0,b.Length);
			}
			_des.Clear();
			return b_result;
		}
		/// <summary>
		/// Des字符串串加密算法
		/// </summary>
		/// <param name="text">明文</param>
		/// <returns>密文</returns>
		public static string EncryptDES(string text){
			byte[] b=EncryptDES(System.Text.Encoding.Unicode.GetBytes(text));
			return System.Text.Encoding.Unicode.GetString(b);
			
		}
		/// <summary>
		/// Des字符串串解密算法
		/// </summary>
		/// <param name="text">密文</param>
		/// <returns>明文</returns>
		public static string DecryptDES(string text){
			byte[] b=DecryptDES(System.Text.Encoding.Unicode.GetBytes(text));
			return System.Text.Encoding.Unicode.GetString(b);
		}
		/// <summary>
		/// 3Des的加密算法
		/// </summary>
		/// <call>dfhgdsuihgsdjih</call>
		/// <param name="b">明文</param>
		/// <param name="bl_crypt">是否加密</param>
		/// <returns>返回明文</returns>
		public static byte[] EncryptTripleDES(byte[] b,bool bl_crypt){
			return null;
		}
		

		/// <summary>
		/// 加密原函数
		/// </summary>
		/// <param name="pToEncrypt"></param>
		/// <param name="sKey"></param>
		/// <returns></returns>
		public static string DesEncrypt(string pToEncrypt, string sKey)
		{
			DESCryptoServiceProvider des = new DESCryptoServiceProvider();
			byte[] inputByteArray = Encoding.Default.GetBytes(pToEncrypt);
			des.Key = ASCIIEncoding.ASCII.GetBytes(sKey);
			des.IV = ASCIIEncoding.ASCII.GetBytes(sKey);
			MemoryStream ms = new MemoryStream();
			CryptoStream cs = new CryptoStream(ms, des.CreateEncryptor(), CryptoStreamMode.Write);
			cs.Write(inputByteArray, 0, inputByteArray.Length);
			cs.FlushFinalBlock();
			StringBuilder ret = new StringBuilder();
			foreach (byte b in ms.ToArray())
			{
				ret.AppendFormat("{0:X2}", b);
			}
			ret.ToString();
			return ret.ToString();
			//return a;
		}
		/// <summary>
		/// 解密原函数
		/// </summary>
		/// <param name="pToDecrypt"></param>
		/// <param name="sKey"></param>
		/// <returns></returns>
		public static string DesDecrypt(string pToDecrypt, string sKey)
		{
			DESCryptoServiceProvider des = new DESCryptoServiceProvider();
			byte[] inputByteArray = new byte[pToDecrypt.Length / 2];
			for (int x = 0; x < pToDecrypt.Length / 2; x++)
			{
				int i = (Convert.ToInt32(pToDecrypt.Substring(x * 2, 2), 16));
				inputByteArray[x] = (byte)i;
			}
			des.Key = ASCIIEncoding.ASCII.GetBytes(sKey);
			des.IV = ASCIIEncoding.ASCII.GetBytes(sKey);
			MemoryStream ms = new MemoryStream();
			CryptoStream cs = new CryptoStream(ms, des.CreateDecryptor(), CryptoStreamMode.Write);
			cs.Write(inputByteArray, 0, inputByteArray.Length);
			cs.FlushFinalBlock();
			StringBuilder ret = new StringBuilder();
			return System.Text.Encoding.Default.GetString(ms.ToArray());
		}

	}
}
