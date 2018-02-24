namespace YingNet.WeiXing.WebApp.manage
{
    using Microsoft.Web.UI.WebControls;
    using System;
    using System.Web.UI;

    public class WebForm1 : Page
    {
        protected TreeView TreeView1;

        private void InitializeComponent()
        {
            this.TreeView1.Expand += new ClickEventHandler(this.TreeView1_Expand);
            this.TreeView1.SelectedIndexChange += new SelectEventHandler(this.TreeView1_SelectedIndexChange);
            this.TreeView1.Collapse += new ClickEventHandler(this.TreeView1_Collapse);
            base.Load += new EventHandler(this.Page_Load);
        }

        protected override void OnInit(EventArgs e)
        {
            this.InitializeComponent();
            base.OnInit(e);
        }

        private void Page_Load(object sender, EventArgs e)
        {
            TreeNode nodeFromIndex = this.TreeView1.GetNodeFromIndex("0");
            base.Response.Write(nodeFromIndex.Parent.ToString());
        }

        private void TreeView1_Collapse(object sender, TreeViewClickEventArgs e)
        {
        }

        private void TreeView1_Expand(object sender, TreeViewClickEventArgs e)
        {
        }

        private void TreeView1_SelectedIndexChange(object sender, TreeViewSelectEventArgs e)
        {
        }
    }
}

