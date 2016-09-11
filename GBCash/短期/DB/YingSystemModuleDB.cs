/// <copyright>青岛英网资讯技术有限公司  1999-2004</copyright>
/// <version>1.0</version>
/// <author>季宝福</author>
/// <email>jibf@YingNet.com</email>
/// <log date="2004-8-9">创建</log>

using System;
using System.Collections;
using System.Data;
using System.Data.SqlClient;
using YingNet.Common;
using YingNet.WeiXing.DB.Data;

namespace YingNet.WeiXing.DB
{
	
	/// <summary>
	/// DepinfoDT的摘要说明。
	/// <summary>

	public class YingSystemModuleDB:DBAccess
	{

		/// <summary>
		///  按结构取值
		/// <summary>
		/// <param name='dr'>SqlDataReader</param>
		/// <param name='obj'>数据结构对象</param>
		/// <returns>数据结构对象</returns>
		public override object ConvertItem( SqlDataReader dr)
		{
			YingSystemModuleDT dt = new YingSystemModuleDT();
			dt.code= Convert.ToString(dr["code"]);
			dt.name= Convert.ToString(dr["name"]);
			dt.displayname= Convert.ToString(dr["displayname"]);
			return dt;
		}

		/// <summary>
		///  组织参数列表
		/// <summary>
		/// <param name='obj'>数据结构对象</param>
		/// <returns>参数列表</returns>
		public override SqlParameter[] GetParameter( object obj )
		{
			YingSystemModuleDT dt = (YingSystemModuleDT)obj;
			SqlParameter[] prams =
			{
				MakeInParam("@code" ,SqlDbType.Char,12,dt.code),
				MakeInParam("@name" ,SqlDbType.VarChar,50,dt.name),
				MakeInParam("@displayname" ,SqlDbType.VarChar,50,dt.displayname)
			};
			return prams;
		}

		/// <summary>
		///  组织参数列表
		/// <summary>
		/// <param name='obj'>数据结构对象</param>
		/// <returns>参数列表</returns>
		public SqlParameter[] GetParameter( string strCode)
		{
			SqlParameter[] prams =
			{
				MakeInParam("@code" ,SqlDbType.Char,12,strCode),
			};
			return prams;
		}

		/// <summary>
		/// 删除
		/// </summary>
		/// <param name="id"></param>
		/// <param name="isdel"></param>
		/// <returns></returns>
		public bool Del(string strCode)
		{
			Open();
			try 
			{
				RunProc("proc_YingSystemModuleDB_Del", GetParameter( strCode ));
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
		/// 取单条记录
		/// </summary>
		/// <param name="id"></param>
		/// <returns></returns>
		public object GetOneItem( string strCode )
		{
			object dt = null;
			SqlDataReader dr = null;
			Open();
			try 
			{
				dr = RunProc("proc_YingSystemModuleDB_GetItem", GetParameter( strCode ));

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
		public YingSystemModuleDT GetOneDT( string strCode )
		{
			return (YingSystemModuleDT)GetOneItem( strCode );
		}
	}

}
