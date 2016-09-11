using System;
using System.Data;
using System.Collections;
using Microsoft.Web.UI.WebControls;

namespace YingNet.Common
{
	#region BuildTree类，根据指定的树及其根节点创结树
	/// <summary>
	/// 根据指定的树及其根节点创结树
	/// </summary>
	public class BuildTree
	{
	
		/// <summary>
		/// 根据指定的树及其根节点建树
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
			tv.Nodes .Add (tree1);   //建立根结点

			build(tv.Nodes [0],rootNode);  //建立子结点树
		}
		/// <summary>
		///向各个根节点挂接子节点，递归操作
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
	#endregion 根据指定的树及其根节点创结树

	#region ZKR_Nodes类，获取树节点并将其挂接到根节点上
	/// <summary>
	/// 获取树节点并将其挂接到根节点上
	/// </summary>
	public  class ZKR_Nodes
	{
		public NodeClass rootClass;

		public ZKR_Nodes(NodeClass rootClass)
		{
			this.rootClass =rootClass;
		}
		/// <summary>
		/// 获取树节点，根据参数url和target给节点的属性赋值，可重载
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
	#endregion 获取树节点并将其挂接到根节点上

	#region NodeClass类，树的节点类，存储TreeNode节点信息
	/// <summary>
	/// 树的节点类
	/// </summary>
	public class NodeClass
	{
		public string text="";//显示文本
		public string data="";//包含的数据
		public string url="";//连接地址
		public string target="";//显示位置
		public bool hascheckbox=false;//是否显示选择框
		public ArrayList  nadelist=new ArrayList ();  //存储结点类NodeClass链表
		
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
	#endregion  NodeClass类，树的节点类
}

