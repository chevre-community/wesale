using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Configurations.Announcement.AnnouncementContact
{
    public class AnnouncementContactConfiguration : IEntityTypeConfiguration<Core.Entities.Announcement.AnnouncementContact.AnnouncementContact>
    {
        public void Configure(EntityTypeBuilder<Core.Entities.Announcement.AnnouncementContact.AnnouncementContact> builder)
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
               .WithOne(a => a.AnnouncementContact)
               .HasForeignKey<Core.Entities.Announcement.AnnouncementContact.AnnouncementContact>(a => a.AnnouncementId)
               .OnDelete(DeleteBehavior.Cascade);

            #endregion

            builder
                .ToTable("AnnouncementContacts");
        }
    }
}
