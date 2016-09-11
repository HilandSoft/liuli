

using System;
namespace YingNet.Serialization
{
    /// <summary>
    /// 需要做数据序列化的实体类的接口
    /// </summary>
    public interface IExtendedAttributes
    {
        /// <summary>
        /// 序列化字段数目
        /// </summary>
        int ExtendedAttributesCount { get; }
        
        //处理某一个扩展字段
        
        /// <summary>
        /// 获取扩展属性（属性不存在时返回空字符串）
        /// </summary>
        /// <param name="name">属性名称</param>
        /// <returns>string类型的属性值</returns>
        string GetExtendedAttribute(string name);
        
        /// <summary>
        /// 设置扩展属性
        /// </summary>
        /// <param name="name">属性名称</param>
        /// <param name="value">属性值</param>
        void SetExtendedAttribute(string name, string value);

        bool GetBool(string name, bool defaultValue);
        int GetInt(string name, int defaultValue);
        double GetDouble(string name, double defaultValue);
        string GetString(string name, string defaultValue);

        //处理所有的扩展字段(一次将写入到扩展字段/从扩展字段读取)
        
        /// <summary>
        /// 获取序列化数据
        /// </summary>
        /// <returns></returns>
        SerializerData GetSerializerData();

        /// <summary>
        /// 设置序列化数据
        /// </summary>
        /// <param name="data">需要增加的序列化数据</param>
        void SetSerializerData(SerializerData data);
    }
}
