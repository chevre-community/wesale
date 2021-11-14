using Core.Entities.NotificationRelated;
using Core.Mappers.Web.Admin.UserManagement.UserActivation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Services.Business.Data.Abstractions
{
    public interface IUserActivationService 
    {
        Task<List<UserActivation>> GetAllAsync();
        Task<List<UserActivationViewModelMapper>> GetAllForAdminAsync();

        Task<UserActivation> GetAsync(int id);

        Task CreateAsync(UserActivation userActivation);

        Task UpdateAsync(UserActivation userActivation);
    }
}
