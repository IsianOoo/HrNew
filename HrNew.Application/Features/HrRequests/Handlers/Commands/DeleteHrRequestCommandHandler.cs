using AutoMapper;
using HrNew.Application.Contracts.Presistence;
using HrNew.Application.Exceptions;
using HrNew.Application.Features.HrRequests.Requests.Commands;
using HrNew.Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HrNew.Application.Features.HrRequests.Handlers.Commands
{
    public class DeleteHrRequestCommandHandler : IRequestHandler<DeleteHrRequestCommand>
    {
        private readonly IHrRequestRepository _hrRequestRepository;
        private readonly IMapper _mapper;

        public DeleteHrRequestCommandHandler(IHrRequestRepository hrRequestRepository, IMapper mapper)
        {
            _hrRequestRepository = hrRequestRepository;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(DeleteHrRequestCommand request, CancellationToken cancellationToken)
        {
            var hrRequest = await _hrRequestRepository.GetAsync(request.Id);

            if (hrRequest == null)
            {
                throw new NotFoundException(nameof(HrRequest), request.Id);
            }

            await _hrRequestRepository.DeleteAsync(hrRequest);

            return Unit.Value;
        }
    }
}
