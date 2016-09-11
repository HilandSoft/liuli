using System;

namespace YingNet.Common.SSLHelper
{

	///// <summary>
	///// 
	///// </summary>
	//public class SSLSwitchEntity
	//{

	//}


	/// <summary>
	/// SSL��վ��ҳ��Ŀ���ģʽ
	/// </summary>
	public enum ControlModes
	{
		/// <summary>
		/// �������������Ĳ���ʹ��ssl,�������ֲ�ʹ��ssl
		/// </summary>
		OnlyThus,
		/// <summary>
		/// ������������ʹ��ssl(��ɲ�ʹ��)(ȱʡ)
		/// </summary>
		AllowOther,
	}

	/// <summary>
	/// ����վ��ʱ��ҳ��SSL��ģʽ
	/// </summary>
	public enum DeployModes
	{
		/// <summary>
		/// ���Ը������������ʹ��SSL(ȱʡ)
		/// </summary>
		On,
		/// <summary>
		/// ������Զ�̿ͻ�������ʹ��SSL ��վ���𵽷�������ʹ�ô�����
		/// </summary>
		RemoteOnly,
		/// <summary>
		/// ���ص���ʱʹ��
		/// </summary>
		LocalOnly,
		/// <summary>
		/// SSL������
		/// </summary>
		Off,
	}
}
