using ErlezQue.Domain;
using ErlezQue.Domain;
using System;

namespace ErlezQue.Messaging.GrossController
{
    public class GrossEnclosure : MessageController
    {
        public void Insert(bool saveData, ErlezQue.Domain.Enclosure enclosure)
        {
            var bill = new ErlezWebUIEntities();

            var Enclosures = new ErlezQue.Domain.Enclosure()
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
