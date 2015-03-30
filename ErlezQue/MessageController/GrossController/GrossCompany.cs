using ErlezQue.BillDomain;
using ErlezQue.BullDomain;
using System;

namespace ErlezQue.MessageController.GrossController
{
    public static class GrossCompany
    {
        public static void Insert(ErlezQue.BillDomain.Company company)
        {
            var bill = new BillEntities();

            bill.Companies.Add(new ErlezQue.BillDomain.Company()
            {
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
            });
            bill.SaveChanges();
        }
    }
}
