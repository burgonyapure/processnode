using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Linq;
using System.Xml;
using System.IO;

namespace processnode
{
    class xml
    {
        public static void saveXml(List<string> arrProc)
        {
            var filePath = @"C:\Users\teszt\source\repos\processnode\processnode\xml\Processes.xml";
            var xmlDoc = XDocument.Load(filePath);
            for (int i = 0; i < arrProc.Count; i++)
            {
                var parentElement = new XElement("Process");
                var nameElement = new XElement("Name", arrProc[i].Split(';')[0]);
                var idElement = new XElement("ID", arrProc[i].Split(';')[1]);
                var firstNameElement = new XElement("Memory", arrProc[i].Split(';')[2]);

                parentElement.Add(nameElement);
                parentElement.Add(idElement);
                parentElement.Add(firstNameElement);
                var rootElement = xmlDoc.Element("Processes");
                rootElement?.Add(parentElement);
                xmlDoc.Save(filePath);
            }          
        }
        public static void writeXml(string[] xmlComment) {
            var filePath = @"C:\Users\teszt\source\repos\processnode\processnode\xml\comment.xml";
            var xmlDoc = XDocument.Load(filePath);
            var parentElement = new XElement("Process",new XAttribute(xmlComment[0],xmlComment[1]));
            var firstNameElement = new XElement("Memory", xmlComment[2]);
            var lastNameElement = new XElement("Comment", xmlComment[3]);

            parentElement.Add(firstNameElement);
            parentElement.Add(lastNameElement);

            var rootElement = xmlDoc.Element("Processes");
            rootElement?.Add(parentElement);

            xmlDoc.Save(filePath);

        }
    }
}