using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HrNew.Application.DTOs.HrType.Validators
{
    public class CreateHrTypeDtoValidator : AbstractValidator<CreateHrTypeDto>
    {
        public CreateHrTypeDtoValidator()
        {
            Include(new IHrTypeDtoValidator());
        }
    }
}
