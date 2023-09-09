using HrNew.Application.Contracts.Presistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HrNew.Persistence.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly HrManagementDbContext _context;
        private IHrAllocationRepository _hrAllocationRepository;
        private IHrRequestRepository _hrRequestRepository;
        private IHrTypeRepository _hrTypeRepository;
        public UnitOfWork(HrManagementDbContext context)
        {
            _context = context;
        }

        public IHrRequestRepository HrRequestRepository => _hrRequestRepository ??= new HrRequestRepository(_context);

        public IHrAllocationRepository HrAllocationRepository => _hrAllocationRepository ??= new HrAllocationRepository(_context);

        public IHrTypeRepository HrTypeRepository => _hrTypeRepository ??= new HrTypeRepository(_context);

        public void Dispose()
        {
            _context.Dispose();
            GC.SuppressFinalize(this);
        }

        public async Task Save()
        {
            await _context.SaveChangesAsync();
        }
    }
}
