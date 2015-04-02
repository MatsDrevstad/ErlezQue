using ErlezQue.BillDomain;
using ErlezQue.BullDomain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ErlezQue.MessageController.Esap20
{
    public class Invoice
    {
        private IEnumerable<Head> _heads;
        private IEnumerable<Company> _companies;
        private int _elementCount;

        public Invoice(IEnumerable<Head> heads, IEnumerable<Company> companies)
        {
            _heads = heads;
            _companies = companies;
            _elementCount = 0;
        }

        public int Save(bool saveData) 
        {
            foreach (var head in _heads)
            {
                if (head.InvoiceType == "381")
                {
                    if (string.IsNullOrEmpty(head.CreditReason))
                    {
                        throw new Exception("Fel: T0061. " + this.GetType());
                    }
                }
                _elementCount++;
                if (saveData) { MessageController.GrossController.GrossHead.Insert(head); }
            }

            foreach (var item in _companies)
            {
                if (false)
                    throw new Exception("Fel: T0000. " + this.GetType());
                if (saveData) { MessageController.GrossController.GrossCompany.Insert(item); }
                _elementCount++;
	        }

            return _elementCount;
        }
    }
}
