using System;
using System.Data;
using System.Web.UI;
using YingNet.WeiXing.DB;
using YingNet.WeiXing.DB.Data;

namespace YingNet.WeiXing.Business
{
	/// <summary>
	/// CSProcessCenterBN 的摘要说明。
	/// </summary>
	public class CSProcessCenterBN:BaseLib
	{
		public CSProcessCenterBN(Page page): base(page)
		{
			//
			// TODO: 在此处添加构造函数逻辑
			//
		}
		
		public bool Add( CSProcessCenterDT dt )
		{
			using ( CSProcessCenterDB db = new CSProcessCenterDB() )
			{
				//每次添加或者修改时,都把当前状态的提醒设置为 未读
				dt.CurrentStateIsAlerted = InformationAlertStates.UnRead;
				return db.Insert(dt);
			}
		}

		public bool Del(int id) 		
		{
			using ( CSProcessCenterDB db = new CSProcessCenterDB() )
			{
				return db.Del(id,true,"ProcessID");
			}
		}
		public bool Edit( CSProcessCenterDT dt )
		{
			using ( CSProcessCenterDB db = new CSProcessCenterDB() )
			{
				//每次添加或者修改时,都把当前状态的提醒设置为 未读
				dt.CurrentStateIsAlerted = InformationAlertStates.UnRead;
				return db.Update(dt);
			}
		}

		public bool Edit( CSProcessCenterDT dt,bool isChangeReadStatus )
		{
			using ( CSProcessCenterDB db = new CSProcessCenterDB() )
			{
				if(isChangeReadStatus==true)
				{
					dt.CurrentStateIsAlerted = InformationAlertStates.UnRead;
				}

				return db.Update(dt);
			}
		}
		
		/// <summary>
		/// 更新提醒的状态
		/// </summary>
		/// <param name="id"></param>
		/// <param name="state"></param>
		/// <returns></returns>
		public bool SetAlertState(int id,InformationAlertStates state)
		{
			using ( CSProcessCenterDB db = new CSProcessCenterDB() )
			{
				CSProcessCenterDT entity= db.GetOneItem( id,"ProcessID" ) as CSProcessCenterDT;
				entity.CurrentStateIsAlerted = state;
				return db.Update(entity);
			}
		}
		
		public CSProcessCenterDT Get( int id )
		{
			using ( CSProcessCenterDB db = new CSProcessCenterDB() )
			{
				return db.GetOneItem( id,"ProcessID" ) as CSProcessCenterDT;
			}
		}
		public DataTable GetList ( ) 
		{
			DBFieldList = "*";
			DBTable = "cs_ProcessCenter";
			if(this.Order==null||this.Order==string.Empty)
			{
				this.Order="ProcessID desc";
			}
			return base.CommonGetList();
		}
	}
}
