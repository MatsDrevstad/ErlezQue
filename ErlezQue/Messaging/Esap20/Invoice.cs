using ErlezQue.BillDomain;
using ErlezQue.BullDomain;
using ErlezQue.Messaging.GrossController;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ErlezQue.Messaging.Esap20
{
    public class Invoice
    {
        private int postId;
        private int _elementCount;
        private Head _head;
        private IEnumerable<Company> _companies;
        private Bet _bet;

        public Invoice(Head head, IEnumerable<Company> companies, Bet bet)
        {
            _elementCount = 0;
            _head = head;
            _companies = companies;
            _bet = bet;
        }

        public int Save(bool saveData) 
        {
            if (_head.InvoiceType == "381")
            {
                if (string.IsNullOrEmpty(_head.CreditReason))
                    throw new Exception("Fel: T0061. " + this.GetType());
            }
            if (saveData) 
            {
                try
                {
                    var grossHead = new GrossHead();
                    postId = grossHead.Insert(_head);
                    _elementCount++;
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
                        var grossCompany = new GrossCompany();
                        grossCompany.Insert(item); 
                        _elementCount++;
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.InnerException);
                    }
                }
            }

            if (saveData && _bet != null)
            {
                try
                {
                    _bet.PostId = postId;
                    var grossBet = new GrossBet();
                    grossBet.Insert(_bet);
                    _elementCount++;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }

            return _elementCount;
        }
    }
}
