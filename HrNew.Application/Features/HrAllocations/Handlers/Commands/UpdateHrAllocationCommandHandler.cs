using AutoMapper;
using HrNew.Application.Contracts.Presistence;
using HrNew.Application.DTOs.HrAllocation.Validators;
using HrNew.Application.Exceptions;
using HrNew.Application.Features.HrAllocations.Requests.Commands;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HrNew.Application.Features.HrAllocations.Handlers.Commands
{
    public class UpdateHrAllocationCommandHandler : IRequestHandler<UpdateHrAllocationCommand, Unit>
    {
        private readonly IHrAllocationRepository _hrAllocationRepository;
        private readonly IMapper _mapper;

        public UpdateHrAllocationCommandHandler(IHrAllocationRepository hrAllocationRepository, IMapper mapper)
        {
            _hrAllocationRepository = hrAllocationRepository;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(UpdateHrAllocationCommand request, CancellationToken cancellationToken)
        {
            var validator = new UpdateHrAllocationDtoValidator();
            var validationResult = await validator.ValidateAsync(request.HrAllocationDto);

            if (validationResult.IsValid == false)
            {
                throw new ValidationException(validationResult);
            }

            var hrAllocation = await _hrAllocationRepository.GetAsync(request.HrAllocationDto.Id);

            _mapper.Map(request.HrAllocationDto, hrAllocation);

            await _hrAllocationRepository.UpdateAsync(hrAllocation);

            return Unit.Value;
        }
    }
}
