﻿using System.Net;

namespace UnitOfWork.MiddleWare
{
    public class ErrorHandalingMiddleware
    {
        private readonly RequestDelegate _next;

        public ErrorHandalingMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext httpContext)
        {
            await _next(httpContext);




            if (httpContext.Response.StatusCode == (int)HttpStatusCode.NotFound && !httpContext.Response.HasStarted && !httpContext.Request.Path.StartsWithSegments("/Error"))
            {
                httpContext.Response.Redirect("/Error/NotFoundEx");
            }

            if (httpContext.Response.StatusCode == (int)HttpStatusCode.Ambiguous && !httpContext.Response.HasStarted && !httpContext.Request.Path.StartsWithSegments("/Error"))
            {
                httpContext.Response.Redirect("/Error/Ambiguous");
            }

            if (httpContext.Response.StatusCode == (int)HttpStatusCode.BadRequest && !httpContext.Response.HasStarted && !httpContext.Request.Path.StartsWithSegments("/Error"))
            {
                httpContext.Response.Redirect("/Error/BadRequestEx");
            }

            if (httpContext.Response.StatusCode == (int)HttpStatusCode.InternalServerError && !httpContext.Response.HasStarted && !httpContext.Request.Path.StartsWithSegments("/Error"))
            {
                httpContext.Response.Redirect("/Error/InternalServerError");
            }

            if (httpContext.Response.StatusCode == (int)HttpStatusCode.LoopDetected && !httpContext.Response.HasStarted && !httpContext.Request.Path.StartsWithSegments("/Error"))
            {
                httpContext.Response.Redirect("/Error/LoopDetected");
            }

            if (httpContext.Response.StatusCode == (int)HttpStatusCode.Unauthorized && !httpContext.Response.HasStarted && !httpContext.Request.Path.StartsWithSegments("/Error"))
            {
                httpContext.Response.Redirect("/Error/UnAuthorized");
            }

        }
    }

    public static class ErrorHandalingMiddlewareExtensions
    {
        public static IApplicationBuilder UseErrorHandalingMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<ErrorHandalingMiddleware>();
        }
    }
}
