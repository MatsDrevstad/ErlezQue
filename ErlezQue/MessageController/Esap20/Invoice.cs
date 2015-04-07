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
        private Head _head;
        private IEnumerable<Company> _companies;
        private int _elementCount;
        private int postId;

        public Invoice(Head head, IEnumerable<Company> companies)
        {
            _head = head;
            _companies = companies;
            _elementCount = 0;
        }

        public int Save(bool saveData) 
        {
            if (_head.InvoiceType == "381")
            {
                if (string.IsNullOrEmpty(_head.CreditReason))
                    throw new Exception("Fel: T0061. " + this.GetType());
            }
            _elementCount++;
            if (saveData) 
            {
                try
                {
                    postId = MessageController.GrossController.GrossHead.Insert(_head);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }

            int countCompany = 1;
            foreach (var item in _companies)
            {
                item.PostId = postId;
                item.CompanyCount = countCompany++;
                if (saveData) 
                {
                    try
                    {
                        MessageController.GrossController.GrossCompany.Insert(item); 
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.InnerException);
                    }
                }
                _elementCount++;
            }
            return _elementCount;
        }
    }
}
