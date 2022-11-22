using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace ConsoleApp2
{
    public static class SimpleSerializer
    {
        public static string ToXml<T>(this T obj)
        {
            if (obj == null) throw new NullReferenceException();

            XmlSerializer serializer = new XmlSerializer(typeof(T));

            using (StringWriter writer = new StringWriter())
            {
                //XmlSerializerNamespaces _namespaces = new XmlSerializerNamespaces();
                XmlSerializerNamespaces _namespaces = new XmlSerializerNamespaces(new[] { new XmlQualifiedName("", "") });
                serializer.Serialize(writer, obj, _namespaces);
                return writer.ToString();
            }
        }

        public static string ToXml2<T>(this T obj)
        {
            if (obj == null) throw new NullReferenceException();

            XmlSerializer serializer = new XmlSerializer(typeof(T));
            MemoryStream ms = new MemoryStream();
            //设置序序化XML格式
            XmlWriterSettings xws = new XmlWriterSettings();
            xws.Indent = true;
            xws.OmitXmlDeclaration = true;
            xws.Encoding = Encoding.UTF8;
            XmlWriter xtw = XmlTextWriter.Create(ms, xws);
            //去掉要结点的 xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance" xmlns:xsd="http://www.w3.org/2001/XMLSchema" 属性

            XmlSerializerNamespaces _namespaces = new XmlSerializerNamespaces(new[] { new XmlQualifiedName("", "") });
            serializer.Serialize(xtw, obj, _namespaces);
            ms.Position = 0;
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(ms);

            XmlDeclaration xmlDecl = xmlDoc.CreateXmlDeclaration("1.0", "utf-8", null);
            xmlDoc.InsertBefore(xmlDecl, xmlDoc.DocumentElement);
            return xmlDoc.OuterXml;


        }

    }

    public class NullToEmptyStringResolver : CamelCasePropertyNamesContractResolver
    {
        /// <summary>
        /// 创建属性
        /// </summary>
        /// <param name="type">类型</param>
        /// <param name="memberSerialization">序列化成员</param>
        /// <returns></returns>
        protected override IList<JsonProperty> CreateProperties(Type type, MemberSerialization memberSerialization)
        {
            return type.GetProperties().Select(c =>
            {
                var jsonProperty = base.CreateProperty(c, memberSerialization);
                jsonProperty.ValueProvider = new NullToEmptyStringValueProvider(c);
                return jsonProperty;
            }).ToList();
        }
    }

    public class NullToEmptyStringValueProvider : IValueProvider
    {
        private readonly PropertyInfo _memberInfo;
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="memberInfo"></param>
        public NullToEmptyStringValueProvider(PropertyInfo memberInfo)
        {
            _memberInfo = memberInfo;
        }

        /// <summary>
        /// 获取Value
        /// </summary>
        /// <param name="target"></param>
        /// <returns></returns>
        public object GetValue(object target)
        {
            var result = _memberInfo.GetValue(target);
            if (_memberInfo.PropertyType == typeof(string) && result == null)
                result = string.Empty;
            return result;
        }

        /// <summary>
        /// 设置Value
        /// </summary>
        /// <param name="target"></param>
        /// <param name="value"></param>
        public void SetValue(object target, object value)
        {
            _memberInfo.SetValue(target, value);
        }

    }

}
