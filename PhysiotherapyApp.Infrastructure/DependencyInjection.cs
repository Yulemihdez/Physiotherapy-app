using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PhysiotherapyApp.Application.Interfaces;
using PhysiotherapyApp.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Text;
using PhysiotherapyApp.Application.Interfaces.Repositories;
using PhysiotherapyApp.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;

namespace PhysiotherapyApp.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(
        this IServiceCollection services,
        IConfiguration configuration)
        {
            var connectionString = configuration
                .GetConnectionString("DefaultConnection")
                ?? throw new InvalidOperationException(
                    "No se encontró la cadena DefaultConnection.");


            services.AddDbContext<PhysioDbContext>(options =>
                options.UseSqlServer(connectionString));

            //REPOSITORIOS
            services.AddScoped<IClientRepository, ClientRepository>();

            services.AddScoped<IUnitOfWork, UnitOfWork>();

            return services;
        }
    }
}