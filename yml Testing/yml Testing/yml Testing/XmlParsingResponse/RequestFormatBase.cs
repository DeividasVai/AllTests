using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace yml_Testing.XmlParsingResponse
{
    [XmlRoot("cxml1.0")]
    public class RequestFormatBase<T>
    {
        [XmlElement("language")]
        public string Language { get; set; }

        [XmlElement("function")]
        public string Function { get; set; }

        [XmlElement("params")]
        public Employee Params { get; set; }
    }
}
