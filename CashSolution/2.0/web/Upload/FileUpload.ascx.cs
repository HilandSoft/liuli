namespace YingNet.ControlLib.Upload
{
    using System;
    using System.Web.UI;
    using System.Web.UI.HtmlControls;

    public class FileUpload : UserControl
    {
        protected HtmlInputFile upfile;

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

        public void SaveAs(string filename)
        {
            this.upfile.PostedFile.SaveAs(filename);
        }

        public int ContentLength
        {
            get
            {
                return this.upfile.PostedFile.ContentLength;
            }
        }

        public string ContentType
        {
            get
            {
                return this.upfile.PostedFile.ContentType;
            }
        }

        public string ExtName
        {
            get
            {
                string fileName = this.FileName;
                if (fileName != null)
                {
                    int num = fileName.LastIndexOf('.');
                    if (num > 0)
                    {
                        return fileName.Substring(num + 1);
                    }
                }
                return null;
            }
        }

        public string FileName
        {
            get
            {
                string fullName = this.FullName;
                if (fullName != null)
                {
                    int num = fullName.LastIndexOf('\\');
                    if (num > 0)
                    {
                        return fullName.Substring(num + 1);
                    }
                }
                return null;
            }
        }

        public string FullName
        {
            get
            {
                if ((this.upfile.PostedFile.FileName == null) || this.upfile.PostedFile.FileName.Equals(""))
                {
                    return null;
                }
                return this.upfile.PostedFile.FileName;
            }
        }
    }
}

