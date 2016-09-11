namespace YingNet.WeiXing.WebApp.manage
{
    using System;
    using System.IO;
    using YingNet.WeiXing.Business;
    using YingNet.WeiXing.DB.Data;

    public class ProductTypeDel : ManageBasePage
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
            if ((this.Session["ProductTypeID"] != null) && (this.Session["ProductTypeID"].ToString() != string.Empty))
            {
                ProductTypeBN ebn = new ProductTypeBN(this);
                if (!ebn.ISHasSub(this.Session["ProductTypeID"].ToString()))
                {
                    if (this.Session["ProductTypeID"].ToString() != "001")
                    {
                        ProductTypeDT byNum = ebn.GetByNum(this.Session["ProductTypeID"].ToString());
                        if (ebn.Del(this.Session["ProductTypeID"].ToString()))
                        {
                            if (byNum != null)
                            {
                                string path = (base.Server.MapPath("/") + byNum.ImgPath).Replace("/", @"\");
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
                            if (this.Session["ProductTypeID"].ToString().Length > 3)
                            {
                                this.Session["ProductTypeID"] = this.Session["ProductTypeID"].ToString().Substring(0, this.Session["ProductTypeID"].ToString().Length - 3);
                                base.Response.Write("<script>alert('删除类型成功！');window.location='ProductList.aspx';window.parent.carnoc.location.reload();</script>");
                            }
                            else
                            {
                                this.Session["ProductTypeID"] = null;
                                base.Response.Write("<script>alert('删除类型成功！');window.location='ProductList.aspx';window.parent.carnoc.location.reload();</script>");
                            }
                        }
                        else
                        {
                            base.Response.Write("<script>alert('删除类型失败！');window.location='ProductList.aspx';</script>");
                        }
                    }
                    else
                    {
                        base.Response.Write("<script>alert('不能删除根目录，删除类型失败！');window.location='ProductList.aspx';</script>");
                    }
                }
                else
                {
                    base.Response.Write("<script>alert('类型已经使用,不能被删除！！');window.location='ProductList.aspx';</script>");
                }
            }
            else
            {
                base.Response.Write("<script>alert('请选择要删除的类型！');window.location='ProductList.aspx';</script>");
            }
        }
    }
}

