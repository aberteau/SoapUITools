using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using SoapUITools.Xml.Serialization;

namespace SoapUITools.Xml
{
    public class ProjectFileHelper
    {
        public const string ConfigNamespace = "http://eviware.com/soapui/config";

        public static void OrderResourcesByName(string inputPath, String outputPath)
        {
            XDocument xDocument = XDocument.Load(inputPath);
            XElement projectXElement = XmlHelper.GetProjectXElement(xDocument);

            UpdateName(projectXElement);

            IEnumerable<XElement> interfaceXElements = XmlHelper.GetInterfaceXElements(projectXElement);

            foreach (XElement interfaceXElement in interfaceXElements)
            {
                IEnumerable<XElement> resourceXElements = XmlHelper.GetResourceXElements(interfaceXElement);

                Dictionary<string, XElement> xElementByName = resourceXElements.ToDictionary(r => r.Attributes("name").SingleOrDefault().Value, r => r);

                // reorder nodes
                IEnumerable<XElement> orderedNodes = xElementByName.OrderBy(f => f.Key).Select(k => k.Value).ToList();

                interfaceXElement.ReplaceNodes(orderedNodes);
            }

            xDocument.Save(outputPath, SaveOptions.DisableFormatting);
        }

        private static void UpdateName(XElement projectXElement)
        {
            String name = projectXElement.Attributes("name").SingleOrDefault().Value;
            projectXElement.SetAttributeValue("name", $"{name}-Updated");
        }
    }
}
