

using System;
using System.IO;
using System.Collections.Specialized;
using System.Globalization;
using System.Security;
using System.Security.Permissions;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Xml;
using System.Xml.Serialization;
using YingNet.Utils;

namespace YingNet.Serialization
{
    /// <summary>
    /// 序列化工具类
    /// </summary>
    public class Serializer
    {
        //Do not allow this class to be instantiated
        private Serializer()
        { }

        /// <summary>
        /// Static Constructor is used to set the CanBinarySerialize value only once for the given security policy
        /// </summary>
        static Serializer()
        {
            SecurityPermission sp = new SecurityPermission(SecurityPermissionFlag.SerializationFormatter);
            try
            {
                sp.Demand();
                CanBinarySerialize = true;
            }
            catch (SecurityException)
            {
                CanBinarySerialize = false;
            }
        }

        /// <summary>
        /// 是否可以序列化成二进制格式（只读）
        /// </summary>
        public static readonly bool CanBinarySerialize;

        /// <summary>
        /// 把.net 对象转换成byte[]
        /// </summary>
        /// <param name="objectToConvert">被转换的对象</param>
        /// <returns>byte[]（如果CanBinarySerialize=false，则返回null）</returns>
        public static byte[] ConvertToBytes(object objectToConvert)
        {
            byte[] byteArray = null;

            if (CanBinarySerialize)
            {
                BinaryFormatter binaryFormatter = new BinaryFormatter();
                using (MemoryStream ms = new MemoryStream())
                {
                    binaryFormatter.Serialize(ms, objectToConvert);

                    // Set the position	of the MemoryStream	back to	0
                    //
                    ms.Position = 0;

                    // Read	in the byte	array
                    //
                    byteArray = new Byte[ms.Length];
                    ms.Read(byteArray, 0, byteArray.Length);
                    ms.Close();
                }
            }
            return byteArray;
        }

        /// <summary>
        /// 把.net对象以二进制格式存储在磁盘上        
        /// </summary>
        /// <param name="objectToSave">被存储的对象</param>
        /// <param name="path">存储的路径</param>
        /// <returns>如果存储成功则返回true，否则返回false</returns>
        public static bool SaveAsBinary(object objectToSave, string path)
        {
            if (objectToSave != null && CanBinarySerialize)
            {
                byte[] ba = ConvertToBytes(objectToSave);
                if (ba != null)
                {
                    using (FileStream fs = new FileStream(path, FileMode.OpenOrCreate, FileAccess.Write))
                    {
                        using (BinaryWriter bw = new BinaryWriter(fs))
                        {
                            bw.Write(ba);
                            return true;
                        }
                    }
                }
            }
            return false;
        }


        /// <summary>
        /// 把.net对象转换成xml
        /// </summary>
        /// <param name="objectToConvert">被转换的对象</param>
        /// <returns>xml格式的string</returns>
        public static string ConvertToString(object objectToConvert)
        {
            string xml = null;
            if (objectToConvert != null)
            {
                //we need the type to serialize
                Type t = objectToConvert.GetType();

                XmlSerializer ser = new XmlSerializer(t);
                //will hold the xml
                using (StringWriter writer = new StringWriter(CultureInfo.InvariantCulture))
                {
                    ser.Serialize(writer, objectToConvert);
                    xml = writer.ToString();
                    writer.Close();
                }
            }

            return xml;
        }

        /// <summary>
        /// 把.net对象以xml格式存储在磁盘上        
        /// </summary>
        /// <param name="objectToSave">被存储的对象</param>
        /// <param name="path">存储的路径</param>
        /// <returns>如果存储成功则返回true，否则返回false</returns>
        public static void SaveAsXML(object objectToSave, string path)
        {
            if (objectToSave != null)
            {
                //we need the type to serialize
                Type t = objectToSave.GetType();

                XmlSerializer ser = new XmlSerializer(t);
                //will hold the xml
                using (StreamWriter writer = new StreamWriter(path))
                {
                    ser.Serialize(writer, objectToSave);
                    writer.Close();
                }
            }

        }


        /// <summary>
        /// 把byte[]反序列化成.net对象
        /// </summary>
        /// <remarks>If the array is null or empty, it will return null. 注意实际使用时对转换结果进行类型转换</remarks>
        /// <param name="byteArray">被转换的byte[]</param>
        /// <returns>The byte array converted to an object or null if the value of byteArray is null or empty</returns>
        public static object ConvertToObject(byte[] byteArray)
        {
            object convertedObject = null;
            if (CanBinarySerialize && byteArray != null && byteArray.Length > 0)
            {
                BinaryFormatter binaryFormatter = new BinaryFormatter();
                using (MemoryStream ms = new MemoryStream())
                {
                    ms.Write(byteArray, 0, byteArray.Length);

                    // Set the memory stream position to the beginning of the stream
                    //
                    ms.Position = 0;

                    if (byteArray.Length > 4)
                        convertedObject = binaryFormatter.Deserialize(ms);

                    ms.Close();
                }
            }
            return convertedObject;
        }

