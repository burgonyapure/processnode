using System;
using System.Diagnostics;

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
                            Console.WriteLine("Process: {0} ID: {1} CPU: asd", theprocess.ProcessName, theprocess.Id);
                        }
                    }
                    Console.WriteLine("Number of processes running: {0}", processlist.Length);
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
