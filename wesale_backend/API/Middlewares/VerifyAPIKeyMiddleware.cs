using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace API.Middlewares
{
    // You may need to install the Microsoft.AspNetCore.Http.Abstractions package into your project
    public class VerifyAPIKeyMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger _logger;

        public VerifyAPIKeyMiddleware(RequestDelegate next, ILoggerFactory logFactory)
        {
            _next = next;
            _logger = logFactory.CreateLogger<VerifyAPIKeyMiddleware>();
        }

        public async Task Invoke(HttpContext httpContext)
        {
            string CLIENT_API_KEY = GetClientAPIKey(httpContext.Request);

            if (CLIENT_API_KEY != null)
            {
                if (ValidateAPIKey(httpContext, CLIENT_API_KEY))
                {
                    httpContext.Response.StatusCode = (int)HttpStatusCode.Forbidden;
                    await httpContext.Response.WriteAsync("API Key invalid");

                    return;
                }
                else
                {
                    await _next(httpContext);

                    return;
                }
            }
            else
            {
                httpContext.Response.StatusCode = (int)HttpStatusCode.Forbidden;
                await httpContext.Response.WriteAsync("API Key required");

                return;
            }

        }

        private IConfiguration GetConfigurationService(HttpContext httpContext)
        {
            IServiceProvider serviceProvider = httpContext.RequestServices;
            return serviceProvider.GetRequiredService<IConfiguration>();
        }

        private string GetClientAPIKey(HttpRequest httpRequest)
        {
            return httpRequest.Headers["CLIENT_API_KEY"];
        }

        private bool ValidateAPIKey(HttpContext httpContext, string clientApiKey)
        {
            IConfiguration configruation = GetConfigurationService(httpContext);
            string API_KEY = configruation.GetValue<string>("API_KEY"); ;
            return API_KEY != clientApiKey;
        }
    }


    // Extension method used to add the middleware to the HTTP request pipeline.
    public static class VerifyAPIKeyMiddlewareExtensions
    {
        public static IApplicationBuilder UseVerifyAPIKeyMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<VerifyAPIKeyMiddleware>();
        }
    }
}
