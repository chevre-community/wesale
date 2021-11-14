using Core.Constants.User;
using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Services.Business.Data.Abstractions
{
    public interface IPermissionService
    {
        List<Permission> GetAll();
        bool IsExists(string key);
        Task<List<Permission>> GetByUserAsync(User user);

        //Task<List<ClaimViewModelMapper>> GetByRoleAsync(Role role);
    }
}