        /// <summary>
        /// 把文件反序列化成.net对象（文件存储数据为xml）
        /// </summary>
        /// <param name="path">被反序列化的文件</param>
        /// <param name="objectType">反序列化的类型</param>
        /// <returns>object</returns>
        public static object ConvertFileToObject(string path, Type objectType)
        {
            object convertedObject = null;

            if (path != null && path.Length > 0)
            {
                using (FileStream fs = new FileStream(path, FileMode.Open, FileAccess.Read))
                {
                    XmlSerializer ser = new XmlSerializer(objectType);
                    convertedObject = ser.Deserialize(fs);
                    fs.Close();
                }
            }
            return convertedObject;
        }


        /// <summary>
        /// 把xml的字符串反序列化成.net对象
        /// </summary>
        /// <param name="xml">被反序列化的xml字符串</param>
        /// <param name="objectType">反序列化的类型</param>
        /// <returns>object</returns>
        public static object ConvertToObject(string xml, Type objectType)
        {
            object convertedObject = null;

            if (!ValueHelper.IsNullOrEmpty(xml))
            {
                using (StringReader reader = new StringReader(xml))
                {
                    XmlSerializer ser = new XmlSerializer(objectType);
                    convertedObject = ser.Deserialize(reader);
                    reader.Close();
                }
            }
            return convertedObject;
        }

        /// <summary>
        /// 把XmlNode反序列化成.net对象
        /// </summary>
        /// <param name="node">被反序列化的XmlNode</param>
        /// <param name="objectType">反序列化的类型</param>
        /// <returns>object</returns>
        public static object ConvertToObject(XmlNode node, Type objectType)
        {
            object convertedObject = null;
            if (node != null)
            {
                using (StringReader reader = new StringReader(node.OuterXml))
                {
                    XmlSerializer ser = new XmlSerializer(objectType);
                    convertedObject = ser.Deserialize(reader);
                    reader.Close();
                }
            }
            return convertedObject;
        }

        /// <summary>
        /// 把二进制文件反序列化成.net对象
        /// </summary>
        /// <param name="path">被反序列化的文件路径</param>
        /// <returns>object</returns>
        public static object LoadBinaryFile(string path)
        {
            if (!File.Exists(path))
                return null;

            using (FileStream fs = new FileStream(path, FileMode.Open, FileAccess.Read))
            {
                BinaryReader br = new BinaryReader(fs);
                byte[] ba = new byte[fs.Length];
                br.Read(ba, 0, (int)fs.Length);
                return ConvertToObject(ba);
            }
        }

        /// <summary>
        /// Creates a NameValueCollection from two string. The first contains the key pattern and the second contains the values
        /// spaced according to the kys
        /// </summary>
        /// <param name="keys">Keys for the namevalue collection</param>
        /// <param name="values">Values for the namevalue collection</param>
        /// <returns>A NameValueCollection populated based on the keys and vaules</returns>
        /// <example>
        /// string keys = "key1:S:0:3:key2:S:3:4:";
        /// string values = "1234567";
        /// This would result in a NameValueCollection with two keys (Key1 and Key2) with the values 123 and 4567
        /// </example>
        public static NameValueCollection ConvertToNameValueCollection(string keys, string values)
        {
            NameValueCollection nvc = new NameValueCollection();

            if (keys != null && values != null && keys.Length > 0 && values.Length > 0)
            {
                char[] splitter = new char[1] { ':' };
                string[] keyNames = keys.Split(splitter);

                for (int i = 0; i < (keyNames.Length / 4); i++)
                {
                    int start = int.Parse(keyNames[(i * 4) + 2], CultureInfo.InvariantCulture);
                    int len = int.Parse(keyNames[(i * 4) + 3], CultureInfo.InvariantCulture);
                    string key = keyNames[i * 4];

                    //Future version will support more complex types	
                    if (((keyNames[(i * 4) + 1] == "S") && (start >= 0)) && (len > 0) && (values.Length >= (start + len)))
                    {
                        nvc[key] = values.Substring(start, len);
                    }
                }
            }

            return nvc;
        }

        /// <summary>
        /// Creates a the keys and values strings for the simple serialization based on a NameValueCollection
        /// </summary>
        /// <param name="nvc">NameValueCollection to convert</param>
        /// <param name="keys">the ref string will contain the keys based on the key format</param>
        /// <param name="values">the ref string will contain all the values of the namevaluecollection</param>
        public static void ConvertFromNameValueCollection(NameValueCollection nvc, ref string keys, ref string values)
        {
            if (nvc == null || nvc.Count == 0)
                return;

            StringBuilder sbKey = new StringBuilder();
            StringBuilder sbValue = new StringBuilder();

            int index = 0;
            foreach (string key in nvc.AllKeys)
            {
                if (key.IndexOf(':') != -1)
                    throw new ArgumentException("ExtendedAttributes Key can not contain the character \":\"");

                string v = nvc[key];
                if (!ValueHelper.IsNullOrEmpty(v))
                {
                    sbKey.AppendFormat("{0}:S:{1}:{2}:", key, index, v.Length);
                    sbValue.Append(v);
                    index += v.Length;
                }
            }
            keys = sbKey.ToString();
            values = sbValue.ToString();
        }
    }
}
