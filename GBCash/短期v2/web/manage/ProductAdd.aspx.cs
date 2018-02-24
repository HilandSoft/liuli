namespace YingNet.WeiXing.WebApp.manage
{
    using System;
    using System.IO;
    using System.Web.UI.HtmlControls;
    using System.Web.UI.WebControls;
    using YingNet.Common.Utils;
    using YingNet.WeiXing.Business;
    using YingNet.WeiXing.DB.Data;

    public class ProductAdd : ManageBasePage
    {
        protected HtmlInputButton Add;
        protected CheckBox CheckBox1;
        protected HtmlInputFile File1;
        protected TextBox TextBox1;
        protected TextBox TextBox3;

        private void Add_ServerClick(object sender, EventArgs e)
        {
            ProductDT tdt;
            if (((this.TextBox1.Text == null) || (this.TextBox1.Text == string.Empty)) || ((this.TextBox3.Text == null) || (this.TextBox3.Text == string.Empty)))
            {
                base.Response.Write("<script>alert('主题和内容有一项为空！保存不能继续！');</script>");
                return;
            }
            string str = null;
            if (this.File1.PostedFile.ContentLength != 0)
            {
                if (this.File1.PostedFile.ContentLength < 0xfa000)
                {
                    if ((this.File1.PostedFile.ContentType == "image/pjpeg") || (this.File1.PostedFile.ContentType == "image/gif"))
                    {
                        try
                        {
                            string path = base.Server.MapPath("/" + WebAppConfig.CNProductPath);
                            if (!Directory.Exists(path))
                            {
                                Directory.CreateDirectory(path);
                            }
                            str = SafeDateTime.LocalNow.Ticks.ToString() + WebAppConfig.GetFileExName(this.File1.PostedFile.FileName);
                            this.File1.PostedFile.SaveAs(path + "/" + str);
                        }
                        catch
                        {
                            base.Response.Write("<script>alert('上传文件错误！');</script>");
                            return;
                        }
                        goto Label_0182;
                    }
                    base.Response.Write("<script>alert('文件类型不对，只能上传jpg和gif格式图片！');</script>");
                }
                else
                {
                    base.Response.Write("<script>alert('文件太大，图片最大只能1M(1024k)');</script>");
                }
                return;
            }
        Label_0182:
            tdt = new ProductDT();
            tdt.ProductName = this.TextBox1.Text;
            tdt.ProductTypeNo = this.Session["ProductTypeID"].ToString().Trim();
            tdt.ProductIsTop = this.CheckBox1.Checked;
            tdt.PubDate = SafeDateTime.LocalNow;
            if ((this.TextBox3.Text != null) && (this.TextBox3.Text != string.Empty))
            {
                tdt.ProductInfo = this.TextBox3.Text;
            }
            else
            {
                tdt.ProductInfo = "";
            }
            if (str != null)
            {
                tdt.ImgPath = WebAppConfig.CNProductPath + "/" + str;
            }
            else
            {
                tdt.ImgPath = "";
            }
            ProductBN tbn = new ProductBN(this);
            if (tbn.Add(tdt))
            {
                base.Response.Write("<script>alert('添加成功！');window.location='ProductList.aspx';</script>");
            }
            else
            {
                base.Response.Write("<script>alert('添加失败');</script>");
            }
        }

        private void InitializeComponent()
        {
            this.Add.ServerClick += new EventHandler(this.Add_ServerClick);
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
        }
    }
}

