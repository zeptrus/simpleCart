namespace Cart.UI.Middleware
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNet.Builder;
    using Microsoft.AspNet.Http;

    public class GlobalExceptionMiddleware
    {
        RequestDelegate _next;

        public GlobalExceptionMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next.Invoke(context);
            }
            catch (Exception e)
            {
                Debug.WriteLine($"{context.User.Identity.Name} {context.Request.Method} {context.Request.Path}{context.Request.QueryString} {e.GetBaseException().Message}\nStack trace::\n{e.StackTrace}");
                context.Response.StatusCode = 500;
            }
        }
    }
}
