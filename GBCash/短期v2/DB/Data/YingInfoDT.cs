namespace YingNet.WeiXing.DB.Data
{
    using System;

    public class YingInfoDT
    {
        private string m_ImgPath;
        private string m_InfoContent;
        private int m_InfoID;
        private bool m_InfoIsTop;
        private DateTime m_InfoPubDate;
        private string m_InfoTitle;
        private string m_InfoTypeNo;

        public string ImgPath
        {
            get
            {
                return this.m_ImgPath;
            }
            set
            {
                this.m_ImgPath = value;
            }
        }

        public string InfoContent
        {
            get
            {
                return this.m_InfoContent;
            }
            set
            {
                this.m_InfoContent = value;
            }
        }

        public int InfoID
        {
            get
            {
                return this.m_InfoID;
            }
            set
            {
                this.m_InfoID = value;
            }
        }

        public bool InfoIsTop
        {
            get
            {
                return this.m_InfoIsTop;
            }
            set
            {
                this.m_InfoIsTop = value;
            }
        }

        public DateTime InfoPubDate
        {
            get
            {
                return this.m_InfoPubDate;
            }
            set
            {
                this.m_InfoPubDate = value;
            }
        }

        public string InfoTitle
        {
            get
            {
                return this.m_InfoTitle;
            }
            set
            {
                this.m_InfoTitle = value;
            }
        }

        public string InfoTypeNo
        {
            get
            {
                return this.m_InfoTypeNo;
            }
            set
            {
                this.m_InfoTypeNo = value;
            }
        }
    }
}

