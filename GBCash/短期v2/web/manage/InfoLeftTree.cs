namespace YingNet.WeiXing.WebApp.manage
{
    using Microsoft.Web.UI.WebControls;
    using System;
    using System.Web.UI;
    using System.Web.UI.HtmlControls;
    using YingNet.Common;
    using YingNet.WeiXing.Business;

    public class InfoLeftTree : Page
    {
        public string target = "";
        protected HtmlInputText Text1;
        protected TreeView TreeView1;

        private void InitializeComponent()
        {
            base.Load += new EventHandler(this.Page_Load);
        }

        protected override void OnInit(EventArgs e)
        {
            this.InitializeComponent();
            base.OnInit(e);
        }

        private void Page_Load(object sender, EventArgs e)
        {
            if (!this.Page.IsPostBack)
            {
                NodeClass rootClass = new NodeClass("信息类型", "0", "InfoList.aspx?InfoTypeID=001", "frmRight", false);
                InfoTypeTree tree = new InfoTypeTree(rootClass);
                BuildTree tree2 = new BuildTree(this.TreeView1, tree.getTreeNode("InfoList.aspx", "frmRight", false));
                this.TreeView1.Nodes[0].Expanded = true;
                rootClass = null;
                if ((this.Session["InfoTypeID"] != null) && (this.Session["InfoTypeID"].ToString() != ""))
                {
                    string str = this.Session["InfoTypeID"].ToString();
                    int num = str.Length / 3;
                    string strIndex = "";
                    for (int i = 0; i < num; i++)
                    {
                        strIndex = strIndex + ((Convert.ToInt32(str.Substring(i * 3, 3)) - 1)).ToString() + ".";
                    }
                    strIndex = strIndex.Substring(0, strIndex.Length - 1);
                    TreeNode nodeFromIndex = this.TreeView1.GetNodeFromIndex(strIndex);
                    if (nodeFromIndex == null)
                    {
                        this.TreeView1.SelectedNodeIndex = "0";
                        this.Session["InfoTypeID"] = "001";
                        this.Page.RegisterStartupScript("", "<script language=javascript>window.parent.frmRight.location.reload();</script>");
                    }
                    else
                    {
                        this.TreeView1.SelectedNodeIndex = strIndex;
                        if (nodeFromIndex.Parent.ToString() == "TreeNode")
                        {
                            for (TreeNode node2 = (TreeNode) nodeFromIndex.Parent; node2 != null; node2 = (TreeNode) node2.Parent)
                            {
                                node2.Expanded = true;
                                if (node2.Text == "信息类型")
                                {
                                    break;
                                }
                            }
                        }
                    }
                }
            }
        }
    }
}

