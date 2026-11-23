using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PhysiotherapyApp.Application.Interfaces.Repositories;
using System.Threading.Tasks;


namespace PhysiotherapyApp.Application.Interfaces
{

    public interface IUnitOfWork
    {
        IClientRepository Patient { get; }

        Task<int> SaveChangesAsync(
            CancellationToken cancellationToken = default);
    }
}
