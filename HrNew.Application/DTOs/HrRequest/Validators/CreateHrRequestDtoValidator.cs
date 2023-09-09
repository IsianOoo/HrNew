using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HrNew.Application.DTOs.HrRequest.Validators
{
    public class CreateHrRequestDtoValidator : AbstractValidator<CreateHrRequestDto>
    {

        private readonly IHrAllocationRepository _HrAllocationRepository;
        private readonly IHrTypeRepository _HrTypeRepository;

        public CreateHrRequestDtoValidator(IHrAllocationRepository HrAllocationRepository, IHrTypeRepository HrTypeRepository)
        {
            _HrAllocationRepository = HrAllocationRepository;
            _HrTypeRepository = HrTypeRepository;

            Include(new IHrRequestDtoValidator(_HrAllocationRepository, _HrTypeRepository));
        }
    }
}
