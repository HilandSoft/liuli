namespace YingNet.WeiXing.WebApp.manage
{
    using System;
    using YingNet.WeiXing.Business;

    public class infotypedel : ManageBasePage
    {
        private void InitializeComponent()
        {
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
            if ((this.Session["InfoTypeID"] != null) && (this.Session["InfoTypeID"].ToString() != string.Empty))
            {
                YingInfoTypeBN ebn = new YingInfoTypeBN(this);
                if (!ebn.ISHasSub(this.Session["InfoTypeID"].ToString()))
                {
                    if (ebn.Del(this.Session["InfoTypeID"].ToString()))
                    {
                        this.Session["InfoTypeID"] = "001";
                        this.Page.RegisterStartupScript("", "<script language=javascript>alert('删除类型成功！');leftReload();</script>");
                    }
                    else
                    {
                        base.Response.Write("<script>alert('删除类型失败！');</script>");
                    }
                }
                else
                {
                    base.Response.Write("<script>alert('类型已经使用,不能被删除！！');window.location='InfoList.aspx';</script>");
                }
            }
            else
            {
                base.Response.Write("<script>alert('请选择要删除的类型！');window.location='InfoList.aspx';</script>");
            }
        }
    }
}

