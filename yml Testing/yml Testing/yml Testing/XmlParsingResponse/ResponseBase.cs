using System;
using System.Collections.Generic;
using System.Text;

namespace yml_Testing.XmlParsingResponse
{
    public static class ResponseBase
    {
        public static string TestAlive(string ping, bool iAmAlive)
        {
            if (iAmAlive)
                return ping.ToLower() == "ping" ? "pong" : "ping";
            
            return ping.ToLower() == "ping" ? "ping" : "pong";
        }
    }
}
