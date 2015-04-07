﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ErlezQue.BillDomain;
using ErlezQue.BullDomain;
using ErlezQue.Mapper.Invoice;
using System.Threading;

namespace ErlezQue.Messaging.Esap20
{
    class Esap20 : MessageController
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

        public static void Sync(bool saveData)
        {
            try 
	        {	        
                var stopwatch = new Stopwatch();
                stopwatch.Start();

                var ediInvoice = new EdiInvoice();
                var elementCount = ediInvoice.Sync(saveData);

                PrintStatus(stopwatch, elementCount);
            }
            catch (Exception ex)
            {
                PrintError(ex);
            }
            finally
            {

            }
        }

        public static void StartQue()
        {
            try
            {
                while (true)
                {
                    Sync(true);
                    Thread.Sleep(5000);
                }
            }
            catch (Exception ex)
            {
                PrintError(ex);
            }
            finally
            {

            }
        }
    }
}