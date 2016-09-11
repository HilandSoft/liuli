///<copyright>Ӣ����Ѷ�������޹�˾ 1999-2004</copyright>
///<version>V1.0  </verion>
///<createdate>2004-6-15</createdate>
///<author>xier</author>
///<email>xier@YingNet.com</email>
///<log date="2004-4-21">����</log>
///<desc>����һ���� ������ ��DBAccess ��ĸĽ�.��Ҫ˼��Ϊ�ڽ��� ����ʵ����ʱ��
/// ��ʼ�����Ӷ���,�ڱ������ٵ�ʱ�� �رղ����� ���Ӷ���(��Ȼû��ʵ���������)
/// </desc>

using System;
using System.Data;
using System.Data.SqlClient;

namespace YingNet.Common
{
	/// <summary>
	/// SQLAccess ��ժҪ˵����
	/// </summary>
	public class SQLAccess : IDisposable 
	{
		public SQLAccess()
		{
			this.Open();
		}

		protected SqlConnection oConn = null;
		
		#region ���Ӳ���
		/// <summary>
		/// ������
		/// </summary>
		private void Open() 
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
		private void Close() 
		{
			if (oConn != null) 
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
		#endregion

		//=======================================================================
		// ***** [ADDED BY DoItNow,2004/6/16]
		//-----------------------------------------------------------------------
		/// <summary>
		/// ִ�в�ѯ ���ص�һ��ֵ
		/// </summary>
		/// <param name="sql"></param>
		/// <returns></returns>
		public virtual object RunSqlStringReturnScalar(string sql)
		{
			object obj= null;
			//this.Open();
			obj= SqlHelper.ExecuteScalar(oConn,CommandType.Text,sql);
			//this.Close();
			return obj;
		}
		//=======[ADDED END]=====================================================
	}
}