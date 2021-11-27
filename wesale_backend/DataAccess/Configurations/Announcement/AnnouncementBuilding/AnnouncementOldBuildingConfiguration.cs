using Core.Entities.Announcement.AnnouncementBuilding;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Configurations.AnnouncementBuilding
{
    public class AnnouncementOldBuildingConfiguration : IEntityTypeConfiguration<AnnouncementOldBuilding>
    {
        public void Configure(EntityTypeBuilder<AnnouncementOldBuilding> builder)
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
               .HasOne(a => a.AnnouncementBuilding)
               .WithOne(a => a.AnnouncementOldBuilding)
               .HasForeignKey<AnnouncementOldBuilding>(a => a.AnnouncementBuildingId)
               .OnDelete(DeleteBehavior.Cascade);

            #endregion

            builder
                .ToTable("AnnouncementOldBuildings");
        }
    }
}
