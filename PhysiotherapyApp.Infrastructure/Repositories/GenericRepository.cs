using Microsoft.EntityFrameworkCore;
using PhysiotherapyApp.Application.Interfaces.Repositories;
using PhysiotherapyApp.Infrastructure.Data;
using PhysiotherapyApp.Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace PhysiotherapyApp.Infrastructure.Repositories
{

    public class GenericRepository<T> : IGenericRepository<T>
        where T : class
    {
        protected readonly PhysioDbContext _context;

        protected readonly DbSet<T> _dbSet;

        public GenericRepository(PhysioDbContext context)
        {
            _context = context;
            _dbSet = context.Set<T>();
        }

        public async Task<IEnumerable<T>> ObtenerTodosAsync()
        {
            return await _dbSet
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<T?> ObtenerPorIdAsync(int id)
        {
            return await _dbSet.FindAsync(id);
        }

        public async Task AgregarAsync(T entidad)
        {
            await _dbSet.AddAsync(entidad);
        }

        public void Actualizar(T entidad)
        {
            _dbSet.Update(entidad);
        }

        public void Eliminar(T entidad)
        {
            _dbSet.Remove(entidad);
        }
    }
}