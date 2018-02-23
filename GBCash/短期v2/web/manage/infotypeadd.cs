namespace YingNet.WeiXing.WebApp.manage
{
    using System;
    using System.Web.UI.HtmlControls;
    using System.Web.UI.WebControls;
    using YingNet.WeiXing.Business;
    using YingNet.WeiXing.DB.Data;

    public class infotypeadd : ManageBasePage
    {
        protected HtmlInputButton Add;
        protected TextBox TextBox1;
        protected TextBox txtParamstr;

        private void Add_ServerClick(object sender, EventArgs e)
        {
            if ((this.TextBox1.Text != null) && (this.TextBox1.Text != string.Empty))
            {
                YingInfoTypeDT dt = new YingInfoTypeDT();
                dt.TypeName = this.TextBox1.Text;
                if ((this.Session["InfoTypeID"] != null) && (this.Session["InfoTypeID"].ToString() != string.Empty))
                {
                    dt.Parent = this.Session["InfoTypeID"].ToString();
                }
                else
                {
                    dt.Parent = "001";
                }
                dt.Has_Sub = true;
                YingInfoTypeBN ebn = new YingInfoTypeBN(this);
                if (ebn.Add(dt))
                {
                    this.Session["InfoTypeID"] = dt.Num;
                    this.Page.RegisterStartupScript("", "<script language=javascript>alert('添加成功！');leftReload();</script>");
                }
                else
                {
                    base.Response.Write("<script>alert('添加失败！');</script>");
                }
            }
            else
            {
                base.Response.Write("<script>alert('名称不能为空');</script>");
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
        }
    }
}

