using ErlezQue.Domain;
using System;

namespace ErlezQue.Messaging.GrossController
{
    public class GrossSumTax : MessageController
    {
        public void Insert(bool saveData, ErlezQue.Domain.SumTax sumTax)
        {
            var bill = new ErlezWebUIEntities();

	        var SumTaxes = new ErlezQue.Domain.SumTax()
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
	            if(saveData)
	               	bill.SaveChanges();
	        }
	        catch (Exception ex)
	        {
	            throw ex;
            }
	    }
    }
}
