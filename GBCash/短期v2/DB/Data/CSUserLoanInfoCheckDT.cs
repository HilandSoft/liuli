namespace YingNet.WeiXing.DB.Data
{
    using System;
    using YingNet.Serialization;

    public class CSUserLoanInfoCheckDT : ExtendedAttributes
    {
        private int checkOther1;
        private int checkOther2;
        private string checkOther3;
        private string checkOther4;
        private string employerAddress;
        private string employerName;
        private string employerTelephone;
        private int employmentStatus;
        private string homeTelephone;
        private string jobTitle;
        private DateTime nextPayday;
        private string payFrequency;
        private int processID;
        private decimal takeHomePayAfterTaxes;
        private string timeEmployed;
        private int userID;
        private UserLoanTypes userLoanType;
        private string workTelephone;

        public int CheckOther1
        {
            get
            {
                return this.checkOther1;
            }
            set
            {
                this.checkOther1 = value;
            }
        }

        public int CheckOther2
        {
            get
            {
                return this.checkOther2;
            }
            set
            {
                this.checkOther2 = value;
            }
        }

        public string CheckOther3
        {
            get
            {
                return this.checkOther3;
            }
            set
            {
                this.checkOther3 = value;
            }
        }

        public string CheckOther4
        {
            get
            {
                return this.checkOther4;
            }
            set
            {
                this.checkOther4 = value;
            }
        }

        public string EmployerAddress
        {
            get
            {
                return this.employerAddress;
            }
            set
            {
                this.employerAddress = value;
            }
        }

        public string EmployerName
        {
            get
            {
                return this.employerName;
            }
            set
            {
                this.employerName = value;
            }
        }

        public string EmployerTelephone
        {
            get
            {
                return this.employerTelephone;
            }
            set
            {
                this.employerTelephone = value;
            }
        }

        public int EmploymentStatus
        {
            get
            {
                return this.employmentStatus;
            }
            set
            {
                this.employmentStatus = value;
            }
        }

        public string EmploymentStatusText
        {
            get
            {
                return base.GetExtendedAttribute("EmploymentStatusText");
            }
            set
            {
                base.SetExtendedAttribute("EmploymentStatusText", value);
            }
        }

        public string HomeTelephone
        {
            get
            {
                return this.homeTelephone;
            }
            set
            {
                this.homeTelephone = value;
            }
        }

        public string JobTitle
        {
            get
            {
                return this.jobTitle;
            }
            set
            {
                this.jobTitle = value;
            }
        }

        public DateTime NextPayday
        {
            get
            {
                return this.nextPayday;
            }
            set
            {
                this.nextPayday = value;
            }
        }

        public string PayFrequency
        {
            get
            {
                return this.payFrequency;
            }
            set
            {
                this.payFrequency = value;
            }
        }

        public int ProcessID
        {
            get
            {
                return this.processID;
            }
            set
            {
                this.processID = value;
            }
        }

        public decimal TakeHomePayAfterTaxes
        {
            get
            {
                return this.takeHomePayAfterTaxes;
            }
            set
            {
                this.takeHomePayAfterTaxes = value;
            }
        }

        public string TimeEmployed
        {
            get
            {
                return this.timeEmployed;
            }
            set
            {
                this.timeEmployed = value;
            }
        }

        public int UserID
        {
            get
            {
                return this.userID;
            }
            set
            {
                this.userID = value;
            }
        }

        public UserLoanTypes UserLoanType
        {
            get
            {
                return this.userLoanType;
            }
            set
            {
                this.userLoanType = value;
            }
        }

        public string WorkTelephone
        {
            get
            {
                return this.workTelephone;
            }
            set
            {
                this.workTelephone = value;
            }
        }
    }
}

