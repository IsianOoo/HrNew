using FluentValidation;
using HrNew.Application.Contracts.Presistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HrNew.Application.DTOs.HrRequest.Validators
{
    public class IHrRequestDtoValidator : AbstractValidator<IHrRequestDto>
    {
        private readonly IHrAllocationRepository _hrAllocationRepository;
        private readonly IHrTypeRepository _hrTypeRepository;

        public IHrRequestDtoValidator(IHrAllocationRepository HrAllocationRepository, IHrTypeRepository HrTypeRepository)
        {
            _hrAllocationRepository = HrAllocationRepository;
            _hrTypeRepository = HrTypeRepository;

            RuleFor(p => p.StartDate)
                .LessThan(p => p.EndDate).WithMessage("{PropertyName} must be before {ComparisonValue}");

            RuleFor(p => p.EndDate)
                .GreaterThan(p => p.StartDate).WithMessage("{PropertyName} must be after {ComparisonValue}");

            RuleFor(p => p.Description)
                    .NotEmpty().WithMessage("{PropertyName} is required.")
                    .NotNull()
                    .MaximumLength(50).WithMessage("{PropertyName} must not exceed 50 characters.");

          

            //RuleFor(p => p.HrAllocationId)
            //        .GreaterThan(0)
            //        .MustAsync(async (id, token) =>
            //        {
            //            var HrAllocationExists = await _hrAllocationRepository.Exists(id);
            //            return !HrAllocationExists;
            //        })
            //        .WithMessage("{PropertyName} does not exist.");

            //RuleFor(p => p.HrTypeId)
            //        .GreaterThan(0)
            //        .MustAsync(async (id, token) =>
            //        {
            //            var HrTypeExists = await _hrTypeRepository.Exists(id);
            //            return !HrTypeExists;
            //        })
            //        .WithMessage("{PropertyName} does not exist.");

        }
    }
}
