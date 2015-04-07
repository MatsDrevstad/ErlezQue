using ErlezQue.BillDomain;
using ErlezQue.BullDomain;
using System;

namespace ErlezQue.Messaging.GrossController
{
    public class GrossLine : MessageController
    {
        public void Insert(ErlezQue.BillDomain.Line line)
        {
            var bill = new BillEntities();

	        var Lines = new ErlezQue.BillDomain.Line()
            {
                PostId = line.PostId,
                LineId = line.LineId,
                LineCount = line.LineCount,
                LineNumber = line.LineNumber,
                GtinNo = line.GtinNo,
                SellerPartNo = line.SellerPartNo,
                BuyerPartNo = line.BuyerPartNo,
                ManufPartNo = line.ManufPartNo,
                QuantityInvoiced = line.QuantityInvoiced,
                QuantityInvoicedUnit = line.QuantityInvoicedUnit,
                QuantityDelivered = line.QuantityDelivered,
                QuantityDeliveredUnit = line.QuantityDeliveredUnit,
                QuantityDespatched = line.QuantityDespatched,
                QuantityDespatchedUnit = line.QuantityDespatchedUnit,
                QuantityReceived = line.QuantityReceived,
                QuantityReceivedUnit = line.QuantityReceivedUnit,
                LineAmount = line.LineAmount,
                Description = line.Description,
                Description2 = line.Description2,
                CreditReason = line.CreditReason,
                Revision = line.Revision,
                Origin = line.Origin,
                DelDate = line.DelDate,
                FirstDelDate = line.FirstDelDate,
                LastDelDate = line.LastDelDate,
                LineType = line.LineType,
            };
            try
            {
                bill.Lines.Add(Lines);
                bill.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
	    }
    }
}
