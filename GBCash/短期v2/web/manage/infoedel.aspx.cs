namespace YingNet.WeiXing.WebApp.manage
{
    using System;
    using System.IO;
    using YingNet.WeiXing.Business;
    using YingNet.WeiXing.DB.Data;

    public class infoedel : ManageBasePage
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
            if (!base.IsPostBack)
            {
                if ((base.Request["infoID"] != null) && (base.Request["infoID"].ToString() != string.Empty))
                {
                    YingInfoBN obn = new YingInfoBN(this);
                    YingInfoDT odt = obn.Get(Convert.ToInt32(base.Request["infoID"]));
                    if (odt != null)
                    {
                        try
                        {
                            if (obn.Del(Convert.ToInt32(base.Request["infoID"])))
                            {
                                string path = (base.Server.MapPath("/") + odt.ImgPath).Replace("/", @"\");
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
                                base.Response.Write("<script>alert('删除成功！');window.location='InfoList.aspx';</script>");
                            }
                            else
                            {
                                base.Response.Write("<script>alert('删除失败！');window.location='InfoList.aspx';</script>");
                            }
                        }
                        catch
                        {
                            base.Response.Write("<script>alert('删除失败！');window.location='InfoList.aspx';</script>");
                        }
                    }
                    else
                    {
                        base.Response.Write("<script>alert('删除产品失败！');window.location='InfoList.aspx';</script>");
                    }
                }
                else
                {
                    base.Response.Write("<script>alert('请选择要删除的信息！');window.location='InfoList.aspx';</script>");
                }
            }
        }
    }
}

