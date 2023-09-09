using HrNew.Application.DTOs.HrRequest;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HrNew.Application.Features.HrRequests.Requests.Commands
{
    public class UpdateHrRequestCommand : IRequest<Unit>
    {
        public int Id { get; set; }
        public UpdateHrRequestDto HrRequestDto { get; set; }
    }
}
