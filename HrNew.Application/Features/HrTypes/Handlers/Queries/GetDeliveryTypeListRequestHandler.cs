using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HrNew.Application.Features.HrTypes.Handlers.Queries
{
    public class GetHrTypeListRequestHandler : IRequestHandler<GetHrTypeListRequest, List<HrTypeDto>>
    {
        private readonly IHrTypeRepository _hrTypeRepository;
        private readonly IMapper _mapper;

        public GetHrTypeListRequestHandler(IHrTypeRepository hrTypeRepository, IMapper mapper)
        {
            _hrTypeRepository = hrTypeRepository;
            _mapper = mapper;
        }

        public async Task<List<HrTypeDto>> Handle(GetHrTypeListRequest request, CancellationToken cancellationToken)
        {
            var hrTypes = await _hrTypeRepository.GetAllAsync();
            return _mapper.Map<List<HrTypeDto>>(hrTypes);
        }
    }
}
