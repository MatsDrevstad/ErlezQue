using ErlezQue.BillDomain;
using ErlezQue.BullDomain;
using ErlezQue.Messaging;
using System;

namespace ErlezQue.Messaging.GrossController
{
    public class GrossBet : MessageController
    {
        public void Insert(bool saveData, ErlezQue.BillDomain.Bet bet)
        {
            var bill = new BillEntities();

	        var Bets = new ErlezQue.BillDomain.Bet()
            {
                PostId = bet.PostId,
                DueDate = MatchGrossFormat(bet.DueDate, "YYYY-mm-dd", this.GetType()),
                DueDays = bet.DueDays,
                InvCurrency = bet.InvCurrency,
                TaxCurrency = bet.TaxCurrency,
                TaxCurrencyRate = bet.TaxCurrencyRate,
                TaxCurrencyRateDate = bet.TaxCurrencyRateDate,
                ExemptFromTax = bet.ExemptFromTax,
                PenaltySurchargePercent = bet.PenaltySurchargePercent,
                PaymentInstruction = bet.PaymentInstruction,
            };
	        try
	        {
	            bill.Bets.Add(Bets);
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
