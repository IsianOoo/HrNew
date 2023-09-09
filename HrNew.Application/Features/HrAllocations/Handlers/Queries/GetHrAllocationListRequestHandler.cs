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
    public class GetHrAllocationListRequestHandler : IRequestHandler<GetHrAllocationListRequest, List<HrAllocationDto>>
    {
        private readonly IHrAllocationRepository _hrAllocationRepository;
        private readonly IMapper _mapper;

        public GetHrAllocationListRequestHandler(IHrAllocationRepository hrAllocationRepository, IMapper mapper)
        {
            _hrAllocationRepository = hrAllocationRepository;
            _mapper = mapper;
        }

        public async Task<List<HrAllocationDto>> Handle(GetHrAllocationListRequest request, CancellationToken cancellationToken)
        {
            var hrAllocation = await _hrAllocationRepository.GetAllAsync();
            return _mapper.Map<List<HrAllocationDto>>(hrAllocation);
        }
    }
}
