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
using System.Runtime.Serialization.Formatters;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;


namespace YingNet.WeiXing.DB
{
	
	/// <summary>
	/// DepinfoDT��ժҪ˵����
	/// <summary>

	public class YingSystemUserDB:DBAccess
	{

		/// <summary>
		///  ���ṹȡֵ
		/// <summary>
		/// <param name='dr'>SqlDataReader</param>
		/// <param name='obj'>���ݽṹ����</param>
		/// <returns>���ݽṹ����</returns>
		public override object ConvertItem( SqlDataReader dr)
		{
			YingSystemUserDT dt = new YingSystemUserDT();

            //��ʼȨ��
            try
            {
                dt.permit= (Hashtable)ReadData((byte[])dr["permit"]);
            }
            catch
            {
                dt.permit = new Hashtable();
            }
			dt.isactive= Convert.ToBoolean(dr["isactive"]);
			dt.id= Convert.ToInt32(dr["id"]);
			dt.account= Convert.ToString(dr["account"]);
			dt.password= Convert.ToString(dr["password"]);
			dt.name= Convert.ToString(dr["name"]);
			dt.deptpermit= Convert.ToString(dr["deptpermit"]);
			return dt;
		}

		/// <summary>
		///  ��֯�����б�
		/// <summary>
		/// <param name='obj'>���ݽṹ����</param>
		/// <returns>�����б�</returns>
		public override SqlParameter[] GetParameter( object obj )
		{
			YingSystemUserDT dt = (YingSystemUserDT)obj;
			SqlParameter[] prams =
			{
				MakeInParam("@permit" ,SqlDbType.Binary,5000,SaveData(dt.permit)),
				MakeInParam("@isactive" ,SqlDbType.Bit,1,dt.isactive),
				MakeInParam("@id" ,SqlDbType.Int,4,dt.id),
				MakeInParam("@account" ,SqlDbType.VarChar,50,dt.account),
				MakeInParam("@password" ,SqlDbType.VarChar,150, dt.password ),
				MakeInParam("@name" ,SqlDbType.VarChar,50,dt.name),
				MakeInParam("@deptpermit" ,SqlDbType.VarChar,120,dt.deptpermit)
			};
			return prams;
		}

		/// <summary>
		///  ��֯�����б�
		/// <summary>
		/// <param name='obj'>���ݽṹ����</param>
		/// <returns>�����б�</returns>
		public SqlParameter[] GetParameter( string strAccount ,string strPassword )
		{
			SqlParameter[] prams =
			{
				MakeInParam("@account" ,SqlDbType.VarChar,50,strAccount),
				MakeInParam("@password" ,SqlDbType.VarChar,150,strPassword),
			};
			return prams;
		}

		/// <summary>
		///  ��֯�����б�
		/// <summary>
		/// <param name='obj'>���ݽṹ����</param>
		/// <returns>�����б�</returns>
		public SqlParameter[] GetParameter(int id, string strAccount ,string strPassword )
		{
			SqlParameter[] prams =
			{
				MakeInParam("@account" ,SqlDbType.VarChar,50,strAccount),
				MakeInParam("@password" ,SqlDbType.VarChar,150,strPassword),
				MakeInParam("@id" ,SqlDbType.Int,4,id)
			};
			return prams;
		}

		/// <summary>
		/// ȡ������¼
		/// </summary>
		/// <param name="id"></param>
		/// <returns></returns>
		public virtual YingSystemUserDT Login( string strAccount ,string strPassword )
		{
			YingSystemUserDT dt = null;
			SqlDataReader dr = null;
			Open();
			try 
			{
				//strPassword = Cipher.EncryptMD5(strPassword);
				dr = RunProc("proc_YingSystemUserDB_Login", GetParameter( strAccount,strPassword ));

				if ( dr.Read() )
				{
					dt = (YingSystemUserDT)ConvertItem(dr);
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
		public virtual YingSystemUserDT Update(int id, string strAccount ,string strPassword )
		{
			YingSystemUserDT dt = null;
			SqlDataReader dr = null;
			Open();
			try 
			{
				//strPassword = Cipher.EncryptMD5(strPassword);
				dr = RunProc("proc_YingSystemUserDB_UpdatePass", GetParameter( id , strAccount,strPassword ));

				if ( dr.Read() )
				{
					dt = (YingSystemUserDT)ConvertItem(dr);
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

		public YingSystemUserDT GetOneDT(int id)
		{
			return (YingSystemUserDT)GetOneItem(id);
		}
	
		public byte[] SaveData(object objName)
		{
			byte[] bData= null;
			BinaryFormatter b= null;
			MemoryStream ms = new MemoryStream();
			try
			{
				b = new BinaryFormatter();
				b.Serialize(ms, objName);
				b=null;
				bData = ms.ToArray();
				ms.Close();
				return bData;
			}
			catch(Exception e)
			{
				if(b!=null)
					b=null;
				if ( ms!=null )
					ms.Close();
				
				return null;
			}

		}

		public object ReadData( byte[] bData)
		{
			MemoryStream ms = null;
			BinaryFormatter b= null;
			object h = null;
			try
			{
				ms = new MemoryStream( bData );
				b = new BinaryFormatter();
				h = (object) b.Deserialize(ms);
				ms.Close();
				b = null;
				return h;
			}
			catch(Exception e)
			{
				if(ms!=null)
					ms.Close();
				if(b!=null)
					b=null;
				return null;
			}
		}
	
	}

}
