/// <copyright>青岛英网资讯技术有限公司  1999-2004</copyright>
/// <version>1.0</version>
/// <author>季宝福</author>
/// <email>jibf@YingNet.com</email>
/// <log date="2004-5-9">创建</log>

using System;
using System.Data;
using System.Web.UI;
using YingNet.WeiXing.DB;
using YingNet.WeiXing.DB.Data;
using YingNet.Common;

namespace YingNet.WeiXing.Business
{
	
	/// <summary>
	/// DepinfoDT的摘要说明。
	/// <summary>

	public class YingSystemUserBN:BaseLib,IDisposable
	{
		public YingSystemUserBN(Page page) : base(page)
		{}

		public YingSystemUserDT Get( int id )
		{
			using (YingSystemUserDB db = new YingSystemUserDB())
			{
				return db.GetOneDT(id);
			}
		}
		public bool Add( YingSystemUserDT dt )
		{
			using ( YingSystemUserDB db = new YingSystemUserDB() )
			{
				return db.Insert(dt);
			}
		}
		public bool Del(int id) 		
		{
			using ( YingSystemUserDB db = new YingSystemUserDB() )
			{
				return db.TrueDel(id);
			}
		}
		public bool Edit( YingSystemUserDT dt )
		{
			using ( YingSystemUserDB db = new YingSystemUserDB() )
			{
				return db.Update(dt);
			}
		}

		public YingSystemUserDT GetModel(int id)
		{
			try
			{
				using (YingSystemUserDB db= new YingSystemUserDB())
				{
					return db.GetOneDT(id);
				}
			}
			catch
			{
				return null;
			}
		}
		public DataTable GetList ( ) 
		{
			DBFieldList = "[id],account,password,[name],deptpermit, [name]+'('+Account+')' UserName";
			DBTable = "YingSystemUser";
			Filter = "isactive=1";
			return base.CommonGetList();
		}

		public YingSystemUserDT Login( string strAccount ,string strPassword )
		{
			using ( YingSystemUserDB db = new YingSystemUserDB() )
			{
				return db.Login( strAccount ,strPassword );
			}
		}

		public bool isAccount( string strAccouunt )
		{
			if( strAccouunt!=null && strAccouunt!="")
			{
				Filter=null;
				Filter = "account='"+StringUtils.ToSQL(strAccouunt)+"'";
				DataTable dt =  GetList();
				if (dt.Rows.Count > 0) 
				{
					dt = null;
					return true;
				}
				else
				{
					if (dt!=null)
						dt=null;
					return false;
				}
			}
			else
			{
				return false;
			}

		}
		#region IDisposable 成员

		public void Dispose()
		{
			// TODO:  添加 EmparchivesBN.Dispose 实现
		}

		#endregion
	}

}
