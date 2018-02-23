
using System;
using System.IO;
using System.Security;
using System.Web;
using System.Runtime.InteropServices;

namespace YingNet.Utils
{
    /// <summary>
    /// 在asp.net下文件系统目录操作辅助类
    /// </summary>
    public class WebDirectory
    {
        private WebDirectory()
        { }

        /// <summary>
        /// Attempts to created a directory at the specified path with the an empty default.aspx file
        /// </summary>
        /// <remarks>创建含Default.aspx的空文件</remarks>
        public static DirectoryAccess Create(string path)
        {
            return Execute(path, "default.aspx", false);
        }

        /// <summary>
        /// Attempts to create a random text file at the specified directory. Once created, the document
        /// will then be deleted.
        /// </summary>
        public static DirectoryAccess ValidateAccess(string path)
        {
            return Execute(path, string.Format("{0}.txt", Guid.NewGuid()), true);
        }

        /// <summary>
        /// Moves one directory and it's contents to another. If the Old directory does not exist,
        /// Create is called on the new directory.
        /// </summary>
        public static DirectoryAccess Move(string oldPath, string newPath)
        {
            try
            {
                oldPath = FormatPath(oldPath);
                newPath = FormatPath(newPath);
                if (Directory.Exists(oldPath))
                {
                    Directory.Move(oldPath, newPath);
                    return DirectoryAccess.Success;
                }
                else
                    return Create(newPath);
            }
            catch (SecurityException)
            {
                return DirectoryAccess.SecurityException;
            }
            catch (UnauthorizedAccessException)
            {
                return DirectoryAccess.UnauthorizedAccessException;
            }
        }

        public static DirectoryAccess Delete(string path)
        {
            try
            {
                path = FormatPath(path);
                if (Directory.Exists(path))
                    Directory.Delete(path, true);
                return DirectoryAccess.Success;
            }
            catch (SecurityException)
            {
                return DirectoryAccess.SecurityException;
            }
            catch (UnauthorizedAccessException)
            {
                return DirectoryAccess.UnauthorizedAccessException;
            }
        }

        /// <summary>
        /// Internal method used to convert a web based path to a lcoal path
        /// </summary>
        private static string FormatPath(string path)
        {
            if (path.StartsWith("~/") || path.StartsWith("/"))
                path = HttpContext.Current.Server.MapPath(path);

            return path;
        }

        /// <summary>
        /// Creates a new directory and file at the specified values. Optioanlly, the new file can be deleted.
        /// </summary>
        private static DirectoryAccess Execute(string path, string fileName, bool delete)
        {
            try
            {
                path = FormatPath(path);

                if (!Directory.Exists(path))
                    CreateDirectory(path);

                string fullPath = Path.Combine(path, fileName);

                StreamWriter sw = new StreamWriter(fullPath);
                sw.Close();

                if (delete)
                    File.Delete(fullPath);

                return DirectoryAccess.Success;
            }
            catch (SecurityException)
            {
                return DirectoryAccess.SecurityException;
            }
            catch (UnauthorizedAccessException)
            {
                return DirectoryAccess.UnauthorizedAccessException;
            }
        }


        [DllImport("kernel32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        public static extern bool CreateDirectory(string path, int lpSecurityAttributes);

        public static bool CreateDirectory(string sPath)
        {
            return CreateDirectory(sPath, 0);
        }

        /// <summary>
        /// 获取文件名称
        /// </summary>
        public static string GetMainName(string sData, string sSeparator)
        {
            if (sData == sSeparator || sData.Length <= sSeparator.Length)
                return "";
            else
            {
                int iPos = sData.Substring(sData.Length - sSeparator.Length) == sSeparator ? sData.LastIndexOf(sSeparator, sData.Length - sSeparator.Length - 1) : sData.LastIndexOf(sSeparator);
                return iPos > -1 ? sData.Substring(0, iPos) : "";
            }
        }

        /// <summary>
        /// 获取文件名称
        /// </summary>
        public static string GetMainName(string sData, char cSeparator)
        {
            if (sData.Length < 2)
                return "";

            int iPos = sData[sData.Length - 1] == cSeparator ? sData.LastIndexOf(cSeparator, sData.Length - 2) : sData.LastIndexOf(cSeparator);
            if (iPos < 0)
                return "";
            else
                return sData.Substring(0, iPos);
        }

        /// <summary>
        /// 获取文件扩展名
        /// </summary>
        public static string GetExtName(string sData, string sSeparator)
        {
            if (sData == sSeparator || sData.Length <= sSeparator.Length)
                return string.Empty;
            else
            {
                int iPos = sData.LastIndexOf(sSeparator);
                if (iPos < 0 || iPos + sSeparator.Length >= sData.Length)
                    return string.Empty;
                else
                    return sData.Substring(iPos + sSeparator.Length);
            }
        }

        /// <summary>
        /// 获取文件扩展名
        /// </summary>
        public static string GetExtName(string sData, char cSeparator)
        {
            int iPos = sData.LastIndexOf(cSeparator);
            if (iPos < 0 || iPos + 1 == sData.Length)
                return string.Empty;
            else
                return sData.Substring(iPos + 1);
        }

        public static long Copy(string sSourDir, string sDistDir)
        {
            return Copy(sSourDir, sDistDir, 0);
        }

        public static long Copy(string sSourDir, string sDistDir, long lCount)
        {
            int k, iBound;
            if (CreateDirectory(sDistDir))
            {
                string[] arySubFile = Directory.GetFiles(sSourDir);
                iBound = arySubFile.GetUpperBound(0);
                for (k = 0; k <= iBound; k++)
                {
                    File.Copy(arySubFile[k], sDistDir + Path.DirectorySeparatorChar.ToString() + GetExtName(arySubFile[k], Path.DirectorySeparatorChar));
                }
                lCount += (iBound + 1);
                string[] arySubDir = Directory.GetDirectories(sSourDir);
                iBound = arySubDir.GetUpperBound(0);
                for (k = 0; k <= iBound; k++)
                {
                    lCount = Copy(arySubDir[k], sDistDir + Path.DirectorySeparatorChar.ToString() + GetExtName(arySubDir[k], Path.DirectorySeparatorChar), lCount);
                }
            }
            return lCount;
        }

    }

    /// <summary>
    /// 目录操作结果
    /// </summary>
    public enum DirectoryAccess
    {
        /// <summary>
        /// 成功
        /// </summary>
        Success = 0,

        /// <summary>
        /// 安全性异常
        /// </summary>
        SecurityException = 1,

        /// <summary>
        /// 未经授权异常
        /// </summary>
        UnauthorizedAccessException = 2
    }

}
