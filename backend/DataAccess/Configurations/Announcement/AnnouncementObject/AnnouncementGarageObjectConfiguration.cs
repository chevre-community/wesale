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
    public class AnnouncementGarageObjectConfiguration : IEntityTypeConfiguration<AnnouncementGarageObject>
    {
        public void Configure(EntityTypeBuilder<AnnouncementGarageObject> builder)
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
               .WithOne(a => a.AnnouncementGarageObject)
               .HasForeignKey<AnnouncementGarageObject>(a => a.AnnouncementObjectId)
               .OnDelete(DeleteBehavior.Cascade);

            #endregion

            builder
                .ToTable("AnnouncementGarageObjects");
        }
    }
}
