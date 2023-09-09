using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HrNew.Application.DTOs.HrType
{
    public class CreateHrTypeDto : IHrTypeDto
    {
        public string Name { get; set; }
    }
}