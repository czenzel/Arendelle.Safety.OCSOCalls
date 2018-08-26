using System;
using System.Collections.Generic;
using System.Text;
using System.Net;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Arendelle.Safety.OCSOCalls.Orange
{
    public static class Client
    {
        private static Uri Source
        {
            get;
        } = new Uri(@"https://www.ocso.com/portals/0/CFS_FEED/activecalls.xml");

        // TODO : Complete the Map for Orange County FL
        public static Map Mapping
        {
            get;
        } = new Map();

        public static Call[] GetActive()
        {
            var objClient = new WebClient();
            objClient.Headers.Add(HttpRequestHeader.UserAgent, @"Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/68.0.3440.106 Safari/537.36");
            objClient.Headers.Add(HttpRequestHeader.Referer, @"https://www.ocso.com/calls-for-service");

            var bResult = objClient.DownloadData(Source);
            var objMemory = new System.IO.MemoryStream(bResult);

            var objXml = new XmlSerializer(typeof(Document));
            var objResults = (Document)objXml.Deserialize(objMemory);

            var aCalls = objResults.Calls;
            return aCalls;
        }
    }
}
