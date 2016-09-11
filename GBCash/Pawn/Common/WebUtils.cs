//<copyright>英网资讯技术有限公司 1999-2003</copyright>
//<version>V1.0</verion>
//<createdate>2003-7-14</createdate>
//<author>wuhp</author>
//<email>wuhp@qingdaojob.com</email>
//<log date="2003-7-14">创建</log>

using System;
using System.Collections;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;

namespace YingNet.Common {
	/// <summary>
	/// web常用工具集
	/// </summary>
	public class WebUtils {
        /// <summary>
        /// 数据存储
        /// </summary>
        private Hashtable hs = null;

		public WebUtils() {
		}

        /// <summary>
        /// 得到url路径
        /// </summary>
        /// <param name="path">url全路经</param>
        /// <returns>url路径</returns>
        public static string GetUrlPath (string path) {
            return(path.Substring(0,path.LastIndexOf("/")));
        }

        /// <summary>
        /// 增加存储数据
        /// </summary>
        /// <param name="key">名称</param>
        /// <param name="keyValue">值</param>
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
        /// 包装存储数据
        /// </summary>
        /// <returns>包装好的数据串</returns>
        public string Pack () {
            return Pack(hs);
        }

        /// <summary>
        /// 包装存储数据
        /// </summary>
        /// <param name="hs">待封装的数据</param>
        /// <returns>包装好的数据串</returns>
        public static string Pack (Hashtable hs) {
            if ((hs == null) || (hs.Count == 0)) {
                return null;
            }

            //key,value用'='分隔,(key,value)对用'&'分隔
            StringBuilder buffer = null;

            IDictionaryEnumerator myEnumerator = hs.GetEnumerator();
            while(myEnumerator.MoveNext()) {
                if (buffer == null) {
                    buffer = new StringBuilder();
                } else {
                    buffer.Append("&");
                }
                //第一层包装,包装value
                buffer.Append(myEnumerator.Key + "=" + HttpUtility.UrlEncode(myEnumerator.Value.ToString()));
            }
            //第二层包装,包装整个pack串
            return HttpUtility.UrlEncode(buffer.ToString());
        }

        /// <summary>
        /// 包装串的解包
        /// </summary>
        /// <param name="strPack">包装串</param>
        /// <returns>解包后的数据</returns>
        public static Hashtable UnPack (string strPack) {
            if (strPack == null) {
                return null;
            }

            //第二层解包
            string pack = HttpUtility.UrlDecode(strPack);
            string[] keyValues = Regex.Split(pack, "&");
            
            Hashtable hs = new Hashtable();
            for (int i = 0; i < keyValues.Length; i++) {
                string[] result = Regex.Split(keyValues[i], "=");
                //第一层解包
                if (result.Length >= 2) {
                    hs.Add(result[0], HttpUtility.UrlDecode(result[1]));
                }
            }
            return hs;
        }
	}
}
