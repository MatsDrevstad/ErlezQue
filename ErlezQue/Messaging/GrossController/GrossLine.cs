using ErlezQue.Domain;
using ErlezQue.Domain;
using System;

namespace ErlezQue.Messaging.GrossController
{
    public class GrossB03 : MessageController
    {
        public long Insert(bool saveData, ErlezQue.Domain.Line line)
        {
            var bill = new ErlezWebUIEntities();

	        var Line = new ErlezQue.Domain.Line()
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
                bill.Lines.Add(Line);
                if(saveData)
                    bill.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return Line.LineId;
	    }
    }
}
