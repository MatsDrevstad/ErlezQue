using ErlezQue.Messaging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ErlezQue.Messaging
{
    public class MessageController
    {
        public static void PrintStatus(Stopwatch stopwatch, int _elementCount = 0)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\nOK {0}ms", stopwatch.ElapsedMilliseconds);
            Console.WriteLine("Antal rader: {0}", _elementCount);
            Console.ForegroundColor = ConsoleColor.Gray;
            stopwatch.Stop();
        }

        public static void PrintError(Exception ex)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("\n" + ex.Message + "\r" + ex.InnerException);
        }

        public static void PrintError(String str)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("\n" + str);
        }

        public static string MatchGrossFormat(string str, string pattern, object obj)
        {
            var regex = new Regex(pattern, RegexOptions.IgnoreCase);
            if (!regex.IsMatch(str))
            {
                PrintError("Varning, Formatfel: " + obj.ToString() + " '" + pattern + "'");
            }
            return str;
        }
    }
}
