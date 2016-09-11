///<copyright>Ӣ����Ѷ�������޹�˾ 1999-2004</copyright>
///<version>V1.0  </verion>
///<createdate>2004-4-21</createdate>
///<author>������</author>
///<email>jibf@YingNet.com</email>
///<log date="2004-4-21">����</log>

using System;
using System.Data;
using System.Data.SqlClient;

namespace YingNet.Common
{
	/// <summary>
	/// ����
	/// </summary>
	public class DBAccess:IDisposable 
	{
		protected SqlConnection oConn = null;
		
		#region ���Ӳ���
		/// <summary>
		/// ������
		/// </summary>
		public void Open() 
		{
			if (oConn == null) 
			{
				oConn = new SqlConnection( Config.DataSource );
				oConn.Open();
			}
			else
			{
				if(oConn.State== ConnectionState.Broken||oConn.State==ConnectionState.Closed)
					oConn.Open();
			}
		}

		/// <summary>
		/// �ر�����
		/// </summary>
		public void Close() 
		{
			if (oConn != null)// && CloseConnectionAfterAccess)  
				oConn.Close();
		}

		/// <summary>
		/// �ͷ���Դ
		/// </summary>
		public void Dispose() 
		{
			if (oConn != null) 
			{
				Close();
				oConn.Dispose();
				oConn = null;
			}			
		}
/*
		protected bool m_CloseConnectionAfterAccess = false;
		public bool CloseConnectionAfterAccess
		{
			get
			{
				return m_CloseConnectionAfterAccess;
			}
			set
			{
				m_CloseConnectionAfterAccess = value;
			}
		}
*/
		#endregion

		#region �����

		/// <summary>
		/// ת����������������д
		/// </summary>
		/// <param name="dr"></param>
		/// <param name="obj"></param>
		/// <returns></returns>
		public virtual object ConvertItem( SqlDataReader dr)
		{
			return null;
		}
		/// <summary>
		/// ȡ������¼
		/// </summary>
		/// <param name="id"></param>
		/// <returns></returns>
		public virtual object GetOneItem( int id )
		{
			object dt = null;
			SqlDataReader dr = null;
			Open();
			try 
			{
				dr = SqlHelper.ExecuteReader(oConn,CommandType.StoredProcedure,"proc_"+GetTableName()+"_GetItem", GetParameter(id));

				if ( dr.Read() )
				{
					dt = ConvertItem(dr);
				}
				else
				{
					dt = null;
				}
				dr.Close();
			}
			catch(SqlException e)
			{
				return null;
			}
			finally
			{
				Close();
			}
			Close();
			return dt;

		}
		
		/// <summary>
		/// ȡ������¼
		/// </summary>
		/// <param name="id"></param>
		/// <returns></returns>
		public virtual object GetOneItem( int id,string IDColumnName)
		{
			object dt = null;
			SqlDataReader dr = null;
			Open();
			try 
			{
				dr = SqlHelper.ExecuteReader(oConn,CommandType.StoredProcedure,"proc_"+GetTableName()+"_GetItem", GetParameter(id,IDColumnName));

				if ( dr.Read() )
				{
					dt = ConvertItem(dr);
				}
				else
				{
					dt = null;
				}
				dr.Close();
			}
			catch(SqlException e)
			{
				return null;
			}
			finally
			{
				Close();
			}
			Close();
			return dt;

		}

		///<summary>
		///���
		///</summary>
		/// <param name="dt"> �����ݽṹ </param>
		/// <param name="pid">������ӵļ�¼ID</param>
		/// <returns>�ɹ�/ʧ��</returns>
		public virtual bool Insert(object ob)
		{
			Open();
			try 
			{
				SqlHelper.ExecuteNonQuery(oConn,CommandType.StoredProcedure,"proc_"+GetTableName()+"_Insert", GetParameter(ob));

			}
			catch(Exception ex)
			{
				throw ex;
			}
			finally
			{
				Close();
			}
			return true;
		}

		///<summary>
		///���
		///</summary>
		/// <param name="dt"> �����ݽṹ </param>
		/// <param name="pid">������ӵļ�¼ID</param>
		/// <returns>�ɹ�/ʧ��</returns>
		public virtual bool Update(object ob)
		{
			Open();
			try 
			{
				SqlHelper.ExecuteNonQuery(oConn,CommandType.StoredProcedure,"proc_"+GetTableName()+"_Update", GetParameter(ob));

			}
			catch(SqlException e)
			{
				throw e;
				//return false;
			}
			finally
			{
				Close();
			}
			return true;
		}
		/// <summary>
		/// 
		/// </summary>
		/// <param name="id"></param>
		/// <returns></returns>
		public virtual bool Del(int id)
		{
			return Del(id,true);
		}
		/// <summary>
		/// ɾ��
		/// </summary>
		/// <param name="id"></param>
		/// <param name="isdel"></param>
		/// <returns></returns>
		public virtual bool Del(int id,bool isdel)
		{
			Open();
			try 
			{
				SqlHelper.ExecuteNonQuery(oConn,CommandType.StoredProcedure,"proc_"+GetTableName()+"_Del", GetParameter(id,isdel));
			}
			catch(SqlException e)
			{
				return false;
			}
			finally
			{
				Close();
			}
			Close();
			return true;
		}
		
