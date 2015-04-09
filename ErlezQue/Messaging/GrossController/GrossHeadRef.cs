using ErlezQue.BillDomain;
using ErlezQue.BullDomain;
using System;

namespace ErlezQue.Messaging.GrossController
{
    public class GrossHeadRef : MessageController
    {
        public void Insert(bool saveData, ErlezQue.BillDomain.HeadRef headRef)
        {
            var bill = new BillEntities();

	    var HeadRefs = new ErlezQue.BillDomain.HeadRef()
            {
                PostId = headRef.PostId,
                HeadRefCount = headRef.HeadRefCount,
                HeadRefQual = headRef.HeadRefQual,
                HeadRef1 = headRef.HeadRef1,
                HeadRefDate = headRef.HeadRefDate,
            };
            try
            {
                bill.HeadRefs.Add(HeadRefs);
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
