namespace YingNet.ControlLib.HtmlEditor
{
    using System;
    using System.Data;
    using System.Web.UI;
    using YingNet.Common;

    public class HtmlEditor : UserControl
    {
        private string m_content = "";
        private string m_filemanageurl = null;

        private void InitializeComponent()
        {
            base.Load += new EventHandler(this.Page_Load);
        }

        protected override void OnInit(EventArgs e)
        {
            this.InitializeComponent();
            base.OnInit(e);
        }

        private void Page_Load(object sender, EventArgs e)
        {
        }

        protected string ShowContent()
        {
            return StringUtils.Replace(StringUtils.Replace(this.m_content, "\r\n", ""), "'", @"\'");
        }

        public string Content
        {
            get
            {
                this.m_content = base.Request.Params["myEditWorksControl_html"];
                this.m_content = StringUtils.DropHtmlTag(this.m_content, "form");
                return this.m_content;
            }
            set
            {
                this.m_content = value;
            }
        }

        public DataTable File
        {
            get
            {
                DataTable table = (DataTable) base.Session["htmleditor_uploadfile"];
                base.Session.Remove("htmleditor_uploadfile");
                return table;
            }
            set
            {
                base.Session["htmleditor_uploadfile"] = value;
            }
        }

        public string FileManageURL
        {
            get
            {
                return this.m_filemanageurl;
            }
            set
            {
                this.m_filemanageurl = value;
            }
        }

        public string Path
        {
            set
            {
                base.Session["htmleditor_path"] = value;
            }
        }

        public string WebPath
        {
            set
            {
                base.Session["htmleditor_webpath"] = value;
            }
        }
    }
}

