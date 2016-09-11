namespace YingNet.WeiXing.WebApp.manage
{
    using System;
    using System.IO;
    using System.Web.UI.HtmlControls;
    using System.Web.UI.WebControls;
    using YingNet.WeiXing.Business;
    using YingNet.WeiXing.DB.Data;
	using YingNet.Common.Utils;

    public class ProductTypeAdd : ManageBasePage
    {
        protected HtmlInputButton Add;
        protected HtmlInputFile File1;
        protected TextBox TextBox1;
        protected TextBox TextBox3;

        private void Add_ServerClick(object sender, EventArgs e)
        {
            ProductTypeDT edt;
            if (((this.TextBox1.Text == null) || !(this.TextBox1.Text != string.Empty)) || ((this.TextBox3.Text == null) || !(this.TextBox3.Text != string.Empty)))
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
                        goto Label_017E;
                    }
                    base.Response.Write("<script>alert('文件类型不对，只能上传jpg和gif格式图片！');</script>");
                }
                else
                {
                    base.Response.Write("<script>alert('文件太大，图片最大只能1M(1024k)');</script>");
                }
                return;
            }
        Label_017E:
            edt = new ProductTypeDT();
            edt.TypeName = this.TextBox1.Text;
            edt.Parent = this.Session["ProductTypeID"].ToString().Trim();
            if ((this.TextBox3.Text != null) && (this.TextBox3.Text != string.Empty))
            {
                edt.TypeInfo = this.TextBox3.Text;
            }
            else
            {
                edt.TypeInfo = "";
            }
            if (str != null)
            {
                edt.ImgPath = WebAppConfig.CNProductPath + "/" + str;
            }
            else
            {
                edt.ImgPath = "";
            }
            ProductTypeBN ebn = new ProductTypeBN(this);
            if (ebn.Add(edt))
            {
                this.Session["ProductTypeID"] = edt.num;
                this.Page.RegisterStartupScript("", "<script language=javascript>alert('添加成功！');leftReload();</script>");
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

