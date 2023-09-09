using FluentValidation;
using HrNew.Application.Contracts.Presistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HrNew.Application.DTOs.HrRequest.Validators
{
    public class CreateHrRequestDtoValidator : AbstractValidator<CreateHrRequestDto>
    {

        private readonly IHrAllocationRepository _hrAllocationRepository;
        private readonly IHrTypeRepository _hrTypeRepository;

        public CreateHrRequestDtoValidator(IHrAllocationRepository HrAllocationRepository, IHrTypeRepository HrTypeRepository)
        {
            _hrAllocationRepository = HrAllocationRepository;
            _hrTypeRepository = HrTypeRepository;

            Include(new IHrRequestDtoValidator(_hrAllocationRepository, _hrTypeRepository));
        }
    }
}
