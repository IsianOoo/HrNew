using AutoMapper;
using HrNew.Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HrNew.Application.Features.HrAllocations.Handlers.Commands
{
    public class CreateHrAllocationCommandHandler : IRequestHandler<CreateHrAllocationCommand, BaseCommandResponse>
    {
        private readonly IHrAllocationRepository _HrAllocationRepository;
        private readonly IMapper _mapper;

        public CreateHrAllocationCommandHandler(IHrAllocationRepository HrAllocationRepository, IMapper mapper)
        {
            _HrAllocationRepository = HrAllocationRepository;
            _mapper = mapper;
        }

        public async Task<BaseCommandResponse> Handle(CreateHrAllocationCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseCommandResponse();
            var validator = new CreateHrAllocationDtoValidator();
            var validationResult = await validator.ValidateAsync(request.HrAllocationDto);

            if (validationResult.IsValid == false)
            {
                response.Success = false;
                response.Message = "Creation Failed";
                response.Errors = validationResult.Errors.Select(q => q.ErrorMessage).ToList();
            }
            else
            {
                var HrAllocation = _mapper.Map<HrAllocation>(request.HrAllocationDto);

                HrAllocation = await _HrAllocationRepository.AddAsync(HrAllocation);

                response.Success = true;
                response.Message = "Creation Successful";
                response.Id = HrAllocation.Id;
            }
            return response;
        }
    }
}
