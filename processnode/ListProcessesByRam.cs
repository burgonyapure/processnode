using System;
using System.Collections.Generic;
using System.Text;
using System.Diagnostics;
using System.Linq;
using System.Threading;

namespace processnode
{
    
    class ListProcessesByRam
    {
        public static void ListProcesses()
        {
            ConsoleSpinner spinIt = new ConsoleSpinner();
            spinIt.Delay = 400;
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

                    //double sum = 0;

                    /* foreach (KeyValuePair<string, long> kvp in keyValuePairs)
                     {
                         Console.WriteLine("{0} | {1}",kvp.Key, (Convert.ToDouble(kvp.Value)/1048576).ToString("N4")+" MB");
                         sum += kvp.Value / 1048576;
                     }
                     //Console.WriteLine("\nUsed: "+Convert.ToDouble(sum/1024).ToString("N3")+" MB of 16GB");
                     */

                    var myList = keyValuePairs.ToList();
                    myList.Sort((pair1, pair2) => pair1.Value.CompareTo(pair2.Value));

                    for (int i = myList.Count - 1; i >= myList.Count - 10; i--)
                    {
                        Console.Write("{0} || {1}", myList[i].Key, (Convert.ToDouble(myList[i].Value) / 1048576).ToString("N4") + " MB\n");

                    }
                    Console.SetCursorPosition(0, Console.CursorTop - 10);
                    Thread.Sleep(1000);
                    Console.Clear();
                    /*while (true)
                    {
                        Console.SetCursorPosition(10, Console.CursorTop);
                        spinIt.Turn(displayMsg: "Nagyon mérek mo ", sequenceCode: 2);
                        break;
                    }
                    */
                    
                    
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
