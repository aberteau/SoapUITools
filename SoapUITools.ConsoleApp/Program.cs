using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SoapUITools.Xml;
using SoapUITools.Xml.Definitions;
using SoapUITools.Xml.Serialization;

namespace SoapUITools.ConsoleApp
{
    class Program
    {
        private const string Path = @"C:\Users\amael.berteau\OneDrive\Projets\SoapUITools\Technique\Examples\EasyNanny-WebAPI-soapui-project.xml";

        static void Main(string[] args)
        {
            Project project = XmlSerializer.Deserialize(Path);

            Console.ReadLine();
        }
    }
}
