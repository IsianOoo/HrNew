using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HrNew.Application.Features.HrRequests.Handlers.Queries
{
    public class GetHrRequestDetailRequestHandler : IRequestHandler<GetHrRequestDetailRequest, HrRequestDto>
    {
        private readonly IHrRequestRepository _hrRequestRepository;
        private readonly IMapper _mapper;

        public GetHrRequestDetailRequestHandler(IHrRequestRepository hrRequestRepository, IMapper mapper)
        {
            _hrRequestRepository = hrRequestRepository;
            _mapper = mapper;
        }
        public async Task<HrRequestDto> Handle(GetHrRequestDetailRequest request, CancellationToken cancellationToken)
        {
            var hrRequest = await _hrRequestRepository.GetHrRequestWithDetails(request.Id);
            return _mapper.Map<HrRequestDto>(hrRequest);
        }
    }
}
