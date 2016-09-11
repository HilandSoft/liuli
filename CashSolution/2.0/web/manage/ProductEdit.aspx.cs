namespace YingNet.WeiXing.WebApp.manage
{
    using System;
    using System.IO;
    using System.Web.UI.HtmlControls;
    using System.Web.UI.WebControls;
    using YingNet.WeiXing.Business;
    using YingNet.WeiXing.DB.Data;

    public class ProductEdit : ManageBasePage
    {
        protected HtmlInputButton Add;
        protected CheckBox CheckBox1;
        protected CheckBox CheckBox2;
        protected HtmlInputFile File1;
        protected TextBox TempID;
        protected TextBox TextBox1;
        protected TextBox TextBox2;
        protected TextBox TextBox3;

        private void Add_ServerClick(object sender, EventArgs e)
        {
            ProductBN tbn;
            if (((this.TextBox1.Text == null) || !(this.TextBox1.Text != string.Empty)) || ((this.TextBox3.Text == null) || !(this.TextBox3.Text != string.Empty)))
            {
                base.Response.Write("<script>alert('主题和内容有一项为空！保存不能继续！');</script>");
                return;
            }
            string str = null;
            bool flag = false;
            string filename = null;
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
                            str = DateTime.Now.Ticks.ToString() + WebAppConfig.GetFileExName(this.File1.PostedFile.FileName);
                            filename = path + "/" + str;
                            this.File1.PostedFile.SaveAs(filename);
                            flag = true;
                        }
                        catch
                        {
                            base.Response.Write("<script>alert('上传文件错误！');</script>");
                            return;
                        }
                        goto Label_0186;
                    }
                    base.Response.Write("<script>alert('文件类型不对，只能上传jpg和gif格式图片！');</script>");
                }
                else
                {
                    base.Response.Write("<script>alert('文件太大，图片最大只能1M(1024k)');</script>");
                }
                return;
            }
        Label_0186:
            tbn = new ProductBN(this);
            ProductDT dt = tbn.Get(Convert.ToInt32(this.TempID.Text));
            if (dt != null)
            {
                dt.ProductName = this.TextBox1.Text;
                if ((this.TextBox3.Text != null) && (this.TextBox3.Text != string.Empty))
                {
                    dt.ProductInfo = this.TextBox3.Text;
                }
                else
                {
                    dt.ProductInfo = "";
                }
                string str4 = (base.Server.MapPath("/") + dt.ImgPath).Replace("/", @"\");
                if (str != null)
                {
                    dt.ImgPath = WebAppConfig.CNProductPath + "/" + str;
                }
                else if (this.CheckBox1.Checked)
                {
                    if (File.Exists(str4))
                    {
                        try
                        {
                            File.Delete(str4);
                            dt.ImgPath = "";
                        }
                        catch (Exception)
                        {
                        }
                    }
                    else
                    {
                        dt.ImgPath = "";
                    }
                }
                dt.ProductIsTop = this.CheckBox2.Checked;
                if (tbn.Edit(dt))
                {
                    if (File.Exists(str4) && flag)
                    {
                        try
                        {
                            File.Delete(str4);
                        }
                        catch (Exception)
                        {
                        }
                    }
                    base.Response.Write("<script>alert('修改成功！');window.location='ProductList.aspx';</script>");
                }
                else
                {
                    if ((filename != null) && File.Exists(filename))
                    {
                        try
                        {
                            File.Delete(filename);
                        }
                        catch (Exception)
                        {
                        }
                    }
                    base.Response.Write("<script>alert('修改失败');</script>");
                }
            }
            else
            {
                base.Response.Write("<script>alert('原纪录不存在！');</script>");
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
            if (!base.IsPostBack)
            {
                if ((base.Request["ProductID"] != null) && (base.Request["ProductID"].ToString() != string.Empty))
                {
                    try
                    {
                        ProductBN tbn = new ProductBN(this);
                        this.TempID.Text = base.Request["ProductID"];
                        ProductDT tdt = tbn.Get(Convert.ToInt32(base.Request["ProductID"]));
                        if (tdt != null)
                        {
                            this.TextBox1.Text = tdt.ProductName;
                            this.TextBox3.Text = tdt.ProductInfo;
                            this.TextBox2.Text = tdt.ImgPath;
                            this.CheckBox2.Checked = tdt.ProductIsTop;
                        }
                        else
                        {
                            base.Response.Write("<script>alert('取数据出错！');window.location='Productlist.aspx?ProductTypeID=" + this.Session["ProductTypeID"].ToString() + "';</script>");
                        }
                    }
                    catch
                    {
                        base.Response.Write("<script>alert('传入参数错误');window.location='Infolist.aspx?ProductTypeID=" + this.Session["ProductTypeID"].ToString() + "';</script>");
                    }
                }
                else
                {
                    base.Response.Write("<script>alert('没有传入参数');window.location='Infolist.aspx?ProductTypeID=" + this.Session["ProductTypeID"].ToString() + "';</script>");
                }
            }
        }
    }
}

