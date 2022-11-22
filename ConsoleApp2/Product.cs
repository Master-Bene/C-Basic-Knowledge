using System;
using System.Collections.Generic;
using System.IO;
using System.Xml;
using System.Xml.Serialization;

namespace ConsoleApp2
{
    [Serializable]
    //[XmlInclude(typeof(BookProduct))]
    [XmlRoot]
    public class Product
    {
        public int ProductID { set; get; }//默认为[XmlElement("ProductID")] 

        //[XmlAttribute("Discount")]
        public int DisCount { set; get; }


    }

    public class BookProduct : Product
    {
        public BookProduct() { }

        private string _title = null;
        public string ISBN { get; set; }
        public string BookName { get => _title; set => _title = value; }
        public int? Mony { get; set; }
        public DateTime? DateTime { set; get; }
    }

    public class ComputerProduct : Product
    {
        public ComputerProduct() { }
        public string NX { get; set; }
        public int XH { get; set; }
    }

    public class Head
    {
        public Head() { }
        public int HeadId { get; set; }
        public string Title { get; set; }
    }

    [XmlRoot("ViewModel")]
    public class ViewModel<T>
    {
        public Head Head { get; set; }

        [XmlElement(typeof(Product))]
        [XmlElement(typeof(ComputerProduct))]
        [XmlElement(typeof(BookProduct))]
        public T Model { get; set; }
        //[XmlArray("集合列表的名称")]
        //[XmlArrayItem("集合列表中的项的名称")]
        //public List<T> Model { get; set; }

        public override string ToString()
        {
            XmlAttributeOverrides xmlAttributeOverrides = new XmlAttributeOverrides();
            XmlAttributes attributes = new XmlAttributes();
            XmlElementAttribute xmlElementAttribute = new XmlElementAttribute { ElementName = "Data", Type = this.Model.GetType() };
            attributes.XmlElements.Add(xmlElementAttribute);
            xmlAttributeOverrides.Add(typeof(ViewModel<T>), "Model", attributes);

            XmlSerializer serializer = new XmlSerializer(typeof(ViewModel<T>), xmlAttributeOverrides);
            using (StringWriter writer = new StringWriter())
            {
                //XmlSerializerNamespaces _namespaces = new XmlSerializerNamespaces();
                XmlSerializerNamespaces _namespaces = new XmlSerializerNamespaces(new[] { new XmlQualifiedName("", "") });
                serializer.Serialize(writer, this, _namespaces);
                return writer.ToString();
            }
        }
    }
}
