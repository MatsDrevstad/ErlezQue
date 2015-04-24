using ErlezQue.Domain;
using ErlezQue.Domain;
using System;

namespace ErlezQue.Messaging.GrossController
{
    public class GrossAlc : MessageController
    {
        public void Insert(bool saveData, ErlezQue.Domain.Alc alc)
        {
            var bill = new ErlezWebUIEntities();

            var Alcs = new ErlezQue.Domain.Alc()
            {
                PostId = alc.PostId,
                AlcCount = alc.AlcCount,
                AlcType = alc.AlcType,
                Type = alc.Type,
                Percentage = alc.Percentage,
                BaseAmount = alc.BaseAmount,
                Amount = alc.Amount,
                TaxType = alc.TaxType,
                TaxCategory = alc.TaxCategory,
                TaxRate = alc.TaxRate,
                TaxAmount = alc.TaxAmount,
            };
	        try 
	        {
	            bill.Alcs.Add(Alcs);
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
