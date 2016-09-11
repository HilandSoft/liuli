//<copyright>山东三维科技有限公司 1999-2004</copyright>
//<version>V1.0</verion>
//<createdate>2004-3-12</createdate>
//<author>wangyh</author>
//<email>wangyh@qingdaojob.com</email>
//<log date="2004-3-12">创建</log>
//<log date="2004-8-31">将sql数据库的数据库连接设为Pooling=false</log>

using System;

namespace YingNet.Common.Database {
    /// <summary>
    /// DBOperate的工厂类
    /// </summary>
    public class DBOperatorFactory {
        //根据需要再增加其它类型的数据库标志
        /// <summary>
        /// SQL SERVER
        /// </summary>
        public const int MSSQLSERVER = 1;
        /// <summary>
        /// MS Access
        /// </summary>
        public const int MSACCESS = 2;

        /// <summary>
        /// Excel数据库
        /// </summary>
        public const int Excel = 3;
       /* const int DB2 = 4;
        const int MYSQL = 5;
        const int FXOPRO = 6;
        */

        public enum DataBaseTYPE
        {
            MSSQLSERVER = 1,
            MSACCESS = 2,
            MSEXCEL = 3
        };

        /// <summary>
        /// 构造器
        /// </summary>
        public DBOperatorFactory() {
        }

	
        /// <summary>
        /// 获取正确的数据库连接==========如果要扩展支持的数据库类型，需要改动此方法
        /// </summary>
        /// <param name="strConnection"></param>
        /// <param name="iDBType"></param>
        /// <returns></returns>
        public static DBOperate GetDBOperator(string strConnection,int iDBType) {
            try {
                //根据不同的数据库返回相应的连接
                if(strConnection.Equals(null) || strConnection.Equals("")) {
                    return null;
                } else {
                    switch(iDBType) {
                        case MSSQLSERVER:
                            return new SqlDBOperate(strConnection);
                        case MSACCESS:
                            return new OleDBOperate(strConnection);
                        case Excel:
                            return new ODBCDBOperate(strConnection);
                        default:
                            return null;
                    }
                }
            } catch {
                return null;
            }
        }

        public static DBOperate GetDBOperator(string strConnection)
        {
            return GetDBOperator(strConnection,DataBaseTYPE.MSSQLSERVER);
        }

        public static DBOperate GetDBOperator(string strConnection, DataBaseTYPE dataBaseType)
        {
            try
            {
                //根据不同的数据库返回相应的连接
                if (strConnection.Equals(null) || strConnection.Equals(""))
                {
                    return null;
                }
                else
                {
                    switch (dataBaseType)
                    {
                        case DataBaseTYPE.MSSQLSERVER:
                            return new SqlDBOperate(strConnection);
                        case DataBaseTYPE.MSACCESS:
                            return new OleDBOperate(strConnection);
                        case DataBaseTYPE.MSEXCEL:
                            return new ODBCDBOperate(strConnection);
                        default:
                            return null;
                    }
                }
            }
            catch
            {
                return null;
            }
        }
        
        /// <summary>
        /// 获取正确的数据库连接==========如果要扩展支持的数据库类型，需要改动此方法
        /// </summary>
        /// <param name="strDBServer"></param>
        /// <param name="strDBName"></param>
        /// <param name="strDBUser"></param>
        /// <param name="strDBPwd"></param>
        /// <param name="iDBType"></param>
        public static DBOperate GetDBOperator(string strDBServer,string strDBName, string strDBUser, string strDBPwd, int iDBType) {
            string strCon = "";
            switch(iDBType) {
                case MSSQLSERVER:
                    strCon = "data source="+strDBServer+";initial catalog="+strDBName+";persist security info=False;"+
                        "user id="+strDBUser+";password="+strDBPwd+";packet size=4096;Pooling=false";
                    break;
                case MSACCESS:
                    strCon = "Provider=Microsoft.Jet.OLEDB.4.0;Password='"+strDBPwd+"';User ID="+strDBUser
                        +";Data Source="+strDBName+";Mode=Share Deny None;Extended Properties='';Jet OLEDB:System database='';Jet OLEDB:Registry Path='';Jet OLEDB:Database Password='';Jet OLEDB:Engine Type=5;Jet OLEDB:Database Locking Mode=1;Jet OLEDB:Global Partial Bulk Ops=2;Jet OLEDB:Global Bulk Transactions=1;Jet OLEDB:New Database Password='';Jet OLEDB:Create System Database=False;Jet OLEDB:Encrypt Database=False;Jet OLEDB:Don't Copy Locale on Compact=False;Jet OLEDB:Compact Without Replica Repair=False;Jet OLEDB:SFP=False";
                    break;
                case Excel:
                    strCon = "Driver={Microsoft Excel Driver (*.xls)};DBQ=" + strDBName + ";";
                    break;
                default:
                    strCon = "";
                    break;
            }
            return GetDBOperator(strCon,iDBType);
        }

    }//类结束
}//命名空间结束