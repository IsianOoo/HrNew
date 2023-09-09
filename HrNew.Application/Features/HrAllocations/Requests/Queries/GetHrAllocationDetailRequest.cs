using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HrNew.Application.Features.HrAllocations.Requests.Queries
{
    internal class GetHrAllocationDetailRequest : IRequest<HrAllocationDto>
    {
        public int Id { get; set; }
    }
}
