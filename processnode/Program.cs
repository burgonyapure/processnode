using System;
using System.Diagnostics;

namespace processnode
{
    class Program
    {
        static void Main(string[] args)
        {
            Process[] processlist = Process.GetProcesses();

            foreach (Process theprocess in processlist)
            {
                Console.WriteLine("Process: {0} ID: {1}", theprocess.ProcessName, theprocess.Id);
               
            }
            Console.ReadLine();
        }
    }
}
