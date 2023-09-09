using HrNew.Application.DTOs.HrType;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HrNew.Application.Features.HrTypes.Requests.Queries
{
    public class GetHrTypeDetailRequest : IRequest<HrTypeDto>
    {
        public int Id { get; set; }
    }
}
