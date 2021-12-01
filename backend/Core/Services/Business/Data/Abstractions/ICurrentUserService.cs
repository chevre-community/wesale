using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Services.Business.Data.Abstractions
{
    /// <summary>
    ///     Provides information about current user
    /// </summary>
    public interface ICurrentUserService
    {
        string UserId { get; }
        bool IsAuthenticated { get; }
        HashSet<string> Roles { get; }
    }
}
