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

	public class ProductTypeDB:DBAccess
	{

		/// <summary>
		///  按结构取值
		/// <summary>
		/// <param name='dr'>SqlDataReader</param>
		/// <param name='obj'>数据结构对象</param>
		/// <returns>数据结构对象</returns>
		public override object ConvertItem( SqlDataReader dr)
		{
			ProductTypeDT dt = new ProductTypeDT();
			dt.Has_Sub= Convert.ToBoolean(dr["Has_Sub"]);
			dt.id= Convert.ToInt32(dr["id"]);
			dt.ImgPath= Convert.ToString(dr["ImgPath"]);
			dt.num= Convert.ToString(dr["num"]);
			dt.TypeName= Convert.ToString(dr["TypeName"]);
			dt.Parent= Convert.ToString(dr["Parent"]);
			dt.TypeInfo= Convert.ToString(dr["TypeInfo"]);
			return dt;
		}

		/// <summary>
		///  组织参数列表
		/// <summary>
		/// <param name='obj'>数据结构对象</param>
		/// <returns>参数列表</returns>
		public override SqlParameter[] GetParameter( object obj )
		{
			ProductTypeDT dt = (ProductTypeDT)obj;
			SqlParameter[] prams =
			{
				MakeInParam("@Has_Sub" ,SqlDbType.Bit,1,dt.Has_Sub),
				MakeInParam("@id" ,SqlDbType.Int,4,dt.id),
				MakeInParam("@ImgPath" ,SqlDbType.NVarChar,600,dt.ImgPath),
				MakeInParam("@num" ,SqlDbType.NVarChar,240,dt.num),
				MakeInParam("@TypeName" ,SqlDbType.NVarChar,300,dt.TypeName),
				MakeInParam("@Parent" ,SqlDbType.NVarChar,240,dt.Parent),
				MakeInParam("@TypeInfo" ,SqlDbType.Text,0,dt.TypeInfo)
			};
			return prams;
		}
		public ProductTypeDT GetOneDT(int id)
		{
			return (ProductTypeDT)GetOneItem(id);
		}

		public ProductTypeDT GetByNum( string s )
		{
			return (ProductTypeDT)GetOneItem(s);
		}

		public virtual object GetOneItem( string num)
		{
			object dt = null;
			SqlDataReader dr = null;
			Open();
			try 
			{
				dr = RunSqlString("Select * from ProductType where num='"+num+"'");

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
				int i = SqlHelper.ExecuteNonQuery(oConn,CommandType.Text, "DELETE FROM ProductType where num='"+num+"'");
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
				DataTable dt = RunSqlString("select id FROM Product where ProductTypeNo like '"+num+"%'","t");
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
				DataTable dt = RunSqlString("select id FROM ProductType where Num like '"+num+"%'","t");
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
			return RunSqlString("SELECT id, num, TypeName, Parent, Has_Sub,SUBSTRING(TypeInfo, 0, 100) as TypeInfo,ImgPath FROM ProductType ORDER BY num" ,"data");
		}
		
		public DataTable GetList(string parentid)
		{
			return RunSqlString("SELECT id, num, TypeName, Parent, Has_Sub,SUBSTRING(TypeInfo, 0, 100) as TypeInfo,ImgPath FROM ProductType where [Parent]='"+parentid+"'   ORDER BY num" ,"data");
		}
	}
}
