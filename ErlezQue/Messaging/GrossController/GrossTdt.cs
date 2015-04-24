using ErlezQue.Domain;
using ErlezQue.Domain;
using System;

namespace ErlezQue.Messaging.GrossController
{
    public class GrossTdt : MessageController
    {
        public void Insert(bool saveData, ErlezQue.Domain.Tdt tdt)
        {
            var bill = new ErlezWebUIEntities();

	        var Tdts = new ErlezQue.Domain.Tdt()
            {
                PostId = tdt.PostId,
                TdtCount = tdt.TdtCount,
                TdtMethod = tdt.TdtMethod,
                TdtDescription = tdt.TdtDescription,
                TdtCarrierName = tdt.TdtCarrierName,
            };
	        try
	        {
	            bill.Tdts.Add(Tdts);
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
