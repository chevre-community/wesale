using Core.Entities.Announcement;
using Core.Entities.Announcement.AnnouncementBuilding;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Configurations.Announcement.AnnouncementBuilding
{
    public class AnnouncementBuildingConfiguration : IEntityTypeConfiguration<Core.Entities.Announcement.AnnouncementBuilding.AnnouncementBuilding>
    {
        public void Configure(EntityTypeBuilder<Core.Entities.Announcement.AnnouncementBuilding.AnnouncementBuilding> builder)
        {
            #region Id

            builder
                .HasKey(a => a.Id);

            builder
                .Property(a => a.Id)
                .UseIdentityColumn();

            #endregion

            #region NavigationProperties

            builder
               .HasOne(a => a.AnnouncementProperty)
               .WithOne(a => a.AnnouncementBuilding)
               .HasForeignKey<Core.Entities.Announcement.AnnouncementBuilding.AnnouncementBuilding>(a => a.AnnouncementPropertyId)
               .OnDelete(DeleteBehavior.Cascade);

            #endregion

            builder
                .ToTable("AnnouncementBuildings");
        }
    }
}
