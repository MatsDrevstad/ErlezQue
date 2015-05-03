using ErlezQue.Domain;
using System;

namespace ErlezQue.Messaging.GrossController
{
    public class GrossSum : MessageController
    {
        public void Insert(bool saveData, ErlezQue.Domain.Sum sum)
        {
            var bill = new ErlezWebUIEntities();

	        var Sums = new ErlezQue.Domain.Sum()
            {
                PostId = sum.PostId,
                TotalQuantity = sum.TotalQuantity,
                TotalLines = sum.TotalLines,
                TotalAmount = sum.TotalAmount,
                TotalAmountTaxCur = sum.TotalAmountTaxCur,
                LineAmount = sum.LineAmount,
                TaxableAmount = sum.TaxableAmount,
                TaxableAmountTaxCur = sum.TaxableAmountTaxCur,
                TaxableAmountExclExemption = sum.TaxableAmountExclExemption,
                TaxableAmountExclExemptionTaxCur = sum.TaxableAmountExclExemptionTaxCur,
                TaxAmount = sum.TaxAmount,
                TaxAmountTaxCur = sum.TaxAmountTaxCur,
                AlcAmount = sum.AlcAmount,
                AdjustmentAmount = sum.AdjustmentAmount,
                NonTaxableAmount = sum.NonTaxableAmount,
                ExemptionAmount = sum.ExemptionAmount,
            };
            try
            {
                bill.Sums.Add(Sums);
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
