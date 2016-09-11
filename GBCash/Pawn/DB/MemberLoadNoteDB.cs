using System;
using System.Data;
using System.Data.SqlClient;
using YingNet.Common;
using YingNet.WeiXing.DB.Data;

namespace YingNet.WeiXing.DB
{
	/// <summary>
	/// MemberLoadNoteDB 的摘要说明。
	/// </summary>
	public class MemberLoadNoteDB : DBAccess
	{

		/// <summary>
		///  按结构取值
		/// <summary>
		/// <param name='dr'>SqlDataReader</param>
		/// <param name='obj'>数据结构对象</param>
		/// <returns>数据结构对象</returns>
		public override object ConvertItem( SqlDataReader dr)
		{
			MemberLoadNoteDT dt = new MemberLoadNoteDT();
			dt.ExtendedNames= Convert.ToString(dr["ExtendedNames"]);
			dt.ExtendedValues= Convert.ToString(dr["ExtendedValues"]);
			dt.MemberID= Convert.ToInt32(dr["MemberID"]);
			dt.NodeDesc= Convert.ToString(dr["NodeDesc"]);
			dt.NodeOrder= Convert.ToInt32(dr["NodeOrder"]);
			dt.NodeStatus= Convert.ToInt32(dr["NodeStatus"]);
			dt.NoteContent= Convert.ToString(dr["NoteContent"]);
			dt.NoteID= Convert.ToInt32(dr["NoteID"]);

			return dt;
		}

		/// <summary>
		///  组织参数列表
		/// <summary>
		/// <param name='obj'>数据结构对象</param>
		/// <returns>参数列表</returns>
		public override SqlParameter[] GetParameter( object obj )
		{
			MemberLoadNoteDT dt = (MemberLoadNoteDT)obj;
			SqlParameter[] prams =
			{
				MakeInParam("@ExtendedNames",SqlDbType.NVarChar,4000,dt.ExtendedNames),
				MakeInParam("@ExtendedValues",SqlDbType.NVarChar,4000,dt.ExtendedValues),
				MakeInParam("@MemberID",SqlDbType.Int,4,dt.MemberID),
				MakeInParam("@NodeDesc",SqlDbType.NVarChar,4000,dt.NodeDesc),
				MakeInParam("@NoteContent",SqlDbType.NVarChar,4000,dt.NoteContent),
				MakeInParam("@NodeOrder",SqlDbType.Int,4,dt.NodeOrder),
				MakeInParam("@NodeStatus",SqlDbType.Int,4,dt.NodeStatus),
				MakeInParam("@NoteID",SqlDbType.Int,4,dt.NoteID)
			};
			return prams;
		}
		public new MemberLoadNoteDT GetOneItem(int noteID)
		{
			MemberLoadNoteDT dt= null;
			SqlDataReader dr = null;
			try 
			{	
				string commandString= " select * from [MemberLoadNote] where NoteID=@NoteID;";
				SqlParameter[] prams ={MakeInParam("@NoteID",SqlDbType.Int,4,noteID)};
				dr= SqlHelper.ExecuteReader(Common.Config.DataSource,CommandType.Text,commandString,prams);
				
				if ( dr.Read())
				{
					dt = (MemberLoadNoteDT)ConvertItem(dr);
				}
				else
				{
					dt = null;
				}
				dr.Close();
			}
			catch(Exception ex)
			{
				throw ex;
			}
			return (MemberLoadNoteDT)dt;
		}

		public MemberLoadNoteDT GetOneItemByMemberID(int memberID)
		{
			MemberLoadNoteDT dt= null;
			SqlDataReader dr = null;
			try 
			{	
				string commandString= " select * from [MemberLoadNote] where MemberID=@MemberID;";
				SqlParameter[] prams ={MakeInParam("@MemberID",SqlDbType.Int,4,memberID)};
				dr= SqlHelper.ExecuteReader(Common.Config.DataSource,CommandType.Text,commandString,prams);
				
				if ( dr.Read())
				{
					dt = (MemberLoadNoteDT)ConvertItem(dr);
				}
				else
				{
					dt = null;
				}
				dr.Close();
			}
			catch(Exception ex)
			{
				throw ex;
			}
			return (MemberLoadNoteDT)dt;
		}

		public new int Insert(object ob)
		{
			int identity=-1;
			try 
			{
				string commandString= " insert into [MemberLoadNote] (NodeStatus,NodeOrder,NoteContent,NodeDesc,MemberID,ExtendedValues,ExtendedNames) values (@NodeStatus,@NodeOrder,@NoteContent,@NodeDesc,@MemberID,@ExtendedValues,@ExtendedNames);";
				//commandString+= " select @@identity ";
				SqlHelper.ExecuteScalar(Common.Config.DataSource,CommandType.Text,commandString,GetParameter(ob));
			}
			catch(Exception ex)
			{
				throw ex;
			}
			return 0;
		}

		public override bool Update(object ob)
		{
			try 
			{
				string commandString= " update [MemberLoadNote] set NodeStatus=@NodeStatus,NodeOrder=@NodeOrder,NoteContent=@NoteContent,NodeDesc=@NodeDesc,MemberID=@MemberID,ExtendedValues=@ExtendedValues,ExtendedNames=@ExtendedNames Where NoteID=@NoteID";
				SqlHelper.ExecuteScalar(Common.Config.DataSource,CommandType.Text,commandString,GetParameter(ob));
			}
			catch(Exception ex)
			{
				throw ex;
			}
			return true;
		}
	}
}
