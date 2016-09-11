using System;
using YingNet.Serialization;

namespace YingNet.WeiXing.DB.Data
{
	/// <summary>
	/// CSUserDT 的摘要说明。
	/// </summary>
	public class CSUserDT: ExtendedAttributes 
	{
		public CSUserDT()
		{
			//
			// TODO: 在此处添加构造函数逻辑
			//
		}
		
		#region Private Column
		private System.Int32 userID;
		private System.String userName;
		private System.String password;
		private System.String passwordSalt;
		private System.Int32 passwordFormat;
		private System.String nickname;
		private System.String email;
		private System.Int32 userType;
		private System.Int32 userRank;
		private System.String userClass;
		private System.DateTime dateCreated;
		private System.DateTime lastLoginDate;
		private System.Int32 enable;
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
		
		public System.String UserName
		{
			get
			{
				return this.userName;
			}
			set
			{
				this.userName = value;
			}
		}
		
		public System.String Password
		{
			get
			{
				return this.password;
			}
			set
			{
				this.password = value;
			}
		}
		
		public System.String PasswordSalt
		{
			get
			{
				return this.passwordSalt;
			}
			set
			{
				this.passwordSalt = value;
			}
		}
		
		public System.Int32 PasswordFormat
		{
			get
			{
				return this.passwordFormat;
			}
			set
			{
				this.passwordFormat = value;
			}
		}
		
		public System.String Nickname
		{
			get
			{
				return this.nickname;
			}
			set
			{
				this.nickname = value;
			}
		}
		
		public System.String Email
		{
			get
			{
				return this.email;
			}
			set
			{
				this.email = value;
			}
		}
		
		public System.Int32 UserType
		{
			get
			{
				return this.userType;
			}
			set
			{
				this.userType = value;
			}
		}
		
		public System.Int32 UserRank
		{
			get
			{
				return this.userRank;
			}
			set
			{
				this.userRank = value;
			}
		}
		
		public System.String UserClass
		{
			get
			{
				return this.userClass;
			}
			set
			{
				this.userClass = value;
			}
		}
		
		public System.DateTime DateCreated
		{
			get
			{
				return this.dateCreated;
			}
			set
			{
				this.dateCreated = value;
			}
		}
		
		public System.DateTime LastLoginDate
		{
			get
			{
				return this.lastLoginDate;
			}
			set
			{
				this.lastLoginDate = value;
			}
		}
		
		public System.Int32 Enable
		{
			get
			{
				return this.enable;
			}
			set
			{
				this.enable = value;
			}
		}
		#endregion
	}
}
