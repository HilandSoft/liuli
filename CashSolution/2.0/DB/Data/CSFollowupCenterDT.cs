using System;
using YingNet.Serialization;

namespace YingNet.WeiXing.DB.Data
{
	/// <summary>
	/// CSFollowupCenterDT 的摘要说明。
	/// </summary>
	public class CSFollowupCenterDT: ExtendedAttributes 
	{
		public CSFollowupCenterDT()
		{
			//
			// TODO: 在此处添加构造函数逻辑
			//
		}
		
		#region Private Column
		private System.Int32 followupID;
		private System.Int32 userID;
		private UserLoanTypes userLoanType;
		private FollowupCenterStatusEnum followupStatus;
		private System.String taskInformation;
		private System.Boolean remindEnable;
		private System.DateTime remindDate;
		private System.DateTime remindDate2;
		private System.DateTime remindDate3;
		private System.DateTime postDate;
		private System.Int32 lastOperateUserID;
		private System.DateTime lastOperateDate;
		#endregion
		
		#region public - Property
		public System.Int32 FollowupID
		{
			get
			{
				return this.followupID;
			}
			set
			{
				this.followupID = value;
			}
		}
		
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
		
		public UserLoanTypes UserLoanType
		{
			get
			{
				return this.userLoanType;
			}
			set
			{
				this.userLoanType = value;
			}
		}
		
		public FollowupCenterStatusEnum FollowupStatus
		{
			get
			{
				return this.followupStatus;
			}
			set
			{
				this.followupStatus = value;
			}
		}
		
		public System.String TaskInformation
		{
			get
			{
				return this.taskInformation;
			}
			set
			{
				this.taskInformation = value;
			}
		}
		
		public System.Boolean RemindEnable
		{
			get
			{
				return this.remindEnable;
			}
			set
			{
				this.remindEnable = value;
			}
		}
		
		public System.DateTime RemindDate
		{
			get
			{
				return this.remindDate;
			}
			set
			{
				this.remindDate = value;
			}
		}
		
		public System.DateTime RemindDate2
		{
			get
			{
				return this.remindDate2;
			}
			set
			{
				this.remindDate2 = value;
			}
		}
		
		public System.DateTime RemindDate3
		{
			get
			{
				return this.remindDate3;
			}
			set
			{
				this.remindDate3 = value;
			}
		}
		
		public System.DateTime PostDate
		{
			get
			{
				return this.postDate;
			}
			set
			{
				this.postDate = value;
			}
		}
		
		public System.Int32 LastOperateUserID
		{
			get
			{
				return this.lastOperateUserID;
			}
			set
			{
				this.lastOperateUserID = value;
			}
		}
		
		public System.DateTime LastOperateDate
		{
			get
			{
				return this.lastOperateDate;
			}
			set
			{
				this.lastOperateDate = value;
			}
		}
		#endregion

		#region 可扩展属性
		/// <summary>
		/// 前一个状态
		/// </summary>
		public FollowupCenterStatusEnum PreviewStatus
		{
			get
			{
				string val= GetExtendedAttribute("PreviewStatus");
				if(val==null||val==string.Empty)
				{
					return FollowupCenterStatusEnum.NoStatus;
				}
				else
				{
					return (FollowupCenterStatusEnum)Convert.ToInt32(val);
				}
			}
			set
			{
				SetExtendedAttribute("PreviewStatus",((int)value).ToString());
			}
		}
		#endregion
	}
}
