using ErlezQue.BillDomain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ErlezQue.Models
{
    public class HeadModel : Head
    {
        public int HeadId { get; set; }
    }

    public class CompanyModel : Company
    {
        public int CompanyId { get; set; }
        public int HeadId { get; set; }
    }
}
