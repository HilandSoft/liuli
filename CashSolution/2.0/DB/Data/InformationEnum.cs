using System;

namespace YingNet.WeiXing.DB.Data
{
	/// <summary>
	/// ProcessCenter״̬
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
	/// FollowupCenter��״̬
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
	/// ProcessCenter�� �ͻ��ύ�ĵ�����״̬
	/// </summary>
	public enum DocumentCheckListStatusEnum
	{
		Incomplete=0,
		Checked=1,
	}
	
	/// <summary>
	/// �����ĵ����յ�״̬
	/// </summary>
	public enum DocumentRequiredStatusEnum
	{
		Pending=0,
		Received=1,
		NoDocumnetRequired=2,
	}
	
	/// <summary>
	/// ProcessCenter�� �ͻ�������Ϣ����״̬
	/// </summary>
	public enum DetailsVerificationStatusEnum
	{
		Pending=0,
		Done=1,
	}
	
	public enum UserLoanTypes
	{
		/// <summary>
		/// ���ڴ���
		/// </summary>
		Short=0,
		/// <summary>
		/// ���ڴ���
		/// </summary>
		Long=1,
	}
	
	/// <summary>
	/// ������Ϣ�Ķ�ȡ״̬
	/// </summary>
	public enum InformationAlertStates
	{
		UnRead=0,
		Readed=1,
	}
}
