using AutoMapper;
using HrNew.Application.Contracts.Presistence;
using HrNew.Application.DTOs.HrType;
using HrNew.Application.Features.HrTypes.Requests.Queries;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HrNew.Application.Features.HrTypes.Handlers.Queries
{
    public class GetHrTypeDetailRequestHandler : IRequestHandler<GetHrTypeDetailRequest, HrTypeDto>
    {
        private readonly IHrTypeRepository _hrTypeRepository;
        private readonly IMapper _mapper;

        public GetHrTypeDetailRequestHandler(IHrTypeRepository hrTypeRepository, IMapper mapper)
        {
            _hrTypeRepository = hrTypeRepository;
            _mapper = mapper;
        }

        public async Task<HrTypeDto> Handle(GetHrTypeDetailRequest request, CancellationToken cancellationToken)
        {
            var hrType = await _hrTypeRepository.GetAsync(request.Id);
            return _mapper.Map<HrTypeDto>(hrType);
        }
    }
}
