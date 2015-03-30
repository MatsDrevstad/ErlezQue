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

        public IEnumerable<Head> GetHead()
        {
            var list = new List<Head>();
            list.Add( new Head() { InvoiceNo = "111" });
            list.Add( new Head() { InvoiceNo = "222" });
            return list.AsEnumerable();
        }

        internal void Sync()
        {

            var ordersToSync = _bull.Orders
                .Where(o => o.InvoiceId != null)
                .Where(o => o.Invoice.Status == "Created").ToList();

            var heads = GetHead();

            var messageController = new MessageController.Invoice(heads);
            messageController.Save();

            foreach (var item in ordersToSync)
            {
                item.Gtin = null;
                item.Invoice.Status = "Synced";
                _bull.SaveChanges();
            }
        }
    }
}
