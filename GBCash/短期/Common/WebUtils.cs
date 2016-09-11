//<copyright>Ӣ����Ѷ�������޹�˾ 1999-2003</copyright>
//<version>V1.0</verion>
//<createdate>2003-7-14</createdate>
//<author>wuhp</author>
//<email>wuhp@qingdaojob.com</email>
//<log date="2003-7-14">����</log>

using System;
using System.Collections;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;

namespace YingNet.Common {
	/// <summary>
	/// web���ù��߼�
	/// </summary>
	public class WebUtils {
        /// <summary>
        /// ���ݴ洢
        /// </summary>
        private Hashtable hs = null;

		public WebUtils() {
		}

        /// <summary>
        /// �õ�url·��
        /// </summary>
        /// <param name="path">urlȫ·��</param>
        /// <returns>url·��</returns>
        public static string GetUrlPath (string path) {
            return(path.Substring(0,path.LastIndexOf("/")));
        }

        /// <summary>
        /// ���Ӵ洢����
        /// </summary>
        /// <param name="key">����</param>
        /// <param name="keyValue">ֵ</param>
        public void add (string key, string keyValue) {
            if (hs == null) {
                hs = new Hashtable();
            }
			if (hs.Contains(key)) 
			{
				hs.Remove(key);
			}
            hs.Add(key, keyValue);
        }

        /// <summary>
        /// ��װ�洢����
        /// </summary>
        /// <returns>��װ�õ����ݴ�</returns>
        public string Pack () {
            return Pack(hs);
        }

        /// <summary>
        /// ��װ�洢����
        /// </summary>
        /// <param name="hs">����װ������</param>
        /// <returns>��װ�õ����ݴ�</returns>
        public static string Pack (Hashtable hs) {
            if ((hs == null) || (hs.Count == 0)) {
                return null;
            }

            //key,value��'='�ָ�,(key,value)����'&'�ָ�
            StringBuilder buffer = null;

            IDictionaryEnumerator myEnumerator = hs.GetEnumerator();
            while(myEnumerator.MoveNext()) {
                if (buffer == null) {
                    buffer = new StringBuilder();
                } else {
                    buffer.Append("&");
                }
                //��һ���װ,��װvalue
                buffer.Append(myEnumerator.Key + "=" + HttpUtility.UrlEncode(myEnumerator.Value.ToString()));
            }
            //�ڶ����װ,��װ����pack��
            return HttpUtility.UrlEncode(buffer.ToString());
        }

        /// <summary>
        /// ��װ���Ľ��
        /// </summary>
        /// <param name="strPack">��װ��</param>
        /// <returns>����������</returns>
        public static Hashtable UnPack (string strPack) {
            if (strPack == null) {
                return null;
            }

            //�ڶ�����
            string pack = HttpUtility.UrlDecode(strPack);
            string[] keyValues = Regex.Split(pack, "&");
            
            Hashtable hs = new Hashtable();
            for (int i = 0; i < keyValues.Length; i++) {
                string[] result = Regex.Split(keyValues[i], "=");
                //��һ����
                if (result.Length >= 2) {
                    hs.Add(result[0], HttpUtility.UrlDecode(result[1]));
                }
            }
            return hs;
        }
	}
}
