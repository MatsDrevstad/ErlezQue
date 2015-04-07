using ErlezQue.BillDomain;
using ErlezQue.BullDomain;
using System;

namespace ErlezQue.MessageController.GrossController
{
    public static class GrossLinePri
    {
        public static void Insert(ErlezQue.BillDomain.LinePri linePri)
        {
            var bill = new BillEntities();

    	    var LinePris = new ErlezQue.BillDomain.LinePri()
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
                bill.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
	    }
    }
}
