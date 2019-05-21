using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace yml_Testing.XmlParsingResponse
{
    [XmlTypeAttribute(AnonymousType = true)]
    public class Employee
    {
        [XmlElement("id")]
        public string Id { get; set; }

        [XmlElement("name")]
        public string Name { get; set; }

        [XmlElement("code")]
        public string Code { get; set; }

    }
}
