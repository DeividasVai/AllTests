using System;
using yml_Testing.XmlParsingResponse;

namespace yml_Testing
{
    class Program
    {
        static void Main(string[] args)
        {
            // Localization ======================================================
            //I18N i18n = I18N.Load("lt");
            // Does return prevent from finally block ============================
            //try
            //{
            //    Console.Out.WriteLineAsync($"This is a try catch block.");
            //    return;
            //}
            //finally
            //{
            //    Console.Out.WriteLineAsync($"And this is a FINALLY block");
            //    Console.Read();
            //}
            // WebServices =======================================================
            WebService ws = new WebService();
            var dp = new DefaultProvider(ws);

            var ats = Console.ReadLine()?.ToLower() == "t";

            if (!dp.TestAlive(ats))
            {
                Console.Out.WriteLine("<cxml1.0>\r\n  <status>error</status>\r\n  <message type=\"error\">Couldn't connect</message>\r\n</cxml1.0>");
                return;
            }

            MakeSpace(5);
            string xmlEmployee = $"<cxml1.0>\n" +
                                 $"    <header>\n" +
                                 $"        <language>LT</language>\n" +
                                 $"        <function>GET_Employee</function>\n" +
                                 $"        <params>\n" +
                                 $"            <id>{Console.ReadLine()}</id>\n" +
                                 $"        </params>\n" +
                                 $"    </header>\n" +
                                 $"</cxml1.0>\n";
            Console.Out.WriteLineAsync(dp.GetEmployee(xmlEmployee));
            MakeSpace(5);

            Console.ReadLine();
        }

        static void MakeSpace(int times)
        {
            for (var i = 0; i < times; i++)
                Console.Out.WriteLineAsync();
        }
    }
}
