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
    public class AnnouncementVideoRepository : BaseRepository<AnnouncementVideo>, IAnnouncementVideoRepository
    {
        private readonly WeSaleContext _context;

        public AnnouncementVideoRepository(WeSaleContext context)
            : base(context)
        {
            _context = context;
        }

        public async Task<List<AnnouncementVideoViewModelMapper>> GetAllByAnnouncementId(int announcementId)
        {
            return await _context.AnnouncementVideos
                .Where(a => a.AnnouncementId == announcementId)
                .Select(a => new AnnouncementVideoViewModelMapper
                {
                    Id = a.Id,
                    Name = a.Name
                })
                .ToListAsync();
        }

        public async Task<AnnouncementVideo> GetByNameAsync(string name)
        {
            return await _context.AnnouncementVideos
                    .FirstOrDefaultAsync(a => a.Name == name);
        }

        public async Task<AnnouncementVideo> GetByUserAndNameAsync(User user, string name)
        {
            return await _context.AnnouncementVideos
                    .FirstOrDefaultAsync(a => a.UserId == user.Id && a.Name == name);
        }

        public async Task DeleteByNameAsync(string name)
        {
            var announcementVideo = await _context.AnnouncementVideos.FirstOrDefaultAsync(a => a.Name == name);
            if (announcementVideo != null) _context.AnnouncementVideos.Remove(announcementVideo);
        }

        public async Task<bool> CheckByRequestIdAsync(string requestId, int count)
        {
            const int MAXIMUM = 3;

            count += await _context.AnnouncementVideos
                                .Where(a => a.RequestId == requestId)
                                .CountAsync();

            if (count < MAXIMUM)
                return true;

            return false;
        }
    }
}
