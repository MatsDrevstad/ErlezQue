using ErlezQue.Domain;
using ErlezQue.Domain;
using System;

namespace ErlezQue.Messaging.GrossController
{
    public class GrossLineTax : MessageController
    {
        public void Insert(bool saveData, ErlezQue.Domain.LineTax lineTax)
        {
            var bill = new ErlezWebUIEntities();

	        var LineTaxes = new ErlezQue.Domain.LineTax()
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
