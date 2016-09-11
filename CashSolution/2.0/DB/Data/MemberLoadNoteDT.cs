using System;

namespace YingNet.WeiXing.DB.Data
{
	/// <summary>
	/// MemberLoadNoteDT ��ժҪ˵����
	/// </summary>
	public class MemberLoadNoteDT
	{
		private int noteID;
		/// <summary>
		/// ע��ID
		/// </summary>
		public int NoteID
		{
			get
			{
				return noteID;
			}
			set
			{
				noteID= value;
			}
		}

		//MemberID NoteContent NodeDesc NodeOrder NodeStatus
		private int memberID;
		/// <summary>
		/// ��Ա��ID
		/// </summary>
		public int MemberID
		{
			get
			{
				return memberID;
			}
			set
			{
				memberID= value;
			}
		}

		private string noteContent;
		/// <summary>
		/// ��ע����
		/// </summary>
		public string NoteContent
		{
			get
			{
				return noteContent;
			}
			set
			{
				noteContent= value;
			}
		}

		private string nodeDesc;
		/// <summary>
		/// ����(����)
		/// </summary>
		public string NodeDesc
		{
			get
			{
				return nodeDesc;
			}
			set
			{
				nodeDesc= value;
			}
		}

		private int nodeOrder;
		/// <summary>
		/// ����(����)
		/// </summary>
		public int NodeOrder
		{
			get
			{
				return nodeOrder;
			}
			set
			{
				nodeOrder= value;
			}
		}

		private int nodeStatus;
		/// <summary>
		/// ״̬(����)
		/// </summary>
		public int NodeStatus
		{
			get
			{
				return nodeStatus;
			}
			set
			{
				nodeStatus= value;
			}
		}

		private string extendedNames;
		/// <summary>
		/// ����չ�ֶ�����(����)
		/// </summary>
		public string ExtendedNames
		{
			get
			{
				return extendedNames;
			}
			set
			{
				extendedNames= value;
			}
		}

		private string extendedValues;
		/// <summary>
		/// ����չ�ֶ�ֵ(����)
		/// </summary>
		public string ExtendedValues
		{
			get
			{
				return extendedValues;
			}
			set
			{
				extendedValues= value;
			}
		}
	}
}
