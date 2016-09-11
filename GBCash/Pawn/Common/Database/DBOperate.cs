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


namespace YingNet.Common.Database {
    /// <summary>
    /// DBOperat 的摘要说明。
    /// </summary>
    #region 一个抽象类，对不同数据库有不同的实现
    public abstract class DBOperate :IDisposable {
        public DBOperate() {
            //
            // TODO: 在此处添加构造函数逻辑
            //
        }

        /// <summary>
        /// 一个接口，由SqlConnection 、OleDbConnection类具体实现
        /// </summary>
        public abstract System.Data.IDbConnection baseConnection {
            get;
            set;
        }

        /// <summary>
        /// 一个接口，由SqlConnection 、OleDbConnection类具体实现
        /// </summary>
        public abstract System.Data.IDbTransaction baseTransaction {
            get;
            set;
        }

		public abstract void Dispose();
		

        /// <summary>
        /// 打开数据库连接
        /// </summary>
        public abstract void Open();

        /// <summary>
        /// 关闭数据库连接
        /// </summary>
        public abstract void Close();

        /// <summary>
        /// 开始一个事务
        /// </summary>
        public abstract void BeginTran();

        /// <summary>
        /// 提交一个事务
        /// </summary>
        public abstract void CommitTran();

        /// <summary>
        /// 回滚一个事务
        /// </summary>
        public abstract void RollBackTran();

        #region 执行update、insert、delete 语句，如果成功返回受影响的条数，失败抛出一个异常
        /// <summary>
        /// 带预处理的
        /// </summary>
        /// <param name="strSql"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public abstract int ExecPreUpdateSql(string strSql,IDataParameter[] parameters);

        /// <summary>
        /// 不带预处理的
        /// </summary>
        /// <param name="strSql"></param>
        /// <returns></returns>
        public abstract int ExecUpdateSql(string strSql);
        #endregion

        #region 处理存储过程
        /// <summary>
        /// 不返回结果集的
        /// </summary>
        /// <param name="strSql"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public abstract int ExecUpdateProc(string strSql, IDataParameter[] parameters);

        /// <summary>
        /// 返回DataSet对象
        /// </summary>
        /// <param name="strSql"></param>
        /// <param name="parameters"></param>
        /// <param name="strTableName"></param>
        /// <returns></returns>
        public abstract DataSet ExecProcForDataSet(string strSql, IDataParameter[] parameters,string strTableName);

        /// <summary>
        /// 返回DataReader
        /// </summary>
        /// <param name="strSql"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public abstract IDataReader ExecProcForDataReader(string strSql, IDataParameter[] parameters);

        /// <summary>
        /// 返回DataTable
        /// </summary>
        /// <param name="strSql"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public abstract DataTable ExecProcForDataTable(string strSql, IDataParameter[] parameters);
        #endregion

        #region//执行select 语句，共分三种情况 返回DataSet 、返回DataReader 、返回DataTable
        /// <summary>
        /// 带预处理的返回DataSet对象
        /// </summary>
        /// <param name="strSql"></param>
        /// <param name="parameters"></param>
        /// <param name="strTableName"></param>
        /// <returns></returns>
        public abstract System.Data.DataSet ExecPreQueryForDataSet(string strSql, IDataParameter[] parameters, string strTableName);
		
        /// <summary>
        /// 带预处理的返回DataReader对象
        /// </summary>
        /// <param name="strSql"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public abstract System.Data.IDataReader ExecPreQueryForDataReader(string strSql, IDataParameter[] parameters);
		
        /// <summary>
        /// 带预处理的返回DataTable对象
        /// </summary>
        /// <param name="strSql"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public abstract System.Data.DataTable ExecPreQueryForDataTable(string strSql, IDataParameter[] parameters);

        //=======================================================================================
        // xieran 20060101 添加
        /// <summary>
        /// 带预处理的 返回Scalar对象
        /// </summary>
        /// <param name="strSql"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public abstract System.Object ExecScalar(string strSql, IDataParameter[] parameters);
        //========================================================================================

        /// <summary>
        /// 不带预处理的返回DataSet对象
        /// </summary>
        /// <param name="strSql"></param>
        /// <param name="strTableName"></param>
        /// <returns></returns>
        public abstract System.Data.DataSet ExecQueryForDataSet(string strSql,string strTableName);
		
        /// <summary>
        /// 不带预处理的返回DataReader对象
        /// </summary>
        /// <param name="strSql"></param>
        /// <returns></returns>
        public abstract System.Data.IDataReader ExecQueryForDataReader(string strSql);
		
        /// <summary>
        /// 不带预处理的返回DataTable对象
        /// </summary>
        /// <param name="strSql"></param>
        /// <returns></returns>
        public abstract System.Data.DataTable ExecQueryForDataTable(string strSql);

        //=======================================================================================
        // xieran 20060101 添加
        /// <summary>
        /// 不带预处理的 返回Scalar对象
        /// </summary>
        /// <param name="strSql"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public abstract System.Object ExecScalar(string strSql);
        //========================================================================================
        #endregion

		//IDataParameter para= new sql
    }
}
#endregion


	

