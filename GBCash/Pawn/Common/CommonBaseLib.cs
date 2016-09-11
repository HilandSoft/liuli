//<copyright>Ӣ����Ѷ�������޹�˾ 1999-2003</copyright>
//<version>V1.01</verion>
//<createdate>2003-7-3</createdate>
//<author>wuhp</author>
//<email>wuhp@qingdaojob.com</email>
//<log date="2003-7-3">����</log>
//<log date="2003-8-23">����group����,getcommonlistʵ��group���</log>

using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace YingNet.Common {
    /// <summary>
    /// BaseCommonLib ��ժҪ˵����
    /// </summary>
    public class CommonBaseLib {
        public CommonBaseLib() {
        }

        /// <summary>
        /// ����datagrid�ķ�ҳ
        /// </summary>
        /// <param name="dg">datagrid</param>
        /// <param name="dt">datatable</param>
        public static void SetPage (DataGrid dg, DataTable dt) {
            //���ҳ
            int maxPage = (int)(dt.Rows.Count + dg.PageSize - 1) / dg.PageSize;

            if (maxPage == 0) {
                maxPage = 1;
            }

            if (dg.CurrentPageIndex >= maxPage){
                dg.CurrentPageIndex = maxPage - 1;
            }
           
            //�����DataGridTable,����ȫ����¼��
            if (dg.GetType().FullName.Equals("YingNet.Common.DataGridTable")) {
                ((DataGridTable)dg).MaxRecord = dt.Rows.Count;
            }

            dg.DataSource = dt;

            return;
        }

		/// <summary>
		/// ����datagrid�ķ�ҳ
		/// </summary>
		/// <param name="dg">datagrid</param>
		/// <param name="dt">datatable</param>
		public static void SetPage (DataGrid dg, DataView dv) 
		{
			//���ҳ
			int maxPage = (int)(dv.Count + dg.PageSize - 1) / dg.PageSize;

			if (maxPage == 0) 
			{
				maxPage = 1;
			}

			if (dg.CurrentPageIndex >= maxPage)
			{
				dg.CurrentPageIndex = maxPage - 1;
			}
           
			//�����DataGridTable,����ȫ����¼��
			if (dg.GetType().FullName.Equals("YingNet.Common.DataGridTable")) 
			{
				((DataGridTable)dg).MaxRecord = dv.Count;
			}

			dg.DataSource = dv;

			return;
		}

        #region ���ݿ����
        private string m_filter = null;
        /// <summary>
        /// ���� and ��������
        /// </summary>
        public string Filter {
            get {
                if ((m_filter == null) || (m_filter.Equals(""))) {
                    return null;
                } else {
                    return m_filter;
                }
            }
            set {
                if (value == null) {//��null
                    m_filter = null;
                } else if (!value.Equals("")) {
                    if((m_filter == null) || (m_filter.Equals(""))) {
                        m_filter = value;
                    } else {
                        m_filter += " and " + value;
                    }
                }
            }
        }

        /// <summary>
        /// ���� or ��������
        /// </summary>
        public string OrFilter {
            set {
                if (value == null) {//��null
                    m_filter = null;
                } else if (!value.Equals("")) {
                    if((m_filter == null) || (m_filter.Equals(""))) {
                        m_filter = value;
                    } else {
                        m_filter += " or " + value;
                    }
                }
            }
        }

        /// <summary>
        /// ����ԭʼ��������
        /// </summary>
        public string RawFilter {
            set {
                if (value == null) {//��null
                    m_filter = null;
                } else if (!value.Equals("")) {
                    if((m_filter == null) || (m_filter.Equals(""))) {
                        m_filter = value;
                    } else {
                        m_filter += " " + value;
                    }
                }
            }
        }

        private string m_group = null;
        /// <summary>
        /// ���� group ����
        /// </summary>
        public string Group {
            get {
                if ((m_group == null) || (m_group.Equals(""))) {
                    return null;
                } else {
                    return m_group;
                }
            }
            set {
                m_group = value;
            }
        }

        private string m_order = null;
        /// <summary>
        /// ��������
        /// </summary>
        public string Order {
            get {
                if ((m_order == null) || (m_order.Equals(""))) {
                    return null;
                } else {
                    return m_order;
                }
            }
            set {
                m_order = value;
            }
        }

        private string m_dbFieldList = null;
        /// <summary>
        /// ���ݿ��ֶ��б�
        /// </summary>
        public string DBFieldList { 
            get {
                return m_dbFieldList; 
            }
            set {
                m_dbFieldList = value;
            }
        }
        
        private string m_dbTable = null;
        /// <summary>
        /// ���ݿ����
        /// </summary>
        public string DBTable { 
            get {
                return m_dbTable; 
            }
            set {
                m_dbTable = value;
            }
        }

        /// <summary>
        /// ���������б�
        /// </summary>
        /// <returns></returns>
        protected DataTable CommonGetList () {
            string sql = "select " + DBFieldList + " from " + DBTable;
            //�й�������
            if (Filter != null) {
                sql += " where " + Filter;
            }
            //��������
            if (Group != null) {
                sql += " group by " + Group;
            }
            //��������
            if (Order != null) {
                sql += " order by " + Order;
            }
            
            DBAccess dbAccess = new DBAccess();
            DataTable result = dbAccess.RunSqlString(sql, DBTable);

            //�ر����ݿ�����
            dbAccess.Close();
            
            return result;
        }
        #endregion

        #region ��Ϣ���
        private int m_code = 0;
        /// <summary>
        /// �������
        /// </summary>
        public int Code { 
            get {
                return m_code; 
            }
            set {
                m_code = value;
            }
        }

        private string m_msg = null;
        /// <summary>
        /// ��Ϣ
        /// </summary>
        public string Msg { 
            get {
                return m_msg; 
            }
            set {
                m_msg = value;
            }
        }
        #endregion
    }
}
