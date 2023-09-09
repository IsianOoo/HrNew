using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HrNew.Application.Features.HrTypes.Requests.Commands
{
    public class DeleteHrTypeCommand : IRequest
    {
        public int Id { get; set; }
    }
}
