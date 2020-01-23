using System;
using System.Collections.Generic;
using System.Text;

namespace processnode
{
    public class Diplay
    {
        static int tableWidth = 90;
        public static void PrintLine()
        {
            Console.WriteLine(new string('-', tableWidth));
        }
        public static void PrintRow(params string[] columns)
        {
            int width = (tableWidth - columns.Length) / columns.Length;
            string row = "|";

            foreach (string column in columns)
            {
                row += AlignCentre(column, width) + "|";
            }

            Console.WriteLine(row);
        }
        public static string AlignCentre(string text, int width)
        {
            text = text.Length > width ? text.Substring(0, width - 3) + "..." : text;
            if (string.IsNullOrEmpty(text))
            {
                return new string(' ', width);
            }
            else
            {
                return text.PadRight(width - (width - text.Length) / 2).PadLeft(width);
            }
        }

        public static void PrintMenu(string[] options, string title)
        {
            Console.WriteLine(title + ":");
            Console.WriteLine("-----------------------\n");
            for (int i = 0; i < options.Length; i++)
            {
                Console.WriteLine("\t{0}. {1}", i + 1, options[i]);
            }
            Console.WriteLine("\tq. Quit");
        }
    }
}
