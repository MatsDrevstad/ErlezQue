using ErlezQue.Domain;
using ErlezQue.Domain;
using System;

namespace ErlezQue.Messaging.GrossController
{
    public class GrossB04 : MessageController
    {
        public void Insert(bool saveData, ErlezQue.Domain.LineAlc lineAlc)
        {
            var bill = new ErlezWebUIEntities();

    	    var LineAlcs = new ErlezQue.Domain.LineAlc()
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
