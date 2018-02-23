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
    /// OleDBOperate ��ժҪ˵����
    /// </summary>
    /// 
    /// <summary>
    /// ��OleDb��֧��
    /// </summary>
    public class OleDBOperate:DBOperate { 
        //���ݿ�����
        private OleDbConnection conn;
			
        //��������
        private OleDbTransaction trans; 

        //ָʾ��ǰ�����Ƿ���������
        private bool bInTrans = false;

        /// <summary>
        /// �ı����ݿ����ӵ�����
        /// </summary>
        public override IDbConnection baseConnection {
            get {
                return this.conn;
            }
            set{this.conn = (OleDbConnection)value;}
        }

        /// <summary>
        /// �ı����ݿ����������
        /// </summary>
        public override IDbTransaction baseTransaction {
            get {
                return this.trans;
            }
            set{this.trans = (OleDbTransaction)value;}
        }

        /// <summary>
        /// �ڹ��췽���д������ݿ�����
        /// </summary>
        /// <param name="strConnection"></param>
        public  OleDBOperate(string strConnection) {
            this.conn = new OleDbConnection(strConnection);
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

		public override void Dispose()
		{
			this.Dispose(true);
			GC.SuppressFinalize(this);
		}

		protected void Dispose(bool disposing)
		{
			if(disposing==false)
			{
				return;
			}

			if(this.bInTrans==true&& this.trans!= null)
			{
				//this.trans.Dispose(); //OleDbTransactioin ��֧��Dispose()���� ���
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
        /// ��ȡһ��OleDbCommand����
        /// </summary>
        /// <param name="strSql"></param>
        /// <param name="parameters"></param>
        /// <param name="strCommandType"></param>
        /// <returns></returns>
        private OleDbCommand GetPreCommand(string strSql, IDataParameter[] parameters, string strCommandType) 
		{
            //��ʼ��һ��command����
            OleDbCommand cmdOleDb =  conn.CreateCommand();
            cmdOleDb.CommandText = strSql;

            if(strCommandType == "PROCEDURE") {
                cmdOleDb.CommandType = CommandType.StoredProcedure;
            }

            //�ж��Ƿ���������
            if(this.bInTrans) {
                cmdOleDb.Transaction = this.trans;
            }

            //ָ������������ȡֵ
            foreach(IDataParameter SqlParm in parameters) {
                cmdOleDb.Parameters.Add(SqlParm);
            }

            return cmdOleDb;
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
            OleDbCommand cmdOle =  GetPreCommand(strSql, parameters, "SQL");
			
            //������Ӱ�������
            return cmdOle.ExecuteNonQuery();
        }

        /// <summary>
        /// ����Ԥ�����
        /// </summary>
        /// <param name="strSql"></param>
        /// <returns></returns>
        public override int ExecUpdateSql(string strSql) {
            OleDbCommand cmdOle = conn.CreateCommand();
            cmdOle.CommandText = strSql;

            //�������
            if(this.bInTrans) {
                cmdOle.Transaction = this.trans;     
            }
            return cmdOle.ExecuteNonQuery();
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
            OleDbCommand cmdOle =   GetPreCommand(strSql, parameters, "PROCEDURE");
				
            //������Ӱ�������
            return cmdOle.ExecuteNonQuery();
        }

        /// <summary>
        /// ����DataSet����
        /// </summary>
        /// <param name="strSql"></param>
        /// <param name="parameters"></param>
        /// <param name="strTableName"></param>
        /// <returns></returns>
        public override DataSet ExecProcForDataSet(string strSql, IDataParameter[] parameters, string strTableName) {
            //��ʼ��һ��DataSet����һ��DataAdapter����
            System.Data.DataSet dsOle = new DataSet();
            System.Data.OleDb.OleDbDataAdapter daOle = new OleDbDataAdapter();

            //��ʼ��һ��command����
            OleDbCommand cmdOle =   GetPreCommand(strSql, parameters, "PROCEDURE");

            //����DataSet����
            daOle.SelectCommand = cmdOle;
            daOle.Fill(dsOle,strTableName);
            return dsOle;
        }

        /// <summary>
        /// ����DataReader����
        /// </summary>
        /// <param name="strSql"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public override IDataReader ExecProcForDataReader(string strSql, IDataParameter[] parameters) {
            //��ʼ��һ��command����
            OleDbCommand cmdOle =   GetPreCommand(strSql, parameters, "PROCEDURE");
			
            //����DataReader����
            return cmdOle.ExecuteReader();
        }

        public override object ExecScalar(string strSql, IDataParameter[] parameters)
        {
            //��ʼ��һ��command����
            OleDbCommand cmdOle = GetPreCommand(strSql, parameters, "PROCEDURE");

            //���ض���
            return cmdOle.ExecuteScalar();
        }

        /// <summary>
        /// ����DataTable����
        /// </summary>
        /// <param name="strSql"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public override DataTable ExecProcForDataTable(string strSql, IDataParameter[] parameters) {
            //��ʼ��һ��DataAdapter����һ��DataTable����
            System.Data.DataTable dtOle = new DataTable();
            System.Data.OleDb.OleDbDataAdapter daOle = new OleDbDataAdapter(strSql,conn);

            //��ʼ��һ��command����
            OleDbCommand cmdOle =   GetPreCommand(strSql, parameters, "PROCEDURE");

            //����DataTable����
            daOle.SelectCommand = cmdOle;
            daOle.Fill(dtOle);
            return dtOle;
        }
        #endregion

        #region//ִ��select ��䣬����������� ����DataSet ������DataReader ������DataTable
        /// <summary>
        /// ��Ԥ����ķ���DataSet����
        /// </summary>
        /// <param name="strSql"></param>
        /// <param name="parameters"></param>
        /// <param name="strTableName"></param>
        /// <returns></returns>
        public override System.Data.DataSet ExecPreQueryForDataSet(string strSql, IDataParameter[] parameters, string strTableName) {
            //��ʼ��һ��DataSet����һ��DataAdapter����
            System.Data.DataSet dsOle = new DataSet();
            System.Data.OleDb.OleDbDataAdapter daOle = new OleDbDataAdapter(strSql,conn);

            //��ʼ��һ��command����
            OleDbCommand cmdOle =   GetPreCommand(strSql, parameters, "SQL");

            //����DataSet����
            daOle.SelectCommand = cmdOle;
            daOle.Fill(dsOle,strTableName);
            return dsOle;
        }
			
        /// <summary>
        /// ��Ԥ����ķ���DataReader����
        /// </summary>
        /// <param name="strSql"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public override System.Data.IDataReader ExecPreQueryForDataReader(string strSql, IDataParameter[] parameters) {
            //��ʼ��һ��command����
            OleDbCommand cmdOle =   GetPreCommand(strSql, parameters, "SQL");
		
            //����DataReader����
            return cmdOle.ExecuteReader();
        }
			
        /// <summary>
        /// ��Ԥ����ķ���DataTable����
        /// </summary>
        /// <param name="strSql"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public override System.Data.DataTable ExecPreQueryForDataTable(string strSql, IDataParameter[] parameters) {
            //��ʼ��һ��DataAdapter����һ��DataTable����
            System.Data.DataTable dtOle = new DataTable("returnTable");
            System.Data.OleDb.OleDbDataAdapter daOle = new OleDbDataAdapter(strSql,conn);

            //��ʼ��һ��command����
            OleDbCommand cmdOle =   GetPreCommand(strSql, parameters, "SQL");

            //����DataTable����
            daOle.SelectCommand = cmdOle;
            daOle.Fill(dtOle);
            return dtOle;
        }

        /// <summary>
        /// ����Ԥ����ķ���DataSet����
        /// </summary>
        /// <param name="strSql"></param>
        /// <param name="strTableName"></param>
        /// <returns></returns>
        public override System.Data.DataSet ExecQueryForDataSet(string strSql,string strTableName) {
            //��ʼ��һ��DataSet����һ��DataAdapter����
            System.Data.DataSet dsOle = new DataSet();
            System.Data.OleDb.OleDbDataAdapter daOle = new OleDbDataAdapter(strSql,conn);

            //��ʼ��һ��command����
            OleDbCommand cmdOle =  conn.CreateCommand();
            cmdOle.CommandText = strSql;

            //�ж��Ƿ���������
            if(this.bInTrans) {
                cmdOle.Transaction = this.trans;
            }

            //����DataSet����
            daOle.SelectCommand = cmdOle;
            daOle.Fill(dsOle,strTableName);
            return dsOle;
        }
			
        /// <summary>
        /// ����Ԥ����ķ���DataReader����
        /// </summary>
        /// <param name="strSql"></param>
        /// <returns></returns>
        public override System.Data.IDataReader ExecQueryForDataReader(string strSql) {
            //��ʼ��һ��command����
            OleDbCommand cmdOle =  conn.CreateCommand();
            cmdOle.CommandText = strSql;
		
            //�ж��Ƿ���������
            if(this.bInTrans) {
                cmdOle.Transaction = this.trans;
            }

            //����DataReader����
            return cmdOle.ExecuteReader();
        }
		
        /// <summary>
        /// ����Ԥ����ķ���DataTable����
        /// </summary>
        /// <param name="strSql"></param>
        /// <returns></returns>
        public override System.Data.DataTable ExecQueryForDataTable(string strSql) {
            //��ʼ��һ��DataAdapter����һ��DataTable����
            System.Data.DataTable dtOle = new DataTable();
            System.Data.OleDb.OleDbDataAdapter daOle = new OleDbDataAdapter(strSql,conn);

            //��ʼ��һ��command����
            OleDbCommand cmdOle =  conn.CreateCommand();
            cmdOle.CommandText = strSql;

            //�ж��Ƿ���������
            if(this.bInTrans) {
                cmdOle.Transaction = this.trans;
            }

            //����DataTable����
            daOle.SelectCommand = cmdOle;
            daOle.Fill(dtOle);
            return dtOle;
        }

        public override object ExecScalar(string strSql)
        {
            //��ʼ��һ��command����
            OleDbCommand cmdOle = conn.CreateCommand();
            cmdOle.CommandText = strSql;

            //�ж��Ƿ���������
            if (this.bInTrans)
            {
                cmdOle.Transaction = this.trans;
            }

            //����DataReader����
            return cmdOle.ExecuteScalar();
        }
        #endregion
    }

}
