using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace ErlezQue
{
    class QueApplication
    {
        public QueApplication()
        {
            Console.WindowHeight = 50;
            Console.WindowWidth = 120;
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.WriteLine("Välkomment till Erlez Que");
            Console.ForegroundColor = ConsoleColor.Gray;

            bool loop = true;
            while (loop)
            {
                PrintMenuOptions();
                loop = HandleMenuOptions(loop);
            }
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.WriteLine();
            Console.WriteLine("Välkommen tillbaka");
            Thread.Sleep(500);
        }

        public bool HandleMenuOptions(bool loop)
        {
            Console.Write("Input:\t");
            Console.ForegroundColor = ConsoleColor.Yellow;
            string input = Console.ReadLine();
            Console.ForegroundColor = ConsoleColor.Gray;

            if (input.Equals("1")) { DbGenerate.GlobalSettings(); }
            if (input.Equals("2")) { DbGenerate.Sync(); }
            if (input.Equals("3")) { DbGenerate.StartQue(); }

            if (input.Equals("0")) { loop = false; }

            return loop;
        }

        private void PrintMenuOptions()
        {
            Console.ForegroundColor = ConsoleColor.Gray; 
            Console.WriteLine();
            Console.Write("Start\t");
            Console.WriteLine("[1] Inställningar");
            Console.Write("\t");
            Console.WriteLine("[2] Synkronisera nu");
            Console.Write("\t");
            Console.WriteLine("[3] Starta kö");
            Console.WriteLine();
            Console.WriteLine("\t[0] EXIT");
            Console.WriteLine();
        }
    }
}
