namespace YingNet.WeiXing.WebApp.manage
{
    using System;
    using System.Web.UI.HtmlControls;
    using System.Web.UI.WebControls;
    using YingNet.WeiXing.Business;
    using YingNet.WeiXing.DB.Data;

    public class infotypeedit : ManageBasePage
    {
        protected HtmlInputButton Add;
        protected TextBox TempID;
        protected TextBox TextBox1;

        private void Add_ServerClick(object sender, EventArgs e)
        {
            if (((this.TempID.Text != null) && (this.TempID.Text != string.Empty)) && ((base.Request["TextBox1"] != null) && (base.Request["TextBox1"] != string.Empty)))
            {
                YingInfoTypeBN ebn = new YingInfoTypeBN(this);
                YingInfoTypeDT byNum = ebn.GetByNum(this.TempID.Text);
                if (byNum != null)
                {
                    byNum.TypeName = base.Request["TextBox1"];
                    if (ebn.Edit(byNum))
                    {
                        this.Session["InfoTypeID"] = byNum.Num;
                        this.Page.RegisterStartupScript("", "<script language=javascript>alert('修改类型成功！');leftReload();</script>");
                    }
                    else
                    {
                        base.Response.Write("<script>alert('修改失败！');</script>");
                    }
                }
            }
            else
            {
                base.Response.Write("<script>alert('类型不能为空！！');</script>");
            }
        }

        private void InitializeComponent()
        {
            this.Add.ServerClick += new EventHandler(this.Add_ServerClick);
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
            if ((this.Session["InfoTypeID"].ToString() != null) && (this.Session["InfoTypeID"].ToString() != string.Empty))
            {
                try
                {
                    this.TempID.Text = this.Session["InfoTypeID"].ToString();
                    YingInfoTypeDT byNum = new YingInfoTypeBN(this).GetByNum(this.TempID.Text);
                    if (byNum != null)
                    {
                        this.TextBox1.Text = byNum.TypeName;
                    }
                    else
                    {
                        base.Response.Write("<script>alert('取数据出错！');window.location='InfoList.aspx';</script>");
                    }
                }
                catch
                {
                    base.Response.Write("<script>alert('传入参数错误');window.location='InfoList.aspx';</script>");
                }
            }
            else
            {
                base.Response.Write("<script>alert('没有记录');window.location='InfoList.aspx';</script>");
            }
        }
    }
}

