using FluentValidation;
using HrNew.Application.Contracts.Presistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HrNew.Application.DTOs.HrRequest.Validators
{
    public class UpdateHrRequestDtoValidator : AbstractValidator<UpdateHrRequestDto>
    {
        private readonly IHrAllocationRepository _hrAllocationRepository;
        private readonly IHrTypeRepository _hrTypeRepository;

        public UpdateHrRequestDtoValidator(IHrAllocationRepository HrAllocationRepository, IHrTypeRepository HrTypeRepository)
        {
            _hrAllocationRepository = HrAllocationRepository;
            _hrTypeRepository = HrTypeRepository;

            Include(new IHrRequestDtoValidator(_hrAllocationRepository, _hrTypeRepository));

            RuleFor(p => p.Id).NotNull().WithMessage("{PropertyName} must be present");
        }
    }
}
