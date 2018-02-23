namespace YingNet.WeiXing.DB.Data
{
    using System;
    using System.Collections;

    public class YingSystemUserDT
    {
        private string m_account;
        private string m_deptpermit;
        private int m_id;
        private bool m_isactive;
        private string m_name;
        private string m_password;
        private Hashtable m_permit;

        public string account
        {
            get
            {
                return this.m_account;
            }
            set
            {
                this.m_account = value;
            }
        }

        public string deptpermit
        {
            get
            {
                return this.m_deptpermit;
            }
            set
            {
                this.m_deptpermit = value;
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

        public bool isactive
        {
            get
            {
                return this.m_isactive;
            }
            set
            {
                this.m_isactive = value;
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

        public string password
        {
            get
            {
                return this.m_password;
            }
            set
            {
                this.m_password = value;
            }
        }

        public Hashtable permit
        {
            get
            {
                return this.m_permit;
            }
            set
            {
                this.m_permit = value;
            }
        }
    }
}

