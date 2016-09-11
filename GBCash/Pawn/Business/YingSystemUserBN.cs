/// <copyright>�ൺӢ����Ѷ�������޹�˾  1999-2004</copyright>
/// <version>1.0</version>
/// <author>������</author>
/// <email>jibf@YingNet.com</email>
/// <log date="2004-5-9">����</log>

using System;
using System.Data;
using System.Web.UI;
using YingNet.WeiXing.DB;
using YingNet.WeiXing.DB.Data;
using YingNet.Common;

namespace YingNet.WeiXing.Business
{
	
	/// <summary>
	/// DepinfoDT��ժҪ˵����
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
		#region IDisposable ��Ա

		public void Dispose()
		{
			// TODO:  ��� EmparchivesBN.Dispose ʵ��
		}

		#endregion
	}

}
