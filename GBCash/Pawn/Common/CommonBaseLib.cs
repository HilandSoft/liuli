//<copyright>英网资讯技术有限公司 1999-2003</copyright>
//<version>V1.01</verion>
//<createdate>2003-7-3</createdate>
//<author>wuhp</author>
//<email>wuhp@qingdaojob.com</email>
//<log date="2003-7-3">创建</log>
//<log date="2003-8-23">增加group变量,getcommonlist实现group语句</log>

using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace YingNet.Common {
    /// <summary>
    /// BaseCommonLib 的摘要说明。
    /// </summary>
    public class CommonBaseLib {
        public CommonBaseLib() {
        }

        /// <summary>
        /// 设置datagrid的分页
        /// </summary>
        /// <param name="dg">datagrid</param>
        /// <param name="dt">datatable</param>
        public static void SetPage (DataGrid dg, DataTable dt) {
            //最大页
            int maxPage = (int)(dt.Rows.Count + dg.PageSize - 1) / dg.PageSize;

            if (maxPage == 0) {
                maxPage = 1;
            }

            if (dg.CurrentPageIndex >= maxPage){
                dg.CurrentPageIndex = maxPage - 1;
            }
           
            //如果是DataGridTable,设置全部记录数
            if (dg.GetType().FullName.Equals("YingNet.Common.DataGridTable")) {
                ((DataGridTable)dg).MaxRecord = dt.Rows.Count;
            }

            dg.DataSource = dt;

            return;
        }

		/// <summary>
		/// 设置datagrid的分页
		/// </summary>
		/// <param name="dg">datagrid</param>
		/// <param name="dt">datatable</param>
		public static void SetPage (DataGrid dg, DataView dv) 
		{
			//最大页
			int maxPage = (int)(dv.Count + dg.PageSize - 1) / dg.PageSize;

			if (maxPage == 0) 
			{
				maxPage = 1;
			}

			if (dg.CurrentPageIndex >= maxPage)
			{
				dg.CurrentPageIndex = maxPage - 1;
			}
           
			//如果是DataGridTable,设置全部记录数
			if (dg.GetType().FullName.Equals("YingNet.Common.DataGridTable")) 
			{
				((DataGridTable)dg).MaxRecord = dv.Count;
			}

			dg.DataSource = dv;

			return;
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
            
            DBAccess dbAccess = new DBAccess();
            DataTable result = dbAccess.RunSqlString(sql, DBTable);

            //关闭数据库连接
            dbAccess.Close();
            
            return result;
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
