namespace YingNet.WeiXing.DB.Data
{
    using System;

    public class EmploybackupDT
    {
        private string m_EAddress;
        private string m_Employer;
        private string m_EPhone;
        private double m_Frequency;
        private string m_huiName;
        private int m_huiSid;
        private int m_id;
        private int m_IsEmployed;
        private float m_MIncome;
        private DateTime m_ModTime;
        private int m_NDayDD;
        private int m_NDayMM;
        private int m_NDayYY;
        private int m_TMonths;
        private int m_TYears;
        private string m_Wpaid;

        public string EAddress
        {
            get
            {
                return this.m_EAddress;
            }
            set
            {
                this.m_EAddress = value;
            }
        }

        public string Employer
        {
            get
            {
                return this.m_Employer;
            }
            set
            {
                this.m_Employer = value;
            }
        }

        public string EPhone
        {
            get
            {
                return this.m_EPhone;
            }
            set
            {
                this.m_EPhone = value;
            }
        }

        public double Frequency
        {
            get
            {
                return this.m_Frequency;
            }
            set
            {
                this.m_Frequency = value;
            }
        }

        public string huiName
        {
            get
            {
                return this.m_huiName;
            }
            set
            {
                this.m_huiName = value;
            }
        }

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

        public int IsEmployed
        {
            get
            {
                return this.m_IsEmployed;
            }
            set
            {
                this.m_IsEmployed = value;
            }
        }

        public float MIncome
        {
            get
            {
                return this.m_MIncome;
            }
            set
            {
                this.m_MIncome = value;
            }
        }

        public DateTime ModTime
        {
            get
            {
                return this.m_ModTime;
            }
            set
            {
                this.m_ModTime = value;
            }
        }

        public int NDayDD
        {
            get
            {
                return this.m_NDayDD;
            }
            set
            {
                this.m_NDayDD = value;
            }
        }

        public int NDayMM
        {
            get
            {
                return this.m_NDayMM;
            }
            set
            {
                this.m_NDayMM = value;
            }
        }

        public int NDayYY
        {
            get
            {
                return this.m_NDayYY;
            }
            set
            {
                this.m_NDayYY = value;
            }
        }

        public int TMonths
        {
            get
            {
                return this.m_TMonths;
            }
            set
            {
                this.m_TMonths = value;
            }
        }

        public int TYears
        {
            get
            {
                return this.m_TYears;
            }
            set
            {
                this.m_TYears = value;
            }
        }

        public string Wpaid
        {
            get
            {
                return this.m_Wpaid;
            }
            set
            {
                this.m_Wpaid = value;
            }
        }
    }
}

