
using System;
using System.Collections.Specialized;
using YingNet.Utils;

namespace YingNet.Serialization
{
    /// <summary>
    /// 需要做数据序列化的实体类的基类
    /// </summary>
    /// <remarks>
    /// 需要使用数据序列化的实体类需要从<c>ExtendedAttributes</c>派生，并且保证存储该实体类的表中存在PropertyNames、PropertyValues两个字段
    /// </remarks>    
    [Serializable]
    public class ExtendedAttributes : IExtendedAttributes
    {
        NameValueCollection extendedAttributes = new NameValueCollection();

        /// <summary>
        /// 获取扩展属性（属性不存在时返回空字符串）
        /// </summary>
        /// <param name="name">属性名称</param>
        /// <returns>string类型的属性值</returns>
        public string GetExtendedAttribute(string name)
        {
            string returnValue = extendedAttributes[name];

            if (returnValue == null)
                return string.Empty;
            else
                return returnValue;
        }

        /// <summary>
        /// 设置扩展属性
        /// </summary>
        /// <param name="name">属性名称</param>
        /// <param name="value">属性值</param>
        public void SetExtendedAttribute(string name, string value)
        {
            if ((value == null) || (value == string.Empty))
                extendedAttributes.Remove(name);
            else
                extendedAttributes[name] = value;
        }

        /// <summary>
        /// 扩展属性个数
        /// </summary>
        public int ExtendedAttributesCount
        {
            get { return extendedAttributes.Count; }
        }

        /// <summary>
        /// 获取扩展属性的bool值（当该属性不存在时返回defaultValue）
        /// </summary>
        /// <param name="name">属性名称</param>
        /// <param name="defaultValue">属性不存在时返回的默认值</param>
        /// <returns>bool类型的属性值</returns>
        public bool GetBool(string name, bool defaultValue)
        {
            string b = GetExtendedAttribute(name);
            if (b == null || b.Trim().Length == 0)
                return defaultValue;

            return bool.Parse(b);
        }

        /// <summary>
        /// 获取扩展属性的int值（当该属性不存在时返回defaultValue）
        /// </summary>
        /// <param name="name">属性名称</param>
        /// <param name="defaultValue">属性不存在时返回的默认值</param>
        /// <returns>int类型的属性值</returns>
        public int GetInt(string name, int defaultValue)
        {
            string i = GetExtendedAttribute(name);
            if (i == null || i.Trim().Length == 0)
                return defaultValue;

            return Int32.Parse(i);
        }

        /// <summary>
        /// 获取扩展属性的double值（当该属性不存在时返回defaultValue）
        /// </summary>
        /// <param name="name">属性名称</param>
        /// <param name="defaultValue">属性不存在时返回的默认值</param>
        /// <returns>double类型的属性值</returns>
        public double GetDouble(string name, double defaultValue)
        {
            string i = GetExtendedAttribute(name);
            if (i == null || i.Trim().Length == 0)
                return defaultValue;

            return double.Parse(i);
        }

        /// <summary>
        /// 获取扩展属性的string值（当该属性不存在时返回defaultValue）
        /// </summary>
        /// <param name="name">属性名称</param>
        /// <param name="defaultValue">属性不存在时返回的默认值</param>
        /// <returns>string类型的属性值</returns>
        public string GetString(string name, string defaultValue)
        {
            string v = GetExtendedAttribute(name);
            return (ValueHelper.IsNullOrEmpty(v)) ? defaultValue : v;
        }

        #region Serialization

        /// <summary>
        /// 获取序列化数据
        /// </summary>
        /// <returns><see cref="TunyNet.Serialization.SerializerData"/></returns>
        public SerializerData GetSerializerData()
        {
            SerializerData data = new SerializerData();

            string keys = null;
            string values = null;

            Serializer.ConvertFromNameValueCollection(this.extendedAttributes, ref keys, ref values);
            data.Keys = keys;
            data.Values = values;

            return data;
        }

        /// <summary>
        /// 设置序列化数据
        /// </summary>
        /// <param name="data">需要增加的序列化数据<see cref="TunyNet.Serialization.SerializerData"/></param>
        public void SetSerializerData(SerializerData data)
        {
            if (this.extendedAttributes == null || this.extendedAttributes.Count == 0)
                this.extendedAttributes = Serializer.ConvertToNameValueCollection(data.Keys, data.Values);

            if (this.extendedAttributes == null)
                extendedAttributes = new NameValueCollection();
        }
        #endregion
    }
}
