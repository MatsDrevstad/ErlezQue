using ErlezQue.BillDomain;
using ErlezQue.BullDomain;
using System;

namespace ErlezQue.Messaging.GrossController
{
    public class GrossEnclosure : MessageController
    {
        public void Insert(ErlezQue.BillDomain.Enclosure enclosure)
        {
            var bill = new BillEntities();

            var Enclosures = new ErlezQue.BillDomain.Enclosure()
            {
                PostId = enclosure.PostId,
                EnclosureCount = enclosure.EnclosureCount,
                MediaType = enclosure.MediaType,
                FileName = enclosure.FileName,
                FileCreationDate = enclosure.FileCreationDate,
                EnclosedDataFormat = enclosure.EnclosedDataFormat,
                EnclosedData = enclosure.EnclosedData,
            };
            try
            {
                bill.Enclosures.Add(Enclosures);
                bill.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
