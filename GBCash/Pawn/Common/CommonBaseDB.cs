//<copyright>山东三维科技有限公司 1999-2004</copyright>
//<version>V1.0</verion>
//<createdate>2004-3-12</createdate>
//<author>wangyh</author>
//<email>wangyh@qingdaojob.com</email>
//<log date="2004-3-12">创建</log>

using System;
using System.Data.SqlClient;
using System.Data.OleDb;
using System.Data;

using YingNet.Common.Database;

namespace YingNet.Common {
    /// <summary>
    /// CommonBaseDB 的摘要说明。
    /// </summary>
    public class CommonBaseDB {
        //新建DBOperate对象
        private DBOperate curDBOperater;

        //定义用户输入的Sql语句的类型 0:更新语句 1:存储过程 2:Select语句  -1:错误语句
        private const int UPDATESQL = 0;
        private const int PROCEDURESQL = 1;
        private const int SELECTSQL = 2;
        private const int ERRORSQL = -1;

        //根据需要再增加其它类型的数据库标志
        const int MSSQLSERVER = DBOperatorFactory.MSSQLSERVER;
        const int MSACCESS = DBOperatorFactory.MSACCESS;
        /*
        const int ORACLE = 3;
        const int DB2 = 4;
        const int MYSQL = 5;
        const int FXOPRO = 6;
        */

        public CommonBaseDB(DBOperate dbOper) {
            this.curDBOperater = dbOper;
            //this.curDBOperater.Open(); // 解然注释掉[3/26/2004]
        }
/*
        public CommonBaseDB (string strDBServer,string strDBName, string strDBUser, string strDBPwd, int iDBType) {
            GetCurDB(strDBServer,strDBName, strDBUser, strDBPwd, iDBType);
        }

        //利用Factory方法，根据用户的参数设置取得响应的数据库操作对象
        protected void GetCurDB(string strDBServer,string strDBName, string strDBUser, string strDBPwd, int iDBType) {
            this.curDBOperater = DBOperatorFactory.GetDBOperator(strDBServer, strDBName, strDBUser, strDBPwd, iDBType);
            this.curDBOperater.Open();
        }
	*/	
        /// <summary>
        /// 打开数据库连接
        /// </summary>
        public void Open() {
            curDBOperater.Open();
        }

        /// <summary>
        /// 关闭数据库连接
        /// </summary>
        public void Close() {
            curDBOperater.Close();
        }

        /// <summary>
        /// 开始一个事务
        /// </summary>
        public void BeginTran() {
            curDBOperater.BeginTran();
        }

        /// <summary>
        /// 提交一个事务
        /// </summary>
        public void CommitTran() {
            curDBOperater.CommitTran();
        }

        /// <summary>
        /// 回滚一个事务
        /// </summary>
        public void RollBackTran() {
            curDBOperater.RollBackTran();
        }

        /// <summary>
        /// 根据sql语句判断是否是存储过程 
        /// </summary>
        /// <param name="strSql"></param>
        /// <returns></returns>
        private int GetSqlType(string strSql) {
            //记录SQL语句的开始字符
            string strTop = "";
            //如果为空
            if(strSql==null || strSql.Length==0) {
                return ERRORSQL;
            }
            if(strSql.Length>7) {
                //取出字符串的前7位
                strTop = strSql.Substring(0,7).ToUpper();

                //如果不是存储过程
                if(strTop.Equals("UPDATE ") || strTop.Equals("INSERT ") || strTop.Equals("DELETE ") ||strTop.Equals("ALTER T") || strTop.Equals("ALTER  ") || strTop.Equals("BACKUP ") || strTop.Equals("RESTORE") ) {
                    return UPDATESQL;
                }

                    //如果是Select语句
                else if(strTop.Equals("SELECT ")) {
                    return SELECTSQL;
                }
                    //如果是存储过程
                else {
                    return PROCEDURESQL;
                }
            }

                //如果是存储过程
            else {
                return PROCEDURESQL;
            }
        }

        /// <summary>
        /// 非预处理返回Int型的Sql语句
        /// </summary>
        /// <param name="strSql"></param>
        /// <returns></returns>
        public int ExecuteForInt(string strSql) {
            //判断Sql语句的类型
            int iSqlType = GetSqlType(strSql);

            //如果是空语句
            if( iSqlType== ERRORSQL) {
                return -1;
            }

            //如果是更新语句
            if(iSqlType == UPDATESQL) {
                return curDBOperater.ExecUpdateSql(strSql);
            }

                //如果是存储过程
            else if(iSqlType == PROCEDURESQL) {
                return curDBOperater.ExecUpdateProc(strSql,null);
            }

                //如果是其他语句
            else {
                return -1;
            }
        }

        public object ExecuteForScalar(string strSql)
        {
            //判断Sql语句的类型
            int iSqlType = GetSqlType(strSql);

            //如果是空语句
            if (iSqlType == ERRORSQL)
            {
                return -1;
            }

            //如果是更新语句
            if (iSqlType == SELECTSQL)
            {
                return curDBOperater.ExecScalar(strSql);
            }

                //如果是存储过程
            else if (iSqlType == PROCEDURESQL)
            {
                return curDBOperater.ExecScalar(strSql, null);
            }

                //如果是其他语句
            else
            {
                return -1;
            }

        }

        /// <summary>
        /// 预处理返回Int型的Sql语句
        /// </summary>
        /// <param name="strSql"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public int ExecuteForInt(string strSql, IDataParameter[] parameters) {
            //判断Sql语句的类型
            int iSqlType = GetSqlType(strSql);

            //如果是空语句
            if(iSqlType == ERRORSQL) {
                return -1;
            }

