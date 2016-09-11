namespace YingNet.WeiXing.WebApp.manage
{
    using System;
    using System.IO;
    using System.Web.UI.HtmlControls;
    using System.Web.UI.WebControls;
    using YingNet.ControlLib.HtmlEditor;
    using YingNet.WeiXing.Business;
    using YingNet.WeiXing.DB.Data;

    public class infoedit : ManageBasePage
    {
        protected HtmlInputButton Add;
        protected Button Button1;
        protected CheckBox CheckBox1;
        protected DropDownList DropDownList1;
        protected HtmlInputFile File1;
        protected YingNet.ControlLib.HtmlEditor.HtmlEditor HtmlEditor1;
        protected TextBox TempID;
        protected TextBox TextBox1;
        protected TextBox TextBox2;
        protected TextBox TextBox3;
        protected TextBox TextBox5;
        protected TextBox txTime;

        private void Button1_Click(object sender, EventArgs e)
        {
            YingInfoBN obn;
            if ((this.TextBox1.Text == null) || !(this.TextBox1.Text != string.Empty))
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
                            string str3 = base.Server.MapPath("/" + WebAppConfig.NewsPath);
                            if (!Directory.Exists(str3))
                            {
                                Directory.CreateDirectory(str3);
                            }
                            str = DateTime.Now.Ticks.ToString() + WebAppConfig.GetFileExName(this.File1.PostedFile.FileName);
                            filename = str3 + "/" + str;
                            this.File1.PostedFile.SaveAs(filename);
                            flag = true;
                        }
                        catch
                        {
                            base.Response.Write("<script>alert('上传文件错误！');</script>");
                            return;
                        }
                        goto Label_015C;
                    }
                    base.Response.Write("<script>alert('文件类型不对，只能上传jpg和gif格式图片！');</script>");
                }
                else
                {
                    base.Response.Write("<script>alert('文件太大，图片最大只能1M(1024k)');</script>");
                }
                return;
            }
        Label_015C:
            obn = new YingInfoBN(this);
            YingInfoDT dt = obn.Get(Convert.ToInt32(this.TempID.Text));
            dt.InfoPubDate = Convert.ToDateTime(this.txTime.Text);
            dt.InfoTypeNo = this.DropDownList1.SelectedValue;
            dt.InfoTitle = this.TextBox1.Text;
            if ((this.HtmlEditor1.Content != null) && (this.HtmlEditor1.Content != string.Empty))
            {
                dt.InfoContent = this.HtmlEditor1.Content;
            }
            else
            {
                dt.InfoContent = "";
            }
            string path = (base.Server.MapPath("/") + dt.ImgPath).Replace("/", @"\");
            if (str != null)
            {
                dt.ImgPath = WebAppConfig.NewsPath + "/" + str;
            }
            dt.InfoIsTop = this.CheckBox1.Checked;
            if (obn.Edit(dt))
            {
                if (File.Exists(path) && flag)
                {
                    try
                    {
                        File.Delete(path);
                    }
                    catch (Exception)
                    {
                    }
                }
                base.Response.Write("<script>alert('修改成功！');window.location='InfoList.aspx';</script>");
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

        private void InitializeComponent()
        {
            this.Button1.Click += new EventHandler(this.Button1_Click);
            base.Load += new EventHandler(this.Page_Load);
        }

        protected override void OnInit(EventArgs e)
        {
            base.Code = "001002";
            this.InitializeComponent();
            base.OnInit(e);
        }

        private void Page_Load(object sender, EventArgs e)
        {
            if (!base.IsPostBack)
            {
                if ((base.Request["InfoID"] != null) && (base.Request["InfoID"].ToString() != string.Empty))
                {
                    this.DropDownList1.DataSource = new YingInfoTypeBN(this).GetList(this.Session["InfoTypeID"].ToString());
                    this.DropDownList1.DataTextField = "TypeName";
                    this.DropDownList1.DataValueField = "num";
                    this.DropDownList1.DataBind();
                    try
                    {
                        this.TempID.Text = base.Request["InfoID"];
                        YingInfoDT odt = new YingInfoBN(this).Get(Convert.ToInt32(this.TempID.Text));
                        if (odt != null)
                        {
                            this.TextBox1.Text = odt.InfoTitle;
                            this.txTime.Text = odt.InfoPubDate.ToShortDateString();
                            if (odt.InfoIsTop)
                            {
                                this.CheckBox1.Checked = true;
                            }
                            this.HtmlEditor1.Content = odt.InfoContent;
                            this.TextBox2.Text = odt.ImgPath;
                            this.DropDownList1.SelectedValue = odt.InfoTypeNo;
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

