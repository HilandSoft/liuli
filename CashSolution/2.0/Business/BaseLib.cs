using System;
using System.Web.UI;
using System.Collections;
using YingNet.Common;

namespace YingNet.WeiXing.Business
{
	/// <summary>
	/// BaseLib 的摘要说明。
	/// </summary>
	public class BaseLib:CommonBaseLib
	{
		/// <summary>
		/// 用户账号ID
		/// </summary>
		public const string SESSION_USER_UID = "user.uid";
		/// <summary>
		/// 用户账号
		/// </summary>
		public const string SESSION_USER_ACCOUNT = "user.account";

		/// <summary>
		/// 用户姓名
		/// </summary>
		public const string SESSION_USER_NAME = "user.name";
        
		/// <summary>
		/// 用户权限范围(部门名称)
		/// </summary>
		public const string SESSION_USER_DEPT = "user.dept";

		/// <summary>
		/// 用户权限范围(部门ID)
		/// </summary>
		public const string SESSION_USER_DEPTID = "user.deptid";

		/// <summary>
		/// 用户权限
		/// </summary>
		public const string SESSION_USER_PERMIT = "user.permit";

		public const string PARAM_NAME = CommonBasePage.PARAM_NAME;

     
		/// <summary>
		/// web页面
		/// </summary>
		protected Page page = null;

		public BaseLib (Page page) : base() 
		{
			this.page = page;
		}


		private Stack stack = null;
		/// <summary>
		/// 保存当前状态,包括fieldlist,tablename,filter,order,group
		/// </summary>
		public void PushStatus () 
		{
			if (stack == null) 
			{
				stack = new Stack();
			}
			stack.Push(DBFieldList);
			
			stack.Push(DBTable);
			stack.Push(Filter);
			stack.Push(Order);
			stack.Push(Group);
		}

		/// <summary>
		/// 清除当前状态,包括fieldlist,tablename,filter,order,group
		/// </summary>
		public void CleanStatus () 
		{
			DBFieldList = null;
			DBTable = null;
			Filter = null;
			Order = null;
			Group = null;
		}

		/// <summary>
		/// 恢复上一状态,,包括fieldlist,tablename,filter,order,group
		/// </summary>
		public void PopStatus () 
		{
			if (stack != null) 
			{
				object obj = null;
				obj = stack.Pop();
				if (obj != null) 
				{
					DBFieldList = obj.ToString();
				} 
				else 
				{
					DBFieldList = null;
				}
				obj = stack.Pop();
				if (obj != null) 
				{
					DBTable = obj.ToString();
				} 
				else 
				{
					DBTable = null;
				}
				obj = stack.Pop();
				if (obj != null) 
				{
					Filter = obj.ToString();
				} 
				else 
				{
					Filter = null;
				}
				obj = stack.Pop();
				if (obj != null) 
				{
					Order = obj.ToString();
				} 
				else 
				{
					Order = null;
				}
				obj = stack.Pop();
				if (obj != null) 
				{
					Group = obj.ToString();
				} 
				else 
				{
					Group = null;
				}
			}
		}

		private Random random = null;
		/// <summary>
		/// 返回随机数
		/// </summary>
		/// <param name="num"></param>
		/// <returns></returns>
		public int GetRadomNum (int num) 
		{
			if (random == null) 
			{
				random = new Random();
			}
			return random.Next() % num;
		}
	}
}
