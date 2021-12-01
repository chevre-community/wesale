using Core.Constants.Announcement;
using Core.DataAccess.Repositories.Abstractions;
using Core.Entities.Announcement;
using Core.Filters.API.Announcement;
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
    public class AnnouncementRepository : BaseRepository<Announcement>, IAnnouncementRepository
    {
        private readonly WeSaleContext _context;

        public AnnouncementRepository(WeSaleContext context)
            : base(context)
        {
            _context = context;
        }

        public async Task<List<AnnouncementViewModelMapper>> GetAllForAdminAsync()
        {
            return await _context.Announcements
                .OrderByDescending(a => a.Id)
                .Select(a => new AnnouncementViewModelMapper
                {
                    Id = a.Id,
                    Title = a.Title,
                    Description = a.Description,
                    Email = a.User.Email,
                    Status = a.Status,
                    CreatedAt = a.CreatedAt
                })
                .ToListAsync();
        }

        public async Task<List<Announcement>> GetAllRecentAsync(AnnouncementGetAllRecentFilterApiModel model)
        {
            var skipCount = (model.Row - 1) * model.Count;

            return await _context.Announcements
                       .Where(a => model.AnnouncementPropertyType != null ? a.AnnouncementProperty.Type == model.AnnouncementPropertyType : true)
                       .Include("AnnouncementProperty")
                       .Include("AnnouncementProperty.AnnouncementBuilding")
                       .Include("AnnouncementProperty.AnnouncementBuilding.AnnouncementNewBuilding")
                       .Include("AnnouncementProperty.AnnouncementBuilding.AnnouncementOldBuilding")
                       .Include("AnnouncementProperty.AnnouncementBuilding.AnnouncementHouseBuilding")
                       .Include("AnnouncementProperty.AnnouncementBuilding.AnnouncementGardenBuilding")
                       .Include("AnnouncementProperty.AnnouncementObject")
                       .Include("AnnouncementProperty.AnnouncementObject.AnnouncementOfficeObject")
                       .Include("AnnouncementProperty.AnnouncementObject.AnnouncementGarageObject")
                       .Include("AnnouncementProperty.AnnouncementObject.AnnouncementLandObject")
                       .Include("AnnouncementDeal")
                       .Include("AnnouncementDeal.AnnouncementSale")
                       .Include("AnnouncementDeal.AnnouncementRent")
                       .Include("AnnouncementLocation")
                       .Include("AnnouncementContact")
                       .Include("AnnouncementContact.AnnouncementContactNumbers")
                        .OrderByDescending(a => a.Id)
                        .Skip(skipCount)
                        .Take(model.Count)
                        .ToListAsync();
        }

        public async Task<Announcement> GetWithFilesAsync(int id)
        {
            return await _context.Announcements
                .Include(a => a.AnnouncementPhotos)
                .Include(a => a.AnnouncementVideos)
                .FirstOrDefaultAsync(a => a.Id == id);
        }

        public async Task<Announcement> GetWithNavigationPropertiesAsync(int id)
        {
            return await _context.Announcements
                   .OrderByDescending(a => a.Id)
                   .Include("User")
                   .Include("AnnouncementProperty")
                   .Include("AnnouncementProperty.AnnouncementBuilding")
                   .Include("AnnouncementProperty.AnnouncementBuilding.AnnouncementNewBuilding")
                   .Include("AnnouncementProperty.AnnouncementBuilding.AnnouncementOldBuilding")
                   .Include("AnnouncementProperty.AnnouncementBuilding.AnnouncementHouseBuilding")
                   .Include("AnnouncementProperty.AnnouncementBuilding.AnnouncementGardenBuilding")
                   .Include("AnnouncementProperty.AnnouncementObject")
                   .Include("AnnouncementProperty.AnnouncementObject.AnnouncementOfficeObject")
                   .Include("AnnouncementProperty.AnnouncementObject.AnnouncementGarageObject")
                   .Include("AnnouncementProperty.AnnouncementObject.AnnouncementLandObject")
                   .Include("AnnouncementDeal")
                   .Include("AnnouncementDeal.AnnouncementSale")
                   .Include("AnnouncementDeal.AnnouncementRent")
                   .Include("AnnouncementLocation")
                   .Include("AnnouncementContact")
                   .Include("AnnouncementContact.AnnouncementContactNumbers")
                   .FirstOrDefaultAsync(a => a.Id == id);
        }

        public async Task<List<Announcement>> FilterBuildingAsync(AnnouncementBuildingSearchFilterApiModel model)
        {
            var skipCount = (model.Page - 1) * model.Count;

            return await _context.Announcements
                                    .Where(a => a.AnnouncementProperty.Type == AnnouncementPropertyType.Building &&
                                     a.AnnouncementDeal.Type == model.DealType &&
                                     a.AnnouncementProperty.SubType == model.PropertySubType &&
                                     (
                                      ((model.PropertySubType == AnnouncementPropertySubType.NewBuilding) &&
                                       (model.AreaOfLand == null ? true : false) &&
                                       (model.RoomCount != null ? a.AnnouncementProperty.AnnouncementBuilding.AnnouncementNewBuilding.RoomCount == model.RoomCount : true) &&
                                       (model.Area != null ? a.AnnouncementProperty.AnnouncementBuilding.AnnouncementNewBuilding.Area == model.Area : true) &&
                                       (model.Floor != null ? a.AnnouncementProperty.AnnouncementBuilding.AnnouncementNewBuilding.Floor == model.Floor : true) &&
                                       (model.FloorCount != null ? a.AnnouncementProperty.AnnouncementBuilding.AnnouncementNewBuilding.FloorCount == model.FloorCount : true)) ||

                                       ((model.PropertySubType == AnnouncementPropertySubType.OldBuilding) &&
                                        (model.AreaOfLand == null ? true : false) &&
                                        (model.RoomCount != null ? a.AnnouncementProperty.AnnouncementBuilding.AnnouncementOldBuilding.RoomCount == model.RoomCount : true) &&
                                        (model.Area != null ? a.AnnouncementProperty.AnnouncementBuilding.AnnouncementOldBuilding.Area == model.Area : true) &&
                                        (model.Floor != null ? a.AnnouncementProperty.AnnouncementBuilding.AnnouncementOldBuilding.Floor == model.Floor : true) &&
                                        (model.FloorCount != null ? a.AnnouncementProperty.AnnouncementBuilding.AnnouncementOldBuilding.FloorCount == model.FloorCount : true)) ||

                                       ((model.PropertySubType == AnnouncementPropertySubType.House) &&
                                        (model.Floor == null ? true : false) &&
                                        (model.FloorCount == null ? true : false) &&
                                        (model.RoomCount != null ? a.AnnouncementProperty.AnnouncementBuilding.AnnouncementHouseBuilding.RoomCount == model.RoomCount : true) &&
                                        (model.Area != null ? a.AnnouncementProperty.AnnouncementBuilding.AnnouncementHouseBuilding.Area == model.Area : true) &&
                                        (model.AreaOfLand != null ? a.AnnouncementProperty.AnnouncementBuilding.AnnouncementHouseBuilding.AreaOfLand == model.AreaOfLand : true)) ||

                                       ((model.PropertySubType == AnnouncementPropertySubType.Garden) &&
                                        (model.RoomCount == null ? true : false) &&
                                        (model.Floor == null ? true : false) &&
                                        (model.FloorCount == null ? true : false) &&
                                        (model.Area != null ? a.AnnouncementProperty.AnnouncementBuilding.AnnouncementGardenBuilding.Area == model.Area : true) &&
                                        (model.AreaOfLand != null ? a.AnnouncementProperty.AnnouncementBuilding.AnnouncementGardenBuilding.AreaOfLand == model.AreaOfLand : true))
                                       ) &&
                                       
                                       (model.DealType == AnnouncementDealType.Sale ?
                                        (
                                         (model.CostFrom != null ? a.AnnouncementDeal.AnnouncementSale.CostFrom >= model.CostFrom : true) &&
                                         (model.CostTo != null ? a.AnnouncementDeal.AnnouncementSale.CostTo <= model.CostTo : true)
                                        ) : true
                                       ) &&

                                       (model.DealType == AnnouncementDealType.Rent ?
                                        (
                                         (model.CostFrom != null ? a.AnnouncementDeal.AnnouncementRent.Cost >= model.CostFrom : true) &&
                                         (model.CostTo != null ? a.AnnouncementDeal.AnnouncementRent.Cost <= model.CostTo : true)
                                        ) : true
                                       )
                                      )
                                   .OrderByDescending(a => a.Id)
                                   .Skip(skipCount)
                                   .Take(model.Count)
                                   .Include("AnnouncementProperty")
                                   .Include("AnnouncementProperty.AnnouncementBuilding")
                                   .Include("AnnouncementProperty.AnnouncementBuilding.AnnouncementNewBuilding")
                                   .Include("AnnouncementProperty.AnnouncementBuilding.AnnouncementOldBuilding")
                                   .Include("AnnouncementProperty.AnnouncementBuilding.AnnouncementHouseBuilding")
                                   .Include("AnnouncementProperty.AnnouncementBuilding.AnnouncementGardenBuilding")
                                   .Include("AnnouncementDeal")
                                   .Include("AnnouncementDeal.AnnouncementSale")
                                   .Include("AnnouncementDeal.AnnouncementRent")
                                   .Include("AnnouncementLocation")
                                   .Include("AnnouncementContact")
                                   .Include("AnnouncementContact.AnnouncementContactNumbers")
                                   .ToListAsync();
        }

        public async Task<List<Announcement>> FilterObjectAsync(AnnouncementObjectSearchFilterApiModel model)
        {
            var skipCount = (model.Page - 1) * model.Count;

            return await _context.Announcements
                             .Where(a => a.AnnouncementProperty.Type == AnnouncementPropertyType.Object &&
                              a.AnnouncementDeal.Type == model.DealType &&
                              (
                               ((model.PropertySubType == AnnouncementPropertySubType.Garage) &&
                                (model.RoomCount == null ? true : false) &&
                                (model.Area != null ? a.AnnouncementProperty.AnnouncementObject.AnnouncementGarageObject.Area == model.Area : true)) ||

                               ((model.PropertySubType == AnnouncementPropertySubType.Land) &&
                                (model.RoomCount == null ? true : false) &&
                                (model.Area != null ? a.AnnouncementProperty.AnnouncementObject.AnnouncementLandObject.Area == model.Area : true)) ||

                               ((model.PropertySubType == AnnouncementPropertySubType.Office) &&
                                (model.Area != null ? a.AnnouncementProperty.AnnouncementObject.AnnouncementOfficeObject.Area == model.Area : true) &&
                                (model.RoomCount != null ? a.AnnouncementProperty.AnnouncementObject.AnnouncementOfficeObject.RoomCount == model.RoomCount : true))
                               ) &&

                               (model.DealType == AnnouncementDealType.Sale ?
                                (
                                (model.CostFrom != null ? a.AnnouncementDeal.AnnouncementSale.CostFrom >= model.CostFrom : true) &&
                                (model.CostTo != null ? a.AnnouncementDeal.AnnouncementSale.CostTo <= model.CostTo : true)
                                ) : true
                               ) &&

                               (model.DealType == AnnouncementDealType.Rent ?
                                (
                                (model.CostFrom != null ? a.AnnouncementDeal.AnnouncementRent.Cost >= model.CostFrom : true) &&
                                (model.CostTo != null ? a.AnnouncementDeal.AnnouncementRent.Cost <= model.CostTo : true)
                                ) : true
                               )
                              )
                             .OrderByDescending(a => a.Id)
                             .Skip(skipCount)
                             .Take(model.Count)
                             .Include("AnnouncementProperty")
                             .Include("AnnouncementProperty.AnnouncementObject")
                             .Include("AnnouncementProperty.AnnouncementObject.AnnouncementOfficeObject")
                             .Include("AnnouncementProperty.AnnouncementObject.AnnouncementGarageObject")
                             .Include("AnnouncementProperty.AnnouncementObject.AnnouncementLandObject")
                             .Include("AnnouncementDeal")
                             .Include("AnnouncementDeal.AnnouncementSale")
                             .Include("AnnouncementDeal.AnnouncementRent")
                             .Include("AnnouncementLocation")
                             .Include("AnnouncementContact")
                             .Include("AnnouncementContact.AnnouncementContactNumbers")
                             .ToListAsync();
        }
    }
}
