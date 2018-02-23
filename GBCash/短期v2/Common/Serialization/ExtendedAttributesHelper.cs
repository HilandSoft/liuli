using System;
using System.Data;

namespace YingNet.Serialization
{
	/// <summary>
	/// ExtendedAttributesHelper 的摘要说明。
	/// </summary>
	public class ExtendedAttributesHelper
	{
		/// <summary>
		/// 从IDataReader里获取序列化信息
		/// </summary>
		/// <param name="reader">IDataReader</param>
		/// <returns>SerializerData</returns>
		public static SerializerData PopulateSerializerDataFromIDataReader(IDataReader reader)
		{
			return PopulateSerializerDataFromIDataReader(reader, "PropertyNames", "PropertyValues");
		}

		/// <summary>
		/// 从IDataReader里获取序列化信息
		/// </summary>
		/// <param name="reader">IDataReader</param>
		/// <param name="propertyNames">propertyNames字段名称</param>
		/// <param name="propertyValues">propertyValues字段名称</param>        
		/// <returns>SerializerData</returns>
		public static SerializerData PopulateSerializerDataFromIDataReader(IDataReader reader, string propertyNames, string propertyValues)
		{
			SerializerData data = new SerializerData();

			if (reader[propertyNames] == DBNull.Value)
				data.Keys = string.Empty;
			else
				data.Keys = Convert.ToString(reader[propertyNames]);

			if (reader[propertyValues] == DBNull.Value)
				data.Values = string.Empty;
			else
				data.Values = Convert.ToString(reader[propertyValues]);

			return data;
		}
	}
}
