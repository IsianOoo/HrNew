using AutoMapper;
using HrNew.Application.Contracts.Presistence;
using HrNew.Application.DTOs.HrAllocation;
using HrNew.Application.Features.HrAllocations.Requests.Queries;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HrNew.Application.Features.HrAllocations.Handlers.Queries
{
    public class GetHrAllocationDetailRequestHandler : IRequestHandler<GetHrAllocationDetailRequest, HrAllocationDto>
    {
        private readonly IHrAllocationRepository _hrAllocationRepository;
        private readonly IMapper _mapper;

        public GetHrAllocationDetailRequestHandler(IHrAllocationRepository hrAllocationRepository, IMapper mapper)
        {
            _hrAllocationRepository = hrAllocationRepository;
            _mapper = mapper;
        }
        public async Task<HrAllocationDto> Handle(GetHrAllocationDetailRequest request, CancellationToken cancellationToken)
        {
            var hrAllocation = await _hrAllocationRepository.GetAsync(request.Id);
            return _mapper.Map<HrAllocationDto>(hrAllocation);
        }
    }
}
