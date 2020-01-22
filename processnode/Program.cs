using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;

namespace processnode { 

    class Program
    {
        static Process[] allProcesses()
        {
            Process[] processlist = Process.GetProcesses();
            return processlist;
        }
        static void wannaComment(string ans)
        {
            var processlist = allProcesses();

            if (ans == "Y" || ans == "y")
            {
                string comment = null;
                string commentID;
                bool vaneID = false;
                Console.WriteLine("ID to comment to:");
                commentID = Console.ReadLine();

                string[] xmlComment = new string[4];

                foreach (Process theprocess in processlist)
                {
                    if (Convert.ToString(theprocess.Id) == commentID)
                    {
                        vaneID = true;
                        Console.WriteLine("Comment: ");
                        comment = Console.ReadLine();
                        xmlComment[0] = theprocess.ProcessName;
                        xmlComment[1] = Convert.ToString(theprocess.Id);
                        xmlComment[2] = (Convert.ToDouble(theprocess.WorkingSet64) / 100000).ToString("N3") + " K";
                        xmlComment[3] = comment;
                        Xml.writeXml(xmlComment);

                    }
                }
                if (!vaneID) { Console.WriteLine("Nincs ilyen id"); };
            }
        }
        static void listAll()
        {
            var processlist = allProcesses();

            foreach (Process theprocess in processlist)
            {
                if (theprocess.Id != 0)
                {
                    Console.WriteLine("Process: {0} ID: {1} MEM:{2} K", theprocess.ProcessName, theprocess.Id, Convert.ToDouble(theprocess.WorkingSet64) / 100000);

                }
            }
            Console.WriteLine("Number of processes running: {0}", processlist.Length);
        }

        static List<string> saveSession()
        {
            var processlist = allProcesses();
            List<string> arrProc = new List<string>();

            foreach (Process proc in processlist)
            {
                if (proc.Id != 0)
                {
                    arrProc.Add(proc.ProcessName + ";" + Convert.ToString(proc.Id) + ";" + Convert.ToString(proc.WorkingSet64));

                }
            }
            return arrProc;
        }
        static void Main(string[] args)
        {
 
            string ls = null;
            string[] commands = new string[]{"ls - List all processes","ls -l - List the first 10 processes in online mode","kill - kill a process by ID","q - Quit"};

            while (ls != "q")
            {
                //Comands "commands xd"
                Console.Write("User@win10> ");
                ls = Console.ReadLine();
                if (ls == "ls")
                {
                    listAll();
                    Console.WriteLine("Comment? (Y/N)");
                    wannaComment(Console.ReadLine());
                }
                
                if (ls == "ls -l")
                {
                    //Parallel.Invoke(() => ListProcessesByRam.ListProcesses(), () => spin());
                    ListProcessesByRam.ListProcesses();
                }
               
                if (ls == "cls")
                {
                    Console.Clear();
                }
                
                if (ls == "kill")
                {
                    listAll();
                    Console.WriteLine("who you wanna kill dawg?");
                    Console.Write("ID: ");
                    string idToKill = null;
                    idToKill = Console.ReadLine();
                    var processlist = allProcesses();
                    bool haveID = false;
                    
                    try
                    {
                        foreach (Process process in processlist)
                        {
                            if (Convert.ToInt32(idToKill) == process.Id)
                            {
                                haveID = true;
                            }
                            else { haveID = false; }
                        }

                        ConsoleSpinner killAnimation = new ConsoleSpinner();
                        killAnimation.Delay = 1000;

                        Process killable = Process.GetProcessById(Convert.ToInt32(idToKill));
                        Console.WriteLine("Are you sure u wanna kill {0} (y/n)?", killable.ProcessName);
                        string ans = Console.ReadLine();
                        if (ans == "Y" || ans == "y")
                        {
                            killable.Kill();
                            for (int i = 0; i < 4; i++)
                            {
                                killAnimation.Turn("I'm killin it m8", 5);
                            }
                            Console.WriteLine();
                            Console.WriteLine("i think he dieded");
                        }
                        else
                        {
                            Console.WriteLine("{0} survives this time",killable.ProcessName);
                        }
                    }
                    catch (FormatException)
                    {
                        Console.WriteLine("id's in windows are integer numbers m8");
                    }
                    catch (Exception) when (haveID == false)
                    {
                        Console.WriteLine("Nah m8 go fck urself no id like that");
                    }
                                                                                 
                }
                
                if(ls == "save")
                {
                    listAll();
                    Console.WriteLine("Save this session to an XML? (y/n)");
                    string ans = Console.ReadLine();
                    if (ans == "Y" || ans == "y")
                    {
                        Xml.saveXml(saveSession());
                        Console.WriteLine("saved!");
                    }
                    
                }
                
                else
                {
                    Console.WriteLine();
                    for (int i = 0; i < commands.Length; i++)
                    {
                        Console.WriteLine(commands[i]);
                    }
                    Console.WriteLine();
                }               
            }
        }
    }
}
