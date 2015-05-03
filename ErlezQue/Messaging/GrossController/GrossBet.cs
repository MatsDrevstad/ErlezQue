using ErlezQue.Domain;
using ErlezQue.Domain;
using ErlezQue.Messaging;
using System;

namespace ErlezQue.Messaging.GrossController
{
    public class GrossA02 : MessageController
    {
        public void Insert(bool saveData, ErlezQue.Domain.Bet bet)
        {
            var bill = new ErlezWebUIEntities();

	        var Bets = new ErlezQue.Domain.Bet()
            {
                PostId = bet.PostId,
                DueDate = MatchGrossFormat(bet.DueDate, @"^\d{4}-\d{2}-\d{2}$", this.GetType()),
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
