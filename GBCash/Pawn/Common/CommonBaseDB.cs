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

using YingNet.Common.Database;

namespace YingNet.Common {
    /// <summary>
    /// CommonBaseDB ��ժҪ˵����
    /// </summary>
    public class CommonBaseDB {
        //�½�DBOperate����
        private DBOperate curDBOperater;

        //�����û������Sql�������� 0:������� 1:�洢���� 2:Select���  -1:�������
        private const int UPDATESQL = 0;
        private const int PROCEDURESQL = 1;
        private const int SELECTSQL = 2;
        private const int ERRORSQL = -1;

        //������Ҫ�������������͵����ݿ��־
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
            //this.curDBOperater.Open(); // ��Ȼע�͵�[3/26/2004]
        }
/*
        public CommonBaseDB (string strDBServer,string strDBName, string strDBUser, string strDBPwd, int iDBType) {
            GetCurDB(strDBServer,strDBName, strDBUser, strDBPwd, iDBType);
        }

        //����Factory�����������û��Ĳ�������ȡ����Ӧ�����ݿ��������
        protected void GetCurDB(string strDBServer,string strDBName, string strDBUser, string strDBPwd, int iDBType) {
            this.curDBOperater = DBOperatorFactory.GetDBOperator(strDBServer, strDBName, strDBUser, strDBPwd, iDBType);
            this.curDBOperater.Open();
        }
	*/	
        /// <summary>
        /// �����ݿ�����
        /// </summary>
        public void Open() {
            curDBOperater.Open();
        }

        /// <summary>
        /// �ر����ݿ�����
        /// </summary>
        public void Close() {
            curDBOperater.Close();
        }

        /// <summary>
        /// ��ʼһ������
        /// </summary>
        public void BeginTran() {
            curDBOperater.BeginTran();
        }

        /// <summary>
        /// �ύһ������
        /// </summary>
        public void CommitTran() {
            curDBOperater.CommitTran();
        }

        /// <summary>
        /// �ع�һ������
        /// </summary>
        public void RollBackTran() {
            curDBOperater.RollBackTran();
        }

        /// <summary>
        /// ����sql����ж��Ƿ��Ǵ洢���� 
        /// </summary>
        /// <param name="strSql"></param>
        /// <returns></returns>
        private int GetSqlType(string strSql) {
            //��¼SQL���Ŀ�ʼ�ַ�
            string strTop = "";
            //���Ϊ��
            if(strSql==null || strSql.Length==0) {
                return ERRORSQL;
            }
            if(strSql.Length>7) {
                //ȡ���ַ�����ǰ7λ
                strTop = strSql.Substring(0,7).ToUpper();

                //������Ǵ洢����
                if(strTop.Equals("UPDATE ") || strTop.Equals("INSERT ") || strTop.Equals("DELETE ") ||strTop.Equals("ALTER T") || strTop.Equals("ALTER  ") || strTop.Equals("BACKUP ") || strTop.Equals("RESTORE") ) {
                    return UPDATESQL;
                }

                    //�����Select���
                else if(strTop.Equals("SELECT ")) {
                    return SELECTSQL;
                }
                    //����Ǵ洢����
                else {
                    return PROCEDURESQL;
                }
            }

                //����Ǵ洢����
            else {
                return PROCEDURESQL;
            }
        }

        /// <summary>
        /// ��Ԥ������Int�͵�Sql���
        /// </summary>
        /// <param name="strSql"></param>
        /// <returns></returns>
        public int ExecuteForInt(string strSql) {
            //�ж�Sql��������
            int iSqlType = GetSqlType(strSql);

            //����ǿ����
            if( iSqlType== ERRORSQL) {
                return -1;
            }

            //����Ǹ������
            if(iSqlType == UPDATESQL) {
                return curDBOperater.ExecUpdateSql(strSql);
            }

                //����Ǵ洢����
            else if(iSqlType == PROCEDURESQL) {
                return curDBOperater.ExecUpdateProc(strSql,null);
            }

                //������������
            else {
                return -1;
            }
        }

        public object ExecuteForScalar(string strSql)
        {
            //�ж�Sql��������
            int iSqlType = GetSqlType(strSql);

            //����ǿ����
            if (iSqlType == ERRORSQL)
            {
                return -1;
            }

            //����Ǹ������
            if (iSqlType == SELECTSQL)
            {
                return curDBOperater.ExecScalar(strSql);
            }

                //����Ǵ洢����
            else if (iSqlType == PROCEDURESQL)
            {
                return curDBOperater.ExecScalar(strSql, null);
            }

                //������������
            else
            {
                return -1;
            }

        }

        /// <summary>
        /// Ԥ������Int�͵�Sql���
        /// </summary>
        /// <param name="strSql"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public int ExecuteForInt(string strSql, IDataParameter[] parameters) {
            //�ж�Sql��������
            int iSqlType = GetSqlType(strSql);

            //����ǿ����
            if(iSqlType == ERRORSQL) {
                return -1;
            }

            //����Ǹ������
            if(iSqlType == UPDATESQL) {
                return curDBOperater.ExecPreUpdateSql(strSql,parameters);
            }

                //����Ǵ洢����
            else if(iSqlType == PROCEDURESQL) {
                return curDBOperater.ExecUpdateProc(strSql,parameters);
            }

