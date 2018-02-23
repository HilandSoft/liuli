namespace YingNet.WeiXing.DB.Data
{
    using System;

    public class ProductDT
    {
        private string m_ImgPath;
        private int m_PriductID;
        private string m_ProductInfo;
        private bool m_ProductIsTop;
        private string m_ProductName;
        private string m_ProductTypeNo;
        private DateTime m_PubDate;

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

        public int PriductID
        {
            get
            {
                return this.m_PriductID;
            }
            set
            {
                this.m_PriductID = value;
            }
        }

        public string ProductInfo
        {
            get
            {
                return this.m_ProductInfo;
            }
            set
            {
                this.m_ProductInfo = value;
            }
        }

        public bool ProductIsTop
        {
            get
            {
                return this.m_ProductIsTop;
            }
            set
            {
                this.m_ProductIsTop = value;
            }
        }

        public string ProductName
        {
            get
            {
                return this.m_ProductName;
            }
            set
            {
                this.m_ProductName = value;
            }
        }

        public string ProductTypeNo
        {
            get
            {
                return this.m_ProductTypeNo;
            }
            set
            {
                this.m_ProductTypeNo = value;
            }
        }

        public DateTime PubDate
        {
            get
            {
                return this.m_PubDate;
            }
            set
            {
                this.m_PubDate = value;
            }
        }
    }
}

