using System;

namespace YingNet.Common 
{
	/// <summary>
	/// 用户功能操作的类型
	/// </summary>
	/// <remarks>也许某个用户可能对自己的数据拥有1248等权限,但是不能对其他的用户拥有这个权限;那么管理员16,就有所有人的数据权限</remarks>
	[Flags] 
	public enum CommonOperateEnum
	{
		List=1,
		ReadOnly=2,
		CreateEdit=4,
		Delete=8,
		Manage=16,
		
		/* 
		 *以下信息在ProcessCenter中使用 
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