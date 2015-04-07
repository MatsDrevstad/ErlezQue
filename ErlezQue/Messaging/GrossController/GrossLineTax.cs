using ErlezQue.BillDomain;
using ErlezQue.BullDomain;
using System;

namespace ErlezQue.Messaging.GrossController
{
    public class GrossLineTax : MessageController
    {
        public void Insert(ErlezQue.BillDomain.LineTax lineTax)
        {
            var bill = new BillEntities();

	        var LineTaxes = new ErlezQue.BillDomain.LineTax()
            {
                LineId = lineTax.LineId,
                LineTaxCount = lineTax.LineTaxCount,
                LineTaxType = lineTax.LineTaxType,
                LineTaxCategory = lineTax.LineTaxCategory,
                LineTaxRate = lineTax.LineTaxRate,
                LineTaxAmount = lineTax.LineTaxAmount,
                ExemptFromTax = lineTax.ExemptFromTax,
            };
            try
            {
                bill.LineTaxes.Add(LineTaxes);
                bill.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
	    }
    }
}
