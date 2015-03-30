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

            bill.Tods.Add(new ErlezQue.BillDomain.Tod()
            {
                PostId = tod.PostId,
                TodCount = tod.TodCount,
                TodTerms = tod.TodTerms,
                TodDescription = tod.TodDescription,
                TodTermsLoc = tod.TodTermsLoc,
            });
            bill.SaveChanges();
        }
    }
}
