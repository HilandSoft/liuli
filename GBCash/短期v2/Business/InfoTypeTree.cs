namespace YingNet.WeiXing.Business
{
    using System;
    using System.Data;
    using YingNet.Common;
    using YingNet.WeiXing.DB;
    using YingNet.WeiXing.DB.Data;

    public class InfoTypeTree : ZKR_Nodes
    {
        public InfoTypeTree(NodeClass rootClass) : base(rootClass)
        {
        }

        public override NodeClass getTreeNode(string url, string target, bool hascheckbox)
        {
            YingInfoTypeDB edb = new YingInfoTypeDB();
            YingInfoTypeDT edt = new YingInfoTypeDT();
            DataTable list = edb.GetList("001");
            if (list != null)
            {
                foreach (DataRow row in list.Rows)
                {
                    NodeClass currentNode = new NodeClass(row[2].ToString(), row[1].ToString(), url + "?InfoTypeID=" + row[1].ToString(), target, hascheckbox);
                    this.nodeTreeD(currentNode, currentNode.data, url, target, hascheckbox);
                    base.rootClass.addNode(currentNode);
                }
            }
            edb = null;
            edt = null;
            return base.rootClass;
        }

        private void nodeTreeD(NodeClass currentNode, string currentparentID, string url, string target, bool hascheckbox)
        {
            YingInfoTypeDB edb = new YingInfoTypeDB();
            YingInfoTypeDT edt = new YingInfoTypeDT();
            DataTable list = edb.GetList(currentparentID);
            if (list != null)
            {
                foreach (DataRow row in list.Rows)
                {
                    NodeClass nc = new NodeClass(row[2].ToString(), row[1].ToString(), url + "?InfoTypeID=" + row[1].ToString(), target, hascheckbox);
                    currentNode.addNode(nc);
                    this.nodeTreeD(nc, nc.data, url, target, hascheckbox);
                }
            }
        }
    }
}

