using Microsoft.AspNetCore.Builder;

namespace Pr.Cms.BuildingBlock.Infrastructure.Exceptions
{
    public static class Extensions
    {
        public static IApplicationBuilder UseGlobalExceptions(this IApplicationBuilder app)
        {
            ArgumentNullException.ThrowIfNull(app, nameof(app));
            app.UseMiddleware<ExceptionHandlerMiddleware>();

            return app;
        }
    }
}
