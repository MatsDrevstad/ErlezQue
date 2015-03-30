using ErlezQue.BillDomain;
using ErlezQue.BullDomain;
using System;

namespace ErlezQue.MessageController.GrossController
{
    public static class GrossLineRef
    {
        public static void Insert(ErlezQue.BillDomain.LineRef lineRef)
        {
            var bill = new BillEntities();

            bill.LineRefs.Add(new ErlezQue.BillDomain.LineRef()
            {
                LineId = lineRef.LineId,
                LineRefCount = lineRef.LineRefCount,
                LineRefQual = lineRef.LineRefQual,
                LineRef1 = lineRef.LineRef1,
                LineRefLin = lineRef.LineRefLin,
                LineRefDate = lineRef.LineRefDate,
            });
            bill.SaveChanges();
        }
    }
}
