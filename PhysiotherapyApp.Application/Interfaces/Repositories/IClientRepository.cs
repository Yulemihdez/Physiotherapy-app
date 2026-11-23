
using PhysiotherapyApp.Domain.Entities;
using System.Threading.Tasks;

namespace PhysiotherapyApp.Application.Interfaces.Repositories
{
  
    public interface IClientRepository
        : IGenericRepository<Patient>
    {
        Task<Patient?> ObtenerPorEmailAsync(string email);
    }
}
