
using System;

namespace YingNet.Serialization
{
    /// <summary>
    /// 序列化数据实体 
    /// </summary>
    /// <remarks>
    /// 封装数据库中序列化的字段
    /// </remarks>
    public struct SerializerData
    {
        /// <summary>
        /// 序列化的属性名称
        /// </summary>
        /// <remarks>一般对应到表中的PropertyNames字段</remarks>
        public string Keys;
        
        /// <summary>
        /// 序列化的属性数据
        /// </summary>
        /// <remarks>一般对应到表中的PropertyValues字段</remarks>
        public string Values;
    }
    
}
