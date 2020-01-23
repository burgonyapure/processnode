using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Xml.Serialization;

namespace processnode
{
    public class LoadSession
    {
        public List<string> names = new List<string>();
        public List<int> year = new List<int>();
        public List<string> month = new List<string>();
        public List<string> day = new List<string>();
        public List<string> hour = new List<string>();
        public List<string> minute = new List<string>();
        public List<string> second = new List<string>();
        private string path;

        [Serializable()]
        public class Process
        {
            [System.Xml.Serialization.XmlElement("Name")]
            public string Name { get; set; }

            [System.Xml.Serialization.XmlElement("ID")]
            public string ID { get; set; }

            [System.Xml.Serialization.XmlElement("Memory")]
            public string Memory { get; set; }
        }


        [Serializable()]
        [System.Xml.Serialization.XmlRoot("ProcessCollection")]
        public class ProcessCollection
        {
            [XmlArray("Processes")]
            [XmlArrayItem("Process", typeof(Process))]
            public Process[] Process { get; set; }
        }
        public LoadSession()
        {
            path = @"xml\Exported_sessions\";
            DirectoryInfo d = new DirectoryInfo(path);
            foreach (var file in d.GetFiles("*.xml"))
            {
                string fname = Path.GetFileName(Convert.ToString(file));
                names.Add(fname);
                fname = fname.Split('.')[0];
                //20200123104001
                year.Add(Convert.ToInt32(fname.Substring(0,4)));
                month.Add(fname.Substring(4, 2));
                day.Add(fname.Substring(6, 2));
                hour.Add(fname.Substring(8, 2));
                minute.Add(fname.Substring(10, 2));
                second.Add(fname.Substring(12, 2));
            }
        }

        public void doIt(int idx)
        {
            ConsoleSpinner load = new ConsoleSpinner();
            load.Delay = 1000;

            try
            {
                string file2open = path + names[idx - 1];
                for (int i = 0; i < 4; i++)
                {
                    load.Turn("Loadin ", 6);
                }
                Console.WriteLine();
                //Console.WriteLine(names[idx-1]);

                
                //string file2open = @"C:\Users\teszt\source\repos\processnode\processnode\xml\Exported_sessions\20200123102052.xml";
                ProcessCollection processes = null;
                string xmlPath = file2open;

                XmlSerializer serializer = new XmlSerializer(typeof(ProcessCollection));

                StreamReader reader = new StreamReader(xmlPath);
                processes = (ProcessCollection)serializer.Deserialize(reader);
                reader.Close();
                Diplay.PrintLine();
                for (int i = 0; i < processes.Process.Length; i++)
                {
                    Diplay.PrintRow(new string[] { processes.Process[i].Name, processes.Process[i].ID, processes.Process[i].Memory });
                    Diplay.PrintLine();
                }

            }
            catch (ArgumentOutOfRangeException)
            {
                for (int i = 0; i < 4; i++)
                {
                    load.Turn("Loadin ",7);
                }
                Console.WriteLine("Reason: No Id like that");
            }
            

        }
    }
}