		public virtual bool Del(int id,bool isdel,string IDColumnName)
		{
			Open();
			try 
			{
				SqlHelper.ExecuteNonQuery(oConn,CommandType.StoredProcedure,"proc_"+GetTableName()+"_Del", GetParameter(id,isdel,IDColumnName));
			}
			catch(SqlException e)
			{
				return false;
			}
			finally
			{
				Close();
			}
			Close();
			return true;
		}

		/// <summary>
		/// ɾ��
		/// </summary>
		/// <param name="id"></param>
		/// <param name="isdel"></param>
		/// <returns></returns>
		public virtual bool TrueDel(int id)
		{
			Open();
			try 
			{
				SqlHelper.ExecuteNonQuery(oConn,CommandType.StoredProcedure,"proc_"+GetTableName()+"_Del", GetParameter(id));
			}
			catch(SqlException e)
			{
				return false;
			}
			finally
			{
				Close();
			}
			Close();
			return true;
		}


		///<summary>
		/// ȡ����
		///</summary>
		public virtual string GetTableName()
		{
			string str  = this.ToString();
			return str.Substring(str.LastIndexOf(".")+1,(str.Length-str.LastIndexOf(".")-1));
		}
		#endregion

		#region ���ݲ���
		/// <summary>
		/// ����SQL�ַ�������
		/// �˷�����Common.CommonBaseLib��Ҳ�е���
		/// ��Ҫ����ҳ��DataGrid��
		/// </summary>
		/// <param name="strSqlCommand">SQL�ַ�������</param>
		/// <param name="strTableName">���ص��ڴ����</param>
		/// <returns>�����ڴ��</returns>
		public virtual DataTable RunSqlString( string strSqlCommand, string strTableName )
		{
			DataTable dt = null;
			Open();
			dt = SqlHelper.ExecuteDataset( oConn, CommandType.Text, strSqlCommand).Tables[0];
			dt.TableName = strTableName;
			Close();
			return dt;
		}
		/// <summary>
		/// ����SQL�ַ�������
		/// �ǵ�����SqlDataReaderҪ�ر�
		/// </summary>
		/// <param name="strSqlCommand">SQL�ַ���</param>
		/// <returns>SqlDataReader</returns>
		public virtual SqlDataReader RunSqlString( string strSqlCommand )
		{
			Open();
			return SqlHelper.ExecuteReader(oConn,CommandType.Text,strSqlCommand);
		}
		/// <summary>
		/// ����SQL�ַ�������
		/// </summary>
		/// <param name="strSqlCommand">SQL�ַ���</param>
		/// <param name="iLine">Ӱ������</param>
		/// <returns>�ɹ�/ʧ��</returns>
		public virtual bool RunSqlStringNoReturn( string strSqlCommand ,out int iLine)
		{
			Open();
			try
			{
				iLine = SqlHelper.ExecuteNonQuery(oConn,CommandType.Text,strSqlCommand);
				Close();
				return true;
			}
			catch
			{
				iLine = 0;
				return false;
			}
			finally
			{
				Close();
			}
		}

		/// <summary>
		/// ����SQL�ַ�������
		/// </summary>
		/// <param name="strSqlCommand">SQL�ַ���</param>
		/// <returns>�ɹ�/ʧ��</returns>
		public virtual bool RunSqlStringNoReturn( string strSqlCommand)
		{
			Open();
			try
			{
				SqlHelper.ExecuteNonQuery(oConn,CommandType.Text,strSqlCommand);
				Close();
				return true;
			}
			catch
			{
				return false;
			}
			finally
			{
				Close();
			}
		}

		public virtual DataTable RunProc(string strStoredProcedureName, string strTableName )
		{
			DataTable dt = null;
			Open();
			dt = SqlHelper.ExecuteDataset(oConn,CommandType.StoredProcedure,strStoredProcedureName).Tables[0];
			dt.TableName = strTableName;
			Close();
			return dt;
		}
		public virtual DataTable RunProc(string strStoredProcedureName, string strTableName , SqlParameter[] prams)
		{
			DataTable dt = null;
			Open();
			dt = SqlHelper.ExecuteDataset(oConn,CommandType.StoredProcedure,strStoredProcedureName,prams).Tables[0];
			dt.TableName = strTableName;
			Close();
			return dt;
		}
		public virtual SqlDataReader RunProc(string strStoredProcedureName )
		{
			Open();
			return SqlHelper.ExecuteReader(oConn,CommandType.StoredProcedure,strStoredProcedureName);
		}
		public virtual SqlDataReader RunProc(string strStoredProcedureName , SqlParameter[] prams)
		{
			Open();
			return SqlHelper.ExecuteReader(oConn,CommandType.StoredProcedure,strStoredProcedureName,prams);
		}


