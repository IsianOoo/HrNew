using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HrNew.Application.DTOs.HrAllocation.Validators
{
    public class CreateHrAllocationDtoValidator : AbstractValidator<CreateHrAllocationDto>
    {
        public CreateHrAllocationDtoValidator()
        {
            Include(new IHrAllocationDtoValidator());
        }
    }
}
