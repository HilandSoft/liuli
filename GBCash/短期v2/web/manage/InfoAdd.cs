namespace YingNet.WeiXing.WebApp.manage
{
    using System;
    using System.IO;
    using System.Web.UI.HtmlControls;
    using System.Web.UI.WebControls;
    using YingNet.Common.Utils;
    using YingNet.ControlLib.HtmlEditor;
    using YingNet.WeiXing.Business;
    using YingNet.WeiXing.DB.Data;

    public class InfoAdd : ManageBasePage
    {
        protected Button Button1;
        protected CheckBox CheckBox1;
        protected DropDownList DropDownList1;
        protected HtmlInputFile File1;
        protected YingNet.ControlLib.HtmlEditor.HtmlEditor HtmlEditor1;
        protected TextBox TextBox1;
        protected TextBox txTime;

        private void Button1_Click(object sender, EventArgs e)
        {
            YingInfoDT odt;
            if (((this.TextBox1.Text == null) || (this.TextBox1.Text == string.Empty)) || ((this.HtmlEditor1.Content == null) || (this.HtmlEditor1.Content == string.Empty)))
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
                            string path = base.Server.MapPath("/" + WebAppConfig.NewsPath);
                            if (!Directory.Exists(path))
                            {
                                Directory.CreateDirectory(path);
                            }
                            str = DateTime.Now.Ticks.ToString() + WebAppConfig.GetFileExName(this.File1.PostedFile.FileName);
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
            odt = new YingInfoDT();
            odt.InfoTypeNo = this.DropDownList1.SelectedValue;
            odt.InfoPubDate = Convert.ToDateTime(this.txTime.Text);
            odt.InfoTitle = this.TextBox1.Text;
            if ((this.HtmlEditor1.Content != null) && (this.HtmlEditor1.Content != string.Empty))
            {
                odt.InfoContent = this.HtmlEditor1.Content;
            }
            else
            {
                odt.InfoContent = "";
            }
            if (str != null)
            {
                odt.ImgPath = WebAppConfig.NewsPath + "/" + str;
            }
            else
            {
                odt.ImgPath = "";
            }
            odt.InfoIsTop = this.CheckBox1.Checked;
            YingInfoBN obn = new YingInfoBN(this);
            if (obn.Add(odt))
            {
                this.Page.RegisterStartupScript("", "<script language=javascript>alert('添加成功！');window.location='InfoList.aspx';</script>");
            }
            else
            {
                base.Response.Write("<script>alert('添加失败');</script>");
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
                this.txTime.Text = SafeDateTime.LocalNow.ToShortDateString();
                this.DropDownList1.DataSource = new YingInfoTypeBN(this).GetList(this.Session["InfoTypeID"].ToString());
                this.DropDownList1.DataTextField = "TypeName";
                this.DropDownList1.DataValueField = "num";
                this.DropDownList1.DataBind();
            }
        }
    }
}