		#endregion

		#region ���ɲ����б�
		/// <summary>
		/// ȡ�����б�
		/// </summary>
		public virtual SqlParameter[] GetParameter(int id)
		{
			SqlParameter[] prams =
			{
				MakeInParam("@id", SqlDbType.Int,4, id),
			};
			return prams;
		}
		
		/// <summary>
		/// ȡ�����б�
		/// </summary>
		public virtual SqlParameter[] GetParameter(int id,string IDColumnName)
		{
			SqlParameter[] prams =
			{
				MakeInParam("@"+IDColumnName, SqlDbType.Int,4, id),
			};
			return prams;
		}

		/// <summary>
		/// ȡ�����б�
		/// </summary>
		public virtual SqlParameter[] GetParameter(int id,bool isdel)
		{
			SqlParameter[] prams =
			{
				MakeInParam("@id", SqlDbType.Int,4, id),
				MakeInParam("@del", SqlDbType.Bit,1, isdel),
			};
			return prams;
		}
		
		/// <summary>
		/// ȡ�����б�
		/// </summary>
		public virtual SqlParameter[] GetParameter(int id,bool isdel,string IDColumnName)
		{
			SqlParameter[] prams =
			{
				MakeInParam("@"+IDColumnName, SqlDbType.Int,4, id),
				MakeInParam("@del", SqlDbType.Bit,1, isdel),
			};
			return prams;
		}
        
		/// <summary>
		/// ȡ�����б�
		/// </summary>
		public virtual SqlParameter[] GetParameter(string Item,string strItem,int Size)
		{
			SqlParameter[] prams =
			{
				MakeInParam(Item, SqlDbType.NVarChar,Size, strItem),
			};
			return prams;
		}

		/// <summary>
		/// ���ݲ�ͬ��ȡ�����б�
		/// </summary>
		public virtual SqlParameter[] GetParameter(object ob)
		{
			return null;
		}

		#endregion

		#region ���ɲ�������

		/// <summary>
		/// ���ɲ���
		/// </summary>
		/// <param name="ParamName">��������</param>
		/// <param name="DbType">����</param>
		/// <param name="Size">����</param>
		/// <param name="Value">ֵ</param>
		/// <returns>������</returns>
		public SqlParameter MakeInParam(string ParamName, SqlDbType DbType, int Size, object Value) 
		{
			return MakeParam(ParamName, DbType, Size, ParameterDirection.Input, Value);
		}		

		/// <summary>
		/// ���ɲ���
		/// </summary>
		/// <param name="ParamName">��������</param>
		/// <param name="DbType">����</param>
		/// <param name="Size">����</param>
		/// <param name="Value">ֵ</param>
		/// <returns>������</returns>
		public SqlParameter MakeInParam(string ParamName, SqlDbType DbType, int Size,Byte Scale, object Value) 
		{
			return MakeParam(ParamName, DbType, Size, ParameterDirection.Input, Scale, Value);
		}	
		/// <summary>
		/// ���ɲ���
		/// </summary>
		/// <param name="ParamName">��������</param>
		/// <param name="DbType">����</param>
		/// <param name="Size">����</param>
		/// <param name="Value">ֵ</param>
		/// <returns>������</returns>
		public SqlParameter MakeOutParam(string ParamName, SqlDbType DbType, int Size) 
		{
			return MakeParam(ParamName, DbType, Size, ParameterDirection.Output, null);
		}		

		/// <summary>
		/// ���ɲ���
		/// </summary>
		/// <param name="ParamName">��������</param>
		/// <param name="DbType">����</param>
		/// <param name="Size">����</param>
		/// <param name="Direction">��ʽ</param>
		/// <param name="Value">ֵ</param>
		/// <returns>������</returns>
		public SqlParameter MakeParam(string ParamName, SqlDbType DbType, Int32 Size, ParameterDirection Direction, object Value) 
		{
			SqlParameter param;

			if(Size > 0)
				param = new SqlParameter(ParamName, DbType, Size);
			else
				param = new SqlParameter(ParamName, DbType);

			param.Direction = Direction;
			if (!(Direction == ParameterDirection.Output && Value == null))
				param.Value = Value;

			return param;
		}
		/// <summary>
		/// ���ɲ���
		/// </summary>
		/// <param name="ParamName">��������</param>
		/// <param name="DbType">����</param>
		/// <param name="Size">����</param>
		/// <param name="Direction">��ʽ</param>
		/// <param name="Value">ֵ</param>
		/// <returns>������</returns>
		public SqlParameter MakeParam(string ParamName, SqlDbType DbType, Int32 Size, ParameterDirection Direction,Byte Scale, object Value) 
		{
			SqlParameter param;

			if(Size > 0)
				param = new SqlParameter(ParamName, DbType, Size);
			else
				param = new SqlParameter(ParamName, DbType);

			param.Direction = Direction;
			param.Scale = Scale;
			if (!(Direction == ParameterDirection.Output && Value == null))
				param.Value = Value;

			return param;
		}
		#endregion
	
	}
}