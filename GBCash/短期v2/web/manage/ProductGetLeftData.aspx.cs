namespace YingNet.WeiXing.WebApp.manage
{
    using System;
    using System.Data;
    using YingNet.WeiXing.Business;

    public class ProductGetLeftData : ManageBasePage
    {
        private void InitializeComponent()
        {
            base.Load += new EventHandler(this.Page_Load);
        }

        protected override void OnInit(EventArgs e)
        {
            base.Code = "001003001";
            this.InitializeComponent();
            base.OnInit(e);
        }

        private void Page_Load(object sender, EventArgs e)
        {
            base.Response.ContentType = "text/plain; charset=utf-8";
            base.Response.Write("id,label,iid,parent,leaf,url\n");
            ProductTypeBN ebn = new ProductTypeBN(this);
            foreach (DataRow row in ebn.GetList().Select())
            {
                base.Response.Write(row["num"].ToString());
                base.Response.Write(",");
                base.Response.Write(row["TypeName"].ToString().Trim());
                base.Response.Write(",");
                base.Response.Write(row["id"].ToString());
                base.Response.Write(",");
                if (row["parent"] == DBNull.Value)
                {
                    base.Response.Write("0");
                }
                else
                {
                    base.Response.Write(row["parent"].ToString());
                }
                base.Response.Write(",");
                base.Response.Write(Convert.ToInt32(row["Has_Sub"]));
                base.Response.Write(",");
                base.Response.Write("ProductList.aspx?ProductTypeID=" + row["num"].ToString());
                base.Response.Write("\n");
            }
        }
    }
}

