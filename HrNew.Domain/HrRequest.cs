using HrNew.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HrNew.Domain
{
    public class HrRequest :BaseDomainEntity
    {
        public HrType HrType { get; set; }
        public int HrTypeId { get; set; }
        public HrAllocation HrAllocation { get; set; }
        public int HrAllocationId { get; set; }
        
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Description { get; set; }
    }
}
