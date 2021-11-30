using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Services.JWT.Abstractions
{
    public interface IJwtService
    {
        string GenerateJwtToken(User user);
    }
}
