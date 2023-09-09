using HrNew.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HrNew.Domain
{
    public class HrAllocation : BaseDomainEntity
    {
        public string Name { get; set; }
        public string Surname { get; set; }
    }
}
