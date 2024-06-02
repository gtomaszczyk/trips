using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using TripAPI.Common;

namespace TripAPI.Infrastructure
{
    public class ValidationAsyncActionFilter : IAsyncActionFilter
    {
        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            foreach (var argument in context.ActionArguments.Values)
            {
                if (argument is not IValidatable validatableArgument)
                    continue;

                var errors = validatableArgument.Validate();
                if (errors.ErrorMessages.Count > 0)
                {
                    context.Result = new BadRequestObjectResult(errors);
                    return;
                }
                    
            }
            await next();
        }
    }
}
