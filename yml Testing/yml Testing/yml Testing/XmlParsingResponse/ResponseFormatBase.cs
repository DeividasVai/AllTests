using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace yml_Testing.XmlParsingResponse
{
    [XmlRoot("cxml1.0")]
    public class ResponseFormatBase<T>
    {
        [XmlElement("status")]
        public string Status { get; set; }

        [XmlElement("message")]
        public string Message { get; set; }

        [XmlElement("content")]
        public T Content { get; set; }
    }
}
