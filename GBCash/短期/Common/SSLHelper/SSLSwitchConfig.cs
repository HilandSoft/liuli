using System;
using System.Collections;

namespace YingNet.Common.SSLHelper
{
	public class SSLSwitchConfig
    {
        private ArrayList sslList = new ArrayList();
        /// <summary>
        /// 需要使用SSL的页面信息列表
        /// </summary>
        public ArrayList SSLList
        {
            get
            {
                return this.sslList;
            }
            set
            {
                this.sslList = value;
            }
        }

        private ControlModes controlMode = ControlModes.AllowOther;
        public ControlModes ControlMode
        {
            get
            {
                return this.controlMode;
            }
            set
            {
                this.controlMode = value;
            }
        }

        private DeployModes deployMode = DeployModes.On;
        public DeployModes DeployMode
        {
            get
            {
                return this.deployMode;
            }
            set
            {
                this.deployMode = value;
            }
        }

        public bool IsContaint(string virtualPathToValidate)
        {
            bool isContaint = false;
            
            virtualPathToValidate = RequestHelper.GetAppRelativeVirtualPath(virtualPathToValidate).ToLower();

            for (int i = 0; i < sslList.Count; i++)
            {
                string currentItem = sslList[i].ToString();
                currentItem = RequestHelper.GetAppRelativeVirtualPath(currentItem).ToLower();

                if (virtualPathToValidate.StartsWith(currentItem) == true)
                {
                    isContaint = true;
                    break;
                }
            }

            return isContaint;
        }
    }
}
