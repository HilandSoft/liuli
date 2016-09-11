using System;

namespace YingNet.WeiXing.DB.Data
{
	/// <summary>
	/// ProcessCenter状态
	/// </summary>
	public enum ProcessCenterStatusEnum
	{
		Pending=0,
		PreApproval=10,
		PreApproved=20,
		DetailVerified=30,
		FinalApproval=40,
	}

	/// <summary>
	/// FollowupCenter的状态
	/// </summary>
	public enum FollowupCenterStatusEnum
	{
		NoStatus=-1,
		FollowupEveryday=0,
		FollowupByDate=10,
		ScheduledPayment=20,
		ReDDed=30,
		DefaultLetter=40,
		FinalNotice=50,
		Collection=60,
		OnHold=70,
		Part9AwaitingResult=80,
		Part9AwaitingDividends=90,
		BlackList= 100,
	}
	
	/// <summary>
	/// ProcessCenter中 客户提交文档检测的状态
	/// </summary>
	public enum DocumentCheckListStatusEnum
	{
		Incomplete=0,
		Checked=1,
	}
	
	/// <summary>
	/// 所需文档的收到状态
	/// </summary>
	public enum DocumentRequiredStatusEnum
	{
		Pending=0,
		Received=1,
		NoDocumnetRequired=2,
	}
	
	/// <summary>
	/// ProcessCenter中 客户具体信息检测的状态
	/// </summary>
	public enum DetailsVerificationStatusEnum
	{
		Pending=0,
		Done=1,
	}
	
	public enum UserLoanTypes
	{
		/// <summary>
		/// 短期贷款
		/// </summary>
		Short=0,
		/// <summary>
		/// 长期贷款
		/// </summary>
		Long=1,
	}
	
	/// <summary>
	/// 提醒信息的读取状态
	/// </summary>
	public enum InformationAlertStates
	{
		UnRead=0,
		Readed=1,
	}
}
