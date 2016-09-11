namespace YingNet.WeiXing.WebApp.manage
{
    using Microsoft.Web.UI.WebControls;
    using System;
    using System.Web.UI;
    using YingNet.Common;
    using YingNet.WeiXing.Business;

    public class ProductLeftTree : Page
    {
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
                NodeClass rootClass = new NodeClass("产品类型", "0", "ProductList.aspx?ProductTypeID=001", "frmRight", false);
                ProductTypeTree tree = new ProductTypeTree(rootClass);
                BuildTree tree2 = new BuildTree(this.TreeView1, tree.getTreeNode("ProductList.aspx", "frmRight", false));
                this.TreeView1.Nodes[0].Expanded = true;
                rootClass = null;
                if ((this.Session["ProductTypeID"] != null) && (this.Session["ProductTypeID"].ToString() != ""))
                {
                    string str = this.Session["ProductTypeID"].ToString();
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
                        this.Session["ProductTypeID"] = "001";
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
                                if (node2.Text == "产品类型")
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

