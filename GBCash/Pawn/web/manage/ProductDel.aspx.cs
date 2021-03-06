﻿namespace YingNet.WeiXing.WebApp.manage
{
    using System;
    using System.IO;
    using YingNet.WeiXing.Business;
    using YingNet.WeiXing.DB.Data;

    public class ProductDel : ManageBasePage
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
            if ((base.Request["ProductID"] != null) && (base.Request["ProductID"].ToString() != string.Empty))
            {
                ProductBN tbn = new ProductBN(this);
                ProductDT tdt = tbn.Get(Convert.ToInt32(base.Request["ProductID"]));
                if (tbn.Del(Convert.ToInt32(base.Request["ProductID"])))
                {
                    if (tdt != null)
                    {
                        string path = (base.Server.MapPath("/") + tdt.ImgPath).Replace("/", @"\");
                        if (File.Exists(path))
                        {
                            try
                            {
                                File.Delete(path);
                            }
                            catch (Exception)
                            {
                            }
                        }
                    }
                    base.Response.Write("<script>alert('删除成功！');window.location='ProductList.aspx';</script>");
                }
            }
            else
            {
                base.Response.Write("<script>alert('请选择要删除的产品！');window.location='ProductList.aspx';</script>");
            }
        }
    }
}

