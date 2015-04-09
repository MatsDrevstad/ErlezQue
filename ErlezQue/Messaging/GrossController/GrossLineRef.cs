using ErlezQue.BillDomain;
using ErlezQue.BullDomain;
using System;

namespace ErlezQue.Messaging.GrossController
{
    public class GrossLineRef : MessageController
    {
        public void Insert(bool saveData, ErlezQue.BillDomain.LineRef lineRef)
        {
            var bill = new BillEntities();

    	    var LineRefs = new ErlezQue.BillDomain.LineRef()
            {
                LineId = lineRef.LineId,
                LineRefCount = lineRef.LineRefCount,
                LineRefQual = lineRef.LineRefQual,
                LineRef1 = lineRef.LineRef1,
                LineRefLin = lineRef.LineRefLin,
                LineRefDate = lineRef.LineRefDate,
            };
            try
            {
                bill.LineRefs.Add(LineRefs);
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
