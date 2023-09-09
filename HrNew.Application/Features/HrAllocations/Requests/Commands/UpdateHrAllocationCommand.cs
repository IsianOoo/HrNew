using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HrNew.Application.Features.HrAllocations.Requests.Commands
{
    public class UpdateHrAllocationCommand : IRequest<Unit>
    {
        public HrAllocationDto HrAllocationDto { get; set; }
    }
}
