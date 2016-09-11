using System;
using YingNet.Serialization;

namespace YingNet.WeiXing.DB.Data
{
	/// <summary>
	/// CSProcessCenterDT 的摘要说明。
	/// </summary>
	public class CSProcessCenterDT: ExtendedAttributes 
	{
		public CSProcessCenterDT()
		{
			//
			// TODO: 在此处添加构造函数逻辑
			//
		}
		
		#region Private Column
		private System.Int32 processID;
		private System.Int32 userID;
		private UserLoanTypes userLoanType;
		private System.Boolean isFirstLoan;
		private ProcessCenterStatusEnum processStatus;
		private System.String conversationTrack=string.Empty;
		private System.String task=string.Empty;
		private System.String documentRequired= string.Empty;
		private System.DateTime postDate;
		private System.Int32 lastOperateUserID=0;
		private System.DateTime lastOperateDate;
		private System.Int32 loanID=0;
		private InformationAlertStates processOther1=0;
		private System.Int32 processOther2=0;
		private System.String processOther3=string.Empty;
		private System.String processOther4=string.Empty;
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
		
		public System.Boolean IsFirstLoan
		{
			get
			{
				return this.isFirstLoan;
			}
			set
			{
				this.isFirstLoan = value;
			}
		}
		
		public ProcessCenterStatusEnum ProcessStatus
		{
			get
			{
				return this.processStatus;
			}
			set
			{
				this.processStatus = value;
			}
		}
		
		public System.String ConversationTrack
		{
			get
			{
				return this.conversationTrack;
			}
			set
			{
				this.conversationTrack = value;
			}
		}
		
		public System.String Task
		{
			get
			{
				return this.task;
			}
			set
			{
				this.task = value;
			}
		}
		
		public System.String DocumentRequired
		{
			get
			{
				return this.documentRequired;
			}
			set
			{
				this.documentRequired = value;
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
		

		public System.Int32 LoanID
		{
			get
			{
				return this.loanID;
			}
			set
			{
				this.loanID = value;
			}
		}
		
		/// <summary>
		/// 当前信息最后设定的状态是否提醒过
		/// </summary>
		public InformationAlertStates CurrentStateIsAlerted
		{
			get
			{
				return this.processOther1;
			}
			set
			{
				this.processOther1 = value;
			}
		}
		
		public System.Int32 ProcessOther2
		{
			get
			{
				return this.processOther2;
			}
			set
			{
				this.processOther2 = value;
			}
		}
		
		public System.String ProcessOther3
		{
			get
			{
				return this.processOther3;
			}
			set
			{
				this.processOther3 = value;
			}
		}
		
		public System.String ProcessOther4
		{
			get
			{
				return this.processOther4;
			}
			set
			{
				this.processOther4 = value;
			}
		}
		#endregion
		
		
		#region 扩展属性
		/// <summary>
		/// 显示的处理状态(其跟具体的状态可能不同,比如可能很多个具体的状态对应一个显示状态)
		/// </summary>
		public string ProcessStatusDisplay
		{
			get
			{
				string val= GetExtendedAttribute("ProcessStatusDisplay");
				return val;
			}
			set
			{
				SetExtendedAttribute("ProcessStatusDisplay",value);
			}
		}

		public DetailsVerificationStatusEnum DetailsVerificationStatus
		{
			get
			{
				string val = GetExtendedAttribute("DetailsVerificationStatus");
				if (val != string.Empty)
				{
					return (DetailsVerificationStatusEnum)Convert.ToInt32(val);
				}
				else
				{
					return DetailsVerificationStatusEnum.Pending;
				}
			}
			set { SetExtendedAttribute("DetailsVerificationStatus", Convert.ToInt32(value).ToString()); }
		}
		
		
		public DocumentCheckListStatusEnum DocumentCheckListStatus
		{
			get
			{
				string val = GetExtendedAttribute("DocumentCheckListStatus");
				if (val != string.Empty)
				{
					return (DocumentCheckListStatusEnum)Convert.ToInt32(val);
				}
				else
				{
					return DocumentCheckListStatusEnum.Incomplete;
				}
			}
			set { SetExtendedAttribute("DocumentCheckListStatus", Convert.ToInt32(value).ToString()); }
		}
		
		public DocumentRequiredStatusEnum DocumentRequiredStatus
		{
			get
			{
				string val = GetExtendedAttribute("DocumentRequiredStatus");
				if (val != string.Empty)
				{
					return (DocumentRequiredStatusEnum)Convert.ToInt32(val);
				}
				else
				{
					return DocumentRequiredStatusEnum.Pending;
				}
			}
			set { SetExtendedAttribute("DocumentRequiredStatus", Convert.ToInt32(value).ToString()); }
		}
		
		public bool IsDocumentMasterLoanAgreemnet
		{
			get
			{
				string val = GetExtendedAttribute("IsDocumentMasterLoanAgreemnet");
				if (val != string.Empty)
				{
					return Convert.ToBoolean(val);
				}
				else
				{
					return false;
				}
			}
			set { SetExtendedAttribute("IsDocumentMasterLoanAgreemnet", value.ToString()); }
		}
		
		public bool IsDocumentDirectDebitRequest
		{
			get
			{
				string val = GetExtendedAttribute("IsDocumentDirectDebitRequest");
				if (val != string.Empty)
				{
					return Convert.ToBoolean(val);
				}
				else
				{
					return false;
				}
			}
			set { SetExtendedAttribute("IsDocumentDirectDebitRequest", value.ToString()); }
		}
		
		public bool IsDocumentPaySlip
		{
			get
			{
				string val = GetExtendedAttribute("IsDocumentPaySlip");
				if (val != string.Empty)
				{
					return Convert.ToBoolean(val);
				}
				else
				{
					return false;
				}
			}
			set { SetExtendedAttribute("IsDocumentPaySlip", value.ToString()); }
		}
		
		public bool IsDocumentBankStatement
		{
			get
			{
				string val = GetExtendedAttribute("IsDocumentBankStatement");
				if (val != string.Empty)
				{
					return Convert.ToBoolean(val);
				}
				else
				{
					return false;
				}
			}
			set { SetExtendedAttribute("IsDocumentBankStatement", value.ToString()); }
		}
		
		public bool IsDocumentID
		{
			get
			{
				string val = GetExtendedAttribute("IsDocumentID");
				if (val != string.Empty)
				{
					return Convert.ToBoolean(val);
				}
				else
				{
					return false;
				}
			}
			set { SetExtendedAttribute("IsDocumentID", value.ToString()); }
		}
		
		public bool IsDocumentUtilityBill
		{
			get
			{
				string val = GetExtendedAttribute("IsDocumentUtilityBill");
				if (val != string.Empty)
				{
					return Convert.ToBoolean(val);
				}
				else
				{
					return false;
				}
			}
			set { SetExtendedAttribute("IsDocumentUtilityBill", value.ToString()); }
		}
		#endregion
	}
}
