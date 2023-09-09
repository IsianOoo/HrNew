using HrNew.Application.DTOs.HrRequest;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HrNew.Application.Features.HrRequests.Requests.Queries
{
    public class GetHrRequestListRequest : IRequest<List<HrRequestListDto>>
    {
    }
}
