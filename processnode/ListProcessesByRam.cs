using System;
using System.Collections.Generic;
using System.Text;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace processnode
{
    
    class ListProcessesByRam
    {
        public static void ListProcesses()
        {
            ConsoleSpinner spinIt = new ConsoleSpinner();
            spinIt.Delay = 200;
            while (true)
            {
                if (!Console.KeyAvailable)
                {
                    Dictionary<string, long> keyValuePairs = new Dictionary<string, long>();
                    Process[] processes = Process.GetProcesses();
                    foreach (Process process in processes)
                    {
                        if (keyValuePairs.ContainsKey(process.ProcessName))
                        {
                            keyValuePairs[process.ProcessName] += process.WorkingSet64;
                        }
                        else { keyValuePairs.Add(process.ProcessName, process.WorkingSet64); }
                    }
                    

                    var myList = keyValuePairs.ToList();
                    myList.Sort((pair1, pair2) => pair1.Value.CompareTo(pair2.Value));

                    for (int i = myList.Count - 1; i >= myList.Count - 10; i--)
                    {
                        Console.Write("{0} | {1}", myList[i].Key, (Convert.ToDouble(myList[i].Value) / (1024*1024)).ToString("N4") + " MB\n");
                    }
                    Console.WriteLine();
                    spinIt.Turn("Workin In Online Mode boi ", 0);
                    Console.SetCursorPosition(0, Console.CursorTop - 11);
                    
                }
                else
                {
                    Console.Clear();
                    break;
                }
            }
        }
    }
}
