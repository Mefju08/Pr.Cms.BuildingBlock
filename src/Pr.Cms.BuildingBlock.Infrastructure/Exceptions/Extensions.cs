using Microsoft.AspNetCore.Builder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
