namespace YingNet.WeiXing.DB.Data
{
    using System;
    using YingNet.Serialization;

    public class CSUserDT : ExtendedAttributes
    {
        private DateTime dateCreated;
        private string email;
        private int enable;
        private DateTime lastLoginDate;
        private string nickname;
        private string password;
        private int passwordFormat;
        private string passwordSalt;
        private string userClass;
        private int userID;
        private string userName;
        private int userRank;
        private int userType;

        public DateTime DateCreated
        {
            get
            {
                return this.dateCreated;
            }
            set
            {
                this.dateCreated = value;
            }
        }

        public string Email
        {
            get
            {
                return this.email;
            }
            set
            {
                this.email = value;
            }
        }

        public int Enable
        {
            get
            {
                return this.enable;
            }
            set
            {
                this.enable = value;
            }
        }

        public DateTime LastLoginDate
        {
            get
            {
                return this.lastLoginDate;
            }
            set
            {
                this.lastLoginDate = value;
            }
        }

        public string Nickname
        {
            get
            {
                return this.nickname;
            }
            set
            {
                this.nickname = value;
            }
        }

        public string Password
        {
            get
            {
                return this.password;
            }
            set
            {
                this.password = value;
            }
        }

        public int PasswordFormat
        {
            get
            {
                return this.passwordFormat;
            }
            set
            {
                this.passwordFormat = value;
            }
        }

        public string PasswordSalt
        {
            get
            {
                return this.passwordSalt;
            }
            set
            {
                this.passwordSalt = value;
            }
        }

        public string UserClass
        {
            get
            {
                return this.userClass;
            }
            set
            {
                this.userClass = value;
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

        public string UserName
        {
            get
            {
                return this.userName;
            }
            set
            {
                this.userName = value;
            }
        }

        public int UserRank
        {
            get
            {
                return this.userRank;
            }
            set
            {
                this.userRank = value;
            }
        }

        public int UserType
        {
            get
            {
                return this.userType;
            }
            set
            {
                this.userType = value;
            }
        }
    }
}

