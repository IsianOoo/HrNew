using AutoMapper;
using HrNew.Application.Exceptions;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HrNew.Application.Features.HrAllocations.Handlers.Commands
{
    public class DeleteHrAllocationCommandHandler : IRequestHandler<DeleteHrAllocationCommand>
    {
        private readonly IHrAllocationRepository _HrAllocationRepository;
        private readonly IMapper _mapper;

        public DeleteHrAllocationCommandHandler(IHrAllocationRepository HrAllocationRepository, IMapper mapper)
        {
            _HrAllocationRepository = HrAllocationRepository;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(DeleteHrAllocationCommand request, CancellationToken cancellationToken)
        {
            var HrAllocation = await _HrAllocationRepository.GetAsync(request.Id);

            if (HrAllocation == null)
            {
                throw new NotFoundException(nameof(HrAllocation), request.Id);
            }

            await _HrAllocationRepository.DeleteAsync(HrAllocation);

            return Unit.Value;
        }
    }
