﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using ErlezQue.Infrastructure;
using ErlezQue.Messaging.Esap20;

namespace ErlezQue
{
    class QueApplication
    {
        public QueApplication()
        {
            Console.WindowHeight = 40;
            Console.WindowWidth = 100;
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
            Thread.Sleep(222);
        }

        public bool HandleMenuOptions(bool loop)
        {
            Console.Write("Input:\t");
            Console.ForegroundColor = ConsoleColor.Yellow;
            string input = Console.ReadLine();
            Console.ForegroundColor = ConsoleColor.Gray;

            if (input.Equals("4")) { Esap20.Settings(); }
            if (input.Equals("5")) { Esap20.Sync(false); }
            if (input.Equals("6")) { Esap20.Sync(true); }
            if (input.Equals("7")) { Esap20.StartQue(); }
            if (input.Equals("8")) { DbController.CreateTables(); }
            if (input.Equals("9")) { DbController.SetCreated(); }

            if (input.Equals("0")) { loop = false; }

            return loop;
        }

        private void PrintMenuOptions()
        {
            Console.ForegroundColor = ConsoleColor.Gray; 
            Console.Write("\nESAP6\t");
            Console.WriteLine("[1] Inställningar");
            Console.Write("\t");
            Console.WriteLine("[2] Synkronisera nu");
            Console.Write("\t");
            Console.WriteLine("[3] Starta kö");
            Console.WriteLine();
            Console.Write("ESAP20\t");
            Console.WriteLine("[4] Inställningar");
            Console.Write("\t");
            Console.WriteLine("[5] Kör test på data");
            Console.Write("\t");
            Console.WriteLine("[6] Synkronisera nu");
            Console.Write("\t");
            Console.WriteLine("[7] Starta kö");
            Console.WriteLine();
            Console.Write("DB\t");
            Console.WriteLine("[8] Truncate Bill");
            Console.WriteLine("\t[9] Set Created Bull");
            Console.WriteLine("\n\t[0] EXIT");
            Console.WriteLine();
        }
    }
}
