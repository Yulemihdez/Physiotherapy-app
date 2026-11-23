using PhysiotherapyApp.Application.Interfaces;
using System;
using System.Collections.Generic;
using PhysiotherapyApp.Application.Interfaces.Repositories;
using PhysiotherapyApp.Infrastructure.Data;
using System.Text;

namespace PhysiotherapyApp.Infrastructure
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly PhysioDbContext _context;

        public IClientRepository Patient { get; }

        public UnitOfWork(
            PhysioDbContext context,
            IClientRepository clientRepository)
        {
            _context = context;
            Patient = clientRepository;
        }

        public async Task<int> SaveChangesAsync(
            CancellationToken cancellationToken = default)
        {
            return await _context.SaveChangesAsync(cancellationToken);
        }
    }
}