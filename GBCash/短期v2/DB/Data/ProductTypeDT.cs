namespace YingNet.WeiXing.DB.Data
{
    using System;

    public class ProductTypeDT
    {
        private bool m_Has_Sub;
        private int m_id;
        private string m_ImgPath;
        private string m_num;
        private string m_Parent;
        private string m_TypeInfo;
        private string m_TypeName;

        public bool Has_Sub
        {
            get
            {
                return this.m_Has_Sub;
            }
            set
            {
                this.m_Has_Sub = value;
            }
        }

        public int id
        {
            get
            {
                return this.m_id;
            }
            set
            {
                this.m_id = value;
            }
        }

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

        public string num
        {
            get
            {
                return this.m_num;
            }
            set
            {
                this.m_num = value;
            }
        }

        public string Parent
        {
            get
            {
                return this.m_Parent;
            }
            set
            {
                this.m_Parent = value;
            }
        }

        public string TypeInfo
        {
            get
            {
                return this.m_TypeInfo;
            }
            set
            {
                this.m_TypeInfo = value;
            }
        }

        public string TypeName
        {
            get
            {
                return this.m_TypeName;
            }
            set
            {
                this.m_TypeName = value;
            }
        }
    }
}

