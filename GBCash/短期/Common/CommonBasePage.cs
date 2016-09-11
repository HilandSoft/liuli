//<copyright>英网资讯技术有限公司 1999-2003</copyright>
//<version>V1.01</verion>
//<createdate>2003-7-7</createdate>
//<author>wuhp</author>
//<email>wuhp@qingdaojob.com</email>
//<log date="2003-7-7">创建</log>
//<log date="2003-8-1">增加职能权限列表功能</log>

using System;
using System.Collections;
using System.Data;
using System.Web;
using System.Web.UI.WebControls;

namespace YingNet.Common {
    /// <summary>
    /// 公共基础页面类
    /// </summary>
    public class CommonBasePage : System.Web.UI.Page {
        /// <summary>
        /// 统一的参数传递名
        /// </summary>
        public const string PARAM_NAME = "paramstr";

        public CommonBasePage() : base() {
        }

        /// <summary>
        /// 设置datagrid的分页
        /// </summary>
        /// <param name="dg">datagrid</param>
        /// <param name="dt">datatable</param>
        public static void SetPage (DataGrid dg, DataTable dt) {
            CommonBaseLib.SetPage(dg, dt);
            dg.DataSource = dt;
        }

        private Hashtable m_paramValue = new Hashtable();
        /// <summary>
        /// 传递的参数
        /// </summary>
        public Hashtable ParamValue {
            get {
                return m_paramValue;
            }
            set {
                m_paramValue = value;
            }
        }

        /// <summary>
        /// 增加传递的参数
        /// </summary>
        /// <param name="key">主健</param>
        /// <param name="keyValue">值</param>
        public void AddValue (string key, string keyValue) {
            if (m_paramValue == null) {
                m_paramValue = new Hashtable();
            }
            if (m_paramValue.Contains(key)) {
                m_paramValue.Remove(key);
            }
            m_paramValue.Add(key, keyValue);
        }

        /// <summary>
        /// 返回传递的参数
        /// </summary>
        /// <param name="key">主健</param>
        /// <returns>值</returns>
        public string GetValue (string key) {
            if (m_paramValue == null) {
                return null;
            }
            if (!m_paramValue.Contains(key)) {
                return null;
            }
            string result = m_paramValue[key].ToString();
            if (result.Equals("")) {
                return null;
            }
            return result;
        }
        
        /// <summary>
        /// 封装数据(paramstr=packstr)
        /// </summary>
        /// <param name="hs">待封装的数据</param>
        /// <returns>封装后的数据串</returns>
        public string PackFull (Hashtable hs) {
            return PARAM_NAME + "=" + WebUtils.Pack(hs);
        }

        /// <summary>
        /// 封装数据(paramstr=packstr)
        /// </summary>
        /// <param name="pack">待封装的数据串</param>
        /// <returns>封装后的数据串</returns>
        public string PackFull (string pack) {
            return PARAM_NAME + "=" + pack;
        }

        /// <summary>
        /// 封装数据（只是packstr）
        /// </summary>
        /// <param name="hs">待封装的数据</param>
        /// <returns>封装后的数据串</returns>
        public string PackPart (Hashtable hs) {
            return WebUtils.Pack(hs);
        }

        /// <summary>
        /// 从request中构造封装数据
        /// </summary>
        /// <returns>构造后的封装数据串</returns>
        public string GetPackStr () {
            //return BaseLib.PARAM_NAME + "=" + Page.Request.Params[BaseLib.PARAM_NAME];
            return HttpUtility.UrlEncode(Page.Request.Params[PARAM_NAME]);
        }

        /// <summary>
        /// 解包数据(paramstr=packstr)
        /// </summary>
        /// <param name="pack">封装的数据串</param>
        /// <returns>解包后的数据</returns>
        public Hashtable UnPackFull (string pack) {
            return WebUtils.UnPack(pack.Substring(pack.IndexOf("=")));
        }

        /// <summary>
        /// 为部分封装数据解包数据
        /// </summary>
        /// <param name="pack">封装的数据串</param>
        /// <returns>解包后的数据</returns>
        public Hashtable UnPackPart (string pack) {
            return WebUtils.UnPack(pack);
        }

        /// <summary>
        /// 封装数据解包数据
        /// </summary>
        /// <param name="pack">封装的数据串</param>
        /// <returns>解包后的数据</returns>
        public Hashtable UnPack () {
            return WebUtils.UnPack(HttpUtility.UrlEncode(Page.Request.Params[PARAM_NAME]));
        }
    	
//    	/// <summary>
//    	/// 功能模块名称
//    	/// </summary>
//    	/// <remarks>一般用于权限控制,每个模块重写这个属性为自己的模块名称</remarks>
//		public virtual string ModuleName
//		{
//			get
//			{
//				return string.Empty;
//			}
//		}
//    	
//    	/// <summary>
//    	/// 针对当前功能模块的操作类型
//    	/// </summary>
//    	/// <remarks>请在需要权限判断的页面中进行重写</remarks>
//		public virtual CommonOperateEnum CommonOperate
//		{
//			get
//			{
//				return CommonOperateEnum.All;
//			}
//		}
    }
}
