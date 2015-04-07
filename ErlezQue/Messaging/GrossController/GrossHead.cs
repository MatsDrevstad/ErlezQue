using ErlezQue.BillDomain;
using ErlezQue.BullDomain;
using System;

namespace ErlezQue.Messaging.GrossController
{
    public class GrossHead : MessageController
    {
        public int Insert(ErlezQue.BillDomain.Head head)
        {
            var bill = new BillEntities();

            var Head = new ErlezQue.BillDomain.Head()
            {
                Flow = head.Flow,
                InvoiceNo = head.InvoiceNo,
                OutputType = head.OutputType,
                UpdateCode = head.UpdateCode,
                CreateDate = head.CreateDate,
                UpdateDate = head.UpdateDate,
                InvoiceType = head.InvoiceType,
                InvoiceDate = head.InvoiceDate,
                RealDelDate = head.RealDelDate,
                RealDelShip = head.RealDelShip,
                HorizonStartDate = head.HorizonStartDate,
                HorizonEndDate = head.HorizonEndDate,
                PeriodFrom = head.PeriodFrom,
                PeriodTo = head.PeriodTo,
                CreditReason = head.CreditReason,
                MaterialType = head.MaterialType,
                GUID = head.GUID,
                Timestamp = head.Timestamp,
                ErpVersion = head.ErpVersion,
                isTest = head.isTest,
                isDeleted = head.isDeleted,
                CorporateGroup = head.CorporateGroup,
                Erp = head.Erp,
                Version = head.Version,
                FromID = head.FromID,
                Hash = head.Hash,
            };
            try
            {
                bill.Heads.Add(Head);
                bill.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return Head.PostId;
        }
    }
}
