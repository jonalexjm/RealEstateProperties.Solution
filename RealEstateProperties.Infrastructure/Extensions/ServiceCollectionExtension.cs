using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using RealEstateProperties.Core.Interfaces;
using RealEstateProperties.Core.Interfaces.Repositories;
using RealEstateProperties.Core.Interfaces.Services;
using RealEstateProperties.Infrastructure.Data;
using RealEstateProperties.Infrastructure.Repositories;
using RealEstateProperties.Infrastructure.Services;
using System;

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
            services.AddTransient<IPropertyImageService, PropertyImageService>();
            services.AddTransient<IPropertyService, PropertyService>();
            services.AddTransient<IPropertyTraceService, PropertyTraceService>();
            services.AddScoped(typeof(IRepository<>), typeof(BaseRepository<>));
            services.AddTransient<IUnitOfWork, UnitOfWork>();
        }

        public static void AddSwagger(this IServiceCollection services, IConfiguration Configuration)
        {
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "Real Estate Properties Api",
                    Version = "v1"
                });
                var securitySchema = new OpenApiSecurityScheme
                {
                    Description = "JWT Authorization header using the Bearer scheme. Example: \"Authorization: Bearer {token}\"",
                    Name = "Authorization",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.Http,
                    Scheme = "bearer",
                    Reference = new OpenApiReference
                    {
                        Type = ReferenceType.SecurityScheme,
                        Id = "Bearer"
                    }
                };
                c.AddSecurityDefinition("Bearer", securitySchema);

                var securityRequirement = new OpenApiSecurityRequirement
                    {
                        { securitySchema, new[] { "Bearer" } }
                    };

                c.AddSecurityRequirement(securityRequirement);
            });
        }
    }
}
