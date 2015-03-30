using ErlezQue.BillDomain;
using ErlezQue.BullDomain;
using System;

namespace ErlezQue.MessageController.GrossController
{
    public static class GrossLineTax
    {
        public static void Insert(ErlezQue.BillDomain.LineTax lineTax)
        {
            var bill = new BillEntities();

            bill.LineTaxes.Add(new ErlezQue.BillDomain.LineTax()
            {
                LineId = lineTax.LineId,
                LineTaxCount = lineTax.LineTaxCount,
                LineTaxType = lineTax.LineTaxType,
                LineTaxCategory = lineTax.LineTaxCategory,
                LineTaxRate = lineTax.LineTaxRate,
                LineTaxAmount = lineTax.LineTaxAmount,
                ExemptFromTax = lineTax.ExemptFromTax,
            });
            bill.SaveChanges();
        }
    }
}
