using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HrNew.Application.Features.HrRequests.Handlers.Queries
{
    public class GetHrRequestListRequestHandler : IRequestHandler<GetHrRequestListRequest, List<HrRequestListDto>>
    {
        private readonly IHrRequestRepository _hrRequestRepository;
        private readonly IMapper _mapper;

        public GetHrRequestListRequestHandler(IHrRequestRepository hrRequestRepository, IMapper mapper)
        {
            _hrRequestRepository = hrRequestRepository;
            _mapper = mapper;
        }
        public async Task<List<HrRequestListDto>> Handle(GetHrRequestListRequest request, CancellationToken cancellationToken)
        {
            var hrRequest = await _hrRequestRepository.GetHrRequestWithDetails();
            return _mapper.Map<List<HrRequestListDto>>(hrRequest);
        }
    }
}
