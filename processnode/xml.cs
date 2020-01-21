using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Linq;
using System.IO;

namespace processnode
{
    class xml
    {
        public static void writeXml() {
            DateTime nev = DateTime.Now;
            string xml_name = Convert.ToString(nev.Year) + Convert.ToString(nev.Month) + Convert.ToString(nev.Day) + Convert.ToString(nev.Hour) + Convert.ToString(nev.Minute) + Convert.ToString(nev.Second);
            
            StreamWriter xmlKi = new StreamWriter(@"C:\Users\teszt\source\repos\processnode\processnode\xml\"+xml_name);
            xmlKi.WriteLine(new XElement("Process", new XAttribute("ProcessName", "/process ID/"), new XElement("Comment", "/Comment/")));
            xmlKi.Close();
            
        }
    }
}