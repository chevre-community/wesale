using Core.Entities.Announcement.AnnouncementContact;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Configurations.Announcement.AnnouncementContact
{
    public class AnnouncementContactNumberConfiguration : IEntityTypeConfiguration<AnnouncementContactNumber>
    {
        public void Configure(EntityTypeBuilder<AnnouncementContactNumber> builder)
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
               .HasOne(a => a.AnnouncementContact)
               .WithMany(a => a.AnnouncementContactNumbers)
               .HasForeignKey(a => a.AnnouncementContactId)
               .OnDelete(DeleteBehavior.Cascade);

            #endregion

            builder
                .ToTable("AnnouncementContactNumbers");
        }
    }
}
