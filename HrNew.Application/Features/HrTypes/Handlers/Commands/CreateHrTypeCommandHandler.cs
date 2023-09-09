using AutoMapper;
using HrNew.Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HrNew.Application.Features.HrTypes.Handlers.Commands
{
    public class CreateHrTypeCommandHandler : IRequestHandler<CreateHrTypeCommand, BaseCommandResponse>
    {
        private readonly IHrTypeRepository _hrTypeRepository;
        private readonly IMapper _mapper;

        public CreateHrTypeCommandHandler(IHrTypeRepository hrTypeRepository, IMapper mapper)
        {
            _hrTypeRepository = hrTypeRepository;
            _mapper = mapper;
        }
        public async Task<BaseCommandResponse> Handle(CreateHrTypeCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseCommandResponse();
            var validator = new CreateHrTypeDtoValidator();
            var validationResult = await validator.ValidateAsync(request.HrTypeDto);

            if (validationResult.IsValid == false)
            {
                response.Success = false;
                response.Message = "Creation Failed";
                response.Errors = validationResult.Errors.Select(q => q.ErrorMessage).ToList();
            }
            else
            {
                var hrType = _mapper.Map<HrType>(request.HrTypeDto);

                hrType = await _hrTypeRepository.AddAsync(hrType);

                response.Success = true;
                response.Message = "Creation Successful";
                response.Id = hrType.Id;
            }

            return response;

        }
    }
}
