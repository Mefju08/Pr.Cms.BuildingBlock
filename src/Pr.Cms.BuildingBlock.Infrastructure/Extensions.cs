using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Pr.Cms.BuildingBlock.Abstractions.Persistance;
using Pr.Cms.BuildingBlock.Domain.Time;
using Pr.Cms.BuildingBlock.Infrastructure.DomainEvents;
using Pr.Cms.BuildingBlock.Infrastructure.Persistance;
using Pr.Cms.BuildingBlock.Infrastructure.Persistance.Repositories;
using Pr.Cms.BuildingBlock.Infrastructure.Time;
using System.Reflection;

namespace Pr.Cms.BuildingBlock.Infrastructure
{
    public static class Extensions
    {
        public static IServiceCollection RegisterSharedInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            ArgumentNullException.ThrowIfNull(services, nameof(services));
            ArgumentNullException.ThrowIfNull(configuration, nameof(configuration));

            var systemDateTimeProvider = new SystemDateTimeProvider();
            Clock.Initialize(systemDateTimeProvider);

            services.AddSingleton<IDateTimeProvider, SystemDateTimeProvider>();

            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IDomainEventsDispatcher, DomainEventsDispatcher>();

            services.AddMediatR(cfg =>
                cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));
            services.AddScoped(typeof(IGenericRepository<,>), typeof(Repository<,>));

            return services;
        }

        public static IServiceCollection AddPostgre<TDbContext>(this IServiceCollection services, string connectionString) where TDbContext : DbContext
        {
            ArgumentNullException.ThrowIfNull(services, nameof(services));

            services.AddDbContext<TDbContext>(options =>
            {
                //options.UseNpgsql(connectionString);

                //for testing purpose
                options.UseInMemoryDatabase("test_connection_string");
            });
            services.AddScoped<DbContext>(provider => provider.GetRequiredService<TDbContext>());

            return services;
        }
    }
}
