using AutoMapper;
using HrNew.Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HrNew.Application.Features.HrRequests.Handlers.Commands
{
    public class CreateHrRequestCommandHandler : IRequestHandler<CreateHrRequestCommand, BaseCommandResponse>
    {
        private readonly IHrRequestRepository _hrRequestRepository;
        private readonly IMapper _mapper;
        private readonly IHrAllocationRepository _hrAllocationRepository;
        private readonly IHrTypeRepository _hrTypeRepository;


        public CreateHrRequestCommandHandler(IHrRequestRepository hrRequestRepository, IMapper mapper, IHrAllocationRepository hrAllocationRepository, IHrTypeRepository hrTypeRepository)
        {
            _hrRequestRepository = hrRequestRepository;
            _mapper = mapper;
            _hrAllocationRepository = hrAllocationRepository;
            _hrTypeRepository = hrTypeRepository;
        }
        public async Task<BaseCommandResponse> Handle(CreateHrRequestCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseCommandResponse();
            var validator = new CreateHrRequestDtoValidator(_hrAllocationRepository, _hrTypeRepository);
            var validationResult = await validator.ValidateAsync(request.HrRequestDto);

            if (validationResult.IsValid == false)
            {
                response.Success = false;
                response.Message = "Creation Failed";
                response.Errors = validationResult.Errors.Select(q => q.ErrorMessage).ToList();
            }
            else
            {
                var hrRequest = _mapper.Map<HrRequest>(request.HrRequestDto);
                hrRequest.HrTypeId = request.HrRequestDto.HrTypeId;
                hrRequest.HrAllocationId = request.HrRequestDto.HrAllocationId;

                hrRequest = await _hrRequestRepository.AddAsync(hrRequest);

                response.Success = true;
                response.Message = "Creation Successful";
                response.Id = hrRequest.Id;
            }
            return response;
        }

    }
}
