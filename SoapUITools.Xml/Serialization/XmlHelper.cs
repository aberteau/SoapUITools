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

        public static XElement GetProjectXElement(XDocument xDocument)
        {
            XName xName = XName.Get("soapui-project", ConfigNamespace);
            XElement xElement = xDocument.Element(xName);
            return xElement;
        }

        private static Project GetProject(XDocument xDocument)
        {
            XElement xElement = GetProjectXElement(xDocument);
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

        public static IEnumerable<XElement> GetInterfaceXElements(XElement projectXElement)
        {
            XName xName = XName.Get("interface", ConfigNamespace);
            IEnumerable<XElement> xElements = projectXElement.Elements(xName).ToList();
            return xElements;
        }

        private static Interface[] GetInterfaces(XElement projectXElement)
        {
            IEnumerable<XElement> xElements = GetInterfaceXElements(projectXElement);
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

        public static IEnumerable<XElement> GetResourceXElements(XElement interfaceXElement)
        {
            XName xName = XName.Get("resource", ConfigNamespace);
            IEnumerable<XElement> xElements = interfaceXElement.Elements(xName).ToList();
            return xElements;
        }

        private static Resource[] GetResources(XElement interfaceXElement)
        {
            IEnumerable<XElement> xElements = GetResourceXElements(interfaceXElement);
            Resource[] resources = xElements.Select(e => ToResource(e)).ToArray();
            return resources;
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
