using System;
using YingNet.Serialization;

namespace YingNet.WeiXing.DB.Data
{
	/// <summary>
	/// CSUserPermissionDT 的摘要说明。
	/// </summary>
	public class CSUserPermissionDT: ExtendedAttributes 
	{
		public CSUserPermissionDT()
		{
			//
			// TODO: 在此处添加构造函数逻辑
			//
		}
		
		#region Private Column
		private System.Int32 userID;
		private System.Int32 permissionOther1;
		private System.Int32 permissionOther2;
		private System.String permissionOther3;
		private System.String permissionOther4;
		#endregion
		
		#region public - Property
		public System.Int32 UserID
		{
			get
			{
				return this.userID;
			}
			set
			{
				this.userID = value;
			}
		}
		
		public System.Int32 PermissionOther1
		{
			get
			{
				return this.permissionOther1;
			}
			set
			{
				this.permissionOther1 = value;
			}
		}
		
		public System.Int32 PermissionOther2
		{
			get
			{
				return this.permissionOther2;
			}
			set
			{
				this.permissionOther2 = value;
			}
		}
		
		public System.String PermissionOther3
		{
			get
			{
				return this.permissionOther3;
			}
			set
			{
				this.permissionOther3 = value;
			}
		}
		
		public System.String PermissionOther4
		{
			get
			{
				return this.permissionOther4;
			}
			set
			{
				this.permissionOther4 = value;
			}
		}
		
		#endregion
		
		#region 可以扩属性
		public int PermissionProcessCenter
		{
			get
			{
				string val = GetExtendedAttribute("ProcessCenter");
				if (val != string.Empty)
				{
					return Convert.ToInt32(val);
				}
				else
				{
					return 0;
				}
			}
			set { SetExtendedAttribute("ProcessCenter", value.ToString()); }
		}
		
		public int PermissionManagerInfo
		{
			get
			{
				string val = GetExtendedAttribute("ManagerInfo");
				if (val != string.Empty)
				{
					return Convert.ToInt32(val);
				}
				else
				{
					return 0;
				}
			}
			set { SetExtendedAttribute("ManagerInfo", value.ToString()); }
		}
		
		public int PermissionFollowupCenter
		{
			get
			{
				string val = GetExtendedAttribute("FollowupCenter");
				if (val != string.Empty)
				{
					return Convert.ToInt32(val);
				}
				else
				{
					return 0;
				}
			}
			set { SetExtendedAttribute("FollowupCenter", value.ToString()); }
		}
		
		public int PermissionPaydayInfo
		{
			get
			{
				string val = GetExtendedAttribute("PaydayInfo");
				if (val != string.Empty)
				{
					return Convert.ToInt32(val);
				}
				else
				{
					return 0;
				}
			}
			set { SetExtendedAttribute("PaydayInfo", value.ToString()); }
		}
		
		public int PermissionLProcessCenter
		{
			get
			{
				string val = GetExtendedAttribute("LProcessCenter");
				if (val != string.Empty)
				{
					return Convert.ToInt32(val);
				}
				else
				{
					return 0;
				}
			}
			set { SetExtendedAttribute("LProcessCenter", value.ToString()); }
		}
		
		public int PermissionLFollowupCenter
		{
			get
			{
				string val = GetExtendedAttribute("LFollowupCenter");
				if (val != string.Empty)
				{
					return Convert.ToInt32(val);
				}
				else
				{
					return 0;
				}
			}
			set { SetExtendedAttribute("LFollowupCenter", value.ToString()); }
		}
		#endregion
	}
}
