using ErlezQue.BillDomain;
using ErlezQue.BullDomain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ErlezQue.Mapper.Invoice
{
    public class EdiInvoice
    {
        private BullEntities _bull;
        private int _elementCount = 0;

        public EdiInvoice()
	    {
            _bull = new BullEntities();
	    }

        //Head 1..1
        public Head GetHead(ErlezQue.BullDomain.Invoice inv)
        {
            var head = new Head()
            {
                InvoiceNo = inv.InvoiceNo.ToString(),
                InvoiceType = "380",
                InvoiceDate = inv.InvoiceDate.ToString(),
            };
            return head;
        }

        //Company 2..*
        private IEnumerable<Company> GetCompany(ErlezQue.BullDomain.Invoice inv)
        {
            var list = new List<Company>();
            list.Add(new Company()
            {
                CompanyQual = "SE",
                VatNo = _bull.CompanySellers.Find(inv.Orders.Where(i => i.InvoiceId == inv.Id).FirstOrDefault().CompanySellerId).OrgNo,
                Name = _bull.CompanySellers.Find(inv.Orders.Where(i => i.InvoiceId == inv.Id).FirstOrDefault().CompanySellerId).Name,
                City = _bull.CompanySellers.Find(inv.Orders.Where(i => i.InvoiceId == inv.Id).FirstOrDefault().CompanySellerId).City,
            });

            list.Add(new Company()
            {
                CompanyQual = "BY",
                VatNo = _bull.CompanyBuyers.Find(inv.Orders.Where(i => i.InvoiceId == inv.Id).FirstOrDefault().CompanyBuyerId).OrgNo,
                Name = _bull.CompanyBuyers.Find(inv.Orders.Where(i => i.InvoiceId == inv.Id).FirstOrDefault().CompanyBuyerId).Name,
                City = _bull.CompanyBuyers.Find(inv.Orders.Where(i => i.InvoiceId == inv.Id).FirstOrDefault().CompanyBuyerId).City,
            });

            return list.AsEnumerable();
        }

        //Bet 1..1
        private Bet GetBet(ErlezQue.BullDomain.Invoice inv)
        {
            var bet = new Bet()
            { 
                DueDate = inv.DueDate.ToString(),
            };
            return bet;
        }

        internal int Sync(bool saveData)
        {
            while (_bull.Invoices.Count(i => i.Status == "Created") > 0)
            {
                var invoice = _bull.Invoices
                    .Where(i => i.Status == "Created")
                    .FirstOrDefault();

                var head = GetHead(invoice);
                var companies = GetCompany(invoice);
                var bet = GetBet(invoice);

                var messageController = new Messaging.Esap20.Invoice(head, companies, bet);
                _elementCount = _elementCount + messageController.Save(saveData);

                if (saveData)
                {
                    invoice.Status = "Synced";
                    _bull.SaveChanges();
                }
            }
            return _elementCount;
        }
    }
}
