using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace yml_Testing.XmlParsingResponse
{
    public class WebService
    {
        private const string StatusError = "error";
        private const string StatusOk = "success";

        public Data Data { get; private set; }


        public WebService()
        {
            Data = new Data();
        }

        public string GetEmployee<T>(string xml)
        {
            try
            {
                var parsedResponse = ParseXml(XDocument.Parse(xml));

                switch (parsedResponse["function"])
                {
                    case "GET_Employee":
                        Employee emp = null;
                        emp = Data.GetEmployee(parsedResponse["id"]);

                        xml = $"<cxml1.0>\n";
                        xml += emp == null ? $"     <status>{StatusError}</status>\n" : $"     <status>{StatusOk}</status>\n";
                        xml += emp == null ? $"     <message>Could not find it</status>\n" : $"     <message>Found it!</status>\n";

                        if (emp != null)
                        {
                            xml += $"     <content>\n" +
                                   $"        <entry>\n" +
                                   $"            <id>{emp.Id}</id>\n" +
                                   $"            <name>{emp.Name}</name>\n" +
                                   $"            <code>{emp.Code}</code>\n" +
                                   $"        </entry>\n" +
                                   $"    </content>\n";
                        }

                        xml += $"</cxml1.0>\n";
                        break;
                }

                return xml;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        /*
         * func (xml)
         *      find function -> string function
         *      make dicktionary from params -> {code, value}
         *      switch -> database call function(dicktionary)
         *
         *
         * func ("<function>get_employee</function><params><id>54</id></params>")
         * string function *magic* = get_employee
         * dicktionary params *magic* = {id: 54}
         * switch
         * ...
         * ...
         *      Database.GetEmployee(params)
         *
         * class Db
         *      public static List<employee> employees = {
         *              fjwoefoiwej
         *          wefkoewpfkpwoe
         *      };
         *
         *      public employee GetEmployee(params)
         *          employees.find(... by params.id)
         */



        public Dictionary<string, string> ParseXml(XDocument xdoc)
        {
            Dictionary<string, string> dict = new Dictionary<string, string>();
            foreach (var body in from element in xdoc.Descendants()
                                 select new
                                 {
                                     Tag = element.Name.LocalName,
                                     Value = element.Value
                                 })
            {
                dict.Add(body.Tag, body.Value);
            }
            return dict;
        }
    }
}
