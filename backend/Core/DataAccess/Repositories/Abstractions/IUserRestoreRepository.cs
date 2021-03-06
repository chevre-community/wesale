using Core.Entities.NotificationRelated;
using Core.Mappers.Web.Admin.UserManagement.UserRestore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.DataAccess.Repositories.Abstractions
{
    public interface IUserRestoreRepository
    {
        Task<List<UserRestore>> GetAllAsync();

        Task<List<UserRestoreViewModelMapper>> GetAllForAdminAsync();

        Task<UserRestore> GetAsync(int id);

        Task CreateAsync(UserRestore userRestore);

        Task UpdateAsync(UserRestore userRestore);
    }
}
