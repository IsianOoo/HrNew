using HrNew.Application.DTOs.HrType;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HrNew.Application.Features.HrTypes.Requests.Commands
{
    public class UpdateHrTypeCommand : IRequest<Unit>
    {
        public HrTypeDto HrTypeDto { get; set; }
    }
}
