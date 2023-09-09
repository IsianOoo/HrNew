using HrNew.Application.DTOs.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HrNew.Application.DTOs.HrType
{
    public class HrTypeDto : BaseDto, IHrTypeDto
    {
        public string Name { get; set; }
    }
}
