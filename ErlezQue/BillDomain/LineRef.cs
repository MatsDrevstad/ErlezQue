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
    
    public partial class LineRef
    {
        public long LineId { get; set; }
        public int LineRefCount { get; set; }
        public string LineRefQual { get; set; }
        public string LineRef1 { get; set; }
        public string LineRefLin { get; set; }
        public string LineRefDate { get; set; }
    
        public virtual Line Line { get; set; }
    }
}
