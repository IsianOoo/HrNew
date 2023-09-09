using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HrNew.Application.DTOs.HrAllocation
{
    public class CreateHrAllocationDto : IHrAllocationDto
    {
        public string Name { get; set; }
        public string Surname { get; set; }
    }
}
