using Core.Entities.Announcement;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Configurations.Announcement
{
    public class AnnouncementLocationConfiguration : IEntityTypeConfiguration<AnnouncementLocation>
    {
        public void Configure(EntityTypeBuilder<AnnouncementLocation> builder)
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
               .HasOne(a => a.Announcement)
               .WithOne(a => a.AnnouncementLocation)
               .HasForeignKey<AnnouncementLocation>(a => a.AnnouncementId)
               .OnDelete(DeleteBehavior.Cascade);

            #endregion

            builder
                .ToTable("AnnouncementLocations");
        }
    }
}
