using ErlezQue.BillDomain;
using ErlezQue.BullDomain;
using System;

namespace ErlezQue.MessageController.GrossController
{
    public static class GrossLineAlc
    {
        public static void Insert(ErlezQue.BillDomain.LineAlc lineAlc)
        {
            var bill = new BillEntities();

            bill.LineAlcs.Add(new ErlezQue.BillDomain.LineAlc()
            {
                LineId = lineAlc.LineId,
                LineAlcCount = lineAlc.LineAlcCount,
                AlcType = lineAlc.AlcType,
                Type = lineAlc.Type,
                Percentage = lineAlc.Percentage,
                Amount = lineAlc.Amount,
                TaxType = lineAlc.TaxType,
                TaxCategory = lineAlc.TaxCategory,
                TaxRate = lineAlc.TaxRate,
                TaxAmount = lineAlc.TaxAmount,
                BaseAmount = lineAlc.BaseAmount,
            });
            bill.SaveChanges();
        }
    }
}
