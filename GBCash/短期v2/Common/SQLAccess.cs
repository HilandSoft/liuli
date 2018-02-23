///<copyright>英网资讯技术有限公司 1999-2004</copyright>
///<version>V1.0  </verion>
///<createdate>2004-6-15</createdate>
///<author>xier</author>
///<email>xier@YingNet.com</email>
///<log date="2004-4-21">创建</log>
///<desc>这是一个对 季宝福 的DBAccess 类的改进.主要思想为在建立 本类实例的时候
/// 初始化连接对象,在本类销毁的时候 关闭并销毁 连接对象(依然没有实现事务控制)
/// </desc>

using System;
using System.Data;
using System.Data.SqlClient;

namespace YingNet.Common
{
	/// <summary>
	/// SQLAccess 的摘要说明。
	/// </summary>
	public class SQLAccess : IDisposable 
	{
		public SQLAccess()
		{
			this.Open();
		}

		protected SqlConnection oConn = null;
		
		#region 连接操作
		/// <summary>
		/// 打开连接
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
		/// 关闭连接
		/// </summary>
		private void Close() 
		{
			if (oConn != null) 
				oConn.Close();
		}

		/// <summary>
		/// 释放资源
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
		/// 执行查询 返回第一个值
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