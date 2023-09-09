using HrNew.Application.DTOs.Common;
using HrNew.Application.DTOs.HrAllocation;
using HrNew.Application.DTOs.HrType;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HrNew.Application.DTOs.HrRequest
{
    public class HrRequestListDto : BaseDto
    {
        public HrTypeDto HrType { get; set; }
        public HrAllocationDto HrAllocation { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Description { get; set; }
    }
}
