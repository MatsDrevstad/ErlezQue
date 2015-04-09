using ErlezQue.BillDomain;
using ErlezQue.BullDomain;
using System;

namespace ErlezQue.Messaging.GrossController
{
    public class GrossCompany : MessageController
    {
        public void Insert(bool saveData, ErlezQue.BillDomain.Company company)
        {
            var bill = new BillEntities();

            var Company = new ErlezQue.BillDomain.Company()
            {
                PostId = company.PostId,
                CompanyCount = company.CompanyCount,
                CompanyQual = company.CompanyQual,
                PartyIdentification = company.PartyIdentification,
                VatNo = company.VatNo,
                OrgNo = company.OrgNo,
                CustomerNumber = company.CustomerNumber,
                SellerUniqueIdentification = company.SellerUniqueIdentification,
                Name = company.Name,
                ContactName = company.ContactName,
                ContactTel = company.ContactTel,
                ContactEmail = company.ContactEmail,
                ContactFax = company.ContactFax,
                StreetName = company.StreetName,
                AdditionalStreetName = company.AdditionalStreetName,
                ZipCode = company.ZipCode,
                City = company.City,
                Country = company.Country,
                Box = company.Box,
                Department = company.Department,
                BankCode = company.BankCode,
                BankName = company.BankName,
                BankAccount = company.BankAccount,
                Iban = company.Iban,
                PlusGiro = company.PlusGiro,
                BankGiro = company.BankGiro,
            };
            try
            {
                bill.Companies.Add(Company);
                if(saveData)
                    bill.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
