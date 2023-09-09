using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HrNew.Application.DTOs.HrAllocation.Validators
{
    public class UpdateHrAllocationDtoValidator : AbstractValidator<HrAllocationDto>
    {
        public UpdateHrAllocationDtoValidator() {
            Include(new IHrAllocationDtoValidator());

            RuleFor(p => p.Id).NotNull().WithMessage("{PropertyName} must be present");

        }
    }
}
