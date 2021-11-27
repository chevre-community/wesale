using Core.Entities;
using Core.Entities.Abstraction;
using Core.Entities.Announcement;
using Core.Entities.Announcement.AnnouncementBuilding;
using Core.Entities.Announcement.AnnouncementContact;
using Core.Entities.Announcement.AnnouncementObject;
using Core.Entities.NotificationRelated;
using DataAccess.Configurations;
using DataAccess.Configurations.Announcement;
using DataAccess.Configurations.Announcement.AnnouncementBuilding;
using DataAccess.Configurations.Announcement.AnnouncementObject;
using DataAccess.Configurations.AnnouncementBuilding;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DataAccess.Contexts
{
    public class WeSaleContext : IdentityDbContext<User, Role, string>
    {
        public WeSaleContext(DbContextOptions<WeSaleContext> options)
        :base(options)
        {

        }

        public DbSet<NotifyEvent> NotifyEvents { get; set; }
        public DbSet<SmsOperationResult> SmsOperationResults { get; set; }
        public DbSet<Notification> Notifications { get; set; }
        public DbSet<UserActivation> UserActivations { get; set; }
        public DbSet<UserRestore> UserRestores { get; set; }
        public DbSet<Announcement> Announcements { get; set; }
        public DbSet<AnnouncementDeal> announcementDeals { get; set; }
        public DbSet<AnnouncementLocation> AnnouncementLocations { get; set; }
        public DbSet<AnnouncementPhoto> AnnouncementPhotos { get; set; }
        public DbSet<AnnouncementProperty> AnnouncementProperties { get; set; }
        public DbSet<AnnouncementRent> AnnouncementRents { get; set; }
        public DbSet<AnnouncementSale> AnnouncementSales { get; set; }
        public DbSet<AnnouncementVideo> AnnouncementVideos { get; set; }
        public DbSet<AnnouncementBuilding> AnnouncementBuildings { get; set; }
        public DbSet<AnnouncementGardenBuilding> AnnouncementGardenBuildings { get; set; }
        public DbSet<AnnouncementHouseBuilding> AnnouncementHouseBuildings { get; set; }
        public DbSet<AnnouncementNewBuilding> AnnouncementNewBuildings { get; set; }
        public DbSet<AnnouncementOldBuilding> AnnouncementOldBuildings { get; set; }
        public DbSet<AnnouncementObject> AnnouncementObjects { get; set; }
        public DbSet<AnnouncementGarageObject> AnnouncementGarageObjects { get; set; }
        public DbSet<AnnouncementLandObject> AnnouncementLandObjects { get; set; }
        public DbSet<AnnouncementOfficeObject> AnnouncementOfficeObjects { get; set; }
        public DbSet<AnnouncementContact> AnnouncementContacts { get; set; }
        public DbSet<AnnouncementContactNumber> AnnouncementContactNumbers { get; set; }
        public DbSet<Translation> Translations { get; set; }
        public DbSet<NavbarComponent> NavbarComponents { get; set; }
        public DbSet<PageSetting> PageSetting { get; set; }
        public DbSet<PhonePrefix> PhonePrefixes { get; set; }


        #region ConfigurationMethods

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.ApplyConfiguration(new UserConfiguration());
            builder.ApplyConfiguration(new RoleConfiguration());
            builder.ApplyConfiguration(new NotifyEventConfiguration());
            builder.ApplyConfiguration(new SmsOperationResultConfiguration());
            builder.ApplyConfiguration(new NotificationConfiguration());
            builder.ApplyConfiguration(new UserActivationConfiguration());
            builder.ApplyConfiguration(new UserRestoreConfiguration());

            #region AnnouncementConfiguration

            builder.ApplyConfiguration(new AnnouncementConfiguration());
            builder.ApplyConfiguration(new AnnouncementLocationConfiguration());
            builder.ApplyConfiguration(new AnnouncementPhotoConfiguration());
            builder.ApplyConfiguration(new AnnouncementDealConfiguration());
            builder.ApplyConfiguration(new AnnouncementRentConfiguration());
            builder.ApplyConfiguration(new AnnouncementSaleConfiguration());
            builder.ApplyConfiguration(new AnnouncementVideoConfiguration());
            builder.ApplyConfiguration(new AnnouncementPropertyConfiguration());
            builder.ApplyConfiguration(new AnnouncementBuildingConfiguration());
            builder.ApplyConfiguration(new AnnouncementGardenBuildingConfiguration());
            builder.ApplyConfiguration(new AnnouncementHouseBuildingConfiguration());
            builder.ApplyConfiguration(new AnnouncementHouseBuildingConfiguration());
            builder.ApplyConfiguration(new AnnouncementNewBuildingConfiguration());
            builder.ApplyConfiguration(new AnnouncementOldBuildingConfiguration());
            builder.ApplyConfiguration(new AnnouncementObjectConfiguration());
            builder.ApplyConfiguration(new AnnouncementGarageObjectConfiguration());
            builder.ApplyConfiguration(new AnnouncementLandObjectConfiguration());
            builder.ApplyConfiguration(new AnnouncementOfficeObjectConfiguration());

            #endregion
            
            builder.ApplyConfiguration(new TranslationConfiguration());
            builder.ApplyConfiguration(new NavbarComponentConfiguration());
            builder.ApplyConfiguration(new PageSettingsConfiguration());
            builder.ApplyConfiguration(new PhonePrefixConfiguration());
        }

        public override int SaveChanges(bool acceptAllChangesOnSuccess)
        {
            OnBeforeSaving();
            return base.SaveChanges(acceptAllChangesOnSuccess);
        }

        public override async Task<int> SaveChangesAsync(
           bool acceptAllChangesOnSuccess,
           CancellationToken cancellationToken = default(CancellationToken)
        )
        {
            OnBeforeSaving();
            return (await base.SaveChangesAsync(acceptAllChangesOnSuccess,
                          cancellationToken));
        }

        private void OnBeforeSaving()
        {
            var entries = ChangeTracker.Entries();
            var utcNow = DateTime.UtcNow;

            foreach (var entry in entries)
            {
                // for entities that implements ICreateTiming,
                // set CreatedAt to current UTC 
                if (entry.Entity is ICreatedAt createdEntity && entry.State == EntityState.Added)
                {
                    createdEntity.CreatedAt = utcNow;
                }

                if (entry.Entity is IUpdatedAt updatedEntity && entry.State == EntityState.Modified)
                {
                    // set the updated date to "now"
                    updatedEntity.UpdatedAt = utcNow;

                    if (entry.Entity is ICreatedAt _)
                    {
                        // mark property as "don't touch"
                        // we don't want to update on a Modify operation
                        entry.Property("CreatedAt").IsModified = false;
                    }

                }
            }
        }

        #endregion
    }
}
