//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ErlezQue.BillDomain
{
    using System;
    using System.Collections.Generic;
    
    public partial class Sum
    {
        public int PostId { get; set; }
        public string TotalQuantity { get; set; }
        public string TotalLines { get; set; }
        public string TotalAmount { get; set; }
        public string TotalAmountTaxCur { get; set; }
        public string LineAmount { get; set; }
        public string TaxableAmount { get; set; }
        public string TaxableAmountTaxCur { get; set; }
        public string TaxableAmountExclExemption { get; set; }
        public string TaxableAmountExclExemptionTaxCur { get; set; }
        public string TaxAmount { get; set; }
        public string TaxAmountTaxCur { get; set; }
        public string AlcAmount { get; set; }
        public string AdjustmentAmount { get; set; }
        public string NonTaxableAmount { get; set; }
        public string ExemptionAmount { get; set; }
    
        public virtual Head Head { get; set; }
    }
}
