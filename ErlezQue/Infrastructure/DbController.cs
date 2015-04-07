using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Data;
using System.Text.RegularExpressions;
using System.Threading;

namespace ErlezQue.Infrastructure
{
    class DbController
    {
        public static void CreateTables()
        {
            var context = new DbContext();

            try
            {
                var stopwatch = new Stopwatch();
                stopwatch.Start();
                SqlCommand[] command = new SqlCommand[4];
                command[0] = new SqlCommand(DbDesign.dropBill, context.GetConnection());
                command[1] = new SqlCommand(DbDesign.createBill, context.GetConnection());
                command[2] = new SqlCommand(DbDesign.createTrigger1, context.GetConnection());
                command[3] = new SqlCommand(DbDesign.createTrigger2, context.GetConnection());

                context.Open();
                foreach (var item in command)
                {
                    item.ExecuteNonQuery();
                    Thread.Sleep(100);
                }
                PrintStatus(stopwatch);

            }
            catch (Exception ex)
            {
                PrintError(ex);
            }
            finally
            {
                context.Close();
            }
        }

        public static void SetCreated()
        {
            var context = new DbContext("Bull");

            try
            {
                var stopwatch = new Stopwatch();
                stopwatch.Start();
                var command = new SqlCommand("UPDATE Invoice SET Status = 'Created'", context.GetConnection());

                context.Open();
                command.ExecuteNonQuery();
                PrintStatus(stopwatch);

            }
            catch (Exception ex)
            {
                PrintError(ex);
            }
            finally
            {
                context.Close();
            }
        }

        private static void PrintStatus(Stopwatch stopwatch, int _elementCount = 0)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\nOK {0}ms", stopwatch.ElapsedMilliseconds);
            Console.WriteLine("Antal rader: {0}", _elementCount);
            Console.ForegroundColor = ConsoleColor.Gray;
            stopwatch.Stop();
        }

        private static void PrintError(Exception ex)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("\n" + ex.Message + "\r" + ex.InnerException);
        }
    }
}