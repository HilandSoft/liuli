using System;

namespace YingNet.WeiXing.DB.Data
{
	/// <summary>
	/// MemberLoadNoteDT 的摘要说明。
	/// </summary>
	public class MemberLoadNoteDT
	{
		private int noteID;
		/// <summary>
		/// 注释ID
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
		/// 会员的ID
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
		/// 备注内容
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
		/// 描述(备用)
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
		/// 排序(备用)
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
		/// 状态(备用)
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
		/// 可扩展字段名称(备用)
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
		/// 可扩展字段值(备用)
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
