using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RealEstateProperties.Core.Interfaces;
using RealEstateProperties.Core.Interfaces.Repositories;
using RealEstateProperties.Core.Interfaces.Services;
using RealEstateProperties.Infrastructure.Data;
using RealEstateProperties.Infrastructure.Repositories;
using RealEstateProperties.Infrastructure.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealEstateProperties.Infrastructure.Extensions
{
    public static class ServiceCollectionExtension
    {
        public static IServiceCollection AddDbContexts(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<RealEstatePropertiesDBContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("dbRealStateProperty"))
            );

            return services;
        }

        public static void AddServices(this IServiceCollection services)
        {
            services.AddTransient<IOwnerService, OwnerService>();
            services.AddScoped(typeof(IRepository<>), typeof(BaseRepository<>));
            services.AddTransient<IUnitOfWork, UnitOfWork>();
        }
    }
}
