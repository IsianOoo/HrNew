using AutoMapper;
using HrNew.Application.Contracts.Presistence;
using HrNew.Application.DTOs.HrType.Validators;
using HrNew.Application.Exceptions;
using HrNew.Application.Features.HrTypes.Requests.Commands;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HrNew.Application.Features.HrTypes.Handlers.Commands
{
    public class UpdateHrTypeCommandHandler : IRequestHandler<UpdateHrTypeCommand, Unit>
    {
        private readonly IHrTypeRepository _hrTypeRepository;
        private readonly IMapper _mapper;

        public UpdateHrTypeCommandHandler(IHrTypeRepository hrTypeRepository, IMapper mapper)
        {
            _hrTypeRepository = hrTypeRepository;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(UpdateHrTypeCommand request, CancellationToken cancellationToken)
        {
            var validator = new UpdateHrTypeDtoValidator();
            var validationResult = await validator.ValidateAsync(request.HrTypeDto);

            if (validationResult.IsValid == false)
            {
                throw new ValidationException(validationResult);
            }

            var hrType = await _hrTypeRepository.GetAsync(request.HrTypeDto.Id);

            _mapper.Map(request.HrTypeDto, hrType);

            await _hrTypeRepository.UpdateAsync(hrType);

            return Unit.Value;
        }
    }
}
