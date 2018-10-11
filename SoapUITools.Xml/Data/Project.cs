using System;
using System.Collections.Generic;
using System.Text;

namespace SoapUITools.Xml.Data
{
    public class Project
    {
        public string Name { get; set; }

        public Interface[] Interfaces { get; set; }   
    }
}
