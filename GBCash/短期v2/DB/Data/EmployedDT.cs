namespace YingNet.WeiXing.DB.Data
{
    using System;
    using YingNet.WeiXing.STRUCTURE;

    public class EmployedDT
    {
        private HousePaymentCircles housePaymentCircle = HousePaymentCircles.NonSet;
        private float housePaymentValue = 0f;
        private string loanPurpose = string.Empty;
        private string m_AName;
        private string m_ANumber;
        private string m_BankName;
        private string m_Branch;
        private string m_Bsb;
        private string m_EAddress;
        private string m_Employer;
        private string m_EPhone;
        private double m_Frequency;
        private string m_GrossIncomeChangeValue;
        private int m_huiSid;
        private int m_id;
        private double m_Interest;
        private int m_IsEmployed;
        private int m_IsGrossIncomeChange = 0;
        private int m_IsPayOtherCredit = 0;
        private int m_IsValid;
        private float m_Loan;
        private string m_MContact;
        private float m_MIncome;
        private int m_NDayDD;
        private int m_NDayMM;
        private int m_NDayYY;
        private int m_NInstallment;
        private double m_Param1;
        private double m_Param2;
        private int m_Param3;
        private string m_Param4;
        private string m_Param5;
        private string m_PayOtherCreditValue;
        private string m_Rname1;
        private string m_Rname2;
        private string m_Rname3;
        private string m_Rnum1;
        private string m_Rnum2;
        private string m_Rnum3;
        private string m_Rship1;
        private string m_Rship2;
        private string m_Rship3;
        private DateTime m_RTime;
        private int m_TMonths;
        private int m_TYears;
        private string m_Wpaid;
        private int m_XDay;
        private OtherLenderCircles otherLenderCircle = OtherLenderCircles.NonSet;
        private float otherLenderValue = 0f;
        private int otherSamllCreditHas = 0;
        private int otherSmallCreditCount = 0;

        public string AName
        {
            get
            {
                return this.m_AName;
            }
            set
            {
                this.m_AName = value;
            }
        }

        public string ANumber
        {
            get
            {
                return this.m_ANumber;
            }
            set
            {
                this.m_ANumber = value;
            }
        }

        public string BankName
        {
            get
            {
                return this.m_BankName;
            }
            set
            {
                this.m_BankName = value;
            }
        }

        public string Branch
        {
            get
            {
                return this.m_Branch;
            }
            set
            {
                this.m_Branch = value;
            }
        }

        public string Bsb
        {
            get
            {
                return this.m_Bsb;
            }
            set
            {
                this.m_Bsb = value;
            }
        }

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

        public string GrossIncomeChangeValue
        {
            get
            {
                return this.m_GrossIncomeChangeValue;
            }
            set
            {
                this.m_GrossIncomeChangeValue = value;
            }
        }

        public HousePaymentCircles HousePaymentCircle
        {
            get
            {
                return this.housePaymentCircle;
            }
            set
            {
                this.housePaymentCircle = value;
            }
        }

        public float HousePaymentValue
        {
            get
            {
                return this.housePaymentValue;
            }
            set
            {
                this.housePaymentValue = value;
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

        public double Interest
        {
            get
            {
                return this.m_Interest;
            }
            set
            {
                this.m_Interest = value;
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

        public int IsGrossIncomeChange
        {
            get
            {
                return this.m_IsGrossIncomeChange;
            }
            set
            {
                this.m_IsGrossIncomeChange = value;
            }
        }

        public int IsPayOtherCredit
        {
            get
            {
                return this.m_IsPayOtherCredit;
            }
            set
            {
                this.m_IsPayOtherCredit = value;
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

        public float Loan
        {
            get
            {
                return this.m_Loan;
            }
            set
            {
                this.m_Loan = value;
            }
        }

        public string LoanPurpose
        {
            get
            {
                return this.loanPurpose;
            }
            set
            {
                this.loanPurpose = value;
            }
        }

        public string MContact
        {
            get
            {
                return this.m_MContact;
            }
            set
            {
                this.m_MContact = value;
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

        public int NInstallment
        {
            get
            {
                return this.m_NInstallment;
            }
            set
            {
                this.m_NInstallment = value;
            }
        }

        public OtherLenderCircles OtherLenderCircle
        {
            get
            {
                return this.otherLenderCircle;
            }
            set
            {
                this.otherLenderCircle = value;
            }
        }

        public float OtherLenderValue
        {
            get
            {
                return this.otherLenderValue;
            }
            set
            {
                this.otherLenderValue = value;
            }
        }

        public int OtherSamllCreditHas
        {
            get
            {
                return this.otherSamllCreditHas;
            }
            set
            {
                this.otherSamllCreditHas = value;
            }
        }

        public int OtherSmallCreditCount
        {
            get
            {
                return this.otherSmallCreditCount;
            }
            set
            {
                this.otherSmallCreditCount = value;
            }
        }

        public double Param1
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

        public double Param2
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

        public int Param3
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

        public string Param5
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

        public string PayOtherCreditValue
        {
            get
            {
                return this.m_PayOtherCreditValue;
            }
            set
            {
                this.m_PayOtherCreditValue = value;
            }
        }

        public string Rname1
        {
            get
            {
                return this.m_Rname1;
            }
            set
            {
                this.m_Rname1 = value;
            }
        }

        public string Rname2
        {
            get
            {
                return this.m_Rname2;
            }
            set
            {
                this.m_Rname2 = value;
            }
        }

        public string Rname3
        {
            get
            {
                return this.m_Rname3;
            }
            set
            {
                this.m_Rname3 = value;
            }
        }

        public string Rnum1
        {
            get
            {
                return this.m_Rnum1;
            }
            set
            {
                this.m_Rnum1 = value;
            }
        }

        public string Rnum2
        {
            get
            {
                return this.m_Rnum2;
            }
            set
            {
                this.m_Rnum2 = value;
            }
        }

        public string Rnum3
        {
            get
            {
                return this.m_Rnum3;
            }
            set
            {
                this.m_Rnum3 = value;
            }
        }

        public string Rship1
        {
            get
            {
                return this.m_Rship1;
            }
            set
            {
                this.m_Rship1 = value;
            }
        }

        public string Rship2
        {
            get
            {
                return this.m_Rship2;
            }
            set
            {
                this.m_Rship2 = value;
            }
        }

        public string Rship3
        {
            get
            {
                return this.m_Rship3;
            }
            set
            {
                this.m_Rship3 = value;
            }
        }

        public DateTime RTime
        {
            get
            {
                return this.m_RTime;
            }
            set
            {
                this.m_RTime = value;
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

        public int XDay
        {
            get
            {
                return this.m_XDay;
            }
            set
            {
                this.m_XDay = value;
            }
        }
    }
}

