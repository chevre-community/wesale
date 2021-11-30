using Core.DataAccess.Repositories.Abstractions;
using Core.Entities;
using Core.Entities.Announcement;
using Core.Mappers.Web.Admin.ComponentManagement.Announcement;
using DataAccess.Contexts;
using DataAccess.Repositories.Base;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories.Implementations
{
    public class AnnouncementPhotoRepository : BaseRepository<AnnouncementPhoto>, IAnnouncementPhotoRepository
    {
        private readonly WeSaleContext _context;

        public AnnouncementPhotoRepository(WeSaleContext context)
            :base(context)
        {
            _context = context;
        }

        public async Task<List<AnnouncementPhotoViewModelMapper>> GetAllByAnnouncementId(int announcementId)
        {
            return await _context.AnnouncementPhotos
                .Where(a => a.AnnouncementId == announcementId)
                .Select(a => new AnnouncementPhotoViewModelMapper
                {
                    Id = a.Id,
                    Name = a.Name
                })
                .ToListAsync();
        }

        public async Task<AnnouncementPhoto> GetByNameAsync(string name)
        {
            return await _context.AnnouncementPhotos
                   .FirstOrDefaultAsync(a => a.Name == name);
        }

        public async Task<AnnouncementPhoto> GetByUserAndNameAsync(User user, string name)
        {
            return await _context.AnnouncementPhotos
                   .FirstOrDefaultAsync(a => a.UserId == user.Id && a.Name == name);
        }

        public async Task DeleteByNameAsync(string name)
        {
            var announcementPhoto = await _context.AnnouncementPhotos.FirstOrDefaultAsync(a => a.Name == name);
            if (announcementPhoto != null) _context.AnnouncementPhotos.Remove(announcementPhoto);
        }

        public async Task<bool> CheckByRequestIdAsync(string requestId, int count)
        {
            const int MAXIMUM = 1;

            count += await _context.AnnouncementPhotos
                                .Where(a => a.RequestId == requestId)
                                .CountAsync();

            if (count <= MAXIMUM)
                return true;

            return false;
        }
    }
}
