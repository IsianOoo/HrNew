using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HrNew.Application.DTOs.HrRequest.Validators
{
    public class IHrRequestDtoValidator : AbstractValidator<IHrRequestDto>
    {
        private readonly IHrAllocationRepository _HrAllocationRepository;
        private readonly IHrTypeRepository _HrTypeRepository;

        public IHrRequestDtoValidator(IHrAllocationRepository HrAllocationRepository, IHrTypeRepository HrTypeRepository)
        {
            _HrAllocationRepository = HrAllocationRepository;
            _HrTypeRepository = HrTypeRepository;

            RuleFor(p => p.City)
               .NotEmpty().WithMessage("{PropertyName} is required.")
               .NotNull()
               .MaximumLength(50).WithMessage("{PropertyName} must not exceed 50 characters.");

            RuleFor(p => p.Street)
                    .NotEmpty().WithMessage("{PropertyName} is required.")
                    .NotNull()
                    .MaximumLength(50).WithMessage("{PropertyName} must not exceed 50 characters.");

            RuleFor(p => p.RequestComments)
                    .NotEmpty().WithMessage("{PropertyName} is required.")
                    .NotNull()
                    .MaximumLength(50).WithMessage("{PropertyName} must not exceed 50 characters.");

            RuleFor(p => p.ZipCode)
                     .NotEmpty().WithMessage("{PropertyName} is required.")
                     .NotNull()
                      .MaximumLength(50).WithMessage("{PropertyName} must not exceed 50 characters.");

            RuleFor(p => p.HouseNumber)
                        .NotEmpty().WithMessage("{PropertyName} is required.")
                        .NotNull();


            RuleFor(p => p.HrAllocationId)
                    .GreaterThan(0)
                    .MustAsync(async (id, token) =>
                    {
                        var HrAllocationExists = await _HrAllocationRepository.Exists(id);
                        return !HrAllocationExists;
                    })
                    .WithMessage("{PropertyName} does not exist.");

            RuleFor(p => p.HrTypeId)
                    .GreaterThan(0)
                    .MustAsync(async (id, token) =>
                    {
                        var HrTypeExists = await _HrTypeRepository.Exists(id);
                        return !HrTypeExists;
                    })
                    .WithMessage("{PropertyName} does not exist.");

        }
    }
}
