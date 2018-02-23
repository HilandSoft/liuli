namespace YingNet.WeiXing.DB.Data
{
    using System;
    using YingNet.Serialization;

    public class CSFollowupCenterDT : ExtendedAttributes
    {
        private int followupID;
        private FollowupCenterStatusEnum followupStatus;
        private DateTime lastOperateDate;
        private int lastOperateUserID;
        private DateTime postDate;
        private DateTime remindDate;
        private DateTime remindDate2;
        private DateTime remindDate3;
        private bool remindEnable;
        private string taskInformation;
        private int userID;
        private UserLoanTypes userLoanType;

        public int FollowupID
        {
            get
            {
                return this.followupID;
            }
            set
            {
                this.followupID = value;
            }
        }

        public FollowupCenterStatusEnum FollowupStatus
        {
            get
            {
                return this.followupStatus;
            }
            set
            {
                this.followupStatus = value;
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

        public FollowupCenterStatusEnum PreviewStatus
        {
            get
            {
                string extendedAttribute = base.GetExtendedAttribute("PreviewStatus");
                switch (extendedAttribute)
                {
                    case null:
                    case "":
                        return FollowupCenterStatusEnum.NoStatus;
                }
                return (FollowupCenterStatusEnum) Convert.ToInt32(extendedAttribute);
            }
            set
            {
                base.SetExtendedAttribute("PreviewStatus", ((int) value).ToString());
            }
        }

        public DateTime RemindDate
        {
            get
            {
                return this.remindDate;
            }
            set
            {
                this.remindDate = value;
            }
        }

        public DateTime RemindDate2
        {
            get
            {
                return this.remindDate2;
            }
            set
            {
                this.remindDate2 = value;
            }
        }

        public DateTime RemindDate3
        {
            get
            {
                return this.remindDate3;
            }
            set
            {
                this.remindDate3 = value;
            }
        }

        public bool RemindEnable
        {
            get
            {
                return this.remindEnable;
            }
            set
            {
                this.remindEnable = value;
            }
        }

        public string TaskInformation
        {
            get
            {
                return this.taskInformation;
            }
            set
            {
                this.taskInformation = value;
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

