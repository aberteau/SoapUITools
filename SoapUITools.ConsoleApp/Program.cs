using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SoapUITools.Xml;
using SoapUITools.Xml.Data;
using SoapUITools.Xml.Definitions;
using SoapUITools.Xml.Serialization;

namespace SoapUITools.ConsoleApp
{
    class Program
    {
        private const string Path = @"E:\UserData\amael\OneDrive\Projets\SoapUITools\Technique\Examples\EasyNanny-WebAPI-soapui-project.xml";
        private const string OutputPath = @"E:\UserData\amael\OneDrive\Projets\SoapUITools\Technique\Tests\EasyNanny-WebAPI-soapui-project.xml";

        static void Main(string[] args)
        {
            //Xml.Definitions.Project project = XmlSerializer.Deserialize(Path);
            //Xml.Data.Project project = XmlHelper.GetProject(Path);
            ProjectFileHelper.OrderResourcesByName(Path, OutputPath);
            Console.ReadLine();
        }
    }
}
