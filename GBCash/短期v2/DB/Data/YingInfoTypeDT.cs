namespace YingNet.WeiXing.DB.Data
{
    using System;

    public class YingInfoTypeDT
    {
        private bool m_Has_Sub;
        private int m_id;
        private string m_Num;
        private string m_Parent;
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

        public string Num
        {
            get
            {
                return this.m_Num;
            }
            set
            {
                this.m_Num = value;
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

