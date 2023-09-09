using HrNew.Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HrNew.Application.Features.HrAllocations.Requests.Commands
{
    public class CreateHrAllocationCommand : IRequest<BaseCommandResponse>
    {
        public CreateHrAllocationDto HrAllocationDto { get; set; }
    }
}
