using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HrNew.Application.DTOs.HrRequest.Validators
{
    public class UpdateHrRequestDtoValidator : AbstractValidator<UpdateHrRequestDto>
    {
        private readonly IHrAllocationRepository _HrAllocationRepository;
        private readonly IHrTypeRepository _HrTypeRepository;

        public UpdateHrRequestDtoValidator(IHrAllocationRepository HrAllocationRepository, IHrTypeRepository HrTypeRepository)
        {
            _HrAllocationRepository = HrAllocationRepository;
            _HrTypeRepository = HrTypeRepository;

            Include(new IHrRequestDtoValidator(_HrAllocationRepository, _HrTypeRepository));

            RuleFor(p => p.Id).NotNull().WithMessage("{PropertyName} must be present");
        }
    }
}
