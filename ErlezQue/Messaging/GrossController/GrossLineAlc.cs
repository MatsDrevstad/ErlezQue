using ErlezQue.BillDomain;
using ErlezQue.BullDomain;
using System;

namespace ErlezQue.Messaging.GrossController
{
    public class GrossLineAlc : MessageController
    {
        public void Insert(ErlezQue.BillDomain.LineAlc lineAlc)
        {
            var bill = new BillEntities();

    	    var LineAlcs = new ErlezQue.BillDomain.LineAlc()
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
            };
            try
            {
                bill.LineAlcs.Add(LineAlcs);
                bill.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
	    }
    }
}
