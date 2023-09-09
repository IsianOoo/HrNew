using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HrNew.Application.DTOs.HrType.Validators
{
    public class UpdateHrTypeDtoValidator : AbstractValidator<HrTypeDto>
    {
        public UpdateHrTypeDtoValidator()
        {
            Include(new IHrTypeDtoValidator());

            RuleFor(p => p.Id).NotNull().WithMessage("{PropertyName} must be present");
        }
    }
}
