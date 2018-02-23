namespace YingNet.WeiXing.DB.Data
{
    using System;

    public class ScheduleDT
    {
        private double m_Balance;
        private DateTime m_Datedue;
        private int m_huiSid;
        private int m_id;
        private int m_IsValid;
        private int m_Numberment;
        private DateTime m_OperateTime;
        private double m_Paid;
        private string m_Param1;
        private string m_Param2;
        private string m_Param3;
        private string m_Param4;
        private double m_Param5;
        private double m_Penalty;
        private double m_Repaydue;
        private DateTime m_RepayTime;

        public double Balance
        {
            get
            {
                return this.m_Balance;
            }
            set
            {
                this.m_Balance = value;
            }
        }

        public DateTime Datedue
        {
            get
            {
                return this.m_Datedue;
            }
            set
            {
                this.m_Datedue = value;
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

        public int IsValid
        {
            get
            {
                return this.m_IsValid;
            }
            set
            {
                this.m_IsValid = value;
            }
        }

        public int Numberment
        {
            get
            {
                return this.m_Numberment;
            }
            set
            {
                this.m_Numberment = value;
            }
        }

        public DateTime OperateTime
        {
            get
            {
                return this.m_OperateTime;
            }
            set
            {
                this.m_OperateTime = value;
            }
        }

        public double Paid
        {
            get
            {
                return this.m_Paid;
            }
            set
            {
                this.m_Paid = value;
            }
        }

        public string Param1
        {
            get
            {
                return this.m_Param1;
            }
            set
            {
                this.m_Param1 = value;
            }
        }

        public string Param2
        {
            get
            {
                return this.m_Param2;
            }
            set
            {
                this.m_Param2 = value;
            }
        }

        public string Param3
        {
            get
            {
                return this.m_Param3;
            }
            set
            {
                this.m_Param3 = value;
            }
        }

        public string Param4
        {
            get
            {
                return this.m_Param4;
            }
            set
            {
                this.m_Param4 = value;
            }
        }

        public double Param5
        {
            get
            {
                return this.m_Param5;
            }
            set
            {
                this.m_Param5 = value;
            }
        }

        public double Penalty
        {
            get
            {
                return this.m_Penalty;
            }
            set
            {
                this.m_Penalty = value;
            }
        }

        public double Repaydue
        {
            get
            {
                return this.m_Repaydue;
            }
            set
            {
                this.m_Repaydue = value;
            }
        }

        public DateTime RepayTime
        {
            get
            {
                return this.m_RepayTime;
            }
            set
            {
                this.m_RepayTime = value;
            }
        }
    }
}

