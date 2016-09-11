///<copyright>英网资讯技术有限公司 1999-2004</copyright>
///<version>V1.0  </verion>
///<createdate>2004-4-21</createdate>
///<author>季宝福</author>
///<email>jibf@YingNet.com</email>
///<log date="2004-4-21">创建</log>

using System;
using System.Data;
using System.Data.SqlClient;

namespace YingNet.Common
{
	/// <summary>
	/// 数据
	/// </summary>
	public class DBAccess:IDisposable 
	{
		protected SqlConnection oConn = null;
		
		#region 连接操作
		/// <summary>
		/// 打开连接
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
		/// 关闭连接
		/// </summary>
		public void Close() 
		{
			if (oConn != null)// && CloseConnectionAfterAccess)  
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

		#region 表操作

		/// <summary>
		/// 转换对象派生类必须改写
		/// </summary>
		/// <param name="dr"></param>
		/// <param name="obj"></param>
		/// <returns></returns>
		public virtual object ConvertItem( SqlDataReader dr)
		{
			return null;
		}
		/// <summary>
		/// 取单条记录
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
		/// 取单条记录
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
		///添加
		///</summary>
		/// <param name="dt"> 表数据结构 </param>
		/// <param name="pid">返回添加的记录ID</param>
		/// <returns>成功/失败</returns>
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
		///添加
		///</summary>
		/// <param name="dt"> 表数据结构 </param>
		/// <param name="pid">返回添加的记录ID</param>
		/// <returns>成功/失败</returns>
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
		/// 删除
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
		/// 删除
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
		/// 取表名
		///</summary>
		public virtual string GetTableName()
		{
			string str  = this.ToString();
			return str.Substring(str.LastIndexOf(".")+1,(str.Length-str.LastIndexOf(".")-1));
		}
		#endregion

		#region 数据操作
		/// <summary>
		/// 运行SQL字符串命令
		/// 此方法在Common.CommonBaseLib类也有调用
		/// 主要负责页面DataGrid用
		/// </summary>
		/// <param name="strSqlCommand">SQL字符串命令</param>
		/// <param name="strTableName">返回的内存表名</param>
		/// <returns>返回内存表</returns>
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
		/// 运行SQL字符串命令
		/// 记得用完SqlDataReader要关闭
		/// </summary>
		/// <param name="strSqlCommand">SQL字符串</param>
		/// <returns>SqlDataReader</returns>
		public virtual SqlDataReader RunSqlString( string strSqlCommand )
		{
			Open();
			return SqlHelper.ExecuteReader(oConn,CommandType.Text,strSqlCommand);
		}
		/// <summary>
		/// 运行SQL字符串命令
		/// </summary>
		/// <param name="strSqlCommand">SQL字符串</param>
		/// <param name="iLine">影响行数</param>
		/// <returns>成功/失败</returns>
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
		/// 运行SQL字符串命令
		/// </summary>
		/// <param name="strSqlCommand">SQL字符串</param>
		/// <returns>成功/失败</returns>
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

		#region 生成参数列表
		/// <summary>
		/// 取参数列表
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
		/// 取参数列表
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
		/// 取参数列表
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
		/// 取参数列表
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
		/// 取参数列表
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
		/// 根据不同表取参数列表
		/// </summary>
		public virtual SqlParameter[] GetParameter(object ob)
		{
			return null;
		}

		#endregion

		#region 生成参数方法

		/// <summary>
		/// 生成参数
		/// </summary>
		/// <param name="ParamName">参数名称</param>
		/// <param name="DbType">类型</param>
		/// <param name="Size">长度</param>
		/// <param name="Value">值</param>
		/// <returns>参数表</returns>
		public SqlParameter MakeInParam(string ParamName, SqlDbType DbType, int Size, object Value) 
		{
			return MakeParam(ParamName, DbType, Size, ParameterDirection.Input, Value);
		}		

		/// <summary>
		/// 生成参数
		/// </summary>
		/// <param name="ParamName">参数名称</param>
		/// <param name="DbType">类型</param>
		/// <param name="Size">长度</param>
		/// <param name="Value">值</param>
		/// <returns>参数表</returns>
		public SqlParameter MakeInParam(string ParamName, SqlDbType DbType, int Size,Byte Scale, object Value) 
		{
			return MakeParam(ParamName, DbType, Size, ParameterDirection.Input, Scale, Value);
		}	
		/// <summary>
		/// 生成参数
		/// </summary>
		/// <param name="ParamName">参数名称</param>
		/// <param name="DbType">类型</param>
		/// <param name="Size">长度</param>
		/// <param name="Value">值</param>
		/// <returns>参数表</returns>
		public SqlParameter MakeOutParam(string ParamName, SqlDbType DbType, int Size) 
		{
			return MakeParam(ParamName, DbType, Size, ParameterDirection.Output, null);
		}		

		/// <summary>
		/// 生成参数
		/// </summary>
		/// <param name="ParamName">参数名称</param>
		/// <param name="DbType">类型</param>
		/// <param name="Size">长度</param>
		/// <param name="Direction">形式</param>
		/// <param name="Value">值</param>
		/// <returns>参数表</returns>
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
		/// 生成参数
		/// </summary>
		/// <param name="ParamName">参数名称</param>
		/// <param name="DbType">类型</param>
		/// <param name="Size">长度</param>
		/// <param name="Direction">形式</param>
		/// <param name="Value">值</param>
		/// <returns>参数表</returns>
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