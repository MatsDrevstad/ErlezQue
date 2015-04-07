using ErlezQue.BillDomain;
using ErlezQue.BullDomain;
using System;

namespace ErlezQue.Messaging.GrossController
{
    public class GrossSumTax : MessageController
    {
        public void Insert(ErlezQue.BillDomain.SumTax sumTax)
        {
            var bill = new BillEntities();

	        var SumTaxes = new ErlezQue.BillDomain.SumTax()
            {
                PostId = sumTax.PostId,
                SumTaxCount = sumTax.SumTaxCount,
                SumTaxType = sumTax.SumTaxType,
                SumTaxCategory = sumTax.SumTaxCategory,
                SumTaxRate = sumTax.SumTaxRate,
                SumTaxableAmount = sumTax.SumTaxableAmount,
                SumTaxAmount = sumTax.SumTaxAmount,
                TaxCurrencyTaxAmount = sumTax.TaxCurrencyTaxAmount,
            };
	        try
	        {
	            bill.SumTaxes.Add(SumTaxes);
	            bill.SaveChanges();
	        }
	        catch (Exception ex)
	        {
	            throw ex;
            }
	    }
    }
}
