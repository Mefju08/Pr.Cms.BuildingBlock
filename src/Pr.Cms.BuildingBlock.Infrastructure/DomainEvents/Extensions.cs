using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using Wolverine;

namespace Pr.Cms.BuildingBlock.Infrastructure.DomainEvents
{
    public static class Extensions
    {
        public static IServiceCollection RegisterDomainEventHandlers(this IServiceCollection services, ConfigureHostBuilder hostBuilder, params Assembly[] assembliesWithHandlers)
        {
            ArgumentNullException.ThrowIfNull(services, nameof(services));
            if (assembliesWithHandlers?.Length > 0)
            {
                hostBuilder.UseWolverine(opts =>
                {
                    foreach (var assembly in assembliesWithHandlers)
                    {
                        opts.Discovery.IncludeAssembly(assembly);
                    }
                });
            }

            return services;
        }
    }
}
