//<copyright>ɽ����ά�Ƽ����޹�˾ 1999-2004</copyright>
//<version>V1.0</verion>
//<createdate>2004-3-12</createdate>
//<author>wangyh</author>
//<email>wangyh@qingdaojob.com</email>
//<log date="2004-3-12">����</log>

using System;
using System.Data.SqlClient;
using System.Data.OleDb;
using System.Data;
namespace YingNet.Common.Database {
    /// <summary>
    /// �ԣͣӣӣ��ӣ�������֧��
    /// </summary>
    public class SqlDBOperate:DBOperate { 
        //���ݿ�����
        private SqlConnection conn;
		
        //��������
        private SqlTransaction trans;

        //ָʾ��ǰ�����Ƿ���������
        private bool bInTrans = false;

        /// <summary>
        /// �ı����ݿ����ӵ�����
        /// </summary>
        public override IDbConnection baseConnection {
            get {
                return this.conn;
            }
            set{this.conn = (SqlConnection)value;}
        }

        /// <summary>
        /// �ı����ݿ����������
        /// </summary>
        public override IDbTransaction baseTransaction {
            get {
                return this.trans;
            }
            set{this.trans = (SqlTransaction)value;}
        }

        /// <summary>
        /// �ڹ��췽���д������ݿ�����
        /// </summary>
        /// <param name="strConnection"></param>
        public  SqlDBOperate(string strConnection) {
            this.conn = new SqlConnection(strConnection);
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
        public override  void BeginTran() 
		{
            if(!this.bInTrans) 
			{
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

		public override void Dispose()
		{
			this.Dispose(true);
			GC.SuppressFinalize(this);
		}


		protected  void Dispose(bool disposing)
		{
			if(disposing==false)
			{
				return;
			}

			if(this.bInTrans==true&& this.trans!= null)
			{
				this.trans.Dispose();
				this.trans= null;
			}

			if(this.conn!= null)
			{
				if(this.conn.State== ConnectionState.Open)
				{
					this.conn.Close();
				}
				this.conn.Dispose();
				this.conn= null;
			}
		}

        /// <summary>
        /// ��ȡһ��SqlCommand����
        /// </summary>
        /// <param name="strSql"></param>
        /// <param name="parameters"></param>
        /// <param name="strCommandType"></param>
        /// <returns></returns>
        private SqlCommand GetPreCommand(string strSql, IDataParameter[] parameters, string strCommandType) {
            //��ʼ��һ��command����
            SqlCommand cmdSql =  conn.CreateCommand();
            
			try
			{
				cmdSql.CommandText = strSql;
				if(strCommandType == "PROCEDURE") 
				{
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
			catch(Exception ex)
			{
				throw ex;
			}
			finally
			{
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
            //��ʼ��һ��command����
            SqlCommand cmdSql =  GetPreCommand(strSql, parameters, "SQL");
			
            //�ж��Ƿ���������
            if(this.bInTrans) {
                cmdSql.Transaction = this.trans;
            }

            //������Ӱ�������
            return cmdSql.ExecuteNonQuery();
        }

        /// <summary>
        /// ����Ԥ�����
        /// </summary>
        /// <param name="strSql"></param>
        /// <returns></returns>
        public override int ExecUpdateSql(string strSql) {
            SqlCommand cmdSql = conn.CreateCommand();
            cmdSql.CommandText = strSql;

            //�ж��Ƿ���������
            if(this.bInTrans) {
                cmdSql.Transaction = this.trans;
            }

            return cmdSql.ExecuteNonQuery();
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
            //��ʼ��һ��command����
            SqlCommand cmdSql =   GetPreCommand(strSql, parameters, "PROCEDURE");
				
            //�ж��Ƿ���������
            if(this.bInTrans) {
                cmdSql.Transaction = this.trans;
            }

            //������Ӱ�������
            return cmdSql.ExecuteNonQuery();
        }

        /// <summary>
        /// ����DataSet����
        /// </summary>
        /// <param name="strSql"></param>
        /// <param name="parameters"></param>
        /// <param name="strTableName"></param>
        /// <returns></returns>
        public override DataSet ExecProcForDataSet(string strSql, IDataParameter[] parameters,string strTableName) {
            //��ʼ��һ��DataSet����һ��DataAdapter����
            System.Data.DataSet dsSql = new DataSet();
            System.Data.SqlClient.SqlDataAdapter daSql = new SqlDataAdapter(strSql,conn);

            //��ʼ��һ��command����
            SqlCommand cmdSql =   GetPreCommand(strSql, parameters, "PROCEDURE");

            //����DataSet����
            daSql.SelectCommand = cmdSql;
            daSql.Fill(dsSql,strTableName);
            return dsSql;
        }

        /// <summary>
        /// ����DataReader
        /// </summary>
        /// <param name="strSql"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public override IDataReader ExecProcForDataReader(string strSql, IDataParameter[] parameters) {
            //��ʼ��һ��command����
            SqlCommand cmdSql =   GetPreCommand(strSql, parameters, "PROCEDURE");
				
            //����DataReader����
            return cmdSql.ExecuteReader();
        }

        public override object ExecScalar(string strSql, IDataParameter[] parameters)
        {
            //��ʼ��һ��command����
            SqlCommand cmdOle = GetPreCommand(strSql, parameters, "PROCEDURE");

            //���ض���
            return cmdOle.ExecuteScalar();
        }

        /// <summary>
        /// ����DataTable
        /// </summary>
        /// <param name="strSql"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public override DataTable ExecProcForDataTable(string strSql, IDataParameter[] parameters) {
            //��ʼ��һ��DataAdapter����һ��DataTable����
            System.Data.DataTable dtSql = new DataTable();
            System.Data.SqlClient.SqlDataAdapter daSql = new SqlDataAdapter(strSql,conn);

            //��ʼ��һ��command����
            SqlCommand cmdSql =   GetPreCommand(strSql, parameters, "PROCEDURE");

            //����DataTable����
            daSql.SelectCommand = cmdSql;
            daSql.Fill(dtSql);
            return dtSql;
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
            //��ʼ��һ��DataSet����һ��DataAdapter����
            System.Data.DataSet dsSql = new DataSet();
            System.Data.SqlClient.SqlDataAdapter daSql = new SqlDataAdapter(strSql,conn);

            //��ʼ��һ��command����
            SqlCommand cmdSql =   GetPreCommand(strSql, parameters, "SQL");

            //����DataSet����
            daSql.SelectCommand = cmdSql;
            daSql.Fill(dsSql,strTableName);
            return dsSql;
        }
			
        /// <summary>
        /// ��Ԥ����ķ���DataReader����
        /// </summary>
        /// <param name="strSql"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public override System.Data.IDataReader ExecPreQueryForDataReader(string strSql, IDataParameter[] parameters) {
            //��ʼ��һ��command����
            SqlCommand cmdSql =   GetPreCommand(strSql, parameters, "SQL");
				
            //����DataReader����
            return cmdSql.ExecuteReader();
        }
			
        /// <summary>
        /// ��Ԥ����ķ���DataTable����
        /// </summary>
        /// <param name="strSql"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public override System.Data.DataTable ExecPreQueryForDataTable(string strSql, IDataParameter[] parameters) {
            //��ʼ��һ��DataAdapter����һ��DataTable����
            System.Data.DataTable dtSql = new DataTable();
            System.Data.SqlClient.SqlDataAdapter daSql = new SqlDataAdapter(strSql,conn);

            //��ʼ��һ��command����
            SqlCommand cmdSql =   GetPreCommand(strSql, parameters, "SQL");

            //����DataTable����
            daSql.SelectCommand = cmdSql;
            daSql.Fill(dtSql);
            return dtSql;
        }

        /// <summary>
        /// ����Ԥ����ķ���DataSet����
        /// </summary>
        /// <param name="strSql"></param>
        /// <param name="strTableName"></param>
        /// <returns></returns>
        public override System.Data.DataSet ExecQueryForDataSet(string strSql,string strTableName) {
            //��ʼ��һ��DataSet����һ��DataAdapter����
            System.Data.DataSet dsSql = new DataSet();
            System.Data.SqlClient.SqlDataAdapter daSql = new SqlDataAdapter(strSql,conn);

            //��ʼ��һ��command����
            SqlCommand cmdSql =  conn.CreateCommand();
            cmdSql.CommandText = strSql;

            //�ж��Ƿ���������
            if(this.bInTrans) {
                cmdSql.Transaction = this.trans;
            }
				

            //����DataSet����
            daSql.SelectCommand = cmdSql;
            daSql.Fill(dsSql,strTableName);
            return dsSql;
        }
			
        /// <summary>
        /// ����Ԥ����ķ���DataReader����
        /// </summary>
        /// <param name="strSql"></param>
        /// <returns></returns>
        public override System.Data.IDataReader ExecQueryForDataReader(string strSql) {
            SqlCommand cmdSql = null;
				
            //��ʼ��һ��command����
            cmdSql =  conn.CreateCommand();
            cmdSql.CommandText = strSql;
			
            //�ж��Ƿ���������
            if(this.bInTrans) {
                cmdSql.Transaction = this.trans;
            }
            //����DataReader����
            return cmdSql.ExecuteReader();
        } 
		
        /// <summary>
        /// ����Ԥ����ķ���DataTable����
        /// </summary>
        /// <param name="strSql"></param>
        /// <returns></returns>
        public override System.Data.DataTable ExecQueryForDataTable(string strSql) {
            //��ʼ��һ��DataAdapter����һ��DataTable����
            System.Data.DataTable dtSql = new DataTable();
            System.Data.SqlClient.SqlDataAdapter daSql = new SqlDataAdapter(strSql,conn);

            //��ʼ��һ��command����
            SqlCommand cmdSql =  conn.CreateCommand();
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

        public override object ExecScalar(string strSql)
        {
            //��ʼ��һ��command����
            SqlCommand cmdSql = conn.CreateCommand();
            cmdSql.CommandText = strSql;

            //�ж��Ƿ���������
            if (this.bInTrans)
            {
                cmdSql.Transaction = this.trans;
            }

            //����DataReader����
            return cmdSql.ExecuteScalar();
        }
        #endregion
    }
}
