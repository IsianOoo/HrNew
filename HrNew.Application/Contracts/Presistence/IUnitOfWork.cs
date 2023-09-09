using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HrNew.Application.Contracts.Presistence
{
    public interface IUnitOfWork : IDisposable
    {
        IHrRequestRepository HrRequestRepository { get; }
        IHrAllocationRepository HrAllocationRepository { get; }
        IHrTypeRepository HrTypeRepository { get; }
        Task Save();
    }
}
