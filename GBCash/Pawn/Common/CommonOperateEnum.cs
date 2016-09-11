using System;

namespace YingNet.Common 
{
	/// <summary>
	/// �û����ܲ���������
	/// </summary>
	/// <remarks>Ҳ��ĳ���û����ܶ��Լ�������ӵ��1248��Ȩ��,���ǲ��ܶ��������û�ӵ�����Ȩ��;��ô����Ա16,���������˵�����Ȩ��</remarks>
	[Flags] 
	public enum CommonOperateEnum
	{
		List=1,
		ReadOnly=2,
		CreateEdit=4,
		Delete=8,
		Manage=16,
		
		/* 
		 *������Ϣ��ProcessCenter��ʹ�� 
		 */
		DocumentCheckList= 32,
		PreApproval= 64,
		DetailsVerification = 128,
		FinalApproval= 256,
		
		
		
		All= List|ReadOnly|CreateEdit|Delete|Manage,
	}
	
	public enum FunnctionModuleEnum
	{
		None=0,
		ProcessCenter=1,
		FollowupCenter=2,
		ManagerInfo=3,
		PaydayInfo=4,
		
		LProcessCenter=11,
		LFollowupCenter=12,
	}
}