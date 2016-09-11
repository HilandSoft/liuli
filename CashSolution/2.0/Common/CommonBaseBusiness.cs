//<copyright>ɽ����ά�Ƽ����޹�˾ 1999-2003</copyright>
//<version>V1.0</verion>
//<createdate>2004-3-13</createdate>
//<author>wuhp</author>
//<email>wuhp@Yingnet.com</email>
//<log date="2004-3-13">��CommonBaseLib�޸�,��ʹ��DBAccess����,��ΪDBOperate����</log>
//<log date="2004-3-13">���ӱ���״̬��ز���</log>
//<log date="2005-5-8">�޸��ָ������״̬��,״̬�ָ�ʧ�ܵ�bug</log>
//<log date="2005-8-23">����SetPage (DataGrid dg, IList list)����</log>

using System;
using System.Collections;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;

using YingNet.Common.Database;

namespace YingNet.Common {
    /// <summary>
    /// һ����Ŀ����ҵ�߼��������
    /// </summary>
    public class CommonBaseBusiness:IDisposable {
        //�½�DBOperate����
        protected DBOperate curDBOperater= null;
        private bool selfOp= false; //��Ȼ��� �ж��Ƿ�Ϊ�������ڴ�����DBOperater,�����ͷ�


        public CommonBaseBusiness(DBOperate DBOper) {
            this.curDBOperater = DBOper;
            if(this.curDBOperater.baseConnection.State==ConnectionState.Closed) {
                this.curDBOperater.Open();
            }
            this.selfOp= false;
        }

        /// <summary>
        /// �½����ݿ����Ӳ���
        /// </summary>
        /// <param name="strDBServer"></param>
        /// <param name="strDBName"></param>
        /// <param name="strDBUser"></param>
        /// <param name="strDBPwd"></param>
        /// <param name="iDBType"></param>
        public CommonBaseBusiness (string strDBServer,string strDBName, string strDBUser, string strDBPwd, int iDBType) {
            curDBOperater = DBOperatorFactory.GetDBOperator(strDBServer, strDBName, strDBUser, strDBPwd, iDBType);
            curDBOperater.Open();
            this.selfOp= true;
        }

        public CommonBaseBusiness(string connectString)
        {
            curDBOperater = DBOperatorFactory.GetDBOperator(connectString);
            curDBOperater.Open();
            this.selfOp = true;
        }

        public void BeginTran() {
            this.curDBOperater.BeginTran();
        }

        public void CommitTran() {
            this.curDBOperater.CommitTran();
        }

        public void RollBackTran() {
            this.curDBOperater.RollBackTran();
        }

        public void Close() {
            this.curDBOperater.Close();
        }

        #region IDisposable ��Ա

        public void Dispose() {
            this.Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected void Dispose(bool disposing) {
            if(disposing==false) {
                return;
            }

            if(this.selfOp== true&& this.curDBOperater!= null) {
                this.curDBOperater.Dispose();
                this.curDBOperater= null;
            }
        }

        #endregion

        /// <summary>
        /// ����datagrid�ķ�ҳ
        /// </summary>
        /// <param name="dg">datagrid</param>
        /// <param name="dt">datatable</param>
        public static void SetPage (DataGrid dg, DataTable dt) {
            DataGridUtils.SetPage(dg, dt);
        }

        /// <summary>
        /// ����datagrid�ķ�ҳ
        /// </summary>
        /// <param name="dg"></param>
        /// <param name="list"></param>
        public static void SetPage (DataGrid dg, IList list) {
            DataGridUtils.SetPage(dg, list);
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

            DataTable result = curDBOperater.ExecQueryForDataTable(sql);
            
            return result;
        }

        protected DataTable GetListWithSP(string spName,IDataParameter[] para)
        {
            DataTable result = curDBOperater.ExecProcForDataTable(spName,para);
            return result;
        }


        #endregion

        #region ����״̬���
        private Stack stack = null;
        /// <summary>
        /// ���浱ǰ״̬,����fieldlist,tablename,filter,order,group
        /// </summary>
        public void PushStatus () {
            if (stack == null) {
                stack = new Stack();
            }
            stack.Push(DBFieldList);
            stack.Push(DBTable);
            stack.Push(Filter);
            stack.Push(Order);
            stack.Push(Group);
        }

        /// <summary>
        /// �����ǰ״̬,����fieldlist,tablename,filter,order,group
        /// </summary>
        public void CleanStatus () {
            DBFieldList = null;
            DBTable = null;
            Filter = null;
            Order = null;
            Group = null;
        }

        /// <summary>
        /// �ָ���һ״̬,,����fieldlist,tablename,filter,order,group
        /// </summary>
        public void PopStatus () {
            if (stack != null) {
                object obj = null;
                obj = stack.Pop();
                if (obj != null) {
                    m_group = obj.ToString();
                } else {
                    m_group = null;
                }
                obj = stack.Pop();
                if (obj != null) {
                    m_order = obj.ToString();
                } else {
                    m_order = null;
                }
                obj = stack.Pop();
                if (obj != null) {
                    m_filter = obj.ToString();
                } else {
                    m_filter = null;
                }
                obj = stack.Pop();
                if (obj != null) {
                    m_dbTable = obj.ToString();
                } else {
                    m_dbTable = null;
                }
                obj = stack.Pop();
                if (obj != null) {
                    m_dbFieldList = obj.ToString();
                } else {
                    m_dbFieldList = null;
                }
            }
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
