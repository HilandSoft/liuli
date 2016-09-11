//<copyright>Ӣ����Ѷ�������޹�˾ 1999-2003</copyright>
//<version>V1.01</verion>
//<createdate>2003-7-7</createdate>
//<author>wuhp</author>
//<email>wuhp@qingdaojob.com</email>
//<log date="2003-7-7">����</log>
//<log date="2003-8-1">����ְ��Ȩ���б���</log>

using System;
using System.Collections;
using System.Data;
using System.Web;
using System.Web.UI.WebControls;

namespace YingNet.Common {
    /// <summary>
    /// ��������ҳ����
    /// </summary>
    public class CommonBasePage : System.Web.UI.Page {
        /// <summary>
        /// ͳһ�Ĳ���������
        /// </summary>
        public const string PARAM_NAME = "paramstr";

        public CommonBasePage() : base() {
        }

        /// <summary>
        /// ����datagrid�ķ�ҳ
        /// </summary>
        /// <param name="dg">datagrid</param>
        /// <param name="dt">datatable</param>
        public static void SetPage (DataGrid dg, DataTable dt) {
            CommonBaseLib.SetPage(dg, dt);
            dg.DataSource = dt;
        }

        private Hashtable m_paramValue = new Hashtable();
        /// <summary>
        /// ���ݵĲ���
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
        /// ���Ӵ��ݵĲ���
        /// </summary>
        /// <param name="key">����</param>
        /// <param name="keyValue">ֵ</param>
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
        /// ���ش��ݵĲ���
        /// </summary>
        /// <param name="key">����</param>
        /// <returns>ֵ</returns>
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
        /// ��װ����(paramstr=packstr)
        /// </summary>
        /// <param name="hs">����װ������</param>
        /// <returns>��װ������ݴ�</returns>
        public string PackFull (Hashtable hs) {
            return PARAM_NAME + "=" + WebUtils.Pack(hs);
        }

        /// <summary>
        /// ��װ����(paramstr=packstr)
        /// </summary>
        /// <param name="pack">����װ�����ݴ�</param>
        /// <returns>��װ������ݴ�</returns>
        public string PackFull (string pack) {
            return PARAM_NAME + "=" + pack;
        }

        /// <summary>
        /// ��װ���ݣ�ֻ��packstr��
        /// </summary>
        /// <param name="hs">����װ������</param>
        /// <returns>��װ������ݴ�</returns>
        public string PackPart (Hashtable hs) {
            return WebUtils.Pack(hs);
        }

        /// <summary>
        /// ��request�й����װ����
        /// </summary>
        /// <returns>�����ķ�װ���ݴ�</returns>
        public string GetPackStr () {
            //return BaseLib.PARAM_NAME + "=" + Page.Request.Params[BaseLib.PARAM_NAME];
            return HttpUtility.UrlEncode(Page.Request.Params[PARAM_NAME]);
        }

        /// <summary>
        /// �������(paramstr=packstr)
        /// </summary>
        /// <param name="pack">��װ�����ݴ�</param>
        /// <returns>����������</returns>
        public Hashtable UnPackFull (string pack) {
            return WebUtils.UnPack(pack.Substring(pack.IndexOf("=")));
        }

        /// <summary>
        /// Ϊ���ַ�װ���ݽ������
        /// </summary>
        /// <param name="pack">��װ�����ݴ�</param>
        /// <returns>����������</returns>
        public Hashtable UnPackPart (string pack) {
            return WebUtils.UnPack(pack);
        }

        /// <summary>
        /// ��װ���ݽ������
        /// </summary>
        /// <param name="pack">��װ�����ݴ�</param>
        /// <returns>����������</returns>
        public Hashtable UnPack () {
            return WebUtils.UnPack(HttpUtility.UrlEncode(Page.Request.Params[PARAM_NAME]));
        }
    	
//    	/// <summary>
//    	/// ����ģ������
//    	/// </summary>
//    	/// <remarks>һ������Ȩ�޿���,ÿ��ģ����д�������Ϊ�Լ���ģ������</remarks>
//		public virtual string ModuleName
//		{
//			get
//			{
//				return string.Empty;
//			}
//		}
//    	
//    	/// <summary>
//    	/// ��Ե�ǰ����ģ��Ĳ�������
//    	/// </summary>
//    	/// <remarks>������ҪȨ���жϵ�ҳ���н�����д</remarks>
//		public virtual CommonOperateEnum CommonOperate
//		{
//			get
//			{
//				return CommonOperateEnum.All;
//			}
//		}
    }
}
