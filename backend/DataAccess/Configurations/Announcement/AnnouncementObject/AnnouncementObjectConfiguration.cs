using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Configurations.Announcement.AnnouncementObject
{
    public class AnnouncementObjectConfiguration : IEntityTypeConfiguration<Core.Entities.Announcement.AnnouncementObject.AnnouncementObject>
    {
        public void Configure(EntityTypeBuilder<Core.Entities.Announcement.AnnouncementObject.AnnouncementObject> builder)
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
               .WithOne(a => a.AnnouncementObject)
               .HasForeignKey<Core.Entities.Announcement.AnnouncementObject.AnnouncementObject>(a => a.AnnouncementPropertyId)
               .OnDelete(DeleteBehavior.Cascade);


            #endregion

            builder
                .ToTable("AnnouncementObjects");
        }
    }
}
