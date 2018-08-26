using System;
using Arendelle.Safety.OCSOCalls.Core.Interfaces;
using System.Xml.Serialization;

namespace Arendelle.Safety.OCSOCalls.Orange
{
    [XmlRoot(ElementName = "CALLS")]
    public class Document
    {
        [XmlElement(ElementName = "CALL")]
        public Call[] Calls { get; set; }
    }

    public class Call : ICall
    {
        public Call()
        {
        }

        [XmlAttribute(AttributeName = "INCIDENT")]
        public int ID { get; set; }

        [XmlElement(ElementName = "DESC")]
        public string Description { get; set; }

        [XmlElement(ElementName = "ENTRYTIME")]
        public string Entry { get; set; }

        [XmlElement(ElementName = "LOCATION")]
        public string Location { get; set; }

        [XmlElement(ElementName = "SECTOR")]
        public string Sector { get; set; }

        [XmlElement(ElementName = "ZONE")]
        public string Zone { get; set; }

        [XmlElement(ElementName = "RD")]
        public string RD { get; set; }
    }
}