            //如果是更新语句
            if(iSqlType == UPDATESQL) {
                return curDBOperater.ExecPreUpdateSql(strSql,parameters);
            }

                //如果是存储过程
            else if(iSqlType == PROCEDURESQL) {
                return curDBOperater.ExecUpdateProc(strSql,parameters);
            }

                //如果是其他语句
            else {
                return -1;
            }
        }

        /// <summary>
        /// 非预处理返回DataSet型的Sql语句
        /// </summary>
        /// <param name="strSql"></param>
        /// <returns></returns>
        public DataSet ExecuteForDataSet(string strSql, string strTableName) {
            //判断Sql语句的类型
            int iSqlType = GetSqlType(strSql);

            //如果是空语句
            if(iSqlType == ERRORSQL) {
                return null;
            }

            //如果是Select语句
            if(iSqlType == SELECTSQL) {
                return curDBOperater.ExecQueryForDataSet(strSql,strTableName);
            }

                //如果是存储过程
            else if(iSqlType == PROCEDURESQL) {
                return curDBOperater.ExecProcForDataSet(strSql,null,strTableName);
            }

                //如果是其他语句
            else {
                return null;
            }
        }

        /// <summary>
        /// 预处理返回DataSet型的Sql语句
        /// </summary>
        /// <param name="strSql"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public DataSet ExecuteForDataSet(string strSql, IDataParameter[] parameters, string strTableName) {
            //判断Sql语句的类型
            int iSqlType = GetSqlType(strSql);

            //如果是空语句
            if(iSqlType == ERRORSQL) {
                return null;
            }

            //如果是Select语句
            if(iSqlType == SELECTSQL) {
                return curDBOperater.ExecPreQueryForDataSet(strSql,parameters,strTableName);
            }

                //如果是存储过程
            else if(iSqlType == PROCEDURESQL) {
                return curDBOperater.ExecProcForDataSet(strSql,parameters,strTableName);
            }

                //如果是其他语句
            else {
                return null;
            }
        }

        /// <summary>
        /// 非预处理返回DataTable型的Sql语句
        /// </summary>
        /// <param name="strSql"></param>
        /// <returns></returns>
        public DataTable ExecuteForDataTable(string strSql) {
            //判断Sql语句的类型
            int iSqlType = GetSqlType(strSql);

            //如果是空语句
            if(iSqlType == ERRORSQL) {
                return null;
            }

            //如果是Select语句
            if(iSqlType == SELECTSQL) {
                return curDBOperater.ExecQueryForDataTable(strSql);
            }

                //如果是存储过程
            else if(iSqlType == PROCEDURESQL) {
                return curDBOperater.ExecProcForDataTable(strSql,null);
            }

                //如果是其他语句
            else {
                return null;
            }
        }

        /// <summary>
        /// 预处理返回DataTable型的Sql语句
        /// </summary>
        /// <param name="strSql"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public DataTable ExecuteForDataTable(string strSql, IDataParameter[] parameters) {
            //判断Sql语句的类型
            int iSqlType = GetSqlType(strSql);

            //如果是空语句
            if(iSqlType == ERRORSQL) {
                return null;
            }

            //如果是Select语句
            if(iSqlType == SELECTSQL) {
                return curDBOperater.ExecPreQueryForDataTable(strSql,parameters);
            }

                //如果是存储过程
            else if(iSqlType == PROCEDURESQL) {
                return curDBOperater.ExecProcForDataTable(strSql,parameters);
            }

                //如果是其他语句
            else {
                return null;
            }
        }

        /// <summary>
        /// 非预处理返回DataReader型的Sql语句
        /// </summary>
        /// <param name="strSql"></param>
        /// <returns></returns>
        public IDataReader ExecuteForDataReader(string strSql) {
            //判断Sql语句的类型
            int iSqlType = GetSqlType(strSql);

            //如果是空语句
            if(iSqlType == ERRORSQL) {
                return null;
            }

            //如果是Select语句
            if(iSqlType == SELECTSQL) {
                return curDBOperater.ExecQueryForDataReader(strSql) ;
            }

                //如果是存储过程
            else if(iSqlType == PROCEDURESQL) {
                return curDBOperater.ExecProcForDataReader(strSql,null);
            }

                //如果是其他语句
            else {
                return null;
            }
        }

        /// <summary>
        /// 预处理返回DataReader型的Sql语句
        /// </summary>
        /// <param name="strSql"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public IDataReader ExecuteForDataReader(string strSql, IDataParameter[] parameters) {
            //判断Sql语句的类型
            int iSqlType = GetSqlType(strSql);

            //如果是空语句
            if(iSqlType == ERRORSQL) {
                return null;
            }

            //如果是Select语句
            if(iSqlType == SELECTSQL) {
                return curDBOperater.ExecPreQueryForDataReader(strSql,parameters);
            }

                //如果是存储过程
            else if(iSqlType == PROCEDURESQL) {
                return curDBOperater.ExecProcForDataReader(strSql,parameters);
            }

                //如果是其他语句
            else {
                return null;
            }
        }

        public object ExecuteForScalar(string strSql, IDataParameter[] parameters)
        {
            //判断Sql语句的类型
            int iSqlType = GetSqlType(strSql);

            //如果是空语句
            if (iSqlType == ERRORSQL)
            {
                return null;
            }

            //如果是Select语句
            if (iSqlType == SELECTSQL)
            {
                return curDBOperater.ExecScalar(strSql, parameters);
            }

                //如果是存储过程
            else if (iSqlType == PROCEDURESQL)
            {
                return curDBOperater.ExecScalar(strSql, parameters);
            }

                //如果是其他语句
            else
            {
                return null;
            }
        }
		
    }
}
