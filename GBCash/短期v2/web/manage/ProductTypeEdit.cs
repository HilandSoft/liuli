namespace YingNet.WeiXing.WebApp.manage
{
    using System;
    using System.IO;
    using System.Web.UI.HtmlControls;
    using System.Web.UI.WebControls;
    using YingNet.Common.Utils;
    using YingNet.WeiXing.Business;
    using YingNet.WeiXing.DB.Data;

    public class ProductTypeEdit : ManageBasePage
    {
        protected HtmlInputButton Add;
        protected CheckBox CheckBox1;
        protected HtmlInputFile File1;
        protected TextBox TempID;
        protected TextBox TextBox1;
        protected TextBox TextBox2;
        protected TextBox TextBox3;

        private void Add_ServerClick(object sender, EventArgs e)
        {
            ProductTypeBN ebn;
            if (((this.TextBox1.Text == null) || (this.TextBox1.Text == string.Empty)) || ((this.TextBox3.Text == null) || (this.TextBox3.Text == string.Empty)))
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
                            str = SafeDateTime.LocalNow.Ticks.ToString() + WebAppConfig.GetFileExName(this.File1.PostedFile.FileName);
                            filename = path + "/" + str;
                            this.File1.PostedFile.SaveAs(filename);
                            flag = true;
                        }
                        catch
                        {
                            base.Response.Write("<script>alert('上传文件错误！');</script>");
                            return;
                        }
                        goto Label_018E;
                    }
                    base.Response.Write("<script>alert('文件类型不对，只能上传jpg和gif格式图片！');</script>");
                }
                else
                {
                    base.Response.Write("<script>alert('文件太大，图片最大只能1M(1024k)');</script>");
                }
                return;
            }
        Label_018E:
            ebn = new ProductTypeBN(this);
            ProductTypeDT byNum = ebn.GetByNum(this.Session["ProductTypeID"].ToString());
            if (byNum != null)
            {
                byNum.TypeName = this.TextBox1.Text;
                if ((this.TextBox3.Text != null) && (this.TextBox3.Text != string.Empty))
                {
                    byNum.TypeInfo = this.TextBox3.Text;
                }
                else
                {
                    byNum.TypeInfo = "";
                }
                string str4 = (base.Server.MapPath("/") + byNum.ImgPath).Replace("/", @"\");
                if (str != null)
                {
                    byNum.ImgPath = WebAppConfig.CNProductPath + "/" + str;
                }
                else if (this.CheckBox1.Checked)
                {
                    if (File.Exists(str4))
                    {
                        try
                        {
                            File.Delete(str4);
                            byNum.ImgPath = "";
                        }
                        catch (Exception)
                        {
                        }
                    }
                    else
                    {
                        byNum.ImgPath = "";
                    }
                }
                if (ebn.Edit(byNum))
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
                    this.Session["ProductTypeID"] = byNum.num;
                    this.Page.RegisterStartupScript("", "<script language=javascript>alert('修改成功！');leftReload();</script>");
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
                if ((this.Session["ProductTypeID"] != null) && (this.Session["ProductTypeID"].ToString() != string.Empty))
                {
                    try
                    {
                        ProductTypeDT byNum = new ProductTypeBN(this).GetByNum(this.Session["ProductTypeID"].ToString());
                        if (byNum != null)
                        {
                            this.TextBox1.Text = byNum.TypeName;
                            this.TextBox3.Text = byNum.TypeInfo;
                            this.TextBox2.Text = byNum.ImgPath;
                        }
                        else
                        {
                            base.Response.Write("<script>alert('取数据出错！');window.location='Infolist.aspx?InfoTypeID=" + this.Session["InfoTypeID"].ToString() + "';</script>");
                        }
                    }
                    catch
                    {
                        base.Response.Write("<script>alert('传入参数错误');window.location='Infolist.aspx?InfoTypeID=" + this.Session["InfoTypeID"].ToString() + "';</script>");
                    }
                }
                else
                {
                    base.Response.Write("<script>alert('没有传入参数');window.location='Infolist.aspx?InfoTypeID=" + this.Session["InfoTypeID"].ToString() + "';</script>");
                }
            }
        }
    }
}

