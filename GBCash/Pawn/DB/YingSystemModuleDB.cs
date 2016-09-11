/// <copyright>�ൺӢ����Ѷ�������޹�˾  1999-2004</copyright>
/// <version>1.0</version>
/// <author>������</author>
/// <email>jibf@YingNet.com</email>
/// <log date="2004-8-9">����</log>

using System;
using System.Collections;
using System.Data;
using System.Data.SqlClient;
using YingNet.Common;
using YingNet.WeiXing.DB.Data;

namespace YingNet.WeiXing.DB
{
	
	/// <summary>
	/// DepinfoDT��ժҪ˵����
	/// <summary>

	public class YingSystemModuleDB:DBAccess
	{

		/// <summary>
		///  ���ṹȡֵ
		/// <summary>
		/// <param name='dr'>SqlDataReader</param>
		/// <param name='obj'>���ݽṹ����</param>
		/// <returns>���ݽṹ����</returns>
		public override object ConvertItem( SqlDataReader dr)
		{
			YingSystemModuleDT dt = new YingSystemModuleDT();
			dt.code= Convert.ToString(dr["code"]);
			dt.name= Convert.ToString(dr["name"]);
			dt.displayname= Convert.ToString(dr["displayname"]);
			return dt;
		}

		/// <summary>
		///  ��֯�����б�
		/// <summary>
		/// <param name='obj'>���ݽṹ����</param>
		/// <returns>�����б�</returns>
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
		///  ��֯�����б�
		/// <summary>
		/// <param name='obj'>���ݽṹ����</param>
		/// <returns>�����б�</returns>
		public SqlParameter[] GetParameter( string strCode)
		{
			SqlParameter[] prams =
			{
				MakeInParam("@code" ,SqlDbType.Char,12,strCode),
			};
			return prams;
		}

		/// <summary>
		/// ɾ��
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
		/// ȡ������¼
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
