using System;
using System.Data;
using System.Data.SqlClient;
using YingNet.Common;
using YingNet.WeiXing.DB.Data;


namespace YingNet.WeiXing.DB
{

	/// <summary>
	/// DepinfoDT的摘要说明。
	/// <summary>

	public class YingInfoTypeDB:DBAccess
	{

		/// <summary>
		///  按结构取值
		/// <summary>
		/// <param name='dr'>SqlDataReader</param>
		/// <param name='obj'>数据结构对象</param>
		/// <returns>数据结构对象</returns>
		public override object ConvertItem( SqlDataReader dr)
		{
			YingInfoTypeDT dt = new YingInfoTypeDT();
			dt.Has_Sub= Convert.ToBoolean(dr["Has_Sub"]);
			dt.id= Convert.ToInt32(dr["id"]);
			dt.Num= Convert.ToString(dr["Num"]);
			dt.TypeName= Convert.ToString(dr["TypeName"]);
			dt.Parent= Convert.ToString(dr["Parent"]);
			return dt;
		}

		/// <summary>
		///  组织参数列表
		/// <summary>
		/// <param name='obj'>数据结构对象</param>
		/// <returns>参数列表</returns>
		public override SqlParameter[] GetParameter( object obj )
		{
			YingInfoTypeDT dt = (YingInfoTypeDT)obj;
			SqlParameter[] prams =
			{
				MakeInParam("@Has_Sub" ,SqlDbType.Bit,1,dt.Has_Sub),
				MakeInParam("@id" ,SqlDbType.Int,4,dt.id),
				MakeInParam("@Num" ,SqlDbType.NVarChar,240,dt.Num),
				MakeInParam("@TypeName" ,SqlDbType.NVarChar,300,dt.TypeName),
				MakeInParam("@Parent" ,SqlDbType.NVarChar,240,dt.Parent)
			};
			return prams;
		}
		
		public YingInfoTypeDT GetOneDT(int id)
		{
			return (YingInfoTypeDT)GetOneItem(id);
		}	
		
		public YingInfoTypeDT GetByNum( string s )
		{
			return (YingInfoTypeDT)GetOneItem(s);
		}

		public virtual object GetOneItem( string num)
		{
			object dt = null;
			SqlDataReader dr = null;
			Open();
			try 
			{
				dr = RunSqlString("Select * from YingInfoType where num='"+num+"'");

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

		public bool Del( string num)
		{
			
			Open();
			try 
			{
				int i = SqlHelper.ExecuteNonQuery(oConn,CommandType.Text, "DELETE FROM YingInfoType where num='"+num+"'");
				if ( i == 1)
				{
					Close();
					return true;
				}
				else
				{
					Close();
					return false;
				}
			}
			catch(SqlException e)
			{
				return false;
			}

		}

		public bool ISHasSub( string num)
		{
			
			Open();
			try 
			{
				DataTable dt = RunSqlString("select id FROM YingInfo where InfoTypeNo like '"+num+"%'","t");
				if ( dt.Rows.Count > 0)
				{
					Close();
					return true;
				}
				else
				{
					Close();
					return false;
				}
			}
			catch(SqlException e)
			{
				return false;
			}

		}
		public bool ISHasDel( string num)
		{
			
			Open();
			try 
			{
				DataTable dt = RunSqlString("select id FROM YingInfoType where Num like '"+num+"%'","t");
				if ( dt.Rows.Count > 1)
				{
					Close();
					return true;
				}
				else
				{
					Close();
					return false;
				}
			}
			catch(SqlException e)
			{
				return false;
			}

		}
		public DataTable GetList()
		{
			return RunSqlString("SELECT id, Num, TypeName, Parent, Has_Sub FROM YingInfoType ORDER BY Num" ,"data");
		}
		
		public DataTable GetList(string parentid)
		{
			return RunSqlString("SELECT id, Num, TypeName, Parent, Has_Sub FROM YingInfoType where [Parent]='"+parentid+"'  ORDER BY Num" ,"data");
		}
	}
}
