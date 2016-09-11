//<copyright>ɽ����ά�Ƽ����޹�˾ 1999-2004</copyright>
//<version>V1.0</verion>
//<createdate>2004-5-21</createdate>
//<author>wangyh</author>
//<email>wangyh@qingdaojob.com</email>
//<log date="2004-5-21">����</log>

using System;
using System.Data.SqlClient;
using System.Data.OleDb;
using System.Data.Odbc;
using System.Data;
namespace YingNet.Common.Database {
    /// <summary>
    /// �ԣͣӣӣ��ӣ�������֧��
    /// </summary>
    public class ODBCDBOperate:DBOperate { 
        //���ݿ�����
        private OdbcConnection conn;
		
        //��������
        private OdbcTransaction trans;

        //ָʾ��ǰ�����Ƿ���������
        private bool bInTrans = false;

        /// <summary>
        /// �ı����ݿ����ӵ�����
        /// </summary>
        public override IDbConnection baseConnection {
            get {
                return this.conn;
            }
            set{this.conn = (OdbcConnection)value;}
        }

        /// <summary>
        /// �ı����ݿ����������
        /// </summary>
        public override IDbTransaction baseTransaction {
            get {
                return this.trans;
            }
            set{this.trans = (OdbcTransaction)value;}
        }

        /// <summary>
        /// �ڹ��췽���д������ݿ�����
        /// </summary>
        /// <param name="strConnection"></param>
        public  ODBCDBOperate(string strConnection) {
            this.conn = new OdbcConnection(strConnection);
        }

        /// <summary>
        /// �����ݿ�����
        /// </summary>
        public override  void Open() {
            if(conn.State.Equals(ConnectionState.Closed)) {
                conn.Open();
            }
        }

        /// <summary>
        /// �ر����ݿ�����
        /// </summary>
        public override  void Close() {
            if(conn.State.Equals(ConnectionState.Open)) {
                conn.Close();
            }
        }

        /// <summary>
        /// ��ʼһ������
        /// </summary>
        public override  void BeginTran() {
            if(!this.bInTrans) {
                trans = conn.BeginTransaction();
                bInTrans = true;
            }
        }

        /// <summary>
        /// �ύһ������
        /// </summary>
        public override  void CommitTran() {
            if(this.bInTrans) {
                trans.Commit();
                bInTrans = false;
            }
        }

        /// <summary>
        /// �ع�һ������
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
        /// ��ȡһ��OdbcCommand����
        /// </summary>
        /// <param name="strSql"></param>
        /// <param name="parameters"></param>
        /// <param name="strCommandType"></param>
        /// <returns></returns>
        private OdbcCommand GetPreCommand(string strSql, IDataParameter[] parameters, string strCommandType) {
            //��ʼ��һ��command����
            OdbcCommand cmdSql =  conn.CreateCommand();
            
            try {
                cmdSql.CommandText = strSql;
                if(strCommandType == "PROCEDURE") {
                    cmdSql.CommandType = CommandType.StoredProcedure;
                }

                //�ж��Ƿ���������
                if(this.bInTrans) {
                    cmdSql.Transaction = this.trans;
                }

                //ָ������������ȡֵ
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

	
        #region ִ��update��insert��delete ��䣬����ɹ�������Ӱ���������ʧ���׳�һ���쳣
        /// <summary>
        /// ��Ԥ�����
        /// </summary>
        /// <param name="strSql"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public override int ExecPreUpdateSql(string strSql, IDataParameter[] parameters) {
            return 0;
        }

        /// <summary>
        /// ����Ԥ�����
        /// </summary>
        /// <param name="strSql"></param>
        /// <returns></returns>
        public override int ExecUpdateSql(string strSql) {
           return 0;
        }
        #endregion

        #region ����洢����
        /// <summary>
        /// �����ؽ������
        /// </summary>
        /// <param name="strSql"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public override int ExecUpdateProc(string strSql, IDataParameter[] parameters) {
            return 0;
        }

        /// <summary>
        /// ����DataSet����
        /// </summary>
        /// <param name="strSql"></param>
        /// <param name="parameters"></param>
        /// <param name="strTableName"></param>
        /// <returns></returns>
        public override DataSet ExecProcForDataSet(string strSql, IDataParameter[] parameters,string strTableName) {
            return null;
        }

        /// <summary>
        /// ����DataReader
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
        /// ����DataTable
        /// </summary>
        /// <param name="strSql"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public override DataTable ExecProcForDataTable(string strSql, IDataParameter[] parameters) {
            return null;
        }
        #endregion

        #region ִ��select ��䣬����������� ����DataSet ������DataReader ������DataTable
        /// <summary>
        /// ��Ԥ����ķ���DataSet����
        /// </summary>
        /// <param name="strSql"></param>
        /// <param name="parameters"></param>
        /// <param name="strTableName"></param>
        /// <returns></returns>
        public override System.Data.DataSet ExecPreQueryForDataSet(string strSql, IDataParameter[] parameters, string strTableName) {
            return null;
        }
			
        /// <summary>
        /// ��Ԥ����ķ���DataReader����
        /// </summary>
        /// <param name="strSql"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public override System.Data.IDataReader ExecPreQueryForDataReader(string strSql, IDataParameter[] parameters) {
            return null;
        }
			
        /// <summary>
        /// ��Ԥ����ķ���DataTable����
        /// </summary>
        /// <param name="strSql"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public override System.Data.DataTable ExecPreQueryForDataTable(string strSql, IDataParameter[] parameters) {
            return null;
        }

        /// <summary>
        /// ����Ԥ����ķ���DataSet����
        /// </summary>
        /// <param name="strSql"></param>
        /// <param name="strTableName"></param>
        /// <returns></returns>
        public override System.Data.DataSet ExecQueryForDataSet(string strSql,string strTableName) {
            return null;
        }
			
        /// <summary>
        /// ����Ԥ����ķ���DataReader����
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
        /// ����Ԥ����ķ���DataTable����
        /// </summary>
        /// <param name="strSql"></param>
        /// <returns></returns>
        public override System.Data.DataTable ExecQueryForDataTable(string strSql) {
            //��ʼ��һ��DataAdapter����һ��DataTable����
            System.Data.DataTable dtSql = new DataTable();
            System.Data.Odbc.OdbcDataAdapter daSql = new OdbcDataAdapter(strSql,conn);

            //��ʼ��һ��command����
            OdbcCommand cmdSql =  conn.CreateCommand();
            cmdSql.CommandText = strSql;

            //�ж��Ƿ���������
            if(this.bInTrans) {
                cmdSql.Transaction = this.trans;
            }

            //����DataTable����
            daSql.SelectCommand = cmdSql;
            daSql.Fill(dtSql);
            return dtSql;
        }
        #endregion
    }
}
