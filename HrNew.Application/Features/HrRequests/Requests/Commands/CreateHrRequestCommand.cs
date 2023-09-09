using HrNew.Application.DTOs.HrRequest;
using HrNew.Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HrNew.Application.Features.HrRequests.Requests.Commands
{
    public class CreateHrRequestCommand : IRequest<BaseCommandResponse>
    {
        public CreateHrRequestDto HrRequestDto { get; set; }
    }
}
