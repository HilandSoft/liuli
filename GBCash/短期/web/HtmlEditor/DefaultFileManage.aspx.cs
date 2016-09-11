namespace YingNet.ControlLib.HtmlEditor
{
    using System;
    using System.Data;
    using System.IO;
    using System.Web.UI;
    using System.Web.UI.WebControls;
    using YingNet.ControlLib.Upload;
    using YingNet.WeiXing.Business;

    public class DefaultFileManage : Page
    {
        protected Button btnUpload;
        protected DataGrid dgdList;
        private DataTable file = null;
        private string m_path = null;
        private string m_webpath = null;
        protected YingNet.ControlLib.Upload.FileUpload upload;

        private void btnUpload_Click(object sender, EventArgs e)
        {
            if (this.upload.FileName != null)
            {
                string str = Guid.NewGuid().ToString();
                if (this.upload.ExtName != null)
                {
                    str = str + "." + this.upload.ExtName;
                }
                this.upload.SaveAs(this.m_path + str);
                DataRow row = this.file.NewRow();
                row["orgName"] = this.upload.FileName;
                row["serverName"] = str;
                row["contenttype"] = this.upload.ContentType;
                row["filesize"] = this.upload.ContentLength;
                this.file.Rows.Add(row);
            }
            this.dgdList.DataBind();
        }

        private void dgdList_DataBinding(object sender, EventArgs e)
        {
            this.dgdList.DataSource = this.file;
        }

        private void dgdList_ItemCommand(object source, DataGridCommandEventArgs e)
        {
            if (e.CommandName.Equals("Delete"))
            {
                if (File.Exists(this.m_path + this.file.Rows[e.Item.DataSetIndex]["serverName"]))
                {
                    File.Delete(this.m_path + this.file.Rows[e.Item.DataSetIndex]["serverName"]);
                }
                this.file.Rows.RemoveAt(e.Item.DataSetIndex);
                this.dgdList.DataBind();
            }
        }

        private void dgdList_ItemDataBound(object sender, DataGridItemEventArgs e)
        {
            ListItemType itemType = e.Item.ItemType;
            if ((itemType.Equals(ListItemType.AlternatingItem) || itemType.Equals(ListItemType.EditItem)) || (itemType.Equals(ListItemType.Item) || itemType.Equals(ListItemType.SelectedItem)))
            {
                if (e.Item.Cells[3].Text.ToLower().Trim().StartsWith("image"))
                {
                    e.Item.Cells[0].Text = "<div ondblclick='returnImage(\"" + this.m_webpath + e.Item.Cells[1].Text + "\",\"" + e.Item.Cells[0].Text + "\")'><img width=\"20\" height=\"21\" src=\"" + this.m_webpath + e.Item.Cells[1].Text + "\">" + e.Item.Cells[0].Text + "</div>";
                }
                else
                {
                    e.Item.Cells[0].Text = "<div ondblclick='returnHref(\"" + this.m_webpath + e.Item.Cells[1].Text + "\",\"" + e.Item.Cells[0].Text + "\")'>" + e.Item.Cells[0].Text + "</div>";
                }
            }
        }

        private void InitializeComponent()
        {
            this.btnUpload.Click += new EventHandler(this.btnUpload_Click);
            this.dgdList.ItemCommand += new DataGridCommandEventHandler(this.dgdList_ItemCommand);
            this.dgdList.DataBinding += new EventHandler(this.dgdList_DataBinding);
            this.dgdList.ItemDataBound += new DataGridItemEventHandler(this.dgdList_ItemDataBound);
            base.Load += new EventHandler(this.Page_Load);
        }

        private void InitTable()
        {
            if (this.Page.Session["htmleditor_uploadfile"] == null)
            {
                this.file = new DataTable("uploadfile");
                this.file.Columns.Add("orgName");
                this.file.Columns.Add("serverName");
                this.file.Columns.Add("contenttype");
                this.file.Columns.Add("filesize");
                this.Page.Session["htmleditor_uploadfile"] = this.file;
            }
            else
            {
                this.file = (DataTable) this.Page.Session["htmleditor_uploadfile"];
            }
            if (this.Page.Session["htmleditor_path"] == null)
            {
                this.m_path = this.Page.Server.MapPath("/") + WebAppConfig.NewsPath + "/";
                this.m_webpath = "/" + WebAppConfig.NewsPath + "/";
                this.Page.Session["htmleditor_path"] = this.m_path;
                this.Page.Session["htmleditor_webpath"] = this.m_webpath;
            }
            else
            {
                this.m_path = (string) this.Page.Session["htmleditor_path"];
                this.m_webpath = (string) this.Page.Session["htmleditor_webpath"];
            }
        }

        protected override void OnInit(EventArgs e)
        {
            this.InitializeComponent();
            base.OnInit(e);
        }

        private void Page_Load(object sender, EventArgs e)
        {
            this.InitTable();
            if (!base.IsPostBack)
            {
                this.dgdList.DataBind();
            }
        }
    }
}

