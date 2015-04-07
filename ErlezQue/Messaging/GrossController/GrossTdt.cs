using ErlezQue.BillDomain;
using ErlezQue.BullDomain;
using System;

namespace ErlezQue.Messaging.GrossController
{
    public class GrossTdt : MessageController
    {
        public void Insert(ErlezQue.BillDomain.Tdt tdt)
        {
            var bill = new BillEntities();

	        var Tdts = new ErlezQue.BillDomain.Tdt()
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
	            bill.SaveChanges();
	        }
	        catch (Exception ex)
	        {
	            throw ex;
            }
	    }
    }
}
