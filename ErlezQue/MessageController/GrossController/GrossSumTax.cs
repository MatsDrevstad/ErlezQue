using ErlezQue.BillDomain;
using ErlezQue.BullDomain;
using System;

namespace ErlezQue.MessageController.GrossController
{
    public static class GrossSumTax
    {
        public static void Insert(ErlezQue.BillDomain.SumTax sumTax)
        {
            var bill = new BillEntities();

            bill.SumTaxes.Add(new ErlezQue.BillDomain.SumTax()
            {
                PostId = sumTax.PostId,
                SumTaxCount = sumTax.SumTaxCount,
                SumTaxType = sumTax.SumTaxType,
                SumTaxCategory = sumTax.SumTaxCategory,
                SumTaxRate = sumTax.SumTaxRate,
                SumTaxableAmount = sumTax.SumTaxableAmount,
                SumTaxAmount = sumTax.SumTaxAmount,
                TaxCurrencyTaxAmount = sumTax.TaxCurrencyTaxAmount,
            });
            bill.SaveChanges();
        }
    }
}
