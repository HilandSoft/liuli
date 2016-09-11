using System;
using System.Data;
using System.Collections;
using Microsoft.Web.UI.WebControls;

namespace YingNet.Common
{
	#region BuildTree�࣬����ָ������������ڵ㴴����
	/// <summary>
	/// ����ָ������������ڵ㴴����
	/// </summary>
	public class BuildTree
	{
	
		/// <summary>
		/// ����ָ������������ڵ㽨��
		/// </summary>
		/// <param name="tv">TreeView</param>
		/// <param name="rootNode">NodeClass</param>
		public BuildTree(TreeView tv,NodeClass rootNode)
		{  
			TreeNode tree1=new TreeNode () ;
			tree1.Text=rootNode.text ;
			tree1.NodeData =rootNode.data ;
			tree1.NavigateUrl =rootNode.url;
			tree1.Target=rootNode.target; 
			tree1.CheckBox =rootNode.hascheckbox ;
			tv.Nodes .Add (tree1);   //���������

			build(tv.Nodes [0],rootNode);  //�����ӽ����
		}
		/// <summary>
		///��������ڵ�ҽ��ӽڵ㣬�ݹ����
		/// </summary>
		/// <param name="treeRootNode">TreeNode</param>
		/// <param name="nc">NodeClass</param>
		private void build(TreeNode treeRootNode,NodeClass nc){	
			if(nc!=null){
				while(nc.hasNode ()){
					TreeNode temp=new TreeNode ();
					NodeClass tempNC=nc.nextNc ();
					temp.Text=tempNC.text ;
					temp.NodeData =tempNC.data ;
					temp.NavigateUrl =tempNC.url ;
					temp.Target =tempNC.target ;
					temp.CheckBox =tempNC.hascheckbox ;
					treeRootNode.Nodes .Add (temp);			
					build(temp,tempNC);
				}
			}else{
				return;
			}
		}
	}
	#endregion ����ָ������������ڵ㴴����

	#region ZKR_Nodes�࣬��ȡ���ڵ㲢����ҽӵ����ڵ���
	/// <summary>
	/// ��ȡ���ڵ㲢����ҽӵ����ڵ���
	/// </summary>
	public  class ZKR_Nodes
	{
		public NodeClass rootClass;

		public ZKR_Nodes(NodeClass rootClass)
		{
			this.rootClass =rootClass;
		}
		/// <summary>
		/// ��ȡ���ڵ㣬���ݲ���url��target���ڵ�����Ը�ֵ��������
		/// </summary>
		/// <param name="url">string</param>
		/// <param name="target">string</param>
		/// <returns>NodeClass</returns>
		public virtual  NodeClass getTreeNode(string url,string target,bool hascheckbox) 
		{
			return this.rootClass ;
		} 
		/*{
				ds=dal1.selectChildren(parentid);
				if(ds!=null){
				 foreach(DataRow dr1 in ds.Tables [0].Rows ){
					direc1.MID  =int.Parse (dr1[0].ToString ());
					direc1.MNAME  =dr1[1].ToString ();
					string data=direc1.MID.ToString () ;
					NodeClass n1=new NodeClass(direc1.MNAME  ,data,url+"?id="+data,target,hascheckbox);
					this.parentid =direc1.MID.ToString () ;
					nodeTreeD(n1,this.parentid ,url,target,hascheckbox);
					this.rootClass .addNode (n1);
				   }
				}
			  return this.rootClass ;
			}*/
	}
	#endregion ��ȡ���ڵ㲢����ҽӵ����ڵ���

	#region NodeClass�࣬���Ľڵ��࣬�洢TreeNode�ڵ���Ϣ
	/// <summary>
	/// ���Ľڵ���
	/// </summary>
	public class NodeClass
	{
		public string text="";//��ʾ�ı�
		public string data="";//����������
		public string url="";//���ӵ�ַ
		public string target="";//��ʾλ��
		public bool hascheckbox=false;//�Ƿ���ʾѡ���
		public ArrayList  nadelist=new ArrayList ();  //�洢�����NodeClass����
		
		private int  indexNc=0;
		public NodeClass(string text,string data,string url,string target,bool hascheckbox)
		{
			this.text=text;
			this.data =data;
			this.url =url;
			this.target =target;
			this.hascheckbox =hascheckbox;
		}
		public void addNode(NodeClass nc)
		{
			nadelist.Add (nc);
		}
		public void removeAt(int index)
		{
			if(0<index && index<this.nadelist.Count)
			{
				this.nadelist .RemoveAt (index);
			}
			
		}
		public bool hasNode()
		{
			return (0<this.nadelist .Count && indexNc<this.nadelist .Count) ;
		}
		public NodeClass nextNc()
		{
			if(this.indexNc <this.nadelist .Count )
			{
				NodeClass temp=(NodeClass)nadelist[this.indexNc];
				this.indexNc ++;
				return temp;
			}
			else
			{
				return null;
			}
		}
	}
	#endregion  NodeClass�࣬���Ľڵ���
}

