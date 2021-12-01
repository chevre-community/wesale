using Core.Services.Business.Data.Abstractions;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Services.Business.Data.Implementations
{
    /// <summary>
    ///     Extracts current user details from http context
    /// </summary>
    public class CurrentUserService : ICurrentUserService
    {
        public CurrentUserService(IHttpContextAccessor httpContextAccessor)
        {
            var httpContext = httpContextAccessor.HttpContext;

            if (httpContext != null)
            {
                var userId = httpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);
                UserId = httpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);
                IsAuthenticated = httpContext.User.Identity.IsAuthenticated;
                Roles = httpContext.User.FindAll(ClaimTypes.Role).Select(e => e.Value).ToHashSet();
            }
        }

        public string UserId { get; }
        public bool IsAuthenticated { get; }
        public HashSet<string> Roles { get; }
    }
}
