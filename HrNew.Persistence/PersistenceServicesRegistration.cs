using HrNew.Application.Contracts.Presistence;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HrNew.Persistence
{
    public static class PersistenceServicesRegistration
    {
        public static IServiceCollection ConfigurePersistenceServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<HrManagementDbContext>(options =>
            options.UseSqlServer(
                configuration.GetConnectionString("HrManagementConnectionString")));

            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));

            services.AddScoped<IHrAllocationRepository, HrAllocationRepository>();
            services.AddScoped<IHrTypeRepository, HrTypeRepository>();
            services.AddScoped<IHrRequestRepository, HrRequestRepository>();

            return services;
        }
    }
}
