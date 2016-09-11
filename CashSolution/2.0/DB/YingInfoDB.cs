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

	public class YingInfoDB:DBAccess
	{

		/// <summary>
		///  按结构取值
		/// <summary>
		/// <param name='dr'>SqlDataReader</param>
		/// <param name='obj'>数据结构对象</param>
		/// <returns>数据结构对象</returns>
		public override object ConvertItem( SqlDataReader dr)
		{
			YingInfoDT dt = new YingInfoDT();
			dt.InfoIsTop= Convert.ToBoolean(dr["InfoIsTop"]);
			dt.InfoPubDate= Convert.ToDateTime(dr["InfoPubDate"]);
			dt.InfoID= Convert.ToInt32(dr["InfoID"]);
			dt.InfoTitle= Convert.ToString(dr["InfoTitle"]);
			dt.ImgPath= Convert.ToString(dr["ImgPath"]);
			dt.InfoTypeNo= Convert.ToString(dr["InfoTypeNo"]);
			dt.InfoContent= Convert.ToString(dr["InfoContent"]);
			return dt;
		}

		/// <summary>
		///  组织参数列表
		/// <summary>
		/// <param name='obj'>数据结构对象</param>
		/// <returns>参数列表</returns>
		public override SqlParameter[] GetParameter( object obj )
		{
			YingInfoDT dt = (YingInfoDT)obj;
			SqlParameter[] prams =
			{
				MakeInParam("@InfoIsTop" ,SqlDbType.Bit,1,dt.InfoIsTop),
				MakeInParam("@InfoPubDate" ,SqlDbType.DateTime,8,dt.InfoPubDate),
				MakeInParam("@InfoID" ,SqlDbType.Int,4,dt.InfoID),
				MakeInParam("@InfoTitle" ,SqlDbType.NVarChar,800,dt.InfoTitle),
				MakeInParam("@ImgPath" ,SqlDbType.NVarChar,600,dt.ImgPath),
				MakeInParam("@InfoTypeNo" ,SqlDbType.NVarChar,240,dt.InfoTypeNo),
				MakeInParam("@InfoContent" ,SqlDbType.NText,0,dt.InfoContent)
			};
			return prams;
		}
		public YingInfoDT GetOneDT(int id)
		{
			return (YingInfoDT)GetOneItem(id);
		}
	
		public override SqlParameter[] GetParameter(int id)
		{
			// TODO:  添加 YingInfoDB.GetParameter 实现
			SqlParameter[] prams =
			{
				MakeInParam("@InfoID" ,SqlDbType.Int,4,id),
			};
			return prams;
		}
		public DataTable GetList()
		{
			return RunSqlString("SELECT InfoID, InfoTitle,InfoContent, InfoIsTop, InfoTypeNo,ImgPath, InfoPubDate FROM YingInfo ORDER BY InfoPubDate DESC" ,"data");
		}

	}
}
