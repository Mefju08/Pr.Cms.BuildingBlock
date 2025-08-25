using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Pr.Cms.BuildingBlock.Infrastructure.Controllers
{
    public class ApiResponseWrapperFilter : IAsyncActionFilter
    {
        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            var resultContext = await next();

            if (resultContext.Result is ObjectResult objectResult)
            {
                var value = objectResult.Value;
                var wrappedResult = new { data = value };
                resultContext.Result = new ObjectResult(wrappedResult)
                {
                    StatusCode = objectResult.StatusCode
                };
            }
        }
    }


}
