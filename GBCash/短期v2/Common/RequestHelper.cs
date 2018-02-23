using System;
using System.Text;
using System.Web;
using System.Collections.Specialized;
using System.Collections;

namespace YingNet.Common
{
    public class RequestHelper
    {
        /// <summary>
        /// 获取当前请求的不带请求头(例如"http://"等)的原始地址
        /// </summary>
        /// <returns></returns>
        public static string GetOriginalUrlWithoutSchemeHeader()
        {
            string originalUrl = HttpContext.Current.Request.Url.AbsoluteUri;
            return GetOriginalUrlWithoutSchemeHeader(originalUrl);
        }

        /// <summary>
        /// 获取不带请求头(例如"http://"等)的原始地址
        /// </summary>
        /// <param name="originalUrl">完整的请求地址（即HttpContext.Current.Request.Url.OriginalString）</param>
        /// <returns></returns>
        public static string GetOriginalUrlWithoutSchemeHeader(string originalUrl)
        {
            string result = originalUrl;
            int headerSeperatorPos= originalUrl.IndexOf("://");
            if (headerSeperatorPos >= 0)
            {
                result = originalUrl.Substring(headerSeperatorPos+3);
            }

            return result;
        }

        /// <summary>
        /// 将普通的虚拟目录转化成应用程序的虚拟目录（以“~/”开头格式的目录）
        /// </summary>
        /// <param name="virtualPath">普通的虚拟目录</param>
        /// <returns></returns>
        public static string GetAppRelativeVirtualPath(string virtualPath)
        {
            if (virtualPath.StartsWith("~/") == false)
            {
                if (virtualPath.StartsWith("/") == false)
                {
                    virtualPath = "/" + virtualPath;
                }

                if (virtualPath.StartsWith("~") == false)
                {
                    virtualPath = "~" + virtualPath;
                }
            }

            return virtualPath;
        }

        /// <summary>
        /// 是否为本机服务器
        /// </summary>
        /// <returns></returns>
        /// <remarks>
        ///     当前请求的服务是否位于本机上（主要针对开发人员的授权时使用）
        /// </remarks>
        public static bool IsSelfServer
        {
            get
            {
                bool isSelf = false;

                string hostAddress = HttpContext.Current.Request.UserHostAddress.ToLower();
                if (hostAddress == "127.0.0.1" || hostAddress == "localhost")
                {
                    isSelf = true;
                }

                return isSelf;
            }
        }

        /// <summary>
        /// 是否为本地服务器
        /// </summary>
        /// <returns></returns>
        /// <remarks>
        ///     本机服务器，局域网内的服务器均为本地服务器
        ///     局域网可用的ip地址范围为:
        ///         A类地址10.0.0.0 - 10.255.255.255
        ///         b类网172.16.0.0 - 172.31.255.255
        ///         c类网192.168.0.0 -192.168.255.255
        /// </remarks>
        public static bool IsLocalServer
        {
            get
            {
                bool isLocal = false;
                
                //判断本机
                isLocal = IsSelfServer;
                if (isLocal == true)
                {
                    return true;
                }

                //判断局域网
                string hostAddress = HttpContext.Current.Request.UserHostAddress.ToLower();
                if (hostAddress.StartsWith("10.") || hostAddress.StartsWith("172.") || hostAddress.StartsWith("192.168."))
                {
                    isLocal = true;
                }

                return isLocal;
            }
        }

        /// <summary>
        /// 是否为远程服务器
        /// </summary>
        /// <returns></returns>
        public static bool IsRemoteServer
        {
            get
            {
                bool isLocal = IsLocalServer;

                if (isLocal == true)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
        }
    }
}
