using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using SoapUITools.Xml.Data;

namespace SoapUITools.Xml.Serialization
{
    public class XmlHelper
    {
        private const string ConfigNamespace = "http://eviware.com/soapui/config";

        public static Project GetProject(string xmlDoc)
        {
            XDocument xDocument = XDocument.Load(xmlDoc);
            Project project = GetProject(xDocument);
            return project;
        }

        #region Project

        private static Project GetProject(XDocument xDocument)
        {
            XName xName = XName.Get("soapui-project", ConfigNamespace);
            XElement xElement = xDocument.Element(xName);

            Project project = ToProject(xElement);

            return project;
        }

        private static Project ToProject(XElement xElement)
        {
            Project project = new Project();
            project.Name = xElement.Attributes("name").SingleOrDefault().Value;
            project.Interfaces = GetInterfaces(xElement);
            return project;
        }

        #endregion

        #region Interface

        private static Interface[] GetInterfaces(XElement projectXElement)
        {
            XName xName = XName.Get("interface", ConfigNamespace);
            IEnumerable<XElement> xElements = projectXElement.Elements(xName).ToList();
            Interface[] interfaces = xElements.Select(e => ToInterface(e)).ToArray();
            return interfaces;
        }

        private static Interface ToInterface(XElement xElement)
        {
            Interface i = new Interface();
            i.Resources = GetResources(xElement);
            return i;
        }

        #endregion

        #region Resource

        private static Resource[] GetResources(XElement interfaceXElement)
        {
            XName xName = XName.Get("resource", ConfigNamespace);
            IEnumerable<XElement> xElements = interfaceXElement.Elements(xName).ToList();
            Resource[] interfaces = xElements.Select(e => ToResource(e)).ToArray();
            return interfaces;
        }

        private static Resource ToResource(XElement xElement)
        {
            Resource resource = new Resource();
            string idValue = xElement.Attributes("id").SingleOrDefault().Value;
            resource.Id = new Guid(idValue);
            resource.Name = xElement.Attributes("name").SingleOrDefault().Value;
            resource.Path = xElement.Attributes("path").SingleOrDefault().Value;
            return resource;
        }

        #endregion
    }
}
