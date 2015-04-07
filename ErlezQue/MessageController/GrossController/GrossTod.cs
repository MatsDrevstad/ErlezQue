using ErlezQue.BillDomain;
using ErlezQue.BullDomain;
using System;

namespace ErlezQue.MessageController.GrossController
{
    public static class GrossTod
    {
        public static void Insert(ErlezQue.BillDomain.Tod tod)
        {
            var bill = new BillEntities();

	        var Tods = new ErlezQue.BillDomain.Tod()
            {
                PostId = tod.PostId,
                TodCount = tod.TodCount,
                TodTerms = tod.TodTerms,
                TodDescription = tod.TodDescription,
                TodTermsLoc = tod.TodTermsLoc,
            };
	        try
	        {
	            bill.Tods.Add(Tods);
	            bill.SaveChanges();
	        }
	        catch (Exception ex)
	        {
	            throw ex;
	        }
        }
    }
}
