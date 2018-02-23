namespace YingNet.WeiXing.Business
{
    using System;
    using System.Collections;
    using System.Web.UI;
    using YingNet.Common;

    public class BaseLib : CommonBaseLib
    {
        protected Page page = null;
        public const string PARAM_NAME = "paramstr";
        private Random random = null;
        public const string SESSION_USER_ACCOUNT = "user.account";
        public const string SESSION_USER_DEPT = "user.dept";
        public const string SESSION_USER_DEPTID = "user.deptid";
        public const string SESSION_USER_NAME = "user.name";
        public const string SESSION_USER_PERMIT = "user.permit";
        public const string SESSION_USER_UID = "user.uid";
        private Stack stack = null;

        public BaseLib(Page page)
        {
            this.page = page;
        }

        public void CleanStatus()
        {
            base.DBFieldList = null;
            base.DBTable = null;
            base.Filter = null;
            base.Order = null;
            base.Group = null;
        }

        public int GetRadomNum(int num)
        {
            if (this.random == null)
            {
                this.random = new Random();
            }
            return (this.random.Next() % num);
        }

        public void PopStatus()
        {
            if (this.stack != null)
            {
                object obj2 = null;
                obj2 = this.stack.Pop();
                if (obj2 != null)
                {
                    base.DBFieldList = obj2.ToString();
                }
                else
                {
                    base.DBFieldList = null;
                }
                obj2 = this.stack.Pop();
                if (obj2 != null)
                {
                    base.DBTable = obj2.ToString();
                }
                else
                {
                    base.DBTable = null;
                }
                obj2 = this.stack.Pop();
                if (obj2 != null)
                {
                    base.Filter = obj2.ToString();
                }
                else
                {
                    base.Filter = null;
                }
                obj2 = this.stack.Pop();
                if (obj2 != null)
                {
                    base.Order = obj2.ToString();
                }
                else
                {
                    base.Order = null;
                }
                obj2 = this.stack.Pop();
                if (obj2 != null)
                {
                    base.Group = obj2.ToString();
                }
                else
                {
                    base.Group = null;
                }
            }
        }

        public void PushStatus()
        {
            if (this.stack == null)
            {
                this.stack = new Stack();
            }
            this.stack.Push(base.DBFieldList);
            this.stack.Push(base.DBTable);
            this.stack.Push(base.Filter);
            this.stack.Push(base.Order);
            this.stack.Push(base.Group);
        }
    }
}

