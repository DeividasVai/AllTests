using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using static System.String;

namespace yml_Testing.XmlParsingResponse
{
    public class DefaultProvider
    {
        private readonly WebService _webService;

        public DefaultProvider(WebService webService)
        {
            _webService = webService;
        }

        public bool TestAlive(bool isAlive)
        {
            var ping = new Random(666).Next(0, 1) == 0 ? "ping" : "pong";
            return ping.ToLower() != ResponseBase.TestAlive(ping, isAlive);
        }

        public string GetEmployee(string xml)
        {
            return _webService.GetEmployee<Employee>(xml);
        }


    }
}
