using HrNew.Application.DTOs.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HrNew.Application.DTOs.HrRequest
{
    public class UpdateHrRequestDto : BaseDto,IHrRequestDto
    {
        public int HrTypeId { get; set; }
        public int HrAllocationId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Description { get; set; }
    }
}
