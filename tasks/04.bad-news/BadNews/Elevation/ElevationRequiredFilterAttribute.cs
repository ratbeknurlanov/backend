using System;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace BadNews.Elevation
{
    public class ElevationRequiredFilterAttribute : Attribute, IResourceFilter
    {
        public void OnResourceExecuting(ResourceExecutingContext context)
        {
            if (!context.HttpContext.Request.IsElevated())
                context.Result = new StatusCodeResult(StatusCodes.Status403Forbidden);
        }

        public void OnResourceExecuted(ResourceExecutedContext context)
        {
        }
    }
}
