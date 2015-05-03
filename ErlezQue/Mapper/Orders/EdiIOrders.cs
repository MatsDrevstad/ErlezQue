using ErlezQue.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ErlezQue.Mapper.Orders
{
    public class EdiOrders
    {
        private  ErlezWebUIEntities context;
        private int _elementCount = 0;

        public EdiOrders()
	    {
            context = new ErlezWebUIEntities();
	    }

        //Head 1..1
        public Head GetHead(ErlezQue.Domain.Invoice inv)
        {
            var head = new Head()
            {
                InvoiceNo = inv.InvoiceNo.ToString(),
                InvoiceType = "380",
                InvoiceDate = inv.InvoiceDate.ToString(),
            };
            return head;
        }

        //HeadRef 0..*
        public IEnumerable<HeadRef> GetHeadRef(ErlezQue.Domain.Invoice inv)
        {
            var list = new List<HeadRef>();
            list.Add(new HeadRef() 
            {
                HeadRefQual = "IV",
                HeadRef1 = inv.InvoiceNo.ToString(),
            });
            return list.AsEnumerable();
        }

        //Company 2..*
        private IEnumerable<Company> GetCompany(ErlezQue.Domain.Invoice inv)
        {
            var list = new List<Company>();
            list.Add(new Company()
            {
                CompanyQual = "SE",
                VatNo = context.CompanySellers.Find(inv.Orders.Where(i => i.InvoiceId == inv.Id).FirstOrDefault().CompanySellerId).OrgNo,
                Name = context.CompanySellers.Find(inv.Orders.Where(i => i.InvoiceId == inv.Id).FirstOrDefault().CompanySellerId).Name,
                City = context.CompanySellers.Find(inv.Orders.Where(i => i.InvoiceId == inv.Id).FirstOrDefault().CompanySellerId).City,
            });

            list.Add(new Company()
            {
                CompanyQual = "BY",
                VatNo = context.CompanyBuyers.Find(inv.Orders.Where(i => i.InvoiceId == inv.Id).FirstOrDefault().CompanyBuyerId).OrgNo,
                Name = context.CompanyBuyers.Find(inv.Orders.Where(i => i.InvoiceId == inv.Id).FirstOrDefault().CompanyBuyerId).Name,
                City = context.CompanyBuyers.Find(inv.Orders.Where(i => i.InvoiceId == inv.Id).FirstOrDefault().CompanyBuyerId).City,
            });

            return list.AsEnumerable();
        }
        
        //Bet 1..1
        private Bet GetBet(ErlezQue.Domain.Invoice inv)
        {
            var bet = new Bet()
            { 
                DueDate = inv.DueDate.ToString().Substring(0, 10),
                InvCurrency = "SEK",
                TaxCurrency = "SEK",
            };
            return bet;
        }

        //Tdt 0..*
        public IEnumerable<Tdt> GetTdts(ErlezQue.Domain.Invoice inv)
        {
            return null;
        }

        //Tod 0..*
        public IEnumerable<Tod> GetTods(ErlezQue.Domain.Invoice inv)
        {
            return null;
        }

        //Alc 0..*
        public IEnumerable<Alc> GetAlcs(ErlezQue.Domain.Invoice inv)
        {
            return null;
        }

        //Line 1..*
        public IEnumerable<Line> GetLines(ErlezQue.Domain.Invoice inv)
        {
            var list = new List<Line>();
            foreach (var item in inv.Orders)
            {
                list.Add(new Line
                {
                    LineNumber = item.Id.ToString(),
                    GtinNo = item.Gtin.ToString(),
                    QuantityInvoiced = item.Amount.ToString(),
                    QuantityInvoicedUnit = item.UnitType,
                    LineAmount = (item.Amount * item.UnitPrice).ToString()
                });
            }
            return list.AsEnumerable();
        }

        //LineRef 0..*
        public IEnumerable<LineRef> GetLineRefs(ErlezQue.Domain.Invoice inv)
        {
            return null;
        }

        //LinePri 1..*
        public IEnumerable<LinePri> GetLinePris(ErlezQue.Domain.Invoice inv)
        {
            var list = new List<LinePri>();
            foreach (var item in inv.Orders)
            {
                list.Add(new LinePri
                {
                    PriceQualifier = "AAA",
                    PriceType = "CT",
                    PriceTypeQualifier = "CP",
                    LinePri1 = item.UnitPrice.ToString()
                });
            }
            return list.AsEnumerable();
        }

        //LineTax 1..*
        public IEnumerable<LineTax> GetLineTaxes(ErlezQue.Domain.Invoice inv)
        {
            var list = new List<LineTax>();
            foreach (var item in inv.Orders)
            {
                list.Add(new LineTax
                {
                    LineTaxType = "VAT",
                    LineTaxRate = "25",
                    LineTaxAmount = (item.UnitPrice * 0.25m).ToString(),
                });
            }
            return list.AsEnumerable();
        }

        //LineAlc 0..*
        public IEnumerable<LineAlc> GetLineAlcs(ErlezQue.Domain.Invoice inv)
        {
            return null;
        }

        //Sum 1..1
        public Sum GetSum(ErlezQue.Domain.Invoice inv)
        {
            var totalQuantity = 0m;
            var totalLines = 0;
            decimal? totalAmount = 0m;
            foreach (var item in inv.Orders)
            {
                totalQuantity = totalQuantity + item.Amount;
                totalLines++;
                totalAmount = totalAmount + (item.Amount * item.UnitPrice);
            }

            var sum = new Sum()
            {
                TotalQuantity = totalQuantity.ToString(),
                TotalLines = totalLines.ToString(),
                TotalAmount = totalAmount.ToString(),
            };

            return sum;
        }
        
        //SumTax 1..*
        public IEnumerable<SumTax> GetSumTaxes(ErlezQue.Domain.Invoice inv)
        {
            var list = new List<SumTax>();

            decimal? sumTaxAmount = 0m;
            foreach (var item in inv.Orders)
            {
                sumTaxAmount = sumTaxAmount + (item.Amount * item.UnitPrice);
            }

            list.Add(new SumTax
            {
                SumTaxType = "VAT",
                SumTaxRate = "25",
                SumTaxAmount = sumTaxAmount.ToString(),
            });

            return list.AsEnumerable();
        }

        internal int Sync(bool saveData)
        {
            while (context.Invoices.Count(i => i.Status == "Created") > 0)
            {
                var invoice = context.Invoices
                    .Where(i => i.Status == "Created")
                    .FirstOrDefault();

                var head = GetHead(invoice);
                var headRefs = GetHeadRef(invoice);
                var companies = GetCompany(invoice);
                var bet = GetBet(invoice);
                var tdts = GetTdts(invoice);
                var tods = GetTods(invoice);
                var alcs = GetAlcs(invoice);
                var lines = GetLines(invoice);
                var lineRefs = GetLineRefs(invoice);
                var linePris = GetLinePris(invoice);
                var lineTaxes = GetLineTaxes(invoice);
                var lineAlcs = GetLineAlcs(invoice);
                var sum = GetSum(invoice);
                var sumTaxes = GetSumTaxes(invoice);

                var messageController = new Messaging.Esap20.Orders(head, headRefs, companies, 
                    bet, tdts, tods, alcs, lines, lineRefs, linePris, lineTaxes, lineAlcs, sum, sumTaxes);
                _elementCount = _elementCount + messageController.Save(saveData);

                if (saveData)
                {
                    invoice.Status = "Synced";
                    context.SaveChanges();
                }
                else
                {
                    invoice.Status = "Pending";
                    context.SaveChanges();
                }
            }
            var invoicesPending = context.Invoices
                .Where(i => i.Status == "Pending");

            foreach (var item in invoicesPending)
            {
                item.Status = "Created";
            }
            context.SaveChanges();
            return _elementCount;
        }
    }
}
