namespace YingNet.WeiXing.DB.Data
{
    using System;

    public class InfoDT
    {
        private int m_huiSid;
        private int m_id;
        private int m_isvalid;
        private string m_param1;
        private string m_param2;
        private string m_param3;
        private DateTime m_regtime;
        private string m_type;
        private string m_Username;

        public int huiSid
        {
            get
            {
                return this.m_huiSid;
            }
            set
            {
                this.m_huiSid = value;
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

        public int isvalid
        {
            get
            {
                return this.m_isvalid;
            }
            set
            {
                this.m_isvalid = value;
            }
        }

        public string param1
        {
            get
            {
                return this.m_param1;
            }
            set
            {
                this.m_param1 = value;
            }
        }

        public string param2
        {
            get
            {
                return this.m_param2;
            }
            set
            {
                this.m_param2 = value;
            }
        }

        public string param3
        {
            get
            {
                return this.m_param3;
            }
            set
            {
                this.m_param3 = value;
            }
        }

        public DateTime regtime
        {
            get
            {
                return this.m_regtime;
            }
            set
            {
                this.m_regtime = value;
            }
        }

        public string type
        {
            get
            {
                return this.m_type;
            }
            set
            {
                this.m_type = value;
            }
        }

        public string Username
        {
            get
            {
                return this.m_Username;
            }
            set
            {
                this.m_Username = value;
            }
        }
    }
}

