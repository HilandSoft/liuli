namespace YingNet.WeiXing.DB.Data
{
    using System;
    using YingNet.Serialization;

    public class CSProcessCenterDT : ExtendedAttributes
    {
        private string conversationTrack = string.Empty;
        private string documentRequired = string.Empty;
        private bool isFirstLoan;
        private DateTime lastOperateDate;
        private int lastOperateUserID = 0;
        private int loanID = 0;
        private DateTime postDate;
        private int processID;
        private InformationAlertStates processOther1 = InformationAlertStates.UnRead;
        private int processOther2 = 0;
        private string processOther3 = string.Empty;
        private string processOther4 = string.Empty;
        private ProcessCenterStatusEnum processStatus;
        private string task = string.Empty;
        private int userID;
        private UserLoanTypes userLoanType;

        public string ConversationTrack
        {
            get
            {
                return this.conversationTrack;
            }
            set
            {
                this.conversationTrack = value;
            }
        }

        public InformationAlertStates CurrentStateIsAlerted
        {
            get
            {
                return this.processOther1;
            }
            set
            {
                this.processOther1 = value;
            }
        }

        public DetailsVerificationStatusEnum DetailsVerificationStatus
        {
            get
            {
                string extendedAttribute = base.GetExtendedAttribute("DetailsVerificationStatus");
                if (extendedAttribute != string.Empty)
                {
                    return (DetailsVerificationStatusEnum) Convert.ToInt32(extendedAttribute);
                }
                return DetailsVerificationStatusEnum.Pending;
            }
            set
            {
                base.SetExtendedAttribute("DetailsVerificationStatus", Convert.ToInt32(value).ToString());
            }
        }

        public DocumentCheckListStatusEnum DocumentCheckListStatus
        {
            get
            {
                string extendedAttribute = base.GetExtendedAttribute("DocumentCheckListStatus");
                if (extendedAttribute != string.Empty)
                {
                    return (DocumentCheckListStatusEnum) Convert.ToInt32(extendedAttribute);
                }
                return DocumentCheckListStatusEnum.Incomplete;
            }
            set
            {
                base.SetExtendedAttribute("DocumentCheckListStatus", Convert.ToInt32(value).ToString());
            }
        }

        public string DocumentRequired
        {
            get
            {
                return this.documentRequired;
            }
            set
            {
                this.documentRequired = value;
            }
        }

        public DocumentRequiredStatusEnum DocumentRequiredStatus
        {
            get
            {
                string extendedAttribute = base.GetExtendedAttribute("DocumentRequiredStatus");
                if (extendedAttribute != string.Empty)
                {
                    return (DocumentRequiredStatusEnum) Convert.ToInt32(extendedAttribute);
                }
                return DocumentRequiredStatusEnum.Pending;
            }
            set
            {
                base.SetExtendedAttribute("DocumentRequiredStatus", Convert.ToInt32(value).ToString());
            }
        }

        public bool IsDocumentBankStatement
        {
            get
            {
                string extendedAttribute = base.GetExtendedAttribute("IsDocumentBankStatement");
                return ((extendedAttribute != string.Empty) && Convert.ToBoolean(extendedAttribute));
            }
            set
            {
                base.SetExtendedAttribute("IsDocumentBankStatement", value.ToString());
            }
        }

        public bool IsDocumentDirectDebitRequest
        {
            get
            {
                string extendedAttribute = base.GetExtendedAttribute("IsDocumentDirectDebitRequest");
                return ((extendedAttribute != string.Empty) && Convert.ToBoolean(extendedAttribute));
            }
            set
            {
                base.SetExtendedAttribute("IsDocumentDirectDebitRequest", value.ToString());
            }
        }

        public bool IsDocumentID
        {
            get
            {
                string extendedAttribute = base.GetExtendedAttribute("IsDocumentID");
                return ((extendedAttribute != string.Empty) && Convert.ToBoolean(extendedAttribute));
            }
            set
            {
                base.SetExtendedAttribute("IsDocumentID", value.ToString());
            }
        }

        public bool IsDocumentMasterLoanAgreemnet
        {
            get
            {
                string extendedAttribute = base.GetExtendedAttribute("IsDocumentMasterLoanAgreemnet");
                return ((extendedAttribute != string.Empty) && Convert.ToBoolean(extendedAttribute));
            }
            set
            {
                base.SetExtendedAttribute("IsDocumentMasterLoanAgreemnet", value.ToString());
            }
        }

        public bool IsDocumentPaySlip
        {
            get
            {
                string extendedAttribute = base.GetExtendedAttribute("IsDocumentPaySlip");
                return ((extendedAttribute != string.Empty) && Convert.ToBoolean(extendedAttribute));
            }
            set
            {
                base.SetExtendedAttribute("IsDocumentPaySlip", value.ToString());
            }
        }

        public bool IsDocumentUtilityBill
        {
            get
            {
                string extendedAttribute = base.GetExtendedAttribute("IsDocumentUtilityBill");
                return ((extendedAttribute != string.Empty) && Convert.ToBoolean(extendedAttribute));
            }
            set
            {
                base.SetExtendedAttribute("IsDocumentUtilityBill", value.ToString());
            }
        }

        public bool IsFirstLoan
        {
            get
            {
                return this.isFirstLoan;
            }
            set
            {
                this.isFirstLoan = value;
            }
        }

        public DateTime LastOperateDate
        {
            get
            {
                return this.lastOperateDate;
            }
            set
            {
                this.lastOperateDate = value;
            }
        }

        public int LastOperateUserID
        {
            get
            {
                return this.lastOperateUserID;
            }
            set
            {
                this.lastOperateUserID = value;
            }
        }

        public int LoanID
        {
            get
            {
                return this.loanID;
            }
            set
            {
                this.loanID = value;
            }
        }

        public DateTime PostDate
        {
            get
            {
                return this.postDate;
            }
            set
            {
                this.postDate = value;
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

        public int ProcessOther2
        {
            get
            {
                return this.processOther2;
            }
            set
            {
                this.processOther2 = value;
            }
        }

        public string ProcessOther3
        {
            get
            {
                return this.processOther3;
            }
            set
            {
                this.processOther3 = value;
            }
        }

        public string ProcessOther4
        {
            get
            {
                return this.processOther4;
            }
            set
            {
                this.processOther4 = value;
            }
        }

        public ProcessCenterStatusEnum ProcessStatus
        {
            get
            {
                return this.processStatus;
            }
            set
            {
                this.processStatus = value;
            }
        }

        public string ProcessStatusDisplay
        {
            get
            {
                return base.GetExtendedAttribute("ProcessStatusDisplay");
            }
            set
            {
                base.SetExtendedAttribute("ProcessStatusDisplay", value);
            }
        }

        public string Task
        {
            get
            {
                return this.task;
            }
            set
            {
                this.task = value;
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
    }
}

