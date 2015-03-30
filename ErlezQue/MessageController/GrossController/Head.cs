using ErlezQue.BillDomain;
using ErlezQue.BullDomain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ErlezQue.MessageController.GrossController
{
    public static class Head
    {
        public static void Insert(ErlezQue.BillDomain.Head head)
        {
            var bill = new BillEntities();

            bill.Heads.Add(new ErlezQue.BillDomain.Head()
            {
                InvoiceNo = head.InvoiceNo,
            });
            bill.SaveChanges();
        }
    }
}