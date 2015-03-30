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

        public EdiInvoice()
	    {
            _bull = new BullEntities();
	    }

        public IEnumerable<Head> GetHead(List<Order> ordersToSync)
        {
            var list = new List<Head>();
            foreach (var item in ordersToSync)
            {
                list.Add(new Head()
                { 
                    InvoiceNo = item.Invoice.InvoiceNo.ToString(),
                    InvoiceType = "380",
                    InvoiceDate = item.Invoice.InvoiceDate.ToString(),

                });
            }
            return list.AsEnumerable();
        }

        private IEnumerable<Company> GetCompany(List<Order> ordersToSync)
        {
            var list = new List<Company>();
            foreach (var item in ordersToSync)
            {
                list.Add(new Company()
                {
                    OrgNo = _bull.CompanySellers.Find(item.CompanySellerId).OrgNo,
                    Name = _bull.CompanySellers.Find(item.CompanySellerId).Name,
                    City = _bull.CompanySellers.Find(item.CompanySellerId).City,
                });
            }
            return list.AsEnumerable();

        }

        internal int Sync(bool saveData)
        {
            var ordersToSync = _bull.Orders
                .Where(o => o.InvoiceId != null)
                .Where(o => o.Invoice.Status == "Created").ToList();

            var heads = GetHead(ordersToSync);
            var company = GetCompany(ordersToSync);

            var messageController = new MessageController.Esap20.Invoice(heads, company);
            var _elementCount = messageController.Save(saveData);

            if (saveData)
            {
                foreach (var item in ordersToSync)
                {
                    item.Gtin = null;
                    item.Invoice.Status = "Synced";
                    _bull.SaveChanges();
                }
            }
            return _elementCount;
        }
    }
}
