using System;
using System.Data;

namespace YingNet.Common
{
	/// <summary>
	/// DataReaderHelper 的摘要说明。
	/// </summary>
	public class DataHelper
	{
		public static string SafeField(DataRow row,string fieldName)
		{
			if(row.IsNull(fieldName) || row[fieldName]==null)
			{
				return string.Empty;
			}
			else
			{
				return row[fieldName].ToString();
			}
		}

//		public static string SafeField(IDataReader reader,string fieldName)
//		{
//			if(reader[fieldName]!=null && (reader[fieldName] is DBNull)==false)
//			{
//				return reader[fieldName].toString();
//			}
//			else
//			{
//				return string.Empty;
//			}
//		}

	}
}
