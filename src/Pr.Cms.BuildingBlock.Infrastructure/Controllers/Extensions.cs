using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;

namespace Pr.Cms.BuildingBlock.Infrastructure.Controllers
{
    public static class Extensions
    {
        public static IServiceCollection AddApiResponseWrapper(this IServiceCollection services, bool applyToAllActions = true)
        {
            ArgumentNullException.ThrowIfNull(services, nameof(services));

            services.Configure<MvcOptions>(options =>
            {
                options.Filters.Add<ApiResponseWrapperFilter>();
            });

            return services;
        }
    }
}
