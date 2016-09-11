//<copyright>山东三维科技有限公司 1999-2003</copyright>
//<version>V1.0</verion>
//<createdate>2004-3-13</createdate>
//<author>wuhp</author>
//<email>wuhp@Yingnet.com</email>
//<log date="2004-3-13">从CommonBaseLib修改,不使用DBAccess对象,改为DBOperate对象</log>
//<log date="2004-3-13">增加保存状态相关操作</log>
//<log date="2005-5-8">修复恢复保存的状态中,状态恢复失败的bug</log>
//<log date="2005-8-23">增加SetPage (DataGrid dg, IList list)方法</log>

using System;
using System.Collections;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;

using YingNet.Common.Database;

namespace YingNet.Common {
    /// <summary>
    /// 一般项目的商业逻辑层基础类
    /// </summary>
    public class CommonBaseBusiness:IDisposable {
        //新建DBOperate对象
        protected DBOperate curDBOperater= null;
        private bool selfOp= false; //解然添加 判断是否为本对象内创建的DBOperater,便于释放


        public CommonBaseBusiness(DBOperate DBOper) {
            this.curDBOperater = DBOper;
            if(this.curDBOperater.baseConnection.State==ConnectionState.Closed) {
                this.curDBOperater.Open();
            }
            this.selfOp= false;
        }

        /// <summary>
        /// 新建数据库联接并打开
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

        #region IDisposable 成员

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
        /// 设置datagrid的分页
        /// </summary>
        /// <param name="dg">datagrid</param>
        /// <param name="dt">datatable</param>
        public static void SetPage (DataGrid dg, DataTable dt) {
            DataGridUtils.SetPage(dg, dt);
        }

        /// <summary>
        /// 设置datagrid的分页
        /// </summary>
        /// <param name="dg"></param>
        /// <param name="list"></param>
        public static void SetPage (DataGrid dg, IList list) {
            DataGridUtils.SetPage(dg, list);
        }

        #region 数据库相关
        private string m_filter = null;
        /// <summary>
        /// 设置 and 过滤条件
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
                if (value == null) {//置null
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
        /// 设置 or 过滤条件
        /// </summary>
        public string OrFilter {
            set {
                if (value == null) {//置null
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
        /// 设置原始过滤条件
        /// </summary>
        public string RawFilter {
            set {
                if (value == null) {//置null
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
        /// 设置 group 条件
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
        /// 排序条件
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
        /// 数据库字段列表
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
        /// 数据库表名
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
        /// 返回数据列表
        /// </summary>
        /// <returns></returns>
        protected DataTable CommonGetList () {
            string sql = "select " + DBFieldList + " from " + DBTable;
            //有过滤条件
            if (Filter != null) {
                sql += " where " + Filter;
            }
            //分组条件
            if (Group != null) {
                sql += " group by " + Group;
            }
            //排序条件
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

        #region 保存状态相关
        private Stack stack = null;
        /// <summary>
        /// 保存当前状态,包括fieldlist,tablename,filter,order,group
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
        /// 清除当前状态,包括fieldlist,tablename,filter,order,group
        /// </summary>
        public void CleanStatus () {
            DBFieldList = null;
            DBTable = null;
            Filter = null;
            Order = null;
            Group = null;
        }

        /// <summary>
        /// 恢复上一状态,,包括fieldlist,tablename,filter,order,group
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

        #region 消息相关
        private int m_code = 0;
        /// <summary>
        /// 错误代码
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
        /// 消息
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
