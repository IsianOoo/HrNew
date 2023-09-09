using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HrNew.Application.Features.HrRequests.Requests.Commands
{
    public class DeleteHrRequestCommand : IRequest
    {
        public int Id { get; set; }
    }
}
