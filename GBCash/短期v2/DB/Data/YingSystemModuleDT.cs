namespace YingNet.WeiXing.DB.Data
{
    using System;

    public class YingSystemModuleDT
    {
        private string m_code;
        private string m_displayname;
        private string m_name;

        public string code
        {
            get
            {
                return this.m_code;
            }
            set
            {
                this.m_code = value;
            }
        }

        public string displayname
        {
            get
            {
                return this.m_displayname;
            }
            set
            {
                this.m_displayname = value;
            }
        }

        public string name
        {
            get
            {
                return this.m_name;
            }
            set
            {
                this.m_name = value;
            }
        }
    }
}

