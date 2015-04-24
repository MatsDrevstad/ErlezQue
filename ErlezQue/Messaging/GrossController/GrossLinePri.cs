using ErlezQue.Domain;
using ErlezQue.Domain;
using System;

namespace ErlezQue.Messaging.GrossController
{
    public class GrossLinePri : MessageController
    {
        public void Insert(bool saveData, ErlezQue.Domain.LinePri linePri)
        {
            var bill = new ErlezWebUIEntities();

    	    var LinePris = new ErlezQue.Domain.LinePri()
            {
                LineId = linePri.LineId,
                LinePriCount = linePri.LinePriCount,
                PriceQualifier = linePri.PriceQualifier,
                PriceType = linePri.PriceType,
                PriceTypeQualifier = linePri.PriceTypeQualifier,
                LinePri1 = linePri.LinePri1,
                LinePriBase = linePri.LinePriBase,
                LineUnit = linePri.LineUnit,
            };
            try
            {
                bill.LinePris.Add(LinePris);
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
