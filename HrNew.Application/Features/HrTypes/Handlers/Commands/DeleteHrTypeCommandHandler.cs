using AutoMapper;
using HrNew.Application.Contracts.Presistence;
using HrNew.Application.Exceptions;
using HrNew.Application.Features.HrTypes.Requests.Commands;
using HrNew.Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HrNew.Application.Features.HrTypes.Handlers.Commands
{
    public class DeleteHrTypeCommandHandler : IRequestHandler<DeleteHrTypeCommand>
    {
        private readonly IHrTypeRepository _hrTypeRepository;
        private readonly IMapper _mapper;

        public DeleteHrTypeCommandHandler(IHrTypeRepository hrTypeRepository, IMapper mapper)
        {
            _hrTypeRepository = hrTypeRepository;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(DeleteHrTypeCommand request, CancellationToken cancellationToken)
        {
            var hrType = await _hrTypeRepository.GetAsync(request.Id);

            if (hrType == null)
            {
                throw new NotFoundException(nameof(HrType), request.Id);
            }

            await _hrTypeRepository.DeleteAsync(hrType);

            return Unit.Value;
        }
    }
}
