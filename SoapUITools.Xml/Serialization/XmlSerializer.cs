using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Xml.Serialization;
using SoapUITools.Xml.Definitions;

namespace SoapUITools.Xml.Serialization
{
    public class XmlSerializer
    {
        public static Project Deserialize(string path)
        {
            System.Xml.Serialization.XmlSerializer serializer = new System.Xml.Serialization.XmlSerializer(typeof(Project));

            StreamReader reader = new StreamReader(path);
            reader.ReadToEnd();
            Project project = (Project)serializer.Deserialize(reader);
            reader.Close();

            return project;
        }
    }
}
