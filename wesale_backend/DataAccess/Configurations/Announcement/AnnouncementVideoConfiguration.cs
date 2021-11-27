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
    public class AnnouncementVideoConfiguration : IEntityTypeConfiguration<AnnouncementVideo>
    {
        public void Configure(EntityTypeBuilder<AnnouncementVideo> builder)
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
               .WithMany(a => a.AnnouncementVideos)
               .HasForeignKey(a => a.AnnouncementId)
               .OnDelete(DeleteBehavior.Cascade);

            builder
              .HasOne(a => a.User)
              .WithMany(a => a.AnnouncementVideos)
              .HasForeignKey(a => a.UserId)
              .OnDelete(DeleteBehavior.NoAction);
            #endregion

            builder
                .ToTable("AnnouncementVideos");
        }
    }
}
