﻿using ErlezQue.BillDomain;
using ErlezQue.BullDomain;
using System;

namespace ErlezQue.MessageController.GrossController
{
    public static class GrossTdt
    {
        public static void Insert(ErlezQue.BillDomain.Tdt tdt)
        {
            var bill = new BillEntities();

            bill.Tdts.Add(new ErlezQue.BillDomain.Tdt()
            {
                PostId = tdt.PostId,
                TdtCount = tdt.TdtCount,
                TdtMethod = tdt.TdtMethod,
                TdtDescription = tdt.TdtDescription,
                TdtCarrierName = tdt.TdtCarrierName,
            });
            bill.SaveChanges();
        }
    }
}
