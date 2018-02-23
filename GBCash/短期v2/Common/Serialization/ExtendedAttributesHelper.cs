using System;
using System.Data;

namespace YingNet.Serialization
{
	/// <summary>
	/// ExtendedAttributesHelper ��ժҪ˵����
	/// </summary>
	public class ExtendedAttributesHelper
	{
		/// <summary>
		/// ��IDataReader���ȡ���л���Ϣ
		/// </summary>
		/// <param name="reader">IDataReader</param>
		/// <returns>SerializerData</returns>
		public static SerializerData PopulateSerializerDataFromIDataReader(IDataReader reader)
		{
			return PopulateSerializerDataFromIDataReader(reader, "PropertyNames", "PropertyValues");
		}

		/// <summary>
		/// ��IDataReader���ȡ���л���Ϣ
		/// </summary>
		/// <param name="reader">IDataReader</param>
		/// <param name="propertyNames">propertyNames�ֶ�����</param>
		/// <param name="propertyValues">propertyValues�ֶ�����</param>        
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