                //������������
            else {
                return -1;
            }
        }

        /// <summary>
        /// ��Ԥ������DataSet�͵�Sql���
        /// </summary>
        /// <param name="strSql"></param>
        /// <returns></returns>
        public DataSet ExecuteForDataSet(string strSql, string strTableName) {
            //�ж�Sql��������
            int iSqlType = GetSqlType(strSql);

            //����ǿ����
            if(iSqlType == ERRORSQL) {
                return null;
            }

            //�����Select���
            if(iSqlType == SELECTSQL) {
                return curDBOperater.ExecQueryForDataSet(strSql,strTableName);
            }

                //����Ǵ洢����
            else if(iSqlType == PROCEDURESQL) {
                return curDBOperater.ExecProcForDataSet(strSql,null,strTableName);
            }

                //������������
            else {
                return null;
            }
        }

        /// <summary>
        /// Ԥ������DataSet�͵�Sql���
        /// </summary>
        /// <param name="strSql"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public DataSet ExecuteForDataSet(string strSql, IDataParameter[] parameters, string strTableName) {
            //�ж�Sql��������
            int iSqlType = GetSqlType(strSql);

            //����ǿ����
            if(iSqlType == ERRORSQL) {
                return null;
            }

            //�����Select���
            if(iSqlType == SELECTSQL) {
                return curDBOperater.ExecPreQueryForDataSet(strSql,parameters,strTableName);
            }

                //����Ǵ洢����
            else if(iSqlType == PROCEDURESQL) {
                return curDBOperater.ExecProcForDataSet(strSql,parameters,strTableName);
            }

                //������������
            else {
                return null;
            }
        }

        /// <summary>
        /// ��Ԥ������DataTable�͵�Sql���
        /// </summary>
        /// <param name="strSql"></param>
        /// <returns></returns>
        public DataTable ExecuteForDataTable(string strSql) {
            //�ж�Sql��������
            int iSqlType = GetSqlType(strSql);

            //����ǿ����
            if(iSqlType == ERRORSQL) {
                return null;
            }

            //�����Select���
            if(iSqlType == SELECTSQL) {
                return curDBOperater.ExecQueryForDataTable(strSql);
            }

                //����Ǵ洢����
            else if(iSqlType == PROCEDURESQL) {
                return curDBOperater.ExecProcForDataTable(strSql,null);
            }

                //������������
            else {
                return null;
            }
        }

        /// <summary>
        /// Ԥ������DataTable�͵�Sql���
        /// </summary>
        /// <param name="strSql"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public DataTable ExecuteForDataTable(string strSql, IDataParameter[] parameters) {
            //�ж�Sql��������
            int iSqlType = GetSqlType(strSql);

            //����ǿ����
            if(iSqlType == ERRORSQL) {
                return null;
            }

            //�����Select���
            if(iSqlType == SELECTSQL) {
                return curDBOperater.ExecPreQueryForDataTable(strSql,parameters);
            }

                //����Ǵ洢����
            else if(iSqlType == PROCEDURESQL) {
                return curDBOperater.ExecProcForDataTable(strSql,parameters);
            }

                //������������
            else {
                return null;
            }
        }

        /// <summary>
        /// ��Ԥ������DataReader�͵�Sql���
        /// </summary>
        /// <param name="strSql"></param>
        /// <returns></returns>
        public IDataReader ExecuteForDataReader(string strSql) {
            //�ж�Sql��������
            int iSqlType = GetSqlType(strSql);

            //����ǿ����
            if(iSqlType == ERRORSQL) {
                return null;
            }

            //�����Select���
            if(iSqlType == SELECTSQL) {
                return curDBOperater.ExecQueryForDataReader(strSql) ;
            }

                //����Ǵ洢����
            else if(iSqlType == PROCEDURESQL) {
                return curDBOperater.ExecProcForDataReader(strSql,null);
            }

                //������������
            else {
                return null;
            }
        }

        /// <summary>
        /// Ԥ������DataReader�͵�Sql���
        /// </summary>
        /// <param name="strSql"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public IDataReader ExecuteForDataReader(string strSql, IDataParameter[] parameters) {
            //�ж�Sql��������
            int iSqlType = GetSqlType(strSql);

            //����ǿ����
            if(iSqlType == ERRORSQL) {
                return null;
            }

            //�����Select���
            if(iSqlType == SELECTSQL) {
                return curDBOperater.ExecPreQueryForDataReader(strSql,parameters);
            }

                //����Ǵ洢����
            else if(iSqlType == PROCEDURESQL) {
                return curDBOperater.ExecProcForDataReader(strSql,parameters);
            }

                //������������
            else {
                return null;
            }
        }

        public object ExecuteForScalar(string strSql, IDataParameter[] parameters)
        {
            //�ж�Sql��������
            int iSqlType = GetSqlType(strSql);

            //����ǿ����
            if (iSqlType == ERRORSQL)
            {
                return null;
            }

            //�����Select���
            if (iSqlType == SELECTSQL)
            {
                return curDBOperater.ExecScalar(strSql, parameters);
            }

                //����Ǵ洢����
            else if (iSqlType == PROCEDURESQL)
            {
                return curDBOperater.ExecScalar(strSql, parameters);
            }

                //������������
            else
            {
                return null;
            }
        }
		
    }
}
