using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Linq;
using System.Xml;
using System.IO;
using System.Linq;
using System.Collections;

namespace processnode
{
    class Xml
    {
        private static void ModifyXml(string path,string strTextToInsert, int iInsertAtLineNumber)
        {
            ArrayList lines = new ArrayList();
            StreamReader rdr = new StreamReader(path);
            string line;
            while ((line = rdr.ReadLine()) != null) lines.Add(line);

            rdr.Close();

            if (lines.Count > iInsertAtLineNumber)lines.Insert(iInsertAtLineNumber,strTextToInsert);
            else lines.Add(strTextToInsert);

            StreamWriter wrtr = new StreamWriter(path);

            foreach (string strNewLine in lines) wrtr.WriteLine(strNewLine);

            wrtr.Close();
        }
        public static void saveXml(List<string> arrProc)
        {
            //Generate some unique names, based on the time of creation.
            //This name can be used backwards, to tell the user when this was created.
            string fileName;
            fileName = DateTime.Now.ToString("yyyy") + DateTime.Now.ToString("MM") + DateTime.Now.ToString("dd") +DateTime.Now.ToString("HH") + DateTime.Now.ToString("mm") + DateTime.Now.ToString("ss");

            var filePath = @"xml\Exported_sessions\"+fileName + ".xml";
            XElement newDoc = new XElement("Processes");
            //newDoc.Add(new XElement("Processes"));
            newDoc.Save(filePath);
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
            }
            xmlDoc.Save(filePath);

            ModifyXml(filePath, "<ProcessCollection>", 1);
            using (StreamWriter sw = File.AppendText(filePath))
            {
                sw.Write("</ProcessCollection>");
            }
        }
        public static void writeXml(string[] xmlComment) {
            var filePath = @"xml\comment.xml";
            var xmlDoc = XDocument.Load(filePath);

            var parentElement = new XElement("Process");
            var nameElement = new XElement("Name", xmlComment[0]);
            var idElement = new XElement("ID", xmlComment[1]);
            var firstNameElement = new XElement("Memory", xmlComment[2]);
            var lastNameElement = new XElement("Comment", xmlComment[3]);

            parentElement.Add(nameElement);
            parentElement.Add(idElement);
            parentElement.Add(firstNameElement);
            parentElement.Add(lastNameElement);

            var rootElement = xmlDoc.Element("Processes");
            rootElement?.Add(parentElement);

            xmlDoc.Save(filePath);

        }
    }
}