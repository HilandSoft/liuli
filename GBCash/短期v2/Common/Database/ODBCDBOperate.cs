//<copyright>山东三维科技有限公司 1999-2004</copyright>
//<version>V1.0</verion>
//<createdate>2004-5-21</createdate>
//<author>wangyh</author>
//<email>wangyh@qingdaojob.com</email>
//<log date="2004-5-21">创建</log>

using System;
using System.Data.SqlClient;
using System.Data.OleDb;
using System.Data.Odbc;
using System.Data;
namespace YingNet.Common.Database {
    /// <summary>
    /// 对ＭＳＳｑｌＳｅｒｖｅｒ的支持
    /// </summary>
    public class ODBCDBOperate:DBOperate { 
        //数据库连接
        private OdbcConnection conn;
		
        //事务处理类
        private OdbcTransaction trans;

        //指示当前操作是否在事务中
        private bool bInTrans = false;

        /// <summary>
        /// 改变数据库连接的类型
        /// </summary>
        public override IDbConnection baseConnection {
            get {
                return this.conn;
            }
            set{this.conn = (OdbcConnection)value;}
        }

        /// <summary>
        /// 改变数据库事务的类型
        /// </summary>
        public override IDbTransaction baseTransaction {
            get {
                return this.trans;
            }
            set{this.trans = (OdbcTransaction)value;}
        }

        /// <summary>
        /// 在构造方法中创建数据库连接
        /// </summary>
        /// <param name="strConnection"></param>
        public  ODBCDBOperate(string strConnection) {
            this.conn = new OdbcConnection(strConnection);
        }

        /// <summary>
        /// 打开数据库连接
        /// </summary>
        public override  void Open() {
            if(conn.State.Equals(ConnectionState.Closed)) {
                conn.Open();
            }
        }

        /// <summary>
        /// 关闭数据库连接
        /// </summary>
        public override  void Close() {
            if(conn.State.Equals(ConnectionState.Open)) {
                conn.Close();
            }
        }

        /// <summary>
        /// 开始一个事务
        /// </summary>
        public override  void BeginTran() {
            if(!this.bInTrans) {
                trans = conn.BeginTransaction();
                bInTrans = true;
            }
        }

        /// <summary>
        /// 提交一个事务
        /// </summary>
        public override  void CommitTran() {
            if(this.bInTrans) {
                trans.Commit();
                bInTrans = false;
            }
        }

        /// <summary>
        /// 回滚一个事务
        /// </summary>
        public override  void RollBackTran() {
            if(this.bInTrans) {
                trans.Rollback();
                bInTrans = false;
            }
        }

        public override void Dispose() {
            this.Dispose(true);
            GC.SuppressFinalize(this);
        }


        protected  void Dispose(bool disposing) {
            if(disposing==false) {
                return;
            }

            if(this.bInTrans==true&& this.trans!= null) {
                //this.trans.Dispose();
                this.trans= null;
            }

            if(this.conn!= null) {
                if(this.conn.State== ConnectionState.Open) {
                    this.conn.Close();
                }
                this.conn.Dispose();
                this.conn= null;
            }
        }

        /// <summary>
        /// 获取一个OdbcCommand对象
        /// </summary>
        /// <param name="strSql"></param>
        /// <param name="parameters"></param>
        /// <param name="strCommandType"></param>
        /// <returns></returns>
        private OdbcCommand GetPreCommand(string strSql, IDataParameter[] parameters, string strCommandType) {
            //初始化一个command对象
            OdbcCommand cmdSql =  conn.CreateCommand();
            
            try {
                cmdSql.CommandText = strSql;
                if(strCommandType == "PROCEDURE") {
                    cmdSql.CommandType = CommandType.StoredProcedure;
                }

                //判断是否在事务中
                if(this.bInTrans) {
                    cmdSql.Transaction = this.trans;
                }

                //指定各个参数的取值
                foreach(IDataParameter SqlParm in parameters) {
                    cmdSql.Parameters.Add(SqlParm);
                }
            }
            catch(Exception ex) {
                throw ex;
            }
            finally {
            }
            
            return cmdSql;
        }

	
        #region 执行update、insert、delete 语句，如果成功返回受影响的条数，失败抛出一个异常
        /// <summary>
        /// 带预处理的
        /// </summary>
        /// <param name="strSql"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public override int ExecPreUpdateSql(string strSql, IDataParameter[] parameters) {
            return 0;
        }

