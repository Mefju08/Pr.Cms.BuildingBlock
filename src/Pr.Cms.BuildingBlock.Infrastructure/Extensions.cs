using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Pr.Cms.BuildingBlock.Core.Repositories;
using Pr.Cms.BuildingBlock.Core.Time;
using Pr.Cms.BuildingBlock.Infrastructure.DomainEvents;
using Pr.Cms.BuildingBlock.Infrastructure.Exceptions;
using Pr.Cms.BuildingBlock.Infrastructure.Persistance;
using Pr.Cms.BuildingBlock.Infrastructure.Time;
using System.Reflection;
using Wolverine;

namespace Pr.Cms.BuildingBlock.Infrastructure
{
    public static class Extensions
    {
        public static IServiceCollection AddSharedInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            ArgumentNullException.ThrowIfNull(services, nameof(services));
            ArgumentNullException.ThrowIfNull(configuration, nameof(configuration));

            var systemDateTimeProvider = new SystemDateTimeProvider();
            Clock.Initialize(systemDateTimeProvider);

            services.AddSingleton<IDateTimeProvider, SystemDateTimeProvider>();

            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IDomainEventsDispatcher, DomainEventsDispatcher>();
            services.AddSingleton<ExceptionHandlerMiddleware>();

            return services;
        }
        public static IHostBuilder UseSharedWolverine(this IHostBuilder hostBuilder, params Assembly[] assemblies)
        {
            ArgumentNullException.ThrowIfNull(hostBuilder, nameof(hostBuilder));

            if (assemblies?.Length > 0)
            {
                hostBuilder.UseWolverine(opts =>
                {
                    foreach (var assembly in assemblies)
                    {
                        opts.Discovery.IncludeAssembly(assembly);
                    }
                });
            }

            return hostBuilder;
        }
        public static IServiceCollection AddPostgres<TDbContext>(this IServiceCollection services, string connectionString) where TDbContext : DbContext
        {
            ArgumentNullException.ThrowIfNull(services, nameof(services));
            ArgumentNullException.ThrowIfNullOrEmpty(connectionString, nameof(connectionString));

            services.AddDbContext<TDbContext>(options =>
            {
                options.UseNpgsql(connectionString);
            });

            services.AddScoped<DbContext>(provider => provider.GetRequiredService<TDbContext>());

            return services;
        }
    }
}
