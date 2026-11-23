using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhysiotherapyApp.Application.Interfaces.Repositories
{
   
    public interface IGenericRepository<T> where T : class
    {
        Task<IEnumerable<T>> ObtenerTodosAsync();

        Task<T?> ObtenerPorIdAsync(int id);

        Task AgregarAsync(T entidad);

        void Actualizar(T entidad);

        void Eliminar(T entidad);
    }
}

