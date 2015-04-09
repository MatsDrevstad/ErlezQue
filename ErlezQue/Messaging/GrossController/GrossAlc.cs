using ErlezQue.BillDomain;
using ErlezQue.BullDomain;
using System;

namespace ErlezQue.Messaging.GrossController
{
    public class GrossAlc : MessageController
    {
        public void Insert(bool saveData, ErlezQue.BillDomain.Alc alc)
        {
            var bill = new BillEntities();

            var Alcs = new ErlezQue.BillDomain.Alc()
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
