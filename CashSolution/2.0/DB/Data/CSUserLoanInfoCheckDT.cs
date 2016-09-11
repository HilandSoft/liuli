using System;
using YingNet.Serialization;

namespace YingNet.WeiXing.DB.Data
{
	/// <summary>
	/// CSUserLoanInfoCheckDT 的摘要说明。
	/// </summary>
	public class CSUserLoanInfoCheckDT: ExtendedAttributes 
	{
		public CSUserLoanInfoCheckDT()
		{
			//
			// TODO: 在此处添加构造函数逻辑
			//
		}
		
		#region Private Column
		private System.Int32 processID;
		private System.Int32 userID;
		private UserLoanTypes userLoanType;
		private System.String employerName;
		private System.String employerAddress;
		private System.String employerTelephone;
		private System.String workTelephone;
		private System.String homeTelephone;
		private System.Int32 employmentStatus;
		private System.String jobTitle;
		private System.String timeEmployed;
		private System.Decimal takeHomePayAfterTaxes;
		private System.String payFrequency;
		private System.DateTime nextPayday;
		private System.Int32 checkOther1;
		private System.Int32 checkOther2;
		private System.String checkOther3;
		private System.String checkOther4;
		#endregion
		
		#region public - Property
		public System.Int32 ProcessID
		{
			get
			{
				return this.processID;
			}
			set
			{
				this.processID = value;
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
		
		public System.String EmployerName
		{
			get
			{
				return this.employerName;
			}
			set
			{
				this.employerName = value;
			}
		}
		
		public System.String EmployerAddress
		{
			get
			{
				return this.employerAddress;
			}
			set
			{
				this.employerAddress = value;
			}
		}
		
		public System.String EmployerTelephone
		{
			get
			{
				return this.employerTelephone;
			}
			set
			{
				this.employerTelephone = value;
			}
		}
		
		public System.String WorkTelephone
		{
			get
			{
				return this.workTelephone;
			}
			set
			{
				this.workTelephone = value;
			}
		}
		
		public System.String HomeTelephone
		{
			get
			{
				return this.homeTelephone;
			}
			set
			{
				this.homeTelephone = value;
			}
		}
		
		//目前暂不使用这个属性,而是使用EmploymentStatusText
		public System.Int32 EmploymentStatus
		{
			get
			{
				return this.employmentStatus;
			}
			set
			{
				this.employmentStatus = value;
			}
		}

		public string EmploymentStatusText
		{
			get
			{
				string val= GetExtendedAttribute("EmploymentStatusText");
				return val;
			}
			set
			{
				SetExtendedAttribute("EmploymentStatusText",value);
			}
		}
		
		public System.String JobTitle
		{
			get
			{
				return this.jobTitle;
			}
			set
			{
				this.jobTitle = value;
			}
		}
		
		public System.String TimeEmployed
		{
			get
			{
				return this.timeEmployed;
			}
			set
			{
				this.timeEmployed = value;
			}
		}
		
		public System.Decimal TakeHomePayAfterTaxes
		{
			get
			{
				return this.takeHomePayAfterTaxes;
			}
			set
			{
				this.takeHomePayAfterTaxes = value;
			}
		}
		
		public System.String PayFrequency
		{
			get
			{
				return this.payFrequency;
			}
			set
			{
				this.payFrequency = value;
			}
		}
		
		public System.DateTime NextPayday
		{
			get
			{
				return this.nextPayday;
			}
			set
			{
				this.nextPayday = value;
			}
		}
		
		public System.Int32 CheckOther1
		{
			get
			{
				return this.checkOther1;
			}
			set
			{
				this.checkOther1 = value;
			}
		}
		
		public System.Int32 CheckOther2
		{
			get
			{
				return this.checkOther2;
			}
			set
			{
				this.checkOther2 = value;
			}
		}
		
		public System.String CheckOther3
		{
			get
			{
				return this.checkOther3;
			}
			set
			{
				this.checkOther3 = value;
			}
		}
		
		public System.String CheckOther4
		{
			get
			{
				return this.checkOther4;
			}
			set
			{
				this.checkOther4 = value;
			}
		}
		
		#endregion
	}
}