        /// <summary>
        /// 不带预处理的
        /// </summary>
        /// <param name="strSql"></param>
        /// <returns></returns>
        public override int ExecUpdateSql(string strSql) {
           return 0;
        }
        #endregion

        #region 处理存储过程
        /// <summary>
        /// 不返回结果集的
        /// </summary>
        /// <param name="strSql"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public override int ExecUpdateProc(string strSql, IDataParameter[] parameters) {
            return 0;
        }

        /// <summary>
        /// 返回DataSet对象
        /// </summary>
        /// <param name="strSql"></param>
        /// <param name="parameters"></param>
        /// <param name="strTableName"></param>
        /// <returns></returns>
        public override DataSet ExecProcForDataSet(string strSql, IDataParameter[] parameters,string strTableName) {
            return null;
        }

        /// <summary>
        /// 返回DataReader
        /// </summary>
        /// <param name="strSql"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public override IDataReader ExecProcForDataReader(string strSql, IDataParameter[] parameters) {
            return null;
        }

        public override object ExecScalar(string strSql, IDataParameter[] parameters)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        /// <summary>
        /// 返回DataTable
        /// </summary>
        /// <param name="strSql"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public override DataTable ExecProcForDataTable(string strSql, IDataParameter[] parameters) {
            return null;
        }
        #endregion

        #region 执行select 语句，共分三种情况 返回DataSet 、返回DataReader 、返回DataTable
        /// <summary>
        /// 带预处理的返回DataSet对象
        /// </summary>
        /// <param name="strSql"></param>
        /// <param name="parameters"></param>
        /// <param name="strTableName"></param>
        /// <returns></returns>
        public override System.Data.DataSet ExecPreQueryForDataSet(string strSql, IDataParameter[] parameters, string strTableName) {
            return null;
        }
			
        /// <summary>
        /// 带预处理的返回DataReader对象
        /// </summary>
        /// <param name="strSql"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public override System.Data.IDataReader ExecPreQueryForDataReader(string strSql, IDataParameter[] parameters) {
            return null;
        }
			
        /// <summary>
        /// 带预处理的返回DataTable对象
        /// </summary>
        /// <param name="strSql"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public override System.Data.DataTable ExecPreQueryForDataTable(string strSql, IDataParameter[] parameters) {
            return null;
        }

        /// <summary>
        /// 不带预处理的返回DataSet对象
        /// </summary>
        /// <param name="strSql"></param>
        /// <param name="strTableName"></param>
        /// <returns></returns>
        public override System.Data.DataSet ExecQueryForDataSet(string strSql,string strTableName) {
            return null;
        }
			
        /// <summary>
        /// 不带预处理的返回DataReader对象
        /// </summary>
        /// <param name="strSql"></param>
        /// <returns></returns>
        public override System.Data.IDataReader ExecQueryForDataReader(string strSql) {
            return null;
        }

        public override object ExecScalar(string strSql)
        {
            throw new Exception("The method or operation is not implemented.");
        }
		
        /// <summary>
        /// 不带预处理的返回DataTable对象
        /// </summary>
        /// <param name="strSql"></param>
        /// <returns></returns>
        public override System.Data.DataTable ExecQueryForDataTable(string strSql) {
            //初始化一个DataAdapter对象，一个DataTable对象
            System.Data.DataTable dtSql = new DataTable();
            System.Data.Odbc.OdbcDataAdapter daSql = new OdbcDataAdapter(strSql,conn);

            //初始化一个command对象
            OdbcCommand cmdSql =  conn.CreateCommand();
            cmdSql.CommandText = strSql;

            //判断是否在事务中
            if(this.bInTrans) {
                cmdSql.Transaction = this.trans;
            }

            //返回DataTable对象
            daSql.SelectCommand = cmdSql;
            daSql.Fill(dtSql);
            return dtSql;
        }
        #endregion
    }
}
