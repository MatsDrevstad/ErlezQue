using ErlezQue.Domain;
using System;

namespace ErlezQue.Messaging.GrossController
{
    public class GrossB02 : MessageController
    {
        public void Insert(bool saveData, ErlezQue.Domain.HeadRef headRef)
        {
            var bill = new ErlezWebUIEntities();

	    var HeadRefs = new ErlezQue.Domain.HeadRef()
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
