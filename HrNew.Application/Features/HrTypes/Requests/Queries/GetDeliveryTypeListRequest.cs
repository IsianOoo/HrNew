using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HrNew.Application.Features.HrTypes.Requests.Queries
{
    internal class GetHrTypeListRequest : IRequest<List<HrTypeDto>>
    {
    }
}
