using System;
using System.Data;
using YingNet.Common;
using YingNet.WeiXing.DB;
using YingNet.WeiXing.DB.Data;

namespace YingNet.WeiXing.Business
{
	/// <summary>
	/// InfoTree 的摘要说明。
	/// </summary>
	public class InfoTypeTree:ZKR_Nodes
	{
		public InfoTypeTree(NodeClass rootClass):base(rootClass)
		{
			//
			// TODO: 在此处添加构造函数逻辑
			//
		}

		public override NodeClass getTreeNode(string url, string target, bool hascheckbox)
		{
			YingInfoTypeDB db=new YingInfoTypeDB();
			YingInfoTypeDT dt=new YingInfoTypeDT();
			DataTable dtInfoType=db.GetList("001");
			if(dtInfoType!=null)
			{
				foreach(DataRow dr1 in dtInfoType.Rows) 
				{
					NodeClass n1=new NodeClass(dr1[2].ToString(),dr1[1].ToString(),url+"?InfoTypeID="+dr1[1].ToString(),target,hascheckbox);
					//创建二级结点及各子结点
					nodeTreeD(n1,n1.data,url,target,hascheckbox);
					this.rootClass.addNode(n1);
				}
			}
			db=null;
			dt=null;
			return this.rootClass ;
		}

		private void nodeTreeD(NodeClass currentNode,string currentparentID,string url,string target,bool hascheckbox)
		{
			YingInfoTypeDB db=new YingInfoTypeDB();
			YingInfoTypeDT dt=new YingInfoTypeDT();
			DataTable dtInfoType=db.GetList(currentparentID);
			if(dtInfoType!=null)
			{
				foreach(DataRow dr1 in dtInfoType.Rows) 
				{
					NodeClass n1=new NodeClass(dr1[2].ToString(),dr1[1].ToString(),url+"?InfoTypeID="+dr1[1].ToString(),target,hascheckbox);
					currentNode.addNode(n1);
					nodeTreeD(n1,n1.data,url,target,hascheckbox);
				}
			}
			else{return;}
		}

	}
}
