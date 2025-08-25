using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace Pr.Cms.BuildingBlock.Infrastructure.Exceptions
{
    public static class Extensions
    {
        public static IServiceCollection RegisterGlobalExceptionHandler(this IServiceCollection services)
        {
            services.AddSingleton<ExceptionHandlerMiddleware>();
            return services;
        }
        public static IApplicationBuilder UseGlobalExceptionHandler(this IApplicationBuilder app)
        {
            ArgumentNullException.ThrowIfNull(app, nameof(app));

            return app.UseMiddleware<ExceptionHandlerMiddleware>();
        }
    }
}
