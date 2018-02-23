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
    /// DBOperat ��ժҪ˵����
    /// </summary>
    #region һ�������࣬�Բ�ͬ���ݿ��в�ͬ��ʵ��
    public abstract class DBOperate :IDisposable {
        public DBOperate() {
            //
            // TODO: �ڴ˴���ӹ��캯���߼�
            //
        }

        /// <summary>
        /// һ���ӿڣ���SqlConnection ��OleDbConnection�����ʵ��
        /// </summary>
        public abstract System.Data.IDbConnection baseConnection {
            get;
            set;
        }

        /// <summary>
        /// һ���ӿڣ���SqlConnection ��OleDbConnection�����ʵ��
        /// </summary>
        public abstract System.Data.IDbTransaction baseTransaction {
            get;
            set;
        }

		public abstract void Dispose();
		

        /// <summary>
        /// �����ݿ�����
        /// </summary>
        public abstract void Open();

        /// <summary>
        /// �ر����ݿ�����
        /// </summary>
        public abstract void Close();

        /// <summary>
        /// ��ʼһ������
        /// </summary>
        public abstract void BeginTran();

        /// <summary>
        /// �ύһ������
        /// </summary>
        public abstract void CommitTran();

        /// <summary>
        /// �ع�һ������
        /// </summary>
        public abstract void RollBackTran();

        #region ִ��update��insert��delete ��䣬����ɹ�������Ӱ���������ʧ���׳�һ���쳣
        /// <summary>
        /// ��Ԥ�����
        /// </summary>
        /// <param name="strSql"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public abstract int ExecPreUpdateSql(string strSql,IDataParameter[] parameters);

        /// <summary>
        /// ����Ԥ�����
        /// </summary>
        /// <param name="strSql"></param>
        /// <returns></returns>
        public abstract int ExecUpdateSql(string strSql);
        #endregion

        #region ����洢����
        /// <summary>
        /// �����ؽ������
        /// </summary>
        /// <param name="strSql"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public abstract int ExecUpdateProc(string strSql, IDataParameter[] parameters);

        /// <summary>
        /// ����DataSet����
        /// </summary>
        /// <param name="strSql"></param>
        /// <param name="parameters"></param>
        /// <param name="strTableName"></param>
        /// <returns></returns>
        public abstract DataSet ExecProcForDataSet(string strSql, IDataParameter[] parameters,string strTableName);

        /// <summary>
        /// ����DataReader
        /// </summary>
        /// <param name="strSql"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public abstract IDataReader ExecProcForDataReader(string strSql, IDataParameter[] parameters);

        /// <summary>
        /// ����DataTable
        /// </summary>
        /// <param name="strSql"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public abstract DataTable ExecProcForDataTable(string strSql, IDataParameter[] parameters);
        #endregion

        #region//ִ��select ��䣬����������� ����DataSet ������DataReader ������DataTable
        /// <summary>
        /// ��Ԥ����ķ���DataSet����
        /// </summary>
        /// <param name="strSql"></param>
        /// <param name="parameters"></param>
        /// <param name="strTableName"></param>
        /// <returns></returns>
        public abstract System.Data.DataSet ExecPreQueryForDataSet(string strSql, IDataParameter[] parameters, string strTableName);
		
        /// <summary>
        /// ��Ԥ����ķ���DataReader����
        /// </summary>
        /// <param name="strSql"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public abstract System.Data.IDataReader ExecPreQueryForDataReader(string strSql, IDataParameter[] parameters);
		
        /// <summary>
        /// ��Ԥ����ķ���DataTable����
        /// </summary>
        /// <param name="strSql"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public abstract System.Data.DataTable ExecPreQueryForDataTable(string strSql, IDataParameter[] parameters);

        //=======================================================================================
        // xieran 20060101 ���
        /// <summary>
        /// ��Ԥ����� ����Scalar����
        /// </summary>
        /// <param name="strSql"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public abstract System.Object ExecScalar(string strSql, IDataParameter[] parameters);
        //========================================================================================

        /// <summary>
        /// ����Ԥ����ķ���DataSet����
        /// </summary>
        /// <param name="strSql"></param>
        /// <param name="strTableName"></param>
        /// <returns></returns>
        public abstract System.Data.DataSet ExecQueryForDataSet(string strSql,string strTableName);
		
        /// <summary>
        /// ����Ԥ����ķ���DataReader����
        /// </summary>
        /// <param name="strSql"></param>
        /// <returns></returns>
        public abstract System.Data.IDataReader ExecQueryForDataReader(string strSql);
		
        /// <summary>
        /// ����Ԥ����ķ���DataTable����
        /// </summary>
        /// <param name="strSql"></param>
        /// <returns></returns>
        public abstract System.Data.DataTable ExecQueryForDataTable(string strSql);

        //=======================================================================================
        // xieran 20060101 ���
        /// <summary>
        /// ����Ԥ����� ����Scalar����
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


	

