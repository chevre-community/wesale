using Core.Entities;
using Core.Entities.NotificationRelated;
using Core.Mappers.Web.Admin.UserManagement.UserActivation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.DataAccess.Repositories.Abstractions
{
    public interface IUserActivationRepository
    {
        Task<List<UserActivation>> GetAllAsync();

        Task<List<UserActivationViewModelMapper>> GetAllForAdminAsync();

        Task<UserActivation> GetAsync(int id);

        Task CreateAsync(UserActivation userActivation);

        Task UpdateAsync(UserActivation userActivation);
    }
}
