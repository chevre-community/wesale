using Core.Admin.UserManagement.User;
using Core.Constants.User;
using Core.DataAccess.Repositories.Abstractions;
using Core.Entities;
using Core.Mappers.API.v1.User;
using Core.Mappers.Web.Admin.CoreManagement.PhonePrefix;
using Core.Mappers.Web.Admin.CoreManagement.Translation;
using DataAccess.Contexts;
using DataAccess.Repositories.Base;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories.Implementations
{
    public class PhonePrefixRepository : BaseRepository<PhonePrefix>, IPhonePrefixRepository
    {
        private readonly WeSaleContext _context;

        public PhonePrefixRepository(WeSaleContext context)
            :base(context)
        {
            _context = context;
        }

        public async Task<PhonePrefix> GetByPrefix(string prefix)
        {
            return await _context.PhonePrefixes.FirstOrDefaultAsync(pp => pp.Prefix == prefix);
        }

        public async Task<Dictionary<int, string>> GetAllActive()
        {
            return (await _context.PhonePrefixes
                .OrderBy(pp => pp.Order)
                .Where(pp => pp.IsActive)
                .ToListAsync())
                .ToDictionary(pp => pp.Id, pp => pp.Prefix);
        }

        public async Task<List<PhonePrefixViewModelMapper>> GetAllForAdminAsync()
        {
            return await _context.PhonePrefixes
                .OrderByDescending(t => t.Id)
                .Select(pp => new PhonePrefixViewModelMapper
                {
                    Id = pp.Id,
                    Country = pp.Country,
                    Prefix = pp.Prefix,
                    Order = pp.Order,
                    IsActive = pp.IsActive
                }).ToListAsync();
        }
    }
}
