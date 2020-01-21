using System;
using System.Diagnostics;
using System.Threading.Tasks;

namespace processnode { 
    class Program
    {
        static void Main(string[] args)
        {
 
            Process[] processlist = Process.GetProcesses();
            string ls = null;
            string[] commands = new string[]{"ls - List all processes","q - quit"};

            while (ls != "q")
            {
                Console.Write("User@win10> ");
                ls = Console.ReadLine();
               
                if (ls == "ls")
                {
                    foreach (Process theprocess in processlist)
                    {
                        if (theprocess.Id != 0)
                        {
                            Console.WriteLine("Process: {0} ID: {1} MEM:{2} K", theprocess.ProcessName, theprocess.Id, Convert.ToDouble(theprocess.WorkingSet64)/100000);

                        }
                    }
                    Console.WriteLine("Number of processes running: {0}", processlist.Length);
                    Console.WriteLine("Comment? (Y/N)");
                    string ans;
                    ans = Console.ReadLine();
                    if (ans == "Y" || ans == "y")
                    {
                        string comment = null;
                        string commentID;
                        bool vaneID = false;
                        Console.WriteLine("ID to comment to:");
                        commentID = Console.ReadLine();

                        string[] xmlComment = new string[4];

                        foreach(Process theprocess in processlist)
                        {
                            if (Convert.ToString(theprocess.Id) == commentID)
                            {
                                vaneID = true;
                                Console.WriteLine("Comment: ");
                                comment = Console.ReadLine();
                                xmlComment[0] = theprocess.ProcessName;
                                xmlComment[1] = Convert.ToString(theprocess.Id);
                                xmlComment[2] =(Convert.ToDouble(theprocess.WorkingSet64)/100000).ToString("N3")+" K";
                                xmlComment[3] =comment;
                                xml.writeXml(xmlComment);
                                
                            } 
                        }
                        if (!vaneID) { Console.WriteLine("Nincs ilyen id")};
                    }
                }           
                else
                {
                    for (int i = 0; i < commands.Length; i++)
                    {
                        Console.WriteLine(commands[i]);
                    }
                }               
            }
        }
    }
}
