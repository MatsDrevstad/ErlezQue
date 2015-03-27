using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ErlezQue.BillDomain;
using ErlezQue.BullDomain;

namespace ErlezQue
{
    class DbGenerate
    {
        public static void GlobalSettings()
        {
            bool loop = true;

            while (loop)
	        {
                Console.Write(Globals.SqlType + " mode. Ändra? [y/n] ");
                if (Console.ReadLine().Equals("y"))
                {
                    Globals.SqlType = Globals.SwitchSqlType();
                }
                else { loop = false; }
	        }
        }

        public static void Sync()
        {
            try 
	        {	        
                var stopwatch = new Stopwatch();
                stopwatch.Start();

                var bill = new BillEntities();
                var bull = new BullEntities();

                var ordersToSync = bull.Orders
                    .Where(o => o.InvoiceId != null)
                    .Where(o => o.Invoice.Status == "Created");

                foreach (var item in ordersToSync)
	            {
                    bill.Heads.Add(new Head() 
                    {
                        InvoiceNo = item.Invoice.InvoiceNo.ToString(),
                    });
                    bill.SaveChanges();
	            }

                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine();
                Console.WriteLine("OK {0}ms", stopwatch.ElapsedMilliseconds);
                Console.ForegroundColor = ConsoleColor.Gray;
                stopwatch.Stop();
            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(ex.Message + "/r" + ex.InnerException);
            }
            finally
            {
                //proxy.Close();
            }
        }

        public static void StartQue()
        {
            try
            {
                var stopwatch = new Stopwatch();
                stopwatch.Start();

                int x = 1;
                var i = 10;

                while (i-- > -1)
                {
                    x = x / i;
                }
 
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine();
                Console.WriteLine("OK {0}ms", stopwatch.ElapsedMilliseconds);
                Console.ForegroundColor = ConsoleColor.Gray;
                stopwatch.Stop();
            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine();
                Console.WriteLine(ex.Message);

            }
            finally
            {
                //proxy.Close();
            }
        }
    }
}