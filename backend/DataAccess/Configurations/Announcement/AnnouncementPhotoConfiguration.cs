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
    public class AnnouncementPhotoConfiguration : IEntityTypeConfiguration<AnnouncementPhoto>
    {
        public void Configure(EntityTypeBuilder<AnnouncementPhoto> builder)
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
               .WithMany(a => a.AnnouncementPhotos)
               .HasForeignKey(a => a.AnnouncementId)
               .OnDelete(DeleteBehavior.Cascade);

            builder
               .HasOne(a => a.User)
               .WithMany(a => a.AnnouncementPhotos)
               .HasForeignKey(a => a.UserId)
               .OnDelete(DeleteBehavior.NoAction);

            #endregion

            builder
                .ToTable("AnnouncementPhotos");
        }
    }
}
