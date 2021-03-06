﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace processnode
{
    public class ConsoleSpinner
    {
        static string[,] sequence = null;

        public int Delay { get; set; } = 200;

        int totalSequences = 0;
        int counter;

        public ConsoleSpinner()
        {
            counter = 0;

            sequence = new string[,] {
            { "/", "-", "\\", "|","/", "-", "\\", "|"/*,".","","","","","",""*/ },
            { ".", "o", "0", "o",".","","",""/*,"","",""*/ },
            { "+", "x","+","x",".","","",""/*,"","","" */ },
            { "V", "<", "^", ">",".","","",""/*,"","","" */ },
            { ".   ", "..  ", "... ", "....",".","","",""/*,"","","" */ },
            { "=>        ", "==>       ", "===>      ", "====>     ","=====>    ","======>    ","=======>  ","\t   IT DED"/*,"","","" */ },
            { "=>        ", "==>       ", "===>      ", "====>     ","=====>    ","======>    ","=======>  ","\t  SUCCESS" },
            { "=>        ", "==>       ", "===>      ", "====>     ","=====>    ","======>    ","=======>  ","\t   FAILED"/*,"","","" */ },
            { "=>   ", "==>  ", "===>", "====>","=====>","=======>","========>","=========>"/*,"","","" */},
            
            //{"I love python","i Love python","i lOve python","i loVe python","i lovE python","i love Python","i love pYthon","i love pyThon","i love pytHon","i love pythOn","i love pythoN" },
            //Jöhet még ide
            };

            totalSequences = sequence.GetLength(0);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sequenceCode"> 0 - simple | 1 - circle | 2 - somethin |3 | 4 | 5 - DED | 6 - SUCCESS | 7 - FAILED </param>
        public void Turn(string displayMsg = "", int sequenceCode = 0)
        {
            counter++;

            Thread.Sleep(Delay);

            sequenceCode = sequenceCode > totalSequences - 1 ? 0 : sequenceCode;

            int counterValue = counter % 8;

            string fullMessage = displayMsg + sequence[sequenceCode, counterValue];
            int msglength = fullMessage.Length;
            
            Console.Write(fullMessage);
            Console.SetCursorPosition(Console.CursorLeft - msglength, Console.CursorTop);
        }
    }
}
