using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Pr.Cms.BuildingBlock.Infrastructure.DomainEvents
{
    public static class Extensions
    {
        public static IServiceCollection RegisterDomainEventHandlers(this IServiceCollection services, params Assembly[] assembliesWithHandlers)
        {
            ArgumentNullException.ThrowIfNull(services, nameof(services));
            if (assembliesWithHandlers?.Length > 0)
            {
                services.AddMediatR(cfg =>
                    cfg.RegisterServicesFromAssemblies(assembliesWithHandlers));
            }

            return services;
        }
    }
}
