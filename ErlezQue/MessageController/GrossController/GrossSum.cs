using ErlezQue.BillDomain;
using ErlezQue.BullDomain;
using System;

namespace ErlezQue.MessageController.GrossController
{
    public static class GrossSum
    {
        public static void Insert(ErlezQue.BillDomain.Sum sum)
        {
            var bill = new BillEntities();

            bill.Sums.Add(new ErlezQue.BillDomain.Sum()
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
            });
            bill.SaveChanges();
        }
    }
}
