using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;
using PhysiotherapyApp.Application.Services;


namespace PhysiotherapyApp.Application
{

    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(
            this IServiceCollection services)
        {
            //SERVICES 
            services.AddScoped<IPatientService, PatientService>();

       

            return services;
        }
    }
}