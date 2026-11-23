using Microsoft.EntityFrameworkCore;
using PhysiotherapyApp.Infrastructure.Data;
using PhysiotherapyApp.Application.Interfaces.Repositories;
using PhysiotherapyApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace PhysiotherapyApp.Infrastructure.Repositories
{
    public class ClientRepository: GenericRepository<Patient>, IClientRepository
    {
        public ClientRepository(PhysioDbContext context)
            : base(context)
        {
        }

        public async Task<Patient?> ObtenerPorEmailAsync(
            string email)
        {
            return await _context.Patients
                .AsNoTracking()
                .FirstOrDefaultAsync(e => e.Email == email);
        }
    }
}