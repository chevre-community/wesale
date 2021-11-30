using Core.Entities.Announcement.AnnouncementObject;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Configurations.Announcement.AnnouncementObject
{
    public class AnnouncementLandObjectConfiguration : IEntityTypeConfiguration<AnnouncementLandObject>
    {
        public void Configure(EntityTypeBuilder<AnnouncementLandObject> builder)
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
               .HasOne(a => a.AnnouncementObject)
               .WithOne(a => a.AnnouncementLandObject)
               .HasForeignKey<AnnouncementLandObject>(a => a.AnnouncementObjectId)
               .OnDelete(DeleteBehavior.Cascade);

            #endregion

            builder
                .ToTable("AnnouncementLandObjects");
        }
    }
}
