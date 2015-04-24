using ErlezQue.Domain;
using System;

namespace ErlezQue.Messaging.GrossController
{
    public class GrossTod : MessageController
    {
        public void Insert(bool saveData, ErlezQue.Domain.Tod tod)
        {
            var bill = new ErlezWebUIEntities();

	        var Tods = new ErlezQue.Domain.Tod()
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
