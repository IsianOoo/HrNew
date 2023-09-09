using AutoMapper;
using HrNew.Application.Contracts.Presistence;
using HrNew.Application.DTOs.HrRequest.Validators;
using HrNew.Application.Exceptions;
using HrNew.Application.Features.HrRequests.Requests.Commands;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HrNew.Application.Features.HrRequests.Handlers.Commands
{
    public class UpdateHrRequestCommandHandler : IRequestHandler<UpdateHrRequestCommand, Unit>
    {
        private readonly IHrRequestRepository _hrRequestRepository;
        private readonly IMapper _mapper;
        private readonly IHrAllocationRepository _hrAllocationRepository;
        private readonly IHrTypeRepository _hrTypeRepository;

        public UpdateHrRequestCommandHandler(IHrRequestRepository hrRequestRepository, IMapper mapper, IHrAllocationRepository hrAllocationRepository, IHrTypeRepository hrTypeRepository)
        {
            _hrRequestRepository = hrRequestRepository;
            _mapper = mapper;
            _hrAllocationRepository = hrAllocationRepository;
            _hrTypeRepository = hrTypeRepository;
        }
        public async Task<Unit> Handle(UpdateHrRequestCommand request, CancellationToken cancellationToken)
        {

            var validator = new UpdateHrRequestDtoValidator(_hrAllocationRepository, _hrTypeRepository);
            var validationResult = await validator.ValidateAsync(request.HrRequestDto);

            if (validationResult.IsValid == false)
            {
                throw new ValidationException(validationResult);
            }

            var hrRequest = await _hrRequestRepository.GetAsync(request.HrRequestDto.Id);

            if (request.HrRequestDto != null)
            {
                _mapper.Map(request.HrRequestDto, hrRequest);

                await _hrRequestRepository.UpdateAsync(hrRequest);
            }

            return Unit.Value;
        }
    }
}
