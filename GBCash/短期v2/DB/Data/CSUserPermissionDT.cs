namespace YingNet.WeiXing.DB.Data
{
    using System;
    using YingNet.Serialization;

    public class CSUserPermissionDT : ExtendedAttributes
    {
        private int permissionOther1;
        private int permissionOther2;
        private string permissionOther3;
        private string permissionOther4;
        private int userID;

        public int PermissionFollowupCenter
        {
            get
            {
                string extendedAttribute = base.GetExtendedAttribute("FollowupCenter");
                if (extendedAttribute != string.Empty)
                {
                    return Convert.ToInt32(extendedAttribute);
                }
                return 0;
            }
            set
            {
                base.SetExtendedAttribute("FollowupCenter", value.ToString());
            }
        }

        public int PermissionLFollowupCenter
        {
            get
            {
                string extendedAttribute = base.GetExtendedAttribute("LFollowupCenter");
                if (extendedAttribute != string.Empty)
                {
                    return Convert.ToInt32(extendedAttribute);
                }
                return 0;
            }
            set
            {
                base.SetExtendedAttribute("LFollowupCenter", value.ToString());
            }
        }

        public int PermissionLProcessCenter
        {
            get
            {
                string extendedAttribute = base.GetExtendedAttribute("LProcessCenter");
                if (extendedAttribute != string.Empty)
                {
                    return Convert.ToInt32(extendedAttribute);
                }
                return 0;
            }
            set
            {
                base.SetExtendedAttribute("LProcessCenter", value.ToString());
            }
        }

        public int PermissionManagerInfo
        {
            get
            {
                string extendedAttribute = base.GetExtendedAttribute("ManagerInfo");
                if (extendedAttribute != string.Empty)
                {
                    return Convert.ToInt32(extendedAttribute);
                }
                return 0;
            }
            set
            {
                base.SetExtendedAttribute("ManagerInfo", value.ToString());
            }
        }

        public int PermissionOther1
        {
            get
            {
                return this.permissionOther1;
            }
            set
            {
                this.permissionOther1 = value;
            }
        }

        public int PermissionOther2
        {
            get
            {
                return this.permissionOther2;
            }
            set
            {
                this.permissionOther2 = value;
            }
        }

        public string PermissionOther3
        {
            get
            {
                return this.permissionOther3;
            }
            set
            {
                this.permissionOther3 = value;
            }
        }

        public string PermissionOther4
        {
            get
            {
                return this.permissionOther4;
            }
            set
            {
                this.permissionOther4 = value;
            }
        }

        public int PermissionPaydayInfo
        {
            get
            {
                string extendedAttribute = base.GetExtendedAttribute("PaydayInfo");
                if (extendedAttribute != string.Empty)
                {
                    return Convert.ToInt32(extendedAttribute);
                }
                return 0;
            }
            set
            {
                base.SetExtendedAttribute("PaydayInfo", value.ToString());
            }
        }

        public int PermissionProcessCenter
        {
            get
            {
                string extendedAttribute = base.GetExtendedAttribute("ProcessCenter");
                if (extendedAttribute != string.Empty)
                {
                    return Convert.ToInt32(extendedAttribute);
                }
                return 0;
            }
            set
            {
                base.SetExtendedAttribute("ProcessCenter", value.ToString());
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
    }
}

